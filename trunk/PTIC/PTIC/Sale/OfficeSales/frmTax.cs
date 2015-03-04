/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/17 (yyyy/mm/dd)
 * Description: Tax form
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.BL;
using PTIC.Formatting;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmTax : Form
    {
        /// <summary>
        /// Logger for frmTax
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTax));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TaxSaveHandler(object sender, TaxSaveEventArgs e);

        public event TaxSaveHandler TaxSavedHandler;

        #region Events
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate and set total commission discount
            //txtTotalTaxAmt.Text = Convert.ToString(DataTypeParser.Parse(CalculateTotalTaxAmt(), typeof(string), string.Empty));
            txtTotalTaxAmt.Text = CalculateTotalTaxAmt().ToString(TextFormat.WholeNumber);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        private void frmTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            Approve();
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                )
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Private Methods
        private void LoadNBindNecessaryData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                DataSet ds = new DataSet();
                BindingSource bsTransportType = new BindingSource();
                BindingSource bsGate = new BindingSource();

                DataTable dtTransportType = new TransportTypeBL().GetAll();
                DataTable dtGate = new TransportGateBL().GetAll();

                ds.Tables.Add(dtTransportType);
                ds.Tables.Add(dtGate);

                // Create data relation between Gate and TransportType
                DataRelation relTransportType_Gate = new DataRelation("TransportType_Gate",
                    dtTransportType.Columns["TransportTypeID"], dtGate.Columns["TransportTypeID"]);

                ds.Relations.Add(relTransportType_Gate);

                bsTransportType.DataSource = ds;
                bsTransportType.DataMember = dtTransportType.TableName;

                bsGate.DataSource = bsTransportType;
                bsGate.DataMember = "TransportType_Gate";

                // Set transportation type
                cmbTransportType.DataSource = bsTransportType;
                // Set transportation gate
                cmbGate.DataSource = bsGate;

                // If there is more than one item, select the topmost item
                if (cmbTransportType.Items.Count > 0)
                    cmbTransportType.SelectedIndex = 0;
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private decimal CalculateTotalTaxAmt()
        {
            decimal totalTaxAmt = 0;
            try
            {
                decimal insuranceAmt = Convert.ToDecimal(DataTypeParser.Parse(txtInsuranceAmt.Text, typeof(decimal), 0));
                decimal taxAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTaxAmt.Text, typeof(decimal), 0));
                decimal transportAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTransportCharge.Text, typeof(decimal), 0));

                totalTaxAmt = insuranceAmt + taxAmt + transportAmt;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new Exception("Cannot calculate tax!");
            }
            return totalTaxAmt;
        }

        private void Approve()
        {
            // Pass Invoice and Tax to caller
            Invoice invoice = new Invoice()
            {
                TransportTypeID = (int)DataTypeParser.Parse(cmbTransportType.SelectedValue, typeof(int), -1),
                TransportGateID = (int)DataTypeParser.Parse(cmbGate.SelectedValue, typeof(int), -1)
            };
            Tax tax = new Tax()
            {
                InsuranceAmt = Convert.ToDecimal(DataTypeParser.Parse(txtInsuranceAmt.Text, typeof(decimal), 0)),
                TaxAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTaxAmt.Text, typeof(decimal), 0)),
                TransportAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTransportCharge.Text, typeof(decimal), 0)),
                TotalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalTaxAmt.Text, typeof(decimal), 0)),
                GateInvNo = (string)DataTypeParser.Parse(txtTransportInvNo.Text, typeof(string), 0),
                GateInvPhoto = PTIC.Util.ImageConverter.ToByteArray(picGateInvoice.Image)
            };
            TaxSaveEventArgs eArg = new TaxSaveEventArgs(invoice, tax);
            TaxSavedHandler(this, eArg);
            this.Close();
        }
        #endregion

        #region Constructors
        public frmTax()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind necessary data
            LoadNBindNecessaryData();
        }

        public frmTax(Invoice cashSalesInvoice)
            : this()
        {
            // Set values
            txtInvoiceNo.Text = cashSalesInvoice.InvoiceNo;
            //txtSalesAmt.Text = Convert.ToString(cashSalesInvoice.TotalAmt);
            txtSalesAmt.Text = cashSalesInvoice.TotalAmt.ToString(TextFormat.WholeNumber);
            dtpDate.Value = (DateTime)DataTypeParser.Parse(cashSalesInvoice.SalesDate, typeof(DateTime), DateTime.Now);
            cmbTransportType.SelectedValue = cashSalesInvoice.TransportTypeID;
            if (cashSalesInvoice.TransportGateID == null)
            {
                if (cmbGate.Items.Count == 0)
                {
                    //MessageBox.Show("Please define Gate Name");
                    ToastMessageBox.Show("ဂိတ်အမည် သတ်မှတ်‌ပေးပါ။", Color.Red);
                }
                else if (cmbGate.Items.Count > 0)
                {
                    cmbGate.SelectedIndex = 0;
                }
            }
            else
            {
                cmbGate.SelectedValue = cashSalesInvoice.TransportGateID;
            }


            txtTransportInvNo.Text = "";

            // TODO: Set GateInvoice Image
            //picGateInvoice.Image
        }
        #endregion

        #region Inner Class
        public class TaxSaveEventArgs : EventArgs
        {
            private Invoice _inv = null;
            private Tax _tax = null;
            public TaxSaveEventArgs(Invoice invoice, Tax tax)
            {
                this._inv = invoice;
                this._tax = tax;
            }
            public Invoice Invoice
            {
                get { return this._inv; }
            }
            public Tax Tax
            {
                get { return this._tax; }
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
