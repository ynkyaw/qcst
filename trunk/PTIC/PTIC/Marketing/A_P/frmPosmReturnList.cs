using System;using PTIC.Common;
using System.Windows.Forms;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using System.Data.SqlClient;
using PTIC.Common.BL;
using PTIC.Sale.BL;
using PTIC.VC.Marketing.A_P;

namespace PTIC.Marketing.A_P
{
    public partial class frmPosmReturnList : Form
    {
        public frmPosmReturnList()
        {
            InitializeComponent();
            rdoFromDept.Checked = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime FromDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.MinValue);
            DateTime ToDate = (DateTime)DataTypeParser.Parse(dtpToDate.Value, typeof(DateTime), DateTime.MinValue);
            int DeptID = (int)DataTypeParser.Parse(cmbKW_FromDepartment.SelectedValue,typeof(int),0);
            if (rdoFromVen.Checked)
            {
                if (chkDate.Checked && chkDepartment.Checked)
                {
                    SearchByVen(FromDate, ToDate, DeptID);
                }
                else if (chkDepartment.Checked)
                {
                    SearchByVen(DateTime.MinValue, DateTime.MinValue, DeptID);
                }
                else
                {
                    SearchByVen(FromDate, ToDate, 0);
                }
            
            }
            else
            {
                if (chkDate.Checked && chkDepartment.Checked)
                {
                    Search(FromDate, ToDate, DeptID);
                }
                else if (chkDepartment.Checked)
                {
                    Search(DateTime.MinValue, DateTime.MinValue, DeptID);
                }
                else
                {
                    Search(FromDate, ToDate, 0);
                }
            
            }
          
        }

        private void SearchByVen(DateTime FromDate, DateTime ToDate, int VenID)
        {
            dgvReturnDetail.AutoGenerateColumns = false;
            dgvReturnDetail.DataSource = new AP_ReturnDetailBL().GetByDateORVen(FromDate, ToDate, VenID);
        }

        private void Search(DateTime FromDate, DateTime ToDate, int DeptID)
        {
            dgvReturnDetail.AutoGenerateColumns = false;
            dgvReturnDetail.DataSource = new AP_ReturnDetailBL().GetByDateORDept(FromDate, ToDate, DeptID); 
        }

        private void rdoFromDept_CheckedChanged(object sender, EventArgs e)
        {            
            try
            {                
                if (rdoFromDept.Checked)
                {
                    // Department, Ven & Employee
                    cmbKW_FromDepartment.DataSource = new DepartmentBL().GetAll();
                    cmbKW_FromDepartment.ValueMember = "ID";
                    cmbKW_FromDepartment.DisplayMember = "DeptName";
                    //cmbKW_FromDepartment.SelectedValue = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
                }
                else
                {
                    try
                    {
                        //  Vehicle Binding
                        cmbKW_FromDepartment.DataSource = new VehicleBL().GetAll();
                        cmbKW_FromDepartment.DisplayMember = "VenNo";
                        cmbKW_FromDepartment.ValueMember = "VehicleID";
                    }
                    catch (SqlException Sqle)
                    {
                        throw Sqle;
                    }
                }
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Search(DateTime.MinValue, DateTime.MinValue, 0);
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }
        
    }
}
