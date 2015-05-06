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
using PTIC.Sale.DA;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Util;
using PTIC.Sale.BL;
using PTIC.Formatting;
using PTIC.Sale.SalePlanning;
using PTIC.Marketing.BL;
using PTIC.VC.Validation;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmSalesPlan4Production : Form
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmSalesPlan4Production));

        //private const int _defaultcell = 6;
        //private const int _constant = 102;
        private DataTable productTbl = null;
        private DataTable salesplanTbl = null;
        private DataTable SPDetailTbl = null;
        //private decimal retailprice = 0;
        private float computedvalue = 0;
        private decimal TotalSalesPlanAmount = 0;

        private TextBox _txtQty = null;

             
        public frmSalesPlan4Production()
        {
            InitializeComponent();
            dtpPlanMonth.Value = DateTime.Today;
            LoadData();
            BindData();
            DataUtil.AddInitialNewRow(dgvSalesPlan4P);
        }

        #region Private Methods
        private bool HasNewRow(DataGridView dgv)
        {
            if (dgvSalesPlan4P.Rows.Count > 0)
            {
                int? SalesPlanDetailID = (int?)DataTypeParser.Parse(dgv.Rows[dgv.Rows.Count - 1].Cells[clnSPDetailID.Index].Value, typeof(int), null);

                if (SalesPlanDetailID != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else 
            {
                return false;
            }
        }

        private void BindData()
        {
            dgvSalesPlan4P.AutoGenerateColumns = false;

            clnProductName.DataSource = productTbl;
            clnProductName.DisplayMember = "ProductName";
            clnProductName.ValueMember = "ProductID";

            txtTotalSalesAmount.Text = "0";

            if (salesplanTbl.Rows.Count == 1)
            {
                decimal tempValue = (decimal)DataTypeParser.Parse(salesplanTbl.Rows[0]["SalesPlanAmt"].ToString(), typeof(decimal), 0);
                txtTotalSalesAmount.Text = (tempValue).ToString("N0");
            }
            dgvSalesPlan4P.DataSource = SPDetailTbl;
        }

        private void LoadData()
        {            
            try
            {                
                //productTbl = new ProductBL().GetAll();
                productTbl = new ProductBL().GetWithPrice();
                salesplanTbl = new SalesPlanBL().GetbyMonth(dtpPlanMonth.Value);
                if (salesplanTbl.Rows.Count == 1)
                {
                    SPDetailTbl = new SalesPlanBL().GetDetailBySalesPlanID((int)DataTypeParser.Parse(salesplanTbl.Rows[0][0], typeof(int), 0));
                }
                else
                {
                    SPDetailTbl = new SalesPlanBL().GetDetailBySalesPlanID(0);
                }
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        private void Save()
        {
            SqlConnection conn = null;
            int affectedrows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                //if new SalesPlan then Insert
                SalesPlan saleplan = new SalesPlan()
                {
                    PlanDate = dtpPlanMonth.Value,
                    SalesPlanAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalSalesAmount.Text, typeof(decimal), 0)),
                    Status = 0
                };
                if (salesplanTbl.Rows.Count < 1)
                {
                    //int splanid = new SalesPlanBL().InsertSalesPlan(saleplan, conn);
                    List<SalesPlanDetail> spdetails = new List<SalesPlanDetail>();
                    foreach (DataGridViewRow row in dgvSalesPlan4P.Rows)
                    {
                        if (row.IsNewRow)
                            break;
                        SalesPlanDetail spdetail = new SalesPlanDetail()
                        {
                            ID = 0,
                            ProductID = (int)DataTypeParser.Parse(row.Cells["clnProductName"].Value, typeof(int), -1),
                            SalesPlanID = 0,
                            SaleQty = (int)DataTypeParser.Parse(row.Cells["clnSalesQty"].Value, typeof(int), 0),
                            retailPrice = (decimal)DataTypeParser.Parse(row.Cells["clnRetailPrice"].Value, typeof(decimal), 0),
                            RequireQty = (int)DataTypeParser.Parse(row.Cells["clnNeed2ProduceQty"].Value, typeof(int), 0),
                            ProduceQty = (int)DataTypeParser.Parse(row.Cells["clnProducedQty"].Value, typeof(int), 0),
                            Nconvert = Convert.ToDecimal(DataTypeParser.Parse(row.Cells["clnN100Convert"].Value, typeof(decimal), 0)),
                            Remark = (string)DataTypeParser.Parse(row.Cells["clnRemark"].Value, typeof(string), string.Empty),
                        };
                        if (spdetail.retailPrice != 0 && spdetail.ProductID != -1 && spdetail.SaleQty != 0)
                        {
                            spdetails.Add(spdetail);
                        }
                        else
                        {
                            MessageBox.Show("Data များကို ပြည့်စုံစွာဖြည့်စွက်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        //int detailid = new SalesPlanBL().InsertDetails(spdetail, conn);
                    }
                    if (spdetails.Count > 0)
                    {
                        affectedrows = new SalesPlanBL().Save(saleplan, spdetails, conn);
                    }
                }
                else
                {
                    //if exiting SalePlan then Update
                    saleplan = new SalesPlan()
                    {
                        ID = (int)DataTypeParser.Parse(salesplanTbl.Rows[0][0], typeof(int), 0),
                        PlanDate = dtpPlanMonth.Value,
                        SalesPlanAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalSalesAmount.Text, typeof(decimal), 0)),
                        Status = 0
                    };

                    affectedrows = new SalesPlanBL().UpdateSaleplan(saleplan, conn);
                    //
                    DataTable dt = dgvSalesPlan4P.DataSource as DataTable;
                    //new details insert
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow dr in dvInsert.ToTable().Rows)
                    {
                        SalesPlanDetail spdetail = new SalesPlanDetail()
                        {
                            ID = 0,
                            ProductID = (int)DataTypeParser.Parse(dr["ProductID"], typeof(int), -1),
                            SalesPlanID = saleplan.ID,
                            retailPrice = (decimal)DataTypeParser.Parse(dr["retailPrice"], typeof(decimal), 0),
                            SaleQty = (int)DataTypeParser.Parse(dr["SaleQty"], typeof(int), 0),
                            RequireQty = (int)DataTypeParser.Parse(dr["RequireQty"], typeof(int), 0),
                            ProduceQty = (int)DataTypeParser.Parse(dr["ProduceQty"], typeof(int), 0),
                            Nconvert = Convert.ToDecimal(DataTypeParser.Parse(dr["CalculatedValue"], typeof(decimal), 0)) * (int)DataTypeParser.Parse(dr["SaleQty"], typeof(int), 0),
                            Remark = (string)DataTypeParser.Parse(dr["Remark"], typeof(string), string.Empty),
                        };
                        if (spdetail.retailPrice != 0 && spdetail.ProductID != -1 && spdetail.SaleQty != 0 && spdetail.ProductID != 0)
                        {
                            affectedrows = new SalesPlanBL().InsertDetails(spdetail, conn);
                        }
                        else
                        {
                            MessageBox.Show("Data များကို ပြည့်စုံစွာဖြည့်စွက်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    //update details
                    DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow dr in dvUpdate.ToTable().Rows)
                    {
                        SalesPlanDetail spdetail = new SalesPlanDetail()
                        {
                            ID = (int)DataTypeParser.Parse(dr["SalesPlanDetailID"], typeof(int), 0),
                            ProductID = (int)DataTypeParser.Parse(dr["ProductID"], typeof(int), -1),
                            SalesPlanID = saleplan.ID,
                            retailPrice = (decimal)DataTypeParser.Parse(dr["retailPrice"], typeof(decimal), 0),
                            SaleQty = (int)DataTypeParser.Parse(dr["SaleQty"], typeof(int), 0),
                            RequireQty = (int)DataTypeParser.Parse(dr["RequireQty"], typeof(int), 0),
                            ProduceQty = (int)DataTypeParser.Parse(dr["ProduceQty"], typeof(int), 0),
                            Nconvert = Convert.ToDecimal(DataTypeParser.Parse(dr["N100Convert"], typeof(decimal), 0)),
                            Remark = (string)DataTypeParser.Parse(dr["Remark"], typeof(string), string.Empty),
                        };
                        if (spdetail.retailPrice != 0 && spdetail.ProductID != 0 && spdetail.RequireQty != 0 && spdetail.ProductID != -1)
                        {
                            affectedrows += new SalesPlanBL().UpdateDetails(spdetail, conn);
                        }
                        else
                        {
                            MessageBox.Show("Data များကို ပြည့်စုံစွာဖြည့်စွက်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                }

                if (affectedrows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadData();
                    BindData();
                }
                else
                {
                    ToastMessageBox.Show(Resource.errFailedToSave);  
                }
            }
            catch (Exception ex)
            {
                ToastMessageBox.Show(ex.Message);
                _logger.Error(ex);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void deleteSalePlanProduction()
        {
            DateTime SalesPlanDate = (DateTime)DataTypeParser.Parse(dtpPlanMonth.Value, typeof(DateTime), DateTime.MinValue);

            if (dgvSalesPlan4P.CurrentRow.IsNewRow || dgvSalesPlan4P.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            // Checking A_P Plan Is Exit OR Not
            //DataTable dtAPMaterialPlan = new A_P_PlanBL().GetAllAPPlanByDate(SalesPlanDate);
            //if (dtAPMaterialPlan.Rows.Count > 0)
            //{
            //    MessageBox.Show("A_P_Plan တွင်စီစဥ်ထားပြီးဖြစ်ပါသည်။ ဖျက်ခွင့်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            DataGridViewRow selectedRow = dgvSalesPlan4P.CurrentRow;

            int spDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["clnSPDetailID"].Value, typeof(int), -1);


            if (spDetailID == -1)
            {
                dgvSalesPlan4P.Rows.RemoveAt(dgvSalesPlan4P.CurrentRow.Index);
            }
            else
            {
                // MessageBox.Show(Resource.errDel);
                // delete a selected order
                SalesPlan SalesPlan = new SalesPlan()
                {
                    ID = (int)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells[clnSalesPlanID.Index].Value, typeof(int), -1)
                };

                dgvSalesPlan4P.Rows.RemoveAt(dgvSalesPlan4P.CurrentRow.Index);
                DeleteSalesPlanDetail(spDetailID, SalesPlan);
                //CalculateTotal();
                // UpdateSalePlan();
            }
        }

        private void UpdateSalePlan()
        {
            int affectedrows = 0;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                SalesPlan saleplan = new SalesPlan()
                {
                    ID = (int)DataTypeParser.Parse(salesplanTbl.Rows[0][0], typeof(int), 0),
                    PlanDate = dtpPlanMonth.Value,
                    SalesPlanAmt = Convert.ToDecimal(DataTypeParser.Parse(txtTotalSalesAmount.Text, typeof(decimal), 0)),
                    Status = 0
                };


                affectedrows = new SalesPlanBL().UpdateSaleplan(saleplan, conn);
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
            }

            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void DeleteSalesPlanDetail(int spDetailID, SalesPlan newSalesPlan)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                newSalesPlan.SalesPlanAmt = (decimal)DataTypeParser.Parse(txtTotalSalesAmount.Text, typeof(decimal), 0);

                // delete an order detail
                int affectedRows = new SalesPlanBL().DeleteSPDetail(spDetailID, newSalesPlan);
                if (affectedRows > 0)
                {
                    if (dgvSalesPlan4P.RowCount == 0)
                        DataUtil.AddInitialNewRow(dgvSalesPlan4P);
                }
                // show successful msg and close this
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void lblSalePage_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalePlanningPage));
            this.Close();
        }

        private void RowClear(DataGridView dgv)
        {
            if (dgv.IsCurrentRowDirty)
            {
                int Index = dgv.CurrentRow.Index;
                dgv.Rows.RemoveAt(Index);
                DataUtil.AddNewRow(dgv.DataSource as DataTable);
            }
        }

        private void CalculateSummary(DataView dvCurrent)
        {
            if (dvCurrent == null)
                return;

            decimal summaryAmt = 0;
            decimal summarySoldAmt = 0;
            decimal summaryNeedAmt = 0;
            decimal summaryProduceAmt = 0;
            decimal summaryN100ConvertNeed = 0;
            decimal summaryN100ConvertProduce = 0;

            foreach (DataRow row in dvCurrent.ToTable().Rows)
            {
                float N100Convert = (float)DataTypeParser.Parse(row["CalculatedValue"], typeof(float), 0);
                float N100ConvertProduce = N100Convert * (float)DataTypeParser.Parse(row["RequireQty"], typeof(float), 0);
                float N100ConvertNeedToProduce = N100Convert * (float)DataTypeParser.Parse(row["ProduceQty"], typeof(float), 0);

                if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached)
                    summaryAmt += (decimal)DataTypeParser.Parse(row["Amount"], typeof(decimal), 0);
                summarySoldAmt += (decimal)DataTypeParser.Parse(row["SaleQty"], typeof(decimal), 0);
                summaryProduceAmt += (decimal)DataTypeParser.Parse(row["RequireQty"], typeof(decimal), 0);
                summaryNeedAmt += (decimal)DataTypeParser.Parse(row["ProduceQty"], typeof(decimal), 0);
                summaryN100ConvertProduce += (decimal)DataTypeParser.Parse(N100ConvertProduce, typeof(decimal), 0);
                summaryN100ConvertNeed += (decimal)DataTypeParser.Parse(N100ConvertNeedToProduce, typeof(decimal), 0);
            }

            // Set summary
            txtTotalSalesAmount.Text = summaryAmt.ToString("N0");
            txtSold.Text = summarySoldAmt.ToString();
            txtNeedToProduce.Text = summaryNeedAmt.ToString();
            txtProduce.Text = summaryProduceAmt.ToString();
            txtN100ConvertNeed.Text = summaryN100ConvertNeed.ToString("N2");
            txtN100ConvertProduce.Text = summaryN100ConvertProduce.ToString("N2");
        }

        #endregion

        #region Events

        private void butDelete_Click(object sender, EventArgs e)
        {
            deleteSalePlanProduction();
            DataUtil.AddInitialNewRow(dgvSalesPlan4P);
        }

        private void dtpPlanMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
            BindData();
            DataUtil.AddInitialNewRow(dgvSalesPlan4P);
        }
               
        private void dgvSalesPlan4P_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int retailprice = 5000;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];

            float N100Convert = (float)DataTypeParser.Parse(curRow.Cells["clnCalculatedValue"].Value, typeof(float), 0);
            
            if (gv.DataSource == null)
                return;
            decimal retailPrice = (decimal)DataTypeParser.Parse(curRow.Cells["clnRetailPrice"].Value, typeof(decimal), 0);
                        
            if (curColumName.Equals("clnProductName") || curColumName.Equals("clnRetailPrice") || curColumName.Equals("clnSalesQty"))            
            {
                // Get and set Whole sale price and Retail sale price
                int selectedProductID = (int)DataTypeParser.Parse(curRow.Cells["clnProductName"].Value, typeof(int), -1);
                if (selectedProductID == -1) // NO need to get and set
                    return;

                DataRow[] dr = null;
                dr = productTbl.Select("[ProductID] = " + selectedProductID.ToString());
                if (dr.Length > 0)
                {                    
                    retailPrice = (decimal)DataTypeParser.Parse(dr[0]["WSPrice"], typeof(decimal), 0);
                    computedvalue = (float)DataTypeParser.Parse(dr[0]["CalculatedValue"], typeof(float), 0);
                    dgvSalesPlan4P.CurrentRow.Cells["clnRetailPrice"].Value = retailPrice;
                    dgvSalesPlan4P.CurrentRow.Cells["clnCalculatedValue"].Value = computedvalue;
                    //dgvSalesPlan4P.CurrentRow.Cells["clnN100Convert"].Value = computedvalue;

                    // Calculate amount
                    dgvSalesPlan4P.CurrentRow.Cells["clnAmount"].Value = retailPrice * (int)DataTypeParser.Parse(curRow.Cells["clnSalesQty"].Value, typeof(int), 0);
                }
            }                        
            else if (curColumName.Equals("clnProducedQty"))
            {
                dgvSalesPlan4P.CurrentRow.Cells["clnN100Convert"].Value =
                   N100Convert * (float)DataTypeParser.Parse(curRow.Cells["clnProducedQty"].Value, typeof(float), 0);
            }
            else if (curColumName.Equals("clnNeed2ProduceQty"))
            {
                dgvSalesPlan4P.CurrentRow.Cells["colRequireN100Convert"].Value =
                   N100Convert * (float)DataTypeParser.Parse(curRow.Cells["clnNeed2ProduceQty"].Value, typeof(float), 0);
            }

            // Calculate total summary amount
            DataView dvCurrent = new DataView((gv.DataSource as DataTable), string.Empty, string.Empty, DataViewRowState.CurrentRows);
            CalculateSummary(dvCurrent);                                                 
        }

        private void CalculateTotal()
        {
            DataTable dt = dgvSalesPlan4P.DataSource as DataTable;

            if (dt == null) return;

            TotalSalesPlanAmount = 0;
            decimal summarySoldAmt = 0;
            decimal summaryNeedAmt = 0;
            decimal summaryProduceAmt = 0;
            decimal summaryN100ConvertNeed = 0;
            decimal summaryN100ConvertProduce = 0;

            float N100Convert = (float)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells["clnCalculatedValue"].Value, typeof(float), 0);
            DataView dvCurrent = new DataView(dt, string.Empty, string.Empty, DataViewRowState.CurrentRows);

            foreach (DataRow row in dvCurrent.ToTable().Rows)
            {
                float N100ConvertProduce = N100Convert * (float)DataTypeParser.Parse(row["RequireQty"], typeof(float), 0);
                float N100ConvertNeedToProduce = N100Convert * (float)DataTypeParser.Parse(row["ProduceQty"], typeof(float), 0);

                if (row.RowState != DataRowState.Deleted)
                    TotalSalesPlanAmount += (decimal)DataTypeParser.Parse(row["Amount"], typeof(decimal), 0);
                summarySoldAmt += (decimal)DataTypeParser.Parse(row["SaleQty"], typeof(decimal), 0);
                summaryProduceAmt += (decimal)DataTypeParser.Parse(row["RequireQty"], typeof(decimal), 0);
                summaryNeedAmt += (decimal)DataTypeParser.Parse(row["ProduceQty"], typeof(decimal), 0);
                summaryN100ConvertProduce += (decimal)DataTypeParser.Parse(N100ConvertProduce, typeof(decimal), 0);
                summaryN100ConvertNeed += (decimal)DataTypeParser.Parse(N100ConvertNeedToProduce, typeof(decimal), 0);
            }

            txtTotalSalesAmount.Text = TotalSalesPlanAmount.ToString();
            txtSold.Text = summarySoldAmt.ToString();
            txtProduce.Text = summaryProduceAmt.ToString();
            txtNeedToProduce.Text = summaryNeedAmt.ToString();
            txtN100ConvertProduce.Text = summaryN100ConvertProduce.ToString("N2");
            txtN100ConvertNeed.Text = summaryN100ConvertNeed.ToString("N2");
        }
        
        private void butSave_Click(object sender, EventArgs e)
        {
            if (dgvSalesPlan4P.Rows[dgvSalesPlan4P.CurrentRow.Index].ErrorText != String.Empty)
            {
                MessageBox.Show(Resource.errFailedToSave);
            }
            else
            {
                Save();
               
            }
        }
               
        private void dgvSalesPlan4P_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == clnProductName.Index)
            {
                foreach (DataGridViewRow row in dgvSalesPlan4P.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["clnProductName"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["clnProductName"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("ထုတ်ကုန် ထပ်နေသည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            //dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = string.Empty;
            else if (e.ColumnIndex == clnSalesQty.Index || e.ColumnIndex == clnNeed2ProduceQty.Index || e.ColumnIndex == clnProducedQty.Index)
            {
                int newInteger;
                if (dgvSalesPlan4P.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = Resource.RequiredQty;
                    MessageBox.Show(Resource.RequiredQty, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = Resource.MustIntegerQty;
                    MessageBox.Show(Resource.MustIntegerQty, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvSalesPlan4P.CurrentRow.Cells[clnSalesQty.Index].Value = 0;
                    dgvSalesPlan4P.CurrentRow.Cells[clnNeed2ProduceQty.Index].Value = 0;
                    dgvSalesPlan4P.CurrentRow.Cells[clnProducedQty.Index].Value = 0;
                }
                else
                {
                    dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvSalesPlan4P.CurrentCell.ColumnIndex;
                int iRow = dgvSalesPlan4P.CurrentCell.RowIndex;
                if (iColumn == dgvSalesPlan4P.Columns["clnRemark"].Index)
                {
                    if (HasNewRow(dgvSalesPlan4P)) return base.ProcessCmdKey(ref msg, keyData);
                    if (iRow + 1 >= dgvSalesPlan4P.Rows.Count)
                    {
                        DataTable dt = dgvSalesPlan4P.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvSalesPlan4P.DataSource = dt;
                        dgvSalesPlan4P[0, iRow + 1].Selected = true;                   
                    }
                    else
                    {
                        dgvSalesPlan4P.CurrentCell = dgvSalesPlan4P[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvSalesPlan4P.CurrentCell = dgvSalesPlan4P[dgvSalesPlan4P.CurrentCell.ColumnIndex + 1, dgvSalesPlan4P.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvSalesPlan4P_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    if ((int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[clnSPDetailID.Index].Value, typeof(int), 0) != 0)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                        //gridView.Rows[r.Index].Cells[clnSPDetailID.Index].ReadOnly = false;
                    }

                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    dgvSalesPlan4P.Rows[r.Index].Cells["colRequireN100Convert"].Value =
                               (float)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnCalculatedValue"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnNeed2ProduceQty"].Value, typeof(int), 0);

                    dgvSalesPlan4P.Rows[r.Index].Cells["clnN100Convert"].Value =
                               (float)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnCalculatedValue"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnProducedQty"].Value, typeof(int), 0);
                }


                if (gridView.DataSource == null)
                    return;
                decimal summaryAmt = 0;
                // TODO:

                foreach (DataRow row in (gridView.DataSource as DataTable).Rows)
                {
                    if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached)
                        summaryAmt += (decimal)DataTypeParser.Parse(row["Amount"], typeof(decimal), 0);
                }
                txtTotalSalesAmount.Text = summaryAmt.ToString("N0");

            }
        }

        private void dgvSalesPlan4P_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ToastMessageBox.Show(Resource.errQty, Color.Red);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!HasNewRow(dgvSalesPlan4P))
            {
                DataUtil.AddNewRow(dgvSalesPlan4P.DataSource as DataTable);
                dgvSalesPlan4P.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvSalesPlan4P.CurrentCell = dgvSalesPlan4P.Rows[dgvSalesPlan4P.RowCount - 1].Cells["clnProductName"];
                dgvSalesPlan4P.Rows[dgvSalesPlan4P.Rows.Count - 1].Cells[clnProductName.Index].Value = -1;
            }
        }

        private void dgvSalesPlan4P_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSalesPlan4P == null || dgvSalesPlan4P.CurrentRow == null) return;

                if (dgvSalesPlan4P.Rows[e.RowIndex].ErrorText != string.Empty)
                {
                    dgvSalesPlan4P.CurrentRow.Cells[clnProductName.Index].Value = -1;
                    dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = string.Empty;
                }
                //else if (e.ColumnIndex == clnSalesQty.Index || e.ColumnIndex == clnRetailPrice.Index || e.ColumnIndex == clnNeed2ProduceQty.Index || e.ColumnIndex == clnProducedQty.Index || e.ColumnIndex == clnRemark.Index || e.ColumnIndex == clnN100Convert.Index)
                //{
                else if (e.ColumnIndex == clnSalesQty.Index || e.ColumnIndex == clnNeed2ProduceQty.Index || e.ColumnIndex == clnProducedQty.Index)
                {
                    int need2Produce = (int)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells[clnNeed2ProduceQty.Index].Value.ToString(), typeof(int), 0);
                    int salesQty = (int)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells[clnSalesQty.Index].Value.ToString(), typeof(int), 0);
                    int produceQty = (int)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells[clnProducedQty.Index].Value.ToString(), typeof(int), 0);

                    if (need2Produce < salesQty && need2Produce != 0)
                    {
                       // dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = "ရောင်းချမည့်အရေအတွက်သည် ထုတ်လုပ်ရန်လိုအပ်သည့်အရေအတွက်ထက်နည်းရမည်။";
                       // MessageBox.Show("ရောင်းချမည့်အရေအတွက်သည် ထုတ်လုပ်ရန်လိုအပ်သည့်အရေအတွက်ထက်နည်းရမည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgvSalesPlan4P.Rows[e.RowIndex].ErrorText = "";
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvSalesPlan4P_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvSalesPlan4P.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            DateTime PlanDate = (DateTime)DataTypeParser.Parse(dtpPlanMonth.Value, typeof(DateTime), DateTime.Now);
            frmSalePlan4ProductionCompare frmCompare = new frmSalePlan4ProductionCompare(PlanDate);
            UIManager.OpenForm(frmCompare);
        }
                

        private void dgvSalesPlan4P_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dgvSalesPlan4P_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv == null)
                return;
            // Calculate summmary again
            DataView dvCurrent = new DataView((gv.DataSource as DataTable), string.Empty, string.Empty, DataViewRowState.CurrentRows);
            CalculateSummary(dvCurrent);
        }

        #endregion

        private void dgvSalesPlan4P_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvSalesPlan4P.CurrentCell.ColumnIndex == clnProducedQty.Index || dgvSalesPlan4P.CurrentCell.ColumnIndex == clnAmount.Index || dgvSalesPlan4P.CurrentCell.ColumnIndex == clnNeed2ProduceQty.Index || dgvSalesPlan4P.CurrentCell.ColumnIndex == clnProducedQty.Index || dgvSalesPlan4P.CurrentCell.ColumnIndex == clnSalesQty.Index)
            {
                _txtQty = e.Control as TextBox;
                if (_txtQty != null)
                {
                    _txtQty.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                }
            }
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

        private void dgvSalesPlan4P_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_txtQty != null)
            {
                _txtQty.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<SalesPlanDetail> spdetails = new List<SalesPlanDetail>();
            Report.DataSet.PrintDataSet.tblSalesPlanDataTable dt = new Report.DataSet.PrintDataSet.tblSalesPlanDataTable();
            
            foreach (DataGridViewRow row in dgvSalesPlan4P.Rows)
            {
                if (row.IsNewRow)
                    break;
                SalesPlanDetail spdetail = new SalesPlanDetail()
                {
                    ID = 0,
                    ProductID = (int)DataTypeParser.Parse(row.Cells["clnProductName"].Value, typeof(int), -1),
                    SalesPlanID = 0,
                    SaleQty = (int)DataTypeParser.Parse(row.Cells["clnSalesQty"].Value, typeof(int), 0),
                    retailPrice = (decimal)DataTypeParser.Parse(row.Cells["clnRetailPrice"].Value, typeof(decimal), 0),
                    RequireQty = (int)DataTypeParser.Parse(row.Cells["clnNeed2ProduceQty"].Value, typeof(int), 0),
                    ProduceQty = (int)DataTypeParser.Parse(row.Cells["clnProducedQty"].Value, typeof(int), 0),
                    Nconvert = Convert.ToDecimal(DataTypeParser.Parse(row.Cells["clnN100Convert"].Value, typeof(decimal), 0)),
                    Remark = (string)DataTypeParser.Parse(row.Cells["clnRemark"].Value, typeof(string), string.Empty),
                };
                if (spdetail.retailPrice != 0 && spdetail.ProductID != -1 && spdetail.SaleQty != 0)
                {
                    spdetails.Add(spdetail);
                }
                DataGridViewComboBoxCell cell = row.Cells["clnProductName"] as DataGridViewComboBoxCell;
                DataTable product = cell.DataSource as DataTable;
                DataRow []dr = product.Select("ProductID="+spdetail.ProductID);
                dt.Rows.Add(dr[0]["ProductName"], spdetail.SaleQty, spdetail.ProduceQty, spdetail.Nconvert, spdetail.Nconvert, spdetail.Remark);
                //ds.Rows.Add(spdetail.ID, spdetail.SaleQty, spdetail.ProduceQty, spdetail.RequireQty, dr[0]["CalculatedValue"], spdetail.Nconvert, spdetail.retailPrice * spdetail.SaleQty, spdetail.Remark, dr[0]["ProductName"],dtpPlanMonth.Value);


            }
            
            Report.frmPrintPreview frmPreview = new Report.frmPrintPreview(dt,dtpPlanMonth.Value);
            frmPreview.ShowDialog();
        }
    }
}
