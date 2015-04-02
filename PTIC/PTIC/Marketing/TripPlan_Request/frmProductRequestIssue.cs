using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Common.BL;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.Util;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.VC.Marketing.Entities;

namespace PTIC.Marketing.TripPlan_Request
{
    public partial class frmProductRequestIssue : Form
    {
        public delegate void ProductRequestIssueSaveHandler(object sender, ProductRequestIssueEventArgs e);

        public event ProductRequestIssueSaveHandler ProductRequestIssueSavedHandler;

        //  Employee Datatable
        DataTable dtEmployees = null;

        // Brand DataTable
        DataTable dtBrand = null;

        //  Product DataTable
        DataTable dtProduct = null;

        BindingSource bdBrand;
        BindingSource bdunfilteredProduct;
        BindingSource bdfilteredProduct;

        // DataTable of ProductRequestIssue
        DataTable dtProductRequestIssue = null;

        //
        int ProductRequestIssueID = -1;

        // ComboBox
        ComboBox cmb = null;

        public frmProductRequestIssue()
        {
            InitializeComponent();
            LoadNBind();
            rdoVen.Checked = true;                      
        }

        public frmProductRequestIssue(ProductRequestIssue _ProductRequestIssue)
            : this()
        {
            this.ProductRequestIssueID = _ProductRequestIssue.ID;
            cmbDeptVen.SelectedValue = _ProductRequestIssue.RequestVenID;
            cmbEmployee.SelectedValue = _ProductRequestIssue.RequesterID;
            if (this.ProductRequestIssueID == -1)
            {
                btnIssue.Enabled = false;
                colIssueQty.ReadOnly = true;
                colRequestQty.ReadOnly = false;
            }
            else
            {
                _ProductRequestIssue = new ProductRequestIssueBL().GetProductRequestIssueById(_ProductRequestIssue.ID);
                btnRequest.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                colIssueQty.ReadOnly = false;
                colRequestQty.ReadOnly = true;
                colBrand.ReadOnly = true;
                colProduct.ReadOnly = true;
                colPurpose.ReadOnly = true;
                colRemark.ReadOnly = true;
                colWeight.ReadOnly = true;
            }
            if (_ProductRequestIssue.IssueDeptID != 0 && _ProductRequestIssue.IssueDeptID!=null) 
            {
                cmbGiverDept.SelectedValue = _ProductRequestIssue.IssueDeptID;
                cmbGiver.SelectedValue = _ProductRequestIssue.IssuerID;
            
            }
            dgvProductReqIssue.AutoGenerateColumns = false;
            this.dtProductRequestIssue = new ProductRequestIssueBL().GetAllByProductReqIssueID(this.ProductRequestIssueID);
            dgvProductReqIssue.DataSource = dtProductRequestIssue;
            DataUtil.AddInitialNewRow(dgvProductReqIssue);
        }
        

        #region Private Methods
        private void LoadNBind()
        {
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            try
            {
                //  Bind Employees Into DataTable
                dtEmployees = new EmployeeBL().GetAll();
                cmbGiverDept.DataSource = new DepartmentBL().GetAll();
                cmbGiverDept.ValueMember = "ID";
                cmbGiverDept.DisplayMember = "DeptName";
            }
            catch (SqlException Sqle)
            {

                throw Sqle;
            }
            
            //  Brand & Product Link
            dtBrand = new BrandBL().GetAll();
            dtProduct = new ProductBL().GetAll();

            bdBrand = new BindingSource();
            bdBrand.DataSource = dtBrand;

            colBrand.DataSource = bdBrand;
            colBrand.DisplayMember = "BrandName";
            colBrand.ValueMember = "BrandID";

            bdunfilteredProduct = new BindingSource();
            DataView undv = new DataView(dtProduct);

            bdunfilteredProduct.DataSource = undv;
            colProduct.DataSource = bdunfilteredProduct;
            colProduct.DisplayMember = "ProductName";
            colProduct.ValueMember = "ProductID";

            bdfilteredProduct = new BindingSource();
            DataView fdv = new DataView(dtProduct);
            bdfilteredProduct.DataSource = fdv;
            
            // Request Purpose Column
            List<RequestPurposes> _RequestPurpose = new List<RequestPurposes>();
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 0, RequestPurposeName = "Outlet များပေးရန်" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 1, RequestPurposeName = "Retailer များပေးရန်" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 2, RequestPurposeName = "ခရီးစဉ်တွင်သုံးရန်" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 3, RequestPurposeName = "လက်ဆောင်ပေးရန်" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 4, RequestPurposeName = "ရုံးသုံးရန်" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 5, RequestPurposeName = "အခြားသုံးရန်" });
            colPurpose.DataSource = _RequestPurpose;
            colPurpose.DisplayMember = "RequestPurposeName";
            colPurpose.ValueMember = "RequestPurpose";

            //  ProductRequestIssue Bind into DataGridView
                        
        }


        private void Save()
        {
            SqlConnection conn = null;
           // int AP_RequestID = -1;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                
                // Get DataTable From DataGridView
                DataTable dt = dgvProductReqIssue.DataSource as DataTable;

                #region Entites ProductRequestIssue

                ProductRequestIssue _ProductRequestIssue = new ProductRequestIssue();
                _ProductRequestIssue.RequestDate = (DateTime)DataTypeParser.Parse(dtpRequestDate.Value, typeof(DateTime), DateTime.Now);
                if (rdoDept.Checked)
                {
                    _ProductRequestIssue.RequestDeptID = (int?)DataTypeParser.Parse(cmbDeptVen.SelectedValue, typeof(int), -1);
                    _ProductRequestIssue.RequestVenID = null;
                }
                else
                {
                    _ProductRequestIssue.RequestDeptID = null;
                    _ProductRequestIssue.RequestVenID = (int?)DataTypeParser.Parse(cmbDeptVen.SelectedValue, typeof(int), -1);
                }
                _ProductRequestIssue.RequesterID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1);
                _ProductRequestIssue.IssueDeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);
                _ProductRequestIssue.IssuerID = (int)DataTypeParser.Parse(cmbGiver.SelectedValue, typeof(int), -1);
                _ProductRequestIssue.IssueDate = (DateTime)DataTypeParser.Parse(DateTime.MinValue, typeof(DateTime), DateTime.MinValue);


                List<ProductRequestIssueDetail> insertProductRequestIssueDetail = new List<ProductRequestIssueDetail>();
                List<ProductRequestIssueDetail> updateProductRequestIssueDetail = new List<ProductRequestIssueDetail>();
                List<ProductRequestIssueDetail> deleteProductRequestIssueDetail = new List<ProductRequestIssueDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);

                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    ProductRequestIssueDetail _ProductRequestIssueDetail = new ProductRequestIssueDetail()
                    {
                        ProductRequestIssueID = (int)DataTypeParser.Parse(row["ProductRequestIssueID"].ToString(),typeof(int),-1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                        Weight = (int)DataTypeParser.Parse(row["Weight"].ToString(), typeof(int), 0),
                        RequestQty = (int)DataTypeParser.Parse(row["RequestQty"].ToString(), typeof(int), 0),
                        IssueQty =(int)DataTypeParser.Parse(row["IssueQty"].ToString(),typeof(int),0),
                        Purpose = (int)DataTypeParser.Parse(row["Purpose"], typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (_ProductRequestIssueDetail.ProductID != -1 && _ProductRequestIssueDetail.Purpose != -1 && _ProductRequestIssueDetail.RequestQty != 0)
                    {
                        insertProductRequestIssueDetail.Add(_ProductRequestIssueDetail);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    AP_RequestDetail _AP_RequestDetail = new AP_RequestDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["AP_RequestDetailID"], typeof(int), -1),
                        AP_RequestID = (int)DataTypeParser.Parse(row["AP_RequestID"], typeof(int), -1),
                        AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        RequestQty = (int)DataTypeParser.Parse(row["RequestQty"].ToString(), typeof(int), 0),
                        RequestPurpose = (int)DataTypeParser.Parse(row["RequestPurpose"].ToString(), typeof(int), 0),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                  //  deleteProductRequestIssueDetail.Add(_AP_RequestDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);

                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    ProductRequestIssueDetail _ProductRequestIssueDetail = new ProductRequestIssueDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["ProductRequestIssueDtlID"].ToString(),typeof(int),-1),
                        ProductRequestIssueID = (int)DataTypeParser.Parse(row["ProductRequestIssueID"].ToString(),typeof(int),-1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                        //Weight = (int)DataTypeParser.Parse(row["Weight"].ToString(), typeof(int), 0),
                        //RequestQty = (int)DataTypeParser.Parse(row["RequestQty"].ToString(), typeof(int), 0),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        //Purpose = (int)DataTypeParser.Parse(row["Purpose"], typeof(int), -1),
                        //Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    //if (_ProductRequestIssueDetail.ProductID != -1 && _ProductRequestIssueDetail.Purpose != -1 && _ProductRequestIssueDetail.RequestQty != 0 && _ProductRequestIssueDetail.IssueQty != 0)
                    //{
                    updateProductRequestIssueDetail.Add(_ProductRequestIssueDetail);
                   // }

                    ProductRequestIssueID = _ProductRequestIssueDetail.ProductRequestIssueID;
                    //AP_RequestID = _AP_RequestDetail.AP_RequestID;
                }
                
                #endregion
                int insertedRequestID = 0;
                if (ProductRequestIssueID != -1 && updateProductRequestIssueDetail.Count > 0)
                {
                    _ProductRequestIssue.ID = ProductRequestIssueID;
                    _ProductRequestIssue.IssueDate = dtpRequestDate.Value;
                    //insertedRequestID += new AP_RequestDetailBL().UpdateID(updateProductRequestIssueDetail, conn);
                    insertedRequestID += new ProductRequestIssueBL().Edit(_ProductRequestIssue, updateProductRequestIssueDetail);
                }
                else if (ProductRequestIssueID == -1 && insertProductRequestIssueDetail.Count > 0)
                {
                    insertedRequestID += new ProductRequestIssueBL().Add(_ProductRequestIssue, insertProductRequestIssueDetail);
                }

                if (insertedRequestID > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    ProductRequestIssueID = insertedRequestID;
                    //if (POSM_RequestSavedHandler == null)
                    //    UIManager.MdiChildOpenForm(typeof(frmPosmTransferList));
                    if (ProductRequestIssueSavedHandler != null)
                    {
                        // Send AP_RequestID to caller
                        ProductRequestIssueEventArgs eArg = new ProductRequestIssueEventArgs(this.ProductRequestIssueID);
                        ProductRequestIssueSavedHandler(this, eArg);
                    }
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }
        #endregion

        #region Events
        private void rdoDept_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbDeptVen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDept.Checked)
            {
                int DeptID = (int)DataTypeParser.Parse(cmbDeptVen.SelectedValue, typeof(int), -1);
                DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", DeptID);
                cmbEmployee.DataSource = dtEmployeesByDept;
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.DisplayMember = "EmpName";
            }
        }

        private void cmbGiverDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);

            DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", DeptID);
            cmbGiver.DataSource = dtEmployeesByDept;
            cmbGiver.ValueMember = "EmployeeID";
            cmbGiver.DisplayMember = "EmpName";
        }
        #endregion

        private void dgvProductReqIssue_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colProduct.Index)
                {
                    int BrandID = (int)DataTypeParser.Parse(this.dgvProductReqIssue[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (BrandID == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvProductReqIssue[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredProduct;

                    this.bdfilteredProduct.Filter = "BrandID = " + this.dgvProductReqIssue[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvProductReqIssue_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colProduct.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvProductReqIssue[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredProduct;
                    //  this.bdfilteredPOSM.RemoveFilter();
                }
            }
            catch { }
        }

        private void dgvProductReqIssue_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            if (this.dgvProductReqIssue.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvProductReqIssue.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void rdoVen_CheckedChanged(object sender, EventArgs e)
        {            
            try
            {                
                if (rdoDept.Checked)
                {
                    // Department, Ven & Employee
                    cmbDeptVen.DataSource = new DepartmentBL().GetAll();
                    cmbDeptVen.ValueMember = "ID";
                    cmbDeptVen.DisplayMember = "DeptName";
                    cmbDeptVen.SelectedValue = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
                }
                else
                {
                    try
                    {
                        //  Vehicle Binding
                        cmbDeptVen.DataSource = new VehicleBL().GetAll();
                        cmbDeptVen.DisplayMember = "VenNo";
                        cmbDeptVen.ValueMember = "VehicleID";

                        // Employee Binding
                        DataTable dtEmployeesByDept = null;
                        if (Program.module == Program.Module.Marketing)
                        {
                            dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                        }
                        else
                        {
                            dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                        }

                        cmbEmployee.DataSource = dtEmployeesByDept;
                        cmbEmployee.ValueMember = "EmployeeID";
                        cmbEmployee.DisplayMember = "EmpName";

                        cmbGiver.DataSource = dtEmployeesByDept;
                        cmbGiver.ValueMember = "EmployeeID";
                        cmbGiver.DisplayMember = "EmpName";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvProductReqIssue.DataSource as DataTable);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.msgSureSave, "သတိပေးချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;
            Save();
        }

        

        private void frmProductRequestIssue_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.msgSureSave, "သတိပေးချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;
            Save();
        }

    }

    #region Inner Class
    public class ProductRequestIssueEventArgs : EventArgs
    {
        private int? _productRequestIssueID = null;
        public ProductRequestIssueEventArgs(int? productRequestIssueID)
        {
            this._productRequestIssueID = productRequestIssueID;
        }
        public int? ProductRequestIssueID
        {
            get { return this._productRequestIssueID; }
        }
    }
    #endregion
}
