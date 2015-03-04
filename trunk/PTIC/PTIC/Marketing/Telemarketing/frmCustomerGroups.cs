using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Marketing.DA;
using PTIC.Marketing.Telemarketing;

namespace PTIC.VC.Marketing.Telemarketing
{
    public partial class frmCustomerGroups : Form
    {
        public string Action;
        int id = 0;


        public frmCustomerGroups()
        {
            InitializeComponent();
            LoadGridData();
        }

        #region Private Methods
        private void LoadGridData()
        {
             DataTable dt = new GroupDA().SelectAll();

            dgvGroup.AutoGenerateColumns = false;
            dgvGroup.DataSource = dt;         
        }

        private DataGridViewRow initilizeRow()
        {
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dgvGroup.ColumnCount; i++)
            {
                row.Cells.Add(new DataGridViewTextBoxCell());
            }
            return row;
        }

        private void Save()
        {
            GroupBL groupBL = new GroupBL();
            Group group = new Group();

            if (Action == "ADD")
              this.id = 0;         

            if (this.id != 0)
            {
                group.ID = this.id;
                group.LastModified = DateTime.Now.Date;
            }
            else
            {
                group.LastModified = DateTime.Now.Date;
            }
            group.GroupName = (string)DataTypeParser.Parse(txtGroupName.Text, typeof(string), String.Empty);
            if (group.GroupName == String.Empty)
            {
                ToastMessageBox.Show("Please fill Group Name", Color.Red);
                return;
            }
            group.DateAdded = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            groupBL.Create(group);
            ToastMessageBox.Show(Resource.msgSuccessfullySaved);                      
        }

        private void ClearFields()
        {
            txtGroupName.Text = string.Empty;
        }

        private void SetEditState(bool edit)
        {
            // When a record is selected for edit, disable the Add, Edit & Close buttons.
            btnNew.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnCancel.Enabled = !edit;
            btnDelete.Enabled = !edit;
            
            // When we are editing, do not allow to navigate in the grid.
            dgvGroup.Enabled = !edit;

            // When we are editing, only Cancel and Save buttons are enabled.
            btnCancel.Enabled = edit;
            btnSave.Enabled = edit;

            txtGroupName.ReadOnly = !edit;
        }

        private void LoadCurrentItem()
        {
            if (dgvGroup.CurrentRow.Index == -1)		// Is there any row selected now?
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            if (dgvGroup.SelectedRows.Count == 1 && Action == "Cancel")
            {
                btnCancel.Enabled = false;
                txtGroupName.Text = string.Empty;
            }
            else if(dgvGroup.SelectedRows.Count > 0)
            {
                int GroupID = int.Parse(dgvGroup.SelectedRows[0].Cells[colGroupID.Index].Value.ToString());
                Group group = new GroupDA().GetByID(GroupID);
                txtGroupName.Text = group.GroupName;
                this.id = GroupID;      
            }
        }
        #endregion

        private void dgvGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Action = "ADD";
            ClearFields();
            SetEditState(true);
            txtGroupName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Action = "EDIT";
            LoadCurrentItem();
            txtGroupName.Focus();
            SetEditState(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            txtGroupName.Text = string.Empty;
            LoadGridData();

         // Enable / Disable appropriate buttons.
            SetEditState(false);			
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Action = "Cancel";
            LoadCurrentItem();
            // Enable / Disable appropriate buttons.
            SetEditState(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GroupBL groupBL = new GroupBL();
            Group group = new Group();
            if (dgvGroup.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show("Group ကိုဖျက်ပါက Group အတွင်းရှိ Customer များပါပျက်သွားမည်။", Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    group.ID = (int)DataTypeParser.Parse(dgvGroup.SelectedRows[0].Cells[colGroupID.Index].Value, typeof(int), -1);
                    if (group.ID == -1)
                    {
                        dgvGroup.Rows.RemoveAt(dgvGroup.SelectedRows[0].Index);
                        return;
                    }
                    int affectedrow = groupBL.Delete(group);
                    if (affectedrow > 0)
                    {
                        ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                        LoadGridData();
                    }
                    else
                    {
                        MessageBox.Show(Resource.errCantDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }     
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count > 0)
            {
                Group group = new Group()
                {
                    ID = (int)DataTypeParser.Parse(dgvGroup.CurrentRow.Cells[colGroupID.Index].Value, typeof(int), -1),
                    GroupName = (string)DataTypeParser.Parse(dgvGroup.CurrentRow.Cells[colGroupName.Index].Value, typeof(string), string.Empty)
                };
                frmCustomersInGroup _frmCustomersInGroup = new frmCustomersInGroup(group);
                UIManager.MdiChildOpenForm(_frmCustomersInGroup);
                this.Close();
            }
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
            this.Close();
        }    
    }
}
