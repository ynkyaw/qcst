using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Common.BL;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Sale.Order;

namespace PTIC.VC.Sale.Inventory
{
    public partial class frmShowRoomMovement : Form
    {
        /// <summary>
        /// Variable DeliveryDate
        /// </summary>
        /// 
        DateTime DeliveryDate;

        /// <summary>
        /// Variable SalesPerson,MoveFrom,MoveTo
        /// </summary>
        /// 
        int SalesPerson, MoveFrom, MoveTo, VenNo;

        /// <summary>
        /// ShowRoomMovement Entities
        /// </summary>
        /// 
        ShowRoomMovement showRoomMovement = new ShowRoomMovement();

        DataTable dtShowRoomMovementScheme = null;

        public frmShowRoomMovement()
        {
            InitializeComponent();
            LoadNBind();
            DeliveryDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
            SalesPerson = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
            MoveFrom = (int)DataTypeParser.Parse(cmbDeliverShowRoom.SelectedValue, typeof(int), -1);
            MoveTo = (int)DataTypeParser.Parse(cmbReceivedShowRoom.SelectedValue, typeof(int), -1);
            VenNo = (int)DataTypeParser.Parse(cmbVen.SelectedValue, typeof(int), -1);
            DataUtil.AddInitialNewRow(dgvShowRoomMovement);
        }

        #region Private Methods
        public void LoadNBind()
        {            
            try
            {                
                // Load employees
                cmbSalePerson.DataSource = new EmployeeBL().GetAll();
                //  Load SubStore
                cmbDeliverShowRoom.DataSource = new WarehouseBL().GetAllSubStore();
                // 
                cmbReceivedShowRoom.DataSource = new WarehouseBL().GetAllSubStore();

                // Load vehicles
                cmbVen.DataSource = new VehicleBL().GetAll();

                dgvShowRoomMovement.AutoGenerateColumns = false;
                dgvShowRoomMovement.DataSource = dtShowRoomMovementScheme = new ShowRoomMovementBL().GetScheme();
                colQty.ReadOnly = false;
                colRequest.ReadOnly = false;
                colReceivedQty.ReadOnly = true;
                btnReceived.Enabled = false;
                btnDeliver.Enabled = true;

                colProductID.DataSource = new ProductBL().GetAll();
                colProductID.DisplayMember = "ProductName";
                colProductID.ValueMember = "ProductID";
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
            // Load employees
            cmbSalePerson.DataSource = new EmployeeBL().GetAll();
        }

        public void LoadNBindWithCondition(DateTime DeliverDate, int SalePerson, int MoveFrom, int MoveTo, int VenNo)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtShowRoomMovement = new ShowRoomMovementBL().GetByCondition(DeliveryDate, SalesPerson, MoveFrom, MoveTo, VenNo);
                if (dtShowRoomMovement.Rows.Count > 0)
                {
                    if ((bool)DataTypeParser.Parse(dtShowRoomMovement.Rows[0]["Status"], typeof(bool), false) == true)
                    {
                        btnReceived.Enabled = false;
                    }
                    else
                    {
                        btnReceived.Enabled = true;
                    }
                    dgvShowRoomMovement.DataSource = dtShowRoomMovement;
                    colQty.ReadOnly =true;
                    colRequest.ReadOnly = true;
                    colProductID.ReadOnly = true;
                    colReceivedQty.ReadOnly = false;                   
                    btnDeliver.Enabled = false;
                }
                else
                {
                    dgvShowRoomMovement.DataSource = dtShowRoomMovementScheme;
                    colQty.ReadOnly = false;
                    colRequest.ReadOnly = false;
                    colReceivedQty.ReadOnly = true;
                    btnReceived.Enabled = false;
                    btnDeliver.Enabled = true;
                }
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }

        public void Save()
        {
            DataTable dt = dgvShowRoomMovement.DataSource as DataTable;
            SqlConnection conn = null;
            int sup = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    //showRoomMovement.ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), 0);
                    showRoomMovement.DeliverDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                    showRoomMovement.SalePersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
                    showRoomMovement.MoveFrom = (int)DataTypeParser.Parse(cmbDeliverShowRoom.SelectedValue, typeof(int), -1);
                    showRoomMovement.MoveTo = (int)DataTypeParser.Parse(cmbReceivedShowRoom.SelectedValue, typeof(int), -1);
                    showRoomMovement.VenID = (int)DataTypeParser.Parse(cmbVen.SelectedValue, typeof(int), 0);
                    showRoomMovement.ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1);
                    showRoomMovement.RequestQty = (int)DataTypeParser.Parse(row["RequestQty"], typeof(int), 0);
                    showRoomMovement.DeliverQty = (int)DataTypeParser.Parse(row["DeliverQty"], typeof(int), 0);
                    showRoomMovement.ReceivedQty = (int?)DataTypeParser.Parse(row["ReceivedQty"], typeof(int), 0);
                    showRoomMovement.Status = (bool)DataTypeParser.Parse(row["Status"], typeof(bool), false);
                    if (showRoomMovement.ProductID != -1 && showRoomMovement.DeliverQty != 0 && showRoomMovement.RequestQty != 0)
                    {
                        sup = new ShowRoomMovementBL().Move(showRoomMovement, conn);
                    }
                }

                //// delete
                //DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                //foreach (DataRow row in dvDelete.ToTable().Rows)
                //{
                //    bank.BankID = (int)DataTypeParser.Parse(row["BankID"].ToString(), typeof(int), -1);
                //    sup = new BankBL().Delete(bank, conn);
                //}        

                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    showRoomMovement.ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), 0);
                    showRoomMovement.DeliverDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                    showRoomMovement.SalePersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
                    showRoomMovement.MoveFrom = (int)DataTypeParser.Parse(cmbDeliverShowRoom.SelectedValue, typeof(int), -1);
                    showRoomMovement.MoveTo = (int)DataTypeParser.Parse(cmbReceivedShowRoom.SelectedValue, typeof(int), -1);
                    showRoomMovement.VenID = (int)DataTypeParser.Parse(cmbVen.SelectedValue, typeof(int), 0);
                    showRoomMovement.ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1);
                    showRoomMovement.RequestQty = (int)DataTypeParser.Parse(row["RequestQty"], typeof(int), 0);
                    showRoomMovement.DeliverQty = (int)DataTypeParser.Parse(row["DeliverQty"], typeof(int), 0);
                    showRoomMovement.ReceivedQty = (int?)DataTypeParser.Parse(row["ReceivedQty"], typeof(int), 0);
                    showRoomMovement.Status = (bool)DataTypeParser.Parse(row["Status"], typeof(bool), -1);
                    if (showRoomMovement.ProductID != -1 && showRoomMovement.DeliverQty != 0 && showRoomMovement.RequestQty != 0 && showRoomMovement.ReceivedQty !=0)
                    {
                        sup = new ShowRoomMovementBL().MoveUpdate(showRoomMovement,conn);
                    }
                }

                if (sup > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.GreenYellow);
                    //LoadNBindSalesReturn((int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), 0), (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now));
                    this.Close();
                }
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }
        #endregion

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DeliveryDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
            //LoadNBindWithCondition(DeliveryDate, SalesPerson, MoveFrom, MoveTo,VenNo);
        }

        private void cmbSalePerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            SalesPerson = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
            //LoadNBindWithCondition(DeliveryDate, SalesPerson, MoveFrom, MoveTo,VenNo);
        }

        private void cmbDeliverShowRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoveFrom = (int)DataTypeParser.Parse(cmbDeliverShowRoom.SelectedValue, typeof(int), -1);
            //if (cmbDeliverShowRoom.SelectedIndex == cmbReceivedShowRoom.SelectedIndex)
            //{
            //    MessageBox.Show("ပို့မည့် ShowRoom မတူရပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
           // LoadNBindWithCondition(DeliveryDate, SalesPerson, MoveFrom, MoveTo,VenNo);
        }

        private void cmbReceivedShowRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoveTo = (int)DataTypeParser.Parse(cmbReceivedShowRoom.SelectedValue, typeof(int), -1);
            //if (cmbDeliverShowRoom.SelectedIndex == cmbReceivedShowRoom.SelectedIndex)
            //{
            //    MessageBox.Show("ပို့မည့် ShowRoom မတူရပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
           // LoadNBindWithCondition(DeliveryDate, SalesPerson, MoveFrom, MoveTo,VenNo);
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            if (dgvShowRoomMovement.Rows[dgvShowRoomMovement.CurrentRow.Index].ErrorText != String.Empty)
                MessageBox.Show(Resource.errFailedToSave);
            else if(cmbDeliverShowRoom.SelectedIndex == cmbReceivedShowRoom.SelectedIndex)
            {
                MessageBox.Show("ပို့မည့် ShowRoom မတူရပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
                Save();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvShowRoomMovement.CurrentCell.ColumnIndex;
                int iRow = dgvShowRoomMovement.CurrentCell.RowIndex;
                if (iColumn == dgvShowRoomMovement.Columns[colStatus.Index].Index)
                {
                    if (iRow + 1 >= dgvShowRoomMovement.Rows.Count)
                    {
                        DataTable dt = dgvShowRoomMovement.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvShowRoomMovement.DataSource = dt;
                        dgvShowRoomMovement[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvShowRoomMovement.CurrentCell = dgvShowRoomMovement[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvShowRoomMovement.CurrentCell = dgvShowRoomMovement[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvShowRoomMovement_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Set row number
            foreach (DataGridViewRow r in dgv.Rows)
            {
                dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void frmShowRoomMovement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadNBindWithCondition(DeliveryDate, SalesPerson, MoveFrom, MoveTo, VenNo);
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgvShowRoomMovement_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
           
            if ((int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colQty.Index].Value, typeof(int), 0) > (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colRequest.Index].Value, typeof(int), 0))
            {
                if (dgv.CurrentRow.Cells[colProductID.Index].Value.ToString() != string.Empty)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "Amount is Invalid!";
                    MessageBox.Show("Amount is Invalid");
                    dgv.CurrentRow.Cells[colQty.Index].Value = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colQty.Index].Value, typeof(int), 0);
                }
                else
                {
                    dgv.Rows[e.RowIndex].ErrorText = "Amount is Invalid";
                }
            }
            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && colQty.Index == e.ColumnIndex)
            {
                dgv.CurrentRow.Cells[colQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void dgvShowRoomMovement_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvShowRoomMovement_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            DataTable dt = dgv.DataSource as DataTable;

            if (e.ColumnIndex == dgv.CurrentRow.Cells[colQty.Index].ColumnIndex || e.ColumnIndex == dgv.CurrentRow.Cells[colRequest.Index].ColumnIndex)
            {
                int newInteger;
                if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be fill";
                }              
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be integer";
                }
                else
                {
                    dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));           
        }
    }
}
