/******************************************
 *  Created Date       :    30/06/2015
 *  Created By         :  Yan Naing Kyaw
 *  Last Updated Date  :        -
 *  Edited By          :        -
 *  Version            :      1.0.1
 * *****************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProvenCashCollectionUpdater
{
    public partial class frmCashCollectionTools : Form
    {
        #region Inner Class
        protected class CustomerCreditBalanec 
        {
            private int _cusId;
            public int CusID 
            {
                get { return _cusId; }
                set { _cusId = value; }
            }
            private decimal _balanceAmt;
            public decimal BalanceAmount 
            {
                get { return _balanceAmt; }
                set
                {
                    if (value < 0)
                        throw new Exception("Invalid Balance Amount!");
                    _balanceAmt = value;
                }
            }
        }
        #endregion

        #region Variable Declaration
        private List<CustomerCreditBalanec> recordList = new List<CustomerCreditBalanec>();
        #endregion

        #region Constructor
        public frmCashCollectionTools()
        {
            InitializeComponent();
            txtFilePath.Enabled = false;
            rtxtLog.ReadOnly=true;
            dgvCustomerList.Enabled = false;
        }
        #endregion

        #region Events

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void btnRunUpdate_Click(object sender, EventArgs e)
        {
            if (recordList.Count == 0)
            {
                MessageBox.Show(ProvenCashCollectionUpdater.Properties.Settings.Default.MS0001); //1.1
                return;
            }
            Progress.Value = 0;
            Progress.Minimum = 0;
            Progress.Maximum = recordList.Count;
            new System.Threading.Thread(UpdateReciept).Start();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            bool isValidFile = IsValidSelectedFile(openFileDialog.FileName); // 1

            if (!isValidFile)  
            {
                MessageBox.Show(ProvenCashCollectionUpdater.Properties.Settings.Default.MS0003); //1.1
                return;
            }
            else
            {
                txtFilePath.Text = openFileDialog.FileName; //1.2
            }

            List<string> lines = System.IO.File.ReadAllLines(txtFilePath.Text).ToList();
            lines.RemoveAt(0); // remove header text from list

            foreach (string line in lines) 
            {
                if (String.IsNullOrEmpty(line.Trim()))
                    break;

                string[] cols = line.Split(',');
                int cusId = 0;
                decimal balanceAmt = 0;
                if (int.TryParse(cols[0], out cusId) && decimal.TryParse(cols[1], out balanceAmt)) //Checking Data line contain valid int,decimal format
                {
                    try
                    {
                        CustomerCreditBalanec rec = new CustomerCreditBalanec()
                        {
                            CusID = cusId,
                            BalanceAmount = balanceAmt
                        };
                        recordList.Add(rec);
                    }
                    catch (Exception ex) 
                    {
                        recordList.Clear();
                        MessageBox.Show(ProvenCashCollectionUpdater.Properties.Settings.Default.MS0003);
                        return;
                    }
                }
                else 
                {
                    MessageBox.Show(ProvenCashCollectionUpdater.Properties.Settings.Default.MS0003);
                    return;
                }
            
            }

            dgvCustomerList.DataSource = recordList;

        }

        #endregion

        #region Private Methods
        private bool IsValidSelectedFile(string fileName)
        {
            if (!String.IsNullOrEmpty(openFileDialog.FileName) && System.IO.File.Exists(openFileDialog.FileName) && System.IO.Path.GetExtension(openFileDialog.FileName) == ".csv")
            {
                string[] lines = System.IO.File.ReadAllLines(fileName, System.Text.ASCIIEncoding.UTF8);
                if (lines.Length > 1) 
                {
                    string firstLine = lines[0];
                    string[] cols = firstLine.Split(',');
                    if (cols.Length == 2)
                    {
                        if (cols[0] == "CusID" && cols[1] == "BalanceAmount")
                        {
                            return true;                        
                        }
                    }
                }
            }
            return false;

        }

        private void UpdateReciept()
        {

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("items",
            System.Reflection.Assembly.GetExecutingAssembly());
            // Retrieve the value of the string resource named "welcome".
            // The resource manager will retrieve the value of the  
            // localized resource using the caller's current culture setting.
            String conStr = ProvenCashCollectionUpdater.Properties.Settings.Default.DbConnStr;

            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            System.Data.SqlClient.SqlTransaction trans = null;
            conn.ConnectionString = conStr;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();
                foreach (CustomerCreditBalanec rec in recordList)
                {
                    string invoiceSelectQuery = rm.GetString("InvoiceSelectQuery");
                    string query = string.Format(invoiceSelectQuery, rec.CusID, rec.BalanceAmount);
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn, trans);
                    System.Data.SqlClient.SqlDataReader rd = cmd.ExecuteReader();
                    if (rd != null && rd.Read()) 
                    {
                        int invoiceId = (int)rd["ID"];
                        decimal balanceAmt = (decimal)rd["BALANCE_AMT"];






                    }


                }
            }
            catch (Exception err)
            {
                if (conn.State == ConnectionState.Open) 
                {
                    if (trans != null)
                        trans.Rollback();
                    conn.Close();
                }

            }
        }

        #endregion
    }
}
