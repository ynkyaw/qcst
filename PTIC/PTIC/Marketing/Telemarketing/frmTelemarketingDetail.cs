using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using log4net;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Sale.Order;
using PTIC.Common.BL;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.Sale.Entities;
using PTIC.Marketing.DA;

namespace PTIC.VC.Marketing.Telemarketing
{
    public partial class frmTelemarketingDetail : Form
    {
        private int? _TeleMarketingID = null;
        /// <summary>
        /// Logger for frmDailyMarketingLog
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTelemarketingDetail));

        bool lookupflag = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TeleMarketingDetailSavedHandler(object sender, TeleMarketingDetailSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event TeleMarketingDetailSavedHandler TeleMarketingDetailSavedHandlers;

        /// <summary>
        /// 
        /// </summary>
        private TeleMarketingDetail _teleMarketingDetail = new TeleMarketingDetail();

        /// <summary>
        /// Flag indicating frmDailyMarketingDetail form should be closed after saved
        /// </summary>
        private bool _needToClose = false;

        int CustomerType = 0;
        int Township = 0;
        int CustomerName = 0;

        private Township _township = new Township();

        private DataTable dtTown = null;

        public frmTelemarketingDetail()
        {
            InitializeComponent();

            // Load brands
            LoadNBindBrands();
        }

        public frmTelemarketingDetail(int? teleMarketingID,int TownshipID)
        {
            InitializeComponent();
            this._TeleMarketingID = teleMarketingID;
            lookupflag = true;          
            int teleMarketingDetailID = (int)DataTypeParser.Parse(this._TeleMarketingID, typeof(int), -1);
            LoadNBindByTeleMarketingDetailID(teleMarketingDetailID);
            // Load brands
            LoadNBindBrands();
            cmbTownship.SelectedValue = TownshipID;
        }

        public frmTelemarketingDetail(int customerType, int customerName, int township, string employeeName, TeleMarketingDetail teleMarketingDetail)
        {
            InitializeComponent();
            this._teleMarketingDetail = teleMarketingDetail;

            cmbCustName.Enabled = false;
            cmbCusType.Enabled = false;
            cmbTownship.Enabled = false;

            // Set values
            //cmbCusType.SelectedValue = customerType;
            //cmbCustName.SelectedValue = customerName;
            //cmbTownship.SelectedValue = township;
            this.CustomerType = customerType;
            this.Township = township;
            this.CustomerName = customerName;
            // Load brands
            LoadNBindBrands();

            if (teleMarketingDetail != null && teleMarketingDetail.ID.HasValue)
            {
                // Load an existing marketing detail
                LoadNBindByTeleMarketingDetailID(teleMarketingDetail.ID);
                // Enable delete button
                // btnDelete.Enabled = true;
            }
            else
            {
                btnOrder.Enabled = false;
            }
        }



        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #region Inner Class
        public class TeleMarketingDetailSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;
            public TeleMarketingDetailSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        #region private Function
        /// <summary>
        /// Load and bind brands
        /// </summary>
        private void LoadNBindBrands()
        {            
            try
            {                
                cmbSaleBrand.DataSource = new BrandBL().GetOwnBrands();
                cmbPurchaseBrand.DataSource = new BrandBL().GetAll();
                cmbPurchaseProduct.DataSource = new ProductBL().GetAll();

                DataSet ds = new DataSet();
                BindingSource bdTownship = new BindingSource();
                BindingSource bdTownshipWithCusType = new BindingSource();
                BindingSource bdCustomer = new BindingSource();

                DataTable dtTownship = new TownshipBL().GetAll();
                DataTable dtTownshipWithCusType = new TownshipBL().GetWithCustomerType();
                DataTable dtCustomer = new CustomerBL().GetAll();
                this.dtTown = dtTownship;
                // add three datatables into a single dataset
                ds.Tables.Add(dtTownship);
                ds.Tables.Add(dtTownshipWithCusType);
                ds.Tables.Add(dtCustomer);

                // create data relations among three tables
                DataRelation relTownship_CusType = new DataRelation("Township_CusType",
                       dtTownship.Columns["TownshipID"], dtTownshipWithCusType.Columns["TownshipID"], false);
                DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                       dtTownshipWithCusType.Columns["CusType"], dtCustomer.Columns["CusType"], false);
                ds.Relations.Add(relTownship_CusType);
                ds.Relations.Add(relCusType_Customer);

                bdTownship.DataSource = ds;
                bdTownship.DataMember = dtTownship.TableName;

                bdTownshipWithCusType.DataSource = bdTownship;
                bdTownshipWithCusType.DataMember = "Township_CusType";

                bdCustomer.DataSource = bdTownshipWithCusType;
                bdCustomer.DataMember = "CusType_Customer";

                cmbCusType.DataSource = bdTownshipWithCusType;
                cmbTownship.DataSource = bdTownship;
                cmbCustName.DataSource = bdCustomer;

                cmbSaleBrand.DisplayMember = "BrandName";
                cmbSaleBrand.ValueMember = "BrandID";

                cmbPurchaseBrand.DisplayMember = "BrandName";
                cmbPurchaseBrand.ValueMember = "BrandID";

                cmbPurchaseProduct.DisplayMember = "ProductName";
                cmbPurchaseProduct.ValueMember = "ProductID";

                DataSet ds2 = new DataSet();
                BindingSource bdPurchaseBrand = new BindingSource();
                BindingSource bdPurchaseProduct = new BindingSource();

                DataTable dtPurchaseBrand = new BrandBL().GetOwnBrands().Copy();
                DataTable dtPurchaseProduct = new ProductBL().GetAll().Copy();

                // add town and customer tables into a dataset
                ds2.Tables.Add(dtPurchaseBrand);
                ds2.Tables.Add(dtPurchaseProduct);

                // create data relation between town and customer
                DataRelation relBrand_Product = new DataRelation("Brand_Product", dtPurchaseBrand.Columns["BrandID"], dtPurchaseProduct.Columns["BrandID"]);
                // add relation into a dataset
                ds2.Relations.Add(relBrand_Product);

                bdPurchaseBrand.DataSource = ds2;
                bdPurchaseBrand.DataMember = dtPurchaseBrand.TableName;

                bdPurchaseProduct.DataSource = bdPurchaseBrand;
                bdPurchaseProduct.DataMember = "Brand_Product";

                cmbPurchaseBrand.DataSource = bdPurchaseBrand;
                cmbPurchaseProduct.DataSource = bdPurchaseProduct;

                //Load Employee Data
                DataTable dtEmployee = new EmployeeBL().GetAll();
                DataTable dtEmployeesByDept = null;
                if (GlobalCache.is_sale == false)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployee, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployee, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                }
                cmbEmployee.DataSource = dtEmployeesByDept;
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.DisplayMember = "EmpName";

                cmbTownship.SelectedValue = Township;
                cmbCusType.SelectedValue = CustomerType;
                cmbCustName.SelectedValue = CustomerName;

                string phone = string.Empty;
                // Phone 1
                phone += string.IsNullOrEmpty(dtCustomer.Rows[0]["Phone11"].ToString()) ? string.Empty : dtCustomer.Rows[0]["Phone11"].ToString() + ", \r\n";

                // Phone 2
                phone += string.IsNullOrEmpty(dtCustomer.Rows[0]["Phone21"].ToString()) ? string.Empty : dtCustomer.Rows[0]["Phone21"].ToString();

                phone = phone.Replace(",,", ",");
                txtCusPhone.Text = phone;

                txtContactPhone.Text = string.IsNullOrEmpty(dtCustomer.Rows[0]["MobilePhone"].ToString()) ? 
                    string.Empty : dtCustomer.Rows[0]["MobilePhone"].ToString();
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

        private void LoadNBindByTeleMarketingDetailID(int? teleMarketingDetailID)
        {
            if (!teleMarketingDetailID.HasValue) // No need to load maketing detail for a new detail
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtDetail = new TelemarketingDetailBL().GetByTeleMarketingDetailID(teleMarketingDetailID.Value, conn);
                if (dtDetail.Rows.Count < 1)
                    return;
                _teleMarketingDetail.OrderID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["OrderID"], typeof(int), null);
                cmbTownship.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["TownshipID"], typeof(int), -1);
                cmbCusType.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["CusTypeID"], typeof(int), -1);
                cmbCustName.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["CusID"], typeof(int), -1);
                cmbPurchaseBrand.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["UsingBrandID"], typeof(int), -1);
                cmbPurchaseProduct.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["UsingProductID"], typeof(int), -1);
                cmbTownship.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["TownshipID"], typeof(int), -1);
                cmbSaleBrand.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["SellingBrandID"], typeof(int), -1);
                dtpMarketedDate.Value = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["MarketedDate"], typeof(DateTime), DateTime.Now);
                DateTime recall = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["RecallDate"], typeof(DateTime), DateTime.MinValue);
                DateTime service = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["ServiceDate"], typeof(DateTime), DateTime.Now);
                if (recall != service && recall != DateTime.Now && service != DateTime.Now)
                {
                    rdoServiceYes.Checked = true;
                }
                else
                {
                    rdoServiceYes.Checked = false;
                }

                //  Assign Recall Date When Recall Need
                if (recall != DateTime.MinValue)
                {
                    dtpRecallDate.Checked = true;
                    dtpRecallDate.Value = (DateTime)DataTypeParser.Parse(recall, typeof(DateTime), DateTime.Now);
                    dtpRecallDate.Enabled = false;
                }
                // Assign ServiceDate When Service Need
                if (service != DateTime.MinValue)
                {
                    dtpSvcDate.Value = (DateTime)DataTypeParser.Parse(service, typeof(DateTime), DateTime.Now);
                    dtpSvcDate.Enabled = false;
                    rdoServiceYes.Checked = true;
                }
                else
                {
                    rdoServiceNo.Checked = true;
                }
                txtSalePeriod.Text = dtDetail.Rows[0]["SellingPeriod"].ToString();
                txtContactName.Text = dtDetail.Rows[0]["ConPersonName"].ToString();
                txtContactPhone.Text = dtDetail.Rows[0]["MobilePhone"].ToString();
                txtCusPhone.Text = dtDetail.Rows[0]["Phone1"].ToString();
                cmbEmployee.SelectedValue = dtDetail.Rows[0]["EmpID"].ToString();
                txtPurchaseQty.Text = dtDetail.Rows[0]["UsingQty"].ToString();
                txtPurchasePeriod.Text = dtDetail.Rows[0]["UsingPeriod"].ToString();

                txtSatifiedReason.Text = dtDetail.Rows[0]["SatisfactionFact"].ToString();
                txtDisatifiedReason.Text = dtDetail.Rows[0]["DisatisfactionFact"].ToString();
                txtOtherFact.Text = dtDetail.Rows[0]["OtherFact"].ToString();

                if (lookupflag == true)
                {
                    btnSave.Enabled = false;
                    btnOrder.Enabled = false;
                }
                else
                {
                    btnOrder.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                TeleMarketingDetail teleMarketing = new TeleMarketingDetail()
                {
                    ID = _teleMarketingDetail.ID,
                    CusID = _teleMarketingDetail.CusID, // Detail customer
                    //EmpID = _teleMarketingDetail.EmpID, // Detail employee 
                    MarketingPlanID = _teleMarketingDetail.MarketingPlanID,

                    MarketedDate = dtpMarketedDate.Value,
                    OrderID = _teleMarketingDetail.OrderID,
                    EmpID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1),
                    UsingBrand = (int)DataTypeParser.Parse(cmbPurchaseBrand.SelectedValue, typeof(int), -1),
                    UsingProductID = (int)DataTypeParser.Parse(cmbPurchaseProduct.SelectedValue, typeof(int), -1),
                    UsingQty = (int)DataTypeParser.Parse(txtPurchaseQty.Text, typeof(int), 0),
                    UsingPeriod = (int)DataTypeParser.Parse(txtPurchasePeriod.Text, typeof(int), 0),
                    SellingPeriod = (int)DataTypeParser.Parse(txtSalePeriod.Text, typeof(int), 0),
                    SellingBrandID = (int)DataTypeParser.Parse(cmbSaleBrand.SelectedValue, typeof(int), -1),
                    SatisfactionFact = txtSatifiedReason.Text,
                    DisatisfactionFact = txtDisatifiedReason.Text,
                    OtherFact = txtOtherFact.Text,
                    ServiceDate = rdoServiceYes.Checked ? dtpSvcDate.Value : DateTime.MinValue,
                    RecallDate = dtpRecallDate.Checked ? dtpRecallDate.Value : DateTime.MinValue
                };
           
                int affectedRow = 0;             

                if (!_teleMarketingDetail.ID.HasValue) // New marketing detail
                {     
                    // Add new marketing detail
                    if (rdoServiceYes.Checked && dtpRecallDate.Checked)
                    {
                        affectedRow = new TelemarketingDetailBL().Add(teleMarketing, conn, true, true);
                    }
                    else if (rdoServiceYes.Checked)
                    {
                        affectedRow = new TelemarketingDetailBL().Add(teleMarketing, conn, true, false);
                    }
                    else if (dtpRecallDate.Checked)
                    {
                        affectedRow = new TelemarketingDetailBL().Add(teleMarketing, conn, false, true);
                    }
                    else
                    {
                        affectedRow = new TelemarketingDetailBL().Add(teleMarketing, conn, false, false);
                    }
                }
                else // An existing marketing detail
                {
                    // Update an existing marketing detail
                    if (rdoServiceYes.Checked)
                    {
                        affectedRow = new TelemarketingDetailBL().UpdateByTeleMarketingDetailID(teleMarketing, conn, true);
                    }
                    else
                    {
                        affectedRow = new TelemarketingDetailBL().UpdateByTeleMarketingDetailID(teleMarketing, conn, false);
                    }
                }
                if (affectedRow >= 0)
                {
                    // return value to sender
                    TeleMarketingDetailSaveEventArgs OrderSaveEventArg = new TeleMarketingDetailSaveEventArgs(true);
                    TeleMarketingDetailSavedHandlers(this, OrderSaveEventArg);
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    if (this._needToClose)
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

        private void cmbSaleBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                int CusID = (int)DataTypeParser.Parse(cmbCustName.SelectedValue, typeof(int), -1);
                if (CusID == -1)
                {
                    txtCusPhone.Text = "";
                    txtContactPhone.Text = "";
                    txtContactName.Text = "";
                }
                DataTable ContactPersonTbl = new TelemarketingDetailBL().GetContactPersonAll(CusID, conn);
                foreach (DataRow contactperson in ContactPersonTbl.Rows)
                {
                    txtContactName.Text = contactperson["ConPersonName"].ToString();
                    txtContactPhone.Text = contactperson["MobilePhone"].ToString();
                    txtCusPhone.Text = contactperson["Phone1"].ToString();
                }
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

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this._township.TownshipID = this.Township;
            DataTable townID = DataUtil.GetDataTableBy(dtTown, "TownshipID", this._township.TownshipID);
            int ID = (int)DataTypeParser.Parse(townID.Rows[0]["TownID"], typeof(int), 0);
            this._township.TownID = ID;
            //frmOrder orderForm = new frmOrder(_teleMarketingDetail.OrderID,Township,CustomerType,CustomerName);
            frmOrder orderForm = new frmOrder(_teleMarketingDetail.OrderID,_teleMarketingDetail.CusID,_township);
            // set call back handler
            orderForm.OrderSavedHandler += new frmOrder.OrderSaveHandler(OrderSave_CallBack);
            UIManager.OpenForm(orderForm);
        }

        private void OrderSave_CallBack(object sender, frmOrder.OrderSaveEventArgs e)
        {
            if (e.OrderID.HasValue) // If order id has been created
            {
                // Set order id to be refered by GovMarketingDetail
                _teleMarketingDetail.OrderID = e.OrderID;
                // No need to close this form after saved
                _needToClose = false;
                // Save 
                Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Need to close this form after saved
            _needToClose = true;
            //if ((int)DataTypeParser.Parse(txtSalePeriod.Text, typeof(int), 0) < 1)
            //{
            //    ToastMessageBox.Show("ရောင်းချသောသက်တမ်းကိုဖြည့်ပါ။", Color.Red);
            //}
            //else if ((int)DataTypeParser.Parse(txtPurchaseQty.Text, typeof(int), 0) < 1)
            //{
            //    ToastMessageBox.Show("အသုံးပြုနေသောအရေအတွက်ကိုဖြည့်ပါ။", Color.Red);
            //}
            //else if ((int)DataTypeParser.Parse(txtPurchasePeriod.Text, typeof(int), 0) < 1)
            //{
            //    ToastMessageBox.Show("အသုံးပြုနေသောကာလကိုဖြည့်ပါ။", Color.Red);
            //}
            // Save Daily Marketing Detail
            Save();
        }

        private void rdoServiceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoServiceYes.Checked == false)
            {
                //dtpRecallDate.Enabled = false;
                dtpSvcDate.Enabled = false;
            }
            else
            {
                dtpSvcDate.Enabled = true;
               // dtpRecallDate.Enabled = true;
            }
        }

        private void txtSalePeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        //private void cmbCusType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int selectedValue = 0;
        //    selectedValue =(int) cmbCusType.SelectedValue;

        //    if (selectedValue == 0 || selectedValue == 3)
        //    {
        //        txtSalePeriod.Visible = false;
        //        cmbSaleBrand.Visible = false;
        //        lblSaleBrand.Visible = false;
        //        lblSalePeriod.Visible = false;
        //        lblSalePeriodMonth.Visible = false;
        //    }
        //    else
        //    {
        //        txtSalePeriod.Visible = true;
        //        cmbSaleBrand.Visible = true;
        //        lblSaleBrand.Visible = true;
        //        lblSalePeriod.Visible = true;
        //        lblSalePeriodMonth.Visible = true;
        //    }
        //}

    }
}
