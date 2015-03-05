using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing;
using PTIC.Common.BL;
using PTIC.Util;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Marketing.DA;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.Sale.Setup;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmMessageUsers : Form
    {
        public string Action;
        int id = 0;

        public frmMessageUsers()
        {
            InitializeComponent();
            LoadNBind();
            LoadGridData();
        }

        #region Private Methods
        public void LoadNBind()
        {
            DataTable dtEmployee = new EmployeeBL().GetAllByRank();
          
            cmbSenderEmployee.DataSource = dtEmployee;
            cmbSenderEmployee.ValueMember = "EmployeeID";
            cmbSenderEmployee.DisplayMember = "EmpName";
            if (dtEmployee.Rows.Count > 0)
            {
                cmbSenderEmployee.SelectedIndex = 1;
            }
        }

        private void ClearFields()
        {
            cmbSenderEmployee.SelectedIndex = 0;
        }

        private void SetEditState(bool edit)
        {
            // When a record is selected for edit, disable the Add, Edit & Close buttons.
            btnNew.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnCancel.Enabled = !edit;
            btnDelete.Enabled = !edit;

            // When we are editing, do not allow to navigate in the grid.
            dgvMsgUser.Enabled = !edit;

            // When we are editing, only Cancel and Save buttons are enabled.
            btnCancel.Enabled = edit;
            btnSave.Enabled = edit;

            cmbSenderEmployee.Enabled = edit;
        }

        private void LoadCurrentItem()
        {
            if (dgvMsgUser.Rows.Count == 0)
            {
                btnCancel.Enabled = false;
                cmbSenderEmployee.SelectedIndex = 0;
                return;
            }
            else if (dgvMsgUser.CurrentRow.Index == -1)		// Is there any row selected now?
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            if (dgvMsgUser.SelectedRows.Count == 1 && Action == "Cancel")
            {
                btnCancel.Enabled = false;
                cmbSenderEmployee.SelectedIndex = 0;
            }
            else if (dgvMsgUser.SelectedRows.Count > 0)
            {
                int EmpID = int.Parse(dgvMsgUser.SelectedRows[0].Cells[colEmpID.Index].Value.ToString());
                int MessageUsersID = int.Parse(dgvMsgUser.SelectedRows[0].Cells[colMessageUsersID.Index].Value.ToString());
             //   Group group = new GroupDA().GetByID(EmpID);
                //txtGroupName.Text = group.GroupName;
                cmbSenderEmployee.SelectedValue = EmpID;
                this.id = MessageUsersID;
            }
        }

        private void Save()
        {
            MessageUsersBL messageUsersBL = new MessageUsersBL();
            MessageUsers messageUsers = new MessageUsers();

            if (Action == "ADD")
                this.id = 0;

            if (this.id != 0)
            {
                messageUsers.ID = this.id;
                messageUsers.LastModified = DateTime.Now.Date;
            }
            else
            {
                messageUsers.LastModified = DateTime.Now.Date;
            }
            messageUsers.EmployeeID = (int)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), -1);

            messageUsers.DateAdded = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            messageUsersBL.Create(messageUsers);
            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
        }

        private void LoadGridData()
        {
            DataTable dt = new MessageUsersDA().SelectAll();

            dgvMsgUser.AutoGenerateColumns = false;
            dgvMsgUser.DataSource = dt;
        }

        #endregion

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            if (Program.module == Program.Module.Marketing)
            {
                UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
                this.Close();
            }
            else if(Program.module == Program.Module.Sale)
            {
                UIManager.MdiChildOpenForm(typeof(frmSetupPage));
                this.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Action = "ADD";
            ClearFields();
            SetEditState(true);
            cmbSenderEmployee.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Action = "EDIT";
            LoadCurrentItem();
            cmbSenderEmployee.Focus();
            SetEditState(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new MessageUsersDA().SelectAll();
            int EmployeeID = (int)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), -1);

            if (dt == null) return;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int dtEmployeeID = (int)DataTypeParser.Parse(row["EmployeeID"], typeof(int), -1);

                    if (dtEmployeeID == EmployeeID)
                    {
                        MessageBox.Show("Duplicate Not Allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SetEditState(false);
                        return;
                    }
                }
            }

            Save();
            cmbSenderEmployee.SelectedIndex = 0;
            //txtGroupName.Text = string.Empty;
            LoadGridData();

            // Enable / Disable appropriate buttons.
            SetEditState(false);			
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageUsersBL messageUsersBL = new MessageUsersBL();
            MessageUsers messageUsers = new MessageUsers();
            if (dgvMsgUser.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.deleteConfirmation, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    messageUsers.ID = (int)DataTypeParser.Parse(dgvMsgUser.SelectedRows[0].Cells[colMessageUsersID.Index].Value, typeof(int), -1);
                    if (messageUsers.ID == -1)
                    {
                        dgvMsgUser.Rows.RemoveAt(dgvMsgUser.SelectedRows[0].Index);
                        return;
                    }
                    int affectedrow = messageUsersBL.Delete(messageUsers);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Action = "Cancel";
            LoadCurrentItem();
            // Enable / Disable appropriate buttons.
            SetEditState(false);
        }
    }
}
