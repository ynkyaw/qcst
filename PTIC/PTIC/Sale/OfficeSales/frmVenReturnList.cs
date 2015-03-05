using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Sale.OfficeSales;
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.VC.Sale.Inventory;
using PTIC.Common;
using PTIC.VC.Util;

namespace PTIC.Sale.OfficeSales
{
    public partial class frmVenReturnList : Form
    {
        /// <summary>
        /// Logger for frmVenReturnList
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmVenReturnList));

        #region Events
        private void lblSalePage_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }
        #endregion

        #region Private Methods
        private void LoadNBindData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dgvVenReturn.DataSource = new VehicleBL().GetVenReturn();
            }
            catch (SqlException Sqle)
            {
                _logger.Error(Sqle);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadNBindData(DateTime Date)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dgvVenReturn.DataSource = new VehicleBL().GetVenReturnByDate(Date);
            }
            catch (SqlException Sqle)
            {
                _logger.Error(Sqle);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }     
        #endregion

        #region Constructors
        public frmVenReturnList()
        {
            InitializeComponent();
            // Configure logger 
            XmlConfigurator.Configure();
            // Load and bind ven return list
            LoadNBindData();
        }
        #endregion

        private void dgvVenReturn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadNBindData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime Date = (DateTime)DataTypeParser.Parse(dtpDate.Value,typeof(DateTime),DateTime.Now);
            LoadNBindData(Date);
        }        
    }
}
