using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using log4net;
using PTIC.Common;
using PTIC.Sale.DA;
using PTIC.Util;
using PTIC.Sale.BL;

namespace PTIC.VC.Marketing.MarketingPlan
{
    public partial class frm6MonthPlan : Form
    {

        /// <summary>
        /// Logger for frmNewOrder
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frm6MonthPlan));

        DataTable dtAPCategory, dtAPSubCategory, dtPOSM;

        BindingSource bdAPCategory, bdfilteredAPSubCategory, bdAPSubCategory, bdfilteredPOSM, bdunfilteredPOSM;

        ComboBox cmb;

        /// <summary>
        /// Order to be modified
        /// </summary>
        private A_P_Plan _mdAPPlan = null;

        private int _APPlanId = -1;

        int indexAPSubCat = -1;
        int indexAP = -1;
        int indexAmount = -1;
        ComboBox cmbAP, cmbAPSub, cmbAPCat;

        DataTable applandetailTbl = new DataTable();
        DataTable applanTbl = new DataTable();

        A_P_Plan apPlan = new A_P_Plan();
        A_P_PlanDetail applanDetail = new A_P_PlanDetail();
        //A_P_Type aptype = new A_P_Type();
        //A_P ap = new A_P();

        decimal TotalUsageAmount = 0;
        float TotalSalesPlanPercent = 0;

        //private int mEditRow = -1;
        //int temprowid = 0;

        public frm6MonthPlan()
        {
            InitializeComponent();
            DateTime SelectedDate = new DateTime(dtpEndMonth.Value.Year, dtpEndMonth.Value.Month, 1);
            dtpEndMonth.Value = SelectedDate;
            LoadData();

            LoadNBind();

            indexAP = dgvAPPlanDetail.Columns.IndexOf(dgvAPPlanDetail.Columns["clnAPName"]);
            indexAPSubCat = dgvAPPlanDetail.Columns.IndexOf(dgvAPPlanDetail.Columns["clnAPSubCatName"]);
            indexAmount = dgvAPPlanDetail.Columns["clnUsageAmt"].Index;
            DataUtil.AddInitialNewRow(dgvAPPlanDetail);
            //calculateTotalAmount();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            decimal SalePlanAmount = (decimal)DataTypeParser.Parse(txtSalesPlanAmount.Text, typeof(decimal), 0);
            if (SalePlanAmount == 0)
            {
                MessageBox.Show("Sales Plan Amount မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Save();
            }
        }
               
        #region Private Method
        private void LoadNBind()
        {
            try
            {
                dgvAPPlanDetail.AutoGenerateColumns = false;
                DateTime currentDate = (DateTime)DataTypeParser.Parse(dtpEndMonth.Value, typeof(DateTime), DateTime.Now);
                //  Sales Plan Amount from SalesPlanDetail By Brand And Month
                DataTable dtSaleplan = new SalesPlanBL().GetbyMonthAndBrand(currentDate, (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), -1));
                if (dtSaleplan == null) return;
                applanTbl = new A_P_PlanBL().SelectByDate(currentDate, (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), -1));
                if (applanTbl.Rows.Count > 0)
                {
                    _APPlanId = Convert.ToInt32(applanTbl.Rows[0]["A_P_PlanID"].ToString());
                    if (dtSaleplan.Rows.Count > 0)
                    {
                        txtSalesPlanAmount.Text = ((decimal)DataTypeParser.Parse(dtSaleplan.Rows[0]["SalesPlanAmt"].ToString(), typeof(decimal), 0)).ToString("N0");
                    }
                    else
                    {
                        txtSalesPlanAmount.Text = "0";
                    }
                    //txtSalesPlanAmount.Text = ((decimal)DataTypeParser.Parse(applanTbl.Rows[0]["SalePlanAmt"], typeof(decimal), 0)).ToString("N0");
                    applandetailTbl = new A_P_PlanDetailBL().SelectByAPPanelID(_APPlanId);
                    if (applandetailTbl.Rows.Count == 0)
                    {
                        applandetailTbl.Rows.Add(applandetailTbl.NewRow());
                    }

                    dgvAPPlanDetail.DataSource = applandetailTbl;
                    colAPCategory.DataPropertyName = "APCategoryID";
                    calculateTotalAmount();
                }
                else
                {
                    if (dtSaleplan.Rows.Count > 0)
                    {
                        txtSalesPlanAmount.Text = ((decimal)DataTypeParser.Parse(dtSaleplan.Rows[0]["SalesPlanAmt"].ToString(), typeof(decimal), 0)).ToString("N0");
                    }
                    else
                    {
                        txtSalesPlanAmount.Text = "0";
                    }
                    _APPlanId = -1;

                    txtTotalUsageAmount.Text = "0";
                    txtTotalSalePlanPercent.Text = "0";
                    applandetailTbl = new A_P_PlanDetailBL().SelectByAPPanelID(_APPlanId);
                    applandetailTbl.Clear();
                    dgvAPPlanDetail.DataSource = applandetailTbl;
                    if (dgvAPPlanDetail.Rows.Count == 0)
                    {
                        DataRow newRow = applandetailTbl.NewRow();
                        applandetailTbl.Rows.Add(newRow);
                        this.dgvAPPlanDetail.DataSource = applandetailTbl;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void calculateTotalAmount()
        {
            //DataTable dtnew = dgvAPPlanDetail.DataSource as DataTable;
            //if (dtnew == null) return;
            //DataView dt = new DataView(dtnew, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
            //TotalSalesPlanPercent = 0;
            //TotalUsageAmount = 0;
            //foreach (DataRow dtrow in dt.ToTable().Rows)
            //{
            //    // if (dtrow.RowState == DataRowState.Added) break;
            //    TotalUsageAmount += (decimal)DataTypeParser.Parse(dtrow["UsageAmt"], typeof(decimal), -1);
            //    TotalSalesPlanPercent += (float)DataTypeParser.Parse(dtrow["SalePlanPercent"], typeof(float), -1);
            //}
            //txtTotalSalePlanPercent.Text = TotalSalesPlanPercent.ToString("N2");
            //txtTotalUsageAmount.Text = TotalUsageAmount.ToString("N0");
            //List<decimal> usagepercent = new List<decimal>();
            //foreach (DataRow dtrow in dt.ToTable().Rows)
            //{
            //    decimal usageamt = (decimal)DataTypeParser.Parse(dtrow["UsageAmt"], typeof(decimal), -1);
            //    if (TotalUsageAmount > 0)
            //    {
            //        usagepercent.Add((usageamt * 100) / TotalUsageAmount);
            //        dtrow["TotalAmtPercent"] = (usageamt * 100) / TotalUsageAmount;
            //    }
            //}

            DataTable newdt = dgvAPPlanDetail.DataSource as DataTable;
            if (newdt == null) return;
            DataView data = new DataView(newdt, string.Empty, string.Empty, DataViewRowState.CurrentRows);
            if (data == null)
            {
                txtTotalUsageAmount.Text = "0";
                return;
            }
            TotalSalesPlanPercent = 0;
            TotalUsageAmount = 0;
            foreach (DataRow dtrow in data.ToTable().Rows)
            {
                // if (dtrow.RowState == DataRowState.Added) break;
                TotalUsageAmount += (decimal)DataTypeParser.Parse(dtrow["UsageAmt"], typeof(decimal), -1);
                TotalSalesPlanPercent += (float)DataTypeParser.Parse(dtrow["SalePlanPercent"], typeof(float), -1);
            }
            txtTotalSalePlanPercent.Text = TotalSalesPlanPercent.ToString("N2");
            txtTotalUsageAmount.Text = TotalUsageAmount.ToString("N0");
        }

        private void calculateTotalAmount(DataGridViewCellEventArgs e)
        {
            DataTable dtnew = dgvAPPlanDetail.DataSource as DataTable;
            if (dtnew == null) return;
            DataView dt = new DataView(dtnew, string.Empty, string.Empty, DataViewRowState.CurrentRows);
            TotalSalesPlanPercent = 0;
            TotalUsageAmount = 0;
            foreach (DataRow dtrow in dt.ToTable().Rows)
            {
                // if (dtrow.RowState == DataRowState.Added) break;
                TotalUsageAmount += (decimal)DataTypeParser.Parse(dtrow["UsageAmt"], typeof(decimal), -1);
                TotalSalesPlanPercent += (float)DataTypeParser.Parse(dtrow["SalePlanPercent"], typeof(float), -1);
            }
            txtTotalSalePlanPercent.Text = TotalSalesPlanPercent.ToString("N2");
            txtTotalUsageAmount.Text = TotalUsageAmount.ToString("N0");
            List<decimal> usagepercent = new List<decimal>();
            int i = 0;
            foreach (DataRow dtrow in dt.ToTable().Rows)
            {
                decimal usageamt = (decimal)DataTypeParser.Parse(dtrow["UsageAmt"], typeof(decimal), -1);
                if (TotalUsageAmount > 0)
                {
                    //usagepercent.Add((usageamt * 100) / TotalUsageAmount);
                    //dtrow["TotalAmtPercent"] = (usageamt * 100) / TotalUsageAmount;     
                    dgvAPPlanDetail.Rows[i].Cells[clnTotalAmtPercent.Index].Value = (usageamt * 100) / TotalUsageAmount;
                    i++;
                }
            }
        }


        private bool HasNewRow(DataGridView dgv)
        {
            int? AP_PlanDetailID = (int?)DataTypeParser.Parse(dgv.Rows[dgv.Rows.Count - 1].Cells[clnAPPlanDetailID.Index].Value, typeof(int), null);

            if (AP_PlanDetailID != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        private void Save()
        {
            A_P_PlanBL apPlanBL = null;
            A_P_PlanDetailBL apPlanDetailBL = null;

            if(!string.IsNullOrEmpty(txtTotalSalePlanPercent.Text)){
            decimal salesPercentage = decimal.Parse(txtTotalSalePlanPercent.Text);
                if (salesPercentage >=100) 
                {
                    MessageBox.Show("A & P Plan Amount shouldn't be greather than or equal to sales Amount!\nPlease Check Total Amount and try again!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            
            


            A_P_Plan apPlan = null;
            try
            {
                DataTable dt = dgvAPPlanDetail.DataSource as DataTable;

                apPlanBL = new A_P_PlanBL();
                apPlanDetailBL = new A_P_PlanDetailBL();
                apPlan = new A_P_Plan()
                {
                    // APPlanID
                    A_P_PlanDate = dtpEndMonth.Value,
                    SalePlanAmt = (decimal)DataTypeParser.Parse(txtSalesPlanAmount.Text, typeof(decimal), 0),
                    Status = 0
                };
                List<A_P_PlanDetail> insertApPlanDetails = new List<A_P_PlanDetail>();
                List<A_P_PlanDetail> updateApPlanDetails = new List<A_P_PlanDetail>();
                List<A_P_PlanDetail> deleteApPlanDetails = new List<A_P_PlanDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    int newInt = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1);
                    if (newInt < 0)
                    {
                        MessageBox.Show("Must Fill Required Data!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        A_P_PlanDetail applanDetail = new A_P_PlanDetail()
                        {
                            A_P_PlanDetailID = (int)DataTypeParser.Parse(row["AP_PlanDetailID"].ToString(), typeof(int), -1),
                            A_P_PlanID = (int)DataTypeParser.Parse(row["A_P_PlanID"].ToString(), typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), -1),
                            A_P_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                            UsageAmt = Convert.ToDecimal(DataTypeParser.Parse(row["UsageAmt"].ToString(), typeof(decimal), 0)),
                            TotalAmtPercent = (float)DataTypeParser.Parse(row["TotalAmtPercent"].ToString(), typeof(float), -1),
                            SalePlanPercent = (float)DataTypeParser.Parse(row["SalePlanPercent"].ToString(), typeof(float), -1)
                        };
                        if (applanDetail.UsageAmt != 0 && applanDetail.A_P_MaterialID != -1)
                        {
                            insertApPlanDetails.Add(applanDetail);
                        }
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    A_P_PlanDetail applanDetail = new A_P_PlanDetail()
                    {
                        A_P_PlanDetailID = (int)DataTypeParser.Parse(row["AP_PlanDetailID"].ToString(), typeof(int), -1),
                        A_P_PlanID = (int)DataTypeParser.Parse(row["A_P_PlanID"].ToString(), typeof(int), -1),
                        A_P_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        UsageAmt = Convert.ToDecimal(DataTypeParser.Parse(row["UsageAmt"].ToString(), typeof(decimal), 0)),
                        TotalAmtPercent = (float)DataTypeParser.Parse(row["TotalAmtPercent"].ToString(), typeof(float), -1),
                        SalePlanPercent = (float)DataTypeParser.Parse(row["SalePlanPercent"].ToString(), typeof(float), -1)
                    };
                    if (applanDetail.UsageAmt != 0 || applanDetail.A_P_MaterialID != -1)
                    {
                        deleteApPlanDetails.Add(applanDetail);
                    }
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    int newInt = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1);
                    if (newInt < 0)
                    {
                        // What's up?
                    }
                    else
                    {
                        A_P_PlanDetail applanDetail = new A_P_PlanDetail()
                        {
                            A_P_PlanDetailID = (int)DataTypeParser.Parse(row["AP_PlanDetailID"].ToString(), typeof(int), -1),
                            A_P_PlanID = (int)DataTypeParser.Parse(row["A_P_PlanID"].ToString(), typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), -1),
                            A_P_MaterialID = (int)(DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1)),
                            UsageAmt = Convert.ToDecimal(DataTypeParser.Parse(row["UsageAmt"].ToString(), typeof(decimal), 0)),
                            TotalAmtPercent = (float)DataTypeParser.Parse(row["TotalAmtPercent"].ToString(), typeof(float), -1),
                            SalePlanPercent = (float)DataTypeParser.Parse(row["SalePlanPercent"].ToString(), typeof(float), -1)
                        };
                        if (applanDetail.UsageAmt != 0 || applanDetail.A_P_MaterialID != -1)
                        {
                            updateApPlanDetails.Add(applanDetail);
                        }
                    }
                }

                int affectedRows = 0;
                if (_APPlanId == -1) // Add new order and details
                {
                    if (insertApPlanDetails.Count > 0 && apPlan != null)
                        affectedRows += apPlanBL.Add(apPlan, insertApPlanDetails);
                    else
                    {
                        ToastMessageBox.Show("Blank A & P Detail Data!");
                        return;
                    }
                }
                else // Update an existing order and details
                {
                    // Update order by A & P Plan ID
                    apPlan.A_P_PlanID = _APPlanId;

                    if (insertApPlanDetails.Count > 0) affectedRows += apPlanBL.Update(apPlan, insertApPlanDetails);
                    if (deleteApPlanDetails.Count > 0) affectedRows += apPlanDetailBL.Delete(deleteApPlanDetails);
                    if (updateApPlanDetails.Count > 0) affectedRows += apPlanDetailBL.Update(apPlan, updateApPlanDetails);
                    affectedRows = apPlanBL.UpdateByAPPlanID(apPlan);
                }
                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBind();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }

        private void LoadData()  //Load Data for Grid
        {
            try
            {
                dtAPCategory = new APCategoryDAO().SelectAll();
                dtAPCategory.DefaultView.Sort = string.Format("{0} {1}", "CategoryName", "asc");
                dtAPCategory =  dtAPCategory.DefaultView.ToTable();

                dtAPSubCategory = new APSubCategoryDAO().SelectAllAPSubCat();
                dtAPSubCategory.DefaultView.Sort = string.Format("{0} {1}", "APSubCategoryName", "asc");
                dtAPSubCategory = dtAPSubCategory.DefaultView.ToTable();

                dtPOSM = new APMaterialDAO().SelectAllWithAPSubCat();
                dtPOSM.DefaultView.Sort = string.Format("{0} {1}", "APMaterialName", "asc");
                dtPOSM = dtPOSM.DefaultView.ToTable();

                bdAPCategory = new BindingSource();
                bdAPCategory.DataSource = dtAPCategory;
                colAPCategory.DataSource = bdAPCategory;
                colAPCategory.DisplayMember = "CategoryName";
                colAPCategory.ValueMember = "ID";

                bdAPSubCategory = new BindingSource();
                DataView undvsub = new DataView(dtAPSubCategory);

                bdAPSubCategory.DataSource = undvsub;
                clnAPSubCatName.DataSource = bdAPSubCategory;
                clnAPSubCatName.DisplayMember = "APSubCategoryName";
                clnAPSubCatName.ValueMember = "AP_SubCategoryID";

                bdfilteredAPSubCategory = new BindingSource();
                DataView fdvsub = new DataView(dtAPSubCategory);
                bdfilteredAPSubCategory.DataSource = fdvsub;

                bdunfilteredPOSM = new BindingSource();
                DataView undv = new DataView(dtPOSM);

                bdunfilteredPOSM.DataSource = undv;
                clnAPName.DataSource = bdunfilteredPOSM;
                clnAPName.DisplayMember = "APMaterialName";
                clnAPName.ValueMember = "AP_MaterialID";

                bdfilteredPOSM = new BindingSource();
                DataView fdv = new DataView(dtPOSM);
                bdfilteredPOSM.DataSource = fdv;

                // Load and bind brand
                cmbBrand.DataSource = new BrandBL().GetAll();
                cmbBrand.ValueMember = "BrandID";
                cmbBrand.DisplayMember = "BrandName";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void BindData()  // Bind Data into DataGridView
        {
            A_P_Plan apPlan = new A_P_Plan()
            {
                // APPlanID
                A_P_PlanDate = dtpEndMonth.Value,
                SalePlanAmt = (decimal)DataTypeParser.Parse(txtSalesPlanAmount.Text, typeof(decimal), 0),
                Status = 0
            };
        }

        #endregion

        private void butDelete_Click(object sender, EventArgs e)
        {
            //Delete
            if (dgvAPPlanDetail.CurrentRow.IsNewRow || dgvAPPlanDetail.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            DataGridViewRow selectedRow = dgvAPPlanDetail.CurrentRow;
            int apPlanDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["clnAPPlanDetailID"].Value, typeof(int), -1);
            if (apPlanDetailID == -1)
            {
                dgvAPPlanDetail.Rows.RemoveAt(dgvAPPlanDetail.CurrentRow.Index);
            }
            else
            {              
                // delete a selected order
                DeleteAPPlanDetail(apPlanDetailID);
            }
        }


        private void DeleteAPPlanDetail(int apPlanDetailID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete an order detail
                int affectedRows = new A_P_PlanDetailBL().DeleteByAPPlanDetailID(apPlanDetailID, conn);
                if (affectedRows > 0)
                {
                    dgvAPPlanDetail.Rows.RemoveAt(dgvAPPlanDetail.CurrentRow.Index);
                    if (dgvAPPlanDetail.RowCount == 0)
                    {
                        DataTable apPlanDetailTbl = dgvAPPlanDetail.DataSource as DataTable;
                        DataRow newRow = apPlanDetailTbl.NewRow();
                        apPlanDetailTbl.Rows.Add(newRow);
                        dgvAPPlanDetail.DataSource = apPlanDetailTbl;
                    }
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    LoadNBind();
                }

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

        private void dtpEndMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadNBind();
        }

        private void dgvAPPlanDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //  dgvAPPlanDetail.Rows[e.RowIndex].Cells["ClnNo"].Value = (e.RowIndex + 1).ToString();
        }


        private void dgvAPPlanDetail_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //  dgvAPPlanDetail.AllowUserToAddRows = true;
        }

        private void dgvAPPlanDetail_TabStopChanged(object sender, EventArgs e)
        {
            dgvAPPlanDetail.Rows.Add();
        }

        private void dgvAPPlanDetail_SelectionChanged(object sender, EventArgs e)
        {
            //if(mEditRow >= 0) 

            //{
            //    int new_row=mEditRow;
            //    mEditRow = -1;
            //    dgvAPPlanDetail.CurrentCell = dgvAPPlanDetail.Rows[new_row].Cells[dgvAPPlanDetail.CurrentCell.ColumnIndex];

            //}
        }


        private void dgvAPPlanDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
            if (this.dgvAPPlanDetail.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvAPPlanDetail.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void frm6MonthPlan_Load(object sender, EventArgs e)
        {
            dgvAPPlanDetail.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && dgvAPPlanDetail != null)
            {
                int iColumn = dgvAPPlanDetail.CurrentCell.ColumnIndex;
                int iRow = dgvAPPlanDetail.CurrentCell.RowIndex;
                if (iColumn == dgvAPPlanDetail.Columns["clnSalePlanPercent"].Index)
                {
                    if (dgvAPPlanDetail.CurrentRow.ErrorText != string.Empty) return base.ProcessCmdKey(ref msg, keyData);
                    //if (HasNewRow(dgvAPPlanDetail)) return base.ProcessCmdKey(ref msg, keyData);

                    if (iRow + 1 >= dgvAPPlanDetail.Rows.Count)
                    {
                        DataTable apPlanDetailTbl = dgvAPPlanDetail.DataSource as DataTable;
                        DataRow newRow = apPlanDetailTbl.NewRow();
                        apPlanDetailTbl.Rows.Add(newRow);
                        this.dgvAPPlanDetail.DataSource = apPlanDetailTbl;
                        dgvAPPlanDetail[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvAPPlanDetail.CurrentCell = dgvAPPlanDetail[0, iRow + 1];
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
                        dgvAPPlanDetail.CurrentCell = dgvAPPlanDetail[dgvAPPlanDetail.CurrentCell.ColumnIndex + 1, dgvAPPlanDetail.CurrentCell.RowIndex];

                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvAPPlanDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAPPlanDetail == null || dgvAPPlanDetail.CurrentCell == null) return;

            if (dgvAPPlanDetail.CurrentCell.ColumnIndex == clnUsageAmt.Index)
            {
                Decimal totalAmt = (Decimal)DataTypeParser.Parse(txtTotalUsageAmount.Text, typeof(Decimal), -1);
                Decimal saleplanAmt = (Decimal)DataTypeParser.Parse(txtSalesPlanAmount.Text, typeof(Decimal), -1);
                Decimal usageAmt = (Decimal)DataTypeParser.Parse(dgvAPPlanDetail.CurrentRow.Cells["clnUsageAmt"].Value, typeof(Decimal), -1);
                if (saleplanAmt > 0)
                {
                    dgvAPPlanDetail.CurrentRow.Cells["clnSalePlanPercent"].Value = (usageAmt * 100) / saleplanAmt;
                }
                if (totalAmt > 0)
                {
                    dgvAPPlanDetail.CurrentRow.Cells["clnTotalAmtPercent"].Value = (usageAmt * 100) / totalAmt;
                }
                calculateTotalAmount(e);
            }
            if (dgvAPPlanDetail.CurrentRow.Cells[e.ColumnIndex].ErrorText != String.Empty && e.ColumnIndex == clnUsageAmt.Index)
            {
                //txtSalesPlanAmount.Text = "0";
                dgvAPPlanDetail.CurrentRow.Cells[clnUsageAmt.Index].Value = 0;
                
                dgvAPPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            if (dgvAPPlanDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == clnAPName.Index)
            {
                
                dgvAPPlanDetail.CurrentRow.Cells[clnAPName.Index].Value = -1;
                
                dgvAPPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            if (dgvAPPlanDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == clnAPSubCatName.Index)
            {
              
                dgvAPPlanDetail.CurrentRow.Cells[clnAPSubCatName.Index].Value = -1;
              
                dgvAPPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            }

            try
            {
                if (e.ColumnIndex == this.clnAPName.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPPlanDetail[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredPOSM;

                    //  this.bdfilteredPOSM.RemoveFilter();
                }
                if (e.ColumnIndex == this.clnAPSubCatName.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPPlanDetail[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdAPSubCategory;
                }


            }

            catch { }
        
        }

        private void txtSalesPlanAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void dgvAPPlanDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal totalAmt = (decimal)DataTypeParser.Parse(txtTotalUsageAmount.Text.ToString(), typeof(decimal), 0);
            decimal SalePlanAmt = (decimal)DataTypeParser.Parse(txtSalesPlanAmount.Text.ToString(), typeof(decimal), 0);
            var dgv = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (e.ColumnIndex == clnAPName.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["clnAPName"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["clnAPName"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                            // return;
                        }
                        //else
                        //{
                        //    dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        //}
                    }
                }
            }
            if (e.ColumnIndex == 6)
            {
                decimal newInteger;
                if (dgvAPPlanDetail.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    dgv.Rows[e.RowIndex].ErrorText ="Amount must be fill";
                    MessageBox.Show("သုံးစွဲမည့်ပမာဏဖြည့်သွင်းပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (totalAmt > SalePlanAmt)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "ခွင့်ပြုငွေထက်ကျော်လွန်နေပါသည်။";
                    MessageBox.Show("ခွင့်ပြုငွေထက်ကျော်လွန်နေပါသည်။","သတိပေးချက်",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(e.FormattedValue.ToString(),
                     out newInteger) || newInteger <= 0)
                {
                    // e.Cancel = true;
                    txtTotalUsageAmount.Text = "0";
                    dgv.Rows[e.RowIndex].ErrorText = "သုံးစွဲမည့်ငွေပမာဏ မှားယွင်းနေသည်။";
                    MessageBox.Show("သုံးစွဲမည့်ငွေပမာဏ မှားယွင်းနေသည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void dgvAPPlanDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // dgvAPPlanDetail.CurrentRow.Cells[e.ColumnIndex].ErrorText = "";
        }

        private void dgvAPPlanDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //    if (dgvAPPlanDetail.CurrentCell.ColumnIndex == indexAmount)
            //    {
            dgvAPPlanDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        private void dgvAPPlanDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculateTotalAmount();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (dgvAPPlanDetail == null || dgvAPPlanDetail.CurrentRow == null) return;

            if (dgvAPPlanDetail.CurrentRow.ErrorText != string.Empty) return;
            if (!HasNewRow(dgvAPPlanDetail))
            {
                DataUtil.AddNewRow(dgvAPPlanDetail.DataSource as DataTable);
            }
        }

        private void dgvAPPlanDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == clnAPSubCatName.Index)
                {
                    int AP_Cat = (int)DataTypeParser.Parse(this.dgvAPPlanDetail[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_Cat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPPlanDetail[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredAPSubCategory;

                    this.bdfilteredAPSubCategory.Filter = "AP_CategoryID = " + this.dgvAPPlanDetail[e.ColumnIndex - 1, e.RowIndex].Value.ToString();

                }
                if (e.ColumnIndex == clnAPName.Index)
                {
                    int AP_SubCat = (int)DataTypeParser.Parse(this.dgvAPPlanDetail[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_SubCat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPPlanDetail[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredPOSM;

                    this.bdfilteredPOSM.Filter = "AP_SubCategoryID = " + this.dgvAPPlanDetail[e.ColumnIndex - 1, e.RowIndex].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvAPPlanDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if ((int)DataTypeParser.Parse(r.Cells[clnAPPlanDetailID.Index].Value, typeof(int), -1) != -1)
                    {
                        dgv.Rows[r.Index].ReadOnly = true;
                    }
                }
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNBind();
        }

        private void dgvAPPlanDetail_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == colAPCategory.Index)
            {
                Frm_A_PCategory AP_CategoryFrm = new Frm_A_PCategory();
                AP_CategoryFrm.ShowDialog();
                LoadData();
            }
            else if (e.ColumnIndex == clnAPName.Index)
            {
                PITC.VC.Marketing.Frm_APProductRegister AP_ProductFrm = new PITC.VC.Marketing.Frm_APProductRegister();
                AP_ProductFrm.ShowDialog();
                LoadData();
            }
            else if (e.ColumnIndex == clnAPSubCatName.Index) 
            {
                PITC.VC.Marketing.Frm_APSubCategory APSubCategoryFrm = new PITC.VC.Marketing.Frm_APSubCategory();
                APSubCategoryFrm.ShowDialog();
                LoadData();
            }





        }

    }
}
