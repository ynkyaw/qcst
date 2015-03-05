using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.VC.Marketing;


namespace PTIC.Sale.Setup
{
    public partial class frmRoute : Form
    {
        private BindingSource routeBindingSource = new BindingSource();
        private BindingSource townshipinrouteBindingSource = new BindingSource();
        DataTable townshipTbl = null;
        //DataTable routeTbl = null;
        //DataTable townshipintripTbl = null;
        Route route = new Route();
        TownshipInRoute townshipinroute = new TownshipInRoute();
        bool IsMarketing = false;
        public frmRoute()
        {
            InitializeComponent();
                     
        }

        public frmRoute(bool IsTrue)
            : this()
        {
            IsMarketing = IsTrue;
        }

    

        #region Event Handler


      

        

        private void lblSetup_Click(object sender, EventArgs e)
        {
            if (IsMarketing == true)
            {
                UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
                this.Close();
            }
            else
            {
                UIManager.MdiChildOpenForm(typeof(frmSetupPage));
                this.Close();
            }
        }

       
        #endregion

        private void frmRoute_Load(object sender, EventArgs e)
        {
            InitLoad();
        }

        private void InitLoad()
        {
            try
            {
                DataTable routeTbl = new RouteBL().GetTownList();
                dgvsetuproute.DataSource = routeTbl;
                dgvsetuproute.AutoGenerateColumns = false;

            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            frmRouteDetails frmDetail = new frmRouteDetails();
            frmDetail.ShowDialog(this);
            InitLoad();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvsetuproute.SelectedRows.Count != 1) 
            {
                MessageBox.Show("Please Select Only One Row To Edit!");
                return;
            
            }
            int routeId = int.Parse(dgvsetuproute.SelectedRows[0].Cells[dgvColRouteId.Index].Value.ToString());
            frmRouteDetails frmDetail = new frmRouteDetails(routeId);
            frmDetail.ShowDialog(this);
            InitLoad();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        
    }
}
