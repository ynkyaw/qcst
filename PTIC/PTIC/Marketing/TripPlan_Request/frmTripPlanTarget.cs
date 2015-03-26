/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/25 (yyyy/MM/dd)
 * Description: Trip plan target form
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Common;
using PTIC.Util;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.VC.Validation;

namespace PTIC.Marketing.TripPlan_Request
{
    /// <summary>
    /// Trip plan target form
    /// </summary>
    public partial class frmTripPlanTarget : Form
    {
        /// <summary>
        /// Logger for frmTripPlanTarget
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTripPlanTarget));

        private TripPlanDetail _tripPlanDetail;

        private bool _occuredChanges = false;

        public delegate void TripPlanTargetSaveHandler(object sender, TripPlanTargetEventArgs e);

        public event TripPlanTargetSaveHandler TripPlanTargetSavedHandler;

        TextBox _txtAmt = null;

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save()) // is successful
                this.Close();
        }

        private void frmTripPlanTarget_FormClosed(object sender, FormClosedEventArgs e)
        {
            TripPlanTargetEventArgs eArg = new TripPlanTargetEventArgs(this._occuredChanges);
            TripPlanTargetSavedHandler(this, eArg);
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTripPlan));
            this.Close();
        }

        private void dgvTripPlanTarget_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvTripPlanTarget_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (e.ColumnIndex == colBrand.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex && !row.IsNewRow)
                    {
                        if (row.Cells[colBrand.Index].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "")
                            return;
                        if (row.Cells[colBrand.Index].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate not Allowed!");
                            return;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }

        }

        private void dgvTripPlanTarget_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv == null)
                return;

            if (e.ColumnIndex == colBrand.Index && gv.Rows[e.RowIndex].ErrorText != String.Empty)
            {
                gv.CurrentRow.Cells[colBrand.Index].Value = -1;
                gv.CurrentRow.Cells[colTargetAmt.Index].Value = 0;
                gv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }
        #endregion

        #region Private Methods
        private void LoadNBindByTripPlanDetailID(int tripPlanDetailID)
        {
            this.dgvTripPlanTarget.DataSource = new TripPlanTargetBL().GetByTripPlanDetailID(tripPlanDetailID);
        }

        private void LoadNBindNecessaryData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                colBrand.DataSource = new BrandBL().GetAll();
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

        private bool Save()
        {
            DataTable dt = this.dgvTripPlanTarget.DataSource as DataTable;
            if (dt == null || dt.Rows.Count < 1)
                return false;
            TripPlanTargetBL targetSaver = null;
            bool isSuccessful = false;
            try
            {
                targetSaver = new TripPlanTargetBL();
                // New rows
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                List<TripPlanTarget> targets = new List<TripPlanTarget>();
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    targets.Add(new TripPlanTarget()
                    {
                        // TODO: skip brand id with -1
                        BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        TargetAmount = (decimal)DataTypeParser.Parse(row["TargetAmount"], typeof(decimal), 0)
                    });
                }
                if(targets.Count > 0)
                {
                    targetSaver.Add(this._tripPlanDetail, targets);
                    isSuccessful = true;
                    _occuredChanges = true;
                    // Clear trip plan targets
                    targets.Clear();
                }
                
                // TODO: Update modified rows in TripPlanTarget
                // Modified rows
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                List<TripPlanTarget> updatedTargets = new List<TripPlanTarget>();
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    updatedTargets.Add(new TripPlanTarget()
                    {
                        // TODO: skip brand id with -1
                        ID = (int)DataTypeParser.Parse(row["ID"],typeof(int),-1),
                        BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        TargetAmount = (decimal)DataTypeParser.Parse(row["TargetAmount"], typeof(decimal), 0)
                    });
                }
                if (updatedTargets.Count > 0)
                {
                    targetSaver.Update(this._tripPlanDetail, updatedTargets);
                    isSuccessful = true;
                    _occuredChanges = true;
                    // Clear trip plan targets
                    targets.Clear();
                }

                // TODO: Delete rows in TripPlanTarget
                // Deleted rows
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                List<TripPlanTarget> deletedTargets = new List<TripPlanTarget>();
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    deletedTargets.Add(new TripPlanTarget()
                    {
                        // TODO: skip brand id with -1
                        ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1)
                       
                    });
                }
                if (deletedTargets.Count > 0)
                {
                    targetSaver.Delete(this._tripPlanDetail, deletedTargets);
                    isSuccessful = true;
                    _occuredChanges = true;
                    // Clear trip plan targets
                    targets.Clear();
                }
            }
            catch (Exception e)
            {
                isSuccessful = false;
                throw;
            }
            return isSuccessful;
        }

        private DataTable GetTargetTableSchema()
        {
            DataTable dt = new DataTable();
            DataColumn cID = new DataColumn("ID", typeof(int));
            DataColumn cBrandID = new DataColumn("BrandID", typeof(int));
            DataColumn cTargetAmount = new DataColumn("TargetAmount", typeof(decimal));
            dt.Columns.AddRange(new DataColumn[] { cID, cBrandID, cTargetAmount });

            return dt;
        }
        #endregion

        #region Constructors
        public frmTripPlanTarget()
        {
            InitializeComponent();            
            this.dgvTripPlanTarget.AutoGenerateColumns = false;
            colBrand.DisplayMember = "BrandName";
            colBrand.ValueMember = "BrandID";
            this.dgvTripPlanTarget.DataSource = GetTargetTableSchema();
            DataUtil.AddInitialNewRow(this.dgvTripPlanTarget);
            // Land and bind necessary data
            LoadNBindNecessaryData();
            // Configure logger
            XmlConfigurator.Configure();
        }

        public frmTripPlanTarget(TripPlanDetail tripPlanDetail)
            : this()
        {
            this._tripPlanDetail = tripPlanDetail;
            LoadNBindByTripPlanDetailID(this._tripPlanDetail.ID);
        }
        #endregion

        #region Inner Class
        public class TripPlanTargetEventArgs : EventArgs
        {
            private bool _occuredChanges;
            public TripPlanTargetEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        private void dgvTripPlanTarget_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
            
            _txtAmt = e.Control as TextBox;
            if (dgvTripPlanTarget.CurrentCell.ColumnIndex == 2)
            {
                _txtAmt.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }

        private void dgvTripPlanTarget_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_txtAmt != null)
            {
                _txtAmt.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTripPlanTarget.SelectedRows.Count == 1)
            {
                if(!dgvTripPlanTarget.SelectedRows[0].IsNewRow)
                    dgvTripPlanTarget.Rows.Remove(dgvTripPlanTarget.SelectedRows[0]);
            }
            else 
            {
                MessageBox.Show("Please select one row to delete");
            }
        }
                               
    }
}
