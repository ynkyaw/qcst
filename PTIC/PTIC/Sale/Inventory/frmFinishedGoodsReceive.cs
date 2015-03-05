using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.DA;

namespace PTIC.VC.Sale.Inventory
{
    public partial class frmFinishedGoodsReceive : Form
    {
        int dtFGReceive = -1;

        public frmFinishedGoodsReceive()
        {
            InitializeComponent();
            // Auto generate Column false
            dgvFGReceive.AutoGenerateColumns = false;
            LoadNBindFGRequestDetails();
        }

        #region Events
        private void frmFinishedGoodsReceive_Load(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBindFGRequestDetails();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvFGReceive.Rows[dgvFGReceive.CurrentRow.Index].ErrorText != String.Empty)
                MessageBox.Show(Resource.errFailedToSave);
            else
                Save();
        }
        #endregion

        #region Private Methods
        private void LoadNBindFGRequestDetails()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DateTime requireDate = dtpDate.Value;

                DataTable dtFGRequest = new FGRequestBL().SelectByRequireDate(requireDate, conn);

                if (dtFGRequest.Rows.Count > 0)
                {
                    dgvFGReceive.DataSource = dtFGRequest;
                    if ((int)DataTypeParser.Parse(dtFGRequest.Rows[0]["ID"], typeof(int), 0) == 0)
                    {
                        btnApprove.Enabled = true;
                        dgvFGReceive.Enabled = true;
                        clnProductionDate.ReadOnly = false;
                        clnReceiveQty.ReadOnly = false;
                        clnFactoryRemark.ReadOnly = false;
                    }
                    else
                    {
                        btnApprove.Enabled = false;
                        dgvFGReceive.Enabled = false;
                        clnProductionDate.ReadOnly = true;
                        clnReceiveQty.ReadOnly = true;
                        clnFactoryRemark.ReadOnly = true;
                    }
                }
                else if (dtFGRequest.Rows.Count == 0)
                {
                    DataTable dtRequestDetails = new FGRequestBL().SelectByFGRequestID(0, conn);
                    dgvFGReceive.DataSource = dtRequestDetails;

                    DataTable dt = dgvFGReceive.DataSource as DataTable;
                    if (dgvFGReceive.DataSource != null)
                    {
                        dgvFGReceive.DataSource = null;
                        dgvFGReceive.DataSource = dt.Clone();
                        if (dgvFGReceive.Rows.Count == 0)
                        {
                            DataRow newRow = dt.NewRow();
                            dt.Rows.Add(newRow);
                            this.dgvFGReceive.DataSource = dt;
                            dgvFGReceive.Enabled = true;
                        }
                    }
                    else
                    {
                        dgvFGReceive.Rows.Clear();
                    }
                }
            }
            catch (SqlException ie)
            {
            }
        }

        private void Save()
        {
            if (dgvFGReceive.CurrentRow.ErrorText != String.Empty) return;
            SqlConnection conn = null;
            try
            {
                DataTable dt = dgvFGReceive.DataSource as DataTable;
                conn = DBManager.GetInstance().GetDbConnection();
                if (dt.Rows[0]["FGRequestID"].ToString() == String.Empty)
                    return;
                // Select Warehouse && Factory
                DataTable dtWarehouse = new WarehouseDA().SelectSubtore();
                DataTable dtFactory = new WarehouseDA().SelectMain();

                int warehouseID = (int)DataTypeParser.Parse(dtWarehouse.Rows[0]["WarehouseID"], typeof(int), 0);
                int factoryID = (int)DataTypeParser.Parse(dtFactory.Rows[0]["WarehouseID"],typeof(int),0);

                FGReceive fgRequest = new FGReceive()
                   {
                       FGReqID = (int)DataTypeParser.Parse(dt.Rows[0]["FGRequestID"], typeof(int), 0),
                       IssueDate = dtpDate.Value
                   };
                List<FGReceiveDetail> insertReceiveDetail = new List<FGReceiveDetail>();
                List<FGReceiveDetail> deleteReceiveDetail = new List<FGReceiveDetail>();
                List<FGReceiveDetail> updateReceiveDetail = new List<FGReceiveDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    FGReceiveDetail fgReceiveDetail = new FGReceiveDetail()
                    {
                        FGRecID = (int)DataTypeParser.Parse(row["FGRecID"].ToString(), typeof(int), -1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        ProduceDate = (DateTime)DataTypeParser.Parse(row["ProduceDate"].ToString(), typeof(DateTime), DateTime.Now),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };
                    insertReceiveDetail.Add(fgReceiveDetail);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    FGReceiveDetail fgReceiveDetail = new FGReceiveDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["FGRqDetailID"].ToString(), typeof(int), -1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        ProduceDate = (DateTime)DataTypeParser.Parse(row["ProduceDate"].ToString(), typeof(DateTime), DateTime.Now),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };
                    deleteReceiveDetail.Add(fgReceiveDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    FGReceiveDetail fgReceiveDetail = new FGReceiveDetail()
                    {
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        ProduceDate = (DateTime)DataTypeParser.Parse(row["ProduceDate"].ToString(), typeof(DateTime), DateTime.Now),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };
                    updateReceiveDetail.Add(fgReceiveDetail);
                    //dtFGRequestID = fgRequestDetail.FGReqID;
                    //fgRequest.ID = dtFGRequestID;
                }

                int affectedRows = 0;
                if (dtFGReceive == -1) // Add new order and details
                {
                    if (updateReceiveDetail.Count > 0)
                    {
                        if ((int)DataTypeParser.Parse(dtWarehouse.Rows[0]["SubStoreCount"], typeof(int), 0) > 0)
                        {
                            affectedRows += new FGReceiveBL().Add(fgRequest, updateReceiveDetail,warehouseID,factoryID,conn);
                        }
                    }
                    else
                    {
                        ToastMessageBox.Show("Blank FGRequest Detail Data!");
                        return;
                    }
                }

                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    btnApprove.Enabled = false;
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException sqle)
            {
                // _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        private void dgvFGReceive_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == dgv.CurrentRow.Cells[clnReceiveQty.Index].ColumnIndex)
            {
                int newInteger;
                if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;             
                    btnApprove.Enabled = false;
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be fill";
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    //e.Cancel = true;
                    btnApprove.Enabled = false;
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be integer";
                }
                else
                {
                    btnApprove.Enabled = true;
                    dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
            else if (e.ColumnIndex == dgv.CurrentRow.Cells[clnProductionDate.Index].ColumnIndex)
            {
               // DateTime newDate;
                if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;             
                    btnApprove.Enabled = false;
                    dgv.Rows[e.RowIndex].ErrorText = "Production Date must be fill";
                }
                else
                {
                    btnApprove.Enabled = true;
                    dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        private void dgvFGReceive_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvFGReceive_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clnReceiveQty.Index || e.ColumnIndex == clnRequestQty.Index || e.ColumnIndex == clnFactoryRemark.Index)
            {
                int requestQty = (int)DataTypeParser.Parse(dgvFGReceive.CurrentRow.Cells[clnRequestQty.Index].Value.ToString(), typeof(int), 0);
                int receiveQty = (int)DataTypeParser.Parse(dgvFGReceive.CurrentRow.Cells[clnReceiveQty.Index].Value.ToString(), typeof(int), 0);

                if (receiveQty > requestQty)
                {
                    dgvFGReceive.Rows[e.RowIndex].ErrorText = "Produced Quantity is Invalid!";
                    MessageBox.Show("Produced Quantity is Invalid!");
                    dgvFGReceive.CurrentRow.Cells[clnReceiveQty.Index].Value = 0;
                    dgvFGReceive.Rows[e.RowIndex].ErrorText = String.Empty;
                }
                else
                {
                    dgvFGReceive.Rows[e.RowIndex].ErrorText = String.Empty;
                }

            }
        }



    }
}
