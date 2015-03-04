/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/09/07 (yyyy/MM/dd)
 * Description: Mobile service plan confirmation (approve | reject)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Sale.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.VC.Marketing;

namespace PTIC.Marketing.MarketingPlan
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmConfirmMobileServicePlan : Form
    {
        #region Events
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Reject();
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
            this.Close();
        }
        #endregion

        #region Private methods
        private void LoadNBindNecessaryData()
        {
            colTownship.DataSource = new TownshipBL().GetAll();            
            colCusType.DataSource = new CusTypeBL().GetAll();
            
            colTownship.DisplayMember = "Township";
            colTownship.ValueMember = "TownshipID";

            colCusType.DisplayMember = "CusTypeName";
            colCusType.ValueMember = "CusTypeID";
        }

        private void LoadNBindPlan()
        {
            dgvMobileServicePlan.DataSource = new MobileServicePlanBL().GetReportedMobileServicePlan();
        }

        private void Confirm()
        {
            List<MobileServicePlan> plans = new List<MobileServicePlan>();
            DataTable tbl = new DataTable();
            tbl = (dgvMobileServicePlan.DataSource as DataTable).Clone();
            foreach (DataGridViewRow row in dgvMobileServicePlan.Rows)
            {
                if ((bool)DataTypeParser.Parse(row.Cells[colSelect.Index].Value, typeof(bool), false))
                {
                    MobileServicePlan plan = new MobileServicePlan()
                    {
                        ID = (int)DataTypeParser.Parse(row.Cells[colMobileServicePlanID.Index].Value, typeof(int), -1),
                        SvcPlanDate = (DateTime)DataTypeParser.Parse(row.Cells[colPlanDate.Index].Value, typeof(DateTime), DateTime.MinValue)
                    };
                    if (plan.SvcPlanDate == DateTime.MinValue)
                    {
                        MessageBox.Show("Please select a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (plan.ID == -1)
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
                if (MessageBox.Show("Are you sure to make selected record(s) confirmed?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.OK)
                {
                    // Save mobile service plan as confirmed
                    try
                    {
                        // Update selected records
                        new MobileServicePlanBL().ConfirmMobileServicePlan(plans);
                        // Reload
                        LoadNBindPlan();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }            
        }

        private void Reject()
        {
            List<MobileServicePlan> plans = new List<MobileServicePlan>();
            DataTable tbl = new DataTable();
            tbl = (dgvMobileServicePlan.DataSource as DataTable).Clone();
            foreach (DataGridViewRow row in dgvMobileServicePlan.Rows)
            {
                if ((bool)DataTypeParser.Parse(row.Cells[colSelect.Index].Value, typeof(bool), false))
                {
                    MobileServicePlan plan = new MobileServicePlan()
                    {
                        ID = (int)DataTypeParser.Parse(row.Cells[colMobileServicePlanID.Index].Value, typeof(int), -1),
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
                if (MessageBox.Show("Are you sure to reject selected record(s) out of mobile service plans?", "Reject",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.OK)
                {
                    // Save mobile service plan as reject
                    try
                    {
                        // Update selected records
                        new MobileServicePlanBL().RejectMobileServicePlanAsRejected(plans);
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
        public frmConfirmMobileServicePlan()
        {
            InitializeComponent();
            // Disable auto-generating columns
            dgvMobileServicePlan.AutoGenerateColumns = false;
            // Load and bind necessary data
            LoadNBindNecessaryData();
            // Load and bind plan
            LoadNBindPlan();
        }        
        #endregion
                                
    }
}
