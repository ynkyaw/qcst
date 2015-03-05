/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/28 (yyyy/mm/dd)
 * Description: Competitor Activity form
 */
using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.Marketing.DailyMarketing;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmCompetitorActivity : Form
    {
        /// <summary>
        /// Logger for frmCompetitorActivity
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmCompetitorActivity));

        /// <summary>
        /// 
        /// </summary>
        private int? _competitorActivityID = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void CompetitorActivitySaveHandler(object sender, CompetitorActivitySaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event CompetitorActivitySaveHandler CompetitorActivitySavedHandler;

        #region Events
        private void dgvAPSupport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Name.Equals("colDeleteAPSupport"))
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                    return;

                DataGridViewRow selectedRow = dgv.CurrentRow;
                DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
                if (selectedRowState == DataRowState.Added || selectedRowState == DataRowState.Detached)
                {
                    // Delete row just from GridView because it is a new row that has not been in Database
                    dgv.Rows.RemoveAt(selectedRow.Index);
                    return;
                }

                int APSupportID = (int)DataTypeParser.Parse(selectedRow.Cells["colCompetitor_A_P_SupportID"].Value, typeof(int), -1);
                if (APSupportID == -1)
                {
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // delete a selected product from database
                    DeleteAPSupport(APSupportID, dgv);
                }
            }
        }

        private void dgvMarketPromo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Name.Equals("colDeleteMktPromo"))
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                    return;

                DataGridViewRow selectedRow = dgv.CurrentRow;
                DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
                if (selectedRowState == DataRowState.Added || selectedRowState == DataRowState.Detached)
                {
                    // Delete row just from GridView because it is a new row that has not been in Database
                    dgv.Rows.RemoveAt(selectedRow.Index);
                    return;
                }

                int competitorMarketPromotionID = (int)DataTypeParser.Parse(selectedRow.Cells["colCompetitorMarketPromotionID"].Value, typeof(int), -1);
                if (competitorMarketPromotionID == -1)
                {
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // delete a selected product from database
                    DeleteMarketPromo(competitorMarketPromotionID, dgv);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save records
            Save();
        }

        #endregion

        #region Private Methods
        private void LoadNBind()
        {             
            try
            {
                // Load Brands                
                DataTable dtCBrands = new BrandBL().GetCompetitorBrands();
                // Bind CBrands
                colBrand.DataSource = dtCBrands;
                colBrandMktPromo.DataSource = dtCBrands;
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

        private void Save()
        {
            SqlConnection conn = null;
            CompetitorActivityBL competitorActivitySaver = null;
            Competitor_A_P_SupportBL competitor_A_P_SupportSaver = null;
            CompetitorMarketPromotionBL competitorMarketPromotionSaver = null;
            CompetitorActivity competitorActivity = null;
            int? affectedRows = null;

            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                competitorActivitySaver = new CompetitorActivityBL();
                competitor_A_P_SupportSaver = new Competitor_A_P_SupportBL();
                competitorMarketPromotionSaver = new CompetitorMarketPromotionBL();

                competitorActivity = new CompetitorActivity() 
                {
                    //CompetitorActivityID =
                    A_P_Remark = txtAPRemark.Text,
                    MarketPromoRemark =  txtMarketPromoRemark.Text
                };

                if (!_competitorActivityID.HasValue) // Add new CompetitorActivity, Competitor_A_P_Support and CompetitorMarketPromotion
                {
                    // Add Competitor_A_P_Support to List
                    List<Competitor_A_P_Support> newCompetitor_A_P_Supports = new List<Competitor_A_P_Support>();
                    foreach (DataGridViewRow row in dgvAPSupport.Rows)
                    {
                        if (row.IsNewRow)
                            break;
                        Competitor_A_P_Support newCompetitor_A_P_Support = new Competitor_A_P_Support()
                        {
                            //CActivityID =
                            BrandID = (int)DataTypeParser.Parse(row.Cells["colBrand"].Value, typeof(int), -1),
                            A_P_Type = (string)DataTypeParser.Parse(row.Cells["colA_P_Type"].Value, typeof(string), string.Empty),
                            A_P_Size = (string)DataTypeParser.Parse(row.Cells["colA_P_Size"].Value, typeof(string), string.Empty),
                            Period = (int)DataTypeParser.Parse(row.Cells["colPeriod"].Value, typeof(int), 0),
                            Result = (string)DataTypeParser.Parse(row.Cells["colResult"].Value, typeof(string), string.Empty)
                        };
                        newCompetitor_A_P_Supports.Add(newCompetitor_A_P_Support);
                    }

                    // Add CompetitorMarketPromotion to List
                    List<CompetitorMarketPromotion> newCompetitorMarketPromotions = new List<CompetitorMarketPromotion>();
                    foreach (DataGridViewRow rowMkPromo in dgvMarketPromo.Rows)
                    {
                        if (rowMkPromo.IsNewRow)
                            break;
                        CompetitorMarketPromotion newCompetitorMarketPromotion = new CompetitorMarketPromotion()
                        {
                            //CActivityID =
                            BrandID = (int)DataTypeParser.Parse(rowMkPromo.Cells["colBrandMktPromo"].Value, typeof(int), -1),
                            PromoActivity = (string)DataTypeParser.Parse(rowMkPromo.Cells["colPromoActivity"].Value, typeof(string), string.Empty),
                            FromDate = (DateTime)DataTypeParser.Parse(rowMkPromo.Cells["colFromDate"].Value, typeof(DateTime), DateTime.Now),
                            ToDate = (DateTime)DataTypeParser.Parse(rowMkPromo.Cells["colToDate"].Value, typeof(DateTime), DateTime.Now),
                            Period = (int)DataTypeParser.Parse(rowMkPromo.Cells["colPeriodMktPromo"].Value, typeof(int), 0),
                            Result = (string)DataTypeParser.Parse(rowMkPromo.Cells["colResultMktPromo"].Value, typeof(string), string.Empty)
                        };
                        newCompetitorMarketPromotions.Add(newCompetitorMarketPromotion);
                    }
                    // Save new Activity, APSupport and MarketPromotion and make CompetitorActivityID present in this form
                    _competitorActivityID = affectedRows = competitorActivitySaver.Add(
                        competitorActivity,
                        newCompetitor_A_P_Supports,
                        newCompetitorMarketPromotions,
                        conn);
                } // END of if(!_competitorActivityID.HasValue)
                else // Update existing CompetitorActivity, Competitor_A_P_Support and CompetitorMarketPromotion
                {
                    competitorActivity.CompetitorActivityID = (int)DataTypeParser.Parse(this._competitorActivityID, typeof(int), null);
                    // Update an existing CompetitorActivity from database
                    affectedRows = competitorActivitySaver.UpdateByCompetitorActivityID(competitorActivity, conn);

                    // APSupport
                    DataTable dtAPSupport = dgvAPSupport.DataSource as DataTable;
                    // New APSupport
                    DataView dvAPSupportInsert = new DataView(dtAPSupport, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvAPSupportInsert.ToTable().Rows)
                    {
                        Competitor_A_P_Support newCompetitor_A_P_Support = new Competitor_A_P_Support()
                        {
                            CActivityID = (int)DataTypeParser.Parse(_competitorActivityID, typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            A_P_Type = (string)DataTypeParser.Parse(row["A_P_Type"], typeof(string), string.Empty),
                            A_P_Size = (string)DataTypeParser.Parse(row["A_P_Size"], typeof(string), string.Empty),
                            Period = (int)DataTypeParser.Parse(row["Period"], typeof(int), 0),
                            Result = (string)DataTypeParser.Parse(row["Result"], typeof(string), string.Empty)
                        };
                        // Add new Competitor_A_P_Support into database
                        affectedRows += competitor_A_P_SupportSaver.Add(newCompetitor_A_P_Support, conn);
                    }
                    // Update APSupport
                    DataView dvAPSupportUpdate = new DataView(dtAPSupport, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvAPSupportUpdate.ToTable().Rows)
                    {
                        Competitor_A_P_Support mdCompetitor_A_P_Support = new Competitor_A_P_Support()
                        {
                            ID = (int)DataTypeParser.Parse(row["Competitor_A_P_SupportID"], typeof(int), -1),
                            CActivityID = (int)DataTypeParser.Parse(row["CActivityID"], typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            A_P_Type = (string)DataTypeParser.Parse(row["A_P_Type"], typeof(string), string.Empty),
                            A_P_Size = (string)DataTypeParser.Parse(row["A_P_Size"], typeof(string), string.Empty),
                            Period = (int)DataTypeParser.Parse(row["Period"], typeof(int), 0),
                            Result = (string)DataTypeParser.Parse(row["Result"], typeof(string), string.Empty)
                        };
                        // Update existing Competitor_A_P_Support from database
                        affectedRows += competitor_A_P_SupportSaver.UpdateByID(mdCompetitor_A_P_Support, conn);
                    }

                    // CompetitorMarketPromotion
                    DataTable dtMktPromo = dgvMarketPromo.DataSource as DataTable;
                    // New CompetitorMarketPromotion
                    DataView dvMktPromoInsert = new DataView(dtMktPromo, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvMktPromoInsert.ToTable().Rows)
                    {
                        CompetitorMarketPromotion newCompetitorMarketPromotion = new CompetitorMarketPromotion()
                        {
                            CActivityID = (int)DataTypeParser.Parse(_competitorActivityID, typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row["BrandMktPromo"], typeof(int), -1),
                            PromoActivity = (string)DataTypeParser.Parse(row["PromoActivity"], typeof(string), string.Empty),
                            FromDate = (DateTime)DataTypeParser.Parse(row["FromDate"], typeof(DateTime), DateTime.Now),
                            ToDate = (DateTime)DataTypeParser.Parse(row["ToDate"], typeof(DateTime), DateTime.Now),
                            Period = (int)DataTypeParser.Parse(row["PeriodMktPromo"], typeof(int), 0),
                            Result = (string)DataTypeParser.Parse(row["ResultMktPromo"], typeof(string), string.Empty)
                        };
                        // Insert new CompetitorMarketPromotion into database
                        affectedRows += competitorMarketPromotionSaver.Add(newCompetitorMarketPromotion, conn);
                    }
                    // Update CompetitorMarketPromotion
                    DataView dvMktPromoUpdate = new DataView(dtMktPromo, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvMktPromoUpdate.ToTable().Rows)
                    {
                        CompetitorMarketPromotion mdCompetitorMarketPromotion = new CompetitorMarketPromotion()
                        {
                            ID = (int)DataTypeParser.Parse(row["CompetitorMarketPromotionID"], typeof(int), -1),
                            CActivityID = (int)DataTypeParser.Parse(row["CActivityID"], typeof(int), -1),
                            //BrandID = (int)DataTypeParser.Parse(row["BrandMktPromo"], typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            PromoActivity = (string)DataTypeParser.Parse(row["PromoActivity"], typeof(string), string.Empty),
                            FromDate = (DateTime)DataTypeParser.Parse(row["FromDate"], typeof(DateTime), DateTime.Now),
                            ToDate = (DateTime)DataTypeParser.Parse(row["ToDate"], typeof(DateTime), DateTime.Now),
                            //Period = (int)DataTypeParser.Parse(row["PeriodMktPromo"], typeof(int), 0),
                            Period = (int)DataTypeParser.Parse(row["Period"], typeof(int), 0),
                            //Result = (string)DataTypeParser.Parse(row["ResultMktPromo"], typeof(string), string.Empty)
                            Result = (string)DataTypeParser.Parse(row["Result"], typeof(string), string.Empty)
                        };
                        // Update CompetitorMarketPromotion from database
                        affectedRows += competitorMarketPromotionSaver.UpdateByID(mdCompetitorMarketPromotion, conn);
                    }
                } // END of update existing records
                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                    // return value to sender
                    CompetitorActivitySaveEventArgs competitorActivitySaveEventArgs = new CompetitorActivitySaveEventArgs(_competitorActivityID);
                    CompetitorActivitySavedHandler(this, competitorActivitySaveEventArgs);

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                ToastMessageBox.Show(Resource.errFailedToSave);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void DeleteAPSupport(int APSupportID, DataGridView dgv)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete a selected product
                int affectedRows = new Competitor_A_P_SupportBL().DeleteByID(APSupportID, conn);
                if (affectedRows > 0)
                {
                    // remove row @gridvew also
                    dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void DeleteMarketPromo(int competitorMarketPromotionID, DataGridView dgv)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete a selected product
                int affectedRows = new CompetitorMarketPromotionBL().DeleteByID(competitorMarketPromotionID, conn);
                if (affectedRows > 0)
                {
                    // remove row @gridvew also
                    dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        #endregion

        #region Constructors
        public frmCompetitorActivity()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvAPSupport.AutoGenerateColumns = false;
            dgvMarketPromo.AutoGenerateColumns = false;
            // Set binding fields
            string brandDisplayMember = "BrandName";
            string brandValueMember = "BrandID";            
            colBrand.DisplayMember = brandDisplayMember;
            colBrand.ValueMember = brandValueMember;
            colBrandMktPromo.DisplayMember = brandDisplayMember;
            colBrandMktPromo.ValueMember = brandValueMember;
            // Load and bind data
            LoadNBind();
          
        }

        public frmCompetitorActivity(int? competitorActivityID)
            : this()
        {
            this._competitorActivityID = competitorActivityID;
            int intCompetitorActivity = (int)DataTypeParser.Parse(this._competitorActivityID, typeof(int), -1);
            // Load APSuport and Marketing Promotion
            LoadNBindByCompetitorActivityID(intCompetitorActivity);
            if (dgvAPSupport.Rows.Count == 0)
            {
                DataTable dt = dgvAPSupport.DataSource as DataTable;
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
                this.dgvAPSupport.DataSource = dt;
            }
            if (dgvMarketPromo.Rows.Count == 0)
            {
                DataTable dt = dgvMarketPromo.DataSource as DataTable;
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
                this.dgvMarketPromo.DataSource = dt;
            }
        }
        #endregion

        private void LoadNBindByCompetitorActivityID(int competitorActivityID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Load CompetitorActivity
                DataTable cActivity = new CompetitorActivityBL().GetByCompetitorActivityID(competitorActivityID, conn);
                if(cActivity.Rows.Count > 0)
                {
                    txtAPRemark.Text = (string)DataTypeParser.Parse(cActivity.Rows[0]["A_P_Remark"], typeof(string), string.Empty);
                    txtMarketPromoRemark.Text = (string)DataTypeParser.Parse(cActivity.Rows[0]["MarketPromoRemark"], typeof(string), string.Empty);
                }
                // Load C AP Support
                dgvAPSupport.DataSource = new Competitor_A_P_SupportBL().GetByCompetitorActivityID(competitorActivityID, conn);
                // Load C Marketing Promotion
                dgvMarketPromo.DataSource = new CompetitorMarketPromotionBL().GetByCompetitorActivityID(competitorActivityID, conn);
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

        #region Inner Class
        public class CompetitorActivitySaveEventArgs : EventArgs
        {
            private int? _ComActivityID = null;
            public CompetitorActivitySaveEventArgs(int? comActivityID)
            {
                this._ComActivityID = comActivityID;
            }
            public int? CompetitorActivityID
            {
                get { return this._ComActivityID; }
            }
        }
        #endregion

        private void dgvAPSupport_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvAPSupport.Rows[e.RowIndex].Cells["colSrNo"].Value = (e.RowIndex + 1);
        }

        private void dgvMarketPromo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvMarketPromo.Rows[e.RowIndex].Cells["colSr"].Value = (e.RowIndex + 1);
        }
      
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
            //if (keyData == Keys.Enter)
            //{               
            //    //    dgvMarketingPlan.BeginEdit(true);
            //    // e.SuppressKeyPress = true;
            //    int iColumn = dgvAPSupport.CurrentCell.ColumnIndex;
            //    int iRow = dgvAPSupport.CurrentCell.RowIndex;
            //    int iColumnPromo = dgvMarketPromo.CurrentCell.ColumnIndex;
            //    if (iColumn == dgvAPSupport.Columns.Count - 1)
            //    {
            //        if (iRow + 1 >= dgvAPSupport.Rows.Count)
            //        {
            //            DataTable dt = dgvAPSupport.DataSource as DataTable;
            //            DataRow newRow = dt.NewRow();
            //            dt.Rows.Add(newRow);
            //            this.dgvAPSupport.DataSource = dt;
            //            dgvAPSupport[0, iRow + 1].Selected = true;
            //        }
            //        else
            //        {
            //            dgvAPSupport.CurrentCell = dgvAPSupport[0, iRow + 1];
            //        }
            //    }
            //    else
            //    {
            //        dgvAPSupport.CurrentCell = dgvAPSupport[dgvAPSupport.CurrentCell.ColumnIndex + 1, dgvAPSupport.CurrentCell.RowIndex];
            //    }
            //    return true;
            //}
            //else if (keyData == Keys.Delete)
            //{
            //    if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        foreach (DataGridViewRow item in this.dgvAPSupport.SelectedRows)
            //        {
            //            dgvAPSupport.Rows.RemoveAt(item.Index);
            //        }
            //        Save();
            //        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
            //    }
            //    return true;
            //}
            //return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void dgvMarketPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //    dgvMarketingPlan.BeginEdit(true);
                // e.SuppressKeyPress = true;
                int iColumn = dgvMarketPromo.CurrentCell.ColumnIndex;
                int iRow = dgvMarketPromo.CurrentCell.RowIndex;
              //  int iColumnPromo = dgvMarketPromo.CurrentCell.ColumnIndex;
                if (iColumn == dgvMarketPromo.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvMarketPromo.Rows.Count)
                    {
                        DataTable dt = dgvMarketPromo.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvMarketPromo.DataSource = dt;
                        dgvMarketPromo[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvMarketPromo.CurrentCell = dgvMarketPromo[0, iRow + 1];
                    }
                }
                else
                {
                    dgvMarketPromo.CurrentCell = dgvMarketPromo[dgvMarketPromo.CurrentCell.ColumnIndex + 1, dgvMarketPromo.CurrentCell.RowIndex];
                }
                
            }
           
        }

        private void dgvAPSupport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //    dgvMarketingPlan.BeginEdit(true);
                // e.SuppressKeyPress = true;
                int iColumn = dgvAPSupport.CurrentCell.ColumnIndex;
                int iRow = dgvAPSupport.CurrentCell.RowIndex;
                int iColumnPromo = dgvMarketPromo.CurrentCell.ColumnIndex;
                if (iColumn == dgvAPSupport.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvAPSupport.Rows.Count)
                    {
                        DataTable dt = dgvAPSupport.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvAPSupport.DataSource = dt;
                        dgvAPSupport[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvAPSupport.CurrentCell = dgvAPSupport[0, iRow + 1];
                    }
                }
                else
                {
                  //  dgvAPSupport.CurrentCell = dgvAPSupport[dgvAPSupport.CurrentCell.ColumnIndex + 1, dgvAPSupport.CurrentCell.RowIndex];
                }
               
            }
            else if (e.KeyChar == '\n')
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvAPSupport.SelectedRows)
                    {
                        dgvAPSupport.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }           
        }

        private void dgvAPSupport_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvMarketPromo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
              
    }
}
