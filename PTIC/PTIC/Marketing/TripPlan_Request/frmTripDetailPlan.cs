using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using log4net;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.Common.BL;
using PTIC.Marketing;
using PTIC.Sale.BL;
using PTIC.Marketing.MarketingPlan;
using PTIC.Common.Entities;
using PTIC.Util;
using PTIC.VC.Marketing.A_P;
using PTIC.Common;
using PTIC.VC.Validation;
using PTIC.Marketing.TripPlan_Request;
using PTIC.VC.Marketing.Entities;
using PTIC.Common.DA;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmTripDetailPlan : Form
    {
        //  DataTable tripPlanTbl = null;
        DataTable tripTbl = null;
        DataTable tripTbl2 = null;
        DataTable venTbl = null;
        DataTable transportTypeTbl = null;
        DataTable userTbl = null;
        DataTable a_p_Tbl = null;
        bool checkReqestEmp = false;
        TripPlanDetail _mTripPlanDetail = null;
        TripPlan _mTripPlan = null;

        private string remark = "";

        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTripPlan));
        private List<Employee> EmployeesList = null;

        // TripRequest Fields
        DataTable dtTripRequestDetail = null;
        int TripRequestID = -1;
        int? ProductRequestIssueID = null;
        int? AP_RequestID = null;

        DataTable dtAPTransferList = null;
        private bool alreadyIssued;

        private int? _tripRecordID = null;




        




        #region Events
        private void butSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void frmTripPlanDetail_Load(object sender, EventArgs e)
        {
            dgvAPGiftList.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current trip plan will be reported.");
        }

        private void dgvAPGiftList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvAPGiftList.Rows[e.RowIndex].Cells["ClnNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void cboPrevTripID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboPrevTripID.Text.ToString() == "") return;
            //int prevTripPlanDetailID = 0;
            //DataRowView drv = cboPrevTripID.SelectedValue as DataRowView;
            //if (drv == null)
            //{
            //    prevTripPlanDetailID = Convert.ToInt32(cboPrevTripID.SelectedValue);
            //}
            //else
            //{
            //    prevTripPlanDetailID = Convert.ToInt32(drv.Row.ItemArray[0]);
            //}

            //SqlConnection conn = null;
            //try
            //{
            //    conn = DBManager.GetInstance().GetDbConnection();
            //    DataTable dtTripPlanDetail = new TripPlanDetailBL().GetPrevTripPlanByTripPlanDetailID(prevTripPlanDetailID, conn);
            //    if (dtTripPlanDetail == null) return;
            //    if (dtTripPlanDetail.Rows.Count > 0)
            //    {
            //        dtPrevTripID.Value = Convert.ToDateTime(dtTripPlanDetail.Rows[0]["FromDate"].ToString());
            //        txtPrevRent.Text = dtTripPlanDetail.Rows[0]["Rent"].ToString();
            //        txtPrevTransport.Text = dtTripPlanDetail.Rows[0]["Transport"].ToString();
            //        txtPrevRemittance.Text = dtTripPlanDetail.Rows[0]["Remittance"].ToString();
            //        txtPrevCommunication.Text = dtTripPlanDetail.Rows[0]["Communication"].ToString();
            //        txtPrevFood.Text = dtTripPlanDetail.Rows[0]["Food"].ToString();
            //        txtPrevOtherExp.Text = dtTripPlanDetail.Rows[0]["OtherExp"].ToString();
            //    }
            //}
            //catch (SqlException sqle)
            //{
            //}
            //finally
            //{
            //    DBManager.GetInstance().CloseDbConnection();
            //}
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtToDate.Value.Date < dtFromDate.Value.Date) 
            {
                dtToDate.Value = dtFromDate.Value.Date;
            }
            dtToDate.MinDate = dtFromDate.Value.Date;


            txtTotalDays.Text = dtToDate.Value.Subtract(dtFromDate.Value).Days.ToString();
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            //if (dtToDate.Value.ToShortDateString() != dtFromDate.Value.ToShortDateString())
            //dtFromDate.Value = dtToDate.Value.AddMonths(-2);

            if (dtToDate.Value.Date < dtFromDate.Value.Date)
            {
                dtFromDate.Value = dtToDate.Value.Date;
            }
            txtTotalDays.Text = dtToDate.Value.Subtract(dtFromDate.Value).Days.ToString();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            // Open invoice lookup form
            int ManagerID = (int)DataTypeParser.Parse(cboManagerID.SelectedValue, typeof(int), 0);
            if (EmployeesList == null)
            {
                frmEmployeePicker employeePicker = new frmEmployeePicker(_mTripPlanDetail.ID, ManagerID);
                employeePicker.EmployeeSelectedHandler += new frmEmployeePicker.EmployeeSelectionHandler(employeeSelection_CallBack);
                // Set call back handler
                UIManager.OpenForm(employeePicker);
            }
            else 
            {
                frmEmployeePicker employeePicker = new frmEmployeePicker(_mTripPlanDetail.ID, ManagerID,EmployeesList);
                employeePicker.EmployeeSelectedHandler += new frmEmployeePicker.EmployeeSelectionHandler(employeeSelection_CallBack);
                // Set call back handler
                UIManager.OpenForm(employeePicker);
            
            }
        }

        private void employeeSelection_CallBack(object sender, frmEmployeePicker.EmployeeSelectionEventArgs args)
        {
            if (args.Employees == null)
                return;
            EmployeesList = new List<Employee>();
            if (checkReqestEmp)
            {
                udStaffNumber.Text = args.Employees.Count.ToString();
            }
            else
            {
                numPersonCount.Text = args.Employees.Count.ToString();
            }
            foreach (Employee insertemployee in args.Employees)
            {
                if (insertemployee.EmployeeInTripPlanDetailID == 0)
                    EmployeesList.Add(insertemployee);
            }

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void numPersonCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void txtRent_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void cboTripID_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtPrevRent_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtPrevFood_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnAPRequest_Click(object sender, EventArgs e)
        {
            alreadyIssued = false;
            DataTable dtTmpIssueInfo = null;
            // TODO: set aleradyIsseud ...
            if (AP_RequestID.HasValue)
            {
                dtTmpIssueInfo = DataUtil.GetDataTableBy(dtAPTransferList, "AP_RequestID", AP_RequestID);
                if (dtTmpIssueInfo.Rows.Count > 0)
                {
                    DateTime IssueDate = (DateTime)DataTypeParser.Parse(dtTmpIssueInfo.Rows[0]["IssueDate"], typeof(DateTime), DateTime.MinValue);
                    if (IssueDate != DateTime.MinValue)
                    {
                        alreadyIssued = true;
                    }
                }
            }

            if (AP_RequestID.HasValue && alreadyIssued)
            {
                int AP_IssueDeptID = (int)DataTypeParser.Parse(dtTmpIssueInfo.Rows[0]["IssueDeptID"], typeof(int), -1);
                int AP_IssueEmployeeID = (int)DataTypeParser.Parse(dtTmpIssueInfo.Rows[0]["IssueEmployeeID"], typeof(int), -1);

                frmPosmRecieve frmReceive = new frmPosmRecieve(AP_RequestID, AP_IssueDeptID, AP_IssueEmployeeID);
                UIManager.OpenForm(frmReceive);
            }
            else if (AP_RequestID.HasValue)
            {
                frmPosmRequest _frmPosmRequest = new frmPosmRequest(AP_RequestID);
                _frmPosmRequest.POSM_RequestSavedHandler += new frmPosmRequest.POSM_RequestSaveHandler(form_PosmRequest_POSM_RequestSaved_CallBack);
                UIManager.OpenForm(_frmPosmRequest);
            }
            else
            {
                frmPosmRequest _frmPosmRequest = new frmPosmRequest();
                _frmPosmRequest.POSM_RequestSavedHandler += new frmPosmRequest.POSM_RequestSaveHandler(form_PosmRequest_POSM_RequestSaved_CallBack);
                UIManager.OpenForm(_frmPosmRequest);
            }
            LoadNBind();
            LoadNBindTripDetailPlan();
        }

        private void form_PosmRequest_POSM_RequestSaved_CallBack(object sender, POSM_RequestEventArgs e)
        {
            // TODO: update TripRequest...
            if (!this.AP_RequestID.HasValue)
            {
                this.AP_RequestID = e.AP_RequestID;
                btnAPRequest.Text = "ထုတ်ပေးမည်";
            }
            SaveTripPlanRequest();
        }

        private void btnRequestEmployees_Click(object sender, EventArgs e)
        {
            int ManagerID = (int)DataTypeParser.Parse(cmbTripRequestManager.SelectedValue, typeof(int), 0);
            checkReqestEmp = true;
            //if (_mTripPlanDetail.ID == -1) return;
            frmEmployeePicker employeePicker = new frmEmployeePicker(TripRequestID, ManagerID, true);
            employeePicker.EmployeeSelectedHandler += new frmEmployeePicker.EmployeeSelectionHandler(employeeSelection_CallBack);
            // Set call back handler
            UIManager.OpenForm(employeePicker);
        }

        private void btnTripRequest_Click(object sender, EventArgs e)
        {
            SaveTripPlanRequest();
        }

        private void dtpRequestFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRequestFromDate.Value.Date < dtpRequestToDate.Value.Date)
            {
                dtpRequestToDate.Value = dtFromDate.Value.Date;
            }
            dtpRequestToDate.MinDate = dtFromDate.Value.Date;


            txtTripRequestDay.Text = dtpRequestToDate.Value.Subtract(dtpRequestFromDate.Value).Days.ToString();
        }

        private void dtpRequestToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpRequestFromDate.Value.Date > dtpRequestToDate.Value.Date)
            {
                dtFromDate.Value = dtpRequestToDate.Value.Date;
            }

            txtTripRequestDay.Text = dtpRequestToDate.Value.Subtract(dtpRequestFromDate.Value).Days.ToString();
        }

        private void btnSaveTripRecord_Click(object sender, EventArgs e)
        {
            SaveTripRecord();
        }

        private void txtTripRecordExpense_TextChanged(object sender, EventArgs e)
        {
            this.txtTotalExpense.Text = CalculateTripRecordExpense().ToString("N0");
        }
        #endregion

        #region Private Methods
        public void LoadNBindTripDetailPlan()
        {
            SqlConnection conn = null;
            int tripPlanDetailID = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                tripPlanDetailID = this._mTripPlanDetail.ID;

                txtTripPlanName.Text = _mTripPlan.TripPlanName;
                // TripPlanRequest TextBox Binding
                txtTripPlanRequest.Text = _mTripPlan.TripPlanName;
                txtTripName.Text = _mTripPlan.TripPlanName;

                

                using (DataTable dtTripPlanDetail = new TripPlanDetailBL().GetByTripPlanDetailID(tripPlanDetailID, conn))
                {
                    //dgvAPGiftList.DataSource = tblTripPanelDetails;
                    //Bind to each controls
                    
                    txtTripNo.Text = dtTripPlanDetail.Rows[0]["TripPlanNo"].ToString();
                    cboTripID.SelectedValue = dtTripPlanDetail.Rows[0]["TripID"].ToString();
                    //   txtTripPlanName.Text = dtTripPlanDetail.Rows[0]["TripPlanName"].ToString();
                    cboManagerID.SelectedValue = (int)dtTripPlanDetail.Rows[0]["ManagerID"];
                    //cboSalesPersonID.SelectedValue = (int)dtTripPlanDetail.Rows[0]["SalesPersonID"];

                    cboTransportTypeID.SelectedValue = (int)dtTripPlanDetail.Rows[0]["TransportTypeID"];
                    cmbTripRequestTranportType.SelectedValue = (int)dtTripPlanDetail.Rows[0]["TransportTypeID"];    // TripRequest TransportType

                    cmbTripRequestVen.SelectedValue = (int?)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["VenID"].ToString(), typeof(int), 0);
                    cmbRequestVen.SelectedValue = (int?)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["VenID"].ToString(), typeof(int), 0); // TripRequest Ven

                    dtFromDate.Value = (DateTime)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["FromDate"].ToString(), typeof(DateTime), DateTime.Now);
                    dtpRequestFromDate.Value = (DateTime)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["FromDate"].ToString(), typeof(DateTime), DateTime.Now); // TripRequest FromDate
                    dtToDate.Value = (DateTime)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["ToDate"].ToString(), typeof(DateTime), DateTime.Now);
                    dtpRequestToDate.Value = (DateTime)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["ToDate"].ToString(), typeof(DateTime), DateTime.Now);   // TripRequest ToDate

                    txtTotalDays.Text = dtToDate.Value.Subtract(dtFromDate.Value).Days.ToString();
                    txtTripRequestDay.Text = dtpRequestToDate.Value.Subtract(dtpRequestFromDate.Value).Days.ToString(); // TripRequest Total Days

                    //   cboSaleType.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["SaleType"].ToString(), typeof(string), string.Empty);
                    txtRemittance.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Remittance"].ToString(), typeof(string), string.Empty);
                    txtRent.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Rent"].ToString(), typeof(string), string.Empty);
                    txtTransport.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Transport"].ToString(), typeof(string), string.Empty);
                    txtcommunication.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Communication"].ToString(), typeof(string), string.Empty);
                    txtOtherExp.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["OtherExp"].ToString(), typeof(string), string.Empty);
                    txtFood.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Food"].ToString(), typeof(string), string.Empty);
                    numPersonCount.Text = ((int)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["PersonCount"].ToString(), typeof(int), 0)).ToString();
                    //   cboSaleType.SelectedIndex = (int)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["SaleType"].ToString(), typeof(int), 0);
                    chkCash.Checked = (bool)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["SaleType"], typeof(bool), 0);
                    chkCredit.Checked = (bool)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["SaleType1"], typeof(bool), 0);
                    chkConsignment.Checked = (bool)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["SaleType2"], typeof(bool), 0);
                    //  cboPrevTripID.SelectedValue = dtTripPlanDetail.Rows[0]["PrevTripName"].ToString();

                    txtCOO.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["COORemark"].ToString(), typeof(string), string.Empty);
                    txtMM.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["MarketingManagerRemark"].ToString(), typeof(string), string.Empty);
                    txtSM.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["SaleManagerRemark"].ToString(), typeof(string), string.Empty);
                    txtPurpose.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["TripPlanPurpose"].ToString(), typeof(string), string.Empty);
                    remark = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Remark"].ToString(), typeof(string), string.Empty);
                    //txtTripName.Text = (string)DataTypeParser.Parse(dtTripPlanDetail.Rows[0]["Remark"].ToString(), typeof(string), string.Empty);
                };

                //if (numPersonCount.Text == "0") numPersonCount.Text=((int)DataTypeParser.Parse(numPersonCount.Text,typeof(int),0) + 1).ToString();
                DataTable dtAPGiftList = new DataTable();
                dtAPGiftList = new TripPlan_AP_BL().GetByTripPlanDetailID(_mTripPlanDetail.ID, conn);
                //dtAPGiftList= new TripPlan_AP
                dgvAPGiftList.AutoGenerateColumns = false;
                dgvAPGiftList.DataSource = dtAPGiftList;
                // DataTable dtTripPlan_AP=new TripPlanDetailBL().GetAPByTripPlanDetailID(tripPlanDetailID, conn))
                //dgvAPGiftList.DataSource = dtTripPlan_AP;
            }
            catch (SqlException ie)
            {
            }
        }

        private void set_default()
        {
            txtTripNo.Text = "";
            txtcommunication.Text = "0";
            txtFood.Text = "0";
            txtOtherExp.Text = "0";
            txtRemittance.Text = "0";
            txtRent.Text = "0";
            txtTotalDays.Text = "0";
            txtTransport.Text = "0";
            txtPrevCommunication.Text = "0";
            txtPrevFood.Text = "0";
            txtPrevOtherExp.Text = "0";
            txtPrevRemittance.Text = "0";
            txtPrevRent.Text = "0";
            txtTotalDays.Text = "0";
            txtPrevTransport.Text = "0";
            cboManagerID.Text = "";
            cboPrevTripID.Text = "";
            cboSalesPersonID.Text = "";
            cboTransportTypeID.Text = "";
            cboTripID.Text = "";
            cmbTripRequestVen.Text = "";
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now;
            dtTransDate.Value = DateTime.Now;
            cboPrevTripID.Text = "";
            numPersonCount.Text = "0";

        }

        private void SetInputExpression()
        {
            // Allow only interger
            txtDebitConflictShop.ValidationExpression =
            txtShopWithoutOwnerSign.ValidationExpression =
            txtPrevDebitAmt.ValidationExpression =
            txtRentAmt.ValidationExpression =
            txtFoodAmt.ValidationExpression =
            txtTransportAmt.ValidationExpression =
            txtCommunicationAmt.ValidationExpression =
            txtOtherExpense.ValidationExpression =
            txtRemittanceAmt.ValidationExpression = PatternRule.NaturalNumberIncludingBlank;
        }

        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                TripPlanDetailBL tripPlanDetailSaver = new TripPlanDetailBL();
                TripPlan_AP_BL tripPlan_AP_Saver = new TripPlan_AP_BL();

                TripPlanDetail saveTripPlanDetail = new TripPlanDetail()
               {
                   ID = _mTripPlanDetail.ID,
                   TripPlanID = _mTripPlan.ID,
                   //TripPlanID=(int)DataTypeParser.Parse(txtTripPlanName.Text,typeof(int),-1),
                   ManagerID = (int)DataTypeParser.Parse(cboManagerID.SelectedValue, typeof(int), 0),
                   SalesPersonID = (int)DataTypeParser.Parse(cboSalesPersonID.SelectedValue, typeof(int), 0),
                   TransportTypeID = (int)DataTypeParser.Parse(cboTransportTypeID.SelectedValue, typeof(int), 0),
                   VenID = (int?)DataTypeParser.Parse(cmbTripRequestVen.SelectedValue, typeof(int), null),
                   TripPlanNo = txtTripNo.Text,
                   TripID = (int)DataTypeParser.Parse(cboTripID.SelectedValue, typeof(int), 0),
                   TranDate = dtTransDate.Value,
                   Accessories = "",
                   FromDate = dtFromDate.Value,
                   ToDate = dtToDate.Value,
                   COO_remark = txtCOO.Text.ToString(),
                   MM_remark = txtMM.Text.ToString(),
                   SM_remark = txtSM.Text.ToString(),
                   PersonCount = (int)DataTypeParser.Parse(numPersonCount.Text, typeof(int), 0),
                   // TODO: previos trip name must be referenced from history
                   PrevTripName = (string)DataTypeParser.Parse(cboPrevTripID.SelectedValue, typeof(string), null),
                   // SaleType = (int)cboSaleType.SelectedIndex,
                   TripPlanPurpose = txtPurpose.Text,
                   SaleType = (bool)DataTypeParser.Parse(chkCash.Checked, typeof(bool), 0),
                   SaleType1 = (bool)DataTypeParser.Parse(chkCredit.Checked, typeof(bool), 0),
                   SaleType2 = (bool)DataTypeParser.Parse(chkConsignment.Checked, typeof(bool), 0),
                   Rent = (decimal)DataTypeParser.Parse(txtRent.Text.ToString(), typeof(decimal), 0),
                   Food = (decimal)DataTypeParser.Parse(txtFood.Text.ToString(), typeof(decimal), 0),
                   Transport = (decimal)DataTypeParser.Parse(txtTransport.Text.ToString(), typeof(decimal), 0),
                   Communication = (decimal)DataTypeParser.Parse(txtcommunication.Text.ToString(), typeof(decimal), 0),
                   OtherExp = (decimal)DataTypeParser.Parse(txtOtherExp.Text, typeof(decimal), 0),
                   Remittance = (decimal)DataTypeParser.Parse(txtRemittance.Text, typeof(decimal), 0),
                   Remark = this.remark
               };

                //if (saveProduct.SubCategoryID == -1 || string.IsNullOrEmpty(saveProduct.ProductName))
                //{
                //    // show error msg
                //    MessageBox.Show(string.Format(Resource.errRequiredFields + "\n - {0}\n - {1}", Resource.SubCategory, Resource.ProductName),
                //        Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                int affectedRows = 0;
                //if (_mdTripReqest == null) // add a new product
                //{
                //    affectedRows = tripRequestSaver.Add(saveTripRequest, conn);
                //}
                //else // update an existing product
                //{
                // set product id for update condition
                saveTripPlanDetail.ID = _mTripPlanDetail.ID;
                affectedRows = tripPlanDetailSaver.UpdateByID(saveTripPlanDetail, EmployeesList, conn);

                DataTable dt = dgvAPGiftList.DataSource as DataTable;

                List<TripPlan_AP> insertTripPlanAP = new List<TripPlan_AP>();
                List<TripPlan_AP> updateTripPlanAP = new List<TripPlan_AP>();
                List<TripPlan_AP> deleteTripPlanAP = new List<TripPlan_AP>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    TripPlan_AP tripPlan_AP = new TripPlan_AP()
                    {
                        TripPlanDetailID = _mTripPlanDetail.ID,
                        A_PID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1)
                    };
                    insertTripPlanAP.Add(tripPlan_AP);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    TripPlan_AP tripPlan_AP = new TripPlan_AP()
                    {
                        ID = (int)DataTypeParser.Parse(row["Trip_Plan_AP_ID"].ToString(), typeof(int), -1),
                        TripPlanDetailID = _mTripPlanDetail.ID,
                        A_PID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1)
                    };
                    deleteTripPlanAP.Add(tripPlan_AP);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    TripPlan_AP tripPlan_AP = new TripPlan_AP()
                    {
                        ID = (int)DataTypeParser.Parse(row["Trip_Plan_AP_ID"].ToString(), typeof(int), -1),
                        TripPlanDetailID = _mTripPlanDetail.ID,
                        A_PID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1)

                    };
                    updateTripPlanAP.Add(tripPlan_AP);
                }

                if (insertTripPlanAP.Count > 0) affectedRows += tripPlan_AP_Saver.Insert(insertTripPlanAP, conn);
                if (deleteTripPlanAP.Count > 0) affectedRows += tripPlan_AP_Saver.DeleteByTripPlanAPID(deleteTripPlanAP, conn);
                if (updateTripPlanAP.Count > 0) affectedRows += tripPlan_AP_Saver.UpdateByTripPlanAPID(updateTripPlanAP, conn);

                //  }
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

        private void LoadNBind()
        {            
            DataTable dtEmployeesByDept = null;
            try
            {                
                transportTypeTbl = new TransportTypeBL().GetAll();
                cboTransportTypeID.DataSource = transportTypeTbl;
                cboTransportTypeID.ValueMember = "TransportTypeID";
                cboTransportTypeID.DisplayMember = "TransportTypeName";

                // TripPlanRequest TransportType Combobox Binding
                cmbTripRequestTranportType.DataSource = transportTypeTbl;
                cmbTripRequestTranportType.ValueMember = "TransportTypeID";
                cmbTripRequestTranportType.DisplayMember = "TransportTypeName";

                venTbl = new VehicleBL().GetAll();
                cmbTripRequestVen.DataSource = venTbl;
                cmbTripRequestVen.ValueMember = "VehicleID";
                cmbTripRequestVen.DisplayMember = "VenNo";

                // TripPlanRequest Combobox binding
                cmbRequestVen.DataSource = venTbl;
                cmbRequestVen.ValueMember = "VehicleID";
                cmbRequestVen.DisplayMember = "VenNo";

                tripTbl = new TripBL().GetAll();
                cboTripID.DataSource = tripTbl;
                cboTripID.ValueMember = "TripID";
                cboTripID.DisplayMember = "TripName";

                //  TripRequest Combobox Binding
                cmbTrip.DataSource = tripTbl;
                cmbTrip.ValueMember = "TripID";
                cmbTrip.DisplayMember = "TripName";

                userTbl = new EmployeeBL().GetAll();
                if (Program.module==Program.Module.Marketing)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(userTbl, "DeptID", 8);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(userTbl, "DeptID", 7);
                }
                cboManagerID.DataSource = dtEmployeesByDept;
                cboManagerID.ValueMember = "EmployeeID";
                cboManagerID.DisplayMember = "EmpName";

                // TripPlanRequest Combobox Manager
                cmbTripRequestManager.DataSource = dtEmployeesByDept;
                cmbTripRequestManager.ValueMember = "EmployeeID";
                cmbTripRequestManager.DisplayMember = "EmpName";

                cboSalesPersonID.DataSource = userTbl;
                cboSalesPersonID.ValueMember = "EmployeeID";
                cboSalesPersonID.DisplayMember = "EmpName";

                a_p_Tbl = new PTIC.Common.APMaterialDAO().SelectAllWithAPSubCat();
                clnA_PID.DataSource = a_p_Tbl;
                clnA_PID.ValueMember = "AP_MaterialID";
                clnA_PID.DisplayMember = "APMaterialName";

                // To Check Isalready Issue?
                dtAPTransferList = new AP_TransferListBL().GetAll();

                // Load Product
                cmbNextTripProduct.DataSource = new ProductBL().GetAll();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }            
        }

        private void SaveTripPlanRequest()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                TripRequestBL tripRequestSaver = new TripRequestBL();

                TripRequest saveTripRequest = new TripRequest();
                saveTripRequest.TripPlanDetailID = (int)_mTripPlanDetail.ID;
                saveTripRequest.RoutePlanID = 0;
                saveTripRequest.TransportTypeID = (int)cmbTripRequestTranportType.SelectedValue;
                saveTripRequest.VenID =(int)DataTypeParser.Parse(cmbTripRequestVen.SelectedValue,typeof(int),0);
                saveTripRequest.ManagerID = (int)cboManagerID.SelectedValue;
                //SalesPersonID = (int)cboStaff1ID.SelectedValue;
                //SupporterID = (int)cboSupportStaffID.SelectedValue;
                saveTripRequest.TripPlanNo = "";
                saveTripRequest.ReqDate = dtpTripRequestDate.Value;
                saveTripRequest.FromDate = dtpRequestFromDate.Value;
                saveTripRequest.ToDate = dtpRequestToDate.Value;
                saveTripRequest.PrevTripName = cboTripID.SelectedValue.ToString();
                saveTripRequest.IsSaleDevice = chkCashMachine.Checked;
                saveTripRequest.IsVocher = chkVoucher.Checked;
                saveTripRequest.PersonCount = (int)DataTypeParser.Parse(udStaffNumber.Text, typeof(int), 0);
                saveTripRequest.SalesTargetAmt = Convert.ToDecimal(txtSalesGoal.Text);
                saveTripRequest.IsVen = chkVehicle.Checked;
                saveTripRequest.IsAcc = chkCashAccount.Checked;
                saveTripRequest.IsFac = chkFactory.Checked;
                saveTripRequest.IsAdm = chkManage.Checked;
                saveTripRequest.IsTab = chkSaleMachineInfo.Checked;
                saveTripRequest.IsBoard = chkBoard.Checked;
                saveTripRequest.Remark = "";
                saveTripRequest.COO = txtCOO.Text;
                saveTripRequest.MM = txtMM.Text;
                saveTripRequest.SM = txtSM.Text;
                saveTripRequest.isSale = (Program.module == Program.Module.Sale);
                saveTripRequest.ProductRequestIssueID = this.ProductRequestIssueID;
                saveTripRequest.AP_RequestID = this.AP_RequestID;


                int affectedRows = 0;
                if (TripRequestID == -1)
                {
                    affectedRows = tripRequestSaver.Add(saveTripRequest, EmployeesList, conn);
                }
                else
                {
                    saveTripRequest.ID = TripRequestID;
                    affectedRows = tripRequestSaver.UpdateAPRequestIDByTripRequestID(saveTripRequest, EmployeesList, conn);
                }

                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    TripRequestID = affectedRows;
                    LoadNBind();
                    LoadNBindTripDetailPlan();
                    LoadTripRequestPage();
                    //this.Close();
                }
            }
            catch (Exception sqle)
            {
                _logger.Error(sqle);
            }
        }

        private void SaveTripRecord()
        {
            TripRecordBL tripRecordSaver = null;
            TripRecord tripRecord = null;
            bool isSuccessful = false;
            try
            {
                tripRecordSaver = new TripRecordBL();
                tripRecord = new TripRecord()
                {
                    ID = this._tripRecordID,
                    TripPlanDetailID = (int)DataTypeParser.Parse(this._mTripPlanDetail.ID, typeof(int), -1),
                    ArrivedDate = (DateTime)DataTypeParser.Parse(dtpArrivedDate.Value, typeof(DateTime), DateTime.Now),
                    PrevDebitAmt = (decimal?)DataTypeParser.Parse(txtPrevDebitAmt.Text, typeof(decimal), null),
                    RentAmt = (decimal?)DataTypeParser.Parse(txtRentAmt.Text, typeof(decimal), null),
                    FoodAmt = (decimal?)DataTypeParser.Parse(txtFoodAmt.Text, typeof(decimal), null),
                    TransportAmt = (decimal?)DataTypeParser.Parse(txtTransportAmt.Text, typeof(decimal), null),
                    CommunicationAmt = (decimal?)DataTypeParser.Parse(txtCommunicationAmt.Text, typeof(decimal), null),
                    OtherExpense = (decimal?)DataTypeParser.Parse(txtOtherExpense.Text, typeof(decimal), null),
                    RemittanceAmt = (decimal?)DataTypeParser.Parse(txtRemittanceAmt.Text, typeof(decimal), null),
                    DebitConflictShop = (int?)DataTypeParser.Parse(txtDebitConflictShop.Text, typeof(int), null),
                    ShopWithoutOwnerSign = (int?)DataTypeParser.Parse(txtShopWithoutOwnerSign.Text, typeof(int), null),
                    CompetitorStatus = (string)DataTypeParser.Parse(txtCompetitorStatus.Text, typeof(string), null),
                    Complaint = (string)DataTypeParser.Parse(txtCustomerComplaint.Text, typeof(string), null),
                    //PossibleNextTripDate = (DateTime)DataTypeParser.Parse(, typeof(DateTime), DateTime.min),
                    MainProductID4NextTrip = (int?)DataTypeParser.Parse(cmbNextTripProduct.SelectedValue, typeof(int), null), // Product ID
                    SpecialCase = (string)DataTypeParser.Parse(txtSpecialCondition.Text, typeof(string), null),
                    Suggestion = (string)DataTypeParser.Parse(txtSuggestion.Text, typeof(string), null),
                    Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null)
                };
                if (dtpNextTripDate.Checked)
                    tripRecord.PossibleNextTripDate = (DateTime)DataTypeParser.Parse(dtpNextTripDate.Value, typeof(DateTime), DateTime.Now);
                if (tripRecord.TripPlanDetailID == -1)
                {
                    MessageBox.Show("Please reopen [Trip Detail] form because some of values are missing!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (tripRecord.ArrivedDate == DateTime.MinValue)
                {
                    MessageBox.Show("ပြန်ရောက်သည့်နေ့ ဖြည့်သွင်းပေးပါ။", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tripRecord.ID.HasValue) // Update
                {
                    if (tripRecordSaver.UpdateByID(tripRecord) > 0)
                        isSuccessful = true;
                }
                else // New
                {
                    this._tripRecordID = tripRecordSaver.Add(tripRecord);
                    if (this._tripRecordID.HasValue)
                        isSuccessful = true;
                }
                if (isSuccessful)
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.Green);
                else
                    MessageBox.Show(Resource.errFailedToSave, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private decimal CalculateTripRecordExpense()
        {
            decimal rentAmt = (decimal)DataTypeParser.Parse(txtRentAmt.Text, typeof(decimal), 0);
            decimal foodAmt = (decimal)DataTypeParser.Parse(txtFoodAmt.Text, typeof(decimal), 0);
            decimal transportAmt = (decimal)DataTypeParser.Parse(txtTransportAmt.Text, typeof(decimal), 0);
            decimal communicationAmt = (decimal)DataTypeParser.Parse(txtCommunicationAmt.Text, typeof(decimal), 0);
            decimal otherExpense = (decimal)DataTypeParser.Parse(txtOtherExpense.Text, typeof(decimal), 0);
            decimal remittanceAmt = (decimal)DataTypeParser.Parse(txtRemittanceAmt.Text, typeof(decimal), 0);

            return rentAmt + foodAmt + transportAmt + communicationAmt + otherExpense + remittanceAmt;
        }
        #endregion

        #region Constructors
        public frmTripDetailPlan()
        {
            InitializeComponent();
            // Set input field expression
            SetInputExpression();
            //Set Default values
            set_default();
            // Load necessary data
            LoadNBind();
        }

        public frmTripDetailPlan(TripPlan tripPlan, TripPlanDetail tripPlanDetail, bool requestFlag)
            : this()
        {
            if (requestFlag)
            {
                //(tabPage1 as Control).Enabled = false;
                (tabPage2 as Control).Enabled = false;
                //(tabPage4 as Control).Enabled = false;
            }




           
            this._mTripPlanDetail = tripPlanDetail;
            this._mTripPlan = tripPlan;
            LoadNBindTripDetailPlan();
            _mTripPlanDetail.TripID =(int) cboTripID.SelectedValue;

            if (this._mTripPlanDetail.TripID != 0) 
            {
                DataTable previousTripPlan = new TripPlanBL().GetPreviousTrip((Program.module==Program.Module.Sale),_mTripPlanDetail.TripID,_mTripPlanDetail.ID);
                if (previousTripPlan.Rows.Count == 1)
                {
                    txtPrevRent.Text = previousTripPlan.Rows[0]["RentAmt"].ToString();
                    txtPrevTransport.Text = previousTripPlan.Rows[0]["TransportAmt"].ToString();
                    txtPrevRemittance.Text = previousTripPlan.Rows[0]["RemittanceAmt"].ToString();
                    txtPrevCommunication.Text = previousTripPlan.Rows[0]["CommunicationAmt"].ToString();
                    txtPrevFood.Text = previousTripPlan.Rows[0]["FoodAmt"].ToString();
                    txtPrevOtherExp.Text = previousTripPlan.Rows[0]["OtherExpense"].ToString();
                }

            }

            
            LoadTripRequestPage();
            if (this._mTripPlanDetail.ID > 0)
            {
                LoadTripRecord();
            }// END of if (this._mTripPlanDetail.ID > 0)

        }
        #endregion

        private void LoadTripRecord() 
        {
            TripRecordBL tripRecordRetriever = new TripRecordBL();
            // Get trip plan target amount
            decimal targetAmt = new TripPlanTargetBL().GetTargetAmountByTripPlanDetailID(this._mTripPlanDetail.ID);
            txtSalesTarget.Text = targetAmt.ToString("N0");
            txtSalesGoal.Text = targetAmt.ToString("N0");

            // Get and set current TripRecord
            DataTable dtTripRecord = tripRecordRetriever.GetByTripPlanDetailID(this._mTripPlanDetail.ID);
            if (dtTripRecord != null && dtTripRecord.Rows.Count > 0)
            {
                DataRow row = dtTripRecord.Rows[0];
                this._tripRecordID = (int?)DataTypeParser.Parse(row["ID"], typeof(int), null);
                this.dtpArrivedDate.Value = (DateTime)DataTypeParser.Parse(row["ArrivedDate"], typeof(DateTime), DateTime.MinValue);
                this.txtPrevDebitAmt.Text = (string)DataTypeParser.Parse(row["PrevDebitAmt"], typeof(string), string.Empty);
                txtRentAmt.Text = (string)DataTypeParser.Parse(row["RentAmt"], typeof(string), string.Empty);
                txtFoodAmt.Text = (string)DataTypeParser.Parse(row["FoodAmt"], typeof(string), string.Empty);
                txtTransportAmt.Text = (string)DataTypeParser.Parse(row["TransportAmt"], typeof(string), string.Empty);
                txtCommunicationAmt.Text = (string)DataTypeParser.Parse(row["CommunicationAmt"], typeof(string), string.Empty);
                txtOtherExpense.Text = (string)DataTypeParser.Parse(row["OtherExpense"], typeof(string), string.Empty);
                txtRemittanceAmt.Text = (string)DataTypeParser.Parse(row["RemittanceAmt"], typeof(string), string.Empty);
                txtDebitConflictShop.Text = (string)DataTypeParser.Parse(row["DebitConflictShop"], typeof(string), string.Empty);
                txtShopWithoutOwnerSign.Text = (string)DataTypeParser.Parse(row["ShopWithoutOwnerSign"], typeof(string), string.Empty);
                txtCompetitorStatus.Text = (string)DataTypeParser.Parse(row["CompetitorStatus"], typeof(string), string.Empty);
                txtCustomerComplaint.Text = (string)DataTypeParser.Parse(row["Complaint"], typeof(string), string.Empty);
                dtpNextTripDate.Value = (DateTime)DataTypeParser.Parse(row["PossibleNextTripDate"], typeof(DateTime), DateTime.MinValue);
                cmbNextTripProduct.Text = (string)DataTypeParser.Parse(row["MainProductID4NextTrip"], typeof(string), string.Empty);
                txtSpecialCondition.Text = (string)DataTypeParser.Parse(row["SpecialCase"], typeof(string), string.Empty);
                txtSuggestion.Text = (string)DataTypeParser.Parse(row["Suggestion"], typeof(string), string.Empty);
                txtRemark.Text = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty);
            } // END of if (dtTripRecord != null && dtTripRecord.Rows.Count > 0)

            // Get and set previous TripRecord
            // TODO: Get previous TripRecord
            DataTable dtPrevTripRecord = tripRecordRetriever.GetPreviousRecordByTripPlanDetailID(this._mTripPlanDetail.ID);
            if (dtPrevTripRecord != null && dtPrevTripRecord.Rows.Count > 0)
            {
                dtPrevTripID.Visible = true;
                lblPrevTripDate.Visible = true;
                dtPrevTripDate.Visible = true;
                lblPrevTrip.Visible = true;
                DataRow prevRow = dtPrevTripRecord.Rows[0];
                DateTime arrivedDate = (DateTime)DataTypeParser.Parse("ArrivedDate", typeof(DateTime), DateTime.MinValue);
                if (arrivedDate != DateTime.MinValue)
                {
                    dtPrevTripID.Value = arrivedDate;
                    dtPrevTripDate.Value = arrivedDate;
                }
                txtPrevRent.Text = (string)DataTypeParser.Parse(prevRow["RentAmt"], typeof(string), string.Empty);
                txtPrevFood.Text = (string)DataTypeParser.Parse(prevRow["FoodAmt"], typeof(string), string.Empty);
                txtPrevTransport.Text = (string)DataTypeParser.Parse(prevRow["TransportAmt"], typeof(string), string.Empty);
                txtPrevCommunication.Text = (string)DataTypeParser.Parse(prevRow["CommunicationAmt"], typeof(string), string.Empty);
                txtPrevOtherExp.Text = (string)DataTypeParser.Parse(prevRow["OtherExpense"], typeof(string), string.Empty);
                txtPrevRemittance.Text = (string)DataTypeParser.Parse(prevRow["RemittanceAmt"], typeof(string), string.Empty);

            } // END of if (dtPrevTripRecord != null && dtPrevTripRecord.Rows.Count > 0)
        
        }
        private void LoadTripRequestPage() 
        {
            DataTable dtTmp = new TripRequestBL().GetAll();
            if (dtTmp.Rows.Count > 0)
            {
                dtTripRequestDetail = DataUtil.GetDataTableBy(dtTmp, "TripPlanDetailID", this._mTripPlanDetail.ID);
                if (dtTripRequestDetail != null)
                {
                    TripRequestID = (int)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["ID"], typeof(int), -1);
                    ProductRequestIssueID = (int?)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["ProductRequestIssueID"], typeof(int), null);
                    AP_RequestID = (int?)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["AP_RequestID"], typeof(int), null);
                    if (AP_RequestID != null)
                    {
                        btnAPRequest.Text = "ထုတ်ပေးမည်";
                    }
                    else if (alreadyIssued)
                    {
                        btnAPRequest.Text = "ထုတ်ပေးပြီး";
                    }

                    //  Binding Fields into TripRequest Form
                    cmbTripRequestTranportType.SelectedValue = (int)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["TransportTypeID"], typeof(int), -1);
                    cmbRequestVen.SelectedValue = (int)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["VenID"], typeof(int), -1);
                    dtpRequestFromDate.Value = (DateTime)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["FromDate"], typeof(DateTime), DateTime.Now);
                    // TripRecord 
                    txtGoDate.Text = dtpRequestFromDate.Value.ToShortDateString();

                    dtpRequestToDate.Value = (DateTime)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["ToDate"], typeof(DateTime), DateTime.Now);
                    dtpTripRequestDate.Value = (DateTime)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["ReqDate"], typeof(DateTime), DateTime.Now);
                    chkCashMachine.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsSaleDevice"], typeof(bool), false);
                    chkVoucher.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsVocher"], typeof(bool), false);
                    chkVehicle.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsVen"], typeof(bool), false);
                    udStaffNumber.Text = (string)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["PersonCount"].ToString(), typeof(string), string.Empty);

                    if (udStaffNumber.Text != string.Empty)
                    {
                        //  Bind Selected Employees

                        DataTable dtSelectedEmployees = new EmployeeDA().SelectAllByTripRequestID(TripRequestID);
                        string EmployeeName = string.Empty;
                        foreach (DataRow employee in dtSelectedEmployees.Rows)
                        {
                            // EmployeeName
                            EmployeeName += string.IsNullOrEmpty(employee["EmpName"].ToString()) ? string.Empty : employee["EmpName"].ToString() + ", \r\n";
                        }
                        EmployeeName = EmployeeName.Replace(",", ",");
                        int j = EmployeeName.LastIndexOf(',');
                        EmployeeName = EmployeeName.Remove(j);
                        txtEmployee.Text = EmployeeName;

                    }

                    chkCashAccount.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsAcc"], typeof(bool), false);
                    chkFactory.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsFac"], typeof(bool), false);
                    chkManage.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsAdm"], typeof(bool), false);
                    chkSaleMachineInfo.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsTab"], typeof(bool), false);
                    chkBoard.Checked = (bool)DataTypeParser.Parse(dtTripRequestDetail.Rows[0]["IsBoard"], typeof(bool), false);



                    //If HasTripRequest
                    btnTripRequest.Enabled = false;
                    butDelete.Visible = true;

                    // If HasProductRequestIssueID
                    btnRequestProduct.Enabled = true;
                    btnAPRequest.Enabled = true;
                }
            } // END of if (dtTmp.Rows.Count > 0)

        
        }
        private void btnRequestProduct_Click(object sender, EventArgs e)
        {
            ProductRequestIssue _ProductRequestIssue = new ProductRequestIssue()
            {
                ID = (int)DataTypeParser.Parse(this.ProductRequestIssueID, typeof(int), -1),
                RequestVenID = (int)DataTypeParser.Parse(cmbRequestVen.SelectedValue, typeof(int), -1),
                RequesterID = (int)DataTypeParser.Parse(cmbTripRequestManager.SelectedValue, typeof(int), -1)
            };

            frmProductRequestIssue _frmProductRequestIssue = new frmProductRequestIssue(_ProductRequestIssue);
            _frmProductRequestIssue.ProductRequestIssueSavedHandler += new frmProductRequestIssue.ProductRequestIssueSaveHandler(_frmProductRequestIssue_ProductRequestIssueSavedHandler);

            UIManager.OpenForm(_frmProductRequestIssue);
            SaveTripPlanRequest();
        }

        private void _frmProductRequestIssue_ProductRequestIssueSavedHandler(object sender, ProductRequestIssueEventArgs e)
        {
            //// TODO: update TripRequest...
            if (!this.ProductRequestIssueID.HasValue)
            {
                this.ProductRequestIssueID = e.ProductRequestIssueID;
                Save();
            }
        }

        private void cboManagerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManagerID.SelectedIndex != -1) 
            {
                int _managerId=(int)cboManagerID.SelectedValue;
                if (EmployeesList != null)
                {
                    try
                    {
                        Employee manager = EmployeesList.FirstOrDefault(emp => emp.ID == _managerId);
                        if (manager != null)
                            EmployeesList.Remove(manager);
                        numPersonCount.Text = EmployeesList.Count.ToString();
                    }
                    catch (Exception err) 
                    {
                    
                    }
                }
            
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                int affectedRows = new TripRequestBL().DeleteByTripRequestID(TripRequestID, conn);
                if (affectedRows == 1) 
                {
                    butDelete.Visible = false;
                    btnTripRequest.Enabled = true;

                    ResetCheckBoxForTripRequestTabPage();
                    LoadNBind();
                    TripRequestID = -1;
                    LoadNBindTripDetailPlan();
                    LoadTripRequestPage();
                 


                }
            }
            catch (Exception err) 
            {
            
            }
        }

        private void ResetCheckBoxForTripRequestTabPage() 
        {
            chkCashMachine.Checked = chkVoucher.Checked = chkVehicle.Checked = chkSaleMachineInfo.Checked = chkManage.Checked = chkFactory.Checked = chkCredit.Checked = chkConsignment.Checked = chkCashAccount.Checked = chkCash.Checked = chkBoard.Checked = false;
        }

    }
}
