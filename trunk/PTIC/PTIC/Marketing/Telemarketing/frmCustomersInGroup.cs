using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.VC.Marketing.Telemarketing;

namespace PTIC.Marketing.Telemarketing
{
    public partial class frmCustomersInGroup : Form
    {
        DataTable dtCustomerType, dtCustomer, dtAllCustomer, dtGroupCustomer;

        BindingSource bdCustomerType, bdfilteredCustomer, bdunfilteredCustomer;

        ComboBox cmb;

        Group group = null;
        bool IsInitial = false;

        #region Constructors
        public frmCustomersInGroup()
        {
            InitializeComponent();
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvGroupCustomer);
        }

        public frmCustomersInGroup(Group group)
        {
            InitializeComponent();
            this.group = group;
            txtGroupName.Text = group.GroupName;
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvGroupCustomer);
        }
        #endregion

        #region Private Methods
        private void LoadAddressNPhone(DataTable dt,bool IsInitial)
        {
            string address = string.Empty;
            string phone = string.Empty;
          
            foreach (DataRow customer in dt.Rows)            
            {
                // No            
                address += string.IsNullOrEmpty(customer["Hno"].ToString()) ? string.Empty : customer["Hno"].ToString() + ", ";
                // Street
                address += string.IsNullOrEmpty(customer["Street"].ToString()) ? string.Empty : customer["Street"].ToString() + ", ";
                // Quarter
                address += string.IsNullOrEmpty(customer["Quartar"].ToString()) ? string.Empty : customer["Quartar"].ToString() + ", ";
                // Township
                address += string.IsNullOrEmpty(customer["Township"].ToString()) ? string.Empty : customer["Township"].ToString() + ", ";
                // Town
                address += string.IsNullOrEmpty(customer["Town"].ToString()) ? string.Empty : customer["Town"].ToString() + ", ";
                // State / Division
                address += string.IsNullOrEmpty(customer["StateDivisionName"].ToString()) ? string.Empty : customer["StateDivisionName"].ToString();

                address = address.Replace(",,", ",");

                // Bind address into datagridview address column
                 dgvGroupCustomer.CurrentRow.Cells[colAddress.Index].Value = address;
            
                // Phone 1
                phone += string.IsNullOrEmpty(customer["Phone1"].ToString()) ? string.Empty : customer["Phone1"].ToString() + ", ";

                // Phone 2
                phone += string.IsNullOrEmpty(customer["Phone2"].ToString()) ? string.Empty : customer["Phone2"].ToString();

                phone = phone.Replace(",,", ",");

                dgvGroupCustomer.CurrentRow.Cells[colPhone.Index].Value = phone;
             
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvGroupCustomer.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void LoadNBind()
        {
            IsInitial = true;
            //  Customer Type & Customer Name Link
            dtCustomerType = new CustomerBL().GetAllCustomerType();
            dtCustomer = new CustomerBL().GetAllCustomer();
            dtAllCustomer = dtCustomer.Copy();

            bdCustomerType = new BindingSource();
            bdCustomerType.DataSource = dtCustomerType;

            colCustomerType.DataSource = bdCustomerType;
            colCustomerType.DisplayMember = "CusTypeName";
            colCustomerType.ValueMember = "ID";


            bdunfilteredCustomer = new BindingSource();
            DataView undv = new DataView(dtCustomer);

            bdunfilteredCustomer.DataSource = undv;
            colCustomerName.DataSource = bdunfilteredCustomer;
            colCustomerName.DisplayMember = "CusName";
            colCustomerName.ValueMember = "CustomerID";


            bdfilteredCustomer = new BindingSource();
            DataView fdv = new DataView(dtCustomer);
            bdfilteredCustomer.DataSource = fdv;

            //  CustomerInGroup Bind Into DataGridview
            dgvGroupCustomer.AutoGenerateColumns = false;
            dtGroupCustomer = new CustomersInGroupBL().GetAll();
            
            DataTable dtGroupCustomerByGroupID = DataUtil.GetDataTableBy(dtGroupCustomer, "GroupID", this.group.ID);
            if(dtGroupCustomerByGroupID !=null)
            {
                dgvGroupCustomer.DataSource = dtGroupCustomerByGroupID;             
            }
            else
            {
                dgvGroupCustomer.DataSource = dtGroupCustomer.Clone();               
            }
        }

        private void Save()
        {
            int affectedRow = -1;
            DataTable dt = dgvGroupCustomer.DataSource as DataTable;

            Group group = new Group()
            {
                ID = (int)DataTypeParser.Parse(this.group.ID, typeof(int), -1),
                GroupName = (string)DataTypeParser.Parse(txtGroupName.Text, typeof(string), string.Empty)
            };

            List<CustomersInGroup> insertCustomersInGroup = new List<CustomersInGroup>();
            List<CustomersInGroup> updateCustomersInGroup = new List<CustomersInGroup>();
            List<CustomersInGroup> deleteCustomersInGroup = new List<CustomersInGroup>();

            DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
            foreach (DataRow row in dvInsert.ToTable().Rows)
            {
                CustomersInGroup _customersInGroup = new CustomersInGroup()
                {
                    ID = (int)DataTypeParser.Parse(row["CustomersInGroupID"], typeof(int), -1),
                    GroupID = (int)DataTypeParser.Parse(row["GroupID"], typeof(int), -1),
                    CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1)
                };
                insertCustomersInGroup.Add(_customersInGroup);
            }

            // delete
            DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
            foreach (DataRow row in dvDelete.ToTable().Rows)
            {
                CustomersInGroup _customersInGroup = new CustomersInGroup()
                {
                    ID = (int)DataTypeParser.Parse(row["CustomersInGroupID"], typeof(int), -1),
                    GroupID = (int)DataTypeParser.Parse(row["GroupID"], typeof(int), -1),
                    CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1)
                };
                deleteCustomersInGroup.Add(_customersInGroup);
            }

            // update
            DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
            foreach (DataRow row in dvUpdate.ToTable().Rows)
            {
                CustomersInGroup _customersInGroup = new CustomersInGroup()
                {
                    ID = (int)DataTypeParser.Parse(row["CustomersInGroupID"], typeof(int), -1),
                    GroupID = (int)DataTypeParser.Parse(row["GroupID"], typeof(int), -1),
                    CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1)
                };
                updateCustomersInGroup.Add(_customersInGroup);
            }

            if (insertCustomersInGroup.Count > 0) // New marketing detail
            {
                // Add new CustomersInGroup
                affectedRow = new CustomersInGroupBL().Add(group, insertCustomersInGroup);
            }

            if (affectedRow > 0)
            {
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                LoadNBind();               
            }

        }
        #endregion

        private void dgvGroupCustomer_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colCustomerName.Index)
                {
                    int CusType = (int)DataTypeParser.Parse(this.dgvGroupCustomer[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (CusType == -1) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvGroupCustomer[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredCustomer;
                    if (this.dgvGroupCustomer[e.ColumnIndex - 1, e.RowIndex].Value.ToString() == string.Empty || this.dgvGroupCustomer[e.ColumnIndex - 1, e.RowIndex].Value.ToString() == null) return;
                    this.bdfilteredCustomer.Filter = "CusType = " + this.dgvGroupCustomer[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvGroupCustomer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colCustomerName.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvGroupCustomer[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredCustomer;
                }
            }
            catch { }

            if (dgvGroupCustomer.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colCustomerName.Index)
            {
                dgvGroupCustomer.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvGroupCustomer.CurrentRow.Cells[colCustomerName.Index].Value = -1;
                dgvGroupCustomer.CurrentRow.Cells[colPhone.Index].Value = string.Empty;
                dgvGroupCustomer.CurrentRow.Cells[colAddress.Index].Value = string.Empty;
            }
        }

        private void dgvGroupCustomer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            if (this.dgvGroupCustomer.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvGroupCustomer.CurrentCell.ColumnIndex;
                int iRow = dgvGroupCustomer.CurrentCell.RowIndex;
                if (iColumn == dgvGroupCustomer.Columns[colAddress.Index].Index)
                {
                    if (iRow + 1 >= dgvGroupCustomer.Rows.Count)
                    {
                        DataTable dtAPEnquiry = dgvGroupCustomer.DataSource as DataTable;
                        DataRow newRow = dtAPEnquiry.NewRow();
                        dtAPEnquiry.Rows.Add(newRow);
                        dgvGroupCustomer.DataSource = dtAPEnquiry;
                        dgvGroupCustomer[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvGroupCustomer.CurrentCell = dgvGroupCustomer[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvGroupCustomer.CurrentCell = dgvGroupCustomer[dgvGroupCustomer.CurrentCell.ColumnIndex + 1, dgvGroupCustomer.CurrentCell.RowIndex];
                    }
                    catch (Exception)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvGroupCustomer.DataSource as DataTable);
            dgvGroupCustomer.CurrentCell = dgvGroupCustomer.Rows[dgvGroupCustomer.Rows.Count - 1].Cells[0];
        }

        private void dgvGroupCustomer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvGroupCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvGroupCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string address = string.Empty;
            string phone = string.Empty;
            if (dgvGroupCustomer == null || e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (e.ColumnIndex == colCustomerName.Index)
            {
                int CustomerID = (int)DataTypeParser.Parse(dgvGroupCustomer.CurrentRow.Cells[colCustomerName.Index].Value, typeof(int), -1);
                //DataTable dtCustomerInfoByCusID = new CustomerBL().GetAllByCusID(CustomerID);
                DataTable dtCustomerInfoByCusID = DataUtil.GetDataTableBy(dtAllCustomer, "CustomerID", CustomerID);
                if (dtCustomerInfoByCusID == null) return;

                LoadAddressNPhone(dtCustomerInfoByCusID,false);
                IsInitial = false;
              
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgvGroupCustomer_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (e.ColumnIndex == colCustomerName.Index && IsInitial == false)
            {
                foreach (DataRow r in dtGroupCustomer.Rows)
                {
                    if ((int)DataTypeParser.Parse(r["CustomerID"], typeof(int), -1) == (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colCustomerName.Index].Value, typeof(int), -1))
                    {
                        dgv.Rows[e.RowIndex].ErrorText = "Error";
                        MessageBox.Show("ရွေးချယ်ထားသော Customer သည်အခြား Group ထဲတွင်ထည့်သွင်းပြီးဖြစ်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colCustomerName"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colCustomerName"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
                            MessageBox.Show("Duplicate not allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

        private void dgvGroupCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvGroupCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
         
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if ((int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colCustomersInGroupID.Index].Value, typeof(int), 0) != 0)
                    {
                        dgv.Rows[r.Index].ReadOnly = true;
                      //  dgv.Rows[r.Index].Cells[colAccepted.Index].ReadOnly = false;
                    }
                }

                if (IsInitial)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        string address = string.Empty;
                        string phone = string.Empty;
                        // No            
                        address += string.IsNullOrEmpty(row.Cells[colHno.Index].Value.ToString()) ? string.Empty : row.Cells[colHno.Index].Value.ToString() + ", ";
                        // Street
                        address += string.IsNullOrEmpty(row.Cells[colStreet.Index].Value.ToString()) ? string.Empty : row.Cells[colStreet.Index].Value.ToString() + ", ";
                        // Quarter
                        address += string.IsNullOrEmpty(row.Cells[colQuartar.Index].Value.ToString()) ? string.Empty : row.Cells[colQuartar.Index].Value.ToString() + ", ";
                        // Township
                        address += string.IsNullOrEmpty(row.Cells[colTown.Index].Value.ToString()) ? string.Empty : row.Cells[colTown.Index].Value.ToString() + ", ";
                        // Town
                        address += string.IsNullOrEmpty(row.Cells[colTownship.Index].Value.ToString()) ? string.Empty : row.Cells[colTownship.Index].Value.ToString() + ", ";
                        // State / Division
                        address += string.IsNullOrEmpty(row.Cells[colStateDivision.Index].Value.ToString()) ? string.Empty : row.Cells[colStateDivision.Index].Value.ToString();

                        address = address.Replace(",,", ",");

                        // Bind address into datagridview address column
                        row.Cells[colAddress.Index].Value = address;

                        // Phone 1
                        phone += string.IsNullOrEmpty(row.Cells[colPhone1.Index].Value.ToString()) ? string.Empty : row.Cells[colPhone1.Index].Value.ToString() + ", ";

                        // Phone 2
                        phone += string.IsNullOrEmpty(row.Cells[colPhone2.Index].Value.ToString()) ? string.Empty : row.Cells[colPhone2.Index].Value.ToString();

                        phone = phone.Replace(",,", ",");

                        row.Cells[colPhone.Index].Value = phone;
                    }
                }
                
            }

        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerGroups));
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomersInGroupBL customerInGroupBL = new CustomersInGroupBL();
            CustomersInGroup customersInGroup = new CustomersInGroup();
            if (dgvGroupCustomer.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    customersInGroup.ID = (int)DataTypeParser.Parse(dgvGroupCustomer.SelectedRows[0].Cells[colCustomersInGroupID.Index].Value,typeof(int),-1);
                if (customersInGroup.ID == -1)
                {
                    dgvGroupCustomer.Rows.RemoveAt(dgvGroupCustomer.SelectedRows[0].Index);
                    return;
                }
                
                int affectedrow = customerInGroupBL.Delete(customersInGroup);
                if (affectedrow > 0)
                {
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    LoadNBind();
                }
                else
                {
                    MessageBox.Show(Resource.errCantDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }
    }
}
