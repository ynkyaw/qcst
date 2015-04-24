using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Common.BL;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Util;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmPosmRecieve : Form
    {
        DataTable dtEmployees = null;
        DataTable dtAP_RequestIssueDetail = null;

        #region Constructors

        public frmPosmRecieve()
        {
            InitializeComponent();
            pnlFilter.Visible = false;
            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            LoadNBind();
            cmbGiverDept.SelectedValue = (int)DataTypeParser.Parse(8, typeof(int), -1);
        }

        public frmPosmRecieve(int? AP_RequestID,int IssueDeptID,int IssueEmployeeID)
            : this()
        {
            // DataGridView Auto-Generate Columns fals
            dgvPosmRecieve.AutoGenerateColumns = false;
            cmbGiverDept.SelectedValue = (int)DataTypeParser.Parse(IssueDeptID, typeof(int), -1);
            cmbGiver.SelectedValue = (int)DataTypeParser.Parse(IssueEmployeeID, typeof(int), -1);
            DataTable dtAP_RIByRequestID =DataUtil.GetDataTableBy(this.dtAP_RequestIssueDetail, "AP_RequestID", AP_RequestID);
            if (dtAP_RIByRequestID.Rows.Count > 0)
            {
                if ((int?)DataTypeParser.Parse(dtAP_RIByRequestID.Rows[0]["FromDeptID"], typeof(int), null) != null)
                {
                    cmbGiverDept.SelectedValue = (int?)DataTypeParser.Parse(dtAP_RIByRequestID.Rows[0]["FromDeptID"], typeof(int), null);
                    cmbGiverDept.Enabled = false;
                    cmbGiver.Enabled = false;
                    btnSave.Enabled = false;
                    dgvPosmRecieve.Enabled = false;             
                }
                cmbReciever.SelectedValue = (int)DataTypeParser.Parse(dtAP_RIByRequestID.Rows[0]["RequesterID"], typeof(int), -1);
                textBox1.Text = (string)DataTypeParser.Parse(dtAP_RIByRequestID.Rows[0]["RequestNo"], typeof(string), String.Empty);
            }
            dgvPosmRecieve.DataSource = dtAP_RIByRequestID;

        }

        #endregion

        #region Private Methods
        private void LoadNBind()
        {
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            try
            {
                //  Bind Employees Into DataTable
                dtEmployees = new EmployeeBL().GetAll();
                cmbReciever.DataSource = dtEmployees;
                cmbReciever.ValueMember = "EmployeeID";
                cmbReciever.DisplayMember = "EmpName";

                // Department, Ven & Employee
                cmbGiverDept.DataSource = new DepartmentBL().GetAll();
                cmbGiverDept.ValueMember = "ID";
                cmbGiverDept.DisplayMember = "DeptName";
                //cmbGiverDept.SelectedValue = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }

            //  AP_RecieveDetail Bind Into DataGridview
            dgvPosmRecieve.AutoGenerateColumns = false;
            this.dtAP_RequestIssueDetail = new AP_RequestDetailBL().GetAll();
            dgvPosmRecieve.DataSource = this.dtAP_RequestIssueDetail.Clone();

        }

        private void Save()
        {
            SqlConnection conn = null;
            int AP_IssueDetailID = -1;
           try
            {
                conn = DBManager.GetInstance().GetDbConnection();
               
                // Get DataTable From DataGridView
                DataTable dt = dgvPosmRecieve.DataSource as DataTable;
                #region Entites AP_Request

                List<AP_IssueDetail> insertAP_IssueDetail = new List<AP_IssueDetail>();
                List<AP_IssueDetail> updateAP_IssueDetail = new List<AP_IssueDetail>();
                List<AP_IssueDetail> deleteAP_IssueDetail = new List<AP_IssueDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {                           
                    AP_IssueDetail _AP_IssueDetail = new AP_IssueDetail()
                    {
                        AP_RequestDetailID = (int)DataTypeParser.Parse(row["AP_RequestDetailID"], typeof(int), -1),
                        IssueDate = (DateTime)DataTypeParser.Parse(dtpIssueDate.Value, typeof(DateTime), DateTime.Now),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        FromDeptID = (int?)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1),
                        ToDeptID = (int?)DataTypeParser.Parse(row["RequestDeptID"], typeof(int), null),
                        ToVenID = (int?)DataTypeParser.Parse(row["RequestVenID"], typeof(int), null),
                        FromEmpID = (int)DataTypeParser.Parse(cmbGiver.SelectedValue, typeof(int), -1),
                        ToEmpID = (int)DataTypeParser.Parse(cmbReciever.SelectedValue, typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (_AP_IssueDetail.IssueQty != 0 && _AP_IssueDetail.FromEmpID != -1 && _AP_IssueDetail.ToDeptID != -1 && _AP_IssueDetail.FromEmpID != -1 && _AP_IssueDetail.ToEmpID != -1)
                    {
                        insertAP_IssueDetail.Add(_AP_IssueDetail);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    AP_IssueDetail _AP_IssueDetail = new AP_IssueDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["AP_IssueDetailID"], typeof(int), -1),
                        AP_RequestDetailID = (int)DataTypeParser.Parse(row["AP_RequestDetailID"], typeof(int), -1),
                        IssueDate = (DateTime)DataTypeParser.Parse(dtpIssueDate.Value, typeof(DateTime), DateTime.Now),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        FromDeptID = (int?)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1),
                        ToDeptID = (int?)DataTypeParser.Parse(row["RequestDeptID"], typeof(int), null),
                        ToVenID = (int?)DataTypeParser.Parse(row["RequestVenID"], typeof(int), null),
                        FromEmpID = (int)DataTypeParser.Parse(cmbGiver.SelectedValue, typeof(int), -1),
                        ToEmpID = (int)DataTypeParser.Parse(cmbReciever.SelectedValue, typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    deleteAP_IssueDetail.Add(_AP_IssueDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);

                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {                   
                    AP_IssueDetail _AP_IssueDetail = new AP_IssueDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["AP_IssueDetailID"], typeof(int), -1),
                        AP_RequestDetailID = (int)DataTypeParser.Parse(row["AP_RequestDetailID"], typeof(int), -1),
                        IssueDate = (DateTime)DataTypeParser.Parse(dtpIssueDate.Value, typeof(DateTime), DateTime.Now),
                        IssueQty = (int)DataTypeParser.Parse(row["IssueQty"].ToString(), typeof(int), 0),
                        FromDeptID = (int?)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1),
                        ToDeptID = (int?)DataTypeParser.Parse(row["RequestDeptID"], typeof(int), null),
                        ToVenID = (int?)DataTypeParser.Parse(row["RequestVenID"], typeof(int), null),
                        FromEmpID = (int)DataTypeParser.Parse(cmbGiver.SelectedValue, typeof(int), -1),
                        ToEmpID = (int)DataTypeParser.Parse(cmbReciever.SelectedValue, typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (_AP_IssueDetail.IssueQty < 1)
                    {
                        MessageBox.Show("Please Fill 'Issue Qty'", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (_AP_IssueDetail.IssueQty != 0 && _AP_IssueDetail.FromEmpID != -1 && _AP_IssueDetail.ToDeptID != -1 && _AP_IssueDetail.FromEmpID != -1 && _AP_IssueDetail.ToEmpID != -1)
                    {
                        updateAP_IssueDetail.Add(_AP_IssueDetail);
                    }
                    AP_IssueDetailID = _AP_IssueDetail.ID;
                }

                #endregion
                int affectedrows = 0;
                if (AP_IssueDetailID == -1 && updateAP_IssueDetail.Count > 0)
                {
                    affectedrows += new IssueDetailBL().Add(updateAP_IssueDetail, conn);
                    //affectedrows += new AP_RequestDetailBL().UpdateID(updateAP_IssueDetail, conn);
                }
                else if (AP_IssueDetailID != -1 && updateAP_IssueDetail.Count > 0)
                {
                    affectedrows += new IssueDetailBL().Update(updateAP_IssueDetail, conn);
                   // affectedrows += new AP_RequestDetailBL().Add(_AP_IssueDetail, insertAP_IssueDetail, conn);
                }

                if (affectedrows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);                   
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

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
                pnlGrid.Visible = true;
            }
            else
            {
                pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
                pnlGrid.Visible = false;
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmTransferList));
            this.Close();
        }

        private void cmbGiverDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtAP_RequestIssueDetail == null) return;
            int DeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);
            int RequestDeptID = -1;
            if (dtAP_RequestIssueDetail.Rows.Count > 0)
            {
                RequestDeptID = (int)DataTypeParser.Parse(dtAP_RequestIssueDetail.Rows[0]["RequestDeptID"], typeof(int), -1);
            }
            //if (RequestDeptID == DeptID)
            //{
            //    MessageBox.Show("ပေးမည့် ဌာန နှင့် ယူမည့် ဌာန မတူညီရပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    cmbGiverDept.SelectedValue = -1;
            //    return;
            //}

            DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", DeptID);
            cmbGiver.DataSource = dtEmployeesByDept;
            cmbGiver.ValueMember = "EmployeeID";
            cmbGiver.DisplayMember = "EmpName";
        }

        private void dgvPosmRecieve_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    int RequestPurpose = (int)DataTypeParser.Parse(dtAP_RequestIssueDetail.Rows[r.Index]["RequestPurpose"], typeof(int), -1);

                    if (RequestPurpose == (int)PTIC.Common.Enum.A_P_RequestPurpose.Outlet)
                    {
                        dgv.Rows[r.Index].Cells[colDescription.Index].Value = "Outlet များပေး";
                    }
                    else if (RequestPurpose == (int)PTIC.Common.Enum.A_P_RequestPurpose.Retailer)
                    {
                        dgv.Rows[r.Index].Cells[colDescription.Index].Value = "Retailer များပေး";
                    }
                    else if (RequestPurpose == (int)PTIC.Common.Enum.A_P_RequestPurpose.Present)
                    {
                        dgv.Rows[r.Index].Cells[colDescription.Index].Value = "လက်ဆောင်ပေး";
                    }
                    else if (RequestPurpose == (int)PTIC.Common.Enum.A_P_RequestPurpose.Trip)
                    {
                        dgv.Rows[r.Index].Cells[colDescription.Index].Value = "ခရီးစဉ်";
                    }
                    else if (RequestPurpose == (int)PTIC.Common.Enum.A_P_RequestPurpose.Office)
                    {
                        dgv.Rows[r.Index].Cells[colDescription.Index].Value = "ရုံးသုံး";
                    }
                    else
                    {
                        dgv.Rows[r.Index].Cells[colDescription.Index].Value = "အခြား";
                    }



                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.msgSureSave, "သတိပေးချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;
            Save();
        }

        #endregion

        private void cmbGiverDept_Validating(object sender, CancelEventArgs e)
        {
            //if (this.cmbGiverDept.SelectedIndex == -1)
            //{
            //    MessageBox.Show("ထုတ်ပေးသည့်ဌာန ရွေးပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    cmbGiverDept.SelectedValue = -1;
            //}
        }

        private void cmbGiver_Validating(object sender, CancelEventArgs e)
        {
            //if (this.cmbGiver.SelectedIndex == -1)
            //{
            //    MessageBox.Show("ထုတ်ပေးသူ ရွေးပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    cmbGiver.SelectedValue = -1;
            //}
        }

        private void dgvPosmRecieve_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            var dgv = sender as DataGridView;
            string APMaterialName;
            int Qty;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            int APMaterialID = (int)DataTypeParser.Parse(dgvPosmRecieve.CurrentRow.Cells[colAP_MaterialID.Index].Value, typeof(int), -1);
            int DeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);
            DataTable dt = new AP_EnquiryBL().GetBalanceByAPMaterialIDDeptID(APMaterialID, DeptID);
            if (dt.Rows.Count < 1)
            {
                Qty = 0;
            }
            else
            {
                APMaterialName = (string)DataTypeParser.Parse(dt.Rows[0]["APMaterialName"], typeof(string), String.Empty);
                Qty = (int)DataTypeParser.Parse(dt.Rows[0]["Qty"], typeof(int), 0);
            }
            //string BalanceMessage = String.Format("လက်ကျန်အရေအတွက်\n   {0} = {1}", APMaterialName, Qty);
            //MessageBox.Show(BalanceMessage, "လက်ကျန်", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
            if (e.ColumnIndex == colIssueQty.Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
                }              
            }
            if (Qty < newInteger)
            {
                string BalanceQty = String.Format("လက်ကျန် '{0}' သာရှိတော့သဖြင့် မလုံလောက်ပါ။",Qty);
                dgv.Rows[e.RowIndex].ErrorText = BalanceQty;
                MessageBox.Show(BalanceQty, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPosmRecieve_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {           
            if (dgvPosmRecieve.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colIssueQty.Index)
            {
                dgvPosmRecieve.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvPosmRecieve.CurrentRow.Cells[colIssueQty.Index].Value = 0;
            }
        }

    }

    #region Inner Class
    public class POSM_ReceiveEventArgs : EventArgs
    {
        //private int? _AP_RequestID = null;
        //public POSM_RequestEventArgs(int? AP_RequestID)
        //{
        //    this._AP_RequestID = AP_RequestID;
        //}
        //public int? AP_RequestID
        //{
        //    get { return this._AP_RequestID; }
        //}
    }
    #endregion

}
