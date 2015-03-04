using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Util;
using PTIC.Marketing.BL;

namespace PTIC.Marketing.Complaint
{
    public partial class frmCustomerComplainSummary : Form
    {
        DataTable dtComplaintRegister = null;

        public frmCustomerComplainSummary()
        {
            InitializeComponent();
            LoadNBind(dtpReceivedDate);
        }

        #region Private Methods

        private void LoadNBind(DateTimePicker dtpReceivedDate)
        {
            //  Bind Complaint Summary
            dtComplaintRegister = new ComplaintRegisterBL().GetSComplaintRegisteByReceiveDate(dtpReceivedDate.Value.Month, dtpReceivedDate.Value.Year);
            // Auto-Generate Columns false
            dgvComplaintSummary.AutoGenerateColumns = false;
            dgvComplaintSummary.DataSource = dtComplaintRegister;
        }
        #endregion

        private void dgvComplaintSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            foreach (DataGridViewRow r in dgv.Rows)
            {
                // Row Number
                dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                // Bind Subject Into colSubject
                int ComplaintReceiveID = (int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colComplaintReceivedID.Index].Value, typeof(int), -1);

                string UsedPeriod = (string)DataTypeParser.Parse(dtComplaintRegister.Rows[r.Index]["UsedPeriod"], typeof(string), null);
                string UsageNature = (string)DataTypeParser.Parse(dtComplaintRegister.Rows[r.Index]["UsageNature"], typeof(string), null);
                string UsingHour = (string)DataTypeParser.Parse(dtComplaintRegister.Rows[r.Index]["UsingHour"], typeof(string), null);
                string ActionByReseller = (string)DataTypeParser.Parse(dtComplaintRegister.Rows[r.Index]["ActionByReseller"], typeof(string), null);
                string ResellerRemark = (string)DataTypeParser.Parse(dtComplaintRegister.Rows[r.Index]["ResellerRemark"], typeof(string), null);

                DataTable dtProductInComplaintReceive = new ComplaintReceiveBL().GetProductInComplaintReceiveBYComplaintReceiveID(ComplaintReceiveID);
                string Subject = string.Empty;
                foreach (DataRow row in dtProductInComplaintReceive.Rows)
                {
                    string Product = string.IsNullOrEmpty(row["ProductName"].ToString()) ? string.Empty : "ထုတ်ကုန်အမည် − (" + row["ProductName"].ToString() + ")";
                    string Qty = string.IsNullOrEmpty(row["Qty"].ToString()) ? string.Empty : " - (" + row["Qty"].ToString() + " Nos" + ") , ";
                    string ProductionDate = string.IsNullOrEmpty(row["ProductionDate"].ToString()) ? string.Empty : "PD Date - ( " + row["ProductionDate"].ToString() + ") , \r\n";
                    string ComplaintCase = string.IsNullOrEmpty(row["ComplaintCase"].ToString()) ? string.Empty : "ဖြစ်ပေါ်လာသည့်ကိစ္စ − (" + row["ComplaintCase"].ToString() + ") , ";

                    // Subject
                    Subject += Product + Qty + ProductionDate + ComplaintCase + "\r\n";
                }

                Subject += string.IsNullOrEmpty(UsedPeriod) ? string.Empty : "အသုံးပြုသည့်ကာလ − (" + UsedPeriod + ") , ";
                Subject += string.IsNullOrEmpty(UsageNature) ? string.Empty : UsageNature + ", ";
                Subject += string.IsNullOrEmpty(UsingHour) ? string.Empty : UsingHour + ",";
                Subject += string.IsNullOrEmpty(ActionByReseller) ? string.Empty : ActionByReseller + ",";
                Subject += string.IsNullOrEmpty(ResellerRemark) ? string.Empty : ResellerRemark + "။";

                dgv.Rows[r.Index].Cells[colSubject.Index].Value = Subject;


                //  Bind Explanation , Action && Comment
                int ComplaintRegisterID = (int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colComplaintRegisterID.Index].Value, typeof(int), -1);

                DataTable dtComplaintExplanation = new ComplaintRegisterBL().GetComplaintExplanationByComplaintRegisterID(ComplaintRegisterID);
                string ExplanAction = string.Empty;
                int ExplanNo = 1;
                foreach (DataRow row in dtComplaintExplanation.Rows)
                {
                    string Explan = string.IsNullOrEmpty(row["Explanation"].ToString()) ? string.Empty : "(" + ExplanNo + ") " + row["Explanation"].ToString() + " ";
                    string Action = string.IsNullOrEmpty(row["Action"].ToString()) ? string.Empty : row["Action"].ToString() + " ";

                    //  Explan && Action
                    ExplanAction += Explan + Action + "\r\n";
                    ExplanNo++;
                }

                DataTable dtComplaintComment = new ComplaintRegisterBL().GetComplaintCommentByComplaintRegisterID(ComplaintRegisterID);
                string Comments = string.Empty;
                int CommentNo = 1;
                foreach (DataRow row in dtComplaintComment.Rows)
                {
                    string Comment = string.IsNullOrEmpty(row["Comment"].ToString()) ? string.Empty : "(" + CommentNo + ") " + row["Comment"].ToString() + " ";
                    //  Explan && Action
                    Comments += Comment;
                    CommentNo++;
                }

                string TempComments = string.IsNullOrEmpty(Comments) ? string.Empty : "Comments- " + Comments;
                String ExplanActionComment = ExplanAction + TempComments;

                dgv.Rows[r.Index].Cells[colExplanComment.Index].Value = ExplanActionComment;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNBind(dtpReceivedDate);
        }

        private void dgvComplaintSummary_Paint(object sender, PaintEventArgs e)
        {
            var dgv = sender as DataGridView;

            string[] columns = { "", "", "", "Action", "Action","" };
            for (int j = 0; j < 10; )
            {
                Rectangle r1 = dgv.GetCellDisplayRectangle(colReceivedBy.Index, -1, true);
                int w2 = dgv.GetCellDisplayRectangle(colWhen.Index, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(columns[j / 2],
                dgv.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
                j += 2;
            }
        }

        private void dgvComplaintSummary_Scroll(object sender, ScrollEventArgs e)
        {
            var dgv = sender as DataGridView;
            Rectangle rtHeader = dgv.DisplayRectangle;
            rtHeader.Height = dgv.ColumnHeadersHeight / 2;
            dgv.Invalidate(rtHeader);
        }

        private void dgvComplaintSummary_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var dgv = sender as DataGridView;
            Rectangle rtHeader = dgv.DisplayRectangle;
            rtHeader.Height = dgv.ColumnHeadersHeight / 2;
            dgv.Invalidate(rtHeader);
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmComplaintPage));
            this.Close();
        }
       
    }
}
