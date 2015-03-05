/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/MM/dd)
 * Description: Daily Marketing Detail form
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using PTIC.Common;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;
using PTIC.Sale.Order;
using PTIC.Util;
using PTIC.VC.Marketing.A_P;
using PTIC.VC.Util;
using PTIC.Common.BL;

namespace PTIC.VC.Marketing.DailyMarketing
{
    /// <summary>
    /// Daily Marketing Detail form
    /// </summary>
    public partial class frmDailyMarketingDetail : Form
    {
        /// <summary>
        /// Logger for frmDailyMarketingLog
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmDailyMarketingDetail));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DailyMarketingDetailSaveHandler(object sender, DailyMarketingDetailSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event DailyMarketingDetailSaveHandler DailyMarketingDetailSavedHandler;

        /// <summary>
        /// 
        /// </summary>
        private MarketingDetail _marketingDetail = null;

        //private Address _address = null;

        // 
        private Township _township = null;

        private int _customerTypeID;

        /// <summary>
        /// Flag indicating frmDailyMarketingDetail form should be closed after saved
        /// </summary>
        private bool _needToClose = false;

        private DataTable dtTown = null;
                
        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Need to close this form after saved
            _needToClose = true;
            // Save Daily Marketing Detail
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.qstSureToDeleteMarketingDetail, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;
            if (!_marketingDetail.ID.HasValue)
            {
                this.Close();
                return;
            }
            // Delete marketing detail
            DeleteMarketingDetail(_marketingDetail.ID);
        }

        private void btnAPUsage_Click(object sender, EventArgs e)
        {
            frmA_PUsage apUsage = new frmA_PUsage(_marketingDetail.A_P_UsageID, _marketingDetail.CusID.Value);
            // set call back handler
            apUsage.A_PUsagSavedHandler += new frmA_PUsage.A_PUsageSaveHandler(A_PUsageSave_CallBack);
            // Open A P Usage form
            UIManager.OpenForm(apUsage);
        }

        private void A_PUsageSave_CallBack(object sender, frmA_PUsage.A_PUsageSaveEventArgs e)
        {
            if (e.A_PUsageID.HasValue) // If A_P_Usage has been created
            {  
                // Set A_P_UsageID to be refered by MarketingDetail
                _marketingDetail.A_P_UsageID = e.A_PUsageID;
                // No need to close this form after saved
                _needToClose = false;
                // Save A_P_Usage
                Save();
            }
        }

        private void btnCompetitorActivity_Click(object sender, EventArgs e)
        {
            frmCompetitorActivity comActivity = new frmCompetitorActivity(_marketingDetail.CompetitorActivityID);
            // Set call back handler
            comActivity.CompetitorActivitySavedHandler += 
                new frmCompetitorActivity.CompetitorActivitySaveHandler(comActivity_CompetitorActivitySavedHandler);
            // Open Form frmCompetitorActivity
            UIManager.OpenForm(comActivity);
        }

        private void comActivity_CompetitorActivitySavedHandler(object sender, frmCompetitorActivity.CompetitorActivitySaveEventArgs e)
        {
            if(e.CompetitorActivityID.HasValue)
            {
                // Set CompetitorActivityID to be refered by GovMarketingDetail
                _marketingDetail.CompetitorActivityID = e.CompetitorActivityID;
                // No need to close this form after saved
                _needToClose = false;
                // Save Daily Marketing Detail
                Save();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {          
            DataTable townID = DataUtil.GetDataTableBy(dtTown, "TownshipID", this._township.TownshipID);
            int ID = (int)DataTypeParser.Parse(townID.Rows[0]["TownID"], typeof(int), 0);
            this._township.TownID = ID;
     
            frmOrder orderForm = new frmOrder(_marketingDetail.OrderID, _marketingDetail.CusID, _township);
            // set call back handler
            orderForm.OrderSavedHandler += new frmOrder.OrderSaveHandler(OrderSave_CallBack);
            UIManager.OpenForm(orderForm);
        }

        private void OrderSave_CallBack(object sender, frmOrder.OrderSaveEventArgs e)
        {
            if (e.OrderID.HasValue) // If order id has been created
            {
                // Set order id to be refered by MarketingDetail
                _marketingDetail.OrderID = e.OrderID;
                // No need to close this form after saved
                _needToClose = false;
                // Save 
                Save();
            }
        }
        
        private void btnCustomerComplaint_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer() 
            {
                ID = _marketingDetail.CusID.Value,
                CusType = _customerTypeID
            };
            frmCusComplaint frmCusComplaint = new frmCusComplaint(_marketingDetail.CustomerComplaintID, cus, _township);
            // set call back handler
            frmCusComplaint.ComplaintSavedHandler += new frmCusComplaint.ComplaintSaveHandler(ComplaintSave_CallBack);
            UIManager.OpenForm(frmCusComplaint);
        }

        private void ComplaintSave_CallBack(object sender, frmCusComplaint.ComplaintSaveEventArgs e)
        {
            if (e.ComplaintID.HasValue) // If order id has been created
            {
                // Set order id to be refered by GovMarketingDetail
                _marketingDetail.CustomerComplaintID = e.ComplaintID;
                // No need to close this form after saved
                _needToClose = false;
                // Save 
                Save();
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPage));
            this.Close();
        }

        private void dgvOwn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOwn_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colOwnBrand.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex && !row.IsNewRow)
                    {
                        if (row.Cells["colOwnBrand"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "")
                            return;

                        if (row.Cells["colOwnBrand"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                            return;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }
        }

        private void dgvOwn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colOwnBrand.Index && dgv.Rows[e.RowIndex].ErrorText != String.Empty)
            {
                dgv.CurrentRow.Cells[colOwnBrand.Index].Value = -1;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void dgvCompetitor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colCompetitorBrand.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex && !row.IsNewRow)
                    {
                        if (row.Cells["colCompetitorBrand"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "")
                            return;

                        if (row.Cells["colCompetitorBrand"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                            return;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }
        }

        private void dgvCompetitor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colCompetitorBrand.Index && dgv.Rows[e.RowIndex].ErrorText != String.Empty)
            {
                dgv.CurrentRow.Cells[colCompetitorBrand.Index].Value = -1;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void dgvCompetitor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvOwn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        
        #endregion

        #region Private Methods
        /// <summary>
        /// Load and bind brands
        /// </summary>
        private void LoadNBindBrands()
        {            
            try
            {
                DataTable employeeTbl = new EmployeeBL().GetAll();
                DataTable dtEmployeesByDept = null;
                if (GlobalCache.is_sale == false)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                }
                cmbEmp.DataSource = dtEmployeesByDept;
                cmbEmp.ValueMember = "EmployeeID";
                cmbEmp.DisplayMember = "EmpName";


                // TODO: remove binding brands @frmDailyMarketingDetail
                cmbBrand.DataSource = new BrandBL().GetOwnBrands();
                //  OwnBrand Bind into DataGridView
                colOwnBrand.DataSource = new BrandBL().GetOwnBrands();
                colOwnBrand.DisplayMember = "BrandName";
                colOwnBrand.ValueMember = "BrandID";
                dgvOwn.AutoGenerateColumns = false;
                dgvCompetitor.AutoGenerateColumns = false;
                int? MarketingDetailID = (int?)DataTypeParser.Parse(this._marketingDetail.ID,typeof(int),-1);
                // TODO: load own brands by specific marketing detail id rather than getting all
                DataTable dtOwnBrand = new OwnBrandInMarketingDetailBL().GetOwnBrandInMarketingDetail();
                if (MarketingDetailID != -1)
                {
                    DataTable dtOwnBrandTmp = DataUtil.GetDataTableBy(dtOwnBrand, "MarketingDetailID", MarketingDetailID);
                    if (dtOwnBrandTmp != null)
                        dgvOwn.DataSource = dtOwnBrandTmp;
                    else
                        dgvOwn.DataSource = dtOwnBrand.Clone();
                }
                else
                {
                    dgvOwn.DataSource = dtOwnBrand.Clone();
                }

                //  Competitor Brand Bind into DataGridView
                colCompetitorBrand.DataSource = new BrandBL().GetCompetitorBrands();;
                colCompetitorBrand.DisplayMember = "BrandName";
                colCompetitorBrand.ValueMember = "BrandID";

                // TODO: get competitor brands by specific marketing detail id rather than get all
                DataTable dtCompeBrand = new CompetitorBrandInMarketingDetailBL().GetCompBrandInMarketingDetail();

                if (MarketingDetailID != -1)
                {
                    DataTable dtCompeBrandTmp = DataUtil.GetDataTableBy(dtCompeBrand, "MarketingDetailID", MarketingDetailID);
                    if (dtCompeBrandTmp != null)
                        dgvCompetitor.DataSource = dtCompeBrandTmp;
                    else
                        dgvCompetitor.DataSource = dtCompeBrand.Clone();
                }
                else
                {
                    dgvCompetitor.DataSource = dtCompeBrand.Clone();
                }
                dtTown = new TownshipBL().GetAll();
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

        /// <summary>
        /// 
        /// </summary>
        private void LoadNBindByMarketingDetailID(int? marketingDetailID)
        {
            if (!marketingDetailID.HasValue) // No need to load maketing detail for a new detail
                return;            
            try
            {                
                DataTable dtDetail = new MarketingDetailBL().GetByMarketingDetailID(marketingDetailID.Value);
                if (dtDetail.Rows.Count < 1)
                    return;
                cmbBrand.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["BrandID"], typeof(int), -1);
                dtpMarketedDate.Value = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["MarketedDate"], typeof(DateTime), DateTime.Now);
                _marketingDetail.OrderID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["OrderID"], typeof(int), null);
                _marketingDetail.A_P_UsageID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["A_P_UsageID"], typeof(int), null);
                _marketingDetail.CustomerComplaintID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["CustomerComplaintID"], typeof(int), null);
                _marketingDetail.CompetitorActivityID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["CompetitorActivityID"], typeof(int), null);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {
            SqlConnection conn = null;
            DataTable dt = dgvOwn.DataSource as DataTable;

            DataTable dtComp = dgvCompetitor.DataSource as DataTable;

            List<OwnBrandInMarketingDetail> insertOwnBrand = new List<OwnBrandInMarketingDetail>();
            List<OwnBrandInMarketingDetail> updateOwnBrand = new List<OwnBrandInMarketingDetail>();
            List<OwnBrandInMarketingDetail> deleteOwnBrand = new List<OwnBrandInMarketingDetail>();

            List<CompetitorBrandInMarketingDetail> insertCompBrand = new List<CompetitorBrandInMarketingDetail>();
            List<CompetitorBrandInMarketingDetail> updateCompBrand = new List<CompetitorBrandInMarketingDetail>();
            List<CompetitorBrandInMarketingDetail> deleteCompBrand = new List<CompetitorBrandInMarketingDetail>();

            DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
            foreach (DataRow row in dvInsert.ToTable().Rows)
            {
                    OwnBrandInMarketingDetail ownBrandInMarketingDetail = new OwnBrandInMarketingDetail()
                    {                       
                        BrandID = (int)DataTypeParser.Parse(row["BrandID"],typeof(int),-1)
                    };
                    insertOwnBrand.Add(ownBrandInMarketingDetail);                
            }

            // delete
            DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
            foreach (DataRow row in dvDelete.ToTable().Rows)
            {
                OwnBrandInMarketingDetail ownBrandInMarketingDetail = new OwnBrandInMarketingDetail()
                {
                    ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1)
                };
                deleteOwnBrand.Add(ownBrandInMarketingDetail);  
            }

            // update
            DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
            foreach (DataRow row in dvUpdate.ToTable().Rows)
            {
                OwnBrandInMarketingDetail ownBrandInMarketingDetail = new OwnBrandInMarketingDetail()
                {
                    ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1),
                    BrandID =(int)DataTypeParser.Parse(row["BrandID"],typeof(int),-1)
                };
                updateOwnBrand.Add(ownBrandInMarketingDetail);             
            }

            DataView dvCompInsert = new DataView(dtComp, string.Empty, string.Empty, DataViewRowState.Added);
            foreach (DataRow row in dvCompInsert.ToTable().Rows)
            {
                CompetitorBrandInMarketingDetail compBrandInMarketingDetail = new CompetitorBrandInMarketingDetail()
                {
                    BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1)
                };
                insertCompBrand.Add(compBrandInMarketingDetail);
            }

            // delete
            DataView dvCompDelete = new DataView(dtComp, string.Empty, string.Empty, DataViewRowState.Deleted);
            foreach (DataRow row in dvCompDelete.ToTable().Rows)
            {
                CompetitorBrandInMarketingDetail compBrandInMarketingDetail = new CompetitorBrandInMarketingDetail()
                {
                    ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1)
                };
                deleteCompBrand.Add(compBrandInMarketingDetail);
            }

            // update
            DataView dvCompUpdate = new DataView(dtComp, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
            foreach (DataRow row in dvCompUpdate.ToTable().Rows)
            {
                CompetitorBrandInMarketingDetail compBrandInMarketingDetail = new CompetitorBrandInMarketingDetail()
                {
                    ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1),
                    BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1)
                };
                updateCompBrand.Add(compBrandInMarketingDetail);
            }

            try
            {
                conn = DBManager.GetInstance().GetDbConnection();               

                MarketingDetail mkDetail = new MarketingDetail() 
                {
                    ID = _marketingDetail.ID,
                    CusID = _marketingDetail.CusID, // Detail customer
                    EmpID = (int?)DataTypeParser.Parse(cmbEmp.SelectedValue,typeof(int),null), // Detail employee 
                    MarketingPlanID = _marketingDetail.MarketingPlanID,
                    //BrandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), null),
                    OrderID = _marketingDetail.OrderID,
                    A_P_UsageID = _marketingDetail.A_P_UsageID,
                    CustomerComplaintID = _marketingDetail.CustomerComplaintID,
                    CompetitorActivityID = _marketingDetail.CompetitorActivityID,
                    MarketedDate = dtpMarketedDate.Value
                };
                int? affectedRow = null;
                MarketingDetailBL mkDetailSaver = new MarketingDetailBL();
                if(!_marketingDetail.ID.HasValue) // New marketing detail
                {
                    // Add new marketing detail
                    this._marketingDetail.ID = affectedRow = mkDetailSaver.Add(mkDetail, insertOwnBrand ,insertCompBrand);
                }
                else // An existing marketing detail
                {
                    // Update an existing marketing detail
                    affectedRow = mkDetailSaver.UpdateByMarketingDetailID(mkDetail,insertOwnBrand,insertCompBrand);
                }
                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    // Return value to caller
                    DailyMarketingDetailSaveEventArgs A_PUsageSaveEventArg = new DailyMarketingDetailSaveEventArgs(true);
                    DailyMarketingDetailSavedHandler(this, A_PUsageSaveEventArg);

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    if(this._needToClose)
                        this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException sqle)
            {
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        // DeleteMarketingDetail(_marketingDetail.ID);
        private void DeleteMarketingDetail(int? marketingDetailID)
        {
            SqlConnection conn = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                int mkDetailID = (int)DataTypeParser.Parse(marketingDetailID, typeof(int), -1);
                affectedRow = new MarketingDetailBL().DeleteByMarketingDetailID(mkDetailID, conn);
                if (affectedRow > 0)
                {
                    // return value to sender
                    DailyMarketingDetailSaveEventArgs A_PUsageSaveEventArg = new DailyMarketingDetailSaveEventArgs(true);
                    DailyMarketingDetailSavedHandler(this, A_PUsageSaveEventArg);

                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
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

        #endregion

        #region Constructors
        public frmDailyMarketingDetail()
        {
            InitializeComponent();
            // Load brands
            LoadNBindBrands();
        }

        public frmDailyMarketingDetail
            //(string customerType, string customerName, string township, string employeeName, 
            //Address address, MarketingDetail marketingDetail)
            (Customer customer, string customerType, string employeeName, 
            Township township, MarketingDetail marketingDetail)
         {
            InitializeComponent();
            this._marketingDetail = marketingDetail;
            this._township = township;
            this._customerTypeID = customer.CusType;
            // Set values
            txtCustomerType.Text = customerType;
            txtTownship.Text = township.TownshipName;
            txtCustomerName.Text = customer.CusName;
            txtEmployee.Text = employeeName;
          
            // Load brands
            LoadNBindBrands();
            if (_marketingDetail != null && _marketingDetail.ID.HasValue)
            {
                // Load an existing marketing detail
                LoadNBindByMarketingDetailID(_marketingDetail.ID);
                // Enable delete button
                btnDelete.Enabled = true;
            }  

            // if customer is still a potential cutomer, do not allow Order process
            if (customer.IsPotential)
                btnOrder.Enabled = false;
        }
        #endregion

        #region Inner Class
        public class DailyMarketingDetailSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;
            public DailyMarketingDetailSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        

    }
}
