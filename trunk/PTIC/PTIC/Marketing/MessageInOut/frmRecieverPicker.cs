using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Common.BL;
using PTIC.VC;
using PTIC.Util;
using PTIC.Common.Entities;
using PTIC.VC.Util;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmRecieverPicker : Form
    {
        public delegate void EmployeeSelectionHandler(object sender, EmployeeSelectionEventArgs args);
        public event EmployeeSelectionHandler EmployeeSelectedHandler;

        #region Constructors
        public frmRecieverPicker()
        {
            InitializeComponent();
            //  Disable auto-generate Columns
            dgvEmployees.AutoGenerateColumns = false;
            dgvSelectedEmployees.AutoGenerateColumns = false;
            LoadNBindEmployees();
        }
        #endregion

        #region Private Methods
        private void LoadNBindEmployees()
        {
            DataTable dtEmployee = null;
            try
            {
                // Load Employee
                if (Program.module == Program.Module.Marketing)
                {
                    dtEmployee = new EmployeeBL().GetAllExpectParam((int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                }
                else if(Program.module == Program.Module.Sale)
                {
                    dtEmployee =new EmployeeBL().GetAllExpectParam((int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                }

                dgvEmployees.DataSource = dtEmployee;
                dgvSelectedEmployees.DataSource = dtEmployee.Clone();
                //dgvSelectedEmployees.DataSource = dtEmployees;
            }
            catch (SqlException Sqle)
            {
                //TODO:
            }
            finally
            {
            }
        }

        private void SendBackEmployeeToComposeMessage()
        {
            List<Employee> insertEmployees = new List<Employee>();
            foreach (DataGridViewRow row in dgvSelectedEmployees.Rows)
            {
                Employee employee = new Employee()
                {
                    ID = (int)DataTypeParser.Parse(row.Cells[colEmployeeID.Index].Value, typeof(int), null)
                };                
                if (employee.ID != 0)
                    insertEmployees.Add(employee);
            }

            // Set selected invoices and handler for caller
            EmployeeSelectionEventArgs args = new EmployeeSelectionEventArgs(insertEmployees);
            EmployeeSelectedHandler(this, args);
        }

        #endregion

        private void dgvEmployees_DoubleClick(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.RowCount < 1)
                return;

            DataRow selectedRow = (dgv.CurrentRow.DataBoundItem as DataRowView).Row;
            DataTable tblSelection = dgvSelectedEmployees.DataSource as DataTable;
            bool flag = false;
            foreach (DataRow row in tblSelection.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row["EmployeeID"].ToString() == selectedRow["EmployeeID"].ToString())
                        flag = true;
                }
            }
            if (flag == true)
            {
                ToastMessageBox.Show("ဝန်ထမ်းတစ်ဦးကိုတစ်ကြိမ်သာရွေးပါ။", Color.Red);
            }
            else
            {
                // Add a selected row into selected Employees
                tblSelection.ImportRow(selectedRow);
                // Remove a selected row from Employees
                dgv.Rows.Remove(dgv.CurrentRow);
            }
        }

        private void dgvSelectedEmployees_DoubleClick(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.RowCount < 1)
                return;

            // Add a selected row into Employees
            DataRow selectedRow = (dgv.CurrentRow.DataBoundItem as DataRowView).Row;
            DataTable tblEmployee = dgvEmployees.DataSource as DataTable;

            tblEmployee.ImportRow(selectedRow);
            // Remove selected row from Selected Employees
            dgv.Rows.Remove(dgv.CurrentRow);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SendBackEmployeeToComposeMessage();
            this.Close();
        }


        #region Inner Class
        public class EmployeeSelectionEventArgs : System.EventArgs
        {
            private List<Employee> _Employee;

            public EmployeeSelectionEventArgs(List<Employee> employees)
            {
                this._Employee = employees;
            }

            public List<Employee> Employees
            {
                get { return this._Employee; }
            }
        }
        #endregion
    }

   
}
