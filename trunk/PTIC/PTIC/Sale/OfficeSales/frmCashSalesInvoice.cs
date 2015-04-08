/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/17 (yyyy/MM/dd)
 * Description: Sale Invoice (cash) form
 */
using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.Entities;
using System.Collections.Generic;
using log4net.Config;
using PTIC.VC.Sale.Setup;
using PTIC.Sale.BL;
using System.Drawing;
using PTIC.Common.BL;
using PTIC.VC.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmCashSalesInvoice : Form
    {
        /// <summary>
        /// Logger for frmCashSalesInvoice
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmCashSalesInvoice));

        /// <summary>
        /// Product prices table
        /// </summary>
        //private DataTable _dtProductPrices = null;
                
        /// <summary>
        /// Order to be modified
        /// </summary>
        private Invoice _cashSalesInvoice = null;

        /// <summary>
        /// Sale Commission DataTable
        /// </summary>
        private DataTable _dtSaleComm = null;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtCustomer = null;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtCashDiscount = null;

        /// <summary>
        /// 
        /// </summary>
        private CommDiscount _commDiscount = null;

        /// <summary>
        /// 
        /// </summary>
        private Tax _tax = null;

        /// <summary>
        /// 
        /// </summary>
        private float _saleCommPercentage = 0;

        /// <summary>
        /// 
        /// </summary>
        private float _cashCommPercentage = 0;

        /// <summary>
        /// Warehouse datatable
        /// </summary>
        private DataTable _dtWarehouses = null;

        /// <summary>
        /// Vehicles datatables
        /// </summary>
        private DataTable _dtVehicles = null;
        
        #region Events

        private void dgvCashSales_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == colProduct.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colProduct"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colProduct"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }
        }

        private void dgvCashSales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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

        private void dgvCashSales_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvCashSales.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvCashSales_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvCashSales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

           
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvCashSales.CurrentRow;
            if (selectedRow == null)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            else if (dgvCashSales.Rows.Count <= 1)
            {
                return;
            }

            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;

            DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
            dgvCashSales.Rows.RemoveAt(selectedRow.Index);
            return;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (dgvCashSales.CurrentCell == null)
                return true;
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvCashSales.CurrentCell.ColumnIndex;
                int iRow = dgvCashSales.CurrentCell.RowIndex;
                if (iColumn == dgvCashSales.Columns["colAmount"].Index)
                {
                    Invoice inv = GetInvoice();
                    List<SaleDetail> details = GetSalesDetailList();

                    InvoiceBL invValidator = new InvoiceBL();
                    int placeID = (int)cmbSource.SelectedValue;
                    if (rdoWarehouse.Checked)
                        invValidator.ValidateWarehouse(inv, details, placeID, this._commDiscount, this._tax);
                    else
                        invValidator.ValidateVehicle(inv, details, placeID, this._commDiscount, this._tax);

                    // Check field validation failed or not
                    if (!invValidator.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(invValidator.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    if (iRow + 1 >= dgvCashSales.Rows.Count)
                    {
                        DataTable dt = dgvCashSales.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvCashSales.DataSource = dt;
                        dgvCashSales[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvCashSales.CurrentCell = dgvCashSales[0, iRow + 1];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        dgvCashSales.CurrentCell = dgvCashSales[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvCashSales_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex <0)
                return;
            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];

            if (curColumName.Equals("colProduct"))
            {                
                
                int selectedProductID = (int)DataTypeParser.Parse(curRow.Cells["colProduct"].Value, typeof(int), -1);


                try{
                DataTable colDataSource=(curRow.Cells["colProduct"] as DataGridViewComboBoxCell).DataSource as DataTable;
                
                DataRow [] dr = colDataSource.Select("ProductID=" + selectedProductID);
                if (dr.Length == 1 && colDataSource.Columns.Contains("hasDiscount")) 
                {
                    bool hasDiscount =(bool)dr[0]["hasDiscount"];
                    dgvCashSales.CurrentRow.Cells[colHasDis.Index].Value = hasDiscount;
                }
                
                }catch{
                
                
                }
                

                // Clear Nos Per Pack to avoid old value
                curRow.Cells["colNoPerPack"].Value = 0;
                if (selectedProductID == -1)
                    return;
                // Get and set Whole sale price and Retail sale price by Sale Date
                PriceChange productPrice = new PriceChangeBL().GetPrice(selectedProductID, dtpSaleDate.Value);
                if (productPrice == null) // if there is no price defined
                {
                    curRow.Cells["colSalePrice"].Value = 0;
                    return;
                }
                // Set SalePrice
                decimal salePrice = 0;
                int customerType = (int)PTIC.Common.Enum.CustomerType.EndUser;
                DataRowView selectedCustomer = cmbCustomerName.SelectedItem as DataRowView;
                if (selectedCustomer != null)
                    customerType = (int)DataTypeParser.Parse(selectedCustomer["CusType"], typeof(int),
                        (int)PTIC.Common.Enum.CustomerType.EndUser); // default : end user
                
                if (customerType == (int)PTIC.Common.Enum.CustomerType.Company 
                        || customerType == (int)PTIC.Common.Enum.CustomerType.WholeSaleOutlet)                    
                    salePrice = productPrice.WSPrice; // Whole sale
                else                    
                    salePrice = productPrice.RSPrice; // Retail sale

                curRow.Cells["colSalePrice"].Value = salePrice;

                // Products
                DataTable dtProducts = colProduct.DataSource as DataTable;
                // Set Nos per pack                
                DataRow productInfo = DataUtil.GetDataRowBy(dtProducts, "ProductID", selectedProductID);
                int noPerPack = (int)DataTypeParser.Parse(productInfo["NoPerPack"], typeof(int), -1); // pass default value -1 to void DivideByZeroException
                curRow.Cells["colNoPerPack"].Value = noPerPack;
                // Set Package                
                decimal qty = (int)DataTypeParser.Parse(curRow.Cells["colQty"].Value, typeof(decimal), 0);
                if (noPerPack == 0)
                    curRow.Cells["colPackage"].Value = 0;
                else
                    curRow.Cells["colPackage"].Value = qty / noPerPack;

                // Set values to be able to calculate packing discount                
                DataRow row = DataUtil.GetDataRowBy(dtProducts, "ProductID", selectedProductID);
                if (row != null) // if there is no price defined
                {
                    // Set discount amount per pack
                    curRow.Cells["colDiscountAmtPerPack"].Value = DataTypeParser.Parse(row["DiscountAmtPerPack"], typeof(int), 0);
                    // Set minimum qty of pack
                    curRow.Cells["colMinPackQty"].Value = DataTypeParser.Parse(row["MinPackQty"], typeof(int), 0);
                }
                else
                {
                    curRow.Cells["colDiscountAmtPerPack"].Value = 0;
                    curRow.Cells["colMinPackQty"].Value = 0;    
                }
            }
            else if (curColumName.Equals("colSalePrice") || curColumName.Equals("colQty"))
            {
                decimal salePrice = Convert.ToDecimal(DataTypeParser.Parse(curRow.Cells["colSalePrice"].Value, typeof(decimal), 0));
                int qty = (int)DataTypeParser.Parse(curRow.Cells["colQty"].Value, typeof(int), 0);

                // Set amount = sale price * qty
                curRow.Cells["colAmount"].Value = salePrice * qty;

                // Set Package
                int noPerPack = (int)DataTypeParser.Parse(curRow.Cells["colNoPerPack"].Value, typeof(int), -1); // pass default value -1 to void DivideByZeroException
                if (noPerPack == 0 || noPerPack == -1)
                    curRow.Cells["colPackage"].Value = 0;
                else
                    curRow.Cells["colPackage"].Value = qty / noPerPack;

                // Set summary of quantity
                int totalQty = 0;
                foreach (DataRow row in (gv.DataSource as DataTable).Rows)
                {
                    totalQty += (int)DataTypeParser.Parse(row["Qty"], typeof(int), 0);
                }
                txtTotalQty.Text = (string)DataTypeParser.Parse(totalQty, typeof(string), string.Empty);
            }
            else if (curColumName.Equals("colAmount")) // Calculate summary of amount
            {
                if (gv.DataSource == null)
                    return;

                /*
                decimal summaryAmt = 0;
                foreach (DataRow row in (gv.DataSource as DataTable).Rows)
                {
                    summaryAmt += (int)DataTypeParser.Parse(row["Amount"], typeof(int), 0);
                }
                txtTotalAmt.Text = (string)DataTypeParser.Parse(summaryAmt, typeof(string), string.Empty);
                 */ 
                // Set total amount
                txtTotalAmt.Text = (string)DataTypeParser.Parse(CalculateTotalAmount(gv), typeof(string), string.Empty);
                txtTotalDiscountItem.Text = (string)DataTypeParser.Parse(CalculateDiscountTotalAmount(gv), typeof(string), string.Empty);
            }
            else if (curColumName.Equals("colPackage")) // Set summary of package
            {
                int totalPackage = 0;
                foreach (DataRow row in (gv.DataSource as DataTable).Rows)
                {
                    totalPackage += (int)DataTypeParser.Parse(row["Package"], typeof(int), 0);
                }
                txtTotalPack.Text = (string)DataTypeParser.Parse(totalPackage, typeof(string), string.Empty);
            }
            // Clear commission discount and other amount after some of values changed
            this.txtCommDiscAmt.Clear();
            this.txtOtherAmt.Clear();
        }

        private void cmbCustomerName_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            DataRowView selectedCustomerRow = cmb.SelectedItem as DataRowView;
            if (selectedCustomerRow == null)
            {
                return;
            }
            SetValuesBySelectedCustomer(selectedCustomerRow);
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            CommDiscount commDiscount = CalculateDiscount();
            Invoice inv = new Invoice() 
            {
                InvoiceNo = txtInvoiceNo.Text,
                SalesDate = dtpSaleDate.Value,
                TotalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0))
            };
            float discountItemAmt = 0.0f;
            float.TryParse(txtTotalDiscountItem.Text,out discountItemAmt);
            frmCommissionDiscount formComDiscount = 
                new frmCommissionDiscount(inv, commDiscount, _saleCommPercentage, _cashCommPercentage, PTIC.Common.Enum.VoucherType.Cash,discountItemAmt);
            // set call back handler
            formComDiscount.CommissionDiscountSavedHandler += new frmCommissionDiscount.CommissionDiscountSaveHandler(CommissionDiscount_CallBack);
            // Open form frmCommissionDiscount
            UIManager.OpenForm(formComDiscount);
        }
                
        private void btnTax_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice()
            {
                InvoiceNo = txtInvoiceNo.Text,
                SalesDate = dtpSaleDate.Value,
                TotalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0))
            };
            frmTax formTax = new frmTax(inv);
            // set call back handler
            //formComDiscount.CommissionDiscountSavedHandler += new frmCommissionDiscount.CommissionDiscountSaveHandler(CommissionDiscount_CallBack);
            formTax.TaxSavedHandler += new frmTax.TaxSaveHandler(Tax_CallBack);
            // Open form frmTax
            UIManager.OpenForm(formTax);
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            // Calculate and set net amount
            txtNetAmt.Text = Convert.ToString((string)DataTypeParser.Parse(CalculateNetAmount(), typeof(string), string.Empty));
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

        private void btnSave_Click(object sender, EventArgs e)
        {  
            /*** Check stock in hand ***/
            DataTable dtCasSales = dgvCashSales.DataSource as DataTable;
            if (rdoVehicle.Checked)
            {
                foreach (DataGridViewRow row in dgvCashSales.Rows)
                {
                    int ProductID = (int)DataTypeParser.Parse(dgvCashSales.Rows[row.Index].Cells[colProduct.Index].Value, typeof(int), -1);
                    int Qty = (int)DataTypeParser.Parse(dgvCashSales.Rows[row.Index].Cells[colQty.Index].Value, typeof(int), -1);
                    //  Checing Stock In hand or Not in Vehicle
                    int VenID = (int)DataTypeParser.Parse(cmbSource.SelectedValue, typeof(int), -1);
                    DataTable dtStockInVehicle = new DeliveryBL().GetStockInVehicle(VenID, ProductID);

                    if (dtStockInVehicle.Rows.Count <= 0)
                    {
                        MessageBox.Show("စီစဉ်ထားသောကားပေါ်တွင်လက်ကျန်မရှိပါ။ Delivery Note ဖြင့်တောင်းယူပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (Qty > (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1))
                    {
                        MessageBox.Show("လက်ကျန်မလုံလောက်ပါ။ ယခုကားပေါ်တွင် '" + (string)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["ProductName"], typeof(string), string.Empty) + " ' လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvCashSales.Rows)
                {
                    int ProductID = (int)DataTypeParser.Parse(dgvCashSales.Rows[row.Index].Cells[colProduct.Index].Value, typeof(int), -1);
                    int Qty = (int)DataTypeParser.Parse(dgvCashSales.Rows[row.Index].Cells[colQty.Index].Value, typeof(int), -1);

                    int WarehouseID = (int)DataTypeParser.Parse(cmbSource.SelectedValue, typeof(int), -1);
                    DataTable dtStockInSubStore = new DeliveryBL().GetStockInSubStore(ProductID, WarehouseID);
                    if (dtStockInSubStore.Rows.Count <= 0)
                    {
                        MessageBox.Show("Sub Store တွင်လက်ကျန်လုံးဝမရှိပါ။ Factory သို့ပစ္စည်းတောင်းပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (Qty > (int)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["Qty"], typeof(int), -1))
                    {
                        MessageBox.Show("Sub Store တွင်လက်ကျန်မလုံလောက်ပါ။ Factory သို့ပစ္စည်းတောင်းပါ။" + Environment.NewLine + "ထုတ်ကုန်အမည် : " + (string)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["ProductName"], typeof(string), string.Empty)
                                        + Environment.NewLine + "လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            // Save cash sale
            Save();
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

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            // Make use cash sale customer is potential or not
            frmNewCustomer formTmpCustomer = new frmNewCustomer(false);
            // Set call back function
            formTmpCustomer.TempCustomerSavedHandler += new frmNewCustomer.TempCustomerSaveHandler(formTmpCustomer_CallBack);
            // Open an entry form for a temp customer
            UIManager.OpenForm(formTmpCustomer);
        }

        void formTmpCustomer_CallBack(object sender, frmNewCustomer.TempCustomerSaveEventArgs e)
        {
            //DataTable table = ((cmbCustomerName.DataSource as BindingSource).DataSource as DataSet).Tables["TownTable"];
            //DataTable table = this._dtCustomer;
            //if (table == null || e.SavedTempCustomer == null)
            //    return;
            //// Add a new temp customer to Customer ComboBox
            //DataRow newTmpCustomer = table.NewRow();
            //newTmpCustomer["CustomerID"] = e.SavedTempCustomer.ID;
            //newTmpCustomer["CusName"] = e.SavedTempCustomer.CusName;
            //newTmpCustomer["ConPersonName"] = e.SavedContactPerson.ContactPersonName;
            //newTmpCustomer["Phone1"] = e.SavedTempCustomer.Phone1;
            //newTmpCustomer["Phone2"] = e.SavedTempCustomer.Phone2;
            //newTmpCustomer["Township"] = e.SavedAddress.TownshipID;
            //newTmpCustomer["Town"] = e.SavedAddress.TownID;            
            //cmbCustomerName.Items.Add(newTmpCustomer);

            // Reload data
            LoadNBind();

            // Set a selected town
            cmbTown.SelectedValue = e.SavedAddress.TownID;
            // Set a selected customer
            cmbCustomerName.SelectedValue = e.SavedTempCustomer.ID;
            // Set a new temp customer as selected item
            //cmbCustomerName.SelectedItem = newTmpCustomer;
            // Set contact person
            //txtContactPerson.Text = e.SavedContactPerson.ContactPersonName;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPage));
            this.Close();
        }

        private void dgvCashSales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPage));
            this.Close();
        }

        private void rdoWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            // Bind Warehouses DataTable to source
            this.cmbSource.DataSource = this._dtWarehouses;
        }

        private void rdoVehicle_CheckedChanged(object sender, EventArgs e)
        {
            // Bind Vehicles DataTable to source
            this.cmbSource.DataSource = this._dtVehicles;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Invoice inv = GetInvoice();
                List<SaleDetail> details = GetSalesDetailList();
                
                InvoiceBL invValidator = new InvoiceBL();
                int placeID = (int)cmbSource.SelectedValue;
                if (rdoWarehouse.Checked)
                    invValidator.ValidateWarehouse(inv, details, placeID, this._commDiscount, this._tax);
                else
                    invValidator.ValidateVehicle(inv, details, placeID, this._commDiscount, this._tax);

                // Check field validation failed or not
                if (!invValidator.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(invValidator.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                DataUtil.AddNewRow(dgvCashSales.DataSource as DataTable);
                dgvCashSales.CurrentCell = dgvCashSales.Rows[dgvCashSales.Rows.Count - 1].Cells[0];
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void dgvCashSales_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv == null)
                return;
            
            txtTotalAmt.Text = (string)DataTypeParser.Parse(CalculateTotalAmount(gv), typeof(string), "0");
            txtTotalDiscountItem.Text = (string)DataTypeParser.Parse(CalculateDiscountTotalAmount(gv), typeof(string), string.Empty);
        }

        #endregion

        #region Private Methods
        private void LoadNBind()
        {            
            try
            {                
                DataSet ds = new DataSet();
                BindingSource bdTown = new BindingSource();
                BindingSource bdCustomer = new BindingSource();

                DataTable dtTown = new TownBL().GetAll();
                DataTable dtCustomer = new CustomerBL().GetAll();

                this._dtCustomer = dtCustomer;

                // add town and customer tables into a dataset
                ds.Tables.Add(dtTown);
                ds.Tables.Add(dtCustomer);

                // create data relation between town and customer
                DataRelation relTown_Customer = new DataRelation
                    ("Town_Customer", 
                    dtTown.Columns["TownID"], 
                    dtCustomer.Columns["TownID"],
                    false);
                // add relation into a dataset
                ds.Relations.Add(relTown_Customer);

                bdTown.DataSource = ds;
                bdTown.DataMember = dtTown.TableName;

                bdCustomer.DataSource = bdTown;
                bdCustomer.DataMember = "Town_Customer";

                cmbTown.DataSource = bdTown;
                cmbCustomerName.DataSource = bdCustomer;

                // Get sale commission
                this._dtSaleComm = new SaleCommissionBL().GetAll();
                // Get cash discount
                this._dtCashDiscount = new CashDiscountBL().GetAll();
                // Load products
                colProduct.DataSource = new ProductBL().GetAll();                                
                // Set binding fields
                colProduct.DisplayMember = "ProductName";
                colProduct.ValueMember = "ProductID";
                                
                // Get employess just from Sales and Marketing department
                List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
                Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                queryBuilder.Add(tpSales);
                queryBuilder.Add(tpMk);
                cmbReceiver.DataSource = DataUtil.GetDataTableByOR(new EmployeeBL().GetAll(), queryBuilder);

                // Load warehouse as default in source
                var queryWarehouse = from warehouse in new WarehouseBL().GetAll().AsEnumerable()
                                   orderby warehouse.Field<bool?>("IsSub") descending
                                   select warehouse;
                this._dtWarehouses = queryWarehouse.AsDataView().ToTable();
                /*** Change column names to common names to be used as a datasource in a single ComboBox ***/
                this._dtWarehouses.Columns["WarehouseID"].ColumnName = "ID";
                this._dtWarehouses.Columns["Warehouse"].ColumnName = "SourceDespt";
                this._dtWarehouses.AcceptChanges();
                cmbSource.DataSource = this._dtWarehouses;
                // Load vehicles
                this._dtVehicles = new VehicleBL().GetAll();
                this._dtVehicles.Columns["VehicleID"].ColumnName = "ID";
                this._dtVehicles.Columns["VenNo"].ColumnName = "SourceDespt";
                this._dtVehicles.AcceptChanges();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }            
        }
           
        private void InitializeComponentAndData()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvCashSales.AutoGenerateColumns = false;
            // Set a cash receiver (Sale Person)
            txtSalePerson.Text = GlobalCache.LoginUser.EmpName;
            // Load necessary data
            LoadNBind();
        }

        private void SetValuesBySelectedCustomer(DataRowView selectedCustomer)
        {
            txtTownship.Text = (string)DataTypeParser.Parse(selectedCustomer["Township"], typeof(string), string.Empty);
            txtContactPerson.Text = (string)DataTypeParser.Parse(selectedCustomer["ConPersonName"], typeof(string), string.Empty);
        }

        private decimal CalculateDiscountTotalAmount(DataGridView gv)
        {
            decimal totalAmt = 0;
            if (gv == null || gv.DataSource == null)
                return totalAmt;            
            foreach (DataGridViewRow row in gv.Rows)
            {
                
                if((bool)row.Cells[colHasDis.Index].Value)
                    totalAmt += (int)DataTypeParser.Parse(row.Cells[colAmount.Index].Value, typeof(int), 0);
            }
            return totalAmt;
        }

        private decimal CalculateTotalAmount(DataGridView gv)
        {
            decimal totalAmt = 0;
            if (gv == null || gv.DataSource == null)
                return totalAmt;
            foreach (DataRow row in (gv.DataSource as DataTable).Rows)
            {
                if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached)
                    totalAmt += (int)DataTypeParser.Parse(row["Amount"], typeof(int), 0);
            }
            return totalAmt;
        }

        private void LoadNBindByCashSalesInvoiceID(int? cashSalesInvoiceID)
        {            
            try
            {                
                int intCashSalesInvoiceID = (int)DataTypeParser.Parse(cashSalesInvoiceID, typeof(int), -1);
                using (DataTable tblSaleDetails = new SalesDetailBL().GetByInvoiceID(intCashSalesInvoiceID))
                {
                    dgvCashSales.DataSource = tblSaleDetails;
                }
                // Instantiate Order not assign yet
                if (_cashSalesInvoice == null)
                    _cashSalesInvoice = new Invoice();
                // Make invoice present in current form
                _cashSalesInvoice.ID = cashSalesInvoiceID;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
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
            DataTable dt = dgvCashSales.DataSource as DataTable;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return net amount</returns>
        private decimal CalculateNetAmount()
        {
            decimal totalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0));
            decimal comDiscount = Convert.ToDecimal(DataTypeParser.Parse(txtCommDiscAmt.Text, typeof(decimal), 0));
            decimal otherCost = Convert.ToDecimal(DataTypeParser.Parse(txtOtherAmt.Text, typeof(decimal), 0));
            return (totalAmt - comDiscount) + otherCost;
        }

        private Invoice GetInvoice()
        {
            // Set invoice
            return new Invoice()
            {
                CusID = (int)DataTypeParser.Parse(cmbCustomerName.SelectedValue, typeof(int), -1),
                //SalesPersonID = GlobalCache.loginUser.ID,
                SalesPersonID = (int)DataTypeParser.Parse(cmbReceiver.SelectedValue, typeof(int), -1),
                SalesDate = dtpSaleDate.Value,
                InvoiceNo = string.IsNullOrEmpty(txtInvoiceNo.Text) ? null : txtInvoiceNo.Text,

                TransportTypeID = (int)PTIC.Common.Enum.PredefinedTransportType.VanID, // Purpose: Skip field validation, it is not saved in db

                //TransportGateID = (int)DataTypeParser.Parse(cmbGateName.SelectedValue, typeof(int), -1),
                //SaleType = cmbSaleType.SelectedIndex,
                //GateInvNo = txtGateInvNo.Text,
                //TransportCharges = (int)DataTypeParser.Parse(txtTransportCharges.Text, typeof(int), 0),
                //VoucherType = 1, // cash voucher
                SaleType = 2,
                TotalAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0)),
                CommDiscAmt = Convert.ToDecimal(DataTypeParser.Parse(txtCommDiscAmt.Text, typeof(decimal), 0)),
                OtherAmt = Convert.ToDecimal(DataTypeParser.Parse(txtOtherAmt.Text, typeof(decimal), 0)),
                NetAmt = Convert.ToDecimal(DataTypeParser.Parse(txtNetAmt.Text, typeof(decimal), 0)),
                Remark = string.IsNullOrEmpty(txtRemark.Text) ? null : txtRemark.Text
            };  
        }

        private List<SaleDetail> GetSalesDetailList()
        {
            // Set new sale detail
            List<SaleDetail> newSaleDetailRecords = new List<SaleDetail>();
            foreach (DataGridViewRow row in dgvCashSales.Rows)
            {
                if (row.IsNewRow)
                    break;
                SaleDetail newSaleDetailRecord = new SaleDetail()
                {
                    //  ID = (int)DataTypeParser.Parse(row.Cells["colMSuvDetailID"].Value, typeof(int), -1),
                    // InvoiceID = (int)DataTypeParser.Parse(row.Cells["colMSuvDetailID"].Value, typeof(int), -1),
                    ProductID = (int)DataTypeParser.Parse(row.Cells["colProduct"].Value, typeof(int), -1),
                    SalePrice = (decimal)DataTypeParser.Parse(row.Cells["colSalePrice"].Value, typeof(decimal), 0),
                    Qty = (int)DataTypeParser.Parse(row.Cells["colQty"].Value, typeof(int), 0),
                    Package = (int)DataTypeParser.Parse(row.Cells["colPackage"].Value, typeof(int), 0),
                    Amount = (decimal)DataTypeParser.Parse(row.Cells["colAmount"].Value, typeof(decimal), 0)
                };

                // Add into List
                newSaleDetailRecords.Add(newSaleDetailRecord);
            }

            return newSaleDetailRecords;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {            
            int? affectedRows = 0;
            InvoiceBL invoiceSaver = null;
            try
            {
                invoiceSaver = new InvoiceBL();

                Invoice invoice = GetInvoice();
                if (this._cashSalesInvoice == null || !this._cashSalesInvoice.ID.HasValue) // If it is a new cash sale invoice
                {
                    List<SaleDetail> newSaleDetailRecords = GetSalesDetailList();

                    // Add the new into database                    
                    int placeID = (int)cmbSource.SelectedValue;
                    if (rdoWarehouse.Checked)
                        this._cashSalesInvoice.ID = affectedRows = invoiceSaver.CashSaleFromWarehouse(invoice, newSaleDetailRecords, placeID, this._commDiscount, this._tax);
                    else
                        this._cashSalesInvoice.ID = affectedRows = invoiceSaver.CashSaleFromVehicle(invoice, newSaleDetailRecords, placeID, this._commDiscount, this._tax);
                }
                else // If it is an existing cash sale invoice, update it
                { 
                    // Set InvoiceID
                    invoice.ID = this._cashSalesInvoice.ID;
                }

                // Check field validation failed or not
                if (!invoiceSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(invoiceSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "Cash Sales",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else // Successful validation
                {
                    // Success in db also
                    if (affectedRows.HasValue && affectedRows.Value > 0)
                    {
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        this.Close();
                    }
                    else
                        ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }                
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;                
            }            
        }

        /// <summary>
        /// Add an initial new row if there is no row
        /// </summary>
        private void AddInitialNewRow()
        {
            if (dgvCashSales.Rows.Count == 0)
            {
                DataTable dt = dgvCashSales.DataSource as DataTable;
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
                this.dgvCashSales.DataSource = dt;
            }
        }

        #endregion

        #region Constructors
        public frmCashSalesInvoice()
        {
            // Configure logger 
            XmlConfigurator.Configure();
            // Initialize ui components and necessary data
            InitializeComponentAndData();
           // Load detail table schema
            LoadNBindByCashSalesInvoiceID(null);
            // Add initial new row
            AddInitialNewRow();
        }
        #endregion

                
    }
}
