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

        DataTable allTownship = null;
        DataTable allCustomer = null;
        public frmCompanyPlan()
        {
            InitializeComponent();
            LoadingDataGrid();
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            DataTable  mobileserviceplanTbl = new MobileServicePlanBL().GetAll();

            dgvMobileServicePlan.AutoGenerateColumns = false; // Autogenerate Columns False
            dgvMobileServicePlan.DataSource = mobileserviceplanTbl;


        }


        #region 
        public void LoadingDataGrid()
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


        #endregion


        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            if (dgvMobileServicePlan == null) return;

            DataUtil.AddNewRow(dgvMobileServicePlan.DataSource as DataTable);
        }

        private void dgvMobileServicePlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

        }

        private void dgvMobileServicePlan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvColTownship.Index)
            {
                int townshipId = (int)DataTypeParser.Parse(dgvMobileServicePlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, typeof(int), -1);
                DataRow[] dr = allCustomer.Select(string.Format("townshipid={0}", townshipId));
                if (dr.Length > 0)
                {
                    dgvColCusName.DataSource = dr.CopyToDataTable();
                    dgvColCusName.DisplayMember = "CusName";
                    dgvColCusName.ValueMember = "ID";
                }
            }
        }
    }
}
