/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: Delivery Plan form
 */
using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using log4net;
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Common.BL;
using PTIC.Sale.Order;
using log4net.Config;
using PTIC.Sale.BL;
using PTIC.Util;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Delivery
{
    public partial class frmDeliveryPlan : Form
    {
        /// <summary>
        /// Logger for frmDeliveryPlan
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmDeliveryPlan));
        
        private DataTable _dtUnplannedOrders = null;

        #region Events
        private void dgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvUnplannedOrders.Rows)
            {
                if ((bool)DataTypeParser.Parse(row.Cells["colIsDelivered"].Value, typeof(bool), false))
                    row.Cells["colStatus"].Value = Resource.Delivered; // NO NEED
                else
                    row.Cells["colStatus"].Value = Resource.NotPlanned;
            }

            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvUnplannedOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //var dgv = sender as DataGridView;
            //string RouteName = (string)DataTypeParser.Parse(dgv.CurrentRow.Cells[colRouteName.Index].Value, typeof(string), String.Empty);

            //if ((string)DataTypeParser.Parse(dgv.CurrentRow.Cells[colRouteName.Index].Value, typeof(string), String.Empty) != string.Empty)
            //{
            //    cmbTransportType.SelectedValue = (int)PTIC.Common.Enum.PredefinedTransportType.VanID;
            //    cmbTransportGate.Enabled = false;
            //}
            //else
            //{
            //    //cmbTransportGate.SelectedIndex = -1;
            //    cmbTransportType.SelectedValue = (int)PTIC.Common.Enum.PredefinedTransportType.ExpressID;
            //    cmbTransportGate.Enabled = true;
            //}
            //object selectedOrderID = null;
            //if ((selectedOrderID = dgv.Rows[e.RowIndex].Cells["colOrderID"].Value) != null)
            //{
            //    int orderID = (int)DataTypeParser.Parse(selectedOrderID, typeof(int), -1);
            //    if (orderID != -1)
            //    {
            //        // load order details
            //        LoadNBindOrderDetailsByOrderID(orderID);
            //    }
            //}
        }

        private void dgvUnplannedOrders_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
                return;
            if ((string)DataTypeParser.Parse(dgv.CurrentRow.Cells[colRouteName.Index].Value, typeof(string), String.Empty) != string.Empty)
            {
                cmbTransportType.SelectedValue = (int)PTIC.Common.Enum.PredefinedTransportType.VanID;
                cmbTransportGate.Enabled = false;
            }
            else
            {
                cmbTransportType.SelectedValue = (int)PTIC.Common.Enum.PredefinedTransportType.ExpressID;
                cmbTransportGate.Enabled = true;
            }
            object selectedOrderID = null;
            if ((selectedOrderID = dgv.Rows[dgv.CurrentRow.Index].Cells["colOrderID"].Value) != null)
            {
                int orderID = (int)DataTypeParser.Parse(selectedOrderID, typeof(int), -1);
                if (orderID != -1)
                {
                    // load order details
                    LoadNBindOrderDetailsByOrderID(orderID);
                }
            }
        }

        private void dgvOrderDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dgvOrderDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colQty.Index || e.ColumnIndex == colProductName.Index || e.ColumnIndex == colRemark.Index || e.ColumnIndex == colDeliveryQty.Index)
            {
                int orderQty = (int)DataTypeParser.Parse(dgvOrderDetails.CurrentRow.Cells[colQty.Index].Value, typeof(int), 0);
                int deliverQty = (int)DataTypeParser.Parse(dgvOrderDetails.CurrentRow.Cells[colDeliveryQty.Index].Value, typeof(int), 0);

                if (deliverQty > orderQty)
                {
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = "Delivery Quantity is Invalid!";
                    MessageBox.Show("Delivery Quantity is Invalid!");
                    dgvOrderDetails.CurrentRow.Cells[colDeliveryQty.Index].Value = 0;
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = "";
                }
                else
                {
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = "";
                }
            }
        }

        private void dgvOrderDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvOrderDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == colDeliveryQty.Index)
            {
                int newInteger;
                if (dgvOrderDetails.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = "Quantity must not be empty!";
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = "Quantity must be integer!";
                    MessageBox.Show(Resource.errQtyMustBeInt);
                    dgvOrderDetails.CurrentRow.Cells[colDeliveryQty.Index].Value = 0;
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = string.Empty;
                }
                else
                {
                    dgvOrderDetails.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? salesPersonID = (int?)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int),-1); // Grid Employee
            DateTime deliveryDate = (DateTime)DataTypeParser.Parse(dtpDeliveryDate.Value, typeof(DateTime), DateTime.Now); // Grid DeliveryDate
            int VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1); // Grid VenID
            
            // DeliveryPlan Get By Date
            DataTable dtDeliveryPlanByDate = new DeliveryBL().GetPlannedBy(null, null, deliveryDate, deliveryDate);
            if(dtDeliveryPlanByDate == null)return;
            // DeliveryPlan Get By SalesPersonID and Date
            DataTable dtDelvieryPlanBy = new DeliveryBL().GetPlannedBy(salesPersonID, null, deliveryDate, deliveryDate);
            if (dtDelvieryPlanBy == null) return;

            foreach (DataRow row in dtDeliveryPlanByDate.Rows)
            {
                int dtVenIDByDate = (int)DataTypeParser.Parse(row["VenID"], typeof(int), -1);
                int dtSalesPersonIDByDate = (int)DataTypeParser.Parse(row["SalesPersonID"], typeof(int), -1);
                if (dtVenIDByDate == VenID && dtSalesPersonIDByDate != salesPersonID)
                {
                    MessageBox.Show("ရွေးချယ်ထားသော ကားအမှတ် '" + (string)DataTypeParser.Parse(row["VenNo"], typeof(string), -1) + "' ကို '" + (string)DataTypeParser.Parse(dtpDeliveryDate.Value.ToShortDateString(), typeof(string), -1) + "' နေ့အတွက် စီစဉ်ထားပြီးဖြစ်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                }
            }

            //------------------------------------- Employee and Ven -----------------------------------------//
            //foreach (DataRow r in dtDelvieryPlanBy.Rows)
            //{
            //    int dtSalesPersonID = (int)DataTypeParser.Parse(r["SalesPersonID"], typeof(int), -1);
            //    DateTime dtDeliveryDate = (DateTime)DataTypeParser.Parse(r["DeliveryDate"], typeof(DateTime), DateTime.Now);
            //    int dtVenID = (int)DataTypeParser.Parse(r["VenID"], typeof(int), -1);
            //    if (dtSalesPersonID == SalesPersonID && dtDeliveryDate.Date == DeliveryDate.Date && dtVenID != VenID)
            //    {
            //        MessageBox.Show("ဝန်ထမ်းတစ်ဦးအတွက် ကားနှစ်စီး စီစဉ်ခွင့်မရှိပါ။", 
            //            "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
            //        return;
            //    }
            //}

            if (MessageBox.Show("ပို့ရန်စီစဉ်ရန် သေချာပါသလား?", 
                "Delivery Plan", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Save orders to be planned or order lost
                
                Save();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (DataGridViewRow row in dgvOrderDetails.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvOrderDetails.Rows.RemoveAt(row.Index);
            }
        }
                
        private void lblDelivery_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                pnlFilter.Visible = true;

                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            if (this._dtUnplannedOrders == null)
                return;

            string kwCustomer = txtKW_Customer.Text.Trim();
            string kwOrderNo = txtKW_OrderNo.Text.TrimEnd();
            string filterString = "@CusName@OrderNo@OrderDate";            
            DataView dv = this._dtUnplannedOrders.AsDataView();
                        
            if (string.IsNullOrEmpty(kwCustomer) && string.IsNullOrEmpty(kwOrderNo) && !dtp_KW_OrderDate.Checked) // All key blank
            {
                dgvUnplannedOrders.DataSource = null;
                dgvOrderDetails.DataSource = null;
                return;
            }
            else if (!string.IsNullOrEmpty(kwCustomer) && !string.IsNullOrEmpty(kwOrderNo) && dtp_KW_OrderDate.Checked) // All key exist
                filterString = string.Format(@"CusName LIKE '%{0}%' AND OrderNo LIKE '%{1}%' AND OrderDate>=#{2}# and OrderDate<=#{3}# ",
                    kwCustomer, kwOrderNo, dtp_KW_OrderDate.Value,dateTimePicker1.Value.Date);
            else // some keys exist
            {
                if (!string.IsNullOrEmpty(kwCustomer))
                    filterString = filterString.Replace("@CusName", string.Format("AND CusName LIKE '%{0}%'", kwCustomer));
                else
                    filterString = filterString.Replace("@CusName", string.Empty);

                if (!string.IsNullOrEmpty(kwOrderNo))
                    filterString = filterString.Replace("@OrderNo", string.Format("AND OrderNo LIKE '%{0}%'", kwOrderNo));
                else
                    filterString = filterString.Replace("@OrderNo", string.Empty);

                if (dtp_KW_OrderDate.Checked)
                    filterString = filterString.Replace("@OrderDate", string.Format("AND OrderDate>=#{0}# and OrderDate<=#{1}#", dtp_KW_OrderDate.Value.Date,dateTimePicker1.Value.Date));
                else
                    filterString = filterString.Replace("@OrderDate", string.Empty);

                filterString = filterString.Substring(4);
            }
            
            dv.RowFilter = filterString;
            dgvUnplannedOrders.DataSource = dv;
            // If there is no record found, clear detail also
            if (dv.Count < 1)
                dgvOrderDetails.DataSource = null;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (this._dtUnplannedOrders == null)
                return;
            dgvUnplannedOrders.DataSource = this._dtUnplannedOrders;
        }

        private void cmbTransportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)DataTypeParser.Parse(cmbTransportType.SelectedValue, typeof(int), -1) == 5)
            {
                cmbTransportGate.Enabled = false;
                cmbTransportGate.SelectedValue = -1;
            }
            else
            {
                cmbTransportGate.Enabled = true;
            }
        }

        private void btnOrderLost_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(Resource.msg_qst_lost_order, 
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == System.Windows.Forms.DialogResult.Yes)
                OrderLost();
        }
        #endregion

        #region Private Methods
        private void LoadNBind()
        {            
            DataSet ds = null;
            BindingSource bdTransportType = null;
            BindingSource bdTransportGate = null;
            try
            {                
                ds = new DataSet();

                bdTransportType = new BindingSource();
                bdTransportGate = new BindingSource();

                // Load employees
                List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
                Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                queryBuilder.Add(tpSales);
                queryBuilder.Add(tpMk);                                
                cmbSalePerson.DataSource = DataUtil.GetDataTableByOR(new EmployeeBL().GetAll(), queryBuilder);

                // Load vehicles
                cmbVehicle.DataSource = new VehicleBL().GetAll();

                /* Load transport type and transport gate */
                DataTable dtTransportType = new TransportTypeBL().GetAll();
                DataTable dtTransportGate = new TransportGateBL().GetAll();

                ds.Tables.Add(dtTransportType);
                ds.Tables.Add(dtTransportGate);

                DataRelation relType_Gate = new DataRelation("Type_Gate", dtTransportType.Columns["TransportTypeID"], dtTransportGate.Columns["TransportTypeID"]);
                ds.Relations.Add(relType_Gate);

                bdTransportType.DataSource = ds;
                bdTransportType.DataMember = dtTransportType.TableName;

                bdTransportGate.DataSource = bdTransportType;
                bdTransportGate.DataMember = "Type_Gate";

                cmbTransportType.DataSource = bdTransportType;
                cmbTransportGate.DataSource = bdTransportGate;
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

        private void LoadNBindUnplannedOrders()
        {            
            try
            {                
                // Get undelivered orders
                this._dtUnplannedOrders = new OrderBL().GetOrderListing();
                //this._dtUnplannedOrders = new OrderBL().GetUndelivered();
                dgvUnplannedOrders.DataSource = this._dtUnplannedOrders;
                // Clear order detail
                dgvOrderDetails.DataSource = null;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show("Cannot load data! " + e.Message, this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        /// <summary>
        /// Load and bind order details by order id
        /// </summary>
        /// <param name="orderID"></param>
        private void LoadNBindOrderDetailsByOrderID(int orderID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                using (DataTable tblOrderDetails = new OrderDetailBL().GetByOrderID(orderID))
                {
                    dgvOrderDetails.DataSource = tblOrderDetails;
                }
                dgvDliveryHistory.AutoGenerateColumns = false;
                DataTable tblDeliveryHistory = new OrderBL().GetDelieveryHistory(orderID);
                dgvDliveryHistory.DataSource = tblDeliveryHistory;
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

        private void LoadNBindOrderByOrderNo(string orderNo)
        {            
            try
            {                
                using (DataTable tblOrderDetails = new OrderBL().GetByOrderNo(orderNo))
                {
                    dgvOrderDetails.DataSource = tblOrderDetails;
                }

                
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }            
        }

        /// <summary>
        /// Load and bind order details by order no
        /// </summary>
        /// <param name="orderNo"></param>
        private void LoadNBindOrderDetailsByOrderNo(string orderNo)
        {            
            try
            {                
                using (DataTable tblOrderDetails = new OrderDetailBL().GetByOrderNo(orderNo))
                {
                    dgvOrderDetails.DataSource = tblOrderDetails;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }            
        }

        /// <summary>
        /// Save Order as planned or lost
        /// </summary>
        private void Save()
        {
            if(dgvUnplannedOrders.Rows.Count < 1)
            {
                MessageBox.Show("Order မရှိသေး၍ စီစဉ်၍ မရနိုင်ပါ။", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (dgvUnplannedOrders.CurrentRow == null)
            {
                MessageBox.Show("Order ကို ရွေးချယ်ပေးပါရန်။", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DeliveryBL deliverySaver = null;
            Entities.Delivery newDelivery = null;
            try
            {                
                deliverySaver = new DeliveryBL();
                newDelivery = new Entities.Delivery()
                {
                    OrderID = (int)DataTypeParser.Parse(dgvUnplannedOrders.CurrentRow.Cells["colOrderID"].Value, typeof(int), -1),
                    VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1),
                    SalesPersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1),
                    TransportTypeID = (int)DataTypeParser.Parse(cmbTransportType.SelectedValue, typeof(int), -1),
                    GateID = (int?)DataTypeParser.Parse(cmbTransportGate.SelectedValue, typeof(int), null),
                    //DeliveryNo = (string)DataTypeParser.Parse(txtDeliveryNo.Text, typeof(string), string.Empty),
                    DeliveryDate = (DateTime)DataTypeParser.Parse(dtpDeliveryDate.Value, typeof(DateTime), DateTime.Now),
                    Status = false, // Flag indicating 'planned'
                    /* Set default */
                    IsMain = false,
                    IsDevice = false,
                };
                List<DeliveryDetail> newDeliveryDetails = new List<DeliveryDetail>();
                foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                {
                    if (row.IsNewRow)
                        break;
                    DeliveryDetail newDeliveryDetail = new DeliveryDetail()
                    {
                        ProductID = (int)DataTypeParser.Parse(row.Cells["colProductID"].Value, typeof(int), -1),
                        OrderQty = (int)DataTypeParser.Parse(row.Cells["colQty"].Value, typeof(int), 0),
                        DeliverQty = (int)DataTypeParser.Parse(row.Cells["colDeliveryQty"].Value, typeof(int), 0)
                    };
                    newDeliveryDetails.Add(newDeliveryDetail);
                }
                // If delivery qty of all rows is less than or equal to zero, save as order lost if confirmed = YES
                int totalDeliveryQty = 0;
                foreach (DeliveryDetail detail in newDeliveryDetails)                
                    totalDeliveryQty += detail.DeliverQty;
                if (totalDeliveryQty <= 0)
                {
                    if (
                    MessageBox.Show("ပို့ရမည့် အရေအတွက်မရှိသောကြောင့် ဘောက်ချာတစ်ခုလုံးကို မပို့နိုင်သော Order စာရင်းသို့ ပေးပို့လိုပါသလား?",
                        this.Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    { 
                        // Save as order lost
                        deliverySaver.ToOrderLost(newDelivery, newDeliveryDetails);
                        // Show successful message
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        // Reload unplanned orders
                        LoadNBindUnplannedOrders();
                    }
                    return;
                }


                // Check is there any outstanding delivery plan
                DateTime deliveryPlanDate = new DateTime ();
                string deliveryPlanNo=string.Empty;
                if(deliverySaver.IsAlreadyPlanIsAlreadyPlan(newDelivery.OrderID,out deliveryPlanDate,out deliveryPlanNo))
                {
                    MessageBox.Show(string.Format("This Plan is Already Plan with Delivery Plan No {0} on {1}!",deliveryPlanNo,deliveryPlanDate.ToShortDateString()));
                    return;
                }

                // Save order as planned
                deliverySaver.Add(newDelivery, newDeliveryDetails);
                // Check field validation is successful or not
                if (!deliverySaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(deliverySaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "Error",                        
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else // Success
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    // Reload unplanned orders
                    LoadNBindUnplannedOrders();
                }                                        
            }
            catch (Exception e)
            {
                MessageBox.Show(
                        e.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                _logger.Error(e);
            }            
        }

        private void OrderLost()
        {
            DeliveryBL deliverySaver = null;
            Entities.Delivery newDelivery = null;

            try
            {
                deliverySaver = new DeliveryBL();
                newDelivery = new Entities.Delivery()
                {
                    OrderID = (int)DataTypeParser.Parse(dgvUnplannedOrders.CurrentRow.Cells[colOrderID.Index].Value, typeof(int), -1),
                    VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1),
                    SalesPersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1),
                    TransportTypeID = (int)DataTypeParser.Parse(cmbTransportType.SelectedValue, typeof(int), -1),
                    GateID = (int?)DataTypeParser.Parse(cmbTransportGate.SelectedValue, typeof(int), null),                    
                    DeliveryDate = (DateTime)DataTypeParser.Parse(dtpDeliveryDate.Value, typeof(DateTime), DateTime.Now),                    
                    /* Set default */
                    IsMain = false,
                    IsDevice = false,
                };
                List<DeliveryDetail> newDeliveryDetails = new List<DeliveryDetail>();
                foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                {
                    if (row.IsNewRow)
                        break;
                    DeliveryDetail newDeliveryDetail = new DeliveryDetail()
                    {
                        ProductID = (int)DataTypeParser.Parse(row.Cells[colProductID.Index].Value, typeof(int), -1),
                        OrderQty = (int)DataTypeParser.Parse(row.Cells[colQty.Index].Value, typeof(int), 0),                        
                    };
                    newDeliveryDetails.Add(newDeliveryDetail);
                }
                // Save as order lost
                deliverySaver.ToOrderLost(newDelivery, newDeliveryDetails);
                // Show successful message
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                // Reload unplanned orders
                LoadNBindUnplannedOrders();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Constructor
        public frmDeliveryPlan()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Disable auto-generating columns
            dgvUnplannedOrders.AutoGenerateColumns = false;
            dgvOrderDetails.AutoGenerateColumns = false;
            // Load and bind necessary data
            LoadNBind();
            // Load and bind underlivered orders and others
            LoadNBindUnplannedOrders();
            //txtKW_Customer.AutoCompleteCustomSource  = 
        }

        public frmDeliveryPlan(string orderNo)
            : this()
        {
            // Load just one order
            LoadNBindOrderByOrderNo(orderNo);
            // Load order detail by order no
            LoadNBindOrderDetailsByOrderNo(orderNo);
        }
        #endregion
                                               
    }
}
