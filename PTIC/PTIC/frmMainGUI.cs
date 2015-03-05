using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Auth;


namespace PTIC.VC
{
    public partial class frmMainGUI : Form
    {
        public frmMainGUI()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        { // Sale Department
            frmLogin Login = new frmLogin(Program.Module.Sale);
            Login.Show();
            this.Visible = false;
        }

        private void btnMarketing_Click(object sender, EventArgs e)
        { // Marketin Department
            frmLogin Login = new frmLogin(Program.Module.Marketing);
            Login.Show();
            this.Visible = false;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        { // Admin/HR Department
            //frmLogin Login = new frmLogin(this);
            //Login.Show();
            //this.Visible = false;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void frmMainGUI_Load(object sender, EventArgs e)
        {
            Program.frmMainGUI = this;
            // Edited by YNK
            // Edited Start
            bool isConnected = false;
            while (!isConnected)
            {
                try
                {
                    isConnected = CheckDatabase();
                }
                catch
                {
                }
                if (isConnected)
                    break;
                DialogResult ds = MessageBox.Show(this, "Please check Network and Database Setting!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (ds == System.Windows.Forms.DialogResult.Cancel)
                {
                    System.Environment.Exit(0);
                }
            }
            //Edited End

            // Old Code
            //while (!CheckDatabase())
            //{
            //    DialogResult ds = MessageBox.Show(this,"Please check Network and Database Setting!","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            //    if (ds == System.Windows.Forms.DialogResult.Cancel)
            //    {
            //        System.Environment.Exit(0);
            //    }
            //}
            //End Of Old Code
        }         

        private bool CheckDatabase()
        {
            System.Data.SqlClient.SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            if (conn.State == ConnectionState.Open){
                DBManager.GetInstance().CloseDbConnection();
                return true;
            }
            else
            {
                return false;
			}
        }


    }
}
