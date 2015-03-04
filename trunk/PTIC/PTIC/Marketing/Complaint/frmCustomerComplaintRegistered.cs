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
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using PTIC.VC;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.Complaint
{
    public partial class frmCustomerComplaintRegistered : Form
    {
        int postfix = 0;
        int commentpostfix = 0;
        DataTable dt = null;
        int ComplaintReceiveID = -1;

        String Action = string.Empty;   // For Action Temp
        String Explanation = string.Empty;  // For Explanation Temp
        String Employee = null; // For Employee
        int EmployeeID = -1;  //  For Employee Temp

        String Comment = string.Empty; //    Form Comment Tem
        int CommentEmployeeID = -1; //   For Comment Employee Temp
        String CommentEmployee = null;

        public frmCustomerComplaintRegistered()
        {
            InitializeComponent();
            DateTime MinDate = (DateTime)DataTypeParser.Parse(dtpReceivedDate.Value.AddDays(-1), typeof(DateTime), DateTime.Now);
            dtpClosedDate.MinDate = MinDate;
            LoadNBind();
        }

        public frmCustomerComplaintRegistered(int ComplaintReceiveID)
            : this()
        {
            this.ComplaintReceiveID = ComplaintReceiveID;
            LoadNBindData();
        }

        #region Private Methods
        private void LoadNBindData()
        {
            // Bind Data From Complaint Receive
            DataTable dtComplaintReceive = new ComplaintReceiveBL().GetComplaintReceiveByComplaintReceiveID(this.ComplaintReceiveID);
            dtpReceivedDate.Value = (DateTime)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["ReceivedDate"], typeof(DateTime), DateTime.Now);
            txtMsgNo.Text = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["MsgNo"], typeof(string), null);
            txtRefNo.Text = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["RefNo"], typeof(string), null);
            txtTown.Text = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["TownOfCus"], typeof(string), null);
            txtCustomer.Text = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["Customer"], typeof(string), null);
            txtRemark.Text = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["Remark"], typeof(string), null);
            cmbReceiver.SelectedValue = (int)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["ReceiverID"], typeof(int), null);

            string UsedPeriod = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["UsedPeriod"], typeof(string), null);
            string UsageNature = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["UsageNature"], typeof(string), null);
            string UsingHour = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["UsingHour"], typeof(string), null);
            string ActionByReseller = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["ActionByReseller"], typeof(string), null);
            string ResellerRemark = (string)DataTypeParser.Parse(dtComplaintReceive.Rows[0]["ResellerRemark"], typeof(string), null);

            // Bind Data From ProductInComplaintReceive
            DataTable dtProductInComplaintReceive = new ComplaintReceiveBL().GetProductInComplaintReceiveBYComplaintReceiveID(this.ComplaintReceiveID);
            string Subject = string.Empty;
            string Post = string.Empty;
            foreach (DataRow row in dtProductInComplaintReceive.Rows)
            {
                string Product = string.IsNullOrEmpty(row["ProductName"].ToString()) ? string.Empty : "ထုတ်ကုန်အမည် − (" + row["ProductName"].ToString() + ")";
                string Qty = string.IsNullOrEmpty(row["Qty"].ToString()) ? string.Empty : " - (" + row["Qty"].ToString() + " Nos" + ") ,";
                string ProductionDate = string.IsNullOrEmpty(row["ProductionDate"].ToString()) ? string.Empty : "PD Date - (" + row["ProductionDate"].ToString() + ") , ";
                string ComplaintCase = string.IsNullOrEmpty(row["ComplaintCase"].ToString()) ? string.Empty : "ဖြစ်ပေါ်လာသည့်ကိစ္စ − (" + row["ComplaintCase"].ToString() + ") , ";

                // Subject
                Subject += Product + Qty + ProductionDate + ComplaintCase + "\r\n";
            }

            Subject += string.IsNullOrEmpty(UsedPeriod) ? string.Empty : "အသုံးပြုသည့်ကာလ − (" + UsedPeriod + ") , ";
            Subject += string.IsNullOrEmpty(UsageNature) ? string.Empty : UsageNature + ", ";
            Subject += string.IsNullOrEmpty(UsingHour) ? string.Empty : UsingHour + ",";
            Subject += string.IsNullOrEmpty(ActionByReseller) ? string.Empty : ActionByReseller + ",";
            Subject += string.IsNullOrEmpty(ResellerRemark) ? string.Empty : ResellerRemark + "။";

            txtSubject.Text = Subject;


            #region Binding ComplaintRegister && ComplaintExplanation and Com

            #endregion
        }

        private void LoadNBind()
        {
            // Bind DepartMent into ComboBox
            DataTable dtDepartment = new DepartmentBL().GetAll();
            List<Tuple<string, object>> queryDeptBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> SalesDepartment = Tuple.Create<string, object>("ID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
            Tuple<string, object> MktDepartment = Tuple.Create<string, object>("ID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);

            queryDeptBuilder.Add(SalesDepartment);
            queryDeptBuilder.Add(MktDepartment);
            DataTable dtDept = DataUtil.GetDataTableByOR(dtDepartment, queryDeptBuilder);
            cmbCloseDept.DataSource = dtDept;
            cmbCloseDept.DisplayMember = "DeptName";
            cmbCloseDept.ValueMember = "ID";

            //  Bind Employee From Sales && Marketing
            DataTable dtEmployee = new EmployeeBL().GetAllByRank();

            // Bind Into FromCombo
            cmbFrom.DataSource = dtEmployee.Copy();
            cmbFrom.DisplayMember = "EmpName";
            cmbFrom.ValueMember = "EmployeeID";

            // Bind Into ToCombo
            cmbTo.DataSource = dtEmployee.Copy();
            cmbTo.DisplayMember = "EmpName";
            cmbTo.ValueMember = "EmployeeID";

            List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> SalesDept = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
            Tuple<string, object> MktDept = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);

            queryBuilder.Add(SalesDept);
            queryBuilder.Add(MktDept);
            dt = DataUtil.GetDataTableByOR(dtEmployee, queryBuilder);

            // Bind Into Receiver
            cmbReceiver.DataSource = dt.Copy();
            cmbReceiver.DisplayMember = "EmpName";
            cmbReceiver.ValueMember = "EmployeeID";

            // Bind Employee
            cmbActionAccepter.DataSource = dt.Copy();
            cmbActionAccepter.DisplayMember = "EmpName";
            cmbActionAccepter.ValueMember = "EmployeeID";

            cmbCommentAccepter.DataSource = dt.Copy();
            cmbCommentAccepter.DisplayMember = "EmpName";
            cmbCommentAccepter.ValueMember = "EmployeeID";
        }

        private void Save()
        {
            int? affectedRows = null;
            ComplaintRegisterBL complaintSaver = new ComplaintRegisterBL();
            ComplaintRegister _ComplaintRegister = new ComplaintRegister();
            _ComplaintRegister.ComplaintReceiveID = this.ComplaintReceiveID;
            _ComplaintRegister.MsgNo = (string)DataTypeParser.Parse(txtMsgNo.Text, typeof(string), null);
            _ComplaintRegister.FromEmployeeID = (int)DataTypeParser.Parse(cmbFrom.SelectedValue, typeof(int), -1);
            _ComplaintRegister.ToEmployeeID = (int)DataTypeParser.Parse(cmbTo.SelectedValue, typeof(int), -1);
            _ComplaintRegister.ToEmployee = (string)DataTypeParser.Parse(txtTo.Text, typeof(string), null);
            _ComplaintRegister.FromEmployee = (string)DataTypeParser.Parse(txtFrom.Text, typeof(string), null);
            _ComplaintRegister.ClosedDate = (DateTime)DataTypeParser.Parse(dtpClosedDate.Value, typeof(DateTime), DateTime.Now);
            _ComplaintRegister.DepartmentIDClosed = (int?)DataTypeParser.Parse(cmbCloseDept.SelectedValue, typeof(int), null);

            #region Explanation and Action Binding

            List<ComplaintExplanation> _ComplaintExplanationList = new List<ComplaintExplanation>();
            int i = 0;  // For Action TextBox
            int j = 0;  // For Explanation TextBox
            int k = 0;  // For ComboBox
            int n = 0; // For textboxEmployee

            foreach (Control c in this.panel5.Controls)
            {
                ComplaintExplanation _ComplaintExplanation = new ComplaintExplanation();

                if (c is TextBox)
                {
                    if (c.Name.Contains("txtActionAccepter"))
                    {
                        Employee = ((TextBox)c).Text;
                        n++;
                    }
                    else if (c.Name.Contains("txtAction"))
                    {
                        Action = ((TextBox)c).Text;
                        i++;
                    }
                    else if (c.Name.Contains("txtExplan"))
                    {
                        Explanation = ((TextBox)c).Text;
                        j++;
                    }                   
                }
                else if (c is ComboBox)
                {
                    EmployeeID = (int)DataTypeParser.Parse(((ComboBox)c).SelectedValue, typeof(int), -1);
                    k++;
                }

                if (i == j && k == j && k == i && i == n && j == n && k == n && n > 0 && i > 0 && j > 0 && k > 0)
                {
                    _ComplaintExplanation.Action = Action;
                    _ComplaintExplanation.Explanation = Explanation;
                    _ComplaintExplanation.ExplainedByEmployeeID = EmployeeID;
                    _ComplaintExplanation.ExplainedByEmployee = Employee;
                    Action = string.Empty;
                    Explanation = string.Empty;
                    Employee = string.Empty;
                    EmployeeID = -1;
                    _ComplaintExplanationList.Add(_ComplaintExplanation);
                }
            }
            #endregion

            #region Comment Binding
            // ComplaintCommentList
            List<ComplaintComment> _ComplaintCommentList = new List<ComplaintComment>();
            int l = 0; //For Comment TextBOx
            int m = 0; // For Comment ComboBox
            int o = 0;

            foreach (Control c in this.panel6.Controls)
            {
                ComplaintComment _ComplaintComment = new ComplaintComment();

                if (c is TextBox)
                {                    
                    if (c.Name.Contains("txtCommentAccepter"))
                    {
                        CommentEmployee = ((TextBox)c).Text;
                        o++;
                    }
                    else if (c.Name.Contains("txtComment"))
                    {
                        Comment = ((TextBox)c).Text;
                        l++;
                    }
                }
                else if (c is ComboBox)
                {
                    CommentEmployeeID = (int)DataTypeParser.Parse(((ComboBox)c).SelectedValue, typeof(int), -1);
                    m++;
                }

                if (l > 0 && m > 0 && o > 0 && l == o && m == o && l == m)
                {
                    _ComplaintComment.Comment = Comment;
                    _ComplaintComment.CommentByEmployeeID = CommentEmployeeID;
                    _ComplaintComment.CommentByEmployee = CommentEmployee;
                    Comment = string.Empty;
                    CommentEmployee = String.Empty;
                    CommentEmployeeID = -1;
                    _ComplaintCommentList.Add(_ComplaintComment);
                }
            }
            #endregion

            // Save to database
            affectedRows = complaintSaver.AddComplaintRegister(_ComplaintRegister, _ComplaintExplanationList, _ComplaintCommentList);
            // Check field validation failed or not
            if (!complaintSaver.ValidationResults.IsValid) // failed
            {
                ValidationResult err = DataUtil.GetFirst(complaintSaver.ValidationResults) as ValidationResult;
                MessageBox.Show(
                    err.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else if (affectedRows.HasValue && affectedRows.Value > 0)
            {
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                this.Close();
            }
            else
            {
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
        }
        #endregion

        private void btnProductSelect_Click(object sender, EventArgs e)
        {
            // Automatically create Two TextBoxes & Two ComboBoxes
            TextBox txtRun = new TextBox();
            TextBox txtRun1 = new TextBox();
            TextBox txtRun2 = new TextBox();
            //ComboBox cmbRun = new ComboBox();
            ComboBox cmbRun1 = new ComboBox();

            postfix = ++postfix;
            txtRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRun.Name = "txtExplan" + postfix;
            txtRun.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int points = 66 + (85 * postfix);
            // points = points + 4;
            txtRun.Location = new System.Drawing.Point(27, points);
            //txtRun.Location = new System.Drawing.Point(27, 36 + (81 * postfix));
            txtRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRun.Multiline = true;
            txtRun.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtRun.Size = new System.Drawing.Size(462, 81);
            txtRun.TabIndex = 252 + postfix;

            txtRun1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRun1.Name = "txtAction" + postfix;
            txtRun1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRun1.Location = new System.Drawing.Point(508, points);
            txtRun1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRun1.Multiline = true;
            txtRun1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtRun1.Size = new System.Drawing.Size(427, 81);
            txtRun1.TabIndex = 262 + postfix;

            txtRun2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRun2.Name = "txtActionAccepter" + postfix;
            txtRun2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRun2.Location = new System.Drawing.Point(945, points);
            txtRun2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRun2.Multiline = false;
            txtRun2.Size = new System.Drawing.Size(166,28);
            txtRun2.TabIndex = 258 + postfix;

            cmbRun1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbRun1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbRun1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cmbRun1.FormattingEnabled = true;
            cmbRun1.Visible = false;
            cmbRun1.Name = "cmbActionAccepter" + postfix;
            cmbRun1.Location = new System.Drawing.Point(945, points);
            cmbRun1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbRun1.Size = new System.Drawing.Size(150, 27);
            cmbRun1.TabIndex = 258 + postfix;
            cmbRun1.DataSource = dt.Copy();
            cmbRun1.DisplayMember = "EmpName";
            cmbRun1.ValueMember = "EmployeeID";

            // Add Controls to panel
            this.panel5.Controls.Add(txtRun);
            this.panel5.Controls.Add(txtRun1);
            this.panel5.Controls.Add(txtRun2);
            //this.panel5.Controls.Add(cmbRun);
            this.panel5.Controls.Add(cmbRun1);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Remove Controls
            var txtExplan = panel5.Controls["txtExplan" + postfix.ToString()];
            var txtAction = panel5.Controls["txtAction" + postfix.ToString()];
            var cmbAccepter = panel5.Controls["cmbAccepter" + postfix.ToString()];
            var cmbActionAccepter = panel5.Controls["cmbActionAccepter" + postfix.ToString()];
            var txtActionAccepter = panel5.Controls["txtActionAccepter" + postfix.ToString()];

            panel5.Controls.Remove(txtExplan);
            panel5.Controls.Remove(txtAction);
            panel5.Controls.Remove(cmbAccepter);
            panel5.Controls.Remove(cmbActionAccepter);
            panel5.Controls.Remove(txtActionAccepter);

            if (panel5.Controls.Count == 11)
                postfix = 0;
            else if (panel5.Controls.Count > 11)
                postfix = --postfix;

        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            // Automatically create TextBoxe & ComboBoxe
            TextBox txtRun = new TextBox();
            TextBox txtRun1 = new TextBox();
            ComboBox cmbRun = new ComboBox();

            commentpostfix = ++commentpostfix;
            txtRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRun.Name = "txtComment" + commentpostfix;
            txtRun.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            int points = 66 + (118 * commentpostfix);
            // points = points + 4;
            txtRun.Location = new System.Drawing.Point(27, points);
            //txtRun.Location = new System.Drawing.Point(27, 36 + (81 * postfix));
            txtRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRun.Multiline = true;
            txtRun.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtRun.Size = new System.Drawing.Size(908, 115);
            txtRun.TabIndex = 261 + commentpostfix;

            txtRun1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRun1.Name = "txtCommentAccepter" + commentpostfix;
            txtRun1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtRun1.Location = new System.Drawing.Point(945, points);
            txtRun1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRun1.Multiline = false;
            txtRun1.Size = new System.Drawing.Size(166, 28);
            txtRun1.TabIndex = 263 + commentpostfix;


            //ComboBoxes
            cmbRun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmbRun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cmbRun.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cmbRun.FormattingEnabled = true;
            cmbRun.Visible = false;
            cmbRun.Name = "cmbCommentAccepter" + commentpostfix;
            cmbRun.Location = new System.Drawing.Point(945, points);
            cmbRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbRun.Size = new System.Drawing.Size(150, 27);
            cmbRun.TabIndex = 263 + commentpostfix;
            cmbRun.DataSource = dt.Copy();
            cmbRun.DisplayMember = "EmpName";
            cmbRun.ValueMember = "EmployeeID";

            // Add Controls to panel
            this.panel6.Controls.Add(txtRun);
            this.panel6.Controls.Add(cmbRun);
            this.panel6.Controls.Add(txtRun1);
        }

        private void btnRemoveComment_Click(object sender, EventArgs e)
        {
            // Remove Controls
            var txtComment = panel6.Controls["txtComment" + commentpostfix.ToString()];
            var cmbCommentAccepter = panel6.Controls["cmbCommentAccepter" + commentpostfix.ToString()];
            var txtCommentAccepter = panel6.Controls["txtCommentAccepter" + commentpostfix.ToString()];

            panel6.Controls.Remove(txtComment);
            panel6.Controls.Remove(cmbCommentAccepter);
            panel6.Controls.Remove(txtCommentAccepter);

            if (panel6.Controls.Count == 7)
                commentpostfix = 0;
            else if (panel6.Controls.Count > 7)
                commentpostfix = --commentpostfix;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

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
