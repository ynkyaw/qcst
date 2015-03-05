using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmPriceChange : Form
    {
        DataTable productTbl = null;
        PriceChange pricechange = new PriceChange();

        public frmPriceChange()
        {
            InitializeComponent();
            LoadDataNBind();
        }

        public frmPriceChange(PriceChange pricechange)
        {
            InitializeComponent();
            this.pricechange = pricechange;
            LoadDataNBind();
        }

        #region Private Method
        private void LoadDataNBind()  //Load Town Data for Combo
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                productTbl = new ProductBL().GetAll();  // LoadData into Datatable
                //  pricechangeTbl = new PriceChangeBL().GetAll(conn);
                cmbProduct.DataSource = productTbl;
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductID";
            }
            catch (SqlException sqle)
            {
                //  _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void BindData()
        {
            cmbProduct.SelectedValue = pricechange.ProductID;
            txtWSNo.Text = pricechange.WholeSaleNo;
            txtWholeSalePrice.Text = pricechange.WSPrice.ToString("N0");
            txtRetailSalePrice.Text = pricechange.RSPrice.ToString("N0");
            txtAcidPrice.Text = pricechange.AcidPrice.ToString("N0");
            txtRSNo.Text = pricechange.RetailNo.ToString();
            dtpStartDate.Value = pricechange.ChangeFromDate;
            dtpEndDate.Value = pricechange.ChangeToDate;
            dtpTranDate.Value = pricechange.TranDate;
        }
        #endregion

        private void frmPriceChange_Load(object sender, EventArgs e)
        {
            dtpStartDate.MinDate = DateTime.Today.AddDays(1);
            dtpEndDate.MinDate = DateTime.Today.AddDays(1);
            if (pricechange.PriceChangeID != 0)
            {
                BindData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            int affectedrow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                pricechange.ProductID = (int)DataTypeParser.Parse(cmbProduct.SelectedValue.ToString(), typeof(int), null);
                pricechange.RetailNo = txtRSNo.Text;
                pricechange.RSPrice = (Decimal)DataTypeParser.Parse(txtRetailSalePrice.Text, typeof(Decimal), null);
                pricechange.WholeSaleNo = txtWSNo.Text;
                pricechange.WSPrice = (Decimal)DataTypeParser.Parse(txtWholeSalePrice.Text, typeof(Decimal), null);
                pricechange.AcidPrice = (Decimal)DataTypeParser.Parse(txtAcidPrice.Text,typeof(Decimal),null);
                pricechange.ChangeFromDate = dtpStartDate.Value;
                pricechange.ChangeToDate = dtpEndDate.Value;
                pricechange.TranDate = dtpTranDate.Value;
                if (pricechange.PriceChangeID != 0)
                {
                    affectedrow = new PriceChangeBL().Update(pricechange, conn);
                }
                else
                {
                    affectedrow = new PriceChangeBL().Insert(pricechange, conn);
                }
                if (affectedrow > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }

            }
            catch (SqlException sqle)
            {
                //_logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWholeSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtRetailSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
