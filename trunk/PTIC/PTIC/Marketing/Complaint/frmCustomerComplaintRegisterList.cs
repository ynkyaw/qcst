using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.VC.Util;

namespace PTIC.Marketing.Complaint
{
    public partial class frmCustomerComplaintRegisterList : Form
    {
        DataTable dtComplaintRegister = null;

        public frmCustomerComplaintRegisterList()
        {
            InitializeComponent();
            LoadNBind(dtpReceivedDate);
        }

        #region Private Methods
        
        private void LoadNBind(DateTimePicker dtpReceivedDate)
        {
            //  Bind Complaint Register
            dtComplaintRegister = new ComplaintRegisterBL().GetSComplaintRegisteByReceiveDate(dtpReceivedDate.Value.Month, dtpReceivedDate.Value.Year);
            // Auto-Generate Columns false
            dgvComplaintRegisterList.AutoGenerateColumns = false;
            dgvComplaintRegisterList.DataSource = dtComplaintRegister;
        }
        #endregion

        private void dgvComplaintRegisterList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            //int i = 0;
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
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNBind(dtpReceivedDate);
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmComplaintPage));
            this.Close();
        }
    }
}
