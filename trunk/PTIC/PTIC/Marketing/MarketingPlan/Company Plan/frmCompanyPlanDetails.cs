using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    public partial class frmCompanyPlanDetails : Form
    {
        CompanyPlanDetail cmpDetails = new CompanyPlanDetail();
        public frmCompanyPlanDetails()
        {
            InitializeComponent();
            LoadCombo();
        }

        public frmCompanyPlanDetails(int CmpDtlId,int companyId)
        {
            InitializeComponent();
            cmpDetails = new CompanyPlanBL().SelectCompanyPlanDetailsById(CmpDtlId);
            dgvOwnBrand.AutoGenerateColumns = false;
            dgvOtherBrand.AutoGenerateColumns = false;
            LoadCombo();
            LoadCompanyDetails(cmpDetails);
            cmbCompany.SelectedValue = companyId;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteServiceRecord_Click(object sender, EventArgs e)
        {

        }

        #region Private Method
        private void LoadCompanyContactInfo(int companyId) 
        {

            PTIC.Sale.Entities.ContactPerson contact = new Sale.BL.ContactPersonBL().GetContactInfoByCustomerId(companyId);
            txtContactPerson.Text = contact.ContactPersonName;
            txtMobile.Text = contact.MobilePhone;
        }

        private void LoadCombo()
        {
            cmbCompany.DataSource = new Sale.BL.CustomerBL().GetAllCustomerByCustomerType("3");
            cmbCompany.DisplayMember = "CusName";
            cmbCompany.ValueMember = "ID";

            DataTable empDt = new PTIC.Common.BL.EmployeeBL().GetAll();

            cmbEmp.DataSource = empDt;
            cmbEmp.DisplayMember = "EmpName";
            cmbEmp.ValueMember = "EmployeeID";

            cmbPrepareBy.DataSource = empDt;
            cmbPrepareBy.DisplayMember = "EmpName";
            cmbPrepareBy.ValueMember = "EmpName";

            cmbCheckedBy.DataSource = empDt;
            cmbCheckedBy.DisplayMember = "EmpName";
            cmbCheckedBy.ValueMember = "EmpName";


            cmbApprovedBy.DataSource = empDt;
            cmbApprovedBy.DisplayMember = "EmpName";
            cmbApprovedBy.ValueMember = "EmpName";





            dgvOwnBrand.DataSource = new Sale.BL.BrandBL().SelectUsedOwnBrandByCompanyPlanDtlId(cmpDetails.CompanyPlanDetailId);

            dgvOtherBrand.DataSource = new Sale.BL.BrandBL().SelectUsedOtherBrandByCompanyPlanDtlId(cmpDetails.CompanyPlanDetailId);
            




            
            

            


            
        }

        private void LoadCompanyDetails(CompanyPlanDetail cmpDtl)
        {
            txtCompanyCarCount.Text = cmpDtl.CarCountInCompany + string.Empty;
            txtMainTopic.Text = cmpDtl.MainTopic+ string.Empty;
            txtToyo.Text = cmpDtl.ToyoComment;
            txtOtherBrandCondition.Text = cmpDtl.ConditionOfOtherBrands;
            rdoOrder.Checked = cmpDtl.HasOrder;
            rdoNoOrder.Checked = !rdoOrder.Checked;




        
        }

        #endregion

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb.SelectedIndex != -1 && cmb.SelectedValue != null) 
            {
                int selectedCustId = (int)cmb.SelectedValue;
                LoadCompanyContactInfo(selectedCustId);

                
            }
        }

        private void dgvOwnBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelected.Index)
            {
                DataGridViewCheckBoxCell cell = dgvOwnBrand.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                cell.Value = !((bool)cell.Value);
            }
        }

        private void dgvOtherBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelected.Index)
            {
                DataGridViewCheckBoxCell cell = dgvOwnBrand.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                cell.Value = !((bool)cell.Value);
            }

        }
    }
}
