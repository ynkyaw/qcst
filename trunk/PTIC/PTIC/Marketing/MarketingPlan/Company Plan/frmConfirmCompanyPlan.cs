using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Marketing.DA;
using PTIC.Sale.BL;
using PTIC.Sale.DA;

namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    public partial class frmConfirmCompanyPlan : Form
    {
        DataTable allTownship = null;
        DataTable allCustomer = null;

        public frmConfirmCompanyPlan()
        {
            InitializeComponent();

            #region LoadTownship
            allTownship = new TownshipBL().GetAll();
            dgvColTownship.DataSource = allTownship;
            dgvColTownship.DisplayMember = "Township";
            dgvColTownship.ValueMember = "TownshipID";
            #endregion

            

            dgvCompanyPlan.AutoGenerateColumns = false;
            dgvCompanyPlan.DataSource = new CompanyPlanBL().GetReportedCompanyPlan();
        }

        private void LoadingUnConfirmCompanyPlanList() 
        {
            
        
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

        }

    }
}

