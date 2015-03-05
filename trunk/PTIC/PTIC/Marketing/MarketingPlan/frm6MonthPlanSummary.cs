using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.Common;


namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frm6MonthPlanSummary : Form
    {
        enum Months {Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec };

        DataTable applanTbl = null;
        DateTime startDate =DateTime.Now;
        DateTime endDate =DateTime.Now;

        public frm6MonthPlanSummary()
        {
            InitializeComponent();
        }

        private void LoadNBind()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                startDate = dtpStartMonth.Value;                
                endDate = dtpEndMonth.Value;

                applanTbl = new A_P_PlanBL().GetAllSummary(conn);

                dgvAPplanSummary.AutoGenerateColumns = false;
                dgvAPplanSummary.DataSource = applanTbl;
                //int startmm = startDate.Month, startyy = startDate.Year;
                //int endmm = endDate.Month, endyy=endDate.Year;
                //if(endyy == startyy)
                //{
                //    int _month=(Int32)endmm-startmm;
                //}

                //TimeSpan duration = endDate-startDate;
                //int dumon = duration.Days / 30;
                //if (dumon > 11)
                //{

                //}
                
                //for (int i = 0; i < 6; i++)
                //{
                //    DateTime currentD = dtpStartMonth.Value.AddMonths(i);                
                //    //applanTbl = new A_P_PlanBL().SelectByDate(currentD, conn);
                    
                //    if (applanTbl.Rows.Count > 0)
                //    {

                //        int apid = Convert.ToInt32(applanTbl.Rows[0][0]);
                //        DataTable aplandetailTbl = new A_P_PlanDetailBL().SelectByAPPanelID(apid, conn);
                //        if (aplandetailTbl.Rows.Count > 0)
                //        {
                //            foreach (DataRow dr in aplandetailTbl.Rows)
                //            {

                //            }
                //        }
                //    }
                //    _APPlanId = Convert.ToInt32(applanTbl.Rows[0]["A_P_PlanID"].ToString());
                //}
                //    applandetailTbl = new A_P_PlanDetailBL().SelectByAPPanelID(_APPlanId, conn);
                //    if (applandetailTbl.Rows.Count == 0)
                //    {
                //        applandetailTbl.Rows.Add(applandetailTbl.NewRow());
                //    }
                //    dgvAPPlanDetail.AutoGenerateColumns = false;
                //    dgvAPPlanDetail.DataSource = applandetailTbl;
                //    calculateTotalAmount();
                //}
                //else
                //{
                //    _APPlanId = -1;
                //    txtSalesPlanAmount.Text = "0";
                //    txtTotalUsageAmount.Text = "0";
                //    txtTotalSalePlanPercent.Text = "0";
                //    applandetailTbl.Clear();
                //    dgvAPPlanDetail.DataSource = applandetailTbl;
                //    if (dgvAPPlanDetail.Rows.Count == 0)
                //    {
                //        DataRow newRow = applandetailTbl.NewRow();
                //        applandetailTbl.Rows.Add(newRow);
                //        this.dgvAPPlanDetail.DataSource = applandetailTbl;
                //    }
                //}

            }
            catch (SqlException ie)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void dtpStartMonth_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView1.Columns.Clear();
            //dataGridView1.DataSource = null;
            //dtpEndMonth.Value = dtpStartMonth.Value.AddMonths(5);
            //DataGridViewRow row = new DataGridViewRow();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("A & P အမည္");
            
            //dt.Columns.Add(String.Format("{0:MMM}", dtpStartMonth.Value).ToString());
            //dt.Columns.Add(String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(1)).ToString());
            //dt.Columns.Add(String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(2)).ToString());
            //dt.Columns.Add(String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(3)).ToString());
            //dt.Columns.Add(String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(4)).ToString());
            //dt.Columns.Add(String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(5)).ToString());
            
            //DataTable dt = new DataTable();
            //dt.Columns.Add("one");
            //dt.Columns.Add("two");

            //for (int i = 0; i < 10; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr[0] = i.ToString();
            //    dr[1] = "dsalkdsfdafs" + (i * i).ToString();
            //    dt.Rows.Add(dr);
            //}

            //this.dataGridView1.DataSource = dt.DefaultView;
            //this.dataGridView1.Columns[0].Width = 150;

            //for (int i = 0; i < 10; i++)
            //{
            //    row.Cells.Add(new DataGridViewTextBoxCell());
            //}

            //lblMonth1.Text = String.Format("{0:MMM}", dtpStartMonth.Value).ToString();
            //lblMonth2.Text = String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(1)).ToString();
            //lblMonth3.Text = String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(2)).ToString();
            //lblMonth4.Text = String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(3)).ToString();
            //lblMonth5.Text = String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(4)).ToString();
            //lblMonth6.Text = String.Format("{0:MMM}", dtpStartMonth.Value.AddMonths(5)).ToString();
        }

        private void frm6MonthPlanSummary_Load(object sender, EventArgs e)
        {
            dgvAPplanSummary.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;
            dtpEndMonth.Value = dtpStartMonth.Value.AddMonths(5);
            LoadNBind();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ContextMenu conmenu = new ContextMenu();
            //    MenuItem item1 = new MenuItem("View Detail Plan");
            //    MenuItem item2 = new MenuItem("Edit Detail Plan");
                
            //    item1.Click += new System.EventHandler(ViewPlan);
            //    conmenu.MenuItems.Add(item1);

            //    item2.Click += new System.EventHandler(EditPlan);
            //    conmenu.MenuItems.Add(item2);

            //    conmenu.Show(dataGridView1, new Point(e.X, e.Y));
            //}
        }

        private void ViewPlan(object sender, EventArgs e)
        {
            //MenuItem item = (MenuItem)sender;

            //frm6MonthPlan frm = new frm6MonthPlan();
            //frm.MdiParent = Program.toyo;
            //frm.Show();
        }

        private void EditPlan(object sender, EventArgs e)
        {
            //MenuItem item = (MenuItem)sender;

            //frm6MonthPlan frm = new frm6MonthPlan();
            //frm.MdiParent = Program.toyo;
            //frm.Show();
        }

        private void dtpEndMonth_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
            this.Close();
        }

        private void dgvAPplanSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        
    }
}
