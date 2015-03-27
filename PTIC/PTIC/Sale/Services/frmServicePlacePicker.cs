using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Util;
using System.Linq;

namespace PTIC.VC.Sale.Services
{
    public partial class frmServicePlacePicker : Form
    {
        private bool _occuredChanges;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ServicePlaceSelectHandler(object sender, ServicePlaceSelectEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public ServicePlaceSelectHandler ServicePlaceSelectedHandler;

        /// <summary>
        /// SalesService Record
        /// </summary>
        /// 
        public SalesService _salesService = null;

        /// <summary>
        /// ServiceStatus Record
        /// </summary>
        /// 
        public ServiceBatteryStatus _serviceStatus = null;

        /// <summary>
        /// PlaceToTransfer
        /// </summary>
        /// 
        public int _placeToTransfer = 0;

        /// <summary>
        /// DataTable Van
        /// </summary>
        /// 
        public DataTable dtVan = null;

        /// <summary>
        /// DataTable Warehouse
        /// </summary>
        /// 
        public DataTable dtWarehouse = null;
        public DataTable dtShowRoom = null;

        /// <summary>
        /// Variable TransportedWarehouseID
        /// </summary>
        public int? TransportedWarehouseID = null;

        /// <summary>
        /// Variable TransportedVenID
        /// </summary>
        /// 
        public int? TransportedVenID = null;

        List<SalesService> salesService = new List<SalesService>();
        List<ServiceBatteryStatus> serviceBatteryStatus = new List<ServiceBatteryStatus>();
        
        #region Private Methods
        private void LoadData()
        {            
            try
            {                
                // Load Vehicles
                dtVan = new VehicleBL().GetAll();
                //  Load SubStore
                dtWarehouse = new WarehouseBL().GetAll();

                dtShowRoom = new WarehouseBL().GetShowRoom();
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._salesService.ID != 0)
            {
                DateTime validDateTime = new SalesServiceBL().GetValidLastTime(_salesService.ID);
                if (validDateTime.Date != new DateTime(1, 1, 1).Date)
                {
                    if (validDateTime.Date > dtTransferOrReturnDate.Value.Date)
                    {
                        MessageBox.Show(string.Format("Invalid Date! The Latest processed date is {0}", validDateTime), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }
                }

            }

            if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle)
            {
                this.TransportedVenID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            else if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom)
            {
                this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            else
            {
                this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            
            int sup = 0;
            try
            {
               
                if (salesService.Count > 0 && serviceBatteryStatus.Count > 0)
                {
                    DateTime ReturnDate = (DateTime)DataTypeParser.Parse(dtTransferOrReturnDate.Value, typeof(DateTime), DateTime.Now);
                    sup = new SalesServiceBL().SalesServiceTransferReturnInsert(this.salesService, this.serviceBatteryStatus, ReturnDate, TransportedWarehouseID, TransportedVenID, GlobalCache.LoginUser.EmpID, this._placeToTransfer);
                }
                else
                {
                    this._salesService.ReturnedDate = (DateTime)DataTypeParser.Parse(dtTransferOrReturnDate.Value, typeof(DateTime), DateTime.Now);
                    sup = new SalesServiceBL().SalesServiceTransferReturnInsert(this._salesService, this._serviceStatus, TransportedWarehouseID, TransportedVenID, GlobalCache.LoginUser.EmpID, this._placeToTransfer);
                }
                if (sup > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.Green);
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();                
            }
        }

        private void frmServicePlacePicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ServicePlaceSelectedHandler == null)
                return;
            ServicePlaceSelectEventArgs eArg = new ServicePlaceSelectEventArgs(this._occuredChanges);
            ServicePlaceSelectedHandler(this, eArg);
        }
        #endregion

        #region Constructors
        public frmServicePlacePicker()
        {
            InitializeComponent();
        }

        public frmServicePlacePicker(List<SalesService> salesService,List<ServiceBatteryStatus> serviceBatteryStatus, int PlaceToTransfer)
            : this()
        {
            this.salesService = salesService;
            this.serviceBatteryStatus = serviceBatteryStatus;
            this._placeToTransfer = PlaceToTransfer;

            // Selcet Max Date list from salesService List
            var maxReceivedList = salesService.Where(s => s.ReceivedDate == salesService.Max(x => x.ReceivedDate))
                        .FirstOrDefault();

            dtTransferOrReturnDate.MinDate = Convert.ToDateTime(maxReceivedList.ReceivedDate);
            
            LoadData();          
           
            if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle)
            {
                cmbVanOrWarehouse.DataSource = dtVan;
                cmbVanOrWarehouse.DisplayMember = "VenNo";
                cmbVanOrWarehouse.ValueMember = "VehicleID";
                //this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle;
                //this.TransportedVenID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            else if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom)
            {
                cmbVanOrWarehouse.DataSource = dtWarehouse;
                cmbVanOrWarehouse.DisplayMember = "Warehouse";
                cmbVanOrWarehouse.ValueMember = "WarehouseID";
               // this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom;
                //this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            else if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore)
            {
                cmbVanOrWarehouse.DataSource = dtWarehouse;
                cmbVanOrWarehouse.DisplayMember = "Warehouse";
                cmbVanOrWarehouse.ValueMember = "WarehouseID";
               // this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore;
                //this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            else
            {
                cmbVanOrWarehouse.DataSource = dtWarehouse;
                cmbVanOrWarehouse.DisplayMember = "Warehouse";
                cmbVanOrWarehouse.ValueMember = "WarehouseID";
               // this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore;
                //this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
            }
            cmbVanOrWarehouse.SelectedValue = 1;
            cmbVanOrWarehouse.Enabled = false;
        }


       //public frmServicePlacePicker(SalesService _salesService, ServiceBatteryStatus _serviceBatteryStatus,int PlaceToTransfer)
       //    :this()
        public frmServicePlacePicker(SalesService _salesService, ServiceBatteryStatus _serviceBatteryStatus, int PlaceToTransfer)
            : this()
       {
           this._salesService = _salesService;
           this._serviceStatus = _serviceBatteryStatus;
           this._placeToTransfer = PlaceToTransfer;           
           LoadData();
           if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle)
           {
               cmbVanOrWarehouse.DataSource = dtVan;
               cmbVanOrWarehouse.DisplayMember = "VenNo";
               cmbVanOrWarehouse.ValueMember = "VehicleID";            
            //   this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle;
               //this.TransportedVenID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
           }
           else if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom)
           {               
               cmbVanOrWarehouse.DataSource = dtShowRoom;
               cmbVanOrWarehouse.DisplayMember = "Warehouse";
               cmbVanOrWarehouse.ValueMember = "WarehouseID";
              
               cmbVanOrWarehouse.Enabled = true;
              // this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom;
               //this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
           }
           else if (_placeToTransfer == (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore)
           {
               cmbVanOrWarehouse.DataSource = dtWarehouse;
               cmbVanOrWarehouse.DisplayMember = "Warehouse";
               cmbVanOrWarehouse.ValueMember = "WarehouseID";
               cmbVanOrWarehouse.SelectedValue = (int)PTIC.Common.Enum.PredefinedWarehouse.FactoryMainStoreID;
               cmbVanOrWarehouse.Enabled = false;
               //this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore;
               //this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
           }
           else
           {
               cmbVanOrWarehouse.DataSource = dtWarehouse;
               cmbVanOrWarehouse.DisplayMember = "Warehouse";
               cmbVanOrWarehouse.ValueMember = "WarehouseID";
               cmbVanOrWarehouse.SelectedValue = (int)PTIC.Common.Enum.PredefinedWarehouse.SSBSubStoreID;
               cmbVanOrWarehouse.Enabled = false;
              // this._salesService.Whereami = (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore;
               //this.TransportedWarehouseID = (int?)DataTypeParser.Parse(cmbVanOrWarehouse.SelectedValue, typeof(int), null);
           }
       }
        #endregion

        #region Inner Classes        
        public class ServicePlaceSelectEventArgs : EventArgs 
        {
            private bool _occuredChanges;
            public ServicePlaceSelectEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

    }
}
