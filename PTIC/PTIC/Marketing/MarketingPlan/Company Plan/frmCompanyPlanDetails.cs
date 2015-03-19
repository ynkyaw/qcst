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
        CompanyPlanDetail cmpDetails = new CompanyPlanDetail() { CompanyPlanDetailId =0};
        int companyPlanId = 0;
        public frmCompanyPlanDetails(int companyPlanId)
        {
            InitializeComponent();
            this.companyPlanId = companyPlanId;
            LoadCombo();
        }

        public frmCompanyPlanDetails(int CmpDtlId,int companyId,int companyPlanId)
        {
            InitializeComponent();
            cmpDetails = new CompanyPlanBL().SelectCompanyPlanDetailsById(CmpDtlId);
            this.companyPlanId = companyPlanId;
            LoadCombo();
            LoadCompanyDetails(cmpDetails);
            cmbCompany.SelectedValue = companyId;
            
        }

        private CompanyPlanDetail GetCompanyDetailsFromUI() 
        {
            CompanyPlanDetail cmpDtl = new CompanyPlanDetail();

            cmpDtl.CompanyPlanDetailId = cmpDetails.CompanyPlanDetailId;
            cmpDtl.ToyoComment = txtToyo.Text;
            cmpDtl.ConditionOfOtherBrands = txtOtherBrandCondition.Text;
            cmpDtl.HasOrder = rdoOrder.Checked;
            cmpDtl.TargetedEmpId = (int)cmbEmp.SelectedValue;
            cmpDtl.ApprovedBy = (string)cmbApprovedBy.SelectedValue;
            cmpDtl.CheckedBy = (string)cmbCheckedBy.SelectedValue;
            cmpDtl.PreparedBy = (string)cmbPrepareBy.SelectedValue;
            cmpDtl.ArrivedTime = dtpArrived.Value;
            cmpDtl.DepatureTime = dtpDepature.Value;
            cmpDtl.ArrivedDate = dtpVisitDate.Value;



            cmpDtl.CarCountInCompany = int.Parse(txtCompanyCarCount.Text);
            cmpDtl.CompanyPlanId = companyPlanId;
            cmpDtl.MainTopic = txtMainTopic.Text;
            cmpDtl.OwnBrandList = new List<int>();

            foreach (DataGridViewRow dr in dgvOwnBrand.Rows)
            {
                if ((bool)dr.Cells[colSelected.Index].Value)
                {
                    cmpDtl.OwnBrandList.Add((int)dr.Cells[colBrandId.Index].Value);
                }
            }

            cmpDtl.OtherBrandList = new List<int>();

            foreach (DataGridViewRow dr in dgvOtherBrand.Rows)
            {
                if ((bool)dr.Cells[colOtherSelected.Index].Value)
                {
                    cmpDtl.OtherBrandList.Add((int)dr.Cells[colOtherBrandId.Index].Value);
                }
            }
            return cmpDtl;
        
        }  


        private void btnSave_Click(object sender, EventArgs e)
        {
            cmpDetails = GetCompanyDetailsFromUI();
            if (cmpDetails.CompanyPlanDetailId == 0)
            {



            }
            else 
            {
            
            }

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

            cmbCheckedBy.DataSource = empDt.Copy();
            cmbCheckedBy.DisplayMember = "EmpName";
            cmbCheckedBy.ValueMember = "EmpName";


            cmbApprovedBy.DataSource = empDt.Copy();
            cmbApprovedBy.DisplayMember = "EmpName";
            cmbApprovedBy.ValueMember = "EmpName";



            dgvOwnBrand.AutoGenerateColumns = false;
            dgvOtherBrand.AutoGenerateColumns = false;

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
            cmbEmp.SelectedValue = cmpDetails.TargetedEmpId;
            cmbApprovedBy.SelectedValue = cmpDetails.ApprovedBy;
            cmbCheckedBy.SelectedValue = cmpDetails.CheckedBy;
            cmbPrepareBy.SelectedValue = cmpDetails.PreparedBy;

            dtpArrived.Value = cmpDtl.ArrivedTime;
            dtpDepature.Value = cmpDtl.DepatureTime;
            dtpVisitDate.Value = cmpDtl.ArrivedDate;


        
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
                DataGridViewCheckBoxCell cell = dgvOtherBrand.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                cell.Value = !((bool)cell.Value);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
