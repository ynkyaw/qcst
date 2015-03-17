using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    public partial class frmCompanyPlanDetails : Form
    {
        CompanyPlanDetail cmpDetails = new CompanyPlanDetail();
        public frmCompanyPlanDetails()
        {
            InitializeComponent();
        }

        public frmCompanyPlanDetails(int CmpDtlId,int companyId)
        {
            InitializeComponent();
            cmpDetails = new CompanyPlanBL().SelectCompanyPlanDetailsById(CmpDtlId);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteServiceRecord_Click(object sender, EventArgs e)
        {

        }

        #region Private Method
        private void LoadCompanyContactInfo(int companyId) 
        {
            PTIC.Sale.Entities.ContactPerson contact = new Sale.Entities.ContactPerson();
            new PTIC.Sale.BL.ContactPersonBL().GetAll();

        
        }

        #endregion
    }
}
