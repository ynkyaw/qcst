/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/17 (yyyy/MM/dd)
 * Description: Sale Invoice (cash) form
 */
using System.Windows.Forms;
using log4net;
using PTIC.Sale.Entities;
using System;
using PTIC.VC.Util;
using log4net.Config;
using PTIC.Formatting;
using PTIC.VC.Validation;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmCommissionDiscount : Form
    {
        /// <summary>
        /// Logger for frmCommissionDiscount
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmCommissionDiscount));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CommissionDiscountSaveHandler(object sender, CommissionDiscountSaveEventArgs e);

        public event CommissionDiscountSaveHandler CommissionDiscountSavedHandler;

        #region Events
        private void btnApprove_Click(object sender, System.EventArgs e)
        {
            Approve();
        }
        
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate and set total commission discount
            //txtTotalDiscount.Text = Convert.ToString(DataTypeParser.Parse(CalculateTotalCommDiscount(), typeof(string), string.Empty));
            txtTotalDiscount.Text = CalculateTotalCommDiscount().ToString(TextFormat.WholeNumber);
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

        private void txtSaleCommPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            string input = txtSaleCommPercentage.Text + e.KeyChar.ToString();
            if (!char.IsControl(e.KeyChar)
                && !PatternValidator.IsIrrationalNumber(input)
                )
            {
                e.Handled = true;
            }
        }

        private void txtCashCommPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            string input = txtCashCommPercentage.Text + e.KeyChar.ToString();
            if (!char.IsControl(e.KeyChar)
                && !PatternValidator.IsIrrationalNumber(input)
                )
            {
                e.Handled = true;
            }
        }

        private void frmCommissionDiscount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Approve();
        }

        private void txtSaleCommPercentage_TextChanged(object sender, EventArgs e)
        {
            decimal saleCommPercentage = (decimal)DataTypeParser.Parse(txtSaleCommPercentage.Text, typeof(decimal), 0);

            decimal totalSaleAmt = Convert.ToDecimal(DataTypeParser.Parse(txtDiscountItemAmt.Text, typeof(decimal), 0));

            //decimal totalSaleAmt = Convert.ToDecimal(DataTypeParser.Parse(txtSalesAmt.Text, typeof(decimal), 0));
            decimal saleComm = (saleCommPercentage / 100) * totalSaleAmt;
            // Set sale commisssion
            //txtSaleCommission.Text = Convert.ToString(DataTypeParser.Parse(saleComm, typeof(string), string.Empty));
            txtSaleCommission.Text = saleComm.ToString(TextFormat.WholeNumber);
        }

        private void txtCashCommPercentage_TextChanged(object sender, EventArgs e)
        {
            decimal cashCommPercentage = (decimal)DataTypeParser.Parse(txtCashCommPercentage.Text, typeof(decimal), 0);
            //decimal totalSaleAmt = Convert.ToDecimal(DataTypeParser.Parse(txtSalesAmt.Text, typeof(decimal), 0));
            decimal totalSaleAmt = Convert.ToDecimal(DataTypeParser.Parse(txtDiscountItemAmt.Text, typeof(decimal), 0));
            decimal cashComm = (cashCommPercentage / 100) * totalSaleAmt;
            // Set sale commisssion
            //txtCashCommission.Text = Convert.ToString(DataTypeParser.Parse(cashComm, typeof(string), string.Empty));
            txtCashCommission.Text = cashComm.ToString(TextFormat.WholeNumber);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return total commission discount amount</returns>
        private decimal CalculateTotalCommDiscount()
        {
            decimal totalCommDiscountAmt = 0;

            try
            {
                decimal totalSaleAmt = Convert.ToDecimal(DataTypeParser.Parse(txtSalesAmt.Text, typeof(decimal), 0));
                decimal packingDiscountAmt = Convert.ToDecimal(DataTypeParser.Parse(txtPackDiscount.Text, typeof(decimal), 0));
                decimal saleCommAmt = Convert.ToDecimal(DataTypeParser.Parse(txtSaleCommission.Text, typeof(decimal), 0));
                decimal cashDiscountAmt = Convert.ToDecimal(DataTypeParser.Parse(txtCashCommission.Text, typeof(decimal), 0));
                decimal otherCommDiscountAmt = Convert.ToDecimal(DataTypeParser.Parse(txtOtherDiscount.Text, typeof(decimal), 0));
                decimal refundAmt = Convert.ToDecimal(DataTypeParser.Parse(txtRefundAmt.Text, typeof(decimal), 0));
                decimal needAmt = Convert.ToDecimal(DataTypeParser.Parse(txtNeedAmt.Text, typeof(decimal), 0));

                totalCommDiscountAmt = (packingDiscountAmt +
                                                        saleCommAmt + cashDiscountAmt +
                                                        otherCommDiscountAmt + refundAmt) - needAmt;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new Exception("Cannot calculate commission and discount!");
            }
            return totalCommDiscountAmt;
        }

        private void Approve()
        {
            // Pass entity CommDiscount to caller
            CommDiscount comDiscount = new CommDiscount()
            {
                PackingAmt = Convert.ToDecimal(DataTypeParser.Parse(txtPackDiscount.Text, typeof(decimal), 0)),
                SaleCommAmt = Convert.ToDecimal(DataTypeParser.Parse(txtSaleCommission.Text, typeof(decimal), 0)),
                CashCommAmt = Convert.ToDecimal(DataTypeParser.Parse(txtCashCommission.Text, typeof(decimal), 0)),
                OtherCommAmt = Convert.ToDecimal(DataTypeParser.Parse(txtOtherDiscount.Text, typeof(decimal), 0)),
                RefundAmt = Convert.ToDecimal(DataTypeParser.Parse(txtRefundAmt.Text, typeof(decimal), 0)),
                NeedAmt = Convert.ToDecimal(DataTypeParser.Parse(txtNeedAmt.Text, typeof(decimal), 0)),
                TotalCommAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalDiscount.Text, typeof(decimal), 0))
            };
            CommissionDiscountSaveEventArgs eArgs = new CommissionDiscountSaveEventArgs(comDiscount);
            CommissionDiscountSavedHandler(this, eArgs);
            this.Close();
        }
        #endregion

        #region Constructors
        public frmCommissionDiscount()
        {
            InitializeComponent();
            txtSaleCommPercentage.Text = string.Empty;
            // Configure logger
            XmlConfigurator.Configure();
        }

        public frmCommissionDiscount(Invoice cashSalesInvoice, CommDiscount discount,
            float saleCommPercentage, float cashCommPercentage, PTIC.Common.Enum.VoucherType voucherType,float discountItemTotalAmt)
            : this()
        {
            // If caller voucher type is credit, do not allow "Cash commission"
            if (voucherType == PTIC.Common.Enum.VoucherType.Credit)
                txtCashCommPercentage.ReadOnly = true;

            txtInvoiceNo.Text = cashSalesInvoice.InvoiceNo;
            dtpDate.Value = (DateTime)DataTypeParser.Parse(cashSalesInvoice.SalesDate, typeof(DateTime), DateTime.Now);
            //txtSalesAmt.Text = Convert.ToString(cashSalesInvoice.TotalAmt);
            txtSalesAmt.Text = cashSalesInvoice.TotalAmt.ToString(TextFormat.WholeNumber);

            //txtPackDiscount.Text = Convert.ToString(DataTypeParser.Parse(discount.PackingAmt, typeof(string), string.Empty));
            txtPackDiscount.Text = discount.PackingAmt.ToString(TextFormat.WholeNumber);


            txtDiscountItemAmt.Text = discountItemTotalAmt.ToString(TextFormat.WholeNumber);


            //txtSaleCommission.Text = Convert.ToString(DataTypeParser.Parse(discount.SaleCommAmt, typeof(string), string.Empty));
            txtSaleCommission.Text = discount.SaleCommAmt.ToString(TextFormat.WholeNumber);
            //txtCashCommission.Text = Convert.ToString(DataTypeParser.Parse(discount.CashCommAmt, typeof(string), string.Empty));
            txtCashCommission.Text = discount.CashCommAmt.ToString(TextFormat.WholeNumber);
            //txtTotalDiscount.Text = Convert.ToString(DataTypeParser.Parse(discount.TotalCommAmt, typeof(string), string.Empty));
            txtTotalDiscount.Text = discount.TotalCommAmt.ToString(TextFormat.WholeNumber);

            //txtSaleCommPercentage.Text = (string)DataTypeParser.Parse(saleCommPercentage, typeof(string), string.Empty);
            txtCashCommPercentage.Text = (string)DataTypeParser.Parse(cashCommPercentage, typeof(string), string.Empty);



        }
        #endregion

        #region Inner Class
        public class CommissionDiscountSaveEventArgs : EventArgs
        {
            private CommDiscount _commDiscount = null;
            public CommissionDiscountSaveEventArgs(CommDiscount commDiscount)
            {
                this._commDiscount = commDiscount;
            }
            public CommDiscount CommDiscount
            {
                get { return this._commDiscount; }
            }
        }
        #endregion

        private void frmCommissionDiscount_Load(object sender, EventArgs e)
        {

        }
                             
    }
}
