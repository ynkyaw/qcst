/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service Battery Status
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Sale.Entities;

namespace PTIC.VC.Sale.Services
{
    /// <summary>
    /// Service Battery Status Form
    /// </summary>
    public partial class frmServiceBatteryStatus : Form
    {
        /// <summary>
        /// Logger for frmServiceBatteryStatus
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmServiceBatteryStatus));

        #region Events

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServicePages));
            this.Close();
        }

        private void dgvStatus_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
                return;
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle() { BackColor = Color.LightGreen };
            // Paint the place(cell) in green, in where service item exists
            foreach (DataGridViewRow row in dgv.Rows)
            {
                int where = (int)DataTypeParser.Parse(row.Cells[colWhereami.Index].Value, typeof(int), 4);
                switch (where)
                {
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle:
                        row.Cells[colInVehicle.Index].Style = cellStyle;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom:
                        row.Cells[colInShowroom.Index].Style = cellStyle;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore:
                        row.Cells[colInServiceTeam.Index].Style = cellStyle;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore:
                        row.Cells[colInMainStore.Index].Style = cellStyle;
                        break;
                    //default: // PTIC.Common.Enum.SalesServiceWhereami.Customer
                    //    row.Cells[colIncu.Index].Style = cellStyle;
                    //    break;
                }
            }
        }

        private void dgvStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != colSvcFact.Index)
                return;
            var gv = sender as DataGridView;
            DataGridViewRow row = gv.Rows[e.RowIndex];
            if (row == null)
                return;
            SalesService salesService = new SalesService()
            {
                ID = (int)DataTypeParser.Parse(row.Cells[colSalesServiceID.Index].Value, typeof(int), -1),
                ServicedCustomerID = (int)DataTypeParser.Parse(row.Cells[colServicedCustomerID.Index].Value, typeof(int), -1),
                //SvcFactID = (int?)DataTypeParser.Parse(row.Cells[colSvcFactID.Index].Value, typeof(int), null),
                SalesServiceNo = (string)DataTypeParser.Parse(row.Cells[colSalesServiceNo.Index].Value, typeof(string), string.Empty),
                ReceivedDate = (DateTime)DataTypeParser.Parse(row.Cells[colReceivedDate.Index].Value, typeof(DateTime), DateTime.MinValue),
                ReturnedDate = (DateTime)DataTypeParser.Parse(row.Cells[colReturnedDate.Index].Value, typeof(DateTime), DateTime.MinValue),
                ProductionDate = (string)DataTypeParser.Parse(row.Cells[colProductionDate.Index].Value, typeof(string), string.Empty),
                PurchaseDate = (string)DataTypeParser.Parse(row.Cells[colPurchaseDate.Index].Value, typeof(string), string.Empty),
                TakerID = (int?)DataTypeParser.Parse(row.Cells[colTackerID.Index].Value, typeof(int), null),
                ProductID = (int)DataTypeParser.Parse(row.Cells[colProductID.Index].Value, typeof(int), -1),
                //UserName = (string)DataTypeParser.Parse(row.Cells[colUserName.Index].Value, typeof(string), string.Empty),
                //ContactPersion = (string)DataTypeParser.Parse(row.Cells[colContactPersion.Index].Value, typeof(string), string.Empty),
                //PhNo1 = (string)DataTypeParser.Parse(row.Cells[colPhNo1.Index].Value, typeof(string), string.Empty),
                //PhNo2 = (string)DataTypeParser.Parse(row.Cells[colPhNo2.Index].Value, typeof(string), string.Empty),
                JobCardNo = (string)DataTypeParser.Parse(row.Cells[colJobCardNo.Index].Value, typeof(string), string.Empty),
                WarrantyNo = (string)DataTypeParser.Parse(row.Cells[colWarrantyNo.Index].Value, typeof(string), string.Empty),
                IsReturned = (bool)DataTypeParser.Parse(row.Cells[colIsReturned.Index].Value, typeof(bool), false),
                Whereami = (int?)DataTypeParser.Parse(row.Cells[colWhereami.Index].Value, typeof(int), null),
                IsBackward = (bool)DataTypeParser.Parse(row.Cells[colIsBackward.Index].Value, typeof(bool), false)
            };

            if (salesService.ID == -1)
            {
                MessageBox.Show("Cannot open detail form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServiceBatteryStatus serviceStatus = new ServiceBatteryStatus()
            {
                CurrentVehicleID = (int?)DataTypeParser.Parse(row.Cells[colCurVehicleID.Index].Value, typeof(int), null),
                CurrentWarehouseID = (int?)DataTypeParser.Parse(row.Cells[colCurWarehouseID.Index].Value, typeof(int), null),
                CurrentMainStoreID = (int?)DataTypeParser.Parse(row.Cells[colCurMainStoreID.Index].Value, typeof(int), null),
                CurrentServiceTeamID = (int?)DataTypeParser.Parse(row.Cells[colCurServiceTeamID.Index].Value, typeof(int), null),

                InForwardShowroom = (bool)DataTypeParser.Parse(row.Cells[colInShowroom.Index].Value, typeof(bool), false),
                InForwardVehicle = (bool)DataTypeParser.Parse(row.Cells[colInVehicle.Index].Value, typeof(bool), false),
                InForwardServiceTeam = (bool)DataTypeParser.Parse(row.Cells[colInServiceTeam.Index].Value, typeof(bool), false),
                InForwardMainStore = (bool)DataTypeParser.Parse(row.Cells[colInMainStore.Index].Value, typeof(bool), false),

                InBackwardShowroom = (bool)DataTypeParser.Parse(row.Cells[colInBackShowroom.Index].Value, typeof(bool), false),
                InBackwardVehicle = (bool)DataTypeParser.Parse(row.Cells[colInBackVehicle.Index].Value, typeof(bool), false),
                InBackwardServiceTeam = (bool)DataTypeParser.Parse(row.Cells[colInBackServiceTeam.Index].Value, typeof(bool), false),
                InBackwardCustomer = (bool)DataTypeParser.Parse(row.Cells[colInBackCustomer.Index].Value, typeof(bool), false)
            };
            string brandName = (string)DataTypeParser.Parse(row.Cells[colBrand.Index].Value, typeof(string), string.Empty);
            string productName = (string)DataTypeParser.Parse(row.Cells[colProductName.Index].Value, typeof(string), string.Empty);
            frmServiceBatteryDetail frmDetail = new frmServiceBatteryDetail(salesService, serviceStatus, brandName, productName);
            // Set call back handler
            frmDetail.ServiceBatteryDetailSavedHandler += new frmServiceBatteryDetail.ServiceBatteryDetailSaveHandler(ServiceBatteryDetailSaved_CallBack);
            UIManager.MdiChildOpenForm(frmDetail);
            //LoadNBindStatus();
        }

        private void ServiceBatteryDetailSaved_CallBack(object sender, PTIC.VC.Sale.Services.frmServiceBatteryDetail.ServiceBatteryDetailEventArgs e)
        {
            if (e.OccuredChanges)
                LoadNBindStatus();
        }
        
        #endregion

        #region Private Methods
        private void LoadNBindStatus()
        {
            try
            {
                this.dgvStatus.DataSource = new ReportBL().GetServiceBatteryStatus();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }

        private void btnToFactory_Click(object sender, EventArgs e)
        {
            
            List<SalesService> saleserviceList = new List<SalesService>();
            List<ServiceBatteryStatus> serviceBatteryStatusList = new List<ServiceBatteryStatus>();

            DataTable dt = dgvStatus.DataSource as DataTable;
            var gv = dgvStatus as DataGridView;
            foreach (DataGridViewRow row in gv.SelectedRows)
            {
                SalesService saleserivice = new SalesService();
                ServiceBatteryStatus serviceStauts = new ServiceBatteryStatus();
                //saleserivice.ID = (int)DataTypeParser.Parse(row["SalesServiceID"], typeof(int), -1);
                //saleserivice.Whereami = (int)DataTypeParser.Parse(row["Whereami"], typeof(int), -1);
                //serviceStauts.InForwardMainStore = true;
                //saleserivice.ReturnedDate = DateTime.MinValue;
                //serviceStauts.CurrentWarehouseID = (int)DataTypeParser.Parse(row["CurWarehouseID"], typeof(int), -1);
                //serviceStauts.CurrentVehicleID = (int)DataTypeParser.Parse(row["CurVehicleID"], typeof(int), -1);
                //serviceStauts.CurrentServiceTeamID = (int)DataTypeParser.Parse(row["CurServiceTeamID"], typeof(int), -1);
                //serviceStauts.CurrentMainStoreID = (int)DataTypeParser.Parse(row["CurMainStoreID"], typeof(int), -1);
                if ((bool)DataTypeParser.Parse(row.Cells[colInMainStore.Index].Value, typeof(bool), false) == false)
                {
                    saleserivice.ID = (int)DataTypeParser.Parse(row.Cells[colSalesServiceID.Index].Value, typeof(int), -1);
                    saleserivice.Whereami = (int)DataTypeParser.Parse(row.Cells[colWhereami.Index].Value, typeof(int), -1);
                    saleserivice.ProductID = (int)DataTypeParser.Parse(row.Cells[colProductID.Index].Value, typeof(int), -1);
                    serviceStauts.InForwardMainStore = true;
                    saleserivice.ReturnedDate = DateTime.MinValue;
                    serviceStauts.CurrentWarehouseID = (int)DataTypeParser.Parse(row.Cells[colCurWarehouseID.Index].Value, typeof(int), -1);
                    serviceStauts.CurrentVehicleID = (int)DataTypeParser.Parse(row.Cells[colCurVehicleID.Index].Value, typeof(int), -1);
                    serviceStauts.CurrentServiceTeamID = (int)DataTypeParser.Parse(row.Cells[colCurServiceTeamID.Index].Value, typeof(int), -1);
                    serviceStauts.CurrentMainStoreID = (int)DataTypeParser.Parse(row.Cells[colCurMainStoreID.Index].Value, typeof(int), -1);
                    saleserviceList.Add(saleserivice);
                    serviceBatteryStatusList.Add(serviceStauts);
                }
                else{
                    MessageBox.Show("You can transter to factory only one time", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(saleserviceList, serviceBatteryStatusList, (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore);
            UIManager.OpenForm(servieplacepicker);
            this.Close();
        }
        #endregion

        #region Constructors
        public frmServiceBatteryStatus()
        {
            InitializeComponent();
            // Disable auto-generation column
            dgvStatus.AutoGenerateColumns = false;
            // Configure logger before use
            XmlConfigurator.Configure();
            // Load and bind data
            LoadNBindStatus();
        }
        #endregion

        
    }
}
