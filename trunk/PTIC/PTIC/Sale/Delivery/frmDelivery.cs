/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: Delivery form
 */
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
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.Common.BL;
using PTIC.Sale.Entities;
using PTIC.Sale.Setup;
using PTIC.Sale.Order;
using log4net.Config;
using PTIC.VC.Sale.OfficeSales;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Sale.Delivery;

namespace PTIC.Sale.Delivery
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDelivery : Form
    {
        /// <summary>
        /// Logger for frmDelivery
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmDelivery));

        bool IsMasterNull = false;

        #region Events
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker && sender != null)
            {
                dtpStartDate.Checked = dtpEndDate.Checked = (sender as DateTimePicker).Checked;
            }
        }

        private void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
            {
                cmbEmployee.Enabled = (sender as CheckBox).Checked;
            }
        }

        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
            {
                cmbCustomer.Enabled = (sender as CheckBox).Checked;
            }
        }

        private void dgvUndeliveredOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPlannedDelivery.Rows)
            {
                if ((bool)DataTypeParser.Parse(row.Cells["colIsDelivered"].Value, typeof(bool), false))
                    row.Cells["colStatus"].Value = Resource.Delivered; // NO NEED
                else
                    row.Cells["colStatus"].Value = Resource.Planned;
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

        private void dgvUndeliveredOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //var dgv = sender as DataGridView;

            //// Clear delivery no
            //txtDeliveryNo.Clear();
            //object selectedDeliveryID = null;
            ////if ((selectedOrderID = dgv.Rows[e.RowIndex].Cells["colOrderID"].Value) != null)
            //if ((selectedDeliveryID = dgv.Rows[e.RowIndex].Cells["colDeliveryID"].Value) != null)
            //{
            //    int deliveryID = (int)DataTypeParser.Parse(selectedDeliveryID, typeof(int), -1);
            //    if (deliveryID != -1)
            //    {
            //        // Set delivery no
            //        txtDeliveryNo.Text = (string)DataTypeParser.Parse(dgv.Rows[e.RowIndex].Cells["colDeliveryNo"].Value, typeof(string), string.Empty);
            //        // load delivery details
            //        LoadNBindDeliveryDetailsByDeliveryID(deliveryID);
            //    }
            //}
        }

        private void dgvDeliveryDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvPlannedDelivery_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)           
                return;
           
            object selectedDeliveryID = null;
            if ((selectedDeliveryID = dgv.Rows[dgv.CurrentRow.Index].Cells["colDeliveryID"].Value) != null)
            {
                int deliveryID = (int)DataTypeParser.Parse(selectedDeliveryID, typeof(int), -1);
                if (deliveryID != -1)
                {
                    // Set selected delivery info                    
                    txtDeliveryNo.Text = (string)DataTypeParser.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[colDeliveryNo.Index].Value, typeof(string), string.Empty);
                    dtpDeliveryDate.Value = (DateTime)DataTypeParser.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[colDeliveryDate.Index].Value, typeof(DateTime), DateTime.Now);
                    cmbVehicle.SelectedValue = (int)DataTypeParser.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[colVenID.Index].Value, typeof(int), -1);
                    cmbSalePerson.SelectedValue = (int)DataTypeParser.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[colSalePersonID.Index].Value, typeof(int), -1);
                    //cmbTransportType.SelectedValue = (int)DataTypeParser.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells[].Value, typeof(string), -1);

                    if (IsMasterNull)
                    {
                        // load delivery details
                        // TODO: if master is null, just clear detail record and no need to load details from db
                        LoadNBindDeliveryDetailsByDeliveryID(-1);
                    }
                    else
                    {
                        // load delivery details
                        LoadNBindDeliveryDetailsByDeliveryID(deliveryID);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvPlannedDelivery.CurrentRow == null)
                return;
            int VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1);

            foreach (DataGridViewRow row in dgvDeliveryDetails.Rows)
            {
                int ProductID = (int)DataTypeParser.Parse(dgvDeliveryDetails.Rows[row.Index].Cells[colProductID.Index].Value, typeof(int), -1);
                int Qty = (int)DataTypeParser.Parse(dgvDeliveryDetails.Rows[row.Index].Cells[colDeliveryQty.Index].Value, typeof(int), -1);
                string ProductName = (string)DataTypeParser.Parse(dgvDeliveryDetails.Rows[row.Index].Cells[colProductName.Index].Value, typeof(string), string.Empty);
                //  Checing Stock In hand or Not in Vehicle
                DataTable dtStockInVehicle = new DeliveryBL().GetStockInVehicle(VenID, ProductID);
                if (dtStockInVehicle.Rows.Count <= 0)
                {
                    MessageBox.Show("စီစဉ်ထားသောကားပေါ်တွင်လက်ကျန်မရှိပါ။ Delivery Note ဖြင့်တောင်းယူပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (Qty > (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1))
                {
                    MessageBox.Show("လက်ကျန်မလုံလောက်ပါ။ ယခုကားပေါ်တွင် '" + ProductName + " ' လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            string DeliveryNo = (string)DataTypeParser.Parse(dgvPlannedDelivery.CurrentRow.Cells["colDeliveryNo"].Value, typeof(string), null);
            frmInvoice frmInv = new frmInvoice(DeliveryNo, VenID);
            // Set call back handler
            frmInv.InvoiceSavedHandler += new frmInvoice.InvoiceSaveHandler(frmInv_InvoiceSavedHandler);
            // Open from frmInvoice
            UIManager.OpenForm(frmInv);
        }

        private void frmInv_InvoiceSavedHandler(object sender, frmInvoice.InvoiceSaveEventArgs e)
        {
            if (e.OccuredChanges) // After delivered
            {
                // Reload 
                LoadNBind();
                // Clear detail grid
                dgvDeliveryDetails.DataSource = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (DataGridViewRow row in dgvDeliveryDetails.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvDeliveryDetails.Rows.RemoveAt(row.Index);
            }
        }

        private void lblDelivery_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }
        #endregion

        #region Private Methods
        private void LoadNBind()
        {
            DataSet ds = null;
            BindingSource bdTransportType = null;
            BindingSource bdTransportGate = null;
            DataTable dtEmployee = null;
            try
            {

                ds = new DataSet();
                bdTransportType = new BindingSource();
                bdTransportGate = new BindingSource();
                // Get planned orders (Status : 0)
                dgvPlannedDelivery.DataSource = new DeliveryBL().GetPlanned();
                if (dgvPlannedDelivery.Rows.Count < 1 || dgvPlannedDelivery == null) return;
                // Load employees
                dtEmployee = new EmployeeBL().GetAll();
                cmbSalePerson.DataSource = dtEmployee;

                if (dgvPlannedDelivery.CurrentRow != null && dgvPlannedDelivery.CurrentRow.Index > -1)
                    cmbSalePerson.SelectedValue = (int)DataTypeParser.Parse(dgvPlannedDelivery.CurrentRow.Cells["colSalePersonID"].Value, typeof(int), -1);
                // Load vehicles
                cmbVehicle.DataSource = new VehicleBL().GetAll();
                if (dgvPlannedDelivery.CurrentRow != null && dgvPlannedDelivery.CurrentRow.Index > -1)
                    cmbVehicle.SelectedValue = (int)DataTypeParser.Parse(dgvPlannedDelivery.CurrentRow.Cells["colVenID"].Value, typeof(int), -1);

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

                // Load and bind employees only from Sales and Marketing departments
                List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
                Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                queryBuilder.Add(tpSales);
                queryBuilder.Add(tpMk);
                //cmbEmployee.DataSource = DataUtil.GetDataTableByOR(new EmployeeBL().GetAll(), queryBuilder);
                cmbEmployee.DataSource = DataUtil.GetDataTableByOR(dtEmployee, queryBuilder);
                // Load and bind customers
                DataTable dtCustomer = new CustomerBL().GetAll();
                cmbCustomer.DataSource = dtCustomer;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        /// <summary>
        /// Load and bind order details by order id
        /// </summary>
        /// <param name="orderID"></param>
        private void LoadNBindDeliveryDetailsByDeliveryID(int deliveryID)
        {
            try
            {
                using (DataTable tblDeliveryDetails = new DeliveryDetailBL().GetByDeliveryID(deliveryID))
                {
                    dgvDeliveryDetails.DataSource = tblDeliveryDetails;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
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
                    dgvDeliveryDetails.DataSource = tblOrderDetails;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNo"></param>
        private void LoadNBindOrderByOrderNo(string orderNo)
        {
            try
            {
                using (DataTable tblOrderDetails = new OrderBL().GetByOrderNo(orderNo))
                {
                    dgvPlannedDelivery.DataSource = tblOrderDetails;
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save_bak()
        {
            DeliveryBL deliverySaver = null;
            Entities.Delivery newDelivery = null;
            try
            {
                deliverySaver = new DeliveryBL();
                newDelivery = new Entities.Delivery()
                {
                    OrderID = (int)DataTypeParser.Parse(dgvPlannedDelivery.CurrentRow.Cells["colOrderID"].Value, typeof(int), -1),
                    VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1),
                    SalesPersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1),
                    TransportTypeID = (int)DataTypeParser.Parse(cmbTransportType.SelectedValue, typeof(int), -1),
                    GateID = (int)DataTypeParser.Parse(cmbTransportGate.SelectedValue, typeof(int), -1),
                    //DeliveryNo = (string)DataTypeParser.Parse(txtDeliveryNo.Text, typeof(string), string.Empty),
                    DeliveryDate = (DateTime)DataTypeParser.Parse(dtpDeliveryDate.Value, typeof(DateTime), DateTime.Now),
                    Status = true, // Flag indicating 'delivered'
                    /* Set default */
                    IsMain = false,
                    IsDevice = false,
                };
                List<DeliveryDetail> newDeliveryDetails = new List<DeliveryDetail>();
                foreach (DataGridViewRow row in dgvDeliveryDetails.Rows)
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
                // add new order and details
                if (deliverySaver.Add(newDelivery, newDeliveryDetails) > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
        }
        #endregion

        #region Constructors
        public frmDelivery()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Disable auto-generating columns
            dgvPlannedDelivery.AutoGenerateColumns = false;
            dgvDeliveryDetails.AutoGenerateColumns = false;

            // Load and bind underlivered orders and others
            LoadNBind();
        }

        public frmDelivery(string orderNo)
            : this()
        {
            // Load just one order
            LoadNBindOrderByOrderNo(orderNo);
            // Load order detail by order no
            LoadNBindOrderDetailsByOrderNo(orderNo);
        }
        #endregion

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            DataTable dtDeliveryPlan = new DeliveryBL().GetPlanned();
            if (dtDeliveryPlan == null) return;
            dgvPlannedDelivery.DataSource = dtDeliveryPlan;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? salesPersonID = null;
            int? customerID = null;
            DateTime? startDate = null;
            DateTime? endDate = null;
            if(chkEmployee.Checked)
                salesPersonID = (int?)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), null);
            if(chkCustomerName.Checked)
                customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (dtpStartDate.Checked && dtpEndDate.Checked)
            {
                startDate = (DateTime?)DataTypeParser.Parse(dtpStartDate.Value, typeof(DateTime), null);
                endDate = (DateTime?)DataTypeParser.Parse(dtpEndDate.Value, typeof(DateTime), null);
            }

            DataTable dtDelvieryPlanBy = new DeliveryBL().GetPlannedBy(salesPersonID, customerID, startDate, endDate);
            if (dtDelvieryPlanBy == null) 
                return;
            if (dtDelvieryPlanBy.Rows.Count > 0)
            {
                IsMasterNull = false;
            }
            else
            {
                IsMasterNull = true;
            }
            dgvPlannedDelivery.DataSource = dtDelvieryPlanBy;
        }

        private void btnDeliveryNote_Click(object sender, EventArgs e)
        {
            List<PTIC.Sale.Entities.Delivery> deliveryList = new List<Entities.Delivery>();
            if(dgvPlannedDelivery == null)return;
            if(dgvPlannedDelivery.Rows.Count <=0)return;

            int SalesPersonID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1);
            int VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1);
            if (SalesPersonID == -1) return;
            DateTime DeliveryDate = (DateTime)DataTypeParser.Parse(dtpDeliveryDate.Value, typeof(DateTime), DateTime.Now);

            foreach (DataGridViewRow row in dgvPlannedDelivery.Rows)
            {
                DateTime gridDeliveryDate = (DateTime)DataTypeParser.Parse(row.Cells[colDeliveryDate.Index].Value, typeof(DateTime), -1);

                PTIC.Sale.Entities.Delivery delivery = new Entities.Delivery();
                delivery.ID = (int)DataTypeParser.Parse(row.Cells[colDeliveryID.Index].Value, typeof(int), -1);
                if (SalesPersonID == (int)DataTypeParser.Parse(row.Cells[colSalePersonID.Index].Value, typeof(int), -1)
                    && VenID == (int)DataTypeParser.Parse(row.Cells[colVenID.Index].Value, typeof(int), -1)
                    && DeliveryDate.Date == gridDeliveryDate.Date)
                {
                    deliveryList.Add(delivery);
                }
            }

            frmDeliveryNote _frmDelveryNote = new frmDeliveryNote(SalesPersonID, DeliveryDate,VenID,deliveryList);
            UIManager.OpenForm(_frmDelveryNote);
            LoadNBind();
        }
                
    }
}
