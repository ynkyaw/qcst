using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.VC;
using PTIC.Marketing.DA;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.MarketingPlan
{
    public partial class frmDailyMarketingPlanCustomers : Form
    {
        public PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
        int RouteID = -1;
        int Day = -1;
        List<DateTime> EachDaysInWeekend = null;

        public frmDailyMarketingPlanCustomers()
        {
            InitializeComponent();
        }

        public frmDailyMarketingPlanCustomers(PTIC.Marketing.Entities.MarketingPlan _marketingPlan,int RouteID,int Day)
        {
            InitializeComponent();
            this._marketingPlan = _marketingPlan;
            this.RouteID = RouteID;
            this.Day = Day;
            //  dataGridView Auto-Generate Columns false
            dgvCustomers.AutoGenerateColumns = false;
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvCustomers);
        }

        #region Private Methods
        public List<DateTime> getEachdaysinMonth(int Day)
        {
            List<DateTime> lstEachdays = new List<DateTime>();
            int intMonth =this._marketingPlan.PlanDate.Month;
            int intYear = this._marketingPlan.PlanDate.Year;
          
            
           int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);         

            DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
            for (int i = 1; i < intDaysThisMonth + 1; i++)
            {
                if (Day == 1)
                {
                    if (oBeginnngOfThisMonth.AddDays(i-1).DayOfWeek == DayOfWeek.Monday)
                    {
                        lstEachdays.Add(new DateTime(intYear, intMonth, i));
                    }
                }
                else if (Day == 2)
                {
                    if (oBeginnngOfThisMonth.AddDays(i - 1).DayOfWeek == DayOfWeek.Tuesday)
                    {
                        lstEachdays.Add(new DateTime(intYear, intMonth, i));
                    }
                }
                else if (Day == 3)
                {
                  //  DayOfWeek d = oBeginnngOfThisMonth.AddDays(2).DayOfWeek;
                 
                    if (oBeginnngOfThisMonth.AddDays(i-1).DayOfWeek == DayOfWeek.Wednesday)
                    {
                        lstEachdays.Add(new DateTime(intYear, intMonth, i));
                    }
                }
                else if (Day == 4)
                {
                    if (oBeginnngOfThisMonth.AddDays(i - 1).DayOfWeek == DayOfWeek.Thursday)
                    {
                        lstEachdays.Add(new DateTime(intYear, intMonth, i));
                    }
                }
                else if (Day == 5)
                {
                    if (oBeginnngOfThisMonth.AddDays(i - 1).DayOfWeek == DayOfWeek.Friday)
                    {
                        lstEachdays.Add(new DateTime(intYear, intMonth, i));
                    }
                }
                else if (Day == 6)
                {
                    if (oBeginnngOfThisMonth.AddDays(i - 1).DayOfWeek == DayOfWeek.Saturday)
                    {
                        lstEachdays.Add(new DateTime(intYear, intMonth, i));
                    }
                }             
            }
            return lstEachdays;
        }
          
     
        private void LoadNBind()
        {
            EachDaysInWeekend = getEachdaysinMonth(this.Day);
            DataTable DesTable = new InitialMarketingPlanBL().GetCustomerByRouteIDAndCustomerID(-1, -1);
            try
            {
                if (this._marketingPlan.InitialMarketingPlanID != -1)
                {
                    DataTable SavedInitialMarketingPlan = new InitialMarketingPlanBL().GetInitialMarketingPlan(this._marketingPlan.InitialMarketingPlanID,this._marketingPlan.CustomerID);
                    if (SavedInitialMarketingPlan.Rows.Count > 0)
                    {
                        dgvCustomers.DataSource = SavedInitialMarketingPlan;
                        btnSelect.Enabled = false;
                    }
                    else
                    {
                        foreach (DateTime date in EachDaysInWeekend)
                        {                          
                            DataTable dt = new InitialMarketingPlanBL().GetCustomerByRouteIDAndCustomerID(this.RouteID,this._marketingPlan.CustomerID);
                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];
                                DesTable.ImportRow(row);
                            }
                        }
                        dgvCustomers.DataSource = DesTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            // DataTable dt = dgvPlanCustomer.DataSource as DataTable;
            var dgv = dgvCustomers as DataGridView;
            int sup = 0;
            if (dgv == null)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                // insert
                //DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
                    _marketingPlan.CustomerID = (int)DataTypeParser.Parse(row.Cells[colCustomerID.Index].Value, typeof(int), -1);
                    _marketingPlan.PlanDate = (DateTime)DataTypeParser.Parse(row.Cells[colPlanDate.Index].Value, typeof(DateTime), DateTime.Now);
                    //_marketingPlan.EmpID = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.ID, typeof(int), -1);
                    _marketingPlan.InitialMarketingPlanID = (int)DataTypeParser.Parse(this._marketingPlan.InitialMarketingPlanID, typeof(int), -1);
                    _marketingPlan.MarketingType = (int)PTIC.Common.Enum.MarketingType.DailyMarketing;
                    _marketingPlan.Status = (int)PTIC.Common.Enum.FormStatus.Confirmed;
                    if (_marketingPlan.CustomerID == -1)
                    {
                        ToastMessageBox.Show(Resource.errCustomer, Color.Red);
                        return;
                    }
                    else if (_marketingPlan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    }
                    bool SelectCustomer = (bool)DataTypeParser.Parse(row.Cells[colMarketorNot.Index].Value, typeof(bool), false);
                    if (SelectCustomer == true)
                    {
                        sup = MarketingPlanDA.InsertMarketingPlan(_marketingPlan, conn);
                    }
                }

                //// delete
                //DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                //foreach (DataRow row in dvDelete.ToTable().Rows)
                //{
                //    PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
                //    _marketingPlan.ID = (int)DataTypeParser.Parse(row["MarketingPlanID"].ToString(), typeof(int), -1);
                //    sup = MarketingPlanDA.DeleteByID(_marketingPlan, conn);
                //}

                //// update
                //DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                //foreach (DataRow row in dvUpdate.ToTable().Rows)
                //{
                //    PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
                //    _marketingPlan.ID = (int)DataTypeParser.Parse(row["MarketingPlanID"].ToString(), typeof(int), -1);
                //    _marketingPlan.CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                //    _marketingPlan.PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"].ToString(), typeof(DateTime), null);
                //    _marketingPlan.EmpID = (int)DataTypeParser.Parse(row["EmpID"].ToString(), typeof(int), -1);
                //    _marketingPlan.MarketingType = (int)DataTypeParser.Parse(row["MarketingType"].ToString(), typeof(int), -1);
                //    if (_marketingPlan.CustomerID == -1)
                //    {
                //        ToastMessageBox.Show(Resource.errCustomer, Color.Red);
                //        return;
                //    }
                //    else if (_marketingPlan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                //    {
                //        ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                //    }
                //    sup = MarketingPlanDA.UpdateByID(_marketingPlan, conn);
                //}

                if (sup > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBind();
                }
                else
                {
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }

            }
            catch (Exception sqle)
            {
                // show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        private void dgvCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
             var dgv = sender as DataGridView;
              if (dgv != null)
              {
                  // Set row number
                  foreach (DataGridViewRow r in dgv.Rows)
                  {
                      dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                  }
              }

              // Plan Or Not
              foreach (DataGridViewRow row in dgv.Rows)
              {
                  int InitialMarketingPlanID = (int)DataTypeParser.Parse(dgv.Rows[0].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1);

                  if (InitialMarketingPlanID != -1)
                  {
                      row.Cells[colMarketorNot.Index].Value = true;
                  }
              }

              //  CusType and CusClass
              foreach (DataGridViewRow row in dgv.Rows)
              {
                  int CusTypeID = (int)DataTypeParser.Parse(row.Cells[colCusTypeID.Index].Value, typeof(int), -1);
                  int CusClassID = (int)DataTypeParser.Parse(row.Cells[colCusClassID.Index].Value, typeof(int), -1);

                  // Set CustomerClass
                  switch (CusClassID)
                  {
                      case 1:
                          row.Cells[colClass.Index].Value = PTIC.Common.Enum.CustomerClass.A;
                          break;
                      case 2:
                          row.Cells[colClass.Index].Value = PTIC.Common.Enum.CustomerClass.B;
                          break;
                      case 3:
                          row.Cells[colClass.Index].Value = PTIC.Common.Enum.CustomerClass.C;
                          break;
                      default:
                          row.Cells[colClass.Index].Value = string.Empty;
                          break;
                  }

                  // Set PlanDate
                  foreach (DataGridViewRow daterow in dgv.Rows)
                  {
                      daterow.Cells[colPlanDate.Index].Value = EachDaysInWeekend[daterow.Index];
                  }
              }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
