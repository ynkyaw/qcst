using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Marketing.DailyMarketing;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using log4net;
using PTIC.Sale.DA;
using PTIC.Sale.BL;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmGovTenderInfo : Form
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmGovTenderInfo));
        private TenderProducts _mdTenderProduct = null;
        private TenderInfo _mdTendInfo = null;

        private BindingSource bdBrand = new BindingSource();
        private BindingSource bdProduct = new BindingSource();

        public frmGovTenderInfo()
        {
            InitializeComponent();
            _mdTenderProduct = new TenderProducts();
            _mdTendInfo = new TenderInfo();
        }

        public frmGovTenderInfo(int? tenderinfoID)
        {
            InitializeComponent();
            _mdTenderProduct = new TenderProducts();
            _mdTendInfo = new TenderInfo();
            _mdTenderProduct.TenderInfoID = (int)tenderinfoID;
            _mdTendInfo.ID = (int)tenderinfoID;
            GridComboBind();
            LoadNBindTenderInfoID(tenderinfoID);
            FillTenderProduct(tenderinfoID);
            FillTenderCompetitor(tenderinfoID);
        }

        public void GridComboBind()
        {
            DataSet ds = new DataSet();            
            try
            {                
                DataTable dtBrand = new BrandBL().GetOwnBrands().Copy(); // make copy to be added into a single dataset
                DataTable dtProduct = new ProductBL().GetAll().Copy();

                ds.Tables.Add(dtBrand);
                ds.Tables.Add(dtProduct);

                try
                {
                    DataRelation relBrand_Product = new DataRelation("Brand_Product",
                    dtBrand.Columns["BrandID"], dtProduct.Columns["BrandID"]);
                    //DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                    //    dtcustype.Columns["CusTypeID"], dtcustomer.Columns["CusType"]);
                    ds.Relations.Add(relBrand_Product);
                    //ds.Relations.Add(relCusType_Customer);

                    /** relation between Brand and Category **/
                    bdBrand.DataSource = ds;
                    bdBrand.DataMember = dtBrand.TableName;

                    bdProduct.DataSource = bdBrand;
                    bdProduct.DataMember = "Brand_Product";

                    //bdcustomer.DataSource = bdcustomertype;
                    //bdcustomer.DataMember = "CusType_Customer";
                }
                catch (Exception ex) { }

                // bind binding list to each combo datasource
                clnBrandname.DataSource = bdBrand;
                clnBrandname.DisplayMember = "BrandName";
                clnBrandname.ValueMember = "BrandID";

                clnProductName.DataSource = bdProduct;
                clnProductName.DisplayMember = "ProductName";
                clnProductName.ValueMember = "ProductName";

                clncptBname.DataSource = bdBrand;
                clncptBname.DisplayMember = "BrandName";
                clncptBname.ValueMember = "BrandID";

                clncptPName.DataSource = bdProduct;
                clncptPName.DisplayMember = "ProductName";
                clncptPName.ValueMember = "ProductName";
            }
            catch (SqlException ie)
            {
                // TODO: show error msg
            }
        }
        
        public frmGovTenderInfo
            (PTIC.Marketing.Entities.GovernmentMarketingDetail govMkDetail, string customerName, string contactPersonName)
        {
            InitializeComponent();
            _mdTenderProduct = new TenderProducts();
            _mdTendInfo = new TenderInfo();
            if (govMkDetail.TenderInfoID != null)
            {
                _mdTenderProduct.TenderInfoID = (int)DataTypeParser.Parse(govMkDetail.TenderInfoID,typeof(int),-1);
                _mdTendInfo.ID = (int)DataTypeParser.Parse(govMkDetail.TenderInfoID, typeof(int), -1);
            }
            this._govMkDetail = govMkDetail;
            this.txtMinistryName.Text = customerName;
            this.txtContactPerson.Text = contactPersonName;
            this.txtDeptName.Text = govMkDetail.Department;
            SetReadOnly();
            GridComboBind();
            LoadNBindTenderInfoID(this._govMkDetail.TenderInfoID);
            FillTenderProduct(this._govMkDetail.TenderInfoID);
            FillTenderCompetitor(this._govMkDetail.TenderInfoID);
        }

        private void FillTenderProduct(int? tenderinfoID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                if (tenderinfoID == null) tenderinfoID = -1;
                DataTable dtTenderProduct= new TenderProductBL().GetTenderProductByID(tenderinfoID,conn);
                if(dtTenderProduct!=null)
                {
                    dgvTenderProduct.DataSource = dtTenderProduct;
                }
            }
            catch (SqlException e)
            {
                // TODO: show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void FillTenderCompetitor(int? tenderinfoID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                if (tenderinfoID == null) tenderinfoID = -1;
                DataTable dtTenderCompetitor = new TenderCompetitorBL().GetTenderCompetitorByID(tenderinfoID, conn);
                if (dtTenderCompetitor != null)
                {
                    dgvCompetitor.DataSource = dtTenderCompetitor;
                }
            }
            catch (SqlException e)
            {
                // TODO: show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void SetReadOnly()
        {
            //txtMinistryName.Text = govMkDetail.MinistryName;
            //txtDeptName.Text = govMkDetail.Department;
            //txtContactPerson.Text = govMkDetail.ContactPerson;
            txtContactPerson.ReadOnly = true;
            txtDeptName.ReadOnly = true;
            txtMinistryName.ReadOnly = true;
        }

        private void LoadNBindTenderInfoID(int? tenderinfoID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                int tenderID = (int)DataTypeParser.Parse(tenderinfoID, typeof(int), -1);
                DataTable tdInfo = new TenderInfoBL().GetTenderInfoByID(tenderID,conn);
                if (tdInfo.Rows.Count == 1)
                {
                    DataRow drinfo = tdInfo.Rows[0];
                    //txtDeptName.Text =;
                    //txtMinistryName.Text = drinfo["GovName"].ToString();
                    //txtDeptName.Text = "";
                    txtTenderName.Text = drinfo["TenderName"].ToString();
                    txtTenderNo.Text = drinfo["TenderNo"].ToString();
                    //txtContactPerson.Text = drinfo["ContactPerson"].ToString();
                    dtpTranDate.Value = Convert.ToDateTime(drinfo["TranDate"]);
                    dtpOpenDate.Value = Convert.ToDateTime(drinfo["OpentDate"]);
                    dtpCloseDate.Value = Convert.ToDateTime(drinfo["CloseDate"]);
                }
            }
            catch(SqlException e)
            {
                // TODO: show error message
                _logger.Error(e);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        public delegate void TenderSaveHandler(object sender, TenderSaveEventArgs e);

        public event TenderSaveHandler TenderSavedHandler;
        private PTIC.Marketing.Entities.GovernmentMarketingDetail _govMkDetail;
        private TenderInfo tenderinfoE = new TenderInfo();

        private void frmGovTenderInfo_Load(object sender, EventArgs e)
        {

        }

        #region Inner Class
        public class TenderSaveEventArgs : EventArgs
        {
            private int? _TenderInfoID = null;
            public TenderSaveEventArgs(int? TenderInfoID)
            {
                this._TenderInfoID = TenderInfoID;
            }
            public int? TenderInfoID
            {
                get { return this._TenderInfoID; }
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            SqlConnection conn = null;
            int? affectedRows = null;
            TenderInfo tenderinfo = null;
            TenderProductBL tenderProduct_Saver = new TenderProductBL();
            TenderCompetitorBL tenderCompetitor_Saver = new TenderCompetitorBL();
            try{

                conn = DBManager.GetInstance().GetDbConnection();

                tenderinfo = new TenderInfo()
                {
                    GovName = txtMinistryName.Text,
                    ContactPerson = txtContactPerson.Text,
                    TranDate = dtpTranDate.Value,
                    TenderNo = txtTenderNo.Text,
                    TenderName = txtTenderName.Text,
                    OpenDate = dtpOpenDate.Value,
                    CloseDate = dtpCloseDate.Value
                };


                if (_mdTendInfo.ID == -1)
                {
                    affectedRows = new TenderInfoBL().SaveInfo(tenderinfo, conn);

                    _mdTendInfo.ID = (int)affectedRows;
                }
                else // update an existing product
                {
                    tenderinfo.ID = _mdTendInfo.ID;
                    affectedRows = new TenderInfoBL().UpdateInfo(tenderinfo, conn);
                }




                //Tender Product Grid Data Process
                DataTable dtTenderProduct = dgvTenderProduct.DataSource as DataTable;


                List<TenderProducts> insertTenderProductList = new List<TenderProducts>();
                List<TenderProducts> updateTenderProductList = new List<TenderProducts>();
                List<TenderProducts> deleteTenderProductList = new List<TenderProducts>();

                if (dtTenderProduct != null)
                {
                    DataView dvInsert = new DataView(dtTenderProduct, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        TenderProducts tenderProduct = new TenderProducts()
                        {

                            ID = (int)DataTypeParser.Parse(row["TenderProductID"].ToString(), typeof(int), -1),
                            TenderInfoID = (int) _mdTendInfo.ID,
                            TproductName = (string)DataTypeParser.Parse(row["TProductName"].ToString(), typeof(string), ""),
                            Tqty = (int)DataTypeParser.Parse(row["TQty"].ToString(), typeof(int), -1),
                            Tprice = (decimal)DataTypeParser.Parse(row["TPrice"].ToString(), typeof(decimal), -1),
                            TotalPrice = (decimal)DataTypeParser.Parse(row["TotalPrice"].ToString(), typeof(decimal), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        insertTenderProductList.Add(tenderProduct);
                    }

                    // delete
                    DataView dvDelete = new DataView(dtTenderProduct, string.Empty, string.Empty, DataViewRowState.Deleted);
                    foreach (DataRow row in dvDelete.ToTable().Rows)
                    {
                        TenderProducts tenderProduct = new TenderProducts()
                        {

                            ID = (int)DataTypeParser.Parse(row["TenderProductID"].ToString(), typeof(int), -1),
                            TenderInfoID = (int)_mdTendInfo.ID,
                            TproductName = (string)DataTypeParser.Parse(row["TProductName"].ToString(), typeof(string), ""),
                            Tqty = (int)DataTypeParser.Parse(row["TQty"].ToString(), typeof(int), -1),
                            Tprice = (decimal)DataTypeParser.Parse(row["TPrice"].ToString(), typeof(decimal), -1),
                            TotalPrice = (decimal)DataTypeParser.Parse(row["TotalPrice"].ToString(), typeof(decimal), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")
                        };

                        deleteTenderProductList.Add(tenderProduct);

                    }

                    // update
                    DataView dvUpdate = new DataView(dtTenderProduct, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate.ToTable().Rows)
                    {
                        TenderProducts tenderProduct = new TenderProducts()
                        {

                            ID = (int)DataTypeParser.Parse(row["TenderProductID"].ToString(), typeof(int), -1),
                            TenderInfoID = (int)_mdTendInfo.ID,
                            TproductName = (string)DataTypeParser.Parse(row["TProductName"].ToString(), typeof(string), ""),
                            Tqty = (int)DataTypeParser.Parse(row["TQty"].ToString(), typeof(int), -1),
                            Tprice = (decimal)DataTypeParser.Parse(row["TPrice"].ToString(), typeof(decimal), -1),
                            TotalPrice = (decimal)DataTypeParser.Parse(row["TotalPrice"].ToString(), typeof(decimal), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        updateTenderProductList.Add(tenderProduct);


                    }


                    if (insertTenderProductList.Count > 0) affectedRows += tenderProduct_Saver.Add(insertTenderProductList, conn);
                    if (deleteTenderProductList.Count > 0) affectedRows += tenderProduct_Saver.DeleteByTenderProductID(deleteTenderProductList, conn);
                    if (updateTenderProductList.Count > 0) affectedRows += tenderProduct_Saver.UpdateByTenderproductID(updateTenderProductList, conn);

                }



                //Tender Competitior Grid Data Process
                DataTable dtTenderCompedititor = dgvCompetitor.DataSource as DataTable;


                List<TenderCompetitors> insertCompetitorList = new List<TenderCompetitors>();
                List<TenderCompetitors> updateCompetitorList = new List<TenderCompetitors>();
                List<TenderCompetitors> deleteCompetitorList = new List<TenderCompetitors>();

                if (dtTenderCompedititor != null)
                {
                    DataView dvInsert = new DataView(dtTenderCompedititor, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        TenderCompetitors tenderCompetitors = new TenderCompetitors()
                        {

                            ID = (int)DataTypeParser.Parse(row["TenderCompetitorID"].ToString(), typeof(int), -1),
                            TenderInfoID = (int)_mdTendInfo.ID,
                            TCompetitor = (string)DataTypeParser.Parse(row["TCompetitor"].ToString(), typeof(string), ""),
                            TProductName = (string)DataTypeParser.Parse(row["TProductName"].ToString(), typeof(string), ""),
                            Tqty = (int)DataTypeParser.Parse(row["TQty"].ToString(), typeof(int), -1),
                            Tprice = (decimal)DataTypeParser.Parse(row["TPrice"].ToString(), typeof(decimal), -1),
                            TotalPrice = (decimal)DataTypeParser.Parse(row["TotalPrice"].ToString(), typeof(decimal), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        insertCompetitorList.Add(tenderCompetitors);
                    }

                    // delete
                    DataView dvDelete = new DataView(dtTenderCompedititor, string.Empty, string.Empty, DataViewRowState.Deleted);
                    foreach (DataRow row in dvDelete.ToTable().Rows)
                    {
                        TenderCompetitors tenderCompetitors = new TenderCompetitors()
                        {


                            ID = (int)DataTypeParser.Parse(row["TenderCompetitorID"].ToString(), typeof(int), -1),
                            TenderInfoID = (int)_mdTendInfo.ID,
                            TCompetitor = (string)DataTypeParser.Parse(row["TCompetitor"].ToString(), typeof(string), ""),
                            TProductName = (string)DataTypeParser.Parse(row["TProductName"].ToString(), typeof(string), ""),
                            Tqty = (int)DataTypeParser.Parse(row["TQty"].ToString(), typeof(int), -1),
                            Tprice = (decimal)DataTypeParser.Parse(row["TPrice"].ToString(), typeof(decimal), -1),
                            TotalPrice = (decimal)DataTypeParser.Parse(row["TotalPrice"].ToString(), typeof(decimal), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        deleteCompetitorList.Add(tenderCompetitors);

                    }

                    // update
                    DataView dvUpdate = new DataView(dtTenderCompedititor, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate.ToTable().Rows)
                    {
                        TenderCompetitors tenderCompetitor = new TenderCompetitors()
                        {


                            ID = (int)DataTypeParser.Parse(row["TenderCompetitorID"].ToString(), typeof(int), -1),
                            TenderInfoID = (int)_mdTendInfo.ID,
                            TCompetitor = (string)DataTypeParser.Parse(row["TCompetitor"].ToString(), typeof(string), ""),
                            TProductName = (string)DataTypeParser.Parse(row["TProductName"].ToString(), typeof(string), ""),
                            Tqty = (int)DataTypeParser.Parse(row["TQty"].ToString(), typeof(int), -1),
                            Tprice = (decimal)DataTypeParser.Parse(row["TPrice"].ToString(), typeof(decimal), -1),
                            TotalPrice = (decimal)DataTypeParser.Parse(row["TotalPrice"].ToString(), typeof(decimal), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        updateCompetitorList.Add(tenderCompetitor);


                    }


                    if (insertCompetitorList.Count > 0) affectedRows += tenderCompetitor_Saver.Add(insertCompetitorList, conn);
                    if (deleteCompetitorList.Count > 0) affectedRows += tenderCompetitor_Saver.DeleteByTenderCompetitorID(deleteCompetitorList, conn);
                    if (updateCompetitorList.Count > 0) affectedRows += tenderCompetitor_Saver.UpdateByTenderCompetitorID(updateCompetitorList, conn);

                }



                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                    if (TenderSavedHandler != null)
                    {
                        TenderSaveEventArgs tendersaveargs = new TenderSaveEventArgs(_mdTendInfo.ID);
                        TenderSavedHandler(this, tendersaveargs);
                    }

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
            }
            catch (SqlException sqle)
            {
                ToastMessageBox.Show(Resource.errFailedToSave);
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void dgvTenderProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTenderProduct.Rows[e.RowIndex].Cells["ClnNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvCompetitor_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvCompetitor.Rows[e.RowIndex].Cells["clncptNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvTenderProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTenderProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            if (curColumName.Equals("clnPrice") || curColumName.Equals("clnQty"))
            {
                decimal price = Convert.ToDecimal(DataTypeParser.Parse(curRow.Cells["clnPrice"].Value, typeof(decimal), 0));
                int qty = (int)DataTypeParser.Parse(curRow.Cells["clnQty"].Value, typeof(int), 0);
                curRow.Cells["clnTotalAmt"].Value = price * qty;
            }
        }

        private void dgvCompetitor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            if (curColumName.Equals("clncptPrice") || curColumName.Equals("clncptQty"))
            {
                decimal price = Convert.ToDecimal(DataTypeParser.Parse(curRow.Cells["clncptPrice"].Value, typeof(decimal), 0));
                int qty = (int)DataTypeParser.Parse(curRow.Cells["clncptQty"].Value, typeof(int), 0);
                curRow.Cells["clncptTotalAmt"].Value = price * qty;
            }
        }

        private void dgvTenderProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            (sender as DataGridView).CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvCompetitor_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            (sender as DataGridView).CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
