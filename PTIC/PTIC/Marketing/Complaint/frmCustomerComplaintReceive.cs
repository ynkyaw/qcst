using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.BL;
using PTIC.Util;
using PTIC.Sale.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.VC;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.Complaint
{
    public partial class frmCustomerComplaintReceive : Form
    {
        List<ProductInComplaintReceive> ProductInComplaintReceiveList = null;

        public frmCustomerComplaintReceive()
        {
            InitializeComponent();
            dtpInformDate.MaxDate = DateTime.Now;
            dtpReceivedDate.MaxDate = DateTime.Now;
            cmbInfoSys.SelectedIndex = 0;
            cmbInfoSys.Select();
            cmbInfoSys.Focus();
            cmbReceivedViaBy.SelectedIndex = 0;
            // LoadNBind Required Data
            LoadNBind();
        }


        #region Private Methods
        private void LoadNBind()
        {
            //  Bind Employee From Sales && Marketing
            DataTable dtEmployee = new EmployeeBL().GetAllByRank();

            List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> SalesDept = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
            Tuple<string, object> MktDept = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
            queryBuilder.Add(SalesDept);
            queryBuilder.Add(MktDept);
            DataTable dt = DataUtil.GetDataTableByOR(dtEmployee, queryBuilder);

            cmbAccepter.DataSource = dt;
            cmbAccepter.DisplayMember = "EmpName";
            cmbAccepter.ValueMember = "EmployeeID";

            cmbCheckedBy.DataSource = dt.Copy();
            cmbCheckedBy.DisplayMember = "EmpName";
            cmbCheckedBy.ValueMember = "EmployeeID";

            cmbReceivedBy.DataSource = dt;
            cmbReceivedBy.DisplayMember = "EmpName";
            cmbReceivedBy.ValueMember = "EmployeeID";

            cmbRepairedBy.DataSource = dtEmployee.Copy();
            cmbRepairedBy.DisplayMember = "EmpName";
            cmbRepairedBy.ValueMember = "EmployeeID";

            //  Bind Customer
            DataTable dtCustomer = new CustomerBL().GetAllCustomer();
            cmbShop.DataSource = dtCustomer;
            cmbShop.DisplayMember = "CusName";
            cmbShop.ValueMember = "CustomerID";
        }

        private void Save()
        {
            int? affectedRows = null;
            ComplaintReceiveBL complaintReceiveSaver = null;
            try
            {
                complaintReceiveSaver = new ComplaintReceiveBL();
                //  Complaint Receive Data Prepared to Save
                ComplaintReceive _ComplaintReceive = new ComplaintReceive();
                _ComplaintReceive.ReceivedDate = (DateTime)DataTypeParser.Parse(dtpReceivedDate.Value, typeof(DateTime), DateTime.Now);
                _ComplaintReceive.ReceivedVia = (Common.Enum.ReceivedVia)cmbInfoSys.SelectedIndex;
                _ComplaintReceive.ReceivedViaBy = (string)DataTypeParser.Parse(cmbReceivedViaBy.Text, typeof(string), null);
                _ComplaintReceive.MsgNo = (string)DataTypeParser.Parse(txtNo.Text, typeof(string), null);                
                _ComplaintReceive.Sender = string.IsNullOrEmpty(txtInformer.Text) ? null : txtInformer.Text;
                _ComplaintReceive.ReceiverID = (int)DataTypeParser.Parse(cmbAccepter.SelectedValue, typeof(int), -1);
                _ComplaintReceive.ServiceNo = (string)DataTypeParser.Parse(txtSerialNo.Text, typeof(string), null);
                _ComplaintReceive.UsageNature = (string)DataTypeParser.Parse(txtUsePlace.Text, typeof(string), null);
                _ComplaintReceive.UsedPeriod = (string)DataTypeParser.Parse(txtPeriod.Text, typeof(string), null);
                _ComplaintReceive.OtherCustomer = (string)DataTypeParser.Parse(txtShop.Text, typeof(string), null);
                _ComplaintReceive.UsingHour = (string)DataTypeParser.Parse(txtElectricTime.Text, typeof(string), null);
                _ComplaintReceive.OutletCustomerID = (int?)DataTypeParser.Parse(cmbShop.SelectedValue, typeof(int), null);
                if (rdoFinished.Checked)
                {
                    _ComplaintReceive.IsChecked = (bool)DataTypeParser.Parse(rdoFinished.Checked, typeof(bool), false);
                }
                else
                {
                    _ComplaintReceive.IsChecked = (bool)DataTypeParser.Parse(rdoFinished.Checked, typeof(bool), false);
                }
                _ComplaintReceive.ActionByReseller = (string)DataTypeParser.Parse(txtResellerTask.Text, typeof(string), null);
                _ComplaintReceive.ResellerRemark = (string)DataTypeParser.Parse(txtResellerSpeech.Text, typeof(string), null);
                _ComplaintReceive.Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null);
                _ComplaintReceive.ReceivedBy = (int)DataTypeParser.Parse(cmbReceivedBy.SelectedValue, typeof(int), -1);
                _ComplaintReceive.RepairedBy = (int?)DataTypeParser.Parse(cmbRepairedBy.SelectedValue, typeof(int), null);
                _ComplaintReceive.CheckedBy = (int?)DataTypeParser.Parse(cmbCheckedBy.SelectedValue, typeof(int), null);

                // Check field validation and if successful , save it
                affectedRows = complaintReceiveSaver.AddComplaintReceived(_ComplaintReceive, ProductInComplaintReceiveList);
                if (!complaintReceiveSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(complaintReceiveSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                            err.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }               
            }
        }
        #endregion


        #region Events

        private void btnProductSelect_Click(object sender, EventArgs e)
        {
            //Open ProductInComplaint lookup form
            frmProductsPicker productsPicker = new frmProductsPicker();
            productsPicker.ProductSelectedHandler += new frmProductsPicker.ProductSelectionHandler(employeeSelection_CallBack);
            //Set call back handler
            UIManager.OpenForm(productsPicker);
            //UIManager.OpenForm(typeof(frmProductsPcker));
        }

        private void employeeSelection_CallBack(object sender, frmProductsPicker.ProductSelectionEventArgs args)
        {
            if (args.ProductsInComplaintReceive == null)
                return;
            ProductInComplaintReceiveList = new List<ProductInComplaintReceive>();

            foreach (ProductInComplaintReceive insertProductInComplaintReceive in args.ProductsInComplaintReceive)
            {
                //if (insertProductInComplaintReceive.ID == -1)
                ProductInComplaintReceiveList.Add(insertProductInComplaintReceive);
            }
        }


        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOther.Checked)
            {
                cmbShop.Visible = false;
                txtShop.Visible = true;
            }
        }

        private void rdoOutlet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOutlet.Checked)
            {
                cmbShop.Visible = true;
                txtShop.Visible = false;
            }
        }


        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmComplaintPage));
            this.Close();
        }

    }
}
