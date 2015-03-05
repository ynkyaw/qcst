/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/06 (yyyy/MM/dd)
 * Description: Stock InOut of vehicle
 */
using System;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Common.BL;
using PTIC.Common;

namespace PTIC.VC.Sale.Inventory
{
    /// <summary>
    /// Stock InOut of vehicle
    /// </summary>
    public partial class frmVanStockList : Form
    {
        /// <summary>
        /// Logger for frmVanStockList
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmVanStockList));

        #region Events
        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        private void dgvVanInList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        private void dgvVanOutList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Key words
            DateTime kwDate = dtpDate.Value; // TODO: check date not be MinDate
            int kwVehID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), 0);
            if (kwVehID == 0)
                return;
            SearchVenInOut(kwVehID, kwDate);
        }
        #endregion

        #region Private Methods
        private void LoadVehicles()
        {            
            try
            {                
                // Load and bind vehicles
                cmbVehicle.DataSource = new VehicleBL().GetAll();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }           
        }

        private void SearchVenInOut(int kwVehID, DateTime kwDate)
        {
            try
            {
                dgvVanInList.DataSource = new ReportBL().GetVenIn(kwVehID, kwDate);
                dgvVanOutList.DataSource = new ReportBL().GetVenOut(kwVehID, kwDate);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(Resource.FailedToLoadData, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Constructors
        public frmVanStockList()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Load vehicles
            LoadVehicles();
            // Disable auto-generating columns
            dgvVanInList.AutoGenerateColumns = false;
            dgvVanOutList.AutoGenerateColumns = false;
        }
        #endregion
                
    }
}
