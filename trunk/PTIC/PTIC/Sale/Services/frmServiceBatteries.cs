/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/18 (yyyy/MM/dd)
 * Description: Service Batteries
 */
using System;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.Common.BL;
using PTIC.VC.Util;
using System.Data;
using PTIC.VC.Sale.Services;
using PTIC.Sale.Entities;
using PTIC.Util;

namespace PTIC.Sale.Services
{
    public partial class frmServiceBatteries : Form
    {
        /// <summary>
        /// Logger for frmServiceBatteries
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmServiceBatteries));
        DataTable dtSalesServiceStatus = null;

        #region Events
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

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServicePages));
            this.Close();
        }

        private void dgvServiceBatteries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            
            //Convert enum int to human-readable text
            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    if ((int)DataTypeParser.Parse(row.Cells["colIsDelivered"].Value, typeof(int), 0) == 1)
            //        row.Cells["colStatus"].Value = Resource.Delivered;
            //    else
            //        row.Cells["colStatus"].Value = Resource.Undelivered;
            //}
            // Set row number
            if (null != dgv)
            {
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }
        #endregion

        #region Private Methods
        private void LoadServiceBatteries()
        {
            try
            {
                this.dgvServiceBatteries.DataSource = new ReportBL().GetServiceBatteries();

                dtSalesServiceStatus = new ReportBL().GetSalesServiceDetails();
            }
            catch (Exception sqle)
            {
                _logger.Error(sqle);
                throw;
            }
        }

        private DataTable GetCustomerSalesService()
        {
            DataTable dt = new DataTable();
            DataColumn colService = new DataColumn("Service", typeof(int));
            DataColumn colDespt = new DataColumn("Despt", typeof(string));
            dt.Columns.AddRange(new DataColumn[] 
            { 
                colService, colDespt
            });
            DataRow nRow = dt.NewRow();
            nRow["Service"] = (int)PTIC.Common.Enum.CustomerSalesService.NewBattery;
            nRow["Despt"] = Resource.NewBattery;
            dt.Rows.Add(nRow);

            nRow = dt.NewRow();
            nRow["Service"] = (int)PTIC.Common.Enum.CustomerSalesService.CVC_Battery;
            nRow["Despt"] = Resource.CVC_Battery;
            dt.Rows.Add(nRow);

            nRow = dt.NewRow();
            nRow["Service"] = (int)PTIC.Common.Enum.CustomerSalesService.Repair;
            nRow["Despt"] = Resource.Repair;
            dt.Rows.Add(nRow);

            nRow = dt.NewRow();
            nRow["Service"] = (int)PTIC.Common.Enum.CustomerSalesService.Other;
            nRow["Despt"] = Resource.Other;
            dt.Rows.Add(nRow);
            return dt;
        }
        #endregion

        #region Constructors
        public frmServiceBatteries()
        {
            InitializeComponent();
            // Disable auto generating columns
            this.dgvServiceBatteries.AutoGenerateColumns = false;
            // Configure logger
            XmlConfigurator.Configure();
            // Set customer sales service
            this.colService.DataSource = GetCustomerSalesService();
            this.colService.ValueMember = "Service";
            this.colService.DisplayMember = "Despt";
            // Load service batteries
            LoadServiceBatteries();
        }        
        #endregion

        private void btnDetail_Click(object sender, EventArgs e)
        {
         //   var gv = sender as DataGridView;
            var gv = dgvServiceBatteries as DataGridView;
            DataGridViewRow row = gv.Rows[gv.CurrentRow.Index];      
            if (row == null)
                return;
            int SalesServiceID = (int)DataTypeParser.Parse(row.Cells[colSaleServicedID.Index].Value, typeof(int), -1);
            DataTable dt = DataUtil.GetDataTableBy(this.dtSalesServiceStatus, "SalesServiceID", SalesServiceID);
            if (dt == null) return;
            SalesService salesService = new SalesService()
            {
                ID = (int)DataTypeParser.Parse(dt.Rows[0]["SalesServiceID"], typeof(int), -1),
                ServicedCustomerID = (int)DataTypeParser.Parse(dt.Rows[0]["ServicedCustomerID"], typeof(int), -1),
                //SvcFactID = (int?)DataTypeParser.Parse(row.Cells[colSvcFactID.Index].Value, typeof(int), null),
                SalesServiceNo = (string)DataTypeParser.Parse(dt.Rows[0]["SalesServiceNo"], typeof(string), string.Empty),
                ReceivedDate = (DateTime)DataTypeParser.Parse(dt.Rows[0]["ReceivedDate"], typeof(DateTime), DateTime.MinValue),
                ReturnedDate = (DateTime)DataTypeParser.Parse(dt.Rows[0]["ReturnedDate"], typeof(DateTime), DateTime.MinValue),
                ProductionDate = (string)DataTypeParser.Parse(dt.Rows[0]["ProductionDate"], typeof(string), string.Empty),
                PurchaseDate = (string)DataTypeParser.Parse(dt.Rows[0]["PurchaseDate"], typeof(string), string.Empty),
                TakerID = (int?)DataTypeParser.Parse(dt.Rows[0]["TakerID"], typeof(int), null),
                ProductID = (int)DataTypeParser.Parse(dt.Rows[0]["ProductID"], typeof(int), -1),
                //UserName = (string)DataTypeParser.Parse(row.Cells[colUserName.Index].Value, typeof(string), string.Empty),
                //ContactPersion = (string)DataTypeParser.Parse(row.Cells[colContactPersion.Index].Value, typeof(string), string.Empty),
                //PhNo1 = (string)DataTypeParser.Parse(row.Cells[colPhNo1.Index].Value, typeof(string), string.Empty),
                //PhNo2 = (string)DataTypeParser.Parse(row.Cells[colPhNo2.Index].Value, typeof(string), string.Empty),
                JobCardNo = (string)DataTypeParser.Parse(dt.Rows[0]["JobCardNo"], typeof(string), string.Empty),
                WarrantyNo = (string)DataTypeParser.Parse(dt.Rows[0]["WarrantyNo"], typeof(string), string.Empty),
                Whereami = (int?)DataTypeParser.Parse(dt.Rows[0]["Whereami"], typeof(int), null),
                IsBackward = (bool)DataTypeParser.Parse(dt.Rows[0]["IsBackward"], typeof(bool), false),
                IsReturned = (bool)DataTypeParser.Parse(dt.Rows[0]["IsReturned"],typeof(bool),false)
            };

            if (salesService.ID == -1)
            {
                MessageBox.Show("Cannot open detail form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServiceBatteryStatus serviceStatus = new ServiceBatteryStatus()
            {
                CurrentVehicleID = (int?)DataTypeParser.Parse(dt.Rows[0]["CurVehicleID"], typeof(int), null),
                CurrentWarehouseID = (int?)DataTypeParser.Parse(dt.Rows[0]["CurWarehouseID"], typeof(int), null),
                CurrentServiceTeamID = (int?)DataTypeParser.Parse(dt.Rows[0]["CurServiceTeamID"], typeof(int), null),
                CurrentMainStoreID = (int?)DataTypeParser.Parse(dt.Rows[0]["CurMainStoreID"], typeof(int), null),

                InForwardShowroom = (bool)DataTypeParser.Parse(dt.Rows[0]["InShowroom"], typeof(bool), false),
                InForwardVehicle = (bool)DataTypeParser.Parse(dt.Rows[0]["InVehicle"], typeof(bool), false),
                InForwardServiceTeam = (bool)DataTypeParser.Parse(dt.Rows[0]["InServiceTeam"], typeof(bool), false),
                InForwardMainStore = (bool)DataTypeParser.Parse(dt.Rows[0]["InMainStore"], typeof(bool), false),

                InBackwardShowroom = (bool)DataTypeParser.Parse(dt.Rows[0]["InBackShowroom"], typeof(bool), false),
                InBackwardVehicle = (bool)DataTypeParser.Parse(dt.Rows[0]["InBackVehicle"], typeof(bool), false),
                InBackwardServiceTeam = (bool)DataTypeParser.Parse(dt.Rows[0]["InBackServiceTeam"], typeof(bool), false),
               // InBackwardMainStore = (bool)DataTypeParser.Parse(row.Cells[colInBackMainStore.Index].Value, typeof(bool), false)
            };
            string brandName = (string)DataTypeParser.Parse(dt.Rows[0]["BrandName"], typeof(string), string.Empty);
            string productName = (string)DataTypeParser.Parse(dt.Rows[0]["ProductName"], typeof(string), string.Empty);     
            frmServiceBatteryDetail frmDetail = new frmServiceBatteryDetail(salesService, serviceStatus, brandName, productName);
            // TODO: set call back handler
            UIManager.MdiChildOpenForm(frmDetail);
        }
                
        
    }
}
