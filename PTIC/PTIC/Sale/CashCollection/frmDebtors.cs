/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/04/23 (yyyy/MM/dd)
 * Description: Debtors list file
 */
using System;
using System.Windows.Forms;
using PTIC.Common.BL;
using log4net;
using log4net.Config;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Sale.BL;
using System.Drawing;
using PTIC.Sale.CashCollection;
using System.Data;

namespace PTIC.VC.Sale.CashCollection
{
    /// <summary>
    /// Debtors list form
    /// </summary>
    public partial class frmDebtors : Form
    {
        /// <summary>
        /// Logger for frmDebtors
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmDebtors));

        private Payment _Payment = null;

        private BindingSource bdRoute = new BindingSource();
        private BindingSource bdTownship = new BindingSource();
        private BindingSource bdTownshipCustomerType = new BindingSource();
        private BindingSource bdTownshipCustomer = new BindingSource();
        
        private BindingSource bdTrip = new BindingSource();
        private BindingSource bdTown = new BindingSource();
        private BindingSource bdTownCustomerType = new BindingSource();
        private BindingSource bdTownCustomer = new BindingSource();

        /// <summary>
        /// Flag indicating frmDebtors form should be closed or not after saved
        /// </summary>
        private bool _needToClose = false;

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

        private void dgvDebtors_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Set Route/Trip value
            foreach (DataGridViewRow row in dgv.Rows)
            {                
                if (row.Cells[colRouteName.Index].Value != DBNull.Value)
                    row.Cells[colRoute_Trip.Index].Value = row.Cells[colRouteName.Index].Value;
                else
                    row.Cells[colRoute_Trip.Index].Value = row.Cells[colTripName.Index].Value;
            }
            // Set row number
            foreach (DataGridViewRow r in dgv.Rows)
            {
                dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashCollectionPage));
            this.Close();
        }

        private void dgvDebtors_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.CurrentRow == null)
                return;
            //colInvoiceID.
            int invoiceID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells["colInvoiceID"].Value, typeof(int), -1);
            LoadNBindPayment(invoiceID);
        }

        private void dgvPayment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView == null || gridView.Rows.Count <= 0)
                return;
            decimal balance = (decimal)DataTypeParser.Parse(gridView.Rows[0].Cells["colTotalAmt"].Value, typeof(decimal), 0);
            foreach (DataGridViewRow row in gridView.Rows)
            {
                gridView.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();

                // Show pay type description
                if ((int)DataTypeParser.Parse(row.Cells[colPayTypeText.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.PayType.First)
                {
                    row.Cells[colPaymentType.Index].Value = PTIC.Common.Enum.PayType.First;
                }
                else if ((int)DataTypeParser.Parse(row.Cells[colPayTypeText.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.PayType.Partial)
                {
                    row.Cells[colPaymentType.Index].Value = PTIC.Common.Enum.PayType.Partial;
                }
                else
                {
                    row.Cells[colPaymentType.Index].Value = PTIC.Common.Enum.PayType.Final;
                }
                // Show cash receipt type
                if ((int)DataTypeParser.Parse(row.Cells[colCashTypeID.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.CashReceiptType.Cash)
                {
                    row.Cells[colCashType.Index].Value = PTIC.Common.Enum.CashReceiptType.Cash;
                }
                else if ((int)DataTypeParser.Parse(row.Cells[colCashTypeID.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.CashReceiptType.Cheque)
                {
                    row.Cells[colCashType.Index].Value = PTIC.Common.Enum.CashReceiptType.Cheque;
                }
                else
                {
                    row.Cells[colCashType.Index].Value = PTIC.Common.Enum.CashReceiptType.Remittance;
                }
                // Calculate and set individual balance for each payment
                balance = balance - (decimal)DataTypeParser.Parse(row.Cells["colPaidAmt"].Value, typeof(decimal), 0);
                row.Cells["colBalance"].Value = balance;
            }
            // If balance amount is greater than zero, format it in red as notified
            if (balance > 0)
            {
                DataGridViewRow row = gridView.Rows[gridView.Rows.Count - 1];
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.BackColor = Color.OrangeRed;
                row.Cells[colBalance.Index].Style = cellStyle;
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            if (dgvDebtors.Rows.Count <= 0) return;
            string InvoiceNo = (string)DataTypeParser.Parse(dgvDebtors.CurrentRow.Cells["colSaleInvoiceNo"].Value, typeof(string), 0);
            int InvoiceID = (int)DataTypeParser.Parse(dgvDebtors.CurrentRow.Cells["colInvoiceID"].Value, typeof(int), 0);
            frmReceipt frmReceipts = new frmReceipt(InvoiceNo);
            UIManager.OpenForm(frmReceipts);
            LoadNBindDebtors();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            // Load and bind debtors
            LoadNBindDebtors();
        }
        
        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
                cmbCustomerName.Enabled = (sender as CheckBox).Checked;
        }
        
        private void chkCustomerType_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
                cmbCustomerType.Enabled = (sender as CheckBox).Checked;
        }

        private void chkTownTownship_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
                cmbTownTownship.Enabled = (sender as CheckBox).Checked;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
                dtpStartDate.Enabled = dtpEndDate.Enabled = (sender as CheckBox).Checked;
        }

        private void frmDebtors_Load(object sender, EventArgs e)
        {

        }

        private void dgvDebtors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var dgvDebtors = sender as DataGridView;
            //string invoiceNo = (string)DataTypeParser.Parse(dgvDebtors.CurrentRow.Cells["colSaleInvoiceNo"].Value, typeof(string), 0);
            //if (e.RowIndex < 0 || e.ColumnIndex != dgvDebtors.Columns["colReceipt"].Index)
            //    return;
            //frmReceipt frmReceipts = new frmReceipt(invoiceNo);
            //UIManager.OpenForm(frmReceipts);
        }

        private void ReceiptSave_CallBack(object sender, frmReceipt.ReceiptSaveEventArgs e)
        {
            if (e.InvoiceID.HasValue)
            {
                // Set InvoiceID to be refered by Payment
                _Payment.InvoiceID = e.InvoiceID;
                // No need to close this form after saved
                _needToClose = false;
            }
        }

        private void rdoTrip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTrip.Checked)
            {
                cmbTripOrRoute.DataSource = bdTrip;
                cmbTripOrRoute.ValueMember = "TripID";
                cmbTripOrRoute.DisplayMember = "TripName";

                cmbTownTownship.DataSource = bdTown;                
                cmbTownTownship.ValueMember = "TownID";
                cmbTownTownship.DisplayMember = "Town";

                cmbCustomerType.DataSource = bdTownCustomerType;
                cmbCustomerName.DataSource = bdTownCustomer;

                cmbTripOrRoute.Focus();
            }
        }

        private void rdoRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRoute.Checked)
            {
                cmbTripOrRoute.DataSource = bdRoute;
                cmbTripOrRoute.ValueMember = "RouteID";
                cmbTripOrRoute.DisplayMember = "RouteName";

                cmbTownTownship.DataSource = bdTownship;
                cmbTownTownship.ValueMember = "TownshipID";
                cmbTownTownship.DisplayMember = "Township";

                cmbCustomerType.DataSource = bdTownshipCustomerType;
                cmbCustomerName.DataSource = bdTownshipCustomer;

                cmbTripOrRoute.Focus();
            }
        }
        #endregion

        #region Private Methods
        private void LoadNBindFilterData()
        {
            try
            {
                CustomerBL customerBL = new CustomerBL();
                DataTable dtCustomers = customerBL.GetAll();
                DataTable dtTripCustomer = dtCustomers.Copy();

                // Routes
                DataTable dtRoute = new RouteBL().GetAll();
                // Add ALL filter in route
                DataRow allRoute= dtRoute.NewRow();
                allRoute["RouteID"] = -1;
                allRoute["RouteName"] = "All";
                // insert in the Index 0 place
                dtRoute.Rows.InsertAt(allRoute, 0);
                // Townships in route
                DataTable dtTownshipInRoute = new TownshipInRouteBL().GetAll();
                // CustomerType in Township
                DataTable dtCusTypeInTownship = customerBL.GetCusTypeInTownship();

                // Add Route, TownshipInRoute and Customer tables into a dataset
                DataSet dsRouteCustomers = new DataSet();
                dsRouteCustomers.Tables.Add(dtRoute);
                dsRouteCustomers.Tables.Add(dtTownshipInRoute);
                dsRouteCustomers.Tables.Add(dtCusTypeInTownship);
                dsRouteCustomers.Tables.Add(dtCustomers);
                // Create data relation among Route, TownshipInRoute and Customer
                DataRelation relRoute_Township = new DataRelation("Route_Township", dtRoute.Columns["RouteID"], dtTownshipInRoute.Columns["RouteID"], false);                
                DataRelation relTownship_CusType = new DataRelation("Township_CusType", dtTownshipInRoute.Columns["TownshipID"], dtCusTypeInTownship.Columns["TownshipID"], false);
                //DataRelation relCusType_Customer = new DataRelation("CusType_Customer", dtCusTypeInTownship.Columns["TownshipID"], dtCustomers.Columns["TownshipID"], false);
                DataRelation relCusType_Customer =
                    new DataRelation("CusType_TownshipCustomer", 
                        new DataColumn[] { dtCusTypeInTownship.Columns["CusType"], dtCusTypeInTownship.Columns["TownshipID"] },
                        new DataColumn[] { dtCustomers.Columns["CusType"], dtCustomers.Columns["TownshipID"] }, false);
                // Add relation into a dataset
                dsRouteCustomers.Relations.Add(relRoute_Township);
                dsRouteCustomers.Relations.Add(relTownship_CusType);
                dsRouteCustomers.Relations.Add(relCusType_Customer);

                bdRoute.DataSource = dsRouteCustomers;
                bdRoute.DataMember = dtRoute.TableName;

                bdTownship.DataSource = bdRoute;
                bdTownship.DataMember = "Route_Township";
                
                bdTownshipCustomerType.DataSource = bdTownship;
                bdTownshipCustomerType.DataMember = "Township_CusType";

                bdTownshipCustomer.DataSource = bdTownshipCustomerType;
                bdTownshipCustomer.DataMember = "CusType_TownshipCustomer";

                //-------------------------------- Customers in Trip -------------------------------------
                // Trips
                DataTable dtTrip = new TripBL().GetAll();
                // Add ALL filter in trip
                DataRow allTrip = dtTrip.NewRow();
                allTrip["TripID"] = -1;
                allTrip["TripName"] = "All";
                dtTrip.Rows.InsertAt(allTrip, 0);
                // Towns in Trip
                DataTable dtTownInTrip = new TownInTripBL().GetAll();
                // CustomerType in Town
                DataTable dtCusTypeInTown = customerBL.GetCusTypeInTown();

                // Add Trip, TownInTrip and Customer tables into a dataset
                DataSet dsTripCustomers = new DataSet();
                dsTripCustomers.Tables.Add(dtTrip);
                dsTripCustomers.Tables.Add(dtTownInTrip);
                dsTripCustomers.Tables.Add(dtCusTypeInTown);
                dsTripCustomers.Tables.Add(dtTripCustomer);
                // Create data relation among Trip, TownInTrip and Customers
                DataRelation relTrip_Town = new DataRelation("Trip_Town", dtTrip.Columns["TripID"], dtTownInTrip.Columns["TripID"], false);
                DataRelation relTown_CusType = new DataRelation("Town_CusType", dtTownInTrip.Columns["TownID"], dtCusTypeInTown.Columns["TownID"], false);
                //DataRelation relCusType_TownCustomer = new DataRelation("CusType_TownCustomer", dtTownInTrip.Columns["TownID"], dtTripCustomer.Columns["TownID"], false);
                DataRelation relCusType_TownCustomer = 
                    new DataRelation("CusType_TownCustomer",
                        new DataColumn[] { dtCusTypeInTown.Columns["CusType"], dtCusTypeInTown.Columns["TownID"] },
                        new DataColumn[] { dtTripCustomer.Columns["CusType"], dtTripCustomer.Columns["TownID"] }, false);
                // Add relation into a dataset
                dsTripCustomers.Relations.Add(relTrip_Town);
                dsTripCustomers.Relations.Add(relTown_CusType);
                dsTripCustomers.Relations.Add(relCusType_TownCustomer);

                bdTrip.DataSource = dsTripCustomers;
                bdTrip.DataMember = dtTrip.TableName;

                bdTown.DataSource = bdTrip;
                bdTown.DataMember = "Trip_Town";

                bdTownCustomerType.DataSource = bdTown;
                bdTownCustomerType.DataMember = "Town_CusType";

                bdTownCustomer.DataSource = bdTownCustomerType;
                bdTownCustomer.DataMember = "CusType_TownCustomer";
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }

        private void LoadNBindDebtors()
        {
            try
            {
                this.dgvDebtors.DataSource = new ReportBL().GetDebtors();
                if (this.dgvDebtors.Rows.Count <= 0)
                    this.dgvPayment.DataSource = null;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNBindPayment(int? invoiceID)
        {
            try
            {
                this.dgvPayment.DataSource = new PaymentBL().GetAllReceipt(invoiceID);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search()
        {
            int? tripID = null, routeID = null, townID = null, townshipID = null, customerTypeID = null, customerID = null;
            DateTime? startDate = null, endDate = null;

            try
            {
                if (rdoRoute.Checked)
                {
                    // routeID that less than 1 means ALL routes 
                    routeID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), null);
                    if (chkTownTownship.Checked)
                        townshipID = (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), null);
                }
                else // if Trip is checked
                {
                    // tripID that less than 1 means ALL trips
                    tripID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), null);
                    if (chkTownTownship.Checked)
                        townID = (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), null);
                }

                if (chkCustomerType.Checked)
                    customerTypeID = (int?)DataTypeParser.Parse(cmbCustomerType.SelectedValue, typeof(int), null);
                if (chkCustomerName.Checked)
                    customerID = (int?)DataTypeParser.Parse(cmbCustomerName, typeof(int), null);
                if (chkDate.Checked)
                {
                    startDate = (DateTime?)DataTypeParser.Parse(dtpStartDate.Value, typeof(DateTime), null);
                    endDate = (DateTime?)DataTypeParser.Parse(dtpEndDate.Value, typeof(DateTime), null);
                }
                // Get searched result
                this.dgvDebtors.DataSource = new ReportBL().GetDebtorBy(
                    tripID, routeID, townID, townshipID, customerTypeID, customerID, startDate, endDate);
                if (this.dgvDebtors.Rows.Count <= 0)
                    this.dgvPayment.DataSource = null;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }
        #endregion

        #region Constructors
        public frmDebtors()
        {
            InitializeComponent();
            // Disable column auto-generation
            dgvDebtors.AutoGenerateColumns = false;
            dgvPayment.AutoGenerateColumns = false;
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind filter data
            LoadNBindFilterData();
            // Prepare filter control
            rdoTrip.Checked = true;
            // Load and bind debtors
            LoadNBindDebtors();
        }
        #endregion
                        
    }
}
