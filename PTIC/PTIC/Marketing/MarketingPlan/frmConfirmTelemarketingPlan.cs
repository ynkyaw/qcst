using System;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using System.Data;
using System.Collections.Generic;

namespace PTIC.VC.Marketing.MarketingPlan
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmConfirmTelemarketingPlan : Form
    {
        #region Events
        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            Confirm();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {                            
            Reject();
        }
        
        #endregion

        #region Private Methods
        private void LoadNBindPlan()
        {            
            // Get and set unconfirmed telemarketing plan
            dgvTeleMarketingPlan.DataSource = new MarketingPlanBL().GetUnconfirmedTelemarketingPlan();
        }

        private void LoadNBindNecessaryData()
        {
            // Get and set customer type
            colCusType.DataSource = new CusTypeBL().GetData();
        }

        private void Reject()
        {
            List<PTIC.Marketing.Entities.MarketingPlan> plans = new List<PTIC.Marketing.Entities.MarketingPlan>();
            DataTable tbl = new DataTable();
            tbl = (dgvTeleMarketingPlan.DataSource as DataTable).Clone();
            foreach (DataGridViewRow row in dgvTeleMarketingPlan.Rows)
            {
                if ((bool)DataTypeParser.Parse(row.Cells[colCheck.Index].Value, typeof(bool), false))
                {
                    PTIC.Marketing.Entities.MarketingPlan plan = new PTIC.Marketing.Entities.MarketingPlan()
                    {
                        ID = (int)DataTypeParser.Parse(row.Cells[colPlanID.Index].Value, typeof(int), -1),                        
                    };                    
                    if (plan.ID == -1)
                    {
                        MessageBox.Show("Selected records cannot be saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        plans.Add(plan);
                }
            }// END of foreach
            if (plans.Count > 0)
            {
                if (MessageBox.Show("Are you sure to reject selected record(s) out of telemarketing plans?", "Reject",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.OK)
                {
                    // Save telemarketing plan as reject
                    try
                    {
                        // Update selected records
                        new MarketingPlanBL().UpdateAsRejected(plans);
                        // Reload
                        LoadNBindPlan();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }                
                }
            }            
        }

        private void Confirm()
        {
            List<PTIC.Marketing.Entities.MarketingPlan> plans = new List<PTIC.Marketing.Entities.MarketingPlan>();
            DataTable tbl = new DataTable();
            tbl = (dgvTeleMarketingPlan.DataSource as DataTable).Clone();            
            foreach (DataGridViewRow row in dgvTeleMarketingPlan.Rows)
            {
                if ((bool)DataTypeParser.Parse(row.Cells[colCheck.Index].Value, typeof(bool), false))
                {
                    PTIC.Marketing.Entities.MarketingPlan plan = new PTIC.Marketing.Entities.MarketingPlan()
                    {
                        ID = (int)DataTypeParser.Parse(row.Cells[colPlanID.Index].Value, typeof(int), -1),
                        PlanDate = (DateTime)DataTypeParser.Parse(row.Cells[colPlanDate.Index].Value, typeof(DateTime), DateTime.MinValue)
                    };
                    if (plan.PlanDate == DateTime.MinValue)
                    {
                        MessageBox.Show("Please select a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if(plan.ID == -1)
                    {
                        MessageBox.Show("Selected records cannot be saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        plans.Add(plan);
                }
            }// END of foreach
            if(plans.Count > 0)
            {
                if (MessageBox.Show("Are you sure to make selected record(s) confirmed?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.OK)
                {
                    // Save telemarketing plan as confirmed
                    try
                    {
                        // Update selected records
                        new MarketingPlanBL().UpdateAsConfirmed(plans);
                        // Reload
                        LoadNBindPlan();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }      
                }
            }            
        }
        #endregion

        #region Constructors
        public frmConfirmTelemarketingPlan()
        {
            InitializeComponent();
            // Disable auto-generating columns
            dgvTeleMarketingPlan.AutoGenerateColumns = false;
            // Set field mapping
            colCusType.DisplayMember = "CusTypeName";
            colCusType.ValueMember = "CusTypeID";
            // Load and bind necessary data
            LoadNBindNecessaryData();
            // Load and bind data
            LoadNBindPlan();
        }
        #endregion

        
                
    }
}
