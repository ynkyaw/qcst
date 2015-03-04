using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.VC.Marketing;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Marketing.DA;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.MarketingPlan
{
    public partial class frmDailyMarketingPlanCustomer : Form
    {
        int RouteID = -1;
        int Day = -1;
        bool IsPlanned = false;
        Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
     
        #region Constructors
        public frmDailyMarketingPlanCustomer()
        {
            InitializeComponent();       
        }

        public frmDailyMarketingPlanCustomer(int RouteID,PTIC.Marketing.Entities.MarketingPlan _marketingPlan,int Day)
            : this()
        {
            this.RouteID = RouteID;
            this._marketingPlan = _marketingPlan;
            this.Day = Day;
            //  DataGridview Auto-Generate Columns false
            dgvPlanCustomer.AutoGenerateColumns = false;
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvPlanCustomer);
        }
      
        #endregion

        #region Private Methods
        private void LoadNBind()
        {
            try
            {
                if (this._marketingPlan.InitialMarketingPlanID != -1)
                {
                    DataTable SavedInitialMarketingPlan = new InitialMarketingPlanBL().GetInitialMarketingPlan(this._marketingPlan.InitialMarketingPlanID,this._marketingPlan.CustomerID);
                    if (SavedInitialMarketingPlan.Rows.Count > 0)
                    {
                        dgvPlanCustomer.DataSource = SavedInitialMarketingPlan;
                        //IsPlanned = true;
                        //dgvPlanCustomer.DataSource = new InitialMarketingPlanBL().GetCustomerByRouteID(this.RouteID);

                    }
                    else
                    {
                        dgvPlanCustomer.DataSource = new InitialMarketingPlanBL().GetCustomerByRouteID(this.RouteID);
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
            var dgv = dgvPlanCustomer as DataGridView;
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
                    _marketingPlan.PlanDate = (DateTime)DataTypeParser.Parse(this._marketingPlan.PlanDate, typeof(DateTime), DateTime.Now);
                    _marketingPlan.EmpID = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.ID, typeof(int), -1);
                    _marketingPlan.InitialMarketingPlanID = (int)DataTypeParser.Parse(this._marketingPlan.InitialMarketingPlanID, typeof(int), -1);
                    _marketingPlan.MarketingType = 0;
                    if (_marketingPlan.CustomerID == -1)
                    {
                        ToastMessageBox.Show(Resource.errCustomer, Color.Red);
                        return;
                    }
                    else if (_marketingPlan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    }
                    bool SelectCustomer = (bool)DataTypeParser.Parse(row.Cells[colMarketorNot.Index].Value,typeof(bool),false);
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


        #region Events
        private void dgvPlanCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }

                // Plan Or Not
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    int InitialMarketingPlanID = (int)DataTypeParser.Parse(dgvPlanCustomer.Rows[0].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1);

                    if (InitialMarketingPlanID != -1)
                    {
                        row.Cells[colMarketorNot.Index].Value = "ရွေးပြီး";
                    }
                }

                foreach (DataGridViewRow intitalRow in dgv.Rows)
                {
                    //this._marketingPlan.InitialMarketingPlanID
                    intitalRow.Cells[colInitialMarketingPlanID.Index].Value = this._marketingPlan.InitialMarketingPlanID;
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
                }
            }
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

        private void MarketingLog_Click(object sender, EventArgs e)
        {
            int InitialMarketingPlanID = (int)DataTypeParser.Parse(dgvPlanCustomer.Rows[0].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1);
        
            frmDailyMarketingLog _dailyMarketingLog = new frmDailyMarketingLog(InitialMarketingPlanID);
            UIManager.MdiChildOpenForm(_dailyMarketingLog);
        }

        private void dgvPlanCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns[colMarketorNot.Index].Index)
                return;

            PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
            _marketingPlan.CustomerID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colCustomerID.Index].Value, typeof(int), -1);
            _marketingPlan.InitialMarketingPlanID = (int)DataTypeParser.Parse(this._marketingPlan.InitialMarketingPlanID, typeof(int), -1);
            _marketingPlan.PlanDate = this._marketingPlan.PlanDate;

            if (_marketingPlan.CustomerID == -1)
            {
                MessageBox.Show("သွားမည့်လမ်းကြောင်းတွင် Customer မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MarketingLog.Enabled = false;
                return;
            }
           
            frmDailyMarketingPlanCustomers _frmDailyMarketingPlanCustomers = new frmDailyMarketingPlanCustomers(_marketingPlan,this.RouteID,this.Day);
            UIManager.OpenForm(_frmDailyMarketingPlanCustomers);
        }
    }

}
