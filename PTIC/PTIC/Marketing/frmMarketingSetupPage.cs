using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.Setup;
using PTIC.VC.Marketing.Setup;
using PITC.VC.Marketing;
using PTIC.Sale.Setup;
using PTIC.VC.Marketing.Telemarketing;
using PTIC.Marketing.Survey;
using PTIC.Marketing.MessageInOut;

namespace PTIC.VC.Marketing
{
    public partial class frmMarketingSetupPage : Form
    {
        public frmMarketingSetupPage()
        {
            InitializeComponent();            
        }

        private void btnAPType_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.OpenForm(typeof(Frm_A_PCategory));
         }

        private void btnAP_Click(object sender, EventArgs e)
        {
            this.Close();
            //UIManager.MdiChildOpenForm(typeof(frmAandP));
            UIManager.OpenForm(typeof(Frm_APMaterial_List));
        }

        private void btnSupplierType_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmSupplierType));
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSupplier));
            this.Close();
        }

        private void btnSurveyQuestion_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyPage));
            this.Close();
        }

        private void btnCompetitor_Click(object sender, EventArgs e)
        {            
            UIManager.MdiChildOpenForm(typeof(PTIC.VC.Marketing.Setup.frmBrandList));
            this.Close();
        }

        private void btnSubCategory_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.OpenForm(typeof(Frm_APSubCategory));
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalCache.is_sale = false;
            UIManager.MdiChildOpenForm(typeof(frmCustomerInformations));
        }

        private void btnCustomerClass_Click(object sender, EventArgs e)
        {           
            frmCustomerClass customerClass = new frmCustomerClass(true);
            UIManager.MdiChildOpenForm(customerClass);
            this.Close();
        }

        private void btnTown_Click(object sender, EventArgs e)
        {
            frmTowns frmTowns = new frmTowns(true);
            UIManager.MdiChildOpenForm(frmTowns);
            this.Close();
        }

        private void btnTownship_Click(object sender, EventArgs e)
        {
            frmTownship frmTownships = new frmTownship(true);
            UIManager.MdiChildOpenForm(frmTownships);
            this.Close();
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            frmTrip frmTrip = new frmTrip(true);
            UIManager.MdiChildOpenForm(frmTrip);
            this.Close();
        }

        private void btnRoute_Click(object sender, EventArgs e)
        {
            frmRoute frmRoute = new frmRoute(true);
            UIManager.MdiChildOpenForm(frmRoute);
            this.Close();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerGroups));
            this.Close();
        }

        private void btnMessageUsers_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMessageUsers));
            this.Close();
        }
       
    }
}
