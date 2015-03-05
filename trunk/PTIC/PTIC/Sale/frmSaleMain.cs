/*  Author  :   Aung KO KO
     Date     :   9 Feb 2014
     Description    :  frmSaleMain is MDIParent of Sale Forms
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Reflection;

using PTIC.Sale.Setup;
using PTIC.VC.Auth;

namespace PTIC.VC.Sale
{
    public partial class frmSaleMain : Form
    {
        public frmLogin frmLogin;
        private frmDockMenu m_Dock = new frmDockMenu();

        public frmSaleMain()
        { // Binding DockMenu in dockPanel && Declare Global use dockPanel
            InitializeComponent();
         //   GlobalCache.MenuContainer = dockPanel;
            m_Dock.CloseButtonVisible = false;
            m_Dock.Dock = System.Windows.Forms.DockStyle.Left;
            m_Dock.Show(dockPanel, DockState.DockLeft);              
          }
             
        public frmSaleMain(frmLogin frmLogin):this()
        {
            this.frmLogin = frmLogin;
            this.frmLogin.Visible = false;
        }

        private void frmSaleMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frmLogin.Close();
        }

        private void menustripHO_Click(object sender, EventArgs e)
        {
           // m_Dock.Show(dockPanel);
        }
        
        private void mstripRequestPro_Click(object sender, EventArgs e)
        { // Show  SaleSetup Form in dockPanel
                    
        }        
    }
}
