using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.Entities;
using PTIC.Util;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.VC.Marketing.MobileService;

namespace PTIC.Marketing.MobileService
{
    public partial class frmMobileServicePlanCustomer : Form
    {
        int RouteID = -1;
        int Day = -1;
        MobileServicePlan _mobileServicePlan = new MobileServicePlan();

        #region Constructors
   
        public frmMobileServicePlanCustomer()
        {
            InitializeComponent();
        }

        public frmMobileServicePlanCustomer(int RouteID, MobileServicePlan _mobileServicePlan, int Day):this()
        {
            this.RouteID = RouteID;
            this._mobileServicePlan = _mobileServicePlan;
            this.Day = Day;
            dgvMobileServiceCustomer.AutoGenerateColumns = false;
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvMobileServiceCustomer);
        }
        #endregion

        #region Private Methods
        private void LoadNBind()
        {
            try
            {
               // dgvPlanCustomer.AutoGenerateColumns = false;
                if (this._mobileServicePlan.InitialMobileServicePlanID != -1)
                {
                    DataTable SavedInitialMobileServicePlan = new InitialMobileServicePlanBL().GetInitialMobileServicePlan(this._mobileServicePlan.InitialMobileServicePlanID, this._mobileServicePlan.CustomerID);
                    if (SavedInitialMobileServicePlan.Rows.Count > 0)
                    {
                        dgvMobileServiceCustomer.DataSource = SavedInitialMobileServicePlan;                     
                    }
                    else
                    {
                        //dgvPlanCustomer.AutoGenerateColumns = false;
                        dgvMobileServiceCustomer.DataSource = new InitialMarketingPlanBL().GetCustomerByRouteID(this.RouteID);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

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
                    int InitialMarketingPlanID = (int)DataTypeParser.Parse(dgvMobileServiceCustomer.Rows[0].Cells[colInitialMobileServicePlanID.Index].Value, typeof(int), -1);

                    if (InitialMarketingPlanID != -1)
                    {
                        row.Cells[colMarketorNot.Index].Value = "ရွေးပြီး";
                    }
                }

                foreach (DataGridViewRow intitalRow in dgv.Rows)
                {
                    //this._marketingPlan.InitialMarketingPlanID
                    intitalRow.Cells[colInitialMobileServicePlanID.Index].Value = this._mobileServicePlan.InitialMobileServicePlanID;
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

        private void dgvPlanCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns[colMarketorNot.Index].Index)
                return;

            MobileServicePlan _mobileServicePlan = new MobileServicePlan();
            _mobileServicePlan.CustomerID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colCustomerID.Index].Value, typeof(int), -1);
            _mobileServicePlan.InitialMobileServicePlanID = (int)DataTypeParser.Parse(this._mobileServicePlan.InitialMobileServicePlanID, typeof(int), -1);
            _mobileServicePlan.SvcPlanDate = this._mobileServicePlan.SvcPlanDate;

            frmMobileServicePlanCustomers _frmMobileServicePlanCustomers = new frmMobileServicePlanCustomers(_mobileServicePlan, this.RouteID, this.Day);
            UIManager.OpenForm(_frmMobileServicePlanCustomers);
        }

        private void MarketingLog_Click(object sender, EventArgs e)
        {
            int InitialMobileServicePlanID = (int)DataTypeParser.Parse(dgvMobileServiceCustomer.Rows[0].Cells[colInitialMobileServicePlanID.Index].Value, typeof(int), -1);
          
            frmMobileServiceLog _mobileServiceLog = new frmMobileServiceLog(InitialMobileServicePlanID);
            UIManager.MdiChildOpenForm(_mobileServiceLog);
        }
    }
}
