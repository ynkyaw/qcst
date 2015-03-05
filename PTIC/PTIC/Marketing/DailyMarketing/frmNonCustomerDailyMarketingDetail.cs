/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/09/23 (yyyy/MM/dd)
 * Description: Non Customer Daily Marketing Detail form
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.Order;
using PTIC.VC.Marketing;
using log4net;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.VC.Marketing.A_P;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.VC.Sale.Setup;

namespace PTIC.Marketing.DailyMarketing
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmNonCustomerDailyMarketingDetail : Form
    {
        /// <summary>
        /// Logger for frmNonCustomerDailyMarketingDetail
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmNonCustomerDailyMarketingDetail));

        /*** Customer in town ***/
        private BindingSource bdTown = new BindingSource();  // Town
        private BindingSource bdTownWithCusType = new BindingSource(); // CusType
        private BindingSource bdCustomerInTown = new BindingSource(); // Customer
        
        /*** Customer in township ***/
        private BindingSource bdTownship = new BindingSource();
        private BindingSource bdTownshipWithCusType = new BindingSource();
        private BindingSource bdCustomerInTownship = new BindingSource();

        private MarketingDetail _marketingDetail = null;

        public delegate void NonCustomerDailyMarketingDetailSaveHandler(object sender, NonCustomerDailyMarketingDetailSaveEventArgs e);

        public event NonCustomerDailyMarketingDetailSaveHandler NonCustomerDailyMarketingDetailSavedHandler;

        /// <summary>
        /// Flag indicating frmDailyMarketingDetail form should be closed after saved
        /// </summary>
        private bool _needToClose = false;

        #region Events
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            //UIManager.OpenForm(typeof(frmNewCustomer));
        }

        private void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            FilterCustomerByIsPotential();
            
            CheckPotentialCustomerOrNot();            
        }

        private void rdoTownTownship_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == rdoTown)
            {                                
                // Bind Town
                cmbTownTownship.DataSource = bdTown;
                // Bind CusType
                cmbCustType.DataSource = bdTownWithCusType;
                // Bind Customer
                cmbCustomer.DataSource = bdCustomerInTown;

                cmbTownTownship.ValueMember = "TownID";
                cmbTownTownship.DisplayMember = "Town";                
            }
            else // rdoTownship
            {                                
                // Bind Town
                cmbTownTownship.DataSource = bdTownship;
                // Bind CusType
                cmbCustType.DataSource = bdTownshipWithCusType;
                // Bind Customer
                cmbCustomer.DataSource = bdCustomerInTownship;

                cmbTownTownship.ValueMember = "TownshipID";
                cmbTownTownship.DisplayMember = "Township";
            }
            cmbCustType.SelectedValue = -1;            
            cmbCustomer.SelectedValue = -1;
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckPotentialCustomerOrNot();
        }
        
        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPage));
            this.Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //DataTable townID = DataUtil.GetDataTableBy(_dtTown, "TownshipID", this._township.TownshipID);
            //int ID = (int)DataTypeParser.Parse(townID.Rows[0]["TownID"], typeof(int), 0);
            //this._township.TownID = ID;

            int? customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (!customerID.HasValue)
            {
                MessageBox.Show("Customer အမည် ဖြည့်သွင်းပါ။", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmOrder orderForm = new frmOrder(
                _marketingDetail == null ? null : _marketingDetail.OrderID,
                //_marketingDetail == null ? null : _marketingDetail.CusID,
                customerID,
                new Township()
                {
                    TownID = rdoTown.Checked ? (int)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), -1) : -1
                });
            // set call back handler
            orderForm.OrderSavedHandler += new frmOrder.OrderSaveHandler(OrderSave_CallBack);
            UIManager.OpenForm(orderForm);
        }

        private void OrderSave_CallBack(object sender, frmOrder.OrderSaveEventArgs e)
        {
            if (e.OrderID.HasValue) // If order id has been created
            {
                // Set order id to be refered by MarketingDetail
                if (_marketingDetail == null)
                    _marketingDetail = new MarketingDetail();
                _marketingDetail.OrderID = e.OrderID;
                // No need to close this form after saved
                _needToClose = false;
                // Save 
                Save();
            }
        }

        private void btnAPUsage_Click(object sender, EventArgs e)
        {
            int? customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (!customerID.HasValue)
            {
                MessageBox.Show("Customer အမည် ဖြည့်သွင်းပါ။", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmA_PUsage apUsage = new frmA_PUsage(
                _marketingDetail == null ? null : _marketingDetail.A_P_UsageID,
                customerID.Value);            
            // set call back handler
            apUsage.A_PUsagSavedHandler += new frmA_PUsage.A_PUsageSaveHandler(A_PUsageSave_CallBack);
            // Open A P Usage form
            UIManager.OpenForm(apUsage);
        }

        private void A_PUsageSave_CallBack(object sender, frmA_PUsage.A_PUsageSaveEventArgs e)
        {
            if (e.A_PUsageID.HasValue) // If A_P_Usage has been created
            {
                if (_marketingDetail == null)
                    _marketingDetail = new MarketingDetail();
                // Set A_P_UsageID to be refered by MarketingDetail
                _marketingDetail.A_P_UsageID = e.A_PUsageID;
                // No need to close this form after saved
                _needToClose = false;
                // Save A_P_Usage
                Save();
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            frmNewCustomer formTmpCustomer = 
                new frmNewCustomer(rdoNonCustomer.Checked ? true : false);
            // Set call back function
            formTmpCustomer.TempCustomerSavedHandler += new frmNewCustomer.TempCustomerSaveHandler(formNewCustomer_CallBack);
            // Open an entry form for a temp customer
            UIManager.OpenForm(formTmpCustomer);
        }

        void formNewCustomer_CallBack(object sender, frmNewCustomer.TempCustomerSaveEventArgs e)
        {            
            // Reload data
            //LoadNBind();
            // TODO: just add new customer instead of reloading customer
            LoadNBindNecessaryData();            
            // Set a selected town
            if (rdoTown.Checked)
                cmbTownTownship.SelectedValue = e.SavedAddress.TownID;
            else // township is checked
                cmbTownTownship.SelectedValue = e.SavedAddress.TownshipID;
            // Set a selected customer
            cmbCustomer.SelectedValue = e.SavedTempCustomer.ID;                        
        }

        private void btnCompetitorActivity_Click(object sender, EventArgs e)
        {
            frmCompetitorActivity comActivity = new frmCompetitorActivity(
                _marketingDetail == null ? null : _marketingDetail.CompetitorActivityID);
            // Set call back handler
            comActivity.CompetitorActivitySavedHandler +=
                new frmCompetitorActivity.CompetitorActivitySaveHandler(comActivity_CompetitorActivitySavedHandler);
            // Open Form frmCompetitorActivity
            UIManager.OpenForm(comActivity);
        }

        private void comActivity_CompetitorActivitySavedHandler(object sender, frmCompetitorActivity.CompetitorActivitySaveEventArgs e)
        {
            if (e.CompetitorActivityID.HasValue)
            {
                if (_marketingDetail == null)
                    _marketingDetail = new MarketingDetail();
                // Set CompetitorActivityID to be refered by GovMarketingDetail
                _marketingDetail.CompetitorActivityID = e.CompetitorActivityID;
                // No need to close this form after saved
                _needToClose = false;
                // Save Daily Marketing Detail
                Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (!customerID.HasValue)
            {
                MessageBox.Show("Customer အမည် ဖြည့်သွင်းပါ။", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Need to close this form after saved
            _needToClose = true;
            // Save Daily Marketing Detail
            Save();
        }
        #endregion

        #region Private Methods
        private void LoadNBindNecessaryData()
        {
            try
            {                
                DataSet dsCustomerInTown = new DataSet();
                
                //BindingSource bdTown = new BindingSource();  // Town
                //BindingSource bdTownWithCusType = new BindingSource(); // CusType
                //BindingSource bdCustomer = new BindingSource(); // Customer
                
                DataTable dtTown = new TownBL().GetAll(); // Load Town
                DataTable dtTownWithCusType = new TownBL().GetAllWithCusType(); // Load CusType
                DataTable dtCustomer = new CustomerBL().GetAll(); // Load Customer
                
                // add three datatables into a single dataset
                dsCustomerInTown.Tables.Add(dtTown);
                dsCustomerInTown.Tables.Add(dtTownWithCusType);
                dsCustomerInTown.Tables.Add(dtCustomer);
                
                // create data relations among three tables
                DataRelation relTown_CusType = new DataRelation("Town_CusType",
                       dtTown.Columns["TownID"], dtTownWithCusType.Columns["TownID"], false);
                DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                       dtTownWithCusType.Columns["CusType"], dtCustomer.Columns["CusType"], false);
                dsCustomerInTown.Relations.Add(relTown_CusType);
                dsCustomerInTown.Relations.Add(relCusType_Customer);
                
                bdTown.DataSource = dsCustomerInTown;
                bdTown.DataMember = dtTown.TableName;

                bdTownWithCusType.DataSource = bdTown;
                bdTownWithCusType.DataMember = "Town_CusType";

                bdCustomerInTown.DataSource = bdTownWithCusType;
                bdCustomerInTown.DataMember = "CusType_Customer";
                
                //// *** Customer in town ***/
                //// Bind Town
                //cmbTown.DataSource = bdTown;
                //// Bind CusType
                //cmbCustTypeInTown.DataSource = bdTownWithCusType;
                //// Bind Customer
                //cmbCustomerInTown.DataSource = bdCustomer;

                // *** Customer in township ***/             
                DataSet dsCustomerInTownship = new DataSet();
                                
                DataTable dtTownship = new TownshipBL().GetAll(); // Load Town
                DataTable dtTownshipWithCusType = new TownshipBL().GetWithCustomerType(); // Load CusType
                DataTable dtCustomerTownship = dtCustomer.Copy();

                // add three datatables into a single dataset
                dsCustomerInTownship.Tables.Add(dtTownship);
                dsCustomerInTownship.Tables.Add(dtTownshipWithCusType);
                dsCustomerInTownship.Tables.Add(dtCustomerTownship);

                // create data relations among three tables
                DataRelation relTownship_CusType = new DataRelation("Township_CusType",
                       dtTownship.Columns["TownshipID"], dtTownshipWithCusType.Columns["TownshipID"], false);
                DataRelation relTownshipCusType_Customer = new DataRelation("CusType_Customer",
                       dtTownshipWithCusType.Columns["CusType"], dtCustomerTownship.Columns["CusType"], false);
                dsCustomerInTownship.Relations.Add(relTownship_CusType);
                dsCustomerInTownship.Relations.Add(relTownshipCusType_Customer);

                bdTownship.DataSource = dsCustomerInTownship;
                bdTownship.DataMember = dtTownship.TableName;

                bdTownshipWithCusType.DataSource = bdTownship;
                bdTownshipWithCusType.DataMember = "Township_CusType";

                bdCustomerInTownship.DataSource = bdTownshipWithCusType;
                bdCustomerInTownship.DataMember = "CusType_Customer";

                //// *** Default: Customer in town ***/                
                // Bind Town
                cmbTownTownship.DataSource = bdTown;
                // Bind CusType
                cmbCustType.DataSource = bdTownWithCusType;
                // Bind Customer
                cmbCustomer.DataSource = bdCustomerInTown;

                // Load preloaded brands
                LoadNBindBrands();
            }
            catch (Exception e)
            {
                MessageBox.Show(Resource.FailedToLoadData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void LoadNBindBrands()
        {            
            try
            {                                
                //  OwnBrand Bind into DataGridView
                colOwnBrand.DataSource = new BrandBL().GetOwnBrands();
                colOwnBrand.DisplayMember = "BrandName";
                colOwnBrand.ValueMember = "BrandID";
                               
                // TODO: do not load all brands from all marketing details, load just brands included in specific marketing detail
                DataTable dtOwnBrand = new OwnBrandInMarketingDetailBL().GetOwnBrandInMarketingDetail();

                // just set chema
                dgvOwn.DataSource = dtOwnBrand.Clone();

                if (this._marketingDetail != null && this._marketingDetail.ID.HasValue)
                {
                    DataTable dtOwnBrandTmp = DataUtil.GetDataTableBy(dtOwnBrand, "MarketingDetailID", this._marketingDetail.ID.Value);
                    dgvOwn.DataSource = dtOwnBrandTmp;
                }
                //else
                //{
                //    dgvOwn.DataSource = dtOwnBrand.Clone();
                //}
                //  Competitor Brand Bind into DataGridView
                colCompetitorBrand.DataSource = new BrandBL().GetCompetitorBrands(); ;
                colCompetitorBrand.DisplayMember = "BrandName";
                colCompetitorBrand.ValueMember = "BrandID";

                DataTable dtCompeBrand = new CompetitorBrandInMarketingDetailBL().GetCompBrandInMarketingDetail();
                // just set schema
                dgvCompetitor.DataSource = dtCompeBrand.Clone();
                if (this._marketingDetail != null && this._marketingDetail.ID.HasValue)
                {
                    DataTable dtCompeBrandTmp = DataUtil.GetDataTableBy(dtCompeBrand, "MarketingDetailID", this._marketingDetail.ID.Value);
                    dgvCompetitor.DataSource = dtCompeBrandTmp;
                }
                //else
                //{
                //    dgvCompetitor.DataSource = dtCompeBrand.Clone();
                //}                
            }
            catch (Exception e)
            {
                ToastMessageBox.Show(Resource.errFailedToSave);
                _logger.Error(e);
            }            
        }

        private void CheckPotentialCustomerOrNot()
        {
            if (cmbCustomer.SelectedItem == null)
            {
                btnOrder.Enabled = false;
                return;
            }
            DataRow selectedCustomer = (cmbCustomer.SelectedItem as DataRowView).Row;

            bool isPotentialCustomer = (bool)DataTypeParser.Parse(selectedCustomer["IsPotential"], typeof(bool), true);
            if (isPotentialCustomer)
            {
                btnOrder.Enabled = false;
            }
            else
            {
                btnOrder.Enabled = true;
            }
        }

        private void FilterCustomerByIsPotential()
        {
            bool isPotentialCustomer = rdoNonCustomer.Checked ? true : false;
            int ii = Convert.ToInt16(isPotentialCustomer);
            this.bdCustomerInTown.Filter = "IsPotential = "+ ii;
            this.bdCustomerInTownship.Filter = "IsPotential = " + ii;
        }
       
        private void Save()
        {            
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
                    BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1)
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
                    BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1)
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
                MarketingDetail mkDetail = new MarketingDetail()
                {
                    //ID = _marketingDetail.ID,
                    ID = _marketingDetail == null ? null : _marketingDetail.ID,                                                            
                    //CusID = _marketingDetail.CusID, // Detail customer
                    CusID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null),
                    //EmpID = _marketingDetail.EmpID, // Detail employee 
                    //EmpID = _marketingDetail == null ? GlobalCache.LoginEmployee.ID : _marketingDetail.EmpID, // Detail employee 
                    EmpID = GlobalCache.LoginEmployee.ID,
                    MarketingPlanID = _marketingDetail == null ? null : _marketingDetail.MarketingPlanID,
                    OrderID = _marketingDetail == null ? null : _marketingDetail.OrderID,
                    A_P_UsageID = _marketingDetail == null ? null : _marketingDetail.A_P_UsageID,
                    CustomerComplaintID = _marketingDetail == null ? null : _marketingDetail.CustomerComplaintID,
                    CompetitorActivityID = _marketingDetail == null ? null : _marketingDetail.CompetitorActivityID,
                    MarketedDate = dtpMarketedDate.Value
                };
                int? affectedRow = null;
                MarketingDetailBL mkDetailSaver = new MarketingDetailBL();
                if (_marketingDetail == null || !_marketingDetail.ID.HasValue) // New marketing detail
                {
                    // Add new marketing detail
                    if (this._marketingDetail == null)
                        this._marketingDetail = new MarketingDetail();
                    this._marketingDetail.ID = affectedRow = mkDetailSaver.Add(mkDetail, insertOwnBrand, insertCompBrand);
                }
                else // An existing marketing detail
                {
                    // Update an existing marketing detail
                    affectedRow = mkDetailSaver.UpdateByMarketingDetailID(mkDetail,insertOwnBrand,insertCompBrand);
                }
                if (affectedRow.HasValue && affectedRow.Value > 0)
                {
                    // when this is called by log / plan
                    if (NonCustomerDailyMarketingDetailSavedHandler != null)
                    {
                        NonCustomerDailyMarketingDetailSaveEventArgs A_PUsageSaveEventArg = new NonCustomerDailyMarketingDetailSaveEventArgs(true);
                        NonCustomerDailyMarketingDetailSavedHandler(this, A_PUsageSaveEventArg);
                    }

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    if (this._needToClose)
                        this.Close();
                    else
                        DisableCustomerSelection();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);                
            }
            catch (Exception e)
            {
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                _logger.Error(e);
            }            
        }

        private void DisableCustomerSelection()
        {
            gbxCustomer.Enabled =
            btnNewCustomer.Enabled = false;
        }
        #endregion

        #region Constructors
        public frmNonCustomerDailyMarketingDetail()
        {
            InitializeComponent();
            dgvOwn.AutoGenerateColumns = false;
            dgvCompetitor.AutoGenerateColumns = false;

            LoadNBindNecessaryData();
            // Set employee name
            txtEmployee.Text = GlobalCache.LoginEmployee.EmpName;
        }
        #endregion

        #region Inner Class
        public class NonCustomerDailyMarketingDetailSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;
            public NonCustomerDailyMarketingDetailSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

                                                
    }
}
