using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;



namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    public partial class frmCompanyPlanLog : Form
    {
        public frmCompanyPlanLog()
        {
            InitializeComponent();
            LoadCompanyPlanDetails();
            
        }

        private void lblMobileServiceSetup_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmCompanyPlanLog_Load(object sender, EventArgs e)
        {

        }



        #region
        private void LoadCompanyPlanDetails() 
        {
            DataTable approveCompanyPlan = new CompanyPlanBL().SelectCompanyPlanLog();
            dgvMobileServiceLog.AutoGenerateColumns = false;
            dgvMobileServiceLog.DataSource = approveCompanyPlan;
        }
        #endregion

        private void dgvMobileServiceLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colServiceDetail.Index)
            {
                int cmpDtlId = (int) PTIC.VC.Util.DataTypeParser.Parse(dgvMobileServiceLog.Rows[e.RowIndex].Cells[colCompanyPlanDetailID.Index].Value, typeof(int), -1);
                if (cmpDtlId == -1)
                {
                    frmCompanyPlanDetails frmCmpDtl = new frmCompanyPlanDetails();
                    UIManager.OpenForm(frmCmpDtl);
                }
                else 
                {
                    frmCompanyPlanDetails frmCmpDtl = new frmCompanyPlanDetails(cmpDtlId);
                    UIManager.OpenForm(frmCmpDtl);
                }
            }
        }
    }
}
