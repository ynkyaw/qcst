/*
 * Author:  AUNG KO KO <waiphyoaungko@gmail.com>
 *              Wai Phyoe Thu <wpt.osp@gmail.com>
 * Create date: 2014/04/22 (yyyy/MM/dd)
 * Description: Receipt Voucher Form
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Common.BL;
using PTIC.Formatting;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Sale.OfficeSales;
using PTIC.Sale.CashCollection;
using PTIC.Util;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Sale.CashCollection
{
    public partial class frmReceipt : Form
    {
        /// <summary>
        /// Logger for frmReceipt
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmReceipt));

        /// <summary>
        /// 
        /// </summary>
        private Tax _tax = null;

        /// <summary>
        /// Selected invoice
        /// </summary>
        private Invoice _cashSalesInvoice = null;

        /// <summary>
        /// Sale Commission DataTable
        /// </summary>
        private DataTable _dtSaleComm = null;

        /// <summary>
        /// 
        /// </summary>
        private float _saleCommPercentage = 0;

        /// <summary>
        /// 
        /// </summary>
        private float _cashCommPercentage = 0;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtCashDiscount = null;

        /// <summary>
        /// 
        /// </summary>
        private CommDiscount _commDiscount = null;

        bool NotFirst = false;

        int id = 0;
        public frmReceipt()
        {
            InitializeComponent();
            cmbReceipt.SelectedIndex = 0;
            cmbPayment.SelectedIndex = 0;

            // Load Data and Bind Each Combo
            //LoadNBind();
        }

        public frmReceipt(string InvoiceNo)
        {
            InitializeComponent();
            //LoadNBindInvoiceProductList(InvoiceNo);
            txtInvoiceNo.Text = InvoiceNo;
        }

        #region Private Methods
        private void LoadNBindInvoiceProductList(string InvoiceNo)
        {            
            try
            {                
                int InvoiceID = 0;
                // Get Bank Data
                DataTable dtBank = new BankBL().GetAll();
                // Get SaleDetail Data
                DataTable dtSaleDetail = new InvoiceBL().GetSaleDetailByInvoiceNo(InvoiceNo);

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
                    txtPriceRemark.Text = (string)DataTypeParser.Parse(dtSaleDetail.Rows[0]["Remark"], typeof(string), null);
                    
                    InvoiceID = (int)DataTypeParser.Parse(dtSaleDetail.Rows[0]["InvoiceID"].ToString(), typeof(int), 0);
                   // Instantiate Invoice not assign yet
                    if (_cashSalesInvoice == null)
                        _cashSalesInvoice = new Invoice();
                    // Make invoice present in current form
                    _cashSalesInvoice.ID = InvoiceID;
                }

                // Bind Bank
                cmbBank.DataSource = dtBank;
                // Bind Employee
                //txtSalePerson.Text = GlobalCache.loginUser.EmpName;
                int deptID = -1;
                if (Program.module == Program.Module.Sale)
                    deptID = (int)PTIC.Common.Enum.PredefinedDepartment.Sales;
                if (Program.module == Program.Module.Marketing)
                    deptID = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
                cmbReceiver.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID", deptID);

                PaymentDA paymentDA = new PaymentDA();
                DataTable dtPayment = paymentDA.SelectAllByQuery(InvoiceID);
                if (dtPayment.Rows.Count > 0)
                {
                    // TODO: ?
                    if ((int)DataTypeParser.Parse(dtPayment.Rows[0]["PayType"], typeof(int), 0) ==
                        (int)PTIC.Common.Enum.PayType.First)
                    {
                        NotFirst = true;
                        cmbPayment.SelectedIndex = (int)PTIC.Common.Enum.PayType.Partial;
                    }
                    else
                    {
                        //cmbPayment.SelectedIndex = (int)DataTypeParser.Parse(dtPayment.Rows[0]["PayType"], typeof(int), 0);
                        cmbPayment.SelectedIndex = (int)DataTypeParser.Parse(dtPayment.Rows[0]["PayType"], typeof(int), 0);
                    }
                    cmbReceipt.SelectedIndex = (int)DataTypeParser.Parse(dtPayment.Rows[0]["CashReceiptType"], typeof(int), 0);
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private void SaveData()
        {
            try
            {
                PaymentBL paymentBL = new PaymentBL();
                Payment payment = new Payment();
                if (this.id != 0)
                {
                    payment.ID = this.id;
                }
                                
                if (cmbPayment.SelectedIndex == (int)PTIC.Common.Enum.PayType.First)
                {
                    payment.PayType = PTIC.Common.Enum.PayType.First;
                }
                else if (cmbPayment.SelectedIndex == (int)PTIC.Common.Enum.PayType.Partial)
                {
                    payment.PayType = PTIC.Common.Enum.PayType.Partial;
                }
                else if (cmbPayment.SelectedIndex == (int)PTIC.Common.Enum.PayType.Final)
                {
                    payment.PayType = PTIC.Common.Enum.PayType.Final;
                }                

                if (cmbReceipt.SelectedIndex == (int)PTIC.Common.Enum.CashReceiptType.Cash)
                {
                    payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Cash;
                }
                else if (cmbReceipt.SelectedIndex == (int)PTIC.Common.Enum.CashReceiptType.Cheque)
                {
                    payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Cheque;
                }
                else if (cmbReceipt.SelectedIndex == (int)PTIC.Common.Enum.CashReceiptType.Remittance)
                {
                    payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Remittance;
                }

                if (cmbBank.SelectedIndex == -1)
                {
                    payment.BankID = null;
                }
                else
                {
                    payment.BankID = (int)DataTypeParser.Parse(cmbBank.SelectedValue, typeof(int), null);
                }
                decimal tmp = (decimal)DataTypeParser.Parse(txtBalanceAmt.Text, typeof(decimal), 0);
                int tmpcmb = (int)DataTypeParser.Parse(cmbPayment.SelectedIndex, typeof(int), -1);
                /*
                if ((decimal)DataTypeParser.Parse(txtCurrentPayment.Text, typeof(decimal), 0) <= 0)
                {
                    MessageBox.Show("ယခုပေးငွေမှားယွင်းနေပါသည်။", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                 */ 

                /*
                if ((decimal)DataTypeParser.Parse(txtBalanceAmt.Text, typeof(decimal), 0) == 0 && (int)DataTypeParser.Parse(cmbPayment.SelectedIndex, typeof(int), -1) != (int)PTIC.Common.Enum.PayType.Final)
                {
                    MessageBox.Show("Payment Type ကို Final ရွေးပါ။", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                 */ 

                payment.SalesPersonID = (int)DataTypeParser.Parse(cmbReceiver.SelectedValue, typeof(int), -1);
                payment.InvoiceID = (int)DataTypeParser.Parse(dgvReceipt.CurrentRow.Cells["dgvColInvoiceID"].Value, typeof(int), 0);
                payment.PayDate = dtpDate.Value;
                payment.CommDisAmt = (decimal)DataTypeParser.Parse(txtCommDiscAmt.Text, typeof(decimal), 0);
                payment.OtherAmt = (decimal)DataTypeParser.Parse(txtOtherAmt.Text, typeof(decimal), 0);
                payment.PaidAmt = (decimal)DataTypeParser.Parse(txtCurrentPayment.Text, typeof(decimal), 0);               
                payment.IsDeleted = false;
                if (payment.ID == 0)
                {
                    payment.DateAdded = DateTime.Now.Date;
                }
                else
                {
                    payment.LastModified = DateTime.Now.Date;
                }

               string ReceiptNo = (string)DataTypeParser.Parse(txtReceiptNo.Text, typeof(string), string.Empty);
               if (ReceiptNo == string.Empty || ReceiptNo == "")
               {
                   payment.ReceiptNo = null;
               }
               else
               {
                   payment.ReceiptNo = ReceiptNo; // When user enter receipt no instead system auto-generated no
               }
                // Save payment
                paymentBL.Add(payment);

                if (!paymentBL.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(paymentBL.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    // Select control needed to enter value
                    if (
                        !string.IsNullOrEmpty(err.Key)
                        && err.Key.Equals("Payment_PayType_Select_FirstOrFinal")
                        || err.Key.Equals("Payment_PayType_Require")
                        )
                    {
                        cmbPayment.SelectedIndex = 0;
                    }
                    else if (!string.IsNullOrEmpty(err.Key) && err.Key.Equals("Payment_PayType_Select_PartialOrFinal"))
                    {
                        cmbPayment.SelectedIndex = 1;
                    }
                    else if (!string.IsNullOrEmpty(err.Key) && err.Key.Equals("Payment_CashReceiptType_Require"))
                    {
                        cmbReceipt.SelectedIndex = 0;
                    }
                    else if (!string.IsNullOrEmpty(err.Key) 
                        && err.Key.Equals("PaidAmt")
                        || err.Key.Equals("Payment_PaidAmt_MustLessThanCreditAmt"))
                    {
                        txtCurrentPayment.Focus();
                    }
                    return;
                }

                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        #endregion

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
            string InvoiceID = (string)DataTypeParser.Parse(txtInvoiceNo.Text, typeof(string), 0);
            LoadNBindInvoiceProductList(InvoiceID);
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            string InvoiceID = (string)DataTypeParser.Parse(txtInvoiceNo.Text, typeof(string), string.Empty);
            LoadNBindInvoiceProductList(InvoiceID);
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
                    if((bool)row.Cells[colHasDiscount.Index].Value)
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
            txtDiscountItemAmt.Text = TextFormat.PointZeroPlace(discountItemAmt);
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotFirst == true && cmbPayment.SelectedIndex == 0)
            {
                cmbPayment.SelectedIndex = 1;
            }
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
                txtCurrentPayment.Enabled = false;
            }
            else // First and Partialy payment
            {
                // Disable discount and tax because only final payment can feel discount and tax
                btnDiscount.Enabled = false;
                btnTax.Enabled = false;
                // Clear current payment
                txtCurrentPayment.Text = string.Empty;
                txtCurrentPayment.Enabled = true;
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
            if (cmbPayment.SelectedIndex == -1)
            {
                MessageBox.Show(
                    PTIC.Sale.ErrorMessages.Payment_PayType_Require,
                    this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
            else if (cmbReceipt.SelectedIndex == -1)
            {
                MessageBox.Show(
                    PTIC.Sale.ErrorMessages.Payment_CashReceiptType_Require,
                    this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
             
            // Save payment
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
            decimal NetAmt = Convert.ToDecimal(DataTypeParser.Parse(txtNetAmt.Text, typeof(decimal), 0));
            decimal pastPayment = Convert.ToDecimal(DataTypeParser.Parse(txtPastPayment.Text, typeof(decimal), 0));
            decimal currentPayment = Convert.ToDecimal(DataTypeParser.Parse(txtCurrentPayment.Text, typeof(decimal), 0));
            if (currentPayment > (NetAmt - pastPayment))
            {                
                MessageBox.Show(
                    PTIC.Sale.ErrorMessages.Payment_PaidAmt_MustLessThanCreditAmt, 
                    this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCurrentPayment.Text = "0";
                decimal payment = Convert.ToDecimal(DataTypeParser.Parse(txtCurrentPayment.Text, typeof(decimal), 0));
                decimal balanceAmt = NetAmt - (pastPayment + payment);
                txtBalanceAmt.Text = balanceAmt.ToString(TextFormat.WholeNumber);
                return;
            }
            else
            {
                decimal balanceAmt = NetAmt - (pastPayment + currentPayment);
                txtBalanceAmt.Text = balanceAmt.ToString(TextFormat.WholeNumber);
            }
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

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            CommDiscount commDiscount = CalculateDiscount();
            Invoice inv = new Invoice()
            {
                InvoiceNo = txtInvoiceNo.Text,
                SalesDate = dtpDate.Value,
                TotalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0))
            };
            float discoutItemAmt = 0;
            float.TryParse(txtDiscountItemAmt.Text, out discoutItemAmt);

            frmCommissionDiscount formComDiscount =
                new frmCommissionDiscount(inv, commDiscount, _saleCommPercentage, _cashCommPercentage, PTIC.Common.Enum.VoucherType.Credit, discoutItemAmt);
            // set call back handler
            formComDiscount.CommissionDiscountSavedHandler += new frmCommissionDiscount.CommissionDiscountSaveHandler(CommissionDiscount_CallBack);
            // Open form frmCommissionDiscount
            UIManager.OpenForm(formComDiscount);
        }

        void CommissionDiscount_CallBack(object sender, frmCommissionDiscount.CommissionDiscountSaveEventArgs e)
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
                decimal saleComPercentage = Convert.ToDecimal(DataTypeParser.Parse(saleCommRows[0]["SaleCommPercent"], typeof(decimal), 0));
                if (saleComPercentage > 0)
                {
                    saleCommAmt = (saleComPercentage / 100) * totalAmt;
                    // Set sale commission percentage
                    this._saleCommPercentage = (float)DataTypeParser.Parse(saleComPercentage, typeof(float), 0);
                    // Set sale commission id
                    this._commDiscount.SaleCommID = (int)DataTypeParser.Parse(saleCommRows[0]["SaleCommissionID"], typeof(int), null);
                }
            }
            // Get cash discount
            if (this._dtCashDiscount.Rows.Count > 0)
            {
                decimal cashComPercentage = Convert.ToDecimal(DataTypeParser.Parse(this._dtCashDiscount.Rows[this._dtCashDiscount.Rows.Count - 1]["CashCommPercent"], typeof(decimal), 0));
                if (cashComPercentage > 0)
                {
                    cashDiscountAmt = (cashComPercentage / 100) * totalAmt;
                    // Set cash commission percentage
                    this._cashCommPercentage = (float)DataTypeParser.Parse(cashComPercentage, typeof(float), 0);
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

        private void btnTax_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice()
            {
                InvoiceNo = txtInvoiceNo.Text,
                SalesDate = dtpDate.Value,
                TotalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0))
            };
            frmTax formTax = new frmTax(inv);
            // set call back handler
            //formComDiscount.CommissionDiscountSavedHandler += new frmCommissionDiscount.CommissionDiscountSaveHandler(CommissionDiscount_CallBack);
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
            // Set transportation info
            this._cashSalesInvoice.TransportTypeID = e.Invoice.TransportTypeID;
            this._cashSalesInvoice.TransportGateID = e.Invoice.TransportGateID;
            // Set tax / other amount
            txtOtherAmt.Text = Convert.ToString(DataTypeParser.Parse(_tax.TotalAmt, typeof(string), string.Empty));
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

        private void dgvReceipt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //var dgv = sender as DataGridView;
            //if (e.ColumnIndex == colProduct.Index)
            //{
            //    foreach (DataGridViewRow row in dgv.Rows)
            //    {
            //        if (row.Index != e.RowIndex & !row.IsNewRow)
            //        {
            //            if (row.Cells["colProduct"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
            //            if (row.Cells["colProduct"].FormattedValue.ToString() == e.FormattedValue.ToString())
            //            {
            //                dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
            //                MessageBox.Show("Duplicate Not Allowed!");
            //                // return;
            //            }
            //            else
            //            {
            //                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            //            }
            //        }
            //    }
            //}
        }

        private void dgvReceipt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colProduct.Index)
            {
                dgv.CurrentRow.Cells[colProduct.Index].Value = -1;
                dgv.CurrentRow.Cells[colSalePrice.Index].Value = null;
                dgv.CurrentRow.Cells[colQty.Index].Value = null;
                dgv.CurrentRow.Cells[colAmount.Index].Value = null;
                dgv.CurrentRow.Cells[colPackage.Index].Value = null;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void dgvReceipt_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void txtCurrentPayment_Validating(object sender, CancelEventArgs e)
        {
            if ((decimal)DataTypeParser.Parse(txtBalanceAmt.Text, typeof(decimal), 0) < 0)
            {
                MessageBox.Show("ပေးငွေပမာဏသည့် ကျန်ငွေထက်များနေသည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

    }
}
