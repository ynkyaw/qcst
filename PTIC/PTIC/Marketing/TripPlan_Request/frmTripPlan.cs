using System;
using PTIC.Common;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Marketing.DailyMarketing;
using PTIC.Common.BL;
using PTIC.Util;
using PTIC.Sale.BL;
using PTIC.VC.Marketing.MarketingPlan;
using PTIC.Marketing.TripPlan_Request;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmTripPlan : Form
    {

        /// <summary>
        /// Logger for frmTripPlan
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTripPlan));

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TripPlanSaveHandler(object sender, TripPlanSaveEventArgs e);

        public event TripPlanSaveHandler TripPlanSavedHandler;

        /// <summary>
        /// 
        /// </summary>
        //private frmTripPlan _frmTripPlan = null;

        DataTable transportTbl = null;
        DataTable venTbl = null;
        DataTable tripTbl = null;
        DataTable salesPersonTbl = null;

        /// <summary>
        /// Trip Plan to be modified
        /// </summary>
        private TripPlan _tripPlan = null;

        //private int selectedTripPlanID = 0;
        private DateTime selectedStartDate = DateTime.Now;
        //private double selectedTotalDays = 0;

        Nullable<bool> isSales = null;

        bool requestFlag = false;

        //  EditFlag 
        bool EditFlag = false;

        public frmTripPlan()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvTripPlanDetail.AutoGenerateColumns = false;
            //Set Default values
            set_default();
            // Load necessary data
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvTripPlanDetail);

            DateTime StartDate = (DateTime)DataTypeParser.Parse(clnFromDate, typeof(DateTime), DateTime.Now);
            // dgvTripPlanDetail.Columns[clnFromDate.Index]
            AddingTripTargetColumns();
            

        }

        private void AddingTripTargetColumns() 
        {
            DataTable brandList = new BrandBL().GetAll();
            foreach (DataRow dr in brandList.Rows)
            {
                DataGridViewTextBoxColumn colTargetedBrand = new DataGridViewTextBoxColumn();
                colTargetedBrand.Name="col" + dr["BrandName"];
                colTargetedBrand.HeaderText = dr["BrandName"] + string.Empty;
                colTargetedBrand.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colTargetedBrand.DefaultCellStyle.NullValue = "-";
                dgvTripPlanDetail.Columns.Add(colTargetedBrand);

            }
        
        }

        public frmTripPlan(TripPlan tripPlan)
            : this()
        {
            LoadNBindTripPlanAndDetails(tripPlan);
           
        }

        public frmTripPlan(DateTime start, DateTime end, bool isSale)
            : this()
        {
            requestFlag = true;
            butSave.Enabled = false;
            butDelete.Enabled = false;
            btnNew.Enabled = false;

            ///
            colTripPlanTargetOpen.Visible = false;
            this.isSales= isSale;

            LoadNBindTripPlanAndDetails(start, end, isSale);
            dgvTripPlanDetail.Columns[clnTripPlanNo.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clntranportTypeID.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clnVenID.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clnTripID.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clnFromDate.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clnToDate.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clnManagerID.Index].ReadOnly = true;
            dgvTripPlanDetail.Columns[clnRemark.Index].ReadOnly = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void frmTripPlan_Load(object sender, EventArgs e)
        {
            dgvTripPlanDetail.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;

            LoadTripTarget();
            

        


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != dgvColBtn.Index && e.ColumnIndex != colTripPlanTargetOpen.Index))
                return;

            int? selectedTripPlanDetailID =
                (int?)DataTypeParser.Parse(dgvTripPlanDetail.Rows[e.RowIndex].Cells[clnTripPlanDetailID.Index].Value, typeof(int), null);
            if (!selectedTripPlanDetailID.HasValue)
            {
                ToastMessageBox.Show("ခရီးစဉ် Plan ကို သိမ်းပါ။", Color.Red);
                return;
            }
            if (dgvTripPlanDetail.CurrentCell.ColumnIndex == dgvTripPlanDetail.CurrentRow.Cells["dgvColBtn"].ColumnIndex
                && dgvTripPlanDetail.CurrentRow.Cells["clnTripPlanDetailID"].Value.ToString() != "")
            {
                // Get an trip plan detail
                DataGridViewRow selectedRow = dgvTripPlanDetail.CurrentRow;
                TripPlanDetail mTripPlanDetail = new TripPlanDetail()
                {
                    ID = (int)DataTypeParser.Parse(selectedRow.Cells["clnTripPlanDetailID"].Value, typeof(int), -1),
                    TripPlanID = selectedTripPlanDetailID.Value
                    //ID = (int)DataTypeParser.Parse(selectedRow.Cells["clnTripPlanID"].Value, typeof(int), -1)
                    //TripPlanName = selectedRow.Cells["clnTripPlanName"].Value.ToString(),
                    //FromDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["clnFromDate"].Value, typeof(DateTime), DateTime.Now),
                    //ToDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["clnToDate"].Value, typeof(DateTime), DateTime.Now)
                };

                if (_tripPlan == null)
                {
                    TripPlan tripPlan = new TripPlan()
                    {
                        TripPlanName = (string)DataTypeParser.Parse(selectedRow.Cells[colTripPlanName.Index].Value, typeof(string), string.Empty),
                        ID = (int)DataTypeParser.Parse(selectedRow.Cells[colTripPlanID.Index].Value, typeof(int), -1)
                    };
                    this._tripPlan = tripPlan;
                }
                else if (_tripPlan.ID == 0) 
                {
                    _tripPlan.ID = (int)DataTypeParser.Parse(selectedRow.Cells[colTripPlanID.Index].Value, typeof(int), -1);
                }

                frmTripDetailPlan frm = new frmTripDetailPlan(_tripPlan, mTripPlanDetail, requestFlag);
                // TODO: set call back handler for frmTripDetailPlan
                UIManager.OpenForm(frm);
            }
            else if (e.ColumnIndex == colTripPlanTargetOpen.Index && requestFlag == false)
            {
                // Open trip plan target form
                frmTripPlanTarget frm = new frmTripPlanTarget(
                    new TripPlanDetail()
                    {
                        ID = selectedTripPlanDetailID.Value
                    });
                // Set call back handler for frmTripPlanTarget
                frm.TripPlanTargetSavedHandler += new frmTripPlanTarget.TripPlanTargetSaveHandler(form_TripPlanTargetSaved_CallBack);
                UIManager.OpenForm(frm);
            }
        }

        private void form_TripPlanTargetSaved_CallBack(object sender, PTIC.Marketing.TripPlan_Request.frmTripPlanTarget.TripPlanTargetEventArgs e)
        {
            // Reload data if occured changes
            if (e.OccuredChanges)
            {
                LoadNBindTripPlanDetails(this._tripPlan.ID);
                DataUtil.AddInitialNewRow(dgvTripPlanDetail);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTripRequestList frm = new frmTripRequestList();
        }

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void LoadNBind()
        {
            DataTable dtEmployeesByDept = null;
            try
            {
                transportTbl = new TransportTypeBL().GetAll();
                clntranportTypeID.DataSource = transportTbl;
                clntranportTypeID.ValueMember = "TransportTypeID";
                clntranportTypeID.DisplayMember = "TransportTypeName";

                venTbl = new VehicleBL().GetAll();
                clnVenID.DataSource = venTbl;
                clnVenID.ValueMember = "VehicleID";
                clnVenID.DisplayMember = "VenNo";

                tripTbl = new TripBL().GetAll();
                clnTripID.DataSource = tripTbl;
                clnTripID.ValueMember = "TripID";
                clnTripID.DisplayMember = "TripName";

                salesPersonTbl = new EmployeeBL().GetAll();
                if (Program.Module.Marketing == Program.module)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(salesPersonTbl, "DeptID", 8);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(salesPersonTbl, "DeptID", 7);
                }
                // clnManagerID.DataSource = salesPersonTbl;
                clnManagerID.DataSource = dtEmployeesByDept;
                clnManagerID.ValueMember = "EmployeeID";
                clnManagerID.DisplayMember = "EmpName";

                DataTable dtTripPlanDetailTbl = new DataTable();
                dtTripPlanDetailTbl = new TripPlanDetailBL().GetAll();

                if (dtTripPlanDetailTbl == null) return;
                dtTripPlanDetailTbl.Rows.Clear();
                dgvTripPlanDetail.DataSource = dtTripPlanDetailTbl;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void set_default()
        {
            dtFromDate.Value = DateTime.Now;
            //Add 3 Month 
            dtToDate.Value = dtFromDate.Value.AddMonths(2);
            txtTripPlanName.Text = String.Format("{0:MMM yyyy}", dtFromDate.Value) + " - " + String.Format("{0:MMM yyyy}", dtToDate.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteTripPlan(int tripPlanID)
        {
            try
            {
                // delete an order detail
                int affectedRows = new TripPlanBL().DeleteByTripPlanID(tripPlanID);
                if (affectedRows > 0)
                {
                    dgvTripPlanDetail.Rows.RemoveAt(dgvTripPlanDetail.CurrentRow.Index);
                    if (dgvTripPlanDetail.RowCount == 0)
                    {
                        DataTable TripPlanDetailTbl = dgvTripPlanDetail.DataSource as DataTable;
                        DataRow newRow = TripPlanDetailTbl.NewRow();
                        TripPlanDetailTbl.Rows.Add(newRow);
                        dgvTripPlanDetail.DataSource = TripPlanDetailTbl;
                    }
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteTripPlanDetail(int tripPlanDetailID)
        {
            try
            {
                // delete an order detail
                int affectedRows = new TripPlanDetailBL().DeleteByTripPlanDetailID(tripPlanDetailID);
                if (affectedRows > 0)
                {
                    dgvTripPlanDetail.Rows.RemoveAt(dgvTripPlanDetail.CurrentRow.Index);
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNBindTripPlanAndDetails(DateTime start, DateTime end, bool IsSale)
        {
            // Set an existing trip plan to be modified
            //this._tripPlan = tripPlan;
            // Load trip plan
            // txtTripPlanName.Text = tripPlan.TripPlanName;
            //txtTripPlanNo.Text = tripPlan.TripPlanNo;
            
            dtFromDate.Value =GetFirstDate(start);
            dtToDate.Value = GetLastDate(end);

            // Load trip Plan details
            LoadNBindTripPlanDetails(start, end, IsSale);
            // see an order in edit mode
            //.Text = ">   Order [ Edit ]";
        }

        private void LoadNBindTripPlanAndDetails(TripPlan tripPlan)
        {
            // Set an existing trip plan to be modified
            this._tripPlan = tripPlan;
            // Load trip plan
            txtTripPlanName.Text = tripPlan.TripPlanName;
            txtTripPlanNo.Text = tripPlan.TripPlanNo;
            dtFromDate.Value = tripPlan.FromDate;
            dtToDate.Value = tripPlan.ToDate;

            // Load trip Plan details
            LoadNBindTripPlanDetails(this._tripPlan.ID);
            // see an order in edit mode
            //.Text = ">   Order [ Edit ]";
        }


        private void LoadNBindTripPlanDetails(int tirpPlanID)
        {
            SqlConnection conn = null;
            try
            {
                dgvTripPlanDetail.AutoGenerateColumns = false;
                conn = DBManager.GetInstance().GetDbConnection();
                using (DataTable tblTripPanelDetails = new TripPlanDetailBL().GetByTripPlanID(tirpPlanID, conn))
                {
                    dgvTripPlanDetail.DataSource = tblTripPanelDetails;
                }
                DataUtil.AddInitialNewRow(dgvTripPlanDetail);
                clnTripPlanDetailID.Visible = false;
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            LoadTripTarget();

          
        }


        private void LoadTripTarget() 
        {
            foreach (DataGridViewRow dgvRw in dgvTripPlanDetail.Rows)
            {
                string tripPlanDtlId = dgvRw.Cells[clnTripPlanDetailID.Index].Value + string.Empty;
                if (!string.IsNullOrEmpty(tripPlanDtlId))
                {
                    DataTable tripPlanTargetTbl = new TripPlanBL().GetTripPlanTargetedBrand_Amount_By_TripDtlId(tripPlanDtlId);
                    foreach (DataRow dr in tripPlanTargetTbl.Rows)
                    {
                        string colBrand = "col" + dr["BrandName"];
                        if (dgvTripPlanDetail.Columns.Contains(colBrand))
                        {
                            dgvRw.Cells[colBrand].Value = dr["TargetAmount"];
                        }

                    }

                }
            }
        
        }

        private void LoadNBindTripPlanDetails(DateTime start, DateTime end, bool isSale)
        {
            SqlConnection conn = null;
            try
            {
                dgvTripPlanDetail.AutoGenerateColumns = false;
                conn = DBManager.GetInstance().GetDbConnection();
                using (DataTable tblTripPanelDetails = new TripPlanDetailBL().GetByDateRange(GetFirstDate(start),GetLastDate(end), isSale))
                {
                    dgvTripPlanDetail.DataSource = tblTripPanelDetails;
                }
                DataUtil.AddInitialNewRow(dgvTripPlanDetail);
                clnTripPlanDetailID.Visible = false;
                LoadTripTarget();
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        private void butSave_Click(object sender, EventArgs e)
        {
            Save();
            EditFlag = false;

            //LoadNBindTripPlanAndDetails(_tripPlan);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {
            TripPlanBL tripPlanSaver = null;
            TripPlan tripPlan = null;
            //TripPlanBL tripPlanBL = null;
            TripPlanDetailBL tripPlanDetailBL = null;
            try
            {
                DataTable dt = dgvTripPlanDetail.DataSource as DataTable;

                if (dt == null) return;

                tripPlanSaver = new TripPlanBL();
                //tripPlanBL = new TripPlanBL();
                tripPlanDetailBL = new TripPlanDetailBL();

                tripPlan = new TripPlan()
                {
                    // Trip Plan ID
                    TripPlanNo = txtTripPlanNo.Text,
                    TranDate = DateTime.Now,
                    TripPlanName = txtTripPlanName.Text,
                    FromDate = (DateTime)dtFromDate.Value,
                    ToDate = (DateTime)dtToDate.Value,
                    IsSale = GlobalCache.is_sale
                };

                List<TripPlanDetail> insertTripPlanDetails = new List<TripPlanDetail>();
                List<TripPlanDetail> updateTripPlanDetails = new List<TripPlanDetail>();
                List<TripPlanDetail> deletTripPlanDetails = new List<TripPlanDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    string FromDate = (string)DataTypeParser.Parse(row["FromDate"].ToString(), typeof(string), String.Empty);
                    string ToDate = (string)DataTypeParser.Parse(row["ToDate"].ToString(), typeof(string), String.Empty);
                    TripPlanDetail tripPlanDetail = new TripPlanDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["TripPlanDetailID"].ToString(), typeof(int), -1),
                        TripPlanID = (int)DataTypeParser.Parse(row["TripPlanID"].ToString(), typeof(int), -1),
                        ManagerID = (int)DataTypeParser.Parse(row["ManagerID"].ToString(), typeof(int), -1),
                        SalesPersonID = (int)DataTypeParser.Parse(row["ManagerID"].ToString(), typeof(int), -1),
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"].ToString(), typeof(int), -1),
                        VenID = (int?)DataTypeParser.Parse(row["VenID"].ToString(), typeof(int), null),
                        TripPlanNo = (string)DataTypeParser.Parse(row["TripPlanNo"].ToString(), typeof(string), string.Empty),
                        //TripName = row["TripName"].ToString().ToString(),
                        TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1),
                        TranDate = DateTime.Now,
                        FromDate = (DateTime)DataTypeParser.Parse(row["FromDate"].ToString(), typeof(DateTime), string.Empty),
                        ToDate = (DateTime)DataTypeParser.Parse(row["ToDate"].ToString(), typeof(DateTime), string.Empty),
                        //PrevTripName =  row.Cells["clnPrevTripName"].ToString(),
                        PrevTripName = "",
                        Accessories = "",
                        Rent = 0,
                        Food = 0,
                        Transport = 0,
                        Communication = 0,
                        OtherExp = 0,
                        Remittance = 0,
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };

                    insertTripPlanDetails.Add(tripPlanDetail);                    
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    TripPlanDetail tripPlanDetail = new TripPlanDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["TripPlanDetailID"].ToString(), typeof(int), -1),
                        TripPlanID = (int)DataTypeParser.Parse(row["TripPlanID"].ToString(), typeof(int), -1),
                        ManagerID = (int)DataTypeParser.Parse(row["ManagerID"].ToString(), typeof(int), -1),
                        SalesPersonID = (int)DataTypeParser.Parse(row["ManagerID"].ToString(), typeof(int), -1),
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"].ToString(), typeof(int), -1),
                        VenID = (int?)DataTypeParser.Parse(row["VenID"].ToString(), typeof(int), null),
                        TripPlanNo = (string)DataTypeParser.Parse(row["TripPlanNo"].ToString(), typeof(string), string.Empty),
                        //TripName = row["TripName"].ToString().ToString(),
                        TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1),
                        TranDate = DateTime.Now,
                        FromDate = (DateTime)DataTypeParser.Parse(row["FromDate"].ToString(), typeof(DateTime), DateTime.Now),
                        ToDate = (DateTime)DataTypeParser.Parse(row["ToDate"].ToString(), typeof(DateTime), DateTime.Now),
                        //PrevTripName =  row.Cells["clnPrevTripName"].ToString(),
                        PrevTripName = "",
                        Accessories = "",
                        Rent = 0,
                        Food = 0,
                        Transport = 0,
                        Communication = 0,
                        OtherExp = 0,
                        Remittance = 0,
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };
                    deletTripPlanDetails.Add(tripPlanDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    string FromDate = (string)DataTypeParser.Parse(row["FromDate"].ToString(), typeof(string), String.Empty);
                    string ToDate = (string)DataTypeParser.Parse(row["ToDate"].ToString(), typeof(string), String.Empty);
                    TripPlanDetail tripPlanDetail = new TripPlanDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["TripPlanDetailID"].ToString(), typeof(int), -1),
                        TripPlanID = (int)DataTypeParser.Parse(row["TripPlanID"].ToString(), typeof(int), -1),
                        ManagerID = (int)DataTypeParser.Parse(row["ManagerID"].ToString(), typeof(int), -1),
                        SalesPersonID = (int)DataTypeParser.Parse(row["ManagerID"].ToString(), typeof(int), -1),
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"].ToString(), typeof(int), -1),
                        VenID = (int?)DataTypeParser.Parse(row["VenID"].ToString(), typeof(int), null),
                        TripPlanNo = (string)DataTypeParser.Parse(row["TripPlanNo"].ToString(), typeof(string), string.Empty),
                        //TripName = row["TripName"].ToString().ToString(),
                        TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1),
                        TranDate = DateTime.Now,
                        FromDate = (DateTime)DataTypeParser.Parse(row["FromDate"].ToString(), typeof(DateTime), -1),
                        ToDate = (DateTime)DataTypeParser.Parse(row["ToDate"].ToString(), typeof(DateTime), -1),
                        //PrevTripName =  row.Cells["clnPrevTripName"].ToString(),
                        PrevTripName = "",
                        Accessories = "",
                        Rent = 0,
                        Food = 0,
                        Transport = 0,
                        Communication = 0,
                        OtherExp = 0,
                        Remittance = 0,
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), string.Empty)
                    };
                    if (tripPlanDetail.ManagerID != -1 && tripPlanDetail.TransportTypeID != -1 && tripPlanDetail.SalesPersonID != -1 && tripPlanDetail.TripID != -1 && FromDate != String.Empty && ToDate != String.Empty)
                    {
                        updateTripPlanDetails.Add(tripPlanDetail);
                    }
                }

                int affectedRows = 0;
                if (_tripPlan == null) // Add new 
                {
                    // Add into db
                    int insertedId = 0;
                    affectedRows = tripPlanSaver.Add(tripPlan, insertTripPlanDetails,out insertedId);

                    _tripPlan = tripPlan;
                    _tripPlan.ID = insertedId;
                    // Check field validation failed or not
                    if (!tripPlanSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(tripPlanSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else // Successful validation
                    {
                        // Success in db also
                        if (affectedRows > 0)
                        {
                            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                            //this.Close();
                        }
                        else
                            ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                    }
                }
                else // Update an existing
                {
                    // Update order by order ID
                    tripPlan.ID = _tripPlan.ID;
                    
                    if (insertTripPlanDetails.Count > 0)
                    {
                        affectedRows = tripPlanSaver.Update(tripPlan, insertTripPlanDetails);
                        // Check field validation failed or not
                        if (!tripPlanSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(tripPlanSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (deletTripPlanDetails.Count > 0)
                    {
                        affectedRows = tripPlanDetailBL.Delete(deletTripPlanDetails);
                        // Check field validation failed or not
                        if (!tripPlanDetailBL.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(tripPlanDetailBL.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (updateTripPlanDetails.Count > 0)
                    {
                        affectedRows = tripPlanDetailBL.Update(updateTripPlanDetails);
                        // Check field validation failed or not
                        if (!tripPlanDetailBL.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(tripPlanDetailBL.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    affectedRows = tripPlanSaver.UpdateByID(tripPlan);
                    // Check field validation failed or not
                    if (!tripPlanSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(tripPlanSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                } // END OF existing
                if (affectedRows > 0)
                {
                    TripPlanSaveEventArgs args = new TripPlanSaveEventArgs(true);
                    TripPlanSavedHandler(this, args);
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBindTripPlanAndDetails(_tripPlan);
                    //this.Close();
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, 
                    this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(e);
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (dgvTripPlanDetail.CurrentRow.IsNewRow || dgvTripPlanDetail.SelectedRows.Count < 1)
            {
                MessageBox.Show(Resource.errSelectRowToDelete, this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            DataGridViewRow selectedRow = dgvTripPlanDetail.CurrentRow;
            if (selectedRow != null && (selectedRow.DataBoundItem as DataRowView).Row.RowState == DataRowState.Added)
            {
                // Delete row just from GridView because it is a new row that has not been in Database
                dgvTripPlanDetail.Rows.RemoveAt(selectedRow.Index);
                // Add initial new row because there is no more row
                DataUtil.AddInitialNewRow(dgvTripPlanDetail);
                return;
            }
            int detailID = (int)DataTypeParser.Parse(selectedRow.Cells[clnTripPlanDetailID.Index].Value, typeof(int), -1);
            // Delete a selected TripPlanDetail                
            DeleteTripPlanDetail(detailID);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvTripPlanDetail.CurrentCell.ColumnIndex;
                int iRow = dgvTripPlanDetail.CurrentCell.RowIndex;
                if (iColumn == dgvTripPlanDetail.Columns["clnRemark"].Index)
                {
                    if (iRow + 1 >= dgvTripPlanDetail.Rows.Count)
                    {
                        if (dgvTripPlanDetail.CurrentRow.ErrorText == String.Empty)
                        {
                            DataUtil.AddNewRow(dgvTripPlanDetail.DataSource as DataTable);
                            dgvTripPlanDetail[0, iRow + 1].Selected = true;                      
                        }
                    }
                    else
                    {
                        dgvTripPlanDetail.CurrentCell = dgvTripPlanDetail[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvTripPlanDetail.CurrentCell = dgvTripPlanDetail[dgvTripPlanDetail.CurrentCell.ColumnIndex + 1, dgvTripPlanDetail.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvTripPlanDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    if ((int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[colTripPlanID.Index].Value, typeof(int), -1) != -1)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                    }
                }
            }
        }


        private DateTime GetFirstDate(DateTime dt) 
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        private DateTime GetLastDate(DateTime dt)
        {
            int lastDay=GetFirstDate(dt.AddMonths(1)).AddDays(-1).Day;
            return new DateTime(dt.Year, dt.Month, lastDay);
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtFromDate.Value.CompareTo(dtToDate.Value) > 0)
            {
                dtToDate.Value = dtFromDate.Value;

            }
            else {
                
                    LoadNBindTripPlanAndDetails(dtFromDate.Value, dtToDate.Value, Program.module==Program.Module.Sale);
            
            }
            dtToDate.MinDate = dtFromDate.Value;
            

        }

        /// <summary>
        /// Change Grid Cell Value Aluto
        /// When user Choose Township & Start Date , Will set End Date Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvTripPlanDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];

            //If user choose Transport type
            if (curColumName.Equals("clntranportTypeID") || curColumName.Equals("clnVenID"))
            {
                //get transport type id
                int selectedTransportTypeID = (int)DataTypeParser.Parse(curRow.Cells["clntranportTypeID"].Value, typeof(int), -1);
                if (selectedTransportTypeID == -1) // NO need to get and set
                    return;

                //5 - Sales Car
                //Other ID - Other Vehicles
                DataGridViewComboBoxCell curCell = dgvTripPlanDetail.CurrentRow.Cells["clnVenID"] as DataGridViewComboBoxCell;

                if (selectedTransportTypeID == 5)
                {
                    curCell.DataSource = venTbl;
                    curCell.DisplayMember = "VenNo";
                    curCell.ValueMember = "VehicleID";
                    dgvTripPlanDetail.CurrentRow.Cells["clnVenID"].ReadOnly = false;
                }
                else
                {
                    var combobox = (DataGridViewComboBoxCell)dgvTripPlanDetail.CurrentRow.Cells["clnVenID"];
                    combobox.DataSource = null;
                    combobox.Items.Clear();
                    combobox.ValueType = typeof(string);

                    dgvTripPlanDetail.CurrentRow.Cells["clnVenID"].Value = DBNull.Value;
                    dgvTripPlanDetail.CurrentRow.Cells["clnVenID"].ReadOnly = true;
                }
            }

           
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            if (isSales.HasValue)
                LoadNBindTripPlanAndDetails(dtFromDate.Value, dtToDate.Value, isSales.Value);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvTripPlanDetail.DataSource as DataTable);
            dgvTripPlanDetail.CurrentCell = dgvTripPlanDetail.Rows[dgvTripPlanDetail.RowCount - 1].Cells["clnTripPlanNo"];
            dgvTripPlanDetail.CurrentRow.ReadOnly = false;
        }

        #region Inner Class
        public class TripPlanSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;

            public TripPlanSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        private void dgvTripPlanDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
         
        }

        private void lblSalePage_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmTripPlanList));
        }

        private void dgvTripPlanDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvTripPlanDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvTripPlanDetail.CurrentRow == null)
            //    return;
            //DateTime StartDate = (DateTime)DataTypeParser.Parse(dgvTripPlanDetail.CurrentRow.Cells[clnFromDate.Index].Value, typeof(DateTime), DateTime.Now);
            //if ((StartDate < dtFromDate.Value || StartDate > dtToDate.Value) && e.ColumnIndex == dgvTripPlanDetail.CurrentRow.Cells["clnFromDate"].ColumnIndex)
            //{
            //    MessageBox.Show("သွားမည့်ရက် သည် သတ်မှတ်ရက်များအတွင်း၌သာရှိရမည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dgvTripPlanDetail.CurrentRow.Cells[clnFromDate.Index].Value = dtFromDate.Value;
            //    return;
            //}

            //if (dgvTripPlanDetail.Rows[e.RowIndex].ErrorText == "Error3")
            //{
            //    dgvTripPlanDetail.CurrentRow.Cells[clnVenID.Index].Value = 0;
            //    dgvTripPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            //}
            //else if (dgvTripPlanDetail.Rows[e.RowIndex].ErrorText == "Error2")
            //{
            //    dgvTripPlanDetail.CurrentRow.Cells[clnManagerID.Index].Value = 0;
            //    dgvTripPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            //}
            //else if (dgvTripPlanDetail.Rows[e.RowIndex].ErrorText == "Error1")
            //{
            //    dgvTripPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            //}
            //else
            //{
            //    dgvTripPlanDetail.Rows[e.RowIndex].ErrorText = String.Empty;
            //}
        }

        private void dgvTripPlanDetail_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (EditFlag == false)
            {
                var dgv = dgvTripPlanDetail as DataGridView;
                dgv.CurrentRow.ReadOnly = false;
                int selectedTransportTypeID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells["clntranportTypeID"].Value, typeof(int), -1);

                //5 - Sales Car
                //Other ID - Other Vehicles

                if (selectedTransportTypeID != 5)
                {
                    dgvTripPlanDetail.CurrentRow.Cells["clnVenID"].ReadOnly = true;
                    //curCell.DataSource = venTbl;
                    //curCell.DisplayMember = "VenNo";
                    //curCell.ValueMember = "VehicleID";
                    //dgvTripPlanDetail.CurrentRow.Cells["clnVenID"].ReadOnly = false;
                }
                else
                {
                    dgvTripPlanDetail.CurrentRow.Cells["clnVenID"].ReadOnly = false;
                }
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<string> invColList = new List<string>() {"colTripPlanID","colTripPlanTargetID", "colTripPlanName", "clnTripName", "clnTripPlanDetailID" };
            if (requestFlag)
                invColList.Add("colTripPlanTargetOpen");
            frmTripPlanViewSetting frmSetting = new frmTripPlanViewSetting(dgvTripPlanDetail,invColList);
            frmSetting.ShowDialog();
        }

       
    }
}
