using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.Entities;
using PTIC.Sale.BL;
using PTIC.Common.BL;
using PTIC.Sale.Delivery;
using PTIC.Sale.Setup;
using PTIC.VC.Validation;
using PTIC.VC.Sale.Setup;
using log4net;
using System.Drawing;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmInvoice : Form
    {
        /// <summary>
        /// Logger for frmInvoice
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmInvoice));

        /// <summary>
        /// Record table for different Proudcts
        /// </summary>
        private DataTable _dtProduct = null;

        /// <summary>
        /// Index of Brand column from DataGridView
        /// </summary>
        private int _indexBrandColumn = -1;

        /// <summary>
        /// Index of Product column from DataGridView
        /// </summary>
        private int _indexProductColumn = -1;

        /// <summary>
        /// ComboBox shown in grid column Product
        /// </summary>
        private ComboBox _cmbProduct = null;     


        /// <summary>
        /// Product prices table
        /// </summary>
        //private DataTable _dtProductPrices = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeliveryNo"></param>
        private string _DeliveryNo = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void InvoiceSaveHandler(object sender, InvoiceSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event InvoiceSaveHandler InvoiceSavedHandler;

        DataTable InvoiceTbl = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name = DeliveryID></param>
        public int? DeliveryID = null;

        DataTable dtSubStore = null;

        DataTable dtVen = null;

        int VenID = 0;
        int WarehouseID = 0;

        bool FromDelivery = false; // From Delviery

        public frmInvoice()
        {
            InitializeComponent();
            dgvInvoice.AutoGenerateColumns = false;
            cmbTown.Enabled = true;
            cmbCustType.Enabled = true;
            // this._DeliveryNo = DeliveryNo;
            this._indexBrandColumn = dgvInvoice.Columns.IndexOf(dgvInvoice.Columns["clnBrandName"]);
            this._indexProductColumn = dgvInvoice.Columns.IndexOf(dgvInvoice.Columns["clnProductName"]);
            LoadNBind();
            btnCancel.Enabled = true;
            dgvInvoice.DataSource = InvoiceTbl;
            DataUtil.AddInitialNewRow(dgvInvoice);
            dtSubStore = new WarehouseBL().GetAllSubStore();
            rdoVenNo.Checked = true;
        }

        public frmInvoice(string DeliveryNo,int VenID)
        {
            InitializeComponent();
            cmbTown.Enabled = false;
            cmbCustomerName.Enabled = false;
            cmbCustType.Enabled = false;
            cmbSaleType.Enabled = false;
            FromDelivery = true;
            LoadNBind();
            btnCancel.Enabled = false;
            this._DeliveryNo = DeliveryNo;
            string Delivery_No = (string)DataTypeParser.Parse(this._DeliveryNo, typeof(string), null);
            LoadNBindInvoice(Delivery_No);
           // rdoShowRoom.Enabled = false;
            rdoVenNo.Checked = true;
            cmbWarehouseORVen.SelectedValue = VenID;
            dtSubStore = new WarehouseBL().GetAllSubStore();
            btnAdd.Enabled = false;
            //btnCancel.Enabled = false;
        }

        #region Private Methods
        private void SaveStatus()
        {                        
            try
            {                
                // update as delivered
                int deliveryID = (int)DataTypeParser.Parse(dgvInvoice.CurrentRow.Cells["dgvColDeliveryID"].Value, typeof(int), -1);
                if (new DeliveryBL().UpdateAsDeliveredByID(deliveryID) > 0)
                {
                    InvoiceSaveEventArgs eArgs = new InvoiceSaveEventArgs(true);
                    InvoiceSavedHandler(this, eArgs);
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }  
        }

        private void LoadNBindInvoice(string DeliveryNo)
        {            
            try
            {                
                DataTable InvoiceTbl = new InvoiceBL().GetByDeliveryNo(_DeliveryNo);
                // Add 'Amount' column if not present
                if (!InvoiceTbl.Columns.Contains("Amount"))
                { 
                    DataColumn colAmount = new DataColumn("Amount", typeof(decimal));
                    InvoiceTbl.Columns.Add(colAmount);
                }

                if (InvoiceTbl.Rows.Count < 1)
                    return;
                this.DeliveryID = (int?)DataTypeParser.Parse(InvoiceTbl.Rows[0]["DeliveryID"], typeof(int), null);
                dtpSaleDate.Value = (DateTime)DataTypeParser.Parse(InvoiceTbl.Rows[0]["DeliveryDate"].ToString(), typeof(DateTime), -1);

                int town_ = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["TownID"].ToString(), typeof(int), -1);
                int cusType_ = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["CusTypeID"].ToString(), typeof(int), -1);
                int cus_ = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["CustomerID"].ToString(), typeof(int), -1);

                cmbTown.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["TownID"].ToString(), typeof(int), -1);
                cmbCustType.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["CusTypeID"].ToString(), typeof(int), -1);
                cmbCustomerName.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["CustomerID"].ToString(), typeof(int), -1);
                txtContactPerson.Text = (string)DataTypeParser.Parse(InvoiceTbl.Rows[0]["ConPersonName"].ToString(), typeof(string), null);
                txtSalePerson.Text = (string)DataTypeParser.Parse(InvoiceTbl.Rows[0]["EmpName"].ToString(), typeof(string), null);
                cmbGateName.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["GateID"], typeof(int), -1);
                cmbTransportType.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["TransportTypeID"], typeof(int), -1);
                cmbWarehouseORVen.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["VenID"], typeof(int), -1);
                cmbReceiver.SelectedValue = (int)DataTypeParser.Parse(InvoiceTbl.Rows[0]["SalesPersonID"], typeof(int), -1);
                dgvInvoice.AutoGenerateColumns = false;
                dgvInvoice.Enabled = false;
                colDelete.Visible = false;
                dgvInvoice.DataSource = InvoiceTbl;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void LoadNBindTransportTypeCombo()
        {            
            try
            {                
                DataSet dsTransport = new DataSet();

                BindingSource bdTransportType = new BindingSource(); // TransportType
                BindingSource bdTransportGate = new BindingSource(); // TransportGate

                DataTable dtTransportType = new TransportTypeBL().GetAll(); // Load TransportType
                DataTable dtTransportGate = new TransportGateBL().GetAll(); // Load TransportGate
                                
                // add two datatables into a single dataset
                dsTransport.Tables.Add(dtTransportType);
                dsTransport.Tables.Add(dtTransportGate);

                // create data relations among two tables
                DataRelation relTransportType_TransportGate = new DataRelation("TransportType_TransportGate",
                    dtTransportType.Columns["TransportTypeID"], dtTransportGate.Columns["TransportTypeID"], false);
                dsTransport.Relations.Add(relTransportType_TransportGate);

                bdTransportType.DataSource = dsTransport;
                bdTransportType.DataMember = dtTransportType.TableName;

                bdTransportGate.DataSource = bdTransportType;
                bdTransportGate.DataMember = "TransportType_TransportGate";

                // Bind TransportType
                cmbTransportType.DataSource = bdTransportType;
                cmbTransportType.SelectedValue = 5;
                // Bind TransportGate
                cmbGateName.DataSource = bdTransportGate;
            }
            catch (Exception e)
            {
                ToastMessageBox.Show(Resource.errFailedToSave);  // To do
            }            
        }

        private void LoadNBind()
        {            
            try
            {                
                DataSet ds = new DataSet();
                DataSet dsTransport = new DataSet();

                BindingSource bdTown = new BindingSource();  // Town
                BindingSource bdTownWithCusType = new BindingSource(); // CusType
                BindingSource bdCustomer = new BindingSource(); // Customer

                BindingSource bdTransportType = new BindingSource(); // TransportType
                BindingSource bdTransportGate = new BindingSource(); // TransportGate

                DataTable dtTown = new TownBL().GetAll(); // Load Town
                DataTable dtTownWithCusType = new TownBL().GetAllWithCusType(); // Load CusType
                DataTable dtCustomer = new CustomerBL().GetAll(); // Load Customer

                DataTable dtTransportType = new TransportTypeBL().GetAll(); // Load TransportType
                DataTable dtTransportGate = new TransportGateBL().GetAll(); // Load TransportGate

                // add three datatables into a single dataset
                ds.Tables.Add(dtTown);
                ds.Tables.Add(dtTownWithCusType);
                ds.Tables.Add(dtCustomer);

                // add two datatables into a single dataset
                dsTransport.Tables.Add(dtTransportType);
                dsTransport.Tables.Add(dtTransportGate);

                // create data relations among three tables
                DataRelation relTown_CusType = new DataRelation("Town_CusType",
                       dtTown.Columns["TownID"], dtTownWithCusType.Columns["TownID"], true);
              
                //DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                //       dtTownWithCusType.Columns["CusType"], dtCustomer.Columns["CusType"], false);

                DataRelation relCusType_Customer = new DataRelation("Town_CusType_Customer", 
                    new DataColumn[]
                    {
                        dtTownWithCusType.Columns["CusType"],
                        dtTownWithCusType.Columns["TownID"],
                    },
                    new DataColumn[]
                    {
                        dtCustomer.Columns["CusType"],
                        dtCustomer.Columns["TownID"],
                    },false);                

                ds.Relations.Add(relTown_CusType);
                ds.Relations.Add(relCusType_Customer);
                
                // create data relations among two tables
                DataRelation relTransportType_TransportGate = new DataRelation("TransportType_TransportGate",
                    dtTransportType.Columns["TransportTypeID"], dtTransportGate.Columns["TransportTypeID"], false);
                dsTransport.Relations.Add(relTransportType_TransportGate);

                bdTown.DataSource = ds;
                bdTown.DataMember = dtTown.TableName;

                bdTownWithCusType.DataSource = bdTown;
                bdTownWithCusType.DataMember = "Town_CusType";

                bdCustomer.DataSource = bdTownWithCusType;
                //bdCustomer.DataMember = "CusType_Customer";
                bdCustomer.DataMember = "Town_CusType_Customer";

                // Bind Town
                cmbTown.DataSource = bdTown;
                // Bind CusType
                cmbCustType.DataSource = bdTownWithCusType;
                // Bind Customer
                cmbCustomerName.DataSource = bdCustomer;

                bdTransportType.DataSource = dsTransport;
                bdTransportType.DataMember = dtTransportType.TableName;

                bdTransportGate.DataSource = bdTransportType;
                bdTransportGate.DataMember = "TransportType_TransportGate";               

                // Bind TransportType
                cmbTransportType.DataSource = bdTransportType;
                // Bind TransportGate
                cmbGateName.DataSource = bdTransportGate;

                //Load Invoice datagrid
                InvoiceTbl = new SalesDetailBL().GetByInvoiceID(0);

                // Load Brand
                clnBrandName.DataSource = new BrandBL().GetOwnBrands();
                // Load Product
                clnProductName.DataSource = this._dtProduct = new ProductBL().GetAll();
                // Set binding fields
                clnBrandName.DisplayMember = "BrandName";
                clnBrandName.ValueMember = "BrandID";

                clnProductName.DisplayMember = "ProductName";
                clnProductName.ValueMember = "ProductID";
                                
                // Get employees just from Sales and Marketing departments
                List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
                Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                queryBuilder.Add(tpSales);
                queryBuilder.Add(tpMk);
                cmbReceiver.DataSource = DataUtil.GetDataTableByOR(new EmployeeBL().GetAll(), queryBuilder);
                
                // Load  Vehicle
                dtVen = new VehicleBL().GetAll();

                cmbTransportType.SelectedValue = 5;
            }
            catch (Exception e)
            {
                ToastMessageBox.Show(Resource.errFailedToSave);  // To do
            }            
        }

        private Invoice GetInvoice()
        {
            return new Invoice()
                {
                    SalesDate = dtpSaleDate.Value,
                    DeliveryID = (int?)DataTypeParser.Parse(this.DeliveryID, typeof(int), null),
                    CusID = (int)DataTypeParser.Parse(cmbCustomerName.SelectedValue, typeof(int), -1),
                    //SalesPersonID = GlobalCache.loginUser.EmpID,
                    SalesPersonID = (int)DataTypeParser.Parse(cmbReceiver.SelectedValue, typeof(int), -1),
                    TransportTypeID = (int)DataTypeParser.Parse(cmbTransportType.SelectedValue, typeof(int), -1),
                    TransportGateID = (int?)DataTypeParser.Parse(cmbGateName.SelectedValue, typeof(int), null),
                    SaleType = cmbSaleType.SelectedIndex,
                    GateInvNo = txtGateInvNo.Text,
                    TransportCharges = (int)DataTypeParser.Parse(txtTransportCharges.Text, typeof(int), 0),
                    VoucherType = 0,
                    TotalAmt = (decimal)DataTypeParser.Parse(txtTotalAmt.Text, typeof(decimal), 0),
                    Remark = (string)DataTypeParser.Parse(txtRemark.Text,typeof(string),null),
                    InvoiceNo = (string)DataTypeParser.Parse(txtInvoiceNo.Text,typeof(string),null)
                };
        }

        private List<SaleDetail> GetSaleDetailList()
        {
            List < SaleDetail > newSaleDetailRecords = new List<SaleDetail>();
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                if (row.IsNewRow)
                    break;
                SaleDetail newSaleDetailRecord = new SaleDetail()
                {
                    //  ID = (int)DataTypeParser.Parse(row.Cells["colMSuvDetailID"].Value, typeof(int), -1),
                    // InvoiceID = (int)DataTypeParser.Parse(row.Cells["colMSuvDetailID"].Value, typeof(int), -1),
                    ProductID = (int)DataTypeParser.Parse(row.Cells["clnProductName"].Value, typeof(int), -1),
                    SalePrice = (decimal)DataTypeParser.Parse(row.Cells["clnPrice"].Value, typeof(decimal), -1),
                    Qty = (int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), -1),
                    //Package = (int)DataTypeParser.Parse(row.Cells["clnPackage"].Value, typeof(int), -1),                        
                    Package = (int)DataTypeParser.Parse(row.Cells["colPack"].Value, typeof(int), -1),
                    Amount = (decimal)DataTypeParser.Parse(row.Cells["clnAmount"].Value, typeof(decimal), -1)
                };

                newSaleDetailRecords.Add(newSaleDetailRecord);
            };
            return newSaleDetailRecords;
        }

        private void Save()
        {            
            int? affectedrow = 0;
            InvoiceBL creditInvoiceSaver = null;
            try
            {
                creditInvoiceSaver = new InvoiceBL();
                if (rdoVenNo.Checked == true)
                {
                    VenID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), 0);
                }
                else
                {
                    WarehouseID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), 0);
                }

                Invoice invoice = GetInvoice();

                /*
                if (invoice.CusID == -1)
                {
                    MessageBox.Show("Customer must be select!"); return;
                }
                 */ 

                // Add new sale detail
                List<SaleDetail> newSaleDetailRecords = GetSaleDetailList();

                affectedrow = creditInvoiceSaver.Add(invoice, newSaleDetailRecords, VenID, WarehouseID);
                if (!creditInvoiceSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(creditInvoiceSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "Credit Sales",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else // Successful validation
                {
                    // Success in db also
                    if (affectedrow.HasValue && affectedrow.Value > 0)
                    {
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        //update as delivered in a single transaction

                        if (this.InvoiceSavedHandler != null)
                        {
                            InvoiceSaveEventArgs eArgs = new InvoiceSaveEventArgs(true);
                            InvoiceSavedHandler(this, eArgs);
                            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        }                     

                       // SaveStatus();
                        this.Close();
                    }
                    else // Falied in db
                    {
                        ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                    }
                }                
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;                
            }            
        }
        #endregion

        #region Events
        private void dgvInvoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            // Register an event to filter displaying value of Product column
            if (dgvInvoice.CurrentRow != null && dgvInvoice.CurrentCell.ColumnIndex == _indexProductColumn)
            {
                _cmbProduct = e.Control as ComboBox;
                if (_cmbProduct != null)
                {
                    _cmbProduct.DropDown += new EventHandler(cmbProduct_DropDown);
                }
            }
            if (dgvInvoice.CurrentCell.ColumnIndex == clnQty.Index || dgvInvoice.CurrentCell.ColumnIndex == clnPrice.Index)
            {
                e.Control.KeyPress +=new KeyPressEventHandler(Control_KeyPress); 
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }

        private void cmbProduct_DropDown(object sender, EventArgs e)
        {
            int brandID = (int)DataTypeParser.Parse(dgvInvoice.CurrentRow.Cells[_indexBrandColumn].Value, typeof(int), 0);
            if (brandID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtProduct, "BrandID", brandID);
            _cmbProduct.DataSource = dtResultProducts;
        }

        private void dgvInvoice_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbProduct != null)
            {
                _cmbProduct.DropDown -= new EventHandler(cmbProduct_DropDown);
            }
        }

        private void dgvInvoice_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // dgvInvoice.Rows[e.RowIndex].Cells["clnNo"].Value = (e.RowIndex + 1).ToString();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvInvoice.CurrentCell.ColumnIndex;
                int iRow = dgvInvoice.CurrentCell.RowIndex;
                if (iColumn == dgvInvoice.Columns[clnAmount.Index].Index)
                {
                    Invoice inv = GetInvoice();
                    List<SaleDetail> details = GetSaleDetailList();
                    if (rdoVenNo.Checked == true)
                    {
                        VenID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), 0);
                    }
                    else
                    {
                        WarehouseID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), 0);
                    }

                    InvoiceBL invValidator = new InvoiceBL();
                    invValidator.Validate(inv, details, VenID, WarehouseID);
                    if (!invValidator.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(invValidator.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    if (iRow + 1 >= dgvInvoice.Rows.Count)
                    {
                        DataTable dt = dgvInvoice.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvInvoice.DataSource = dt;
                        dgvInvoice[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvInvoice.CurrentCell = dgvInvoice[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvInvoice.CurrentCell = dgvInvoice[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPage));
            this.Close();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CusID = (int)DataTypeParser.Parse(cmbCustomerName.SelectedValue, typeof(int), 0);
                DataTable dtContactPerson = new ContactPersonBL().GetAll(CusID);
                if (dtContactPerson.Rows.Count < 1)
                {
                    txtContactPerson.Text = "";
                }
                foreach (DataRow row in dtContactPerson.Rows)
                {
                    txtContactPerson.Text = row["ConPersonName"].ToString();
                }
                ChangeCustomer();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }            
        }

        private void ChangeCustomer()
        {
            var gridView = dgvInvoice as DataGridView;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                int Index = r.Index;
                dgvInvoice.Rows.RemoveAt(Index);
            }
            DataUtil.AddInitialNewRow(dgvInvoice);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtSalesInvoice = dgvInvoice.DataSource as DataTable;
            if (dtSalesInvoice == null) return;

            if (dgvInvoice.Rows.Count > 0)
            {
                if (dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].ErrorText != String.Empty)
                    MessageBox.Show(Resource.errFailedToSave);
                else
                {
                    if (rdoVenNo.Checked)
                    {
                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                        {
                            int ProductID = (int)DataTypeParser.Parse(dgvInvoice.Rows[row.Index].Cells[clnProductName.Index].Value, typeof(int), -1);
                            decimal Qty = (decimal)DataTypeParser.Parse(dgvInvoice.Rows[row.Index].Cells[clnQty.Index].Value, typeof(decimal), -1);
                            //  Checing Stock In hand or Not in Vehicle
                            int VenID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), -1);
                            DataTable dtStockInVehicle = new DeliveryBL().GetStockInVehicle(VenID, ProductID);

                            if (dtStockInVehicle.Rows.Count <= 0)
                            {
                                MessageBox.Show("စီစဉ်ထားသောကားပေါ်တွင်လက်ကျန်မရှိပါ။ Delivery Note ဖြင့်တောင်းယူပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            if (Qty > (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1))
                            {
                                MessageBox.Show("လက်ကျန်မလုံလောက်ပါ။ ယခုကားပေါ်တွင် '" + (string)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["ProductName"], typeof(string), string.Empty) + " ' လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                        {
                            int ProductID = (int)DataTypeParser.Parse(dgvInvoice.Rows[row.Index].Cells[clnProductName.Index].Value, typeof(int), -1);
                            decimal Qty = (decimal)DataTypeParser.Parse(dgvInvoice.Rows[row.Index].Cells[clnQty.Index].Value, typeof(decimal), -1);

                            int WarehouseID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), -1);
                            DataTable dtStockInSubStore = new DeliveryBL().GetStockInSubStore(ProductID, WarehouseID);
                            if (dtStockInSubStore.Rows.Count <= 0)
                            {
                                MessageBox.Show("Sub Store တွင်လက်ကျန်လုံးဝမရှိပါ။ Factory သို့ပစ္စည်းတောင်းပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            if (Qty > (int)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["Qty"], typeof(int), -1))
                            {
                                MessageBox.Show("Sub Store တွင်လက်ကျန်မလုံလောက်ပါ။ Factory သို့ပစ္စည်းတောင်းပါ။" + Environment.NewLine + "ထုတ်ကုန်အမည် : " + (string)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["ProductName"], typeof(string), string.Empty)
                                                + Environment.NewLine + "လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }

                    Save();
                }
            }
        }
        #endregion

        private void dgvInvoice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            Calculatevalue(gv, e);
        }

        public void Calculatevalue(DataGridView gv, DataGridViewCellEventArgs e)
        {
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            int customerType = (int)DataTypeParser.Parse(cmbCustType.SelectedValue, typeof(int), -1);
            int selectedProductID = (int)DataTypeParser.Parse(curRow.Cells["clnProductName"].Value, typeof(int), -1);
                        
            if (this._dtProduct == null)
                return;
            if (curColumName.Equals("clnProductName"))
            {
                // Get and set Whole sale price and Retail sale price by Sale Date
                if (selectedProductID == -1)
                    return;
                PriceChange productPrice = new PriceChangeBL().GetPrice(selectedProductID, dtpSaleDate.Value);
                if (productPrice == null) return;
                if (customerType == (int)PTIC.Common.Enum.CustomerType.Company
                        || customerType == (int)PTIC.Common.Enum.CustomerType.WholeSaleOutlet)
                {
                    curRow.Cells["clnPrice"].Value = productPrice.WSPrice;
                }
                else
                {
                    curRow.Cells["clnPrice"].Value = productPrice.RSPrice;
                }
            }
            else if (curColumName.Equals("clnQty") || curColumName.Equals("clnPrice"))
            {
                decimal totalAmt = 0;

                decimal qty = (decimal)DataTypeParser.Parse(curRow.Cells["clnQty"].Value, typeof(decimal), 0);
                // Set amount = whole sale * qty
                curRow.Cells["clnAmount"].Value = (decimal)DataTypeParser.Parse(curRow.Cells["clnPrice"].Value, typeof(decimal), 0) * qty;
                                
                // Set Package                
                DataRow rowResult = DataUtil.GetDataRowBy(this._dtProduct, "ProductID", selectedProductID);
                if (rowResult != null)
                {
                    int noPerPack = (int)DataTypeParser.Parse(rowResult["NoPerPack"], typeof(int), -1); // pass default value -1 to void DivideByZeroException                
                    if (noPerPack == 0)
                    {
                        curRow.Cells["clnPackage"].Value = 0;
                        curRow.Cells[colPack.Index].Value = 0;
                    }
                    else
                    {
                        curRow.Cells["clnPackage"].Value = qty / noPerPack;
                        decimal tmp = Convert.ToDecimal(qty) / Convert.ToDecimal(noPerPack);
                        curRow.Cells[colPack.Index].Value = Math.Ceiling(tmp);
                    }
                }
                
                if (!FromDelivery)
                {
                    DataTable dt = dgvInvoice.DataSource as DataTable;
                    foreach (DataRow row in dt.Rows)
                    {                        
                        totalAmt += (int)DataTypeParser.Parse(row["DeliverQty"].ToString(), typeof(int), 0) * (decimal)DataTypeParser.Parse(row["SalePrice"].ToString(), typeof(decimal), 0);
                    }
                    txtTotalAmt.Text = totalAmt.ToString("N0");
                }
            }
        }
             

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvInvoice.CurrentRow;
            if (selectedRow == null)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            else if(dgvInvoice.Rows.Count <= 1)
            {
                return;
            }

            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;

            DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
            dgvInvoice.Rows.RemoveAt(selectedRow.Index);
            return;            
        }

        private void DeleteSaleDetail(int SaleDetailID, DataGridView dgv)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete a selected product
                int affectedRows = new SalesDetailBL().Delete(SaleDetailID, conn);
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
                // _logger.Error(sql);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 1)
                return;
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].Name.Equals("colDelete"))
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

                int SaleDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["colSaleDetailID"].Value, typeof(int), -1);
                if (SaleDetailID == -1)
                {
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // delete a selected product from database
                    DeleteSaleDetail(SaleDetailID, dgv);
                }
            }
        }

        private void dgvInvoice_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            decimal totalAmt = 0;
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                // if (row.Index == 0) return;
                try
                {
                    if ((int)DataTypeParser.Parse(row.Cells["dgvColCusType"].Value, typeof(int), 0) == 2)
                    {
                        int noperPack;
                        if ((int)DataTypeParser.Parse(row.Cells["dgvColNoPerPack"].Value, typeof(int), 1) == 0)
                        {
                            noperPack = 1;
                        }
                        else
                        {
                            noperPack = (int)DataTypeParser.Parse(row.Cells["dgvColNoPerPack"].Value, typeof(int), 1);
                        }
                        if (FromDelivery == false)
                        {
                            row.Cells["clnPrice"].Value = (decimal)DataTypeParser.Parse(row.Cells["dgvColWholeSale"].Value, typeof(decimal), 0);
                        }
                            row.Cells["clnAmount"].Value=(decimal)DataTypeParser.Parse(row.Cells["clnPrice"].Value, typeof(decimal), 0) * (int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0);
                        //row.Cells["clnPackage"].Value = (int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0) / (int)DataTypeParser.Parse(row.Cells["dgvColNoPerPack"].Value, typeof(int), 1);
                        row.Cells["clnPackage"].Value = (int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0) / noperPack;                        
                        row.Cells[colPack.Index].Value = Decimal.Ceiling(Convert.ToDecimal((int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0)) / noperPack);
                        totalAmt += (decimal)DataTypeParser.Parse(row.Cells["clnAmount"].Value, typeof(decimal), null);
                    }
                    else
                    {
                        int SalePrice = (int)DataTypeParser.Parse(row.Cells["dgvColRetailPrice"].Value, typeof(int), 0);
                        int noperPack;
                        if ((int)DataTypeParser.Parse(row.Cells["dgvColNoPerPack"].Value, typeof(int), 1) == 0)
                        {
                            noperPack = 1;
                        }
                        else
                        {                            
                            noperPack = (int)DataTypeParser.Parse(row.Cells["dgvColNoPerPack"].Value, typeof(int), 1);
                        }
                        if (SalePrice == 0) return;
                        if (FromDelivery == false)
                        {
                            row.Cells["clnPrice"].Value = (int)DataTypeParser.Parse(row.Cells["dgvColRetailPrice"].Value, typeof(int), 0);

                        }
                        row.Cells["clnAmount"].Value = (decimal)DataTypeParser.Parse(row.Cells["clnPrice"].Value, typeof(decimal), 0) * (int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0);
                        row.Cells["clnPackage"].Value = (int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0) / noperPack;
                        row.Cells[colPack.Index].Value = Decimal.Ceiling(Convert.ToDecimal((int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0)) / noperPack);
                        //row.Cells[colPack.Index].Value = Decimal.Ceiling(Convert.ToDecimal((int)DataTypeParser.Parse(row.Cells["clnQty"].Value, typeof(int), 0)) / Convert.ToDecimal((int)DataTypeParser.Parse(row.Cells["dgvColNoPerPack"].Value, typeof(int), 0)));
                        totalAmt += (decimal)DataTypeParser.Parse(row.Cells["clnAmount"].Value, typeof(decimal), null);
                    }
                }
                catch (StackOverflowException ex)
                {
                }
            }
            txtTotalAmt.Text = totalAmt.ToString("N0");
        }

        private void cmbCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvInvoice.Refresh();
            ChangeCustomer();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            if (cmbSaleType.SelectedIndex == -1)
            {
                cmbSaleType.SelectedIndex = 0;
            }
        }

        #region Inner Class
        public class InvoiceSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;
            public InvoiceSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion

        private void rdoVenNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVenNo.Checked == true && dtVen !=null)
            {
                if (dtVen.Rows.Count > 0)
                {
                    cmbWarehouseORVen.DataSource = dtVen;
                    cmbWarehouseORVen.ValueMember = "VehicleID";
                    cmbWarehouseORVen.DisplayMember = "VenNo";
                }
            }
        }

        private void rdoShowRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoShowRoom.Checked == true)
            {
                if (dtSubStore.Rows.Count > 0)
                {
                    cmbWarehouseORVen.DataSource = dtSubStore;
                    cmbWarehouseORVen.ValueMember = "ID";
                    cmbWarehouseORVen.DisplayMember = "Warehouse";
                }
            }
        }

        private void dgvInvoice_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == clnProductName.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["clnProductName"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["clnProductName"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                            // return;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }
           
        }

        private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == clnProductName.Index)
            {
                dgv.CurrentRow.Cells[clnProductName.Index].Value = -1;
                dgv.CurrentRow.Cells[clnBrandName.Index].Value = null;
                dgv.CurrentRow.Cells[clnAmount.Index].Value = null;
                dgv.CurrentRow.Cells[clnPackage.Index].Value = null;
                dgv.CurrentRow.Cells[clnPrice.Index].Value = null;
                dgv.CurrentRow.Cells[clnQty.Index].Value = null;
                dgv.CurrentRow.Cells[colPack.Index].Value = null;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
           
        }

        private void dgvInvoice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvInvoice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoice.IsCurrentCellDirty)
            {
                dgvInvoice.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Invoice inv = GetInvoice();
                List<SaleDetail> details = GetSaleDetailList();
                if (rdoVenNo.Checked == true)
                {
                    VenID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), 0);
                }
                else
                {
                    WarehouseID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), 0);
                }

                InvoiceBL invValidator = new InvoiceBL();
                invValidator.Validate(inv, details, VenID, WarehouseID);
                if (!invValidator.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(invValidator.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                } 
                DataUtil.AddNewRow(dgvInvoice.DataSource as DataTable);
                dgvInvoice.CurrentCell = dgvInvoice.Rows[dgvInvoice.Rows.Count - 1].Cells[0];
            }
            catch (Exception)
            {                
                throw;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTransportGate _frmTransportGate = new frmTransportGate();
            UIManager.OpenForm(_frmTransportGate);
            LoadNBindTransportTypeCombo();
        }

        private void dgvInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            // TODO: make use cash sale customer is potential or not
            frmCustomerInformation formTmpCustomer = new frmCustomerInformation();
            // Set call back function
            formTmpCustomer.TempCustomerSavedHandler += new frmCustomerInformation.TempCustomerSaveHandler(formTmpCustomer_CallBack);
            // Open an entry form for a temp customer
            UIManager.OpenForm(formTmpCustomer);
        }

       

        private void formTmpCustomer_CallBack(object sender, frmCustomerInformation.TempCustomerSaveEventArgs e)
        {   
            // Reload data
            LoadNBind();

            // Set a selected town
            cmbTown.SelectedValue = e.SavedAddress.TownID;
            // Set customer type
            cmbCustType.SelectedValue = e.SavedTempCustomer.CusType;
            // Set a selected customer
            cmbCustomerName.SelectedValue = e.SavedTempCustomer.ID;
             
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cmbReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
