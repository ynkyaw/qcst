using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Util;
using PTIC.Sale.BL;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmTelemarketingPlan : Form
    {
        /// <summary>
        /// Record table for different CustomerType
        /// </summary>
        private DataTable _dtCusType = null;

        /// <summary>
        /// Index of Township column from DataGridView
        /// </summary>
        private int _indexTownshipColumn = -1;

        /// <summary>
        /// Index of CustomerType column from DataGridView
        /// </summary>
        private int _indexCusTyepColumn = -1;

        /// <summary>
        /// 
        /// </summary>
        private ComboBox _cmbCusType = null;

        PTIC.Marketing.Entities.MarketingPlan marketingplan = new PTIC.Marketing.Entities.MarketingPlan();
        DataTable telemarketingplanTbl = null;

        public frmTelemarketingPlan()
        {
            InitializeComponent();
            this._indexTownshipColumn = dgvTeleMarketingPlan.Columns.IndexOf(dgvTeleMarketingPlan.Columns["dgvColTownship"]);
            this._indexCusTyepColumn = dgvTeleMarketingPlan.Columns.IndexOf(dgvTeleMarketingPlan.Columns["dgvColCusType"]);
            LoadNBindGrid(); // Change By AKK
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvTeleMarketingPlan);
        }

        #region Private Method

        private void LoadNBindData()
        {
            DataSet ds = new DataSet();            
            try
            {                
                //Bind Township
                dgvColTownship.DataSource = new TownshipBL().GetAll();
                //Bind CustomerType
                dgvColCusType.DataSource = this._dtCusType = new CusTypeBL().GetAll();

                dgvColTownship.DisplayMember = "Township";
                dgvColTownship.ValueMember = "TownshipID";

                dgvColCusType.DisplayMember = "CusTypeName";
                dgvColCusType.ValueMember = "CusTypeID";               
            }
            catch (SqlException sqle)
            {
                // _logger.Error(sqle);
            }           
        }

        private void LoadNBindGrid()
        {
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                telemarketingplanTbl = new MarketingPlanBL().GetMarketingPlan(1, conn);

                dgvTeleMarketingPlan.AutoGenerateColumns = false; // Autogenerate Columns False
                dgvTeleMarketingPlan.DataSource = telemarketingplanTbl;

                dgvColCusName.DataSource = telemarketingplanTbl;
                dgvColCusName.ValueMember = "CustomerID";
                dgvColCusName.DisplayMember = "CusName";
                dgvColCusName.DataPropertyName = "CustomerID";

            }
            catch (SqlException Sqle)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void Save()
        {
            DataTable dt = dgvTeleMarketingPlan.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    marketingplan.CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                    marketingplan.PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"].ToString(), typeof(DateTime), null);
                    // marketingplan.EmpID = (int)DataTypeParser.Parse(row["EmpID"].ToString(), typeof(int), -1);
                    marketingplan.MarketingType = 1;
                    if (marketingplan.CustomerID == -1)
                    {
                        ToastMessageBox.Show( Resource.errCustomer, Color.Red);
                        return;
                    }

                    else if (marketingplan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    }                    
                    sup = MarketingPlanDA.InsertTeleMarketingPlan(marketingplan, conn);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    marketingplan.ID = (int)DataTypeParser.Parse(row["MarketingPlanID"].ToString(), typeof(int), -1);
                    sup = MarketingPlanDA.DeleteByID(marketingplan, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    marketingplan.ID = (int)DataTypeParser.Parse(row["MarketingPlanID"].ToString(), typeof(int), -1);
                    marketingplan.CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                    marketingplan.PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"].ToString(), typeof(DateTime), null);
                    //marketingplan.EmpID = (int)DataTypeParser.Parse(row["EmpID"].ToString(), typeof(int), -1);
                    marketingplan.MarketingType = (int)DataTypeParser.Parse(row["MarketingType"].ToString(), typeof(int), -1);
                    if (marketingplan.CustomerID == -1)
                    {
                        ToastMessageBox.Show( Resource.errCustomer, Color.Red);
                        return;
                    }

                    else if (marketingplan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    }          
                    sup = MarketingPlanDA.UpdateTeleMarketingByID(marketingplan, conn);
                }

                if (sup > 0)
                {
                    LoadNBindGrid();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
                else
                {
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }

            }
            catch (Exception sqle)
            {
                // show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region Event Handler

        private void dgvMarketingPlan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTeleMarketingPlan.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvTeleMarketingPlan.SelectedRows)
                {
                    dgvTeleMarketingPlan.Rows.RemoveAt(item.Index);
                }
                Save();
                if (dgvTeleMarketingPlan.RowCount == 0)
                {
                    DataRow newRow = telemarketingplanTbl.NewRow();
                    telemarketingplanTbl.Rows.Add(newRow);
                    this.dgvTeleMarketingPlan.DataSource = telemarketingplanTbl;
                }
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            try
            {                
                DateTime startdate = dtpStartDate.Value;
                DateTime enddate = dtpEndDate.Value;
                int marketingtype = 1;
                DataTable dt = MarketingPlanDA.SearchByID(startdate, enddate, marketingtype);
                dgvTeleMarketingPlan.DataSource = dt;
            }
            catch (SqlException Sqle)
            {
                //To do 
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void dgvTeleMarketingPlan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell currentcmb;
            if (e.RowIndex == -1)
                return;
            if (sender is DataGridView && (e.ColumnIndex == 3 || e.ColumnIndex == 4))
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgvTeleMarketingPlan.Equals(dgv))
                {
                    CustomerName cusname = new CustomerName();
                    SqlConnection conn = null;
                    DataTable dt = null;

                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();
                        cusname.TownshipID = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells[2].Value.ToString(), typeof(int), -1);
                        cusname.CusType = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells[3].Value.ToString(), typeof(int), -1);
                        dt = new MarketingPlanBL().GetCusName(cusname, conn);
                        currentcmb = dgvTeleMarketingPlan.CurrentRow.Cells["dgvColCusName"] as DataGridViewComboBoxCell; //or column name inside brackets!
                        currentcmb.DataSource = dt;
                        //   dgvTeleMarketingPlan.CurrentRow.Cells["dgvColCusName"].Value = 

                        //dgvColCusName.DisplayMember = "CusName";
                        //dgvColCusName.ValueMember = "CustomerID";
                    }
                    catch (SqlException Sqle)
                    {
                    }
                    finally
                    {
                        DBManager.GetInstance().CloseDbConnection();
                    }

                }
            }
        }

        private void dgvTeleMarketingPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell currentcmb;
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            DataGridView dgv = (DataGridView)sender;
            if (dgvTeleMarketingPlan.Equals(dgv))
            {
                CustomerName cusname = new CustomerName();
                SqlConnection conn = null;
                DataTable dt = null;

                try
                {
                    conn = DBManager.GetInstance().GetDbConnection();
                    cusname.TownshipID = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells["dgvColTownship"].Value.ToString(), typeof(int), -1);
                    cusname.CusType = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells["dgvColCusType"].Value.ToString(), typeof(int), -1);
                    dt = new MarketingPlanBL().GetCusName(cusname, conn);
                    currentcmb = dgvTeleMarketingPlan.CurrentRow.Cells["dgvColCusName"] as DataGridViewComboBoxCell; //or column name inside brackets!
                    currentcmb.DataSource = dt;

                    //dgvColCusName.DisplayMember = "CusName";
                    //dgvColCusName.ValueMember = "CustomerID";
                }
                catch (SqlException Sqle)
                {
                }
                finally
                {
                    DBManager.GetInstance().CloseDbConnection();
                }

            }
        }

        private void dgvTeleMarketingPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Register an event to filter displaying value of Customer Type column
            if (dgvTeleMarketingPlan.CurrentRow != null && dgvTeleMarketingPlan.CurrentCell.ColumnIndex == _indexCusTyepColumn)
            {
                _cmbCusType = e.Control as ComboBox;
                if (_cmbCusType != null)
                {
                    _cmbCusType.DropDown += new EventHandler(cmbCusType_DropDown);
                }
            }

            ComboBox cmbbox = e.Control as ComboBox;
            if (cmbbox != null)
            {
                // first remove event handler to keep from attaching multiple:
                cmbbox.SelectedIndexChanged -= new
                EventHandler(cb_SelectedIndexChanged);

                // now attach the event handler
                cmbbox.SelectedIndexChanged += new
                EventHandler(cb_SelectedIndexChanged);
            }
        }

        private void cmbCusType_DropDown(object sender, EventArgs e)
        {
            int TownshipID = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells[_indexTownshipColumn].Value, typeof(int), 0);
            if (TownshipID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtCusType, "TownshipID", TownshipID);
            _cmbCusType.DataSource = dtResultProducts;
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerName cusname = new CustomerName();
            SqlConnection conn = null;
            DataTable dt = null;
            // DataGridViewTextBoxCell txtphone;

            if (dgvTeleMarketingPlan.CurrentRow.Cells["dgvColCusName"].Selected == true)
            {
                ComboBox cmbbox = (ComboBox)sender;
                if (cmbbox.SelectedIndex > -1)
                {
                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();
                        int Id = (int)DataTypeParser.Parse(cmbbox.SelectedValue, typeof(int), -1);
                        cusname.TownshipID = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells[2].Value.ToString(), typeof(int), -1);
                        cusname.CusType = (int)DataTypeParser.Parse(dgvTeleMarketingPlan.CurrentRow.Cells[3].Value.ToString(), typeof(int), -1);
                        dt = new MarketingPlanBL().GetCusName(cusname, conn);
                        foreach (DataRow row in dt.Rows)
                        {
                            int cusid = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                            if (cusid == Id)
                            {
                                dgvTeleMarketingPlan["dgvColPhone", dgvTeleMarketingPlan.CurrentRow.Index].Value = row["Phone1"].ToString();
                            }
                        }
                    }
                    catch (SqlException Sqle)
                    {
                    }
                    finally
                    {
                        DBManager.GetInstance().CloseDbConnection();
                    }
                }
            }

        }

        #endregion

        private void dgvTeleMarketingPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dgvTeleMarketingPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgvTeleMarketingPlan.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgvTeleMarketingPlan.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
        }

        private void dgvTeleMarketingPlan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvTeleMarketingPlan.BeginEdit(true);
                e.SuppressKeyPress = true;
                int iColumn = dgvTeleMarketingPlan.CurrentCell.ColumnIndex;
                int iRow = dgvTeleMarketingPlan.CurrentCell.RowIndex;
                if (iColumn == dgvTeleMarketingPlan.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvTeleMarketingPlan.Rows.Count)
                    {
                        DataRow newRow = telemarketingplanTbl.NewRow();
                        telemarketingplanTbl.Rows.Add(newRow);
                        this.dgvTeleMarketingPlan.DataSource = telemarketingplanTbl;
                        dgvTeleMarketingPlan[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvTeleMarketingPlan.CurrentCell = dgvTeleMarketingPlan[0, iRow + 1];
                    }
                }
                else
                {
                    dgvTeleMarketingPlan.CurrentCell = dgvTeleMarketingPlan[iColumn + 1, iRow];
                }

            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvTeleMarketingPlan.SelectedRows)
                    {
                        dgvTeleMarketingPlan.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    DataUtil.AddInitialNewRow(dgvTeleMarketingPlan);
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
        }

        private void dgvTeleMarketingPlan_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbCusType != null)
            {
                _cmbCusType.DropDown -= new EventHandler(cmbCusType_DropDown);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //    dgvMarketingPlan.BeginEdit(true);
                // e.SuppressKeyPress = true;
                int iColumn = dgvTeleMarketingPlan.CurrentCell.ColumnIndex;
                int iRow = dgvTeleMarketingPlan.CurrentCell.RowIndex;
                if (iColumn == dgvTeleMarketingPlan.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvTeleMarketingPlan.Rows.Count)
                    {
                        DataUtil.AddNewRow(dgvTeleMarketingPlan.DataSource as DataTable);
                        dgvTeleMarketingPlan[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvTeleMarketingPlan.CurrentCell = dgvTeleMarketingPlan[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvTeleMarketingPlan.CurrentCell = dgvTeleMarketingPlan[dgvTeleMarketingPlan.CurrentCell.ColumnIndex + 1, dgvTeleMarketingPlan.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvTeleMarketingPlan.SelectedRows)
                    {
                        dgvTeleMarketingPlan.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    if (dgvTeleMarketingPlan.RowCount == 0)
                    {
                        DataRow newRow = telemarketingplanTbl.NewRow();
                        telemarketingplanTbl.Rows.Add(newRow);
                        this.dgvTeleMarketingPlan.DataSource = telemarketingplanTbl;
                    }
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadNBindGrid();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvTeleMarketingPlan.DataSource as DataTable);
        }
        
    }
}