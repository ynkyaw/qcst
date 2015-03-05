using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC;
using System.Data.SqlClient;
using log4net;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Common.BL;
using PTIC.Sale.BL;
using PTIC.Marketing.MarketingPlan;
using PTIC.Common.Entities;
using PTIC.Util;

namespace PTIC.Marketing.DailyMarketing
{
    public partial class frmTripRequest : Form
    {
        /// <summary>
        /// Logger for frmTripRequest
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTripRequest));

        public bool isSale = false;
        /// <summary>
        /// Product to be modified
        /// </summary>
        private TripRequest _mdTripReqest = null;

        DataTable tripPlanTbl = null;
        DataTable tripTbl = null;
        DataTable tripTbl2 = null;
        DataTable venTbl = null;
        DataTable transportTypeTbl = null;
        DataTable userTbl = null;
        DataTable a_p_Tbl = null;
        DataTable product_Tbl = null;

        private List<Employee> EmployeesList = null;

        public delegate void TripRequestSaveHandler(object sender, TripRequestSaveEventArgs e);
        /// <summary>
        /// 
        /// </summary>
        public event TripRequestSaveHandler TripRequestSavedHandler;


        private void TripRequestSave_CallBack(object sender, frmTripRequest.TripRequestSaveEventArgs e)
        {
            if (e.NeedToReloadTripRequest) { }
            //  LoadNBindData(); // load and bind products
        }

        public frmTripRequest()
        {
            InitializeComponent();

            //Set Default values
            set_default();
            dgvGiftList.AutoGenerateColumns = false;
            LoadNBind();
        }


        //public frmTripRequest(TripRequest mdTripRequest)
        //    : this()
        //{
        //    this._mdTripReqest = mdTripRequest;

        //    // bind data to be modified
        //    BindModifyData();
        //}


        public frmTripRequest(TripRequest mdTripRequest)
            : this()
        {
            this._mdTripReqest = mdTripRequest;
            LoadNBindTripRequestAndDetails(mdTripRequest);
        }

        private void LoadNBindTripRequestAndDetails(TripRequest mdTripRequest)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                using (DataTable tblTripRequestDetails = new TripRequestBL().SelectByTripRequestID(mdTripRequest.ID, conn))
                {
                    //dgvTripPlanDetail.DataSource = tblTripPanelDetails;
                    //Trip Request Data Binding
                    if (tblTripRequestDetails == null) return;
                    cboTripPlanID.SelectedValue = (int)tblTripRequestDetails.Rows[0]["TripPlanID"];
                    //cboTripID.SelectedValue = tblTripRequestDetails.Rows[0]["TripID"].ToString();
                    //   txtTripPlanName.Text = dtTripPlanDetail.Rows[0]["TripPlanName"].ToString();
                    cboManagerID.SelectedValue = (int)tblTripRequestDetails.Rows[0]["ManagerID"];
                    cboStaff1ID.SelectedValue = (int)tblTripRequestDetails.Rows[0]["SalesPersonID"];
                    cboSupportStaffID.SelectedValue = (int)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["SupporterID"], typeof(int), 0);
                    cboTranportTypeID.SelectedValue = (int)tblTripRequestDetails.Rows[0]["TransportTypeID"];
                    cboVenID.SelectedValue = (int)tblTripRequestDetails.Rows[0]["VenID"];
                    dtFromDate.Value = (DateTime)tblTripRequestDetails.Rows[0]["FromDate"];
                    dtToDate.Value = (DateTime)tblTripRequestDetails.Rows[0]["ToDate"];
                    //cboSaleType.Text = tblTripPanelDetails.Rows[0]["SaleType"].ToString();
                    dtTripRequestDate.Value = (DateTime)tblTripRequestDetails.Rows[0]["ReqDate"];
                    udStaffNumber.Text = (string)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["PersonCount"].ToString(), typeof(string), 0);
                    chkCashAccount.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsAcc"].ToString(), typeof(bool), false);
                    chkFactory.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsFac"].ToString(), typeof(bool), false);
                    chkVehicle.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsVen"].ToString(), typeof(bool), false);
                    chkManage.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsAdm"].ToString(), typeof(bool), false);
                    chkCashMachine.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsSaleDevice"].ToString(), typeof(bool), false);
                    chkVoucher.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsVocher"].ToString(), typeof(bool), false);
                    chkSaleMachineInfo.Checked = (bool)DataTypeParser.Parse(tblTripRequestDetails.Rows[0]["IsTab"].ToString(), typeof(bool), false);
                    txtSalesGoal.Text = tblTripRequestDetails.Rows[0]["SalesTargetAmt"].ToString();
                    txtCOO.Text = tblTripRequestDetails.Rows[0]["COORemark"].ToString();
                    txtSM.Text = tblTripRequestDetails.Rows[0]["SaleManagerRemark"].ToString();
                    txtMM.Text = tblTripRequestDetails.Rows[0]["MarketingManagerRemark"].ToString();

                }

                DataTable dtItemList = new DataTable();
                dtItemList = new T_R_Product_BL().GetByTripReqID(mdTripRequest.ID, conn);
                dgvItemList.DataSource = dtItemList;

                DataTable dtGiftList = new DataTable();
                dtGiftList = new T_R_AP_BL().GetByTripReqID(mdTripRequest.ID, conn);
                dgvGiftList.DataSource = dtGiftList;

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



        public void set_default()
        {
            cboTripPlanID.Text = "";
            cboTripID.Text = "";
            udStaffNumber.Text = "1";
            cboManagerID.Text = "";
            cboStaff1ID.Text = "";
            //cboStaff2ID.Text="";
            cboSupportStaffID.Text = "";
            txtSalesGoal.Text = "0";
            dtTripRequestDate.Value = DateTime.Now;
            cboTranportTypeID.Text = "";
            cboVenID.Text = "";
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            txtTotalDays.Text = "";
            cboPrevTripID.Text = "";
            dtPrevTripDate.Value = DateTime.Now;
            chkCashMachine.Checked = true;
            chkVoucher.Checked = false;
            chkVehicle.Checked = true;
            chkCashAccount.Checked = false;
            chkFactory.Checked = false;
            chkManage.Checked = false;
            chkSaleMachineInfo.Checked = false;

        }

        public void LoadNBind()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                transportTypeTbl = new TransportTypeBL().GetAll();
                cboTranportTypeID.DataSource = transportTypeTbl;
                cboTranportTypeID.ValueMember = "TransportTypeID";
                cboTranportTypeID.DisplayMember = "TransportTypeName";

                venTbl = new VehicleBL().GetAll();
                cboVenID.DataSource = venTbl;
                cboVenID.ValueMember = "VehicleID";
                cboVenID.DisplayMember = "VenNo";

                tripPlanTbl = new TripPlanBL().GetAll(GlobalCache.is_sale, conn);
                cboTripPlanID.DataSource = tripPlanTbl;
                cboTripPlanID.ValueMember = "TripPlanID";
                cboTripPlanID.DisplayMember = "TripPlanName";

                tripTbl = new TripBL().GetAll();
                cboTripID.DataSource = tripTbl;
                cboTripID.ValueMember = "TripID";
                cboTripID.DisplayMember = "TripName";

                //tripTbl2 = new TripBL().GetAll(conn);
                tripTbl2 = new TripPlanBL().GetAll(GlobalCache.is_sale, conn);
                cboPrevTripID.DataSource = tripTbl2;
                cboPrevTripID.ValueMember = "TripPlanID";
                cboPrevTripID.DisplayMember = "TripPlanName";

                userTbl = new EmployeeBL().GetAll();
                cboManagerID.DataSource = userTbl;
                cboManagerID.ValueMember = "EmployeeID";
                cboManagerID.DisplayMember = "EmpName";

                cboStaff1ID.DataSource = userTbl;
                cboStaff1ID.ValueMember = "EmployeeID";
                cboStaff1ID.DisplayMember = "EmpName";


                //cboStaff2ID.DataSource = userTbl;
                //cboStaff2ID.ValueMember = "UserID";
                //cboStaff2ID.DisplayMember = "UserName";


                cboSupportStaffID.DataSource = userTbl;
                cboSupportStaffID.ValueMember = "EmployeeID";
                cboSupportStaffID.DisplayMember = "EmpName";

                a_p_Tbl = new AP_MaterialBL().GetAllMaterial();
                clnA_PID.DataSource = a_p_Tbl;
                clnA_PID.ValueMember = "A_P_MaterialID";
                clnA_PID.DisplayMember = "APMaterialName";

                product_Tbl = new ProductBL().GetAll();
                clnProductID.DataSource = product_Tbl;
                clnProductID.ValueMember = "ProductID";
                clnProductID.DisplayMember = "ProductName";


                //DataTable dtItemList = new DataTable();
                //dtItemList = new T_R_Product_BL().GetAll(conn);
                //dgvItemList.DataSource = dtItemList;


                //DataTable dtGiftList = new DataTable();
                //dtGiftList = new T_R_AP_BL().GetAll(conn);
                //dgvGiftList.DataSource = dtGiftList;
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

        private void butsave_Click(object sender, EventArgs e)
        {
            if (cboTripPlanID.Text == "")
            {
                ToastMessageBox.Show("Trip pan name is blank!");
                return;
            }

            //if (cboPrevTripID.Text == "")
            //{
            //    ToastMessageBox.Show("Last trip plan name is blank!");
            //    return;
            //}

            Save();
        }

        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                TripRequestBL tripRequestSaver = new TripRequestBL();
                T_R_AP_BL t_r_AP_Saver = new T_R_AP_BL();
                T_R_Product_BL t_r_Product_Saver = new T_R_Product_BL();

                TripRequest saveTripRequest = new TripRequest()
                {
                    TripPlanDetailID = (int)cboTripPlanID.SelectedValue,
                    RoutePlanID = 0,
                    TransportTypeID = (int)cboTranportTypeID.SelectedValue,
                    VenID = (int)cboVenID.SelectedValue,
                    ManagerID = (int)cboManagerID.SelectedValue,
                    SalesPersonID = (int)cboStaff1ID.SelectedValue,
                    SupporterID = (int)cboSupportStaffID.SelectedValue,
                    TripPlanNo = "",
                    ReqDate = dtTripRequestDate.Value,
                    FromDate = dtFromDate.Value,
                    ToDate = dtToDate.Value,
                    PrevTripName = cboTripID.SelectedValue.ToString(),
                    IsSaleDevice = chkSaleMachineInfo.Checked,
                    IsVocher = chkVoucher.Checked,
                    PersonCount = (int)DataTypeParser.Parse(udStaffNumber.Text, typeof(int), 0),
                    SalesTargetAmt = Convert.ToDecimal(txtSalesGoal.Text),
                    IsVen = chkVehicle.Checked,
                    IsAcc = chkCashAccount.Checked,
                    IsFac = chkFactory.Checked,
                    IsAdm = chkCashMachine.Checked,
                    IsTab = chkSaleMachineInfo.Checked,
                    Remark = "",
                    COO = txtCOO.Text,
                    MM = txtMM.Text,
                    SM = txtSM.Text,
                    isSale = GlobalCache.is_sale


                };
                //if (saveProduct.SubCategoryID == -1 || string.IsNullOrEmpty(saveProduct.ProductName))
                //{
                //    // show error msg
                //    MessageBox.Show(string.Format(Resource.errRequiredFields + "\n - {0}\n - {1}", Resource.SubCategory, Resource.ProductName),
                //        Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                int affectedRows = 0;
                if (_mdTripReqest == null) // add a new product
                {
                    affectedRows = tripRequestSaver.Add(saveTripRequest, EmployeesList, conn);
                }
                else // update an existing product
                {
                    // set product id for update condition
                    saveTripRequest.ID = _mdTripReqest.ID;
                    affectedRows = tripRequestSaver.UpdateAPRequestIDByTripRequestID(saveTripRequest, EmployeesList, conn);
                }

                //T R Product

                DataTable dt = dgvItemList.DataSource as DataTable;


                List<T_R_Product> insertItemList = new List<T_R_Product>();
                List<T_R_Product> updateItemList = new List<T_R_Product>();
                List<T_R_Product> deleteItemList = new List<T_R_Product>();


                if (dt != null)
                {
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        T_R_Product t_r_Product = new T_R_Product()
                        {

                            ID = (int)DataTypeParser.Parse(row["TR_Product_ID"].ToString(), typeof(int), -1),
                            TripReqID = _mdTripReqest.ID,
                            // TripReqID = (int)DataTypeParser.Parse(row["TripReqID"].ToString(), typeof(int), -1),
                            ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1),
                            Weight = (int)DataTypeParser.Parse(row["Weight"].ToString(), typeof(int), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        insertItemList.Add(t_r_Product);
                    }

                    // delete
                    DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                    foreach (DataRow row in dvDelete.ToTable().Rows)
                    {
                        T_R_Product t_r_Product = new T_R_Product()
                        {

                            ID = (int)DataTypeParser.Parse(row["TR_Product_ID"].ToString(), typeof(int), -1),
                            //TripReqID = (int)DataTypeParser.Parse(row["TripReqID"].ToString(), typeof(int), -1),
                            TripReqID = _mdTripReqest.ID,
                            ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1),
                            Weight = (int)DataTypeParser.Parse(row["Weight"].ToString(), typeof(int), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        deleteItemList.Add(t_r_Product);

                    }

                    // update
                    DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate.ToTable().Rows)
                    {
                        T_R_Product t_r_Product = new T_R_Product()
                        {

                            ID = (int)DataTypeParser.Parse(row["TR_Product_ID"].ToString(), typeof(int), -1),
                            // TripReqID = (int)DataTypeParser.Parse(row["TripReqID"].ToString(), typeof(int), -1),
                            TripReqID = _mdTripReqest.ID,
                            ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1),
                            Weight = (int)DataTypeParser.Parse(row["Weight"].ToString(), typeof(int), -1),
                            Remark = (string)DataTypeParser.Parse(row["remark"].ToString(), typeof(string), "")

                        };

                        updateItemList.Add(t_r_Product);


                    }


                    if (insertItemList.Count > 0) affectedRows += t_r_Product_Saver.Add(insertItemList, conn);
                    if (deleteItemList.Count > 0) affectedRows += t_r_Product_Saver.DeleteByT_R_ProductID(deleteItemList, conn);
                    if (updateItemList.Count > 0) affectedRows += t_r_Product_Saver.UpdateByT_R_productID(updateItemList, conn);

                }

                // T R AP

                dt = dgvGiftList.DataSource as DataTable;


                List<T_R_AP> insertGiftList = new List<T_R_AP>();
                List<T_R_AP> updateGiftList = new List<T_R_AP>();
                List<T_R_AP> deleteGiftList = new List<T_R_AP>();

                if (dt != null)
                {
                    DataView dvInsert2 = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert2.ToTable().Rows)
                    {

                        T_R_AP t_r_AP = new T_R_AP()
                        {

                            ID = (int)DataTypeParser.Parse(row["T_R_APID"].ToString(), typeof(int), -1),
                            //TripReqID = (int)DataTypeParser.Parse(row["TripReqID"].ToString(), typeof(int), -1),
                            TripReqID = _mdTripReqest.ID,
                            A_PID = (int)DataTypeParser.Parse(row["A_P_MaterialID"].ToString(), typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1)
                        };

                        insertGiftList.Add(t_r_AP);
                    }

                    // delete
                    DataView dvDelete2 = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                    foreach (DataRow row in dvDelete2.ToTable().Rows)
                    {
                        T_R_AP t_r_AP = new T_R_AP()
                        {

                            ID = (int)DataTypeParser.Parse(row["T_R_APID"].ToString(), typeof(int), -1),
                            // TripReqID = (int)DataTypeParser.Parse(row["TripReqID"].ToString(), typeof(int), -1),
                            TripReqID = _mdTripReqest.ID,
                            A_PID = (int)DataTypeParser.Parse(row["A_PID"].ToString(), typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1)
                        };

                        deleteGiftList.Add(t_r_AP);
                    }

                    // update
                    DataView dvUpdate2 = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate2.ToTable().Rows)
                    {
                        T_R_AP t_r_AP = new T_R_AP()
                        {

                            ID = (int)DataTypeParser.Parse(row["T_R_APID"].ToString(), typeof(int), -1),
                            // TripReqID = (int)DataTypeParser.Parse(row["TripReqID"].ToString(), typeof(int), -1),
                            TripReqID = _mdTripReqest.ID,
                            A_PID = (int)DataTypeParser.Parse(row["T_R_APID"].ToString(), typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1)
                        };

                        updateGiftList.Add(t_r_AP);


                    }


                    if (insertGiftList.Count > 0) affectedRows += t_r_AP_Saver.Add(insertGiftList, conn);
                    if (deleteGiftList.Count > 0) affectedRows += t_r_AP_Saver.DeleteByTR_AP_ID(deleteGiftList, conn);
                    if (updateGiftList.Count > 0) affectedRows += t_r_AP_Saver.UpdateByTR_AP_ID(updateGiftList, conn);
                }

                // if succeeded, handle to reload products onto DataGridView from parent caller 
                if (affectedRows > 0)
                {
                    //TripRequestSaveEventArgs tripRequestSaveEventArgs = new TripRequestSaveEventArgs(true);
                    //TripRequestSavedHandler(this, tripRequestSaveEventArgs);

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }

        }


        /// <summary>
        /// Bind data to be ready for modification
        /// </summary>
        private void BindModifyData()
        {
            //cmbBrand.SelectedValue = _brandID;
            //cmbCategory.SelectedValue = _categoryID;
            //cmbSubCategory.SelectedValue = _mdProduct.SubCategoryID;


            cboTripPlanID.Text = "";
            cboTripID.Text = "";
            udStaffNumber.Text = _mdTripReqest.PersonCount.ToString();
            cboManagerID.Text = "";
            cboStaff1ID.Text = "";
            //cboStaff2ID.Text = "";
            cboSupportStaffID.Text = "";
            txtSalesGoal.Text = _mdTripReqest.SalesTargetAmt.ToString();
            //dtTripRequestDate.Value = _mdTripReqest.ReqDate;
            cboTranportTypeID.Text = "";
            cboVenID.Text = "";
            dtFromDate.Value = _mdTripReqest.FromDate;
            dtToDate.Value = _mdTripReqest.ToDate;
            txtTotalDays.Text = _mdTripReqest.ToDate.Subtract(_mdTripReqest.FromDate).ToString();
            cboPrevTripID.Text = "";
            dtPrevTripDate.Value = DateTime.Now;
            chkCashMachine.Checked = true;
            chkVoucher.Checked = _mdTripReqest.IsVocher;
            chkVehicle.Checked = _mdTripReqest.IsVen;
            chkCashAccount.Checked = _mdTripReqest.IsAcc;
            chkFactory.Checked = _mdTripReqest.IsFac;
            chkManage.Checked = true;
            chkSaleMachineInfo.Checked = _mdTripReqest.IsSaleDevice;
        }

        private void Delete()
        {
            this.Close();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        #region Inner Class
        public class TripRequestSaveEventArgs : EventArgs
        {
            private bool _needToReloadTripRequest;
            public TripRequestSaveEventArgs(bool _needToReloadTripRequest)
            {
                this._needToReloadTripRequest = _needToReloadTripRequest;
            }
            public bool NeedToReloadTripRequest
            {
                get { return this._needToReloadTripRequest; }
            }
        }
        #endregion

        private void dgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvItemList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvItemList.Rows[e.RowIndex].Cells["ClnNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvGiftList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvGiftList.Rows[e.RowIndex].Cells["ClnNo2"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvGiftList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboPrevTripID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrevTripID.Text.ToString() == "") return;

            int prevRequestID = (int)DataTypeParser.Parse(cboPrevTripID.SelectedValue, typeof(int), -1);

            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtTripRequestDetail = new TripRequestBL().SelectByTripRequestID(prevRequestID, conn);
                if (dtTripRequestDetail == null) return;
                if (dtTripRequestDetail.Rows.Count > 0)
                {
                    dtPrevTripDate.Value = Convert.ToDateTime(dtTripRequestDetail.Rows[0]["FromDate"].ToString());
                    //txtPrevRent.Text = dtTripRequestDetail.Rows[0]["Rent"].ToString();
                    //txtPrevTransport.Text = dtTripRequestDetail.Rows[0]["Transport"].ToString();
                    //txtPrevRemittance.Text = dtTripRequestDetail.Rows[0]["Remittance"].ToString();
                    //txtPrevCommunication.Text = dtTripRequestDetail.Rows[0]["Communication"].ToString();
                    //txtPrevFood.Text = dtTripRequestDetail.Rows[0]["Food"].ToString();
                    //txtPrevOtherExp.Text = dtTripPlanDetail.Rows[0]["OtherExp"].ToString();
                }
            }

            catch (SqlException sqe)
            {
                _logger.Error(sqe);
            }

        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            // Open invoice lookup form
            //if (_mdTripReqest == null)
            //{
            //    ToastMessageBox.Show("Please Save TripRequest First!"); return;
            //}
            int ManagerID = (int)DataTypeParser.Parse(cboManagerID.SelectedValue, typeof(int), 0);
          
            if (this._mdTripReqest.ID == null) return;
            frmEmployeePicker employeePicker = new frmEmployeePicker(_mdTripReqest.ID, ManagerID, true);
            employeePicker.EmployeeSelectedHandler += new frmEmployeePicker.EmployeeSelectionHandler(employeeSelection_CallBack);
            // Set call back handler
            UIManager.OpenForm(employeePicker);
        }

        void employeeSelection_CallBack(object sender, frmEmployeePicker.EmployeeSelectionEventArgs args)
        {
            if (args.Employees == null)
                return;
            EmployeesList = new List<Employee>();
            udStaffNumber.Text = args.Employees.Count.ToString();
            foreach (Employee insertemployee in args.Employees)
            {
                if (insertemployee.EmployeeInTripPlanDetailID == 0)
                    EmployeesList.Add(insertemployee);
            }

        }

        private void cboTripID_SelectedValueChanged(object sender, EventArgs e)
        {
            int TripID = (int)DataTypeParser.Parse(cboTripID.SelectedValue, typeof(int), 0);
            DataTable tmpTbl = DataUtil.GetDataTableBy(this.tripTbl, "TripID", TripID);
            if (tmpTbl == null) return;
            int TripPeriod = (int)DataTypeParser.Parse(tmpTbl.Rows[0]["TripPeriod"].ToString(), typeof(int), 0);
            DateTime PeriodDate = dtFromDate.Value.AddDays(TripPeriod);
            dtToDate.Value = PeriodDate;
            txtTotalDays.Text = (string)DataTypeParser.Parse(TripPeriod, typeof(string), 0);

        }
    }
}
