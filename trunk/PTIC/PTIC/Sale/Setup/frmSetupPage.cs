using System;
using System.Windows.Forms;
using PTIC.Marketing.MessageInOut;
//using WeifenLuo.WinFormsUI.Docking;

namespace PTIC.Sale.Setup
{
    public partial class frmSetupPage : Form
    {
        //public frmBrands frmBrand = null;
        public frmCategories frmCategory = null;
        public frmSubCategories frmSubCategory = null;
        public frmProducts frmProduct = null;

        public frmSetupPage()
        {
            InitializeComponent();             
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmBrandList));
            this.Close();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCategories));
            this.Close();
        }

        private void btnSubCategory_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSubCategories));
            this.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmProducts));
            this.Close();
        }

        private void btnBatterySetting_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmBatterySettings));
            this.Close();
        }

        private void btnTown_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTowns));
            this.Close();
        }

        private void btnSDivision_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSDivisions));
            this.Close();
        }

        private void btnPriceChange_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPriceChanges));
            this.Close();
        }

        private void btnTownship_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTownship));
            this.Close();
        }

        private void btnTransportGate_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTransportGate));
            this.Close();
        }

        private void btnCustomerClass_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerClass));
            this.Close();
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmBank));
            this.Close();
        }

        private void btnSalesCommission_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSaleCommission));
            this.Close();
        }

        private void btnPkgCommission_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPackingDiscount));
            this.Close();
        }

        private void btnCashDiscount_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashDiscount));
            this.Close();
        }

        private void btnTripSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTrip));
            this.Close();
        }

        private void btnSaleCustomer_Click(object sender, EventArgs e)
        {
            PTIC.VC.GlobalCache.is_sale = true;
            UIManager.MdiChildOpenForm(typeof(frmCustomerInformations));
            this.Close();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmRoute));
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSetupPage_Load(object sender, EventArgs e)
        {

        }

        private void btnMessageUsers_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMessageUsers));
            this.Close();
        }
                    
    }
}
