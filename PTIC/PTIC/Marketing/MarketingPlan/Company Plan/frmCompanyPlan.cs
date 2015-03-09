using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Marketing.DA;
using PTIC.Util;
using PTIC.Sale.BL;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    public partial class frmCompanyPlan : Form
    {

        /**
         * Test Commit to Google code SVN
         * */

        DataTable allTownship = null;
        DataTable allCustomer = null;
        public frmCompanyPlan()
        {
            InitializeComponent();
            LoadingDataGrid();
            LoadCompanyPlan();
            
        }


        #region 
        private void LoadingDataGrid()
        {

            #region LoadTownship
            allTownship = new TownshipBL().GetAll();
            dgvColTownship.DataSource = allTownship;
            dgvColTownship.DisplayMember = "Township";
            dgvColTownship.ValueMember = "TownshipID";
            #endregion

            #region LoadAllCustomer

            allCustomer = new CustomerBL().GetAllCustomerByCustomerType("3");
            dgvColCusName.DataSource = allCustomer;
            dgvColCusName.DisplayMember = "CusName";
            dgvColCusName.ValueMember = "ID";

            #endregion
        }

        private void LoadCompanyPlan() 
        {
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            DataTable CompanyPlanTbl = new CompanyPlanBL().SelectCompanyPlanUnConfirmedList();


            dgvCompanyPlan.AutoGenerateColumns = false; // Autogenerate Columns False
            dgvCompanyPlan.DataSource = CompanyPlanTbl;
        
        } 
        #endregion


        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            if (dgvCompanyPlan == null) return;

            DataUtil.AddNewRow(dgvCompanyPlan.DataSource as DataTable);
        }

        private void dgvCompanyPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

        }

        private void dgvCompanyPlan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvColTownship.Index)
            {
                if (dgvCompanyPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    int townshipId = (int)DataTypeParser.Parse(dgvCompanyPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, typeof(int), -1);
                    DataRow[] dr = allCustomer.Select(string.Format("townshipid={0}", townshipId));
                    if (dr.Length > 0)
                    {
                        if (dgvCompanyPlan.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                        {
                            int custId = (int)DataTypeParser.Parse(dgvCompanyPlan.Rows[e.RowIndex].Cells[dgvColCusName.Index].Value, typeof(int), -1);
                            dgvCompanyPlan.Rows[e.RowIndex].Cells[dgvColCusName.Index].Value = DBNull.Value;
                            (dgvCompanyPlan.Rows[e.RowIndex].Cells[dgvColCusName.Index] as DataGridViewComboBoxCell).DataSource = dr.CopyToDataTable();
                            (dgvCompanyPlan.Rows[e.RowIndex].Cells[dgvColCusName.Index] as DataGridViewComboBoxCell).DisplayMember = "CusName";
                            (dgvCompanyPlan.Rows[e.RowIndex].Cells[dgvColCusName.Index] as DataGridViewComboBoxCell).ValueMember = "ID";
                            if (dr.CopyToDataTable().Select("ID=" + custId).Length > 0)
                            {
                                dgvCompanyPlan.Rows[e.RowIndex].Cells[dgvColCusName.Index].Value = custId;
                            }
                            
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<CompanyPlan> companyPlanList = new List<CompanyPlan> ();
            foreach (DataGridViewRow dgvr in dgvCompanyPlan.Rows) 
            {
                string companyId = dgvr.Cells[colCompanyPlanID.Index].Value+string.Empty;
                if (companyId.Equals(string.Empty))
                {
                    CompanyPlan cmpPlan = new CompanyPlan();
                    cmpPlan.CreatedDate = DateTime.Now;
                    cmpPlan.TargetedDate = (DateTime)DataTypeParser.Parse(dgvr.Cells[dgvColTargetedDate.Index].Value, typeof(DateTime), null);
                    cmpPlan.IsConfirmed = false;
                    cmpPlan.CompanyPanNo = (string) DataTypeParser.Parse(dgvr.Cells[dgvCompanyPlanNo.Index].Value,typeof(string),string.Empty);
                    cmpPlan.IsDeleted = false;
                    cmpPlan.LastModifiedDate = DateTime.Now;
                    cmpPlan.Status = 0;
                    cmpPlan.TownshipID = (int)DataTypeParser.Parse(dgvr.Cells[dgvColTownship.Index].Value, typeof(int), -1);
                    cmpPlan.CustomerID = (int)DataTypeParser.Parse(dgvr.Cells[dgvColCusName.Index].Value, typeof(int), -1);

                    if (cmpPlan.TownshipID == -1)
                    {
                      MessageBox.Show(string.Format("Choose Township for new inserted Complan Plan at Row {0} of Data List!",dgvr.Index));
                      break;
                    }
                    else if(cmpPlan.CustomerID==-1)
                    {
                        MessageBox.Show(string.Format("Choose Customer for new inserted Complan Plan at Row {0} of Data List!", dgvr.Index));
                        break;
                    }
                    else if (!cmpPlan.TargetedDate.HasValue)
                    {
                        MessageBox.Show(string.Format("Choose Targeted Date for new inserted Complan Plan at Row {0} of Data List!", dgvr.Index));
                        break;
                    }
                    else 
                    {
                       companyPlanList.Add(cmpPlan);

                    }
                        
                }

                    
                    
                    
                    
                
            }

            try
            {

                new CompanyPlanBL().Insert(companyPlanList);
            }
            catch (Exception err)
            {
                MessageBox.Show("Failed To Insert New Data!\n Please Contact your network administrator!\n" + err.Message);
            }

        }

        private void dgvCompanyPlan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            DataTable CompanyPlanTbl = new CompanyPlanBL().SelectCompanyPlanUnConfirmedListByDateRange(dtpStartDate.Value,dtpEndDate.Value);


            dgvCompanyPlan.AutoGenerateColumns = false; // Autogenerate Columns False
            dgvCompanyPlan.DataSource = CompanyPlanTbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCompanyPlan();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value) 
            {
                dtpEndDate.Value = dtpStartDate.Value;
            }
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
