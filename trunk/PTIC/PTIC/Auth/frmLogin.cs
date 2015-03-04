using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Sale;
using PTIC.VC.Sale;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.VC;
using PTIC.Marketing;
using PTIC.VC.Marketing;
using PTIC.Common.Entities;
using PTIC.Common.BL;

namespace PTIC.VC.Auth
{
    public partial class frmLogin : Form
    {
        DataTable UserTbl = null;
        bool IsValidUser = false;
        Program.Module module;
        
        public frmLogin()
        {
            InitializeComponent();
            LoadUser();
            BindUserName();
        }

        public frmLogin(Program.Module module)
            : this()
        {
            this.module = module;
        }

        //public frmLogin(frmMainGUI frmMain)
        //{
        //    // TODO: Complete member initialization
        //    InitializeComponent();
        //    this.frmMain = frmMain;
           
        //}

        private void LoadUser()
        { 
            // LoadUser as Datatable
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                UserTbl = new PTIC.Sale.BL.UserBL().GetAll(conn);
            }
            catch
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void BindUserName()
        { // Bind User Data to UserLogin Form
            if (this.UserTbl == null) return;

            cboUserName.DataSource = this.UserTbl;
        }
        
        private void LogIn()
        {
            if (this.UserTbl == null)
                return;
            
            if (txtPassword.TextLength < 1)
            {
                lblErrorMessage.Text = Resource.EnterPwd;
                return;
            }

            foreach (DataRow user in this.UserTbl.Rows)
            {
                #region /* Check Is Assign */
                if (user["UserName"].ToString().Equals(cboUserName.Text) &&
                   user["Password"].ToString().Equals(txtPassword.Text))
                {
                    IsValidUser = true;
                    User loginUser = new User();                    
                    loginUser.ID = (int)DataTypeParser.Parse(user["UserID"].ToString(), typeof(int),-1);
                    loginUser.UserName = user["UserName"].ToString();
                    loginUser.Password = user["Password"].ToString();
                    //loginUser.AccessLvlID = (int)DataTypeParser.Parse(user["AccessLvlID"].ToString(),typeof(Int32),-1);
                    loginUser.EmpID = Int32.Parse(user["EmpID"].ToString());
                    loginUser.EmpName = (string)DataTypeParser.Parse(user["EmpName"].ToString(),typeof(string), null);
                    GlobalCache.LoginUser = loginUser;

                    DataTable dtEmployee = new EmployeeBL().GetByID(loginUser.EmpID);
                    if(dtEmployee.Rows.Count > 0)
                    {
                        Employee loginEmployee = new Employee() 
                    {
                        ID = (int)DataTypeParser.Parse(user["EmpID"].ToString(), typeof(int), -1),
                        EmpName = (string)DataTypeParser.Parse(user["EmpName"].ToString(),typeof(string),null),
                        DeptID = (int)DataTypeParser.Parse(dtEmployee.Rows[0]["DeptID"], typeof(int), -1)
                    };
                    GlobalCache.LoginEmployee = loginEmployee;
                    }
                    break;
                }
                #endregion /* End Check Assign */

                //if (IsValidUser)
                //{
                //    // valid user
                //    lblErrorMessage.Visible = false;
                //    this.txtPassword.Text = string.Empty;
                //    // Set working module to Program
                //    Program.module = this.module;
                //    switch(this.module)
                //    {
                //        case Program.Module.Sale:                        
                //            Program.toyo = new frmSaleMain(this);
                //            Program.toyo.Show();
                //            break;
                //        case Program.Module.Marketing:
                //            Program.marketintoyo = new frmMarketingMain(this);
                //            Program.marketintoyo.Show();
                //            break;
                //    }  
                //}
                //else
                //{
                //    txtPassword.Text = string.Empty;
                //    txtPassword.Focus();
                //    lblErrorMessage.Text = Resource.IncorrectPwd;
                //    lblErrorMessage.Visible = true;
                //}
            }// END of foreach (DataRow user in this.UserTbl.Rows)

            if (IsValidUser)
            {
                // valid user
                lblErrorMessage.Visible = false;
                this.txtPassword.Text = string.Empty;
                // Set working module to Program
                Program.module = this.module;
                switch (this.module)
                {
                    case Program.Module.Sale:
                        Program.toyo = new frmSaleMain(this);
                        Program.toyo.Show();
                        break;
                    case Program.Module.Marketing:
                        Program.marketintoyo = new frmMarketingMain(this);
                        Program.marketintoyo.Show();
                        break;
                }
            }
            else
            {
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
                lblErrorMessage.Text = Resource.IncorrectPwd;
                lblErrorMessage.Visible = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //frmMain.Visible = true;  
            Program.frmMainGUI.Visible = true;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            Program.frmMainGUI.Visible = true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LogIn();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboUserName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }      

       
    }
}
