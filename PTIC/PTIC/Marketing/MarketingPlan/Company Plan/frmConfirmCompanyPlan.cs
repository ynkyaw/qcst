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
using PTIC.Marketing.Entities;
using PTIC.Sale.BL;
using PTIC.Sale.DA;
using PTIC.VC.Marketing;
using PTIC.VC.Util;

namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    public partial class frmConfirmCompanyPlan : Form
    {
        DataTable allTownship = null;
        

        public frmConfirmCompanyPlan()
        {
            InitializeComponent();
            LoadingUnConfirmCompanyPlanList(); 
            
        }

        private void LoadingUnConfirmCompanyPlanList() 
        {
            #region LoadTownship
            allTownship = new TownshipBL().GetAll();
            dgvColTownship.DataSource = allTownship;
            dgvColTownship.DisplayMember = "Township";
            dgvColTownship.ValueMember = "TownshipID";
            #endregion



            dgvCompanyPlan.AutoGenerateColumns = false;
            dgvCompanyPlan.DataSource = new CompanyPlanBL().GetReportedCompanyPlan();
        
        }

        private List<CompanyPlan> GetSelectedCompanyList() 
        {
            List<CompanyPlan> cmpList = new List<CompanyPlan>();
            foreach (DataGridViewRow dgvr in dgvCompanyPlan.Rows)
            {
                if ((dgvr.Cells[colSelect.Index] as DataGridViewCheckBoxCell).Selected)
                {
                    cmpList.Add(new CompanyPlan() 
                    { 
                        Id = (int)DataTypeParser.Parse((dgvr.Cells[colCompanyPlanID.Index] as DataGridViewTextBoxCell).Value, typeof(int), -1) ,
                        TargetedDate = (DateTime)DataTypeParser.Parse((dgvr.Cells[colTargetedDate.Index] as DataGridViewTextBoxCell).Value, typeof(DateTime), DateTime.MinValue) 
                    
                    });
                }
            }
            return cmpList;
        
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<CompanyPlan> cmpList = GetSelectedCompanyList();
            try
            {
                new CompanyPlanBL().ConfirmCompanyPlan(cmpList);
            }
            catch (Exception err) 
            {
            
            }
            LoadingUnConfirmCompanyPlanList();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            List<CompanyPlan> cmpList = GetSelectedCompanyList();
            try
            {
                new CompanyPlanBL().RejectCompanyPlanAsRejected(cmpList);
            }
            catch (Exception err)
            {

            }
            LoadingUnConfirmCompanyPlanList();
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
            this.Close();
        }

    }
}

