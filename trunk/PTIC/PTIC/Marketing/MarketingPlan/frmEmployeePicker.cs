using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Common.BL;
using PTIC.Common.Entities;
using PTIC.VC.Util;
using PTIC.Common.DA;
using PTIC.Util;

namespace PTIC.Marketing.MarketingPlan
{
    public partial class frmEmployeePicker : Form
    {
        public delegate void EmployeeSelectionHandler(object sender, EmployeeSelectionEventArgs args);
        public event EmployeeSelectionHandler EmployeeSelectedHandler;
        /// <summary>
        /// <paramref name="TripPlanDetailID"/>
        /// </summary>
        private int _TripPlanDetailID = 0;
        DataTable dtSelectedEmployees = null;
        private int _ManagerID = 0;

        List<Employee> deleteEmployees = new List<Employee>();
        List<Employee> selectedEmp = null;
        bool checkRequest = false;

        #region Constructors
        public frmEmployeePicker()
        {
            InitializeComponent();
            //  Disable auto-generate Columns
            dgvEmployees.AutoGenerateColumns = false;
            dgvSelectedEmployees.AutoGenerateColumns = false;
        }

        public frmEmployeePicker(int TripPlanIDDetailID, int ManagerID)
            : this()
        {
            this._TripPlanDetailID = TripPlanIDDetailID;
            this._ManagerID = ManagerID;
            //  Bind Employee
            LoadNBindEmployees();
        }

        public frmEmployeePicker(int TripPlanIDDetailID, int ManagerID,bool True)
            : this()
        {
            this._TripPlanDetailID = TripPlanIDDetailID;
            this._ManagerID = ManagerID;
            this.checkRequest = True;
            //  Bind Employee
            LoadNBindEmployees();
        }


        public frmEmployeePicker(int TripPlanIDDetailID, int ManagerID, List<Employee> selectedEmpList)
            : this()
        {
            this._TripPlanDetailID = TripPlanIDDetailID;
            this._ManagerID = ManagerID;
            //  Bind Employee
            selectedEmp = selectedEmpList;
            LoadNBindEmployees();
        }       
     
     
        #endregion

        #region Private Methods
        private void LoadNBindEmployees()
        {
            SqlConnection conn = null;
            DataTable dtEmployeeByDept = null;
            //DataRow selectedRow = null;
            try
            {
                string[] empIdList = null;
                conn = DBManager.GetInstance().GetDbConnection();
                // Load Employee
                DataTable dtEmployees = new EmployeeBL().GetAll();
                //  Bind Employees
                if (Program.Module.Marketing==Program.module)
                {
                    dtEmployeeByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", 8);
                }
                else
                {
                    dtEmployeeByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", 7);
                }

                DataTable allEmpTable = new DataTable();
                string empList = string.Empty;
                if (selectedEmp != null && selectedEmp.Count>0)
                {
                    empIdList = new string[selectedEmp.Count];
                    int index=0;

                    foreach(Employee emp in selectedEmp){
                        empIdList[index++]= string.Empty + emp.ID;
                    }

                    //empIdList[empIdList.Length - 1] = _ManagerID + string.Empty;
                    empList = "'" + string.Join("','",empIdList) + "'";
                    empList += ",'" + _ManagerID + "'";

                    DataRow[] dr = dtEmployeeByDept.Select("EmployeeID NOT IN (" + empList + ")");
                    allEmpTable = dr.CopyToDataTable();

                    dgvEmployees.DataSource = allEmpTable;
                }else{
                    DataRow[] dr = dtEmployeeByDept.Select("EmployeeID <> " + _ManagerID + "");
                    allEmpTable = dr.CopyToDataTable();

                    dgvEmployees.DataSource = allEmpTable;          
                }



                //  Bind Selected Employees
                if (this.checkRequest == true )
                {
                    dtSelectedEmployees = new EmployeeDA().SelectAllByTripRequestID(_TripPlanDetailID);
                }
                else
                {
                    dtSelectedEmployees = new EmployeeDA().SelectAllByTripPlanDetailID(_TripPlanDetailID);
                }


                if (selectedEmp != null && selectedEmp.Count > 0)
                {

                    dtSelectedEmployees = dtEmployeeByDept.Select("EmployeeID IN (" + "'" + string.Join("','", empIdList) + "'" + ")").CopyToDataTable();
                }
                dgvSelectedEmployees.DataSource = dtSelectedEmployees;
                
            }
            catch (SqlException Sqle)
            {
                //TODO:
            }
            finally
            {
            }
        }
              
        private void SendBackEmployeeToTripPlanDetail()
        {
            DataTable dtSelectedEmployees = dgvSelectedEmployees.DataSource as DataTable;
            // Get selected invoices in state of  DataViewRowState.CurrentRows
            DataView dvSelectedInvoices = new DataView(dtSelectedEmployees, string.Empty, string.Empty, DataViewRowState.CurrentRows);

            List<Employee> insertEmployees = new List<Employee>();

            foreach (DataGridViewRow row in dgvSelectedEmployees.Rows)
            {
                Employee employee = new Employee()
                {
                    ID = (int)DataTypeParser.Parse(row.Cells["colselEmpID"].Value, typeof(int), null),
                    EmployeeInTripPlanDetailID = (int)DataTypeParser.Parse(row.Cells["colEmployeeInTripPlanDetailID"].Value, typeof(int), 0)
                    // InvoiceNo = (string)DataTypeParser.Parse(row.Cells["dgvColInvoiceNo"].Value, typeof(string), string.Empty)
                };
                if (employee.ID != 0)
                    insertEmployees.Add(employee);
            }

            // Set selected invoices and handler for caller
            EmployeeSelectionEventArgs args = new EmployeeSelectionEventArgs(insertEmployees);
            EmployeeSelectedHandler(this, args);
        }
               
        #endregion

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

        #region Events

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
                ToastMessageBox.Show("၀န္ထမ္းတစ္ဦးကို တစ္ၾကိမ္သာေရြးပါ။", Color.Red);
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

            bool flag = false;
            foreach (DataRow row in tblEmployee.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row["EmployeeID"].ToString() == selectedRow["EmployeeID"].ToString())
                        flag = true;
                }
            }
            if (flag == true)
            {
                new EmployeeDA().DeleteByID((int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colEmployeeInTripPlanDetailID.Index].Value, typeof(int), 0));
                dgv.Rows.Remove(dgv.CurrentRow);
            }
            else
            {
                tblEmployee.ImportRow(selectedRow);
                // Remove selected row from Selected Employees
                dgv.Rows.Remove(dgv.CurrentRow);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SendBackEmployeeToTripPlanDetail();
            this.Close();
        }
        #endregion

        private void frmEmployeePicker_Load(object sender, EventArgs e)
        {

        }
    }
}
