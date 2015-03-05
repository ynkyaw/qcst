using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.SalePlanning;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.VC.Sale.Trip
{
    public partial class frmRoutePlan : Form
    {

        private DataTable routeTbl = new DataTable();
        private DataTable vehicleTbl = new DataTable();
        private DataTable routeplanTbl = new DataTable();
        private DataTable employeeTbl = new DataTable();
        private int count = 0;

        public frmRoutePlan()
        {
            InitializeComponent();
            LoadData();
            DataTable dt = dgvRoutePlan.DataSource as DataTable;
            DataUtil.AddInitialNewRow(dgvRoutePlan);
        }

        private void LoadData()
        {
            SqlConnection conn = null;
            dtpTranDate.Value = DateTime.Today;
            dtpPlanDate.Value = DateTime.Today;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                routeTbl = new RouteBL().GetAll();
                vehicleTbl = new VehicleBL().GetAll();
                //routeplanTbl = new RoutePlanBL().GetAll(conn);
                routeplanTbl = new RoutePlanBL().GetAllView(conn);
                employeeTbl = new EmployeeBL().GetAll();

                cmbRouteName.DataSource = routeTbl;
                cmbRouteName.DisplayMember = routeTbl.Columns["RouteName"].ToString();
                cmbRouteName.ValueMember = routeTbl.Columns["RouteID"].ToString();

                cmbSalePerson.DataSource = employeeTbl;
                cmbSalePerson.DisplayMember = employeeTbl.Columns["EmpName"].ToString();
                cmbSalePerson.ValueMember = employeeTbl.Columns["EmployeeID"].ToString();

                cmbVanNo.DataSource = vehicleTbl;
                cmbVanNo.DisplayMember = vehicleTbl.Columns["VenNo"].ToString();
                cmbVanNo.ValueMember = vehicleTbl.Columns["VehicleID"].ToString();

                dgvRoutePlan.AutoGenerateColumns = false;
                
                clnVanNo.DataPropertyName = "VenNo";
                clnSalePerson.DataPropertyName = "EmpName";
                clnRouteName.DataPropertyName = "RouteName";
                clnRoutePlanNo.DataPropertyName = "RoutePlanNo";
                clnPlanDate.DataPropertyName = "PlanDate";
                dgvRoutePlan.DataSource = routeplanTbl;
            }
            catch (SqlException sqle)
            {

            }
            //ToastMessageBox.Show("Frequency - " + count.ToString(), Color.Orange);
            //ToastMessageBox.Show("THis form is UnderConstruction", Color.Crimson);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRplanNo.Text == null || txtRplanNo.Text =="")
            {
                ToastMessageBox.Show("FIll Route Plan No.", Color.Crimson);
            }
            else
            {
                Save();
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            int affected = 0;
            
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                RoutePlan routeplan = new RoutePlan();

                routeplan.RoutePlanNo = txtRplanNo.Text;
                routeplan.SalesPersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
                routeplan.RouteID = (int)DataTypeParser.Parse(cmbRouteName.SelectedValue, typeof(int), -1);
                routeplan.VenID = (int)DataTypeParser.Parse(cmbVanNo.SelectedValue, typeof(int), -1);
                routeplan.TranDate = dtpTranDate.Value;
                routeplan.PlanDate = dtpPlanDate.Value;

                affected = new RoutePlanBL().Save(routeplan, conn);
                

            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                if (affected > 0)
                {                    
                    dgvRefresh();
                    //ClearData();
                    txtRplanNo.Text = "";
                    btnSave.Enabled = false;
                    btnEdit.Enabled = false;
                    txtRplanNo.Focus();
                }
            }
        }

        private void dgvRefresh()
        {
            SqlConnection conn = null;

            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                routeplanTbl = new RoutePlanBL().GetAllView(conn);

                dgvRoutePlan.DataSource = routeplanTbl;
                //dgvRoutePlan.Refresh();
            }
            catch (SqlException sqle)
            {

            }

        }

        private void txtRplanNo_TextChanged(object sender, EventArgs e)
        {
            if (txtRplanNo.Text != null)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void dgvRoutePlan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }    //ToastMessageBox.Show(e.ListChangedType.ToString());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvRoutePlan.CurrentCell.ColumnIndex;
                int iRow = dgvRoutePlan.CurrentCell.RowIndex;
                if (iColumn == dgvRoutePlan.Columns["clnVanNo"].Index)
                {
                    if (iRow + 1 >= dgvRoutePlan.Rows.Count)
                    {
                        if (dgvRoutePlan.CurrentRow.ErrorText == String.Empty)
                        {
                            DataUtil.AddNewRow(dgvRoutePlan.DataSource as DataTable);
                            dgvRoutePlan[0, iRow + 1].Selected = true;
                        }
                    }
                    else
                    {
                        dgvRoutePlan.CurrentCell = dgvRoutePlan[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvRoutePlan.CurrentCell = dgvRoutePlan[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }

                    //dgvsetupbsetting.CurrentCell = dgvsetupbsetting[dgvsetupbsetting.CurrentCell.ColumnIndex + 1, dgvsetupbsetting.CurrentCell.RowIndex];
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvRoutePlan_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row.Cells["clnNo"].Value = e.Row.Index+1;
        }

        private void lblSalePage_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalePlanningPage));
            this.Close();
        }

        private void dgvRoutePlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Set Route Plan No:
            //var gv = sender as DataGridView;
            //DataGridViewRow curRow = gv.Rows[e.RowIndex];
            //txtRplanNo.Text = curRow.Cells["clnRoutePlanNo"].Value.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvRoutePlan.DataSource as DataTable);
            dgvRoutePlan.CurrentCell = dgvRoutePlan.Rows[dgvRoutePlan.RowCount - 1].Cells["clnPlanDate"];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
            // Delete selecte row from GridView and record from database
            if (dgvRoutePlan.CurrentRow.IsNewRow || dgvRoutePlan.SelectedRows.Count < 1 || dgvRoutePlan.DataSource == null)
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;
            // Get selected RoutePlan
            DataGridViewRow selectedRow = dgvRoutePlan.CurrentRow;
            int routePlanID = (int)DataTypeParser.Parse(selectedRow.Cells["clnRoutePlanID"].Value, typeof(int), -1);
            DeleteRoutePlan(routePlanID);
        }

        private void DeleteRoutePlan(int routePlanID)
        {
            int affectedRow = new RoutePlanBL().DeleteByID(routePlanID);
            if (affectedRow > 0)
            {
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                // Reload route plans
                LoadData();
            }
            else
                ToastMessageBox.Show(Resource.errFailedToSave);
        }

        private void dgvRoutePlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            // Set Route Plan No:
            var gv = sender as DataGridView;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            DataRow row = curRow.DataBoundItem as DataRow;
            txtRplanNo.Text = curRow.Cells["clnRoutePlanNo"].Value.ToString();
            cmbRouteName.SelectedValue = DataTypeParser.Parse(curRow.Cells["clnRouteID"].Value, typeof(int), -1);
            cmbSalePerson.SelectedValue = DataTypeParser.Parse(curRow.Cells["clnEmpID"].Value, typeof(int), -1);
            dtpPlanDate.Value = (DateTime)DataTypeParser.Parse(curRow.Cells["clnPlanDate"].Value, typeof(DateTime), DateTime.Now);
            cmbVanNo.SelectedValue = DataTypeParser.Parse(curRow.Cells["clnVenID"].Value, typeof(int), -1);
            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtRplanNo.Text == null || txtRplanNo.Text == "")
            {
                ToastMessageBox.Show("FIll Route Plan No.", Color.Crimson); return;
            }
            // Get selected RoutePlan
            DataGridViewRow selectedRow = dgvRoutePlan.CurrentRow;
            
            RoutePlan routeplan = new RoutePlan();
            routeplan.ID = (int)DataTypeParser.Parse(selectedRow.Cells["clnRoutePlanID"].Value, typeof(int), -1);
            routeplan.RoutePlanNo = txtRplanNo.Text;
            routeplan.SalesPersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
            routeplan.RouteID = (int)DataTypeParser.Parse(cmbRouteName.SelectedValue, typeof(int), -1);
            routeplan.VenID = (int)DataTypeParser.Parse(cmbVanNo.SelectedValue, typeof(int), -1);
            routeplan.TranDate = dtpTranDate.Value;
            routeplan.PlanDate = dtpPlanDate.Value;

            SqlConnection conn = null;
            int affected = 0;
            
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                affected = new RoutePlanBL().Update(routeplan, conn);
            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                if (affected > 0)
                {
                    dgvRefresh();
                    //ClearData();
                    txtRplanNo.Text = "";
                    btnSave.Enabled = false;
                    btnEdit.Enabled = false;
                    txtRplanNo.Focus();
                }
            }
        }
        
    }
}
