using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.BL;
using System.Security.Permissions;
using PTIC.Common.BL;
using System.Collections;
using PTIC.VC.Validation;


namespace PTIC.VC.Sale.Inventory
{
    public partial class frmFinishedGoodsRequest : Form
    {
        DataTable fgrequestDetailTbl = null;
        DataTable productTbl = null;
        int dtFGRequestID = -1;
        int dtFinishedGood = -1;

        bool IsFirst = true;

        /// <summary>
        /// Finished Good  & Factory Request & Issue Fields
        /// </summary>
        //DataTable dtBrand = null;

        ////  Product DataTable
        //DataTable dtProduct = null;

        //BindingSource bdBrand;
        //BindingSource bdunfilteredProduct;
        //BindingSource bdfilteredProduct;

        int FGRequstID = -1;

        TextBox _txtQty = null; // ToCheck Control Validate


        public frmFinishedGoodsRequest()
        {
            InitializeComponent();
            dtpFGDate.MaxDate = DateTime.Now;
            LoadNBindData();
            dgvFinishedGoods.AutoGenerateColumns = false;
            dgvStockInFactory.AutoGenerateColumns = false;
            LoadNBindFGRequestDetails();
            LoadNBindFinishedGood();

            DataUtil.AddInitialNewRow(dgvFGRequest);
            DataUtil.AddInitialNewRow(dgvFinishedGoods);
        }

        public frmFinishedGoodsRequest(int FGRequestID)
        {
            InitializeComponent();
            dtpFGDate.MaxDate = DateTime.Now;
            btnRequest.Enabled = false;
            LoadNBindData();
            this.FGRequstID = FGRequestID;
            LoadNBindFGRequestDetails();
            //  LoadNBindFinishedGood();
            //   DataUtil.AddInitialNewRow(dgvFGRequest);
            DataUtil.AddInitialNewRow(dgvFinishedGoods);
        }

        #region Private Method
        private void LoadNBindData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                productTbl = new ProductBL().GetAll();  // Load ProductData
                fgrequestDetailTbl = new FGRequestBL().SelectByRequireDate(dtpIssueDate.Value, conn); // FGRequestDetail Data

                //Bind into Combodatagridview
                clnFGR_ProductName.DataSource = productTbl;
                clnFGR_ProductName.DisplayMember = "ProductName";
                clnFGR_ProductName.ValueMember = "ProductID";

                //Bind into Combo FinishedGood Product
                colFGProduct.DataSource = productTbl;
                colFGProduct.DisplayMember = "ProductName";
                colFGProduct.ValueMember = "ProductID";

                //  Finished Good Request Van Binding
                cmbVen.DataSource = new VehicleBL().GetAll();
                cmbVen.DisplayMember = "VenNo";
                cmbVen.ValueMember = "VehicleID";

                // FinishedGoodRequest Employee Binding                          
                DataTable tmpEmployee = new EmployeeBL().GetEmployeeFromMarketingAndSale();
                cmbEmployee.DataSource = tmpEmployee;
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.DisplayMember = "EmpName";

                cmbRequester.DataSource = tmpEmployee.Copy();
                cmbRequester.ValueMember = "EmployeeID";
                cmbRequester.DisplayMember = "EmpName";

                // Bind into gridview
                dgvFGRequest.AutoGenerateColumns = false;
                //    dgvFGRequest.DataSource = fgrequestDetailTbl;
            }
            catch (SqlException Sqle)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /// <summary>
        /// Save FGRequest and FGRequestDetail
        /// </summary>
        private void Save()
        {
            bool IsUpdate = false;

            if (dgvFGRequest.CurrentRow.ErrorText != String.Empty) return;
            SqlConnection conn = null;
            try
            {
                DataTable dt = dgvFGRequest.DataSource as DataTable;

                conn = DBManager.GetInstance().GetDbConnection();
                FGRequest fgRequest = new FGRequest()
                {
                    //ReqVouNo = Guid.NewGuid().ToString(),
                    ReqDate = DateTime.Now,
                    IssueDate = dtpIssueDate.Value,
                    RequireDate = dtpRequiredDate.Value,
                    RequesterID = (int)DataTypeParser.Parse(cmbRequester.SelectedValue, typeof(int), -1),
                    TransportVenID = (int)DataTypeParser.Parse(cmbVen.SelectedValue, typeof(int), -1),
                    TarnsportEmpID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1),
                    Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null),
                    FactoryFormRemark = (string)DataTypeParser.Parse(txtFactoryRemark.Text, typeof(string), null),
                };
                List<FGRequestDetail> insertFGRequestDetail = new List<FGRequestDetail>();
                List<FGRequestDetail> updateFGRequestDetail = new List<FGRequestDetail>();
                List<FGRequestDetail> deleteFGRequestDetail = new List<FGRequestDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    FGRequestDetail fgRequestDetail = new FGRequestDetail()
                    {
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        FGReqID = (int)DataTypeParser.Parse(row["FGRequestID"].ToString(), typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), null),
                        FactoryRemark = (string)DataTypeParser.Parse(row["FactoryRemark"].ToString(), typeof(string), null)
                    };
                    if (fgRequestDetail.ProductID != -1 && fgRequestDetail.Qty != 0)
                    {
                        insertFGRequestDetail.Add(fgRequestDetail);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    FGRequestDetail fgRequestDetail = new FGRequestDetail()
                   {
                       ID = (int)DataTypeParser.Parse(row["FGRqDetailID"].ToString(), typeof(int), -1),
                       ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                       FGReqID = (int)DataTypeParser.Parse(row["FGReqID"].ToString(), typeof(int), -1),
                       Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1),
                       IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                       Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), null)
                   };

                    deleteFGRequestDetail.Add(fgRequestDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    FGRequestDetail fgRequestDetail = new FGRequestDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["FGRequestDetailID"].ToString(), typeof(int), -1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        FGReqID = (int)DataTypeParser.Parse(row["FGRequestID"].ToString(), typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), null),
                        FactoryRemark = (string)DataTypeParser.Parse(row["FactoryRemark"].ToString(), typeof(string), null)
                    };

                    if (fgRequestDetail.ProductID != -1 && fgRequestDetail.Qty != 0)
                    {
                        updateFGRequestDetail.Add(fgRequestDetail);
                    }
                    dtFGRequestID = fgRequestDetail.FGReqID;
                    fgRequest.ID = dtFGRequestID;
                }

                int affectedRows = 0;
                if (dtFGRequestID == -1) // Add new order and details
                {
                    if (insertFGRequestDetail.Count > 0 && fgRequest != null)
                    {
                        affectedRows += new FGRequestBL().Add(fgRequest, insertFGRequestDetail, conn);
                    }
                    else
                    {
                        ToastMessageBox.Show("Blank FGRequest Detail Data!");
                        return;
                    }
                }
                else
                {
                    if (updateFGRequestDetail.Count > 0 && fgRequest != null)
                    {
                        affectedRows += new FGRequestBL().Update(fgRequest, updateFGRequestDetail, conn);
                        IsUpdate = true;
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
                    if (IsUpdate == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        LoadNBindData();
                        LoadNBindFGRequestDetails();
                    }
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


        private void SaveFGRecieve()
        {
            if (dgvFGRequest.CurrentRow.ErrorText != String.Empty) return;
            SqlConnection conn = null;
            try
            {
                DataTable dt = dgvFGRequest.DataSource as DataTable;
                conn = DBManager.GetInstance().GetDbConnection();
                if (dt.Rows[0]["FGRequestID"].ToString() == String.Empty)
                    return;
                // Select Warehouse && Factory
                DataTable dtWarehouse = new WarehouseDA().SelectSubtore();
                DataTable dtFactory = new WarehouseDA().SelectMain();

                int warehouseID = (int)DataTypeParser.Parse(dtWarehouse.Rows[0]["WarehouseID"], typeof(int), 0);
                int factoryID = (int)DataTypeParser.Parse(dtFactory.Rows[0]["WarehouseID"], typeof(int), 0);

                FGReceive fgRequest = new FGReceive()
                {
                    FGReqID = (int)DataTypeParser.Parse(dt.Rows[0]["FGRequestID"], typeof(int), 0),
                    IssueDate = dtpIssueDate.Value
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
                if (affectedRows == -1) // Add new order and details
                {
                    if (updateReceiveDetail.Count > 0)
                    {
                        if ((int)DataTypeParser.Parse(dtWarehouse.Rows[0]["SubStoreCount"], typeof(int), 0) > 0)
                        {
                            affectedRows += new FGReceiveBL().Add(fgRequest, updateReceiveDetail, warehouseID, factoryID, conn);
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
                    //    btnApprove.Enabled = false;
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


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && dgvFGRequest.IsCurrentCellInEditMode == true)
            {
                int iColumn = dgvFGRequest.CurrentCell.ColumnIndex;
                int iRow = dgvFGRequest.CurrentCell.RowIndex;
                int? ProductID = (int?)DataTypeParser.Parse(dgvFGRequest.CurrentRow.Cells[clnFGR_ProductName.Index].Value, typeof(int), null);
                int Qty = (int)DataTypeParser.Parse(dgvFGRequest.CurrentRow.Cells[clnFGR_Qty.Index].Value, typeof(int), 0);

                if (iColumn == dgvFGRequest.Columns.Count - 1)
                {
                    if (iColumn <= dgvFGRequest.Columns.Count - 1)
                    {
                        if (dgvFGRequest.CurrentRow.ErrorText != String.Empty) return true;
                        if (iRow + 1 >= dgvFGRequest.Rows.Count)
                        {
                            if (dgvFGRequest.CurrentRow.ErrorText == string.Empty && ProductID != null && Qty > 0 && this.FGRequstID == -1)
                            {
                                DataUtil.AddNewRow(dgvFGRequest.DataSource as DataTable);
                                dgvFGRequest[0, iRow + 1].Selected = true;
                            }
                        }
                        else
                        {
                            dgvFGRequest.CurrentCell = dgvFGRequest[0, iRow + 1];
                        }
                    }
                }
                else
                {
                    try
                    {
                        dgvFGRequest.CurrentCell = dgvFGRequest[dgvFGRequest.CurrentCell.ColumnIndex + 1, dgvFGRequest.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            else if (dgvFinishedGoods.IsCurrentCellInEditMode == true && keyData == Keys.Enter)
            {
                int iColumn = dgvFinishedGoods.CurrentCell.ColumnIndex;
                int iRow = dgvFinishedGoods.CurrentCell.RowIndex;
                
                int? ProductID = (int?)DataTypeParser.Parse(dgvFinishedGoods.CurrentRow.Cells[colFGProduct.Index].Value, typeof(int), null);
                int Qty = (int)DataTypeParser.Parse(dgvFinishedGoods.CurrentRow.Cells[clnFGQty.Index].Value, typeof(int), 0);

                if (iColumn == dgvFinishedGoods.Columns[colRemark.Index].Index)
                {
                    if (iColumn <= dgvFinishedGoods.Columns[colRemark.Index].Index)
                    {
                        if (dgvFinishedGoods.CurrentRow.ErrorText != String.Empty) return true;
                        if (iRow + 1 >= dgvFinishedGoods.Rows.Count)
                        {
                            if (dgvFinishedGoods.Rows[iRow].ErrorText == string.Empty && ProductID != null && Qty > 0)
                            {
                                DataUtil.AddNewRow(dgvFinishedGoods.DataSource as DataTable);
                                dgvFinishedGoods[0, iRow + 1].Selected = true;
                            }
                        }
                        else
                        {
                            dgvFinishedGoods.CurrentCell = dgvFinishedGoods[0, iRow + 1];
                        }
                    }
                }
                else
                {
                    try
                    {
                        dgvFinishedGoods.CurrentCell = dgvFinishedGoods[dgvFinishedGoods.CurrentCell.ColumnIndex + 1, dgvFinishedGoods.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (dgvFGRequest.Rows[dgvFGRequest.CurrentRow.Index].ErrorText != String.Empty)
                MessageBox.Show(Resource.errFailedToSave);
            else
                Save();
        }

        private void dgvFGRequest_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int totalqty = 0;
            if (dgvFGRequest.RowCount > 0)
            {
                DataTable dt = dgvFGRequest.DataSource as DataTable;
                foreach (DataRow row in dt.Rows)
                {
                    totalqty += (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0);
                }
                txtTotalQty.Text = totalqty.ToString();
            }
        }

        private void dtpRequiredDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBindFGRequestDetails();
        }

        private void LoadNBindFGRequestDetails()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DateTime productionDate = dtpFGDate.Value;

                DataTable dtFGRequest = new FGRequestBL().SelectFormByFGRequestID(this.FGRequstID);
                DataTable dtFinishedGood = new FinishedGoodBL().SelectByProductionDate(productionDate, conn);
                dgvFinishedGoods.AutoGenerateColumns = false;
                dgvFinishedGoods.DataSource = dtFinishedGood;

                //if (dtFinishedGood.Rows.Count == 0)
                //{                    
                //    DataTable dtnewFinishedGood = dgvFinishedGoods.DataSource as DataTable;
                //    if (dgvFinishedGoods.DataSource != null && dgvFinishedGoods.Rows.Count == 0)
                //    {
                //        dgvFinishedGoods.DataSource = null;
                //        dgvFinishedGoods.DataSource = dtnewFinishedGood.Clone();
                //        if (dgvFinishedGoods.Rows.Count == 0)
                //        {
                //            DataRow newRow = dtnewFinishedGood.NewRow();
                //            dtnewFinishedGood.Rows.Add(newRow);
                //            this.dgvFinishedGoods.DataSource = dtnewFinishedGood;
                //        }
                //    }
                //    else
                //    {
                //        dgvFGRequest.Rows.Clear();
                //    }   
                //}               


                if (dtFGRequest.Rows.Count > 0)
                {
                    dtpRequiredDate.Value = (DateTime)DataTypeParser.Parse(dtFGRequest.Rows[0]["RequireDate"], typeof(DateTime), DateTime.Now);
                    //dtpIssueDate.Value = (DateTime)DataTypeParser.Parse(dtFGRequest.Rows[0]["IssueDate"], typeof(DateTime), DateTime.Now);

                    int FGRequestID = Convert.ToInt32(dtFGRequest.Rows[0]["FGRequestID"].ToString());
                    txtRemark.Text = dtFGRequest.Rows[0]["FGRequestFormRemark"].ToString();
                    txtFactoryRemark.Text = dtFGRequest.Rows[0]["FactoryFormRemark"].ToString();
                    cmbEmployee.SelectedValue = (int)DataTypeParser.Parse(dtFGRequest.Rows[0]["TarnsportEmpID"], typeof(int), -1);
                    cmbRequester.SelectedValue = (int)DataTypeParser.Parse(dtFGRequest.Rows[0]["RequesterID"], typeof(int), -1);
                    cmbVen.SelectedValue = (int)DataTypeParser.Parse(dtFGRequest.Rows[0]["TransportVenID"], typeof(int), -1);
                    DataTable dtRequestDetails = new FGRequestBL().SelectByFGRequestID(FGRequestID, conn);
                    dgvFGRequest.DataSource = dtRequestDetails;

                    if ((int)DataTypeParser.Parse(dtFGRequest.Rows[0]["IssueQty"], typeof(int), -1) != -1)
                    {
                        btnIssue.Enabled = false;
                        btnAdd.Enabled = false;
                        btnRequest.Enabled = false;
                        dgvFGRequest.Columns[colIssueQty.Index].ReadOnly = true;
                        dgvFGRequest.Columns[colFactoryRemark.Index].ReadOnly = true;
                    }
                    else
                    {
                        cmbVen.Enabled = false;
                        cmbEmployee.Enabled = false;
                        cmbRequester.Enabled = false;

                        dtpRequiredDate.Enabled = false;
                        dtpIssueDate.Enabled = true;

                        dgvFGRequest.Columns[colFGProduct.Index].ReadOnly = true;
                        dgvFGRequest.Columns[clnFGR_Qty.Index].ReadOnly = true;
                        dgvFGRequest.Columns[colRequestRemark.Index].ReadOnly = true;

                        dgvFGRequest.Columns[colFactoryRemark.Index].ReadOnly = false;
                        dgvFGRequest.Columns[colIssueQty.Index].ReadOnly = false;

                        btnAdd.Enabled = false;
                        btnRequest.Enabled = false;
                        btnDelete.Enabled = false;
                        btnIssue.Enabled = true;
                    }
                    //dgvFGRequest.Enabled = false;
                    //btnRequest.Enabled = false;
                }
                else if (dtFGRequest.Rows.Count == 0)
                {
                    DataTable dtRequestDetails = new FGRequestBL().SelectByFGRequestID(0, conn);
                    dgvFGRequest.DataSource = dtRequestDetails;

                    DataTable dt = dgvFGRequest.DataSource as DataTable;
                    if (dgvFGRequest.DataSource != null)
                    {
                        dgvFGRequest.DataSource = null;
                        dgvFGRequest.DataSource = dt.Clone();
                        if (dgvFGRequest.Rows.Count == 0)
                        {
                            DataRow newRow = dt.NewRow();
                            dt.Rows.Add(newRow);
                            this.dgvFGRequest.DataSource = dt;
                            btnRequest.Enabled = true;
                            dgvFGRequest.Enabled = true;
                        }
                    }
                    else
                    {
                        dgvFGRequest.Rows.Clear();
                    }
                }
            }
            catch (SqlException ie)
            {
            }
        }

        private void btnProduced_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (dgvFinishedGoods.CurrentRow.ErrorText != String.Empty) return;
            SqlConnection conn = null;
            try
            {
                DataTable dt = dgvFinishedGoods.DataSource as DataTable;
                conn = DBManager.GetInstance().GetDbConnection();

                List<FinishedGood> insertFinishedGood = new List<FinishedGood>();
                List<FinishedGood> updateFinishedGood = new List<FinishedGood>();
                List<FinishedGood> deleteFinishedGood = new List<FinishedGood>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    FinishedGood finishedGood = new FinishedGood()
                    {
                        ProductionDate = dtpFGDate.Value,
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        ProductionCode = (string)DataTypeParser.Parse(row["ProductionCode"].ToString(), typeof(string), string.Empty),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)

                    };
                    insertFinishedGood.Add(finishedGood);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    FinishedGood finishedGood = new FinishedGood()
                    {
                        ID = (int)DataTypeParser.Parse(row["FinishedGoodID"], typeof(int), -1),
                        ProductionDate = dtpFGDate.Value,
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        ProductionCode = (string)DataTypeParser.Parse(row["ProductionCode"].ToString(), typeof(string), string.Empty),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                    };
                    deleteFinishedGood.Add(finishedGood);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    FinishedGood finishedGood = new FinishedGood()
                    {
                        ID = (int)DataTypeParser.Parse(row["FinishedGoodID"], typeof(int), -1),
                        ProductionDate = dtpFGDate.Value,
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        ProductionCode = (string)DataTypeParser.Parse(row["ProductionCode"].ToString(), typeof(string), string.Empty),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };
                    updateFinishedGood.Add(finishedGood);
                    dtFinishedGood = finishedGood.ID;
                    //fgRequest.ID = dtFGRequestID;
                }

                int affectedRows = 0;
                if (dtFinishedGood == -1) // Add new order and details
                {
                    if (insertFinishedGood.Count > 0)
                    {
                        affectedRows += new FinishedGoodBL().Add(insertFinishedGood, conn);
                    }
                    else
                    {
                        ToastMessageBox.Show("Blank FGRequest Detail Data!");
                        return;
                    }

                }
                else
                {
                    //if (updateFGRequestDetail.Count > 0 && fgRequest != null)
                    //{
                    //    affectedRows += new FGRequestBL().Update(fgRequest, updateFGRequestDetail, conn);
                    //}
                    //else
                    //{
                    //    ToastMessageBox.Show("Blank FGRequest Detail Data!");
                    //    return;
                    //}
                }
                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBindFinishedGood();
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

        private void dtpFGDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBindFinishedGood();
        }

        private void LoadNBindFinishedGood()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DateTime productionDate = dtpFGDate.Value;

                // Stock In Factory
                DataTable dtStockInFactroy = new FinishedGoodBL().GetAllStockInFactory();
                if (dtStockInFactroy != null)
                {
                    dgvStockInFactory.DataSource = dtStockInFactroy;
                }

                DataTable dtFinishedGood = new FinishedGoodBL().SelectByProductionDate(productionDate, conn);
                dgvFinishedGoods.DataSource = dtFinishedGood;
                btnProduced.Enabled = false;
                //dgvFinishedGoods.Enabled = false;
                if (dtFinishedGood.Rows.Count == 0)
                {
                    DataTable dtnewFinishedGood = dgvFinishedGoods.DataSource as DataTable;
                    if (dgvFinishedGoods.DataSource != null && dgvFinishedGoods.Rows.Count == 0)
                    {
                        dgvFinishedGoods.DataSource = null;
                        dgvFinishedGoods.DataSource = dtnewFinishedGood.Clone();
                        btnProduced.Enabled = true;
                        if (dgvFinishedGoods.Rows.Count == 0)
                        {
                            DataRow newRow = dtnewFinishedGood.NewRow();
                            dtnewFinishedGood.Rows.Add(newRow);
                            this.dgvFinishedGoods.DataSource = dtnewFinishedGood;
                        }
                        btnProduced.Enabled = true;
                        dgvFinishedGoods.Enabled = true;
                    }
                    else
                    {
                        dgvFGRequest.Rows.Clear();
                    }
                }
            }
            catch (SqlException e)
            {
            }
            finally
            {

            }
        }

        private void dgvFGRequest_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Set row number
            foreach (DataGridViewRow r in dgv.Rows)
            {
                dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void dgvFinishedGoods_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Set row number
            foreach (DataGridViewRow r in dgv.Rows)
            {
                dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                int? Check = (int?)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colFinishedGoodID.Index].Value, typeof(int), null);
                if (Check != null)
                {
                    dgv.Rows[r.Index].ReadOnly = true;
                }
            }
        }

        private void dgvFinishedGoods_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvFGRequest_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvFGRequest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            bool HasProductID = false;

            // Check Validation Remove
            //if (e.ColumnIndex == dgv.CurrentRow.Cells[clnFGR_ProductName.Index].ColumnIndex)
            //{
            //    foreach (DataGridViewRow row in dgv.Rows)
            //    {
            //        if (row.Index != e.RowIndex & !row.IsNewRow)
            //        {
            //            if (row.Cells[clnFGR_ProductName.Index].EditedFormattedValue.ToString() == e.FormattedValue.ToString())
            //            {
            //                dgv.Rows[e.RowIndex].ErrorText =
            //                    "Duplicate value not allowed";

            //                e.Cancel = true;
            //                // btnRequest.Enabled = false;
            //                return;
            //            }
            //            else
            //            {
            //                dgv.Rows[e.RowIndex].ErrorText = string.Empty;
            //                // btnRequest.Enabled = true;
            //            }
            //        }
            //    }
            //}

            if (e.ColumnIndex == dgv.CurrentRow.Cells[clnFGR_Qty.Index].ColumnIndex || e.ColumnIndex == dgv.CurrentRow.Cells[colIssueQty.Index].ColumnIndex)
            {
                int newInteger;
                if (dgvFGRequest.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be filled!";
                    MessageBox.Show("Amount must be filled!");
                    dgvFGRequest.CurrentRow.Cells[clnFGR_Qty.Index].Value = 0;
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    //e.Cancel = true;
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be integer!";
                    MessageBox.Show("Amount must be integer!");
                    dgvFGRequest.CurrentRow.Cells[clnFGR_Qty.Index].Value = 0;
                }
                else
                {
                    dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }

            if ((e.ColumnIndex == dgv.CurrentRow.Cells[colIssueQty.Index].ColumnIndex || e.ColumnIndex == dgv.CurrentRow.Cells[clnFGR_Qty.Index].ColumnIndex || e.ColumnIndex == dgv.CurrentRow.Cells[colRequestRemark.Index].ColumnIndex || e.ColumnIndex == dgv.CurrentRow.Cells[colFactoryRemark.Index].ColumnIndex || e.ColumnIndex == dgv.CurrentRow.Cells[clnFGR_ProductName.Index].ColumnIndex) && !dgv.Columns[colIssueQty.Index].ReadOnly)
            {
                DataTable dtStockInWarehouse = new FG_ReceiveBL().GetStockInWarehouse();
                if (dtStockInWarehouse.Rows.Count <= 0 && IsFirst)
                {
                    btnIssue.Enabled = false;
                    btnRequest.Enabled = false;
                    IsFirst = false;
                    MessageBox.Show("လက်ကျန်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else if (!IsFirst)
                {
                    btnIssue.Enabled = false;
                    btnRequest.Enabled = false;
                }

                foreach (DataRow row in dtStockInWarehouse.Rows)
                {
                    int ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1);
                    int Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), 0);

                    if ((int)DataTypeParser.Parse(e.FormattedValue, typeof(int), 0) > Qty && (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colFGProduct.Index].Value, typeof(int), -1) == ProductID)
                    {
                        dgv.Rows[e.RowIndex].ErrorText = "Error!";
                        btnIssue.Enabled = false;
                        HasProductID = true;
                        MessageBox.Show("အရေအတွက် ကျော်လွန်နေပါသည်။ လက်ကျန် : " + Qty, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else if ((int)DataTypeParser.Parse(e.FormattedValue, typeof(int), 0) <= Qty && (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colFGProduct.Index].Value, typeof(int), -1) == ProductID)
                    {
                        btnIssue.Enabled = true;
                        return;
                    }
                    else if ((int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colFGProduct.Index].Value, typeof(int), -1) == ProductID)
                    {
                        dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                        HasProductID = true;
                    }
                    else
                    {
                        dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                }

                if (HasProductID == false)
                {
                    foreach (DataRow row in dtStockInWarehouse.Rows)
                    {
                        int ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1);
                        int Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), 0);

                        if ((int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colFGProduct.Index].Value, typeof(int), -1) != ProductID && IsFirst)
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Error!";
                            btnIssue.Enabled = false;
                            btnRequest.Enabled = false;
                            MessageBox.Show("လက်ကျန်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            IsFirst = false;
                            return;
                        }
                        else if (!IsFirst)
                        {
                            btnIssue.Enabled = false;
                            btnRequest.Enabled = false;
                        }
                    }
                }

            }
        }

        private void dgvFinishedGoods_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == dgv.CurrentRow.Cells[colFGProduct.Index].ColumnIndex)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells[colFGProduct.Index].EditedFormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate value not allowed";
                            btnProduced.Enabled = false;
                            MessageBox.Show("Duplicate Not Allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == dgv.CurrentRow.Cells[colProductionCode.Index].ColumnIndex)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells[colProductionCode.Index].EditedFormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate value not allowed";
                            btnProduced.Enabled = false;
                            MessageBox.Show("Duplicate Not Allowed!");
                        }
                    }
                }

                if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    btnProduced.Enabled = false;
                    dgv.Rows[e.RowIndex].ErrorText = "Production Code must be fill";
                    MessageBox.Show("Production Code must be fill");
                }
                else
                {
                    btnProduced.Enabled = true;
                    dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
            else if (e.ColumnIndex == dgv.CurrentRow.Cells[clnFGQty.Index].ColumnIndex)
            {
                int newInteger;
                if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;             
                    btnProduced.Enabled = false;
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be fill!";
                    MessageBox.Show("Amount must be fill!");
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                {
                    //e.Cancel = true;
                    btnProduced.Enabled = false;
                    dgv.Rows[e.RowIndex].ErrorText = "Amount must be integer!";
                    MessageBox.Show("Amount must be integer!");
                }
                else
                {
                    btnProduced.Enabled = true;
                    dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
            //else if (e.ColumnIndex == dgv.CurrentRow.Cells[colProductionCode.Index].ColumnIndex)
            //{

            //}
        }

        private void dgvFinishedGoods_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colFGProduct.Index)
            {
                //dgv.CurrentRow.Cells[colFGProduct.Index].Value = -1;
                //dgv.CurrentRow.Cells[colProductionCode.Index].Value = null;
                //dgv.CurrentRow.Cells[clnFGQty.Index].Value = 0;
                //dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                dgv.Rows.RemoveAt(e.RowIndex);
            }
            else if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == clnFGQty.Index)
            {
                dgv.CurrentRow.Cells[clnFGQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        private void dgvFGRequest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            //dgvFGRequest.Rows[e.RowIndex].ErrorText = String.Empty;
            if (dgv.Rows[e.RowIndex].ErrorText != string.Empty)
            {
                dgv.Rows[e.RowIndex].Cells[colIssueQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (dgvFGRequest.Rows[dgvFGRequest.CurrentRow.Index].ErrorText != String.Empty)
                MessageBox.Show(Resource.errFailedToSave);
            else
                Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int? ProductID = (int?)DataTypeParser.Parse(dgvFGRequest.CurrentRow.Cells[clnFGR_ProductName.Index].Value, typeof(int), null);
                int Qty = (int)DataTypeParser.Parse(dgvFGRequest.CurrentRow.Cells[clnFGR_Qty.Index].Value, typeof(int), 0);
                if (ProductID != null && Qty > 0)
                {
                    DataUtil.AddNewRow(dgvFGRequest.DataSource as DataTable);
                    dgvFGRequest.CurrentCell = dgvFGRequest.Rows[dgvFGRequest.Rows.Count - 1].Cells[0];
                }
            }
            catch (Exception)
            {
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? ProductID = (int?)DataTypeParser.Parse(dgvFinishedGoods.CurrentRow.Cells[colFGProduct.Index].Value, typeof(int), null);
            int Qty = (int)DataTypeParser.Parse(dgvFinishedGoods.CurrentRow.Cells[clnFGQty.Index].Value, typeof(int), 0);
            if (ProductID != null && Qty > 0)
            {
                DataUtil.AddNewRow(dgvFinishedGoods.DataSource as DataTable);
                dgvFinishedGoods.CurrentCell = dgvFinishedGoods.Rows[dgvFinishedGoods.Rows.Count - 1].Cells[0];
            }

        }

        private void dgvFGRequest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _txtQty = e.Control as TextBox;
            if (dgvFGRequest.CurrentCell.ColumnIndex == 1 || dgvFGRequest.CurrentCell.ColumnIndex == 2)
            {
                _txtQty.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }

        private void dgvFinishedGoods_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _txtQty = e.Control as TextBox;

            if (dgvFinishedGoods.CurrentCell.ColumnIndex == 1 && _txtQty != null)
            {
                _txtQty.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void dgvFinishedGoods_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_txtQty != null)
            {
                _txtQty.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void dgvFGRequest_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_txtQty != null)
            {
                _txtQty.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            }
        }

    }
}
