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

        public frmCompanyPlanDetails()
        {
            InitializeComponent();
            rdoNoOrder.Checked = true;
            LoadCombo();
            
        }


        public frmCompanyPlanDetails(int companyPlanId,int companyId)
        {
            InitializeComponent();
            rdoNoOrder.Checked = true;
            this.companyPlanId = companyPlanId;
            LoadCombo();
            cmbCompany.SelectedValue = companyId;
        }

        public frmCompanyPlanDetails(int CmpDtlId,int companyId,int companyPlanId)
        {
            InitializeComponent();
            rdoNoOrder.Checked = true;
            cmpDetails = new CompanyPlanBL().SelectCompanyPlanDetailsById(CmpDtlId);
            this.companyPlanId = companyPlanId;
            LoadCombo();
            LoadCompanyDetails(cmpDetails);
            cmbCompany.SelectedValue = companyId;
            btnSave.Enabled = false;
            btnDeleteServiceRecord.Enabled = true;
            
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

            cmpDtl.HasService = checkBox1.Checked;
            cmpDtl.ServicedDate = dtpServiceDate.Value;

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
            DialogResult dr = MessageBox.Show("Is there any order for this company?", "Has Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Yes))
            {
                int custId = (int)cmbEmp.SelectedValue;
                PTIC.Sale.Order.frmOrder orderForm = new PTIC.Sale.Order.frmOrder();
                // set call back handler
                orderForm.OrderSavedHandler += new Sale.Order.frmOrder.OrderSaveHandler(orderForm_OrderSavedHandler);
                UIManager.OpenForm(orderForm);
            }
            else 
            {
                Save();
            }

            
            

        }

        private void Save() 
        {
            cmpDetails = GetCompanyDetailsFromUI();
            if (cmpDetails.CompanyPlanDetailId == 0)
            {

                new CompanyPlanBL().InsertCompanyPlanDetails(cmpDetails);
                MessageBox.Show("Success!");
                this.Close();
            }
        }

        private void btnDeleteServiceRecord_Click(object sender, EventArgs e)
        {

            new CompanyPlanBL().DeleteCompanyPlanDetails(cmpDetails);
            MessageBox.Show("Success!");
            this.Close();
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

            cmbPrepareBy.DataSource = empDt.Copy();
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
            checkBox1.Checked = cmpDtl.HasService;
            if(cmpDtl.HasService)
                dtpServiceDate.Value = cmpDtl.ServicedDate;

        
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

        void orderForm_OrderSavedHandler(object sender, Sale.Order.frmOrder.OrderSaveEventArgs e)
        {
            rdoOrder.Checked = true;
            cmbCompany.Enabled = false;
            Save();
        }

        private void dtpVisitDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpServiceDate.Value < dtpVisitDate.Value) 
            {
                dtpServiceDate.Value = dtpVisitDate.Value;
            }
            dtpServiceDate.MinDate = dtpVisitDate.Value;
        }

        private void dtpArrived_ValueChanged(object sender, EventArgs e)
        {
            if (dtpArrived.Value.TimeOfDay > dtpDepature.Value.TimeOfDay) 
            {
                dtpDepature.Value = dtpArrived.Value;
            } 
        }

        private void dtpDepature_ValueChanged(object sender, EventArgs e)
        {
            if (dtpArrived.Value.TimeOfDay > dtpDepature.Value.TimeOfDay)
            {
                dtpArrived.Value = dtpDepature.Value;
            } 
        }

        private void frmCompanyPlanDetails_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dtpServiceDate.Enabled = checkBox1.Checked;
        }
    }
}
