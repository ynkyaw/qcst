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
using PTIC.VC;
using log4net;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmPriceChanges : Form
    {
        /// <summary>
        /// Logger for frmPriceChange
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmPriceChanges));

        DataTable productTbl = null;
        DataTable pricechangeTbl = null;
        PriceChange pricechange = new PriceChange();

        public frmPriceChanges()
        {
            InitializeComponent();
            LoadData();
            BindData();
        }

        #region Private Method

        private void LoadData()  //Load Town Data for Grid
        {            
            try
            {                
                productTbl = new ProductBL().GetAll();
                pricechangeTbl = new PriceChangeBL().GetAll();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }            
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvPriceChange.AutoGenerateColumns = false;

            //ProductName.DataSource = productTbl;
            //ProductName.DisplayMember = "ProductName";
            //ProductName.ValueMember = "ProductID";

            dgvPriceChange.DataSource = pricechangeTbl;
        }

        //private void Save()
        //{
        //    DataTable dt = dgvPriceChange.DataSource as DataTable;
        //    int sup = 0;
        //    if (dt == null)
        //        return;
        //    SqlConnection conn = null;
        //    try
        //    {
        //        conn = DBManager.GetInstance().GetDbConnection();

        //        // insert
        //        DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
        //        foreach (DataRow row in dvInsert.ToTable().Rows)
        //        {
        //            pricechange.ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1);
        //            pricechange.TranDate = (DateTime)DataTypeParser.Parse(row["TranDate"].ToString(), typeof(DateTime), null);
        //            pricechange.WholeSaleNo = String.IsNullOrEmpty(row["WholeSaleNo"].ToString()) ? "" : row["WholeSaleNo"].ToString();
        //            pricechange.WSPrice = (decimal)DataTypeParser.Parse(row["WSPrice"].ToString(), typeof(decimal), 0);
        //            pricechange.RetailNo = String.IsNullOrEmpty(row["RetailNo"].ToString()) ? "" : row["RetailNo"].ToString();
        //            pricechange.RSPrice = (decimal)DataTypeParser.Parse(row["RSPrice"].ToString(), typeof(decimal), 0);
        //            pricechange.ChangeFromDate = (DateTime)DataTypeParser.Parse(row["ChangeFromDate"].ToString(), typeof(DateTime), null);
        //            pricechange.ChangeToDate = (DateTime)DataTypeParser.Parse(row["ChangeToDate"].ToString(), typeof(DateTime), null);
        //            sup = new PriceChangeBL().Insert(pricechange, conn);
        //        }

        //        // delete
        //        DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
        //        foreach (DataRow row in dvDelete.ToTable().Rows)
        //        {
        //            pricechange.PriceChangeID = (int)DataTypeParser.Parse(row["PriceChangeID"].ToString(), typeof(int), -1);
        //            sup = new PriceChangeBL().Delete(pricechange, conn);
        //        }

        //        // update
        //        DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
        //        foreach (DataRow row in dvUpdate.ToTable().Rows)
        //        {
        //            pricechange.PriceChangeID = (int)DataTypeParser.Parse(row["PriceChangeID"].ToString(), typeof(int), -1);
        //            pricechange.ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1);
        //            pricechange.TranDate = (DateTime)DataTypeParser.Parse(row["TranDate"].ToString(), typeof(DateTime), null);
        //            pricechange.WholeSaleNo = String.IsNullOrEmpty(row["WholeSaleNo"].ToString()) ? "" : row["WholeSaleNo"].ToString();
        //            pricechange.WSPrice = (decimal)DataTypeParser.Parse(row["WSPrice"].ToString(), typeof(decimal), 0);
        //            pricechange.RetailNo = String.IsNullOrEmpty(row["RetailNo"].ToString()) ? "" : row["RetailNo"].ToString();
        //            pricechange.RSPrice = (decimal)DataTypeParser.Parse(row["RSPrice"].ToString(), typeof(decimal), 0);
        //            pricechange.ChangeFromDate = (DateTime)DataTypeParser.Parse(row["ChangeFromDate"].ToString(), typeof(DateTime), null);
        //            pricechange.ChangeToDate = (DateTime)DataTypeParser.Parse(row["ChangeToDate"].ToString(), typeof(DateTime), null);
        //            sup = new PriceChangeBL().Update(pricechange, conn);
        //        }

        //        if (sup > 0)
        //        {
        //            LoadData();
        //            BindData();
        //            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
        //        }

        //    }
        //    catch (Exception sqle)
        //    {
        //        // show error message
        //    }
        //    finally
        //    {
        //        DBManager.GetInstance().CloseDbConnection();
        //    }
        //}

        #endregion

        #region Event Handler

        private void dgvPriceChange_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvPriceChange.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Save();
            frmPriceChange frmPriceChange = new frmPriceChange();
            UIManager.OpenForm(frmPriceChange);
            LoadData();
            BindData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            if (dgvPriceChange.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DateTime FromDate = (DateTime)DataTypeParser.Parse(dgvPriceChange.SelectedCells[4].Value.ToString(), typeof(DateTime), null);
                if (FromDate > DateTime.Now)
                {                   
                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();

                        pricechange.PriceChangeID = (int)DataTypeParser.Parse(dgvPriceChange.SelectedCells[0].Value.ToString(), typeof(int), -1);
                        int Index = dgvPriceChange.CurrentRow.Index;
                        dgvPriceChange.Rows.RemoveAt(Index);
                        int affectedrow = new PriceChangeBL().Delete(pricechange, conn);
                        if (affectedrow > 0)
                        {
                            ToastMessageBox.Show("Successfully Saved.");
                        }
                    }
                    catch (SqlException sqle)
                    {

                    }
                    finally
                    {
                        DBManager.GetInstance().CloseDbConnection();
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    }
                }
                else
                {
                    ToastMessageBox.Show("အသုံးပြုထားပါသဖြင့်ဖျက်မရပါ။");
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        #endregion

        private void dgvPriceChange_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //TODO handle
            e.Cancel = true;
            dgvPriceChange.Rows[e.RowIndex].ErrorText = "Price must be Decimal Number";
        }

        private void dgvPriceChange_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvPriceChange.Columns["WSaleNo"].Index)
            {
                if (dgvPriceChange.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    dgvPriceChange.Rows[e.RowIndex].ErrorText = "Whole Sale No. must be fill";
                }
                else
                {
                    dgvPriceChange.CurrentCell.ErrorText = string.Empty;
                }
            }
            else
                if (e.ColumnIndex == dgvPriceChange.Columns["RetailNo"].Index)
                {
                    if (dgvPriceChange.Rows[e.RowIndex].IsNewRow) { return; }
                    if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                    {
                        e.Cancel = true;
                        dgvPriceChange.Rows[e.RowIndex].ErrorText = "Retail No. must be fill";
                    }
                    else
                    {
                        dgvPriceChange.CurrentCell.ErrorText = string.Empty;
                    }
                }
                else

                    if (e.ColumnIndex == dgvPriceChange.Columns["WSalePrice"].Index)
                    {
                        decimal newDecimal;
                        if (dgvPriceChange.Rows[e.RowIndex].IsNewRow) { return; }
                        if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                        {
                            e.Cancel = true;
                            dgvPriceChange.Rows[e.RowIndex].ErrorText = "Whole Sale Price must be fill";
                        }
                        else
                            if (!decimal.TryParse(e.FormattedValue.ToString(),
                                out newDecimal) || newDecimal < 0)
                            {
                                e.Cancel = true;
                                dgvPriceChange.Rows[e.RowIndex].ErrorText = "Whole Sale Price must be Decimal Number";
                            }
                            else
                            {
                                dgvPriceChange.CurrentCell.ErrorText = string.Empty;
                            }
                    }
                    else

                        if (e.ColumnIndex == dgvPriceChange.Columns["RetailPrice"].Index)
                        {
                            decimal newDecimal;
                            if (dgvPriceChange.Rows[e.RowIndex].IsNewRow) { return; }
                            if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                            {
                                e.Cancel = true;
                                dgvPriceChange.Rows[e.RowIndex].ErrorText = "Retail Sale Price must be fill";
                            }
                            else
                                if (!decimal.TryParse(e.FormattedValue.ToString(),
                                    out newDecimal) || newDecimal < 0)
                                {
                                    e.Cancel = true;
                                    dgvPriceChange.Rows[e.RowIndex].ErrorText = "Retail Sale Price must be Decimal Number";
                                }
                                else
                                {
                                    dgvPriceChange.CurrentCell.ErrorText = string.Empty;
                                }
                        }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Update
            if (dgvPriceChange.SelectedRows.Count == 1)
            {
                DateTime FromDate = (DateTime)DataTypeParser.Parse(dgvPriceChange.SelectedCells[4].Value.ToString(), typeof(DateTime), null);
                if (FromDate > DateTime.Now)
                {
                    pricechange.PriceChangeID = (int)DataTypeParser.Parse(dgvPriceChange.SelectedCells[0].Value.ToString(), typeof(int), -1);
                    pricechange.ProductID = (int)DataTypeParser.Parse(dgvPriceChange.SelectedCells[colProductID.Index].Value.ToString(), typeof(int), -1);
                    pricechange.TranDate = (DateTime)DataTypeParser.Parse(dgvPriceChange.SelectedCells[TranDate.Index].Value.ToString(), typeof(DateTime), null);
                    pricechange.ChangeFromDate = (DateTime)DataTypeParser.Parse(dgvPriceChange.SelectedCells[colFromDate.Index].Value.ToString(), typeof(DateTime), null);
                    pricechange.ChangeToDate = (DateTime)DataTypeParser.Parse(dgvPriceChange.SelectedCells[colToDate.Index].Value.ToString(), typeof(DateTime), null);
                    pricechange.WholeSaleNo = (string)DataTypeParser.Parse(dgvPriceChange.SelectedCells[WSaleNo.Index].Value.ToString(), typeof(string), null);
                    pricechange.WSPrice = (Decimal)DataTypeParser.Parse(dgvPriceChange.SelectedCells[WSalePrice.Index].Value.ToString(), typeof(Decimal), null);
                    pricechange.RetailNo = (string)DataTypeParser.Parse(dgvPriceChange.SelectedCells[RetailNo.Index].Value.ToString(), typeof(string), null);
                    pricechange.RSPrice = (Decimal)DataTypeParser.Parse(dgvPriceChange.SelectedCells[RetailPrice.Index].Value.ToString(), typeof(Decimal), null);
                    pricechange.AcidPrice = (Decimal)DataTypeParser.Parse(dgvPriceChange.SelectedCells[colAcid.Index].Value.ToString(), typeof(Decimal), null);
                    frmPriceChange frmPriceChange = new frmPriceChange(pricechange);
                    UIManager.OpenForm(frmPriceChange);
                    LoadData();
                    BindData();
                }
                else
                {
                    ToastMessageBox.Show("အသုံးပြုထားပါသဖြင့်ပြင်မရပါ။");
                }

            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
            }
        }


    }
}
