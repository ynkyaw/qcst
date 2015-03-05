/*
 * Author:  Wai Phyoe Thu <wpt.osp@gmail.com> 
 * Create date: 2014/04/27 (yyyy/MM/dd)
 * Description: Receipt Voucher (Multiple payments in a single receipt) Form
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using log4net;
using PTIC.Formatting;
using PTIC.Sale.BL;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Sale.OfficeSales;
using PTIC.VC.Util;
using PTIC.Sale.OfficeSales;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using PTIC.Util;
using PTIC.Sale.CashCollection;
using PTIC.Common;

namespace PTIC.VC.Sale.CashCollection
{
    /// <summary>
    /// Receipt voucher form to receive payments for multiple invoices
    /// </summary>
    public partial class frmReceipt_MultiInvoices : Form
    {
        /// <summary>
        /// Logger for frmReceipt_MultiInvoices
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmReceipt_MultiInvoices));

        /// <summary>
        /// 
        /// </summary>
        private Tax _tax = null;

        /// <summary>
        /// Order to be modified
        /// </summary>
        private List<Invoice> _cashSalesInvoices = null;

        /// <summary>
        /// Sale Commission DataTable
        /// </summary>
        private DataTable _dtSaleComm = null;

        /// <summary>
        /// 
        /// </summary>
        private int _saleCommPercentage = 0;

        /// <summary>
        /// 
        /// </summary>
        private int _cashCommPercentage = 0;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtCashDiscount = null;

        /// <summary>
        /// 
        /// </summary>
        private CommDiscount _commDiscount = null;

        /// <summary>
        /// Payment ID
        /// </summary> 
        private int id = 0;
        
        /*
        public frmReceipt_MultiInvoices(string InvoiceNo)
        {
            InitializeComponent();
            //LoadNBindInvoiceProductList(InvoiceNo);
            txtInvoiceNo.Text = InvoiceNo;           
        }
         */

        #region Events
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbCustomer.SelectedIndex != -1)
            //{
            //    txtContactPerson.Text = (string)DataTypeParser.Parse(dtCustomer.Rows[cmbCustomer.SelectedIndex]["ConPersonName"].ToString(), typeof(string), null);
            //}
        }

        private void txtInvoiceNo_Enter(object sender, EventArgs e)
        {
            string invoiceNo = (string)DataTypeParser.Parse(txtInvoiceNo.Text, typeof(string), 0);
            LoadNBindInvoiceProductList(invoiceNo);
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            string invoiceNo = (string)DataTypeParser.Parse(txtInvoiceNo.Text, typeof(string), 0);
            LoadNBindInvoiceProductList(invoiceNo);
        }

        private void dgvReceipt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            decimal totalQty = 0;
            decimal totalPackage = 0;
            decimal totalAmt = 0;
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
            decimal discountItemAmt = 0;
            foreach (DataGridViewRow row in dgvReceipt.Rows)
            {
                // if (row.Index == 0) return;
                try
                {
                    totalQty += (decimal)DataTypeParser.Parse(row.Cells["colQty"].Value, typeof(decimal), 0);
                    totalPackage += (decimal)DataTypeParser.Parse(row.Cells["colPackage"].Value, typeof(decimal), 0);
                    totalAmt += (decimal)DataTypeParser.Parse(row.Cells["colAmount"].Value, typeof(decimal), 0);
                    if ((bool)row.Cells[colHasDiscount.Index].Value)
                        discountItemAmt += (decimal)DataTypeParser.Parse(row.Cells["colAmount"].Value, typeof(decimal), 0);
                }
                catch (StackOverflowException ex)
                {
                    // TODO: Handle error
                }
            }

            txtTotalQty.Text = TextFormat.PointZeroPlace(totalQty);
            txtTotalPack.Text = TextFormat.PointZeroPlace(totalPackage);
            txtTotalAmt.Text = TextFormat.PointZeroPlace(totalAmt);
            txtDiscountItemsAmt.Text = TextFormat.PointZeroPlace(discountItemAmt);
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If current payment is not first payment
            if (cmbPayment.SelectedIndex != (int)PTIC.Common.Enum.PayType.First)
            {
                // Show Past Payment
                if (dgvReceipt.Rows.Count > 0)
                {
                    int invID = (int)DataTypeParser.Parse(dgvReceipt.Rows[0].Cells[dgvColInvoiceID.Index].Value, typeof(int), 0);
                    if (invID > 0)
                    {
                        decimal totalPastPayment = new PaymentBL().GetTotalPastPayment(invID);
                        txtPastPayment.Text = totalPastPayment.ToString(TextFormat.WholeNumber);
                    }
                }
            }
            else
                txtPastPayment.Text = string.Empty;

            if (cmbPayment.SelectedIndex == (int)PTIC.Common.Enum.PayType.Final)
            {
                // Enable discount and tax
                btnDiscount.Enabled = true;
                btnTax.Enabled = true;
                // Set current payment
                txtCurrentPayment.Text = CalculateCurrentPayment().ToString(TextFormat.WholeNumber);
            }
            else // First and Partialy payment
            {
                // Disable discount and tax because only final payment can feel discount and tax
                btnDiscount.Enabled = false;
                btnTax.Enabled = false;
                // Clear current payment
                txtCurrentPayment.Text = string.Empty;
            }

            // If there are no sale items of Sale invoice, disable discount and tax button
            DataTable dt = dgvReceipt.DataSource as DataTable;
            if (dt == null)
            {
                btnDiscount.Enabled = false;
                btnTax.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate and set net amount
            txtNetAmt.Text = CalculateNetAmount().ToString(TextFormat.WholeNumber);
            // Calculate and set current payment amount if final pay
            if (cmbPayment.SelectedIndex == (int)PTIC.Common.Enum.PayType.Final)
                txtCurrentPayment.Text = CalculateCurrentPayment().ToString(TextFormat.WholeNumber);
            //txtCurrentPayment.Text = txtNetAmt.Text;
        }

        private void txtBoxPayment_TextChanged(object sender, EventArgs e)
        {
            //decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            decimal NetAmt = Convert.ToDecimal(DataTypeParser.Parse(txtNetAmt.Text, typeof(decimal), 0));
            decimal pastPayment = Convert.ToDecimal(DataTypeParser.Parse(txtPastPayment.Text, typeof(decimal), 0));
            decimal currentPayment = Convert.ToDecimal(DataTypeParser.Parse(txtCurrentPayment.Text, typeof(decimal), 0));

            decimal balanceAmt = NetAmt - (pastPayment + currentPayment);
            txtBalanceAmt.Text = balanceAmt.ToString(TextFormat.WholeNumber);

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

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashCollectionPage));
            this.Close();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            if (totalAmt == 0)
                return;
            CommDiscount commDiscount = CalculateDiscount();
            string invoicesStr = string.Empty;
            int i = 0;
            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                invoicesStr = i == dgvInvoices.Rows.Count - 1 ?
                    invoicesStr + (string)DataTypeParser.Parse(row.Cells[colSaleInvoice.Index].Value, typeof(string), string.Empty) :
                    invoicesStr + (string)DataTypeParser.Parse(row.Cells[colSaleInvoice.Index].Value, typeof(string), string.Empty) + " / ";
                i++;
            }
            Invoice inv = new Invoice()
            {
                InvoiceNo = invoicesStr,
                SalesDate = dtpDate.Value,
                TotalAmt = totalAmt
            };
            float discountAmt=0;
            float.TryParse(txtDiscountItemsAmt.Text,out discountAmt);

            frmCommissionDiscount formComDiscount =
                new frmCommissionDiscount(inv, commDiscount, _saleCommPercentage, _cashCommPercentage, PTIC.Common.Enum.VoucherType.Credit,discountAmt);
            // Set call back handler
            formComDiscount.CommissionDiscountSavedHandler += new frmCommissionDiscount.CommissionDiscountSaveHandler(CommissionDiscount_CallBack);
            // Open form frmCommissionDiscount
            UIManager.OpenForm(formComDiscount);
        }

        private void CommissionDiscount_CallBack(object sender, frmCommissionDiscount.CommissionDiscountSaveEventArgs e)
        {
            if (e.CommDiscount != null)
            {
                if (this._commDiscount == null)
                    this._commDiscount = new CommDiscount();
                // Set CommDiscount
                this._commDiscount.PackingAmt = e.CommDiscount.PackingAmt;
                this._commDiscount.SaleCommAmt = e.CommDiscount.SaleCommAmt;
                this._commDiscount.CashCommAmt = e.CommDiscount.CashCommAmt;
                this._commDiscount.OtherCommAmt = e.CommDiscount.OtherCommAmt;
                this._commDiscount.RefundAmt = e.CommDiscount.RefundAmt;
                this._commDiscount.NeedAmt = e.CommDiscount.NeedAmt;
                this._commDiscount.TotalCommAmt = e.CommDiscount.TotalCommAmt;
                // Set commission amount
                txtCommDiscAmt.Text = Convert.ToString(DataTypeParser.Parse(_commDiscount.TotalCommAmt, typeof(string), string.Empty));
                // Calculate and set net amount
                txtNetAmt.Text = Convert.ToString(DataTypeParser.Parse(CalculateNetAmount(), typeof(string), string.Empty));
            }
        }

        private void btnTax_Click(object sender, EventArgs e)
        {
            decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            if (totalAmt == 0)
                return;
            string invoicesStr = string.Empty;
            int i = 0;
            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                invoicesStr = i == dgvInvoices.Rows.Count - 1 ?
                    invoicesStr + (string)DataTypeParser.Parse(row.Cells[colSaleInvoice.Index].Value, typeof(string), string.Empty) :
                    invoicesStr + (string)DataTypeParser.Parse(row.Cells[colSaleInvoice.Index].Value, typeof(string), string.Empty) + " / ";
                i++;
            }
            Invoice inv = new Invoice()
            {
                InvoiceNo = invoicesStr,
                SalesDate = dtpDate.Value,
                TotalAmt = totalAmt
            };
            frmTax formTax = new frmTax(inv);
            formTax.Width = 368;

            // Set call back handler
            formTax.TaxSavedHandler += new frmTax.TaxSaveHandler(Tax_CallBack);
            // Open form frmTax
            UIManager.OpenForm(formTax);
        }

        private void Tax_CallBack(object sender, frmTax.TaxSaveEventArgs e)
        {
            if (e.Tax == null)
                return;
            if (this._tax == null)
                this._tax = new Tax();
            // Set tax
            this._tax.InsuranceAmt = e.Tax.InsuranceAmt;
            this._tax.TaxAmt = e.Tax.TaxAmt;
            this._tax.TransportAmt = e.Tax.TransportAmt;
            this._tax.GateInvNo = e.Tax.GateInvNo;
            this._tax.GateInvPhoto = e.Tax.GateInvPhoto;
            this._tax.TotalAmt = e.Tax.TotalAmt;
            // TODO: Set transportation info
            //this._cashSalesInvoice.TransportTypeID = e.Invoice.TransportTypeID;
            //this._cashSalesInvoice.TransportGateID = e.Invoice.TransportGateID;
            // Set tax / other amount
            txtOtherAmt.Text = Convert.ToString(DataTypeParser.Parse(_tax.TotalAmt, typeof(string), string.Empty));
        }

        private void dgvInvoices_Click(object sender, EventArgs e)
        {
            OpenInvoicePickerForm();
        }

        private void invoiceSelection_CallBack(object sender, frmInvoicesPicker.InvoiceSelectionEventArgs args)
        {
            txtCommDiscAmt.Clear();
            txtOtherAmt.Clear();
            if (args.Invoices == null || args.Invoices.Count < 1)
            {
                dgvInvoices.DataSource = null;
                dgvReceipt.DataSource = null;
                txtTotalQty.Clear();
                txtTotalPack.Clear();
                txtTotalAmt.Clear();
                return;
            }

            // Load and bind invoice items
            LoadNBindInvoiceItems(args.Invoices);
        }

        private void cmbReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReceipt.SelectedIndex == 0)
            {
                cmbBank.SelectedIndex = -1;
                cmbBank.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //if (keyData == (Keys.Control | Keys.F3))
            if (keyData == Keys.F3)
            {
                OpenInvoicePickerForm();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Private Methods
        private void LoadNBindInitialData()
        {            
            try
            {                
                // Bind Bank Data
                DataTable dtBank = new BankBL().GetAll();
                cmbBank.DataSource = dtBank;
                // Get sale commission
                this._dtSaleComm = new SaleCommissionBL().GetAll();
                // Get cash discount
                this._dtCashDiscount = new CashDiscountBL().GetAll();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
                // TODO: show error message
            }            
        }

        private void LoadNBindInvoiceProductList(string invoiceNo)
        {            
            try
            {                
                int InvoiceID = 0;
                // Get Bank Data
                DataTable dtBank = new BankBL().GetAll();
                // Get SaleDetail Data
                DataTable dtSaleDetail = new InvoiceBL().GetSaleDetailByInvoiceNo(invoiceNo);

                // Get sale commission
                this._dtSaleComm = new SaleCommissionBL().GetAll();
                // Get cash discount
                this._dtCashDiscount = new CashDiscountBL().GetAll();

                dgvReceipt.AutoGenerateColumns = false;
                dgvReceipt.DataSource = dtSaleDetail;
                if (dtSaleDetail.Rows.Count > 0)
                {
                    txtTown.Text = (string)DataTypeParser.Parse(dtSaleDetail.Rows[0]["Town"].ToString(), typeof(string), null);
                    txtCusName.Text = (string)DataTypeParser.Parse(dtSaleDetail.Rows[0]["CusName"].ToString(), typeof(string), null);
                    txtContactPerson.Text = (string)DataTypeParser.Parse(dtSaleDetail.Rows[0]["ConPersonName"].ToString(), typeof(string), null);
                    InvoiceID = (int)DataTypeParser.Parse(dtSaleDetail.Rows[0]["InvoiceID"].ToString(), typeof(int), 0);

                    // Instantiate Order not assign yet
                    //if (_cashSalesInvoice == null)
                    //    _cashSalesInvoice = new Invoice();
                    // Make invoice present in current form
                    //_cashSalesInvoice.ID = InvoiceID;
                }

                // Bind Bank
                cmbBank.DataSource = dtBank;
                // Bind Employee
                txtSalePerson.Text = GlobalCache.LoginUser.EmpName;
                PaymentDA paymentDA = new PaymentDA();
                DataTable dtPayment = paymentDA.SelectAllByQuery(InvoiceID);

                if (dtPayment.Rows.Count > 0)
                {
                    if ((int)DataTypeParser.Parse(dtPayment.Rows[0]["PayType"], typeof(int), 0) ==
                        (int)PTIC.Common.Enum.PayType.First)
                    {
                        cmbPayment.SelectedIndex = (int)PTIC.Common.Enum.PayType.Partial;
                    }
                    else
                    {
                        cmbPayment.SelectedIndex = (int)DataTypeParser.Parse(dtPayment.Rows[0]["PayType"], typeof(int), 0);
                    }
                    cmbReceipt.SelectedIndex = (int)DataTypeParser.Parse(dtPayment.Rows[0]["CashReceiptType"], typeof(int), 0);
                }
            }
            catch (Exception e)
            {
                // TODO: show resonable error message to user
                _logger.Error(e);
                throw e;
            }           
        }

        private void LoadNBindInvoiceItems(List<Invoice> invoices)
        {            
            InvoiceBL invBL = null;
            try
            {                
                invBL = new InvoiceBL();
                // TODO: reduce round-trip query
                DataTable dtAllSaleDetail = invBL.GetSaleDetailByInvoiceNo(invoices[0].InvoiceNo);
                // Merge all sale details into a single table
                for (int i = 1; i < invoices.Count; i++)
                {
                    Invoice inv = invoices[i];
                    DataTable dtSaleDetail = invBL.GetSaleDetailByInvoiceNo(inv.InvoiceNo);
                    dtAllSaleDetail.Merge(dtSaleDetail);
                }
                
                var query = from rows in dtAllSaleDetail.AsEnumerable()
                            //group rows by rows.Field<int>("ProductID") into grp
                            group rows by new 
                            { 
                                ProductID = rows["ProductID"],
                                SalePrice = rows["SalePrice"]
                            }
                                into grp
                                let row = grp.First()
                                select new
                                {
                                    ProductID = row.Field<int>("ProductID"),
                                    ProductName = row.Field<string>("ProductName"),
                                    BrandName = row.Field<string>("BrandName"),
                                    Qty = grp.Sum(r => r.Field<int>("Qty")), // Calculate sum of Qty
                                    SalePrice = row.Field<decimal>("SalePrice"),
                                    Package = grp.Sum(r => r.Field<int?>("Package")), // Calculate sum of Package
                                    //Amount = grp.Sum(r => r.Field<int>("Qty")) * row.Field<decimal>("SalePrice"),
                                    Amount = grp.Sum(r => r.Field<int>("Qty")) * (decimal)DataTypeParser.Parse(grp.Key.SalePrice, typeof(decimal), 1), // Calculate sum of Amount
                                    InvoiceNo = row.Field<string>("InvoiceNo"),
                                    CusName = row.Field<string>("CusName"),
                                    Town = row.Field<string>("Town"),
                                    ConPersonName = row.Field<string>("ConPersonName"),
                                    MinPackQty = row.Field<int?>("MinPackQty"),
                                    DiscountAmtPerPack = row.Field<int?>("DiscountAmtPerPack"),
                                    HasDiscount = row.Field<bool?>("HasDiscount")
                                    
                                };
                            
                DataTable dtResult = DataUtil.ToDataTable(query.ToList());
                // Bind detail to dgvReceipt
                dgvReceipt.DataSource = dtResult;
                // Bind invoice to dgvInvoices
                dgvInvoices.DataSource = invoices;
                // Set invoices
                this._cashSalesInvoices = invoices;
                // TODO: Set Town, CustomerName, ContactPersonName
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    DataRow row = dtResult.Rows[0];
                    txtTown.Text = (string)DataTypeParser.Parse(row["Town"], typeof(string), string.Empty);
                    txtCusName.Text = (string)DataTypeParser.Parse(row["CusName"], typeof(string), string.Empty);
                    txtContactPerson.Text = (string)DataTypeParser.Parse(row["ConPersonName"], typeof(string), string.Empty);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
                // TODO: show reasonable error
            }
        }

        private void SaveData()
        {
            MultiInvoicesPaymentBL saver = new MultiInvoicesPaymentBL();
            Payment payment = new Payment();
            List<Invoice> invoices = new List<Invoice>();
                                                
            if (cmbPayment.SelectedIndex == 0)
            {
                payment.PayType = PTIC.Common.Enum.PayType.First;
            }
            else if (cmbPayment.SelectedIndex == 2)
            {
                payment.PayType = PTIC.Common.Enum.PayType.Final;
            }
            else
            {
                payment.PayType = PTIC.Common.Enum.PayType.Partial;                
            }

            if (cmbReceipt.SelectedIndex == 0)
            {
                payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Cash;
            }
            else if (cmbReceipt.SelectedIndex == 1)
            {
                payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Cheque;
            }
            else
            {
                payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Remittance;
            }

            payment.BankID = (int?)DataTypeParser.Parse(cmbBank.SelectedValue, typeof(int), null);
            payment.SalesPersonID = GlobalCache.LoginEmployee.ID;
            //payment.InvoiceID = (int)DataTypeParser.Parse(dgvReceipt.CurrentRow.Cells["dgvColInvoiceID"].Value, typeof(int), 0);
            payment.PayDate = dtpDate.Value;
            payment.TotalAmt = (decimal)DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0);
            payment.CommDisAmt = (decimal)DataTypeParser.Parse(txtCommDiscAmt.Text, typeof(decimal), 0);
            payment.OtherAmt = (decimal)DataTypeParser.Parse(txtOtherAmt.Text, typeof(decimal), 0);
            payment.PaidAmt = (decimal)DataTypeParser.Parse(txtCurrentPayment.Text, typeof(decimal), 0);

            if (payment.TotalAmt < 1)
            {
                MessageBox.Show("Please select sales invoices first!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (payment.PaidAmt < 1)
            {
                MessageBox.Show("ယခု‌ပေး‌ငွေ ထည့်သွင်းပေးပါ။", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            foreach(DataGridViewRow row in dgvInvoices.Rows)
            {
                int? invID = (int?)DataTypeParser.Parse(row.Cells[colSaleInvoiceID.Index].Value, typeof(int), null);
                if (!invID.HasValue)
                {
                    MessageBox.Show("Please select sales invoices first!", "Warning", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                invoices.Add(new Invoice() 
                {
                    ID = invID
                });
            }

            if (saver.Add(payment, invoices).HasValue)
            {
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                this.Close();
            }
            else
                MessageBox.Show(Resource.errFailedToSave, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private decimal CalculateNetAmount()
        {
            decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            decimal comDiscount = Convert.ToDecimal(DataTypeParser.Parse(txtCommDiscAmt.Text, typeof(decimal), 0));
            decimal otherCost = Convert.ToDecimal(DataTypeParser.Parse(txtOtherAmt.Text, typeof(decimal), 0));
            return (totalAmt - comDiscount) + otherCost;
        }

        private decimal CalculateCurrentPayment()
        {
            decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            decimal totalPastPayment = Convert.ToDecimal(DataTypeParser.Parse(txtPastPayment.Text, typeof(decimal), 0));
            decimal discountAmt = Convert.ToDecimal(DataTypeParser.Parse(txtCommDiscAmt.Text, typeof(decimal), 0));
            decimal otherCost = Convert.ToDecimal(DataTypeParser.Parse(txtOtherAmt.Text, typeof(decimal), 0));
            return (totalAmt - totalPastPayment - discountAmt) + otherCost;
        }

        private CommDiscount CalculateDiscount()
        {
            CommDiscount discount = new CommDiscount();
            decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            decimal packingDiscountAmt = 0;
            decimal saleCommAmt = 0;
            decimal cashDiscountAmt = 0;

            if (this._commDiscount == null)
                this._commDiscount = new CommDiscount();

            // Clear commission percentage
            this._saleCommPercentage = 0;
            this._cashCommPercentage = 0;

            // Get packing discount
            DataTable dt = dgvReceipt.DataSource as DataTable;
            if (dt == null || dt.Rows.Count < 1)
                return null;
            foreach (DataRow row in dt.Rows)
            {
                int minPackQty = (int)DataTypeParser.Parse(row["MinPackQty"], typeof(int), 0);
                int package = (int)DataTypeParser.Parse(row["Package"], typeof(int), 0);
                int discountAmtPerPack = (int)DataTypeParser.Parse(row["DiscountAmtPerPack"], typeof(int), 0);
                if (package >= minPackQty)
                {
                    packingDiscountAmt += package * discountAmtPerPack;
                }
            }
            // Get sale commission            
            DataRow[] saleCommRows = this._dtSaleComm.Select(string.Format("{0} >= CommAmt1 AND {0} <= CommAmt2", totalAmt));
            if (saleCommRows != null && saleCommRows.Length > 0)
            {
                decimal saleComPercentage = Convert.ToDecimal(DataTypeParser.Parse(saleCommRows[0]["SaleCommPercent"], typeof(int), 0));
                if (saleComPercentage > 0)
                {
                    saleCommAmt = (saleComPercentage / 100) * totalAmt;
                    // Set sale commission percentage
                    this._saleCommPercentage = (int)DataTypeParser.Parse(saleComPercentage, typeof(int), 0);
                    // Set sale commission id
                    this._commDiscount.SaleCommID = (int)DataTypeParser.Parse(saleCommRows[0]["SaleCommissionID"], typeof(int), null);
                }
            }
            // Get cash discount
            if (this._dtCashDiscount.Rows.Count > 0)
            {
                decimal cashComPercentage = Convert.ToDecimal(DataTypeParser.Parse(this._dtCashDiscount.Rows[this._dtCashDiscount.Rows.Count - 1]["CashCommPercent"], typeof(int), 0));
                if (cashComPercentage > 0)
                {
                    cashDiscountAmt = (cashComPercentage / 100) * totalAmt;
                    // Set cash commission percentage
                    this._cashCommPercentage = (int)DataTypeParser.Parse(cashComPercentage, typeof(int), 0);
                    // Set cash discount id
                    this._commDiscount.CashCommID =
                        (int)DataTypeParser.Parse(this._dtCashDiscount.Rows[this._dtCashDiscount.Rows.Count - 1]["CashDiscountID"], typeof(int), null);
                }
            }

            // Set commission and discount
            discount.PackingAmt = packingDiscountAmt;
            discount.SaleCommAmt = saleCommAmt;
            discount.CashCommAmt = cashDiscountAmt;
            discount.TotalCommAmt = packingDiscountAmt + saleCommAmt + cashDiscountAmt;
            return discount;
        }

        private void OpenInvoicePickerForm()
        {
            // Open invoice picker form
            frmInvoicesPicker invPicker = new frmInvoicesPicker();
            invPicker.InvoiceSelectedHandler += new frmInvoicesPicker.InvoiceSelectionHandler(invoiceSelection_CallBack);
            // Set call back handler
            UIManager.OpenForm(invPicker);
        }
        #endregion
        
        #region Constructor
        public frmReceipt_MultiInvoices()
        {
            InitializeComponent();
            // Disable auto generation columns
            dgvInvoices.AutoGenerateColumns = false;
            dgvReceipt.AutoGenerateColumns = false;

            cmbReceipt.SelectedIndex = (int)PTIC.Common.Enum.CashReceiptType.Cash;
            cmbBank.SelectedIndex = -1;
            // Instantiate invoice list
            _cashSalesInvoices = new List<Invoice>();
            // Load and bind initial data
            LoadNBindInitialData();
            // PayType must be Final in receiving cash for multiple invoices and enable discount and tax
            cmbPayment.SelectedIndex = (int)PTIC.Common.Enum.PayType.Final;
            btnDiscount.Enabled = true;
            btnTax.Enabled = true;
            txtCurrentPayment.Enabled = false;
            // Set saleperson name
            txtSalePerson.Text = GlobalCache.LoginEmployee.EmpName;
        }
        #endregion

        #region Inner Class
        public class ReceiptSaveEventArgs : EventArgs
        {
            private int? _InvoiceID = null;
            public ReceiptSaveEventArgs(int? InvoiceID)
            {
                this._InvoiceID = InvoiceID;
            }
            public int? InvoiceID
            {
                get { return this._InvoiceID; }
            }
        }
        #endregion
                                                
    }
}
