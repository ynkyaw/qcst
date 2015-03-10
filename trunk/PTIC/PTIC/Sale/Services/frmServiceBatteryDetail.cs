/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service battery detail
 */
using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Formatting;
using PTIC.Util;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Sale.Services
{
    /// <summary>
    /// Service battery detail form
    /// </summary>
    public partial class frmServiceBatteryDetail : Form
    {
        /// <summary>
        /// Logger for frmServiceBatteryDetail
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmServiceBatteryDetail));

        /// <summary>
        /// 
        /// </summary>
        DataTable _dtRoute = null;

        /// <summary>
        /// DataTable for Trip
        /// </summary>
        DataTable _dtTrip = null;

        /// <summary>
        /// DataTable for Town
        /// </summary>
        DataTable _dtTown = null;

        /// <summary>
        /// DataTable for Township
        /// </summary>
        DataTable _dtTownship = null;

        /// <summary>
        /// Service test ID
        /// </summary>
        private int? _svcTestID = null;

        /// <summary>
        /// Serivce fact ID
        /// </summary>
        //private int? _svcFactID = null;

        /// <summary>
        /// Sales service item
        /// </summary>
        private SalesService _salesService = null;

        /// <summary>
        /// 
        /// </summary>
        private ServiceBatteryStatus _serviceStatus = null;

        /// <summary>
        /// Service function one ID
        /// </summary>
        private int? _svcFunctionOneID = null;

        /// <summary>
        /// Service function two ID
        /// </summary>
        private int? _svcFunctionTwoID = null;

        /// <summary>
        /// Service function three ID
        /// </summary>
        private int? _svcFunctionThreeID = null;

        /// <summary>
        /// 
        /// </summary>
        private string _brandName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string _productName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private bool _occuredChanges;

        /// <summary>
        /// Employee DataTable
        /// </summary>
        DataTable dtEmployee = null;


        /// <summary>
        /// DataSet & Binding Source for Town
        /// </summary>
        DataSet ds = new DataSet();

        BindingSource bdTrip = new BindingSource();
        BindingSource bdTown = new BindingSource();

        /// <summary>
        /// DataSet & Binding Source for Township
        /// </summary>
        DataSet dsTownship = new DataSet();

        BindingSource bdRoute = new BindingSource();
        BindingSource bdTownship = new BindingSource();

        DataTable dtTownInTrip = null;
        DataTable dtTownshipInRoute = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ServiceBatteryDetailSaveHandler(object sender, ServiceBatteryDetailEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event ServiceBatteryDetailSaveHandler ServiceBatteryDetailSavedHandler;
        //private frmServiceReceiveReturn.ServiceReceivedReturnHandler ServiceReturn_CallBack;
        
        #region Events
        private void btnVen_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = false;
            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle);
            servieplacepicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(servieplacepicker);
        }

        private void ServicePlaceSelect_CallBack(object sender, PTIC.VC.Sale.Services.frmServicePlacePicker.ServicePlaceSelectEventArgs e)
        {
            if (e.OccuredChanges)
            {
                this._occuredChanges = e.OccuredChanges;            
                this.Close();
            }
        }

        private void btnShowRoom_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = false;
            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom);
            servieplacepicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(servieplacepicker);
           
        }

        private void btnSubStore_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = false;
            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore);
            servieplacepicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(servieplacepicker);           
            
        }

        private void btnFactory_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = false;
            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(_salesService,_serviceStatus,(int)PTIC.Common.Enum.SalesServiceWhereami.MainStore);
            servieplacepicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(servieplacepicker);
        }

        private void btnBackFactory_Click(object sender, EventArgs e)
        {
            //frmServicePlacePicker servieplacepicker = new frmServicePlacePicker();
            //UIManager.OpenForm(servieplacepicker);
        }

        private void btnBackSubStore_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = true;
            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore);
            servieplacepicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(servieplacepicker);
        }

        private void btnBackShowRoom_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = true;
            frmServicePlacePicker servieplacepicker = new frmServicePlacePicker(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom);
            servieplacepicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(servieplacepicker);
        }

        private void btnBackVen_Click(object sender, EventArgs e)
        {
            _salesService.IsBackward = true;
            frmServicePlacePicker _frmServicePlacePicker = new frmServicePlacePicker(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle);
            _frmServicePlacePicker.ServicePlaceSelectedHandler += new frmServicePlacePicker.ServicePlaceSelectHandler(ServicePlaceSelect_CallBack);
            UIManager.OpenForm(_frmServicePlacePicker);
        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////if (cmbTownship.SelectedIndex == -1)
            ////    return;
            //cmbTownORTownship.SelectedIndex = -1;
            //BindRoute();
        }

        private void cmbTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTownORTownship.SelectedIndex == -1)
            //    return;
            ////cmbTownship.SelectedIndex = -1;
            //// Bind trip by TownInTrip
            //BindTrip();
        }

        private void buttonTransfer_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            Button btnTransfered = sender as Button;
            btnTransfered.Enabled = false;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.msgCaptionReturnToCustomer, this.Text,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            _salesService.IsReturned = true;
            frmServiceReceiveReturn frmServiceReturn = new frmServiceReceiveReturn(_salesService, _serviceStatus, (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
            frmServiceReturn.ServiceReceivedReturnedHandler += new frmServiceReceiveReturn.ServiceReceivedReturnHandler(ServiceReturn_CallBack);
            UIManager.OpenForm(frmServiceReturn);
            this.Close();
        }

        private void ServiceReturn_CallBack(object sender, PTIC.VC.Sale.Services.frmServiceReceiveReturn.ServiceReceivedReturnedEventArgs e)
        {
            this._occuredChanges = e.OccuredChanges;
        }

        private void txtUsedAmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtUsedSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtChargingTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtContinuousUsedTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtTestVolt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtTestRecPlus1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtTestRecPlus2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtFun1Volt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtFun2Volt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void txtFun3Volt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.KeyPressfunction.CheckInt(sender, e);
        }

        private void rdoTrip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTrip.Checked)
            {
                cmbRouteOrTrip.DataSource = bdTrip;
                //cmbCustomer.DataSource = bdCustomerTrip;
                cmbRouteOrTrip.ValueMember = "TripID";
                cmbRouteOrTrip.DisplayMember = "TripName";
                //cmbCustomer.ValueMember = "CustomerID";
                //cmbCustomer.DisplayMember = "CusName";

                cmbTownORTownship.DataSource = bdTown;
                cmbTownORTownship.ValueMember = "TownID";
                cmbTownORTownship.DisplayMember = "Town";
            }
        }

        private void rdoRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRoute.Checked)
            {
                cmbRouteOrTrip.DataSource = bdRoute;
                //     cmbCustomer.DataSource = bdCustomerRoute;
                cmbRouteOrTrip.ValueMember = "RouteID";
                cmbRouteOrTrip.DisplayMember = "RouteName";

                cmbTownORTownship.DataSource = bdTownship;
                cmbTownORTownship.ValueMember = "TownshipID";
                cmbTownORTownship.DisplayMember = "Township";
            }
        }

        private void btnSvcTest_Click(object sender, EventArgs e)
        {
            SaveSvcTest();
        }

        private void btnSvcFactoryFunction_Click(object sender, EventArgs e)
        {
            SaveSvcFactoryFunction();
        }

        private void btnSvcFactoryRec_Click(object sender, EventArgs e)
        {
            SaveSvcFactoryRecord();
        }

        private void btnSaveFact_Click(object sender, EventArgs e)
        {
            SaveFact();
        }

        private void btnSaveSvcFunc_Click(object sender, EventArgs e)
        {
            SaveSvnFunc();
        }

        private void btnSvcFunction1_Click(object sender, EventArgs e)
        {
            SvcFunction svcFunction = new SvcFunction();
            svcFunction.SalesServiceID = (int)DataTypeParser.Parse(this._salesService.ID, typeof(int), 0);
            svcFunction.SvcDate = (DateTime)DataTypeParser.Parse(dtpFun1Date.Value, typeof(DateTime), DateTime.Now);
            svcFunction.FromTime = dtpFun1From.Value.TimeOfDay;
            svcFunction.ToTime = dtpFun1To.Value.TimeOfDay;
            svcFunction.SvcFunctions = (int)DataTypeParser.Parse(cmbSvcFun1.SelectedIndex, typeof(int), -1);
            svcFunction.Volt = (int)DataTypeParser.Parse(txtFun1Volt.Text, typeof(int), 0);
            svcFunction.RecPlus1 = (string)DataTypeParser.Parse(txtFun1P1.Text, typeof(string), null);
            svcFunction.RecPlus2 = (string)DataTypeParser.Parse(txtFun1P2.Text, typeof(string), null);
            svcFunction.RecPlus3 = (string)DataTypeParser.Parse(txtFun1P3.Text, typeof(string), null);
            svcFunction.RecPlus4 = (string)DataTypeParser.Parse(txtFun1P4.Text, typeof(string), null);
            svcFunction.RecPlus5 = (string)DataTypeParser.Parse(txtFun1P5.Text, typeof(string), null);
            svcFunction.RecPlus5 = (string)DataTypeParser.Parse(txtFun1P6.Text, typeof(string), null);

            svcFunction.RecMinus1 = (string)DataTypeParser.Parse(txtFun1M1.Text, typeof(string), null);
            svcFunction.RecMinus2 = (string)DataTypeParser.Parse(txtFun1M2.Text, typeof(string), null);
            svcFunction.RecMinus3 = (string)DataTypeParser.Parse(txtFun1M3.Text, typeof(string), null);
            svcFunction.RecMinus4 = (string)DataTypeParser.Parse(txtFun1M4.Text, typeof(string), null);
            svcFunction.RecMinus5 = (string)DataTypeParser.Parse(txtFun1M5.Text, typeof(string), null);
            svcFunction.RecMinus6 = (string)DataTypeParser.Parse(txtFun1M6.Text, typeof(string), null);

            svcFunction.Remark = (string)DataTypeParser.Parse(txtFun1Remark.Text, typeof(string), string.Empty);

            SaveSvcFunction(svcFunction);
        }

        private void btnSvcFunction2_Click(object sender, EventArgs e)
        {
            SvcFunction svcFunction = new SvcFunction();
            svcFunction.SalesServiceID = (int)DataTypeParser.Parse(this._salesService.ID, typeof(int), 0);
            svcFunction.SvcDate = (DateTime)DataTypeParser.Parse(dtpFun2Date.Value, typeof(DateTime), DateTime.Now);
            svcFunction.FromTime = dtpFun2From.Value.TimeOfDay;
            svcFunction.ToTime = dtpFun2To.Value.TimeOfDay;
            svcFunction.SvcFunctions = (int)DataTypeParser.Parse(cmbSvcFun2.SelectedIndex, typeof(int), -1);
            svcFunction.Volt = (int)DataTypeParser.Parse(txtFun2Volt.Text, typeof(int), 0);
            svcFunction.RecPlus1 = (string)DataTypeParser.Parse(txtFun2P1.Text, typeof(string), null);
            svcFunction.RecPlus2 = (string)DataTypeParser.Parse(txtFun2P2.Text, typeof(string), null);
            svcFunction.RecPlus3 = (string)DataTypeParser.Parse(txtFun2P3.Text, typeof(string), null);
            svcFunction.RecPlus4 = (string)DataTypeParser.Parse(txtFun2P4.Text, typeof(string), null);
            svcFunction.RecPlus5 = (string)DataTypeParser.Parse(txtFun2P5.Text, typeof(string), null);
            svcFunction.RecPlus5 = (string)DataTypeParser.Parse(txtFun2P6.Text, typeof(string), null);

            svcFunction.RecMinus1 = (string)DataTypeParser.Parse(txtFun2M1.Text, typeof(string), null);
            svcFunction.RecMinus2 = (string)DataTypeParser.Parse(txtFun2M2.Text, typeof(string), null);
            svcFunction.RecMinus3 = (string)DataTypeParser.Parse(txtFun2M3.Text, typeof(string), null);
            svcFunction.RecMinus4 = (string)DataTypeParser.Parse(txtFun2M4.Text, typeof(string), null);
            svcFunction.RecMinus5 = (string)DataTypeParser.Parse(txtFun2M5.Text, typeof(string), null);
            svcFunction.RecMinus6 = (string)DataTypeParser.Parse(txtFun2M6.Text, typeof(string), null);

            svcFunction.Remark = (string)DataTypeParser.Parse(txtFun2Remark.Text, typeof(string), string.Empty);

            SaveSvcFunction(svcFunction);
        }

        private void btnSvnFunction3_Click(object sender, EventArgs e)
        {
            SvcFunction svcFunction = new SvcFunction();
            svcFunction.SalesServiceID = (int)DataTypeParser.Parse(this._salesService.ID, typeof(int), 0);
            svcFunction.SvcDate = (DateTime)DataTypeParser.Parse(dtpFun3Date.Value, typeof(DateTime), DateTime.Now);
            svcFunction.FromTime = dtpFun3From.Value.TimeOfDay;
            svcFunction.ToTime = dtpFun3To.Value.TimeOfDay;
            svcFunction.SvcFunctions = (int)DataTypeParser.Parse(cmbSvcFun3.SelectedIndex, typeof(int), -1);
            svcFunction.Volt = (int)DataTypeParser.Parse(txtFun3Volt.Text, typeof(int), 0);
            svcFunction.RecPlus1 = (string)DataTypeParser.Parse(txtFun3P1.Text, typeof(string), null);
            svcFunction.RecPlus2 = (string)DataTypeParser.Parse(txtFun3P2.Text, typeof(string), null);
            svcFunction.RecPlus3 = (string)DataTypeParser.Parse(txtFun3P3.Text, typeof(string), null);
            svcFunction.RecPlus4 = (string)DataTypeParser.Parse(txtFun3P4.Text, typeof(string), null);
            svcFunction.RecPlus5 = (string)DataTypeParser.Parse(txtFun3P5.Text, typeof(string), null);
            svcFunction.RecPlus5 = (string)DataTypeParser.Parse(txtFun3P6.Text, typeof(string), null);

            svcFunction.RecMinus1 = (string)DataTypeParser.Parse(txtFun3M1.Text, typeof(string), null);
            svcFunction.RecMinus2 = (string)DataTypeParser.Parse(txtFun3M2.Text, typeof(string), null);
            svcFunction.RecMinus3 = (string)DataTypeParser.Parse(txtFun3M3.Text, typeof(string), null);
            svcFunction.RecMinus4 = (string)DataTypeParser.Parse(txtFun3M4.Text, typeof(string), null);
            svcFunction.RecMinus5 = (string)DataTypeParser.Parse(txtFun3M5.Text, typeof(string), null);
            svcFunction.RecMinus6 = (string)DataTypeParser.Parse(txtFun3M6.Text, typeof(string), null);

            svcFunction.Remark = (string)DataTypeParser.Parse(txtFun3Remark.Text, typeof(string), string.Empty);

            SaveSvcFunction(svcFunction);
        }

        private void SaveFactSupportToCustomer(int ServiceToCustomer)
        {
            SqlConnection conn = null;
            int isSuccessful = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                SalesService salesService = new SalesService();
                salesService.ID = this._salesService.ID;
                salesService.Service = ServiceToCustomer;
                isSuccessful = new SalesServiceBL().SalesServiceUpdateServiceByID(salesService, conn);
                //if (this._salesService.SvcFactID.HasValue) // Update service fact
                //{
                //    if (svcFactSaver.Update(newSvcFact, conn) > 0)
                //        isSuccessful = true;
                //}
                //else // Insert new service fact
                //{
                //    // Save service fact
                //    this._salesService.SvcFactID = svcFactSaver.Add(newSvcFact, this._salesService.ID, conn);
                //    if (this._salesService.SvcFactID.HasValue)
                //        isSuccessful = true;
                //}

                if (isSuccessful > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBindData();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException sqle)
            {
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void btnServiceToCustomer_Click(object sender, EventArgs e)
        {
            int CustomerSalesService = (int)DataTypeParser.Parse(cmbSupportToCustomer.SelectedIndex, typeof(int), -1);
            SaveFactSupportToCustomer(CustomerSalesService);
        }

        private void txtTestRecPlus1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //KeyPressfunction.CheckChar(sender, e);
        }

        private void txtFun3Volt_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmServiceBatteryDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ServiceBatteryDetailSavedHandler == null)
                return;
            ServiceBatteryDetailEventArgs detailedSavedArg = new ServiceBatteryDetailEventArgs(this._occuredChanges);
            ServiceBatteryDetailSavedHandler(this, detailedSavedArg);
        }
        #endregion

        #region Private Methods
        //private void BindRoute()
        //{
        //    cmbRouteOrTrip.DataSource = _dtRoute;
        //    cmbRouteOrTrip.DisplayMember = "RouteName";
        //    cmbRouteOrTrip.ValueMember = "RouteID";
        //}

        //private void BindTrip()
        //{
        //    cmbRouteOrTrip.DataSource = _dtTrip;
        //    cmbRouteOrTrip.DisplayMember = "TripName";
        //    cmbRouteOrTrip.ValueMember = "TripID";
        //} 
        private void LoadNBindCombo()
        {
            //SqlConnection conn = null;
            try
            {
                // add town and customer tables into a dataset
                DataTable tblRoute = _dtRoute.Copy();
                DataTable tblTownshipInRoute = dtTownshipInRoute.Copy();
                DataTable tblTrip = _dtTrip.Copy();
                DataTable tblTownInTrip = dtTownInTrip.Copy();
                dsTownship.Tables.Add(tblRoute);
                dsTownship.Tables.Add(tblTownshipInRoute);

                // create data relation between township and customer
                DataRelation relRoute_Township = new DataRelation("Route_Township", tblRoute.Columns["RouteID"], tblTownshipInRoute.Columns["RouteID"], false);
                // add relation into a dataset
                dsTownship.Relations.Add(relRoute_Township);

                bdRoute.DataSource = dsTownship;
                bdRoute.DataMember = tblRoute.TableName;

                bdTownship.DataSource = bdRoute;
                bdTownship.DataMember = "Route_Township";


                // add town and customer tables into a dataset
                ds.Tables.Add(tblTrip);
                ds.Tables.Add(tblTownInTrip);
                // create data relation between town and customer
                DataRelation relTrip_Town = new DataRelation("Trip_Town", tblTrip.Columns["TripID"], tblTownInTrip.Columns["TripID"], false);
                // add relation into a dataset
                ds.Relations.Add(relTrip_Town);

                bdTrip.DataSource = ds;
                bdTrip.DataMember = _dtTrip.TableName;

                bdTown.DataSource = bdTrip;
                bdTown.DataMember = "Trip_Town";
            }
            catch (SqlException Sqle)
            {

                throw Sqle;
            }
        }

        private void LoadNBindData()
        {
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            //if (this._salesService == null || this._serviceStatus == null)
            //    return;

            dtEmployee = new EmployeeBL().GetAll();

            SetSalesService(this._salesService);

            DataTable dtServicedCustomer = new ServicedCustomerBL().GetAllBySvcCustomerID(this._salesService.ServicedCustomerID);
            DataTable dtTownInTrip = new TownInTripBL().GetAll();
            DataTable dtTownshipInRoute = new TownshipInRouteBL().GetAll();
            DataTable dtSalesService = new SalesServiceBL().GetAllByID(this._salesService.ID);
            if(dtSalesService.Rows.Count > 0)
            {
                dtpDateToSvc.Checked = true;
                if ((DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["DateToSvc"], typeof(DateTime), DateTime.MinValue) != DateTime.MinValue)
                {
                    dtpDateToSvc.Value = (DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["DateToSvc"], typeof(DateTime), DateTime.MinValue);
                   
                }
                else
                {
                    dtpDateToSvc.Visible = false;
                }
              
            }
            if (dtServicedCustomer.Rows.Count > 0)
            {
                int CustomerID = (int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["CustomerID"], typeof(int), -1);
                int SvcTownID = (int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["TownID"], typeof(int), -1);
                int SvcTownshipID = (int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["TownshipID"], typeof(int), -1);

                if (CustomerID != -1)
                {
                    DataTable dtCustomer = new CustomerBL().GetAllByCusID(CustomerID);
                    if (dtCustomer == null) return;
                    txtUserName.Text = (string)DataTypeParser.Parse(dtCustomer.Rows[0]["CusName"], typeof(string), string.Empty);
                    txtContactPerson.Text = (string)DataTypeParser.Parse(dtCustomer.Rows[0]["ConPersonName"], typeof(string), string.Empty);
                    txtShop.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["ShopName"], typeof(string), string.Empty);
                    txtPh1.Text = (string)DataTypeParser.Parse(dtCustomer.Rows[0]["Phone1"], typeof(string), string.Empty);
                    txtPh2.Text = (string)DataTypeParser.Parse(dtCustomer.Rows[0]["MobilePhone"], typeof(string), string.Empty);

                    int RouteID = (int)DataTypeParser.Parse(dtCustomer.Rows[0]["RouteID"], typeof(int), -1);
                    int TripID = (int)DataTypeParser.Parse(dtCustomer.Rows[0]["TripID"], typeof(int), -1);
                    int TownID = (int)DataTypeParser.Parse(dtCustomer.Rows[0]["TownID"], typeof(int), -1);
                    int TownshipID = (int)DataTypeParser.Parse(dtCustomer.Rows[0]["TownshipID"], typeof(int), -1);
                    if (RouteID != -1)
                    {
                        rdoRoute.Checked = true;
                        cmbRouteOrTrip.SelectedValue = RouteID;
                        cmbTownORTownship.SelectedValue = TownshipID;

                    }
                    else
                    {
                        rdoTrip.Checked = true;
                        cmbRouteOrTrip.SelectedValue = TripID;
                        cmbTownORTownship.SelectedValue = TownID;
                    }
                }
                else
                {
                    rdoRoute.Visible = false;
                    rdoTrip.Visible = false;
                    cmbRouteOrTrip.Visible = false;
                    cmbTownORTownship.Visible = false;
                    label7.Visible = false;
                    txtUserName.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["UserName"], typeof(string), string.Empty);
                    txtContactPerson.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["ContactPerson"], typeof(string), string.Empty);
                    txtShop.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["ShopName"], typeof(string), string.Empty);
                    txtPh1.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["Phone1"], typeof(string), string.Empty);
                    txtPh2.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["Phone2"], typeof(string), string.Empty);

                    if (SvcTownshipID != -1)
                    {
                        rdoRoute.Checked = true;
                        DataTable dt = DataUtil.GetDataTableBy(dtTownshipInRoute, "TownshipID", SvcTownshipID);
                        if (dt != null)
                        {
                            cmbRouteOrTrip.SelectedValue = (int)DataTypeParser.Parse(dt.Rows[0]["RouteID"], typeof(int), -1);
                        }
                        else
                        {
                            cmbRouteOrTrip.SelectedValue = -1;
                        }
                        cmbTownORTownship.SelectedValue = SvcTownshipID;

                    }
                    else
                    {
                        rdoTrip.Checked = true;
                        DataTable dt = DataUtil.GetDataTableBy(dtTownInTrip, "TownID", SvcTownID);
                        if (dt != null)
                        {
                            cmbRouteOrTrip.SelectedValue = (int)DataTypeParser.Parse(dt.Rows[0]["TripID"], typeof(int), -1);
                        }
                        else
                        {
                            cmbRouteOrTrip.SelectedValue = -1;
                        }
                        cmbTownORTownship.SelectedValue = SvcTownID;
                    }
                }
            }

            SetServiceStatus(this._serviceStatus, this._salesService);
            //if (!this._salesService.SvcFactID.HasValue)
            //    return;
            //// Load service fact
            //LoadSvcFact(this._salesService.SvcFactID);
            // Load sevice test and function
            if (this._svcTestID.HasValue)
                LoadSvcFunction(this._svcTestID.Value);
        }

        private void SetServicedCustomer(ServicedCustomer servicedCustomer)
        {

        }

        private void SetSalesService(SalesService saleService)
        {
            DataTable dtSalesService = new SalesServiceBL().GetAllByID(this._salesService.ID);
          
            if (dtSalesService == null) return;
            txtDateToFactory.Text =TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["DateToFactory"], typeof(DateTime), DateTime.MinValue));
            //txtDateToFactory.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["DateToFactory"],typeof(string),string.Empty);
            txtDateFromFactory.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["DateFromFactory"], typeof(DateTime), DateTime.MinValue));
            //txtDateFromFactory.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["DateFromFactory"],typeof(string), string.Empty);
            txtDateFromSvc.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["DateFromSvc"], typeof(DateTime), DateTime.MinValue));
            //txtDateFromSvc.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["DateFromSvc"], typeof(string), string.Empty);
            txtDateToCustomer.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["DateToCustomer"], typeof(DateTime), DateTime.MinValue));
            //txtDateToCustomer.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["DateToCustomer"], typeof(string), string.Empty);
          //  dtpContactDateToCus.Checked = true;
           // dtpContactDateToCus.Value =
            if ((DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["ContactDateToCustomer"], typeof(DateTime), DateTime.MinValue) == DateTime.MinValue)
            {
                chkCustomerInformDate.Checked = false;
                dtpContactDateToCus.Visible = false;
            }
            else
            {
                chkCustomerInformDate.Checked = true;
                dtpContactDateToCus.Visible = true;
                dtpContactDateToCus.Value = (DateTime)DataTypeParser.Parse(dtSalesService.Rows[0]["ContactDateToCustomer"], typeof(DateTime), DateTime.MinValue);
            }
            txtJobNo.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["JobNo"], typeof(string), string.Empty);
            txtServiceNo.Text = txtSvcNo.Text=saleService.SalesServiceNo;      
            txtWarrantyNo.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["WarrantyNo"], typeof(string), string.Empty);
            txtBrand.Text = txtBrand.Text = _brandName;
            txtProduct.Text = txtProduct.Text = _productName;
            DataTable dt = DataUtil.GetDataTableBy(dtEmployee, "EmployeeID", saleService.TakerID);
            if (dt != null)
            {
                txtAccepter.Text = (string)DataTypeParser.Parse(dt.Rows[0]["EmpName"], typeof(string), string.Empty);
            }
            else
            {
                txtAccepter.Text = string.Empty;
            }
            cmbAcceptSystem.SelectedIndex = (int)DataTypeParser.Parse(dtSalesService.Rows[0]["RecieveVia"], typeof(int), -1);
            txtGiver.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["Giver"], typeof(string), -1);
            //txtUserName.Text = txtUserName.Text = saleService.UserName;
            //txtContactPerson.Text = saleService.ContactPersion;
            //txtPh1.Text = saleService.PhNo1;
            //txtPh2.Text = saleService.PhNo2;
           // txtProductionDate.Text = saleService.PurchaseDate;
          //  txtProductionDate.Text = saleService.ProductionDate;
            txtPurchaseDate.Text = saleService.PurchaseDate;
            txtReceivedDate.Text = TextFormat.ToAppDate(saleService.ReceivedDate);
            txtUsedAmp.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["UsedAmp"], typeof(string), string.Empty);
            txtUsedDuration.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["UsedDuration"], typeof(string), string.Empty);
            txtUsedPlace.Text = (string)DataTypeParser.Parse(dtSalesService.Rows[0]["UsedPlace"], typeof(string), string.Empty);
            cmbSupportToCustomer.SelectedIndex = (int)DataTypeParser.Parse(dtSalesService.Rows[0]["Service"], typeof(int), -1);
            //txtGiver.Text = 
            int ServiceCusID = (int)DataTypeParser.Parse(dtSalesService.Rows[0]["ServicedCustomerID"], typeof(int), -1);

            // Set Data Into Service Test
            SetServiceTest();

            // Set Data into SvcFactoryRecord
            SetSvcFactoryRecord();

            // Set Data into SvcFactoryFunction
            SetSvcFactoryFunction();

            // Set Data into SvcFunction
            SetSvcFunction();
        }

        private void SetServiceStatus(ServiceBatteryStatus serviceStatus, SalesService salesService)
        {
            // Set forward background
            btnForwardVehicle.BackgroundImage = serviceStatus.InForwardVehicle ? Resource.btn_green_right_arrow : null;
            btnForwardShowroom.BackgroundImage = serviceStatus.InForwardShowroom ? Resource.btn_green_right_arrow : null;
            btnForwardServiceTeam.BackgroundImage = serviceStatus.InForwardServiceTeam ? Resource.btn_green_right_arrow : null;
            btnForwardFactory.BackgroundImage = serviceStatus.InForwardMainStore ? Resource.btn_green_right_arrow : null;
            // Set backward background
            btnBackwardVehicle.BackgroundImage = serviceStatus.InBackwardVehicle ? Resource.btn_green_right_arrow : null;
            btnBackwardShowroom.BackgroundImage = serviceStatus.InBackwardShowroom ? Resource.btn_green_right_arrow : null;
            btnBackwardServiceTeam.BackgroundImage = serviceStatus.InBackwardServiceTeam ? Resource.btn_green_right_arrow : null;
            btnReturn.BackgroundImage = serviceStatus.InBackwardCustomer ? Resource.btn_green_right_arrow : null;            
            // Set marker (where service item exist)
            if (salesService.IsBackward)
            {
                switch (salesService.Whereami)
                {
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle:
                        picBackwardVehicle.Image = Resource.marker;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom:
                        picBackwardShowroom.Image = Resource.marker;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore:
                        picBackwardServiceTeam.Image = Resource.marker;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Customer:
                        picReturn.Image = Resource.marker;
                        break;
                }
            }
            else // Forward
            {
                switch (salesService.Whereami)
                {
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle:
                        picForwardVehicle.Image = Resource.marker;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom:
                        picForwardShowroom.Image = Resource.marker;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore:
                        picForwardServiceTeam.Image = Resource.marker;
                        break;
                    case (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore:
                        picForwardFactory.Image = Resource.marker;
                        break;
                }
            }
            // if service battery has been transfered to Factory, disable all forward transfer
            if(serviceStatus.InForwardMainStore)
            {
                gpBxForward.Enabled = false;
            }            
            // if sevice battery has been returned, disable all transfers
            if (salesService.IsReturned)
            {
                gpBxBackward.Enabled = false;

                //btnForwardVehicle.Enabled =
                //btnForwardShowroom.Enabled =
                //btnForwardServiceTeam.Enabled =
                //btnForwardFactory.Enabled =

                //btnBackwardServiceTeam.Enabled =
                //btnBackwardShowroom.Enabled =
                //btnBackwardVehicle.Enabled =
                //btnReturn.Enabled = false;
            }

        }

        private void SetServiceTest()
        {
            DataTable dtSvcTest = new SvcTestBL().GetAllByID(this._salesService.ID);

            if (dtSvcTest.Rows.Count < 1)
                return;
            DataRow row = dtSvcTest.Rows[0];
            btnSvcTest.Enabled = false;
            txtTestVolt.Text = row["TestVolt"].ToString();
            cmbTestService.SelectedIndex = (int)DataTypeParser.Parse(row["TestService"], typeof(int), -1);
            txtTestFault.Text = row["TestFault"].ToString();
            txtTestRecPlus1.Text = row["TestRecPlus1"].ToString();
            txtTestRecPlus2.Text = row["TestRecPlus2"].ToString();
            txtTestRecPlus3.Text = row["TestRecPlus3"].ToString();
            txtTestRecPlus4.Text = row["TestRecPlus4"].ToString();
            txtTestRecPlus5.Text = row["TestRecPlus5"].ToString();
            txtTestRecPlus6.Text = row["TestRecPlus6"].ToString();
            txtTestRecMinus1.Text = row["TestRecMinus1"].ToString();
            txtTestRecMinus2.Text = row["TestRecMinus2"].ToString();
            txtTestRecMinus3.Text = row["TestRecMinus3"].ToString();
            txtTestRecMinus4.Text = row["TestRecMinus4"].ToString();
            txtTestRecMinus5.Text = row["TestRecMinus5"].ToString();
            txtTestRecMinus6.Text = row["TestRecMinus6"].ToString();
            txtTestRemark.Text = row["TestRemark"].ToString();
        }

        private void SetServiceFunction(DataTable tbSvcFunction)
        {
            if (tbSvcFunction.Rows.Count < 3)
                return;
            DataRow row1 = tbSvcFunction.Rows[0];
            //SvcTestID = this._svcTestID.Value,
            // Function 1
            this._svcFunctionOneID = (int?)DataTypeParser.Parse(row1["ID"], typeof(int), null);
            dtpFun1Date.Value = (DateTime)DataTypeParser.Parse(row1["SvcDate"], typeof(DateTime), DateTime.Now);
            dtpFun1From.Value = (DateTime)DataTypeParser.Parse(row1["FromTime"], typeof(DateTime), DateTime.Now);
            dtpFun1To.Value = (DateTime)DataTypeParser.Parse(row1["ToTime"], typeof(DateTime), DateTime.Now);
            cmbSvcFun1.SelectedIndex = (int)DataTypeParser.Parse(row1["Function"].ToString(), typeof(int), -1);
            txtFun1Volt.Text = row1["Volt"].ToString();
            txtFun1P1.Text = row1["RecPlus1"].ToString();
            txtFun1P2.Text = row1["RecPlus2"].ToString();
            txtFun1P3.Text = row1["RecPlus3"].ToString();
            txtFun1P4.Text = row1["RecPlus4"].ToString();
            txtFun1P5.Text = row1["RecPlus5"].ToString();
            txtFun1P6.Text = row1["RecPlus6"].ToString();
            txtFun1M1.Text = row1["RecMinus1"].ToString();
            txtFun1M2.Text = row1["RecMinus2"].ToString();
            txtFun1M3.Text = row1["RecMinus3"].ToString();
            txtFun1M4.Text = row1["RecMinus4"].ToString();
            txtFun1M5.Text = row1["RecMinus5"].ToString();
            txtFun1M6.Text = row1["RecMinus6"].ToString();
            txtFun1Remark.Text = row1["Remark"].ToString();
            // Function 2
            DataRow row2 = tbSvcFunction.Rows[1];
            this._svcFunctionTwoID = (int?)DataTypeParser.Parse(row2["ID"], typeof(int), null);
            dtpFun2Date.Value = (DateTime)DataTypeParser.Parse(row2["SvcDate"], typeof(DateTime), DateTime.Now);
            dtpFun2From.Value = (DateTime)DataTypeParser.Parse(row2["FromTime"], typeof(DateTime), DateTime.Now);
            dtpFun2To.Value = (DateTime)DataTypeParser.Parse(row2["ToTime"], typeof(DateTime), DateTime.Now);
            cmbSvcFun2.SelectedIndex = (int)DataTypeParser.Parse(row2["Function"].ToString(), typeof(int), -1);
            txtFun2Volt.Text = row2["Volt"].ToString();
            txtFun2P1.Text = row2["RecPlus1"].ToString();
            txtFun2P2.Text = row2["RecPlus2"].ToString();
            txtFun2P3.Text = row2["RecPlus3"].ToString();
            txtFun2P4.Text = row2["RecPlus4"].ToString();
            txtFun2P5.Text = row2["RecPlus5"].ToString();
            txtFun2P6.Text = row2["RecPlus6"].ToString();
            txtFun2M1.Text = row2["RecMinus1"].ToString();
            txtFun2M2.Text = row2["RecMinus2"].ToString();
            txtFun2M3.Text = row2["RecMinus3"].ToString();
            txtFun2M4.Text = row2["RecMinus4"].ToString();
            txtFun2M5.Text = row2["RecMinus5"].ToString();
            txtFun2M6.Text = row2["RecMinus6"].ToString();
            txtFun2Remark.Text = row2["Remark"].ToString();
            // Function 3
            DataRow row3 = tbSvcFunction.Rows[2];
            this._svcFunctionThreeID = (int?)DataTypeParser.Parse(row3["ID"], typeof(int), null);
            dtpFun3Date.Value = (DateTime)DataTypeParser.Parse(row3["SvcDate"], typeof(DateTime), DateTime.Now);
            dtpFun3From.Value = (DateTime)DataTypeParser.Parse(row3["FromTime"], typeof(DateTime), DateTime.Now);
            dtpFun3To.Value = (DateTime)DataTypeParser.Parse(row3["ToTime"], typeof(DateTime), DateTime.Now);
            cmbSvcFun3.SelectedIndex = (int)DataTypeParser.Parse(row3["Function"].ToString(), typeof(int), -1);
            txtFun3Volt.Text = row3["Volt"].ToString();
            txtFun3P1.Text = row3["RecPlus1"].ToString();
            txtFun3P2.Text = row3["RecPlus2"].ToString();
            txtFun3P3.Text = row3["RecPlus3"].ToString();
            txtFun3P4.Text = row3["RecPlus4"].ToString();
            txtFun3P5.Text = row3["RecPlus5"].ToString();
            txtFun3P6.Text = row3["RecPlus6"].ToString();
            txtFun3M1.Text = row3["RecMinus1"].ToString();
            txtFun3M2.Text = row3["RecMinus2"].ToString();
            txtFun3M3.Text = row3["RecMinus3"].ToString();
            txtFun3M4.Text = row3["RecMinus4"].ToString();
            txtFun3M5.Text = row3["RecMinus5"].ToString();
            txtFun3M6.Text = row3["RecMinus6"].ToString();
            txtFun3Remark.Text = row3["Remark"].ToString();
        }

        private void LoadSvcFact(int? svcFactID)
        {
            if (!svcFactID.HasValue)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtSvcFact = new SvcFactBL().GetByID(svcFactID);
                if (dtSvcFact.Rows.Count < 1)
                    return;
                DataRow row = dtSvcFact.Rows[0];
                this._svcTestID = (int?)DataTypeParser.Parse(row["SvcTestID"], typeof(int), null);
                int? tripID = (int?)DataTypeParser.Parse(row["TripID"], typeof(int), null);
                int? routeID = (int?)DataTypeParser.Parse(row["RouteID"], typeof(int), null);
                int? townID = (int?)DataTypeParser.Parse(row["TownID"], typeof(int), null);
                int? townshipID = (int?)DataTypeParser.Parse(row["TownshipID"], typeof(int), null);
                int shopID = (int)DataTypeParser.Parse(row["ShopID"], typeof(int), -1); // Customer ID
                int? usedDuration = (int?)DataTypeParser.Parse(row["UsedDuration"], typeof(int), null);
                string usedPlace = (string)DataTypeParser.Parse(row["UsedPlace"], typeof(string), string.Empty);
                int? usedAmp = (int?)DataTypeParser.Parse(row["UsedAmp"], typeof(int), null);
                int? usedSize = (int?)DataTypeParser.Parse(row["UsedSize"], typeof(int), null);
                int? chargingTime = (int?)DataTypeParser.Parse(row["ChargingTime"], typeof(int), null);
                string continuousUsedTime = (string)DataTypeParser.Parse(row["ContinuousUsedTime"], typeof(string), string.Empty);
                string address = (string)DataTypeParser.Parse(row["Address"], typeof(string), string.Empty);

                // Set service fact
                //cmbTown.SelectedValue = townID;
                //cmbTownship.SelectedValue = townshipID;
                if (townID.HasValue)
                {
                    // TODO: don't allow null value assignment
                    cmbTownORTownship.SelectedValue = townID;
                    cmbRouteOrTrip.SelectedValue = tripID.Value;
                }
                else
                {
                    // TODO: don't allow null value assignment
                    cmbRouteOrTrip.SelectedValue = routeID.Value;
                }

                //cmbShop.SelectedValue = shopID;
                txtUsedDuration.Text = usedDuration.Value.ToString();
                txtUsedPlace.Text = usedPlace;
                txtUsedAmp.Text = usedAmp.Value.ToString();

                DateTime dateToSvc = (DateTime)DataTypeParser.Parse(row["DateToSvc"], typeof(DateTime), DateTime.MinValue);
                if (dateToSvc != DateTime.MinValue)
                {
                    dtpDateToSvc.Checked = true;
                    dtpDateToSvc.Value = dateToSvc;                    
                }
                txtServicingDate.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(row["ServicingDate"], typeof(DateTime), DateTime.MinValue));
                txtDateToFactory.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(row["DateToFactory"], typeof(DateTime), DateTime.MinValue));
                txtDateFromFactory.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(row["DateFromFactory"], typeof(DateTime), DateTime.MinValue));
                txtDateFromSvc.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(row["DateFromSvc"], typeof(DateTime), DateTime.MinValue));
                txtDateToCustomer.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(row["DateToCustomer"], typeof(DateTime), DateTime.MinValue));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadSvcFunction(int? svcTestID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Load service test
                DataTable dtSvcTest = new SvcTestBL().GetByID(svcTestID.Value);
                // Load service function
                DataTable dtSvcFunction = new SvcFunctionBL().GetByID(svcTestID.Value);
                //// Set service test
                //SetServiceTest(dtSvcTest);
                // Set service function
                SetServiceFunction(dtSvcFunction);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /*
        private void LoadFactoryFunction(int? svcFactID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }            
        }
        */

        private void LoadNBindPreloadedData()
        {
            try
            {
                // Load Route DataTable
                _dtRoute = new RouteBL().GetAll();
                // Load Trip DataTable
                _dtTrip = new TripBL().GetAll();
                // Load Town DataTable and Bind
                _dtTown = new TownBL().GetAll();
                // cmbTownORTownship.DataSource = _dtTown;
                // Load Township DataTable and Bind
                _dtTownship = new TownshipBL().GetAll();

                dtTownInTrip = new TownInTripBL().GetAll();
                dtTownshipInRoute = new TownshipInRouteBL().GetAll();
                // cmbTownship.DataSource = _dtTownship;
                // Load customer
                //cmbShop.DataSource = new CustomerBL().GetAll(conn);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }

        /// <summary>
        /// Save service fact
        /// </summary>
        private void SaveFact()
        {            
            int isSuccessful = 0;
            SalesServiceBL serviceFactSaver = null;
            try
            {
                serviceFactSaver = new SalesServiceBL();
                SalesService salesService = new SalesService();
                salesService.ID = this._salesService.ID;
                salesService.JobNo = (string)DataTypeParser.Parse(txtJobNo.Text, typeof(string), string.Empty);
                salesService.WarrantyNo = (string)DataTypeParser.Parse(txtWarrantyNo.Text, typeof(string), string.Empty);
                salesService.ProductionDate = (string)DataTypeParser.Parse(txtProductionDate.Text, typeof(string), string.Empty);
                salesService.PurchaseDate = (string)DataTypeParser.Parse(txtPurchaseDate.Text, typeof(string), string.Empty);
                // salesService.ShopName = (string)DataTypeParser.Parse(txtShop.Text, typeof(string), string.Empty);
                salesService.UsedDuration = (int)DataTypeParser.Parse(txtUsedDuration.Text, typeof(int), 0);
                salesService.UsedPlace = (string)DataTypeParser.Parse(txtUsedPlace.Text, typeof(string), string.Empty);
                salesService.UsedAmp = (int)DataTypeParser.Parse(txtUsedAmp.Text, typeof(int), 0);
                if (chkCustomerInformDate.Checked)
                {
                    salesService.ContactDateToCustomer = (DateTime)DataTypeParser.Parse(dtpContactDateToCus.Value, typeof(DateTime), DateTime.Now);
                }
                else
                {
                    dtpContactDateToCus.Visible = false;                   
                }

                ServicedCustomer servicedCustomer = new ServicedCustomer();
                servicedCustomer.ID = this._salesService.ServicedCustomerID;
                servicedCustomer.ShopName = (string)DataTypeParser.Parse(txtShop.Text, typeof(string), string.Empty);
                if (rdoRoute.Checked)
                {
                    servicedCustomer.TownshipID = (int)DataTypeParser.Parse(cmbTownORTownship.SelectedValue, typeof(int), -1);
                }
                else
                {
                    servicedCustomer.TownID = (int)DataTypeParser.Parse(cmbTownORTownship.SelectedValue, typeof(int), -1);
                }
            
                // Save into db
                isSuccessful = serviceFactSaver.SalesServiceUpdateByID(salesService, servicedCustomer);
                // Check field validation failed or not
                if (!serviceFactSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(serviceFactSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    if (!string.IsNullOrEmpty(err.Key) && err.Key.Equals("RequireJobNo"))
                        txtJobNo.Focus();
                    return;
                }
                else if (isSuccessful > 0) // valid and successful
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBindData();
                }
                else
                    MessageBox.Show(
                        Resource.errFailedToSave,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                        e.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                _logger.Error(e);
            }            
        }

        private void SaveSvcTest()
        {
            SqlConnection conn = null;
            int sup = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                SvcTestBL serviceSaver = new SvcTestBL();
                // Set service test
                SvcTest svcTest = new SvcTest()
                {
                    ////ID = this._svcTestID.Value,
                    //ID = this._svcTestID,
                    
                    SalesServiceID = (int)DataTypeParser.Parse(this._salesService.ID, typeof(int), 0),
                    DateAdded = DateTime.Now,
                    LastModified=DateTime.Now,
                    TestVolt = (int)DataTypeParser.Parse(txtTestVolt.Text, typeof(int), 0),
                    TestService = (int)DataTypeParser.Parse(cmbTestService.SelectedIndex, typeof(int), 0),
                    TestFault = (string)DataTypeParser.Parse(txtTestFault.Text, typeof(string), null),
                    TestRecPlus1 = (string)DataTypeParser.Parse(txtTestRecPlus1.Text, typeof(string), null),
                    TestRecPlus2 = (string)DataTypeParser.Parse(txtTestRecPlus2.Text, typeof(string), null),
                    TestRecPlus3 = (string)DataTypeParser.Parse(txtTestRecPlus3.Text, typeof(string), null),
                    TestRecPlus4 = (string)DataTypeParser.Parse(txtTestRecPlus4.Text, typeof(string), null),
                    TestRecPlus5 = (string)DataTypeParser.Parse(txtTestRecPlus5.Text, typeof(string), null),
                    TestRecPlus6 = (string)DataTypeParser.Parse(txtTestRecPlus6.Text, typeof(string), null),
                    TestRecMinus1 = (string)DataTypeParser.Parse(txtTestRecMinus1.Text, typeof(string), null),
                    TestRecMinus2 = (string)DataTypeParser.Parse(txtTestRecMinus2.Text, typeof(string), null),
                    TestRecMinus3 = (string)DataTypeParser.Parse(txtTestRecMinus3.Text, typeof(string), null),
                    TestRecMinus4 = (string)DataTypeParser.Parse(txtTestRecMinus4.Text, typeof(string), null),
                    TestRecMinus5 = (string)DataTypeParser.Parse(txtTestRecMinus5.Text, typeof(string), null),
                    TestRecMinus6 = (string)DataTypeParser.Parse(txtTestRecMinus6.Text, typeof(string), null),
                    TestRemark = (string)DataTypeParser.Parse(txtTestRemark.Text, typeof(string), string.Empty)
                };

                sup = new SvcTestBL().AddSvcTest(svcTest);
                if (sup > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (SqlException Sqle)
            {
                throw;
            }
        }

        private void SaveSvnFunc()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                SvcTestBL serviceSaver = new SvcTestBL();
                // Set service test
                SvcTest svcTest = new SvcTest()
                {
                    //ID = this._svcTestID.Value,
                    ID = this._svcTestID,
                    TestVolt = (int)DataTypeParser.Parse(txtTestVolt.Text, typeof(int), 0),
                    // TestFaultFact = (string)DataTypeParser.Parse(txtTestFaultFact.Text, typeof(string), null),
                    TestService = (int)DataTypeParser.Parse(cmbTestService.SelectedIndex, typeof(int), -1),
                    TestFault = (string)DataTypeParser.Parse(txtTestFault.Text, typeof(string), null),
                    // TestAfterSvc = (string)DataTypeParser.Parse(txtTestAfterSvc.Text, typeof(string), null),
                    TestRecPlus1 = (string)DataTypeParser.Parse(txtTestRecPlus1.Text, typeof(string), null),
                    TestRecPlus2 = (string)DataTypeParser.Parse(txtTestRecPlus2.Text, typeof(string), null),
                    TestRecPlus3 = (string)DataTypeParser.Parse(txtTestRecPlus3.Text, typeof(string), null),
                    TestRecPlus4 = (string)DataTypeParser.Parse(txtTestRecPlus4.Text, typeof(string), null),
                    TestRecPlus5 = (string)DataTypeParser.Parse(txtTestRecPlus5.Text, typeof(string), null),
                    TestRecPlus6 = (string)DataTypeParser.Parse(txtTestRecPlus6.Text, typeof(string), null),
                    TestRecMinus1 = (string)DataTypeParser.Parse(txtTestRecMinus1.Text, typeof(string), null),
                    TestRecMinus2 = (string)DataTypeParser.Parse(txtTestRecMinus2.Text, typeof(string), null),
                    TestRecMinus3 = (string)DataTypeParser.Parse(txtTestRecMinus3.Text, typeof(string), null),
                    TestRecMinus4 = (string)DataTypeParser.Parse(txtTestRecMinus4.Text, typeof(string), null),
                    TestRecMinus5 = (string)DataTypeParser.Parse(txtTestRecMinus5.Text, typeof(string), null),
                    TestRecMinus6 = (string)DataTypeParser.Parse(txtTestRecPlus5.Text, typeof(string), null),
                };
                // Set serivce function
                List<SvcFunction> svc3Functions = new List<SvcFunction>();
                SvcFunction svcFunc1 = new SvcFunction()
                {
                    //ID = this._svcFunctionOneID.Value,
                    //ID = this._svcFunctionOneID,
                    //ID = this._svcFunctionOneID,
                    //SvcTestID = this._svcTestID,
                    SvcDate = (DateTime)DataTypeParser.Parse(dtpFun1Date.Value, typeof(DateTime), DateTime.Now),
                    FromTime = ((DateTime)DataTypeParser.Parse(dtpFun1From.Value, typeof(DateTime), DateTime.Now)).TimeOfDay,
                    ToTime = ((DateTime)DataTypeParser.Parse(dtpFun1To.Value, typeof(DateTime), DateTime.Now)).TimeOfDay,
                    SvcFunctions = (int)DataTypeParser.Parse(cmbSvcFun1.SelectedIndex, typeof(int), -1),
                    Volt = (int)DataTypeParser.Parse(txtFun1Volt.Text, typeof(int), 0),
                    RecPlus1 = (string)DataTypeParser.Parse(txtFun1P1.Text, typeof(string), null),
                    RecPlus2 = (string)DataTypeParser.Parse(txtFun1P2.Text, typeof(string), null),
                    RecPlus3 = (string)DataTypeParser.Parse(txtFun1P3.Text, typeof(string), null),
                    RecPlus4 = (string)DataTypeParser.Parse(txtFun1P4.Text, typeof(string), null),
                    RecPlus5 = (string)DataTypeParser.Parse(txtFun1P5.Text, typeof(string), null),
                    RecPlus6 = (string)DataTypeParser.Parse(txtFun1P6.Text, typeof(string), null),
                    RecMinus1 = (string)DataTypeParser.Parse(txtFun1M1.Text, typeof(string), null),
                    RecMinus2 = (string)DataTypeParser.Parse(txtFun1M2.Text, typeof(string), null),
                    RecMinus3 = (string)DataTypeParser.Parse(txtFun1M3.Text, typeof(string), null),
                    RecMinus4 = (string)DataTypeParser.Parse(txtFun1M4.Text, typeof(string), null),
                    RecMinus5 = (string)DataTypeParser.Parse(txtFun1M5.Text, typeof(string), null),
                    RecMinus6 = (string)DataTypeParser.Parse(txtFun1M6.Text, typeof(string), null),
                    Remark = (string)DataTypeParser.Parse(txtFun1Remark.Text, typeof(string), null)
                };
                SvcFunction svcFunc2 = new SvcFunction()
                {
                    //ID = this._svcFunctionTwoID.Value,
                    //ID = this._svcFunctionTwoID,
                    //  SvcTestID = this._svcTestID,
                    SvcDate = (DateTime)DataTypeParser.Parse(dtpFun2Date.Value, typeof(DateTime), DateTime.Now),
                    FromTime = ((DateTime)DataTypeParser.Parse(dtpFun2From.Value, typeof(DateTime), DateTime.Now)).TimeOfDay,
                    ToTime = ((DateTime)DataTypeParser.Parse(dtpFun2To.Value, typeof(DateTime), DateTime.Now)).TimeOfDay,
                    SvcFunctions = (int)DataTypeParser.Parse(cmbSvcFun2.SelectedIndex, typeof(int), -1),
                    Volt = (int)DataTypeParser.Parse(txtFun2Volt.Text, typeof(int), 0),
                    RecPlus1 = (string)DataTypeParser.Parse(txtFun2P1.Text, typeof(string), null),
                    RecPlus2 = (string)DataTypeParser.Parse(txtFun2P2.Text, typeof(string), null),
                    RecPlus3 = (string)DataTypeParser.Parse(txtFun2P3.Text, typeof(string), null),
                    RecPlus4 = (string)DataTypeParser.Parse(txtFun2P4.Text, typeof(string), null),
                    RecPlus5 = (string)DataTypeParser.Parse(txtFun2P5.Text, typeof(string), null),
                    RecPlus6 = (string)DataTypeParser.Parse(txtFun2P6.Text, typeof(string), null),
                    RecMinus1 = (string)DataTypeParser.Parse(txtFun2M1.Text, typeof(string), null),
                    RecMinus2 = (string)DataTypeParser.Parse(txtFun2M2.Text, typeof(string), null),
                    RecMinus3 = (string)DataTypeParser.Parse(txtFun2M3.Text, typeof(string), null),
                    RecMinus4 = (string)DataTypeParser.Parse(txtFun2M4.Text, typeof(string), null),
                    RecMinus5 = (string)DataTypeParser.Parse(txtFun2M5.Text, typeof(string), null),
                    RecMinus6 = (string)DataTypeParser.Parse(txtFun2M6.Text, typeof(string), null),
                    Remark = (string)DataTypeParser.Parse(txtFun2Remark.Text, typeof(string), null)
                };
                SvcFunction svcFunc3 = new SvcFunction()
                {
                    //ID = this._svcFunctionThreeID.Value,
                    //ID = this._svcFunctionThreeID,
                    //      SvcTestID = this._svcTestID,
                    SvcDate = (DateTime)DataTypeParser.Parse(dtpFun3Date.Value, typeof(DateTime), DateTime.Now),
                    FromTime = ((DateTime)DataTypeParser.Parse(dtpFun3From.Value, typeof(DateTime), DateTime.Now)).TimeOfDay,
                    ToTime = ((DateTime)DataTypeParser.Parse(dtpFun3To.Value, typeof(DateTime), DateTime.Now)).TimeOfDay,
                    SvcFunctions = (int)DataTypeParser.Parse(cmbSvcFun3.SelectedIndex, typeof(int), null),
                    Volt = (int)DataTypeParser.Parse(txtFun3Volt.Text, typeof(int), 0),
                    RecPlus1 = (string)DataTypeParser.Parse(txtFun3P1.Text, typeof(string), null),
                    RecPlus2 = (string)DataTypeParser.Parse(txtFun3P2.Text, typeof(string), null),
                    RecPlus3 = (string)DataTypeParser.Parse(txtFun3P3.Text, typeof(string), null),
                    RecPlus4 = (string)DataTypeParser.Parse(txtFun3P4.Text, typeof(string), null),
                    RecPlus5 = (string)DataTypeParser.Parse(txtFun3P5.Text, typeof(string), null),
                    RecPlus6 = (string)DataTypeParser.Parse(txtFun3P6.Text, typeof(string), null),
                    RecMinus1 = (string)DataTypeParser.Parse(txtFun3M1.Text, typeof(string), null),
                    RecMinus2 = (string)DataTypeParser.Parse(txtFun3M2.Text, typeof(string), null),
                    RecMinus3 = (string)DataTypeParser.Parse(txtFun3M3.Text, typeof(string), null),
                    RecMinus4 = (string)DataTypeParser.Parse(txtFun3M4.Text, typeof(string), null),
                    RecMinus5 = (string)DataTypeParser.Parse(txtFun3M5.Text, typeof(string), null),
                    RecMinus6 = (string)DataTypeParser.Parse(txtFun3M6.Text, typeof(string), null),
                    Remark = (string)DataTypeParser.Parse(txtFun3Remark.Text, typeof(string), null)
                };
                svc3Functions.Add(svcFunc1);
                svc3Functions.Add(svcFunc2);
                svc3Functions.Add(svcFunc3);

                bool isSuccessful = false;
                if (this._svcTestID.HasValue)
                {
                    // Update new service test and function
                    //int? statusUpdate = serviceSaver.Update(svcTest, this._salesService.SvcFactID.Value, svc3Functions, conn);
                    //if (statusUpdate.HasValue)
                    //    isSuccessful = true;
                }
                else // insert new service function
                {
                    // Add new service test and function
                    //List<SvcFunction> insertedSvcFunctions = serviceSaver.Add(svcTest, this._salesService.SvcFactID.Value, svc3Functions, conn);
                    List<SvcFunction> insertedSvcFunctions = serviceSaver.Add(svcTest, 0, svc3Functions, conn);
                    if (insertedSvcFunctions != null)
                    {
                        if (insertedSvcFunctions.Count > 0)
                        {
                            //   this._svcTestID = insertedSvcFunctions[0].SvcTestID;
                            this._svcFunctionOneID = insertedSvcFunctions[0].ID;
                        }
                        if (insertedSvcFunctions.Count > 1)
                            this._svcFunctionTwoID = insertedSvcFunctions[1].ID;
                        if (insertedSvcFunctions.Count > 2)
                            this._svcFunctionThreeID = insertedSvcFunctions[2].ID;
                    }
                    if (this._svcTestID.HasValue)
                        isSuccessful = true;
                }
                // Show message (fail or successful)
                if (isSuccessful)
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException sqle)
            {
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void SaveSvcFactoryRecord()
        {
            SqlConnection conn = null;
            int sup = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                SvcFactoryRecordBL serviceSaver = new SvcFactoryRecordBL();
                // Set service Factory Record
                SvcFactoryRecord svcFactoryRecord = new SvcFactoryRecord()
                {
                    ////ID = this._svcTestID.Value,
                    //ID = this._svcTestID,
                    SalesServiceID = (int)DataTypeParser.Parse(this._salesService.ID, typeof(int), 0),
                    FaultRemark = (string)DataTypeParser.Parse(txtTestFaultFact.Text, typeof(string), string.Empty),
                    AGM_Remark = (string)DataTypeParser.Parse(txtAgmRemark.Text, typeof(string), string.Empty),
                    DateAdded = DateTime.Now,
                    IsDeleted = false,
                    LastModified=DateTime.Now

                };
                sup = new SvcFactoryRecordBL().Add(svcFactoryRecord);
                if (sup > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (SqlException Sqle)
            {
                throw;
            }
        }

        private void SetSvcFactoryRecord()
        {
            DataTable dtSvcFacRecord = new SvcFactoryRecordBL().GetAllBySvcID(this._salesService.ID);

            if (dtSvcFacRecord.Rows.Count < 1)
                return;
            DataRow row = dtSvcFacRecord.Rows[0];

            txtAgmRemark.Text = row["AGM_Remark"].ToString();
            txtTestFaultFact.Text = row["FaultRemark"].ToString();
        }

        private void SaveSvcFactoryFunction()
        {
            SqlConnection conn = null;
            int sup = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                SvcFactoryFunctionBL serviceSaver = new SvcFactoryFunctionBL();
                // Set service Factory Record
                SvcFactoryFunction svcFactoryFunction = new SvcFactoryFunction();
                svcFactoryFunction.SalesServiceID = (int)DataTypeParser.Parse(this._salesService.ID, typeof(int), 0);
                svcFactoryFunction.FactoryFunction = (string)DataTypeParser.Parse(txtCheckingORSupporting.Text, typeof(string), string.Empty);
                svcFactoryFunction.FaultBy = Convert.ToChar(cmbCP.SelectedItem);
                svcFactoryFunction.Remark = (string)DataTypeParser.Parse(txtFactoryFunctionRemark.Text, typeof(string), string.Empty);
                svcFactoryFunction.SvcCheck = (string)DataTypeParser.Parse(txtTestAfterSvc.Text, typeof(string), string.Empty);
                svcFactoryFunction.DateAdded = DateTime.Now;
                svcFactoryFunction.LastModified = DateTime.Now;
                svcFactoryFunction.IsDeleted = false;

                sup = new SvcFactoryFunctionBL().Add(svcFactoryFunction);
                if (sup > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (SqlException Sqle)
            {
                throw;
            }
        }

        private void SetSvcFactoryFunction()
        {
            DataTable dtSvcFacFucn = new SvcFactoryFunctionBL().GetAllBySvcID(this._salesService.ID);

            if (dtSvcFacFucn.Rows.Count < 1)
                return;
            DataRow row = dtSvcFacFucn.Rows[0];

            txtCheckingORSupporting.Text = row["FactoryFunction"].ToString();
            cmbCP.SelectedItem = row["FaultBy"].ToString();
            txtFactoryFunctionRemark.Text = row["Remark"].ToString();
            txtTestAfterSvc.Text = row["SvcCheck"].ToString();
        }

        private void SaveSvcFunction(SvcFunction svcFunction)
        {
            SqlConnection conn = null;
            int sup = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                SvcFunctionBL serviceSaver = new SvcFunctionBL();
                // Set service Function 
                SvcFunction _svcFunction = new SvcFunction();
                _svcFunction = svcFunction;
                _svcFunction.DateAdded = DateTime.Now;
                _svcFunction.LastModified = DateTime.Now;

                sup = new SvcFunctionBL().AddSvcFunction(_svcFunction);
                if (sup > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (SqlException Sqle)
            {
                throw;
            }
        }

        private void SetSvcFunction()
        {
            DataTable dtSvcFucn = new SvcFunctionBL().GetAllByID(this._salesService.ID);

            if (dtSvcFucn.Rows.Count < 1)
                return;
            DataRow row = dtSvcFucn.Rows[0];
            btnSvcFunction1.Enabled = false;
            txtServicingDate.Text = TextFormat.ToAppDate((DateTime)DataTypeParser.Parse(row["SvcDate"], typeof(DateTime), DateTime.MinValue));
           // txtServicingDate.Text = (string)DataTypeParser.Parse(row["SvcDate"], typeof(string), string.Empty);
            dtpFun1Date.Value = (DateTime)DataTypeParser.Parse(row["SvcDate"], typeof(DateTime), DateTime.Now);
            dtpFun1From.Value = (DateTime)DataTypeParser.Parse(row["FromTime"], typeof(DateTime), DateTime.Now);
            dtpFun1To.Value = (DateTime)DataTypeParser.Parse(row["ToTime"], typeof(DateTime), DateTime.Now);
            cmbSvcFun1.SelectedIndex = (int)DataTypeParser.Parse(row["SvcFunctions"].ToString(), typeof(int), -1);
            txtFun1Volt.Text = row["Volt"].ToString();
            txtFun1P1.Text = row["RecPlus1"].ToString();
            txtFun1P2.Text = row["RecPlus2"].ToString();
            txtFun1P3.Text = row["RecPlus3"].ToString();
            txtFun1P4.Text = row["RecPlus4"].ToString();
            txtFun1P5.Text = row["RecPlus5"].ToString();
            txtFun1P6.Text = row["RecPlus6"].ToString();

            txtFun1M1.Text = row["RecMinus1"].ToString();
            txtFun1M2.Text = row["RecMinus2"].ToString();
            txtFun1M3.Text = row["RecMinus3"].ToString();
            txtFun1M4.Text = row["RecMinus4"].ToString();
            txtFun1M5.Text = row["RecMinus5"].ToString();
            txtFun1M6.Text = row["RecMinus6"].ToString();

            txtFun1Remark.Text = row["Remark"].ToString();

            if (dtSvcFucn.Rows.Count < 2) return;
            DataRow row2 = dtSvcFucn.Rows[1];
            btnSvcFunction2.Enabled = false;
            dtpFun2Date.Value = (DateTime)DataTypeParser.Parse(row2["SvcDate"], typeof(DateTime), DateTime.Now);
            dtpFun2From.Value = (DateTime)DataTypeParser.Parse(row2["FromTime"], typeof(DateTime), DateTime.Now);
            dtpFun2To.Value = (DateTime)DataTypeParser.Parse(row2["ToTime"], typeof(DateTime), DateTime.Now);
            cmbSvcFun2.SelectedIndex = (int)DataTypeParser.Parse(row2["Function"].ToString(), typeof(int), -1);
            txtFun2Volt.Text = row2["Volt"].ToString();
            txtFun2P1.Text = row2["RecPlus1"].ToString();
            txtFun2P2.Text = row2["RecPlus2"].ToString();
            txtFun2P3.Text = row2["RecPlus3"].ToString();
            txtFun2P4.Text = row2["RecPlus4"].ToString();
            txtFun2P5.Text = row2["RecPlus5"].ToString();
            txtFun2P6.Text = row2["RecPlus6"].ToString();

            txtFun2M1.Text = row2["RecMinus1"].ToString();
            txtFun2M2.Text = row2["RecMinus2"].ToString();
            txtFun2M3.Text = row2["RecMinus3"].ToString();
            txtFun2M4.Text = row2["RecMinus4"].ToString();
            txtFun2M5.Text = row2["RecMinus5"].ToString();
            txtFun2M6.Text = row2["RecMinus6"].ToString();

            txtFun2Remark.Text = row2["Remark"].ToString();

            if (dtSvcFucn.Rows.Count < 3) return;
            DataRow row3 = dtSvcFucn.Rows[2];
            btnSvnFunction3.Enabled = false;
            dtpFun3Date.Value = (DateTime)DataTypeParser.Parse(row3["SvcDate"], typeof(DateTime), DateTime.Now);
            dtpFun3From.Value = (DateTime)DataTypeParser.Parse(row3["FromTime"], typeof(DateTime), DateTime.Now);
            dtpFun3To.Value = (DateTime)DataTypeParser.Parse(row3["ToTime"], typeof(DateTime), DateTime.Now);
            cmbSvcFun3.SelectedIndex = (int)DataTypeParser.Parse(row3["SvcFunctions"].ToString(), typeof(int), -1);
            txtFun3Volt.Text = row3["Volt"].ToString();
            txtFun3P1.Text = row3["RecPlus1"].ToString();
            txtFun3P2.Text = row3["RecPlus2"].ToString();
            txtFun3P3.Text = row3["RecPlus3"].ToString();
            txtFun3P4.Text = row3["RecPlus4"].ToString();
            txtFun3P5.Text = row3["RecPlus5"].ToString();
            txtFun3P6.Text = row3["RecPlus6"].ToString();

            txtFun3M1.Text = row3["RecMinus1"].ToString();
            txtFun3M2.Text = row3["RecMinus2"].ToString();
            txtFun3M3.Text = row3["RecMinus3"].ToString();
            txtFun3M4.Text = row3["RecMinus4"].ToString();
            txtFun3M5.Text = row3["RecMinus5"].ToString();
            txtFun3M6.Text = row3["RecMinus6"].ToString();

            txtFun3Remark.Text = row3["Remark"].ToString();
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Open service battery detail form specified with Service Fact ID
        /// </summary>
        /// <param name="salesService"></param>
        /// <param name="serviceStatus"></param>
        /// <param name="brandName"></param>
        /// <param name="productName"></param>
        public frmServiceBatteryDetail
            (SalesService salesService,
            ServiceBatteryStatus serviceStatus,
            string brandName, string productName)
        {
            InitializeComponent();
            // Configure logger before use
            XmlConfigurator.Configure();
            // Set service fact id
            this._salesService = salesService;
            this._serviceStatus = serviceStatus;
            this._brandName = brandName;
            this._productName = productName;
            //  Load necessary data
            LoadNBindPreloadedData();
            LoadNBindCombo();
            //cmbTownship.SelectedIndex = -1;
            // Load and bind data
            LoadNBindData();
            // Disable service function and factory function when service fact has not been saved
            //if (!this._salesService.SvcFactID.HasValue)
            //{
            //    // TODO: Disable service function and factory function when service fact has not been saved
            //}
        }

        /// <summary>
        /// Open service battery detail form specified with Service Fact ID
        /// </summary>
        /// <param name="salesService"></param>
        /// <param name="serviceStatus"></param>
        /// <param name="brandName"></param>
        /// <param name="productName"></param>
        public frmServiceBatteryDetail
            (SalesService salesService)
        {
            InitializeComponent();
            // Configure logger before use
            XmlConfigurator.Configure();
            // Set service fact id
            this._salesService = salesService;
           //  Load necessary data
            LoadNBindPreloadedData();
            LoadNBindCombo();
            //cmbTownship.SelectedIndex = -1;
            // Load and bind data
            LoadNBindData();
            // Disable service function and factory function when service fact has not been saved
            //if (!this._salesService.SvcFactID.HasValue)
            //{
            //    // TODO: Disable service function and factory function when service fact has not been saved
            //}
        }

        #endregion

        #region Inner Class
        public class ServiceBatteryDetailEventArgs : EventArgs 
        {
            private bool _occuredChanges;
            public ServiceBatteryDetailEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        private void chkCustomerInformDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomerInformDate.Checked)
            {
                dtpContactDateToCus.Visible = true;
            }
            else
            {
                dtpContactDateToCus.Visible = false;
            }
        }

       
        
    }
}

