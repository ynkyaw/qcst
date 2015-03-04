/*
 * Author:  Wai Phyoe Thu <wpt.osp@gmail.com> 
 * Create date: 2014/08/31 (yyyy/MM/dd)
 * Description: Credit Sale Invoice chooser
 */
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using log4net;
using PTIC.Common;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;
using PTIC.VC;
using PTIC.VC.Util;
using System;
using PTIC.Util;

namespace PTIC.VC.Sale.CashCollection
{
    /// <summary>
    /// Sale Invoice chooser form that return selected invoices to caller
    /// </summary>
    public partial class frmInvoicesPicker : Form
    {
        /// <summary>
        /// Logger for frmInvoicesPicker
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmInvoicesPicker));

        private DataTable _dtSalesInvoices = null;

        public delegate void InvoiceSelectionHandler(object sender, InvoiceSelectionEventArgs args);
        public event InvoiceSelectionHandler InvoiceSelectedHandler;

        #region Events
        private void dgvVouchers_DoubleClick(object sender, System.EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.RowCount < 1)
                return;
            
            DataRow selectedRow = (dgv.CurrentRow.DataBoundItem as DataRowView).Row;            
            DataTable tblSelection = dgvSelectedVouchers.DataSource as DataTable;            
            // Only if customer IDs of selected invoice are same, move it into selected invoices
            DataTable dtCurSelectedInvoices = (new DataView(tblSelection, string.Empty, string.Empty, DataViewRowState.CurrentRows)).ToTable();
            if (dtCurSelectedInvoices.Rows.Count > 0) // if one row has already existed in selected invoices
            {
                bool isSame = false;
                foreach (DataRow row in dtCurSelectedInvoices.Rows)
                {
                    if ((int)selectedRow["CustomerID"] == (int)row["CustomerID"])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) // customers of selected invoices are not same, do not allow to add
                    return;
            }            
            // Add a selected row into selected invoices
            tblSelection.ImportRow(selectedRow);
            // Remove a selected row from invoices
            dgv.Rows.Remove(dgv.CurrentRow);
        }

        private void dgvSelectedVouchers_DoubleClick(object sender, System.EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.RowCount < 1)
                return;

            // Add a selected row into invoices
            DataRow selectedRow = (dgv.CurrentRow.DataBoundItem as DataRowView).Row;
            DataTable tblInvoice = dgvVouchers.DataSource as DataTable;
            tblInvoice.ImportRow(selectedRow);
            // Remove selected row from Selected Invoice
            dgv.Rows.Remove(dgv.CurrentRow);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            SendBackInvoicesToCaller();
            this.Close();
        }

        private void dgvVouchers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView == null)
                return;

            foreach (DataGridViewRow r in gridView.Rows)
            {
                // Set row indicator number
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                // Set sale type description
                if ((int)DataTypeParser.Parse(r.Cells[dgvColSaleTypeText.Index].Value, typeof(int), 0) == 0)
                    r.Cells[colSaleType.Index].Value = PTIC.Common.Enum.SaleType.Credit.ToString();
                else
                    r.Cells[colSaleType.Index].Value = PTIC.Common.Enum.SaleType.Consignment.ToString();
            }
        }

        private void dgvSelectedVouchers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (gridView == null)
                return;
        }

        private void lblFilter_Click(object sender, System.EventArgs e)
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

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            Search();
        }
        
        #endregion

        #region Private Methods
        private void LoadNBindInvoiceVoucher()
        {            
            try
            {
                DataTable dtVouchers = new InvoiceBL().GetInvoicesWithoutAnyPayment();
                // Bind invoices
                //dgvVouchers.DataSource = dtVouchers;
                // Bind only schema on selected invoices
                //dgvSelectedVouchers.DataSource = dtVouchers.Clone();
                dgvVouchers.DataSource = dtVouchers.Clone();
                dgvSelectedVouchers.DataSource = dtVouchers.Clone();
                this._dtSalesInvoices = dtVouchers;
            }
            catch (SqlException Sqle)
            {
                MessageBox.Show(Resource.msg_text_err_failed_to_load_invoices, 
                    Resource.msg_title_err_failed_to_load_data, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                _logger.Error(Sqle);
            }            
        }

        /// <summary>
        /// Get selected invoices and send back to caller 
        /// </summary>
        private void SendBackInvoicesToCaller()
        {
            DataTable dtSelectedInvoices = dgvSelectedVouchers.DataSource as DataTable;
            // Get selected invoices in state of  DataViewRowState.CurrentRows
            //DataView dvSelectedInvoices = new DataView(dtSelectedInvoices, string.Empty, string.Empty, DataViewRowState.CurrentRows);
            List<Invoice> selectedInvoices = new List<Invoice>();
            foreach(DataGridViewRow row in dgvSelectedVouchers.Rows)
            {                
                Invoice inv = new Invoice() 
                {
                    ID = (int)DataTypeParser.Parse(row.Cells["dgvColInvoiceID"].Value, typeof(int), null),
                    InvoiceNo = (string)DataTypeParser.Parse(row.Cells["dgvColInvoiceNo"].Value, typeof(string), string.Empty)
                };
                if(inv.ID.HasValue)
                    selectedInvoices.Add(inv);
            }
            // Set selected invoices and handler for caller
            InvoiceSelectionEventArgs args = new InvoiceSelectionEventArgs(selectedInvoices);
            InvoiceSelectedHandler(this, args);
        }

        private void SetSerialNoNSaleType(DataGridView gv)
        {
            //foreach (DataGridViewRow r in gv.Rows)
            //{
            //    // Set row indicator number
            //    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            //    // Set sale type description
            //    if ((int)DataTypeParser.Parse(r.Cells[dgvColSaleTypeText.Index].Value, typeof(int), 0) == 0)
            //        r.Cells[colSaleType.Index].Value = PTIC.Common.Enum.SaleType.Credit.ToString();
            //    else
            //        r.Cells[colSaleType.Index].Value = PTIC.Common.Enum.SaleType.Consignment.ToString();
            //}
        }
        #endregion
        
        #region Constructors
        public frmInvoicesPicker()
        {
            InitializeComponent();
            // Disable auto-generation columns
            dgvVouchers.AutoGenerateColumns = false;
            dgvSelectedVouchers.AutoGenerateColumns = false;            
            LoadNBindInvoiceVoucher();            
            LoadNBindNecessaryData();
        }

        private void LoadNBindNecessaryData()
        {
            DataSet ds = new DataSet();
            BindingSource bdTown = new BindingSource();
            BindingSource bdCustomer = new BindingSource();

            DataTable dtTown = new TownBL().GetAll();
            DataTable dtCustomer = new CustomerBL().GetAll();

            // add town and customer tables into a dataset
            ds.Tables.Add(dtTown);
            ds.Tables.Add(dtCustomer);

            // create data relation between town and customer
            DataRelation relTown_Customer = new DataRelation("Town_Customer", dtTown.Columns["TownID"], dtCustomer.Columns["TownID"]);
            // add relation into a dataset
            ds.Relations.Add(relTown_Customer);

            bdTown.DataSource = ds;
            bdTown.DataMember = dtTown.TableName;

            bdCustomer.DataSource = bdTown;
            bdCustomer.DataMember = "Town_Customer";

            cmbTown.DataSource = bdTown;
            cmbCustomer.DataSource = bdCustomer;
        }

        private void Search()
        {
            int? selectedCusId = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (!selectedCusId.HasValue 
                || _dtSalesInvoices == null || 
                _dtSalesInvoices.Rows.Count < 1)
            {
                MessageBox.Show("There is no record to display!", 
                    "No record", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> tpCus = Tuple.Create<string, object>("CustomerID", selectedCusId.Value);
            queryBuilder.Add(tpCus);
            this.dgvVouchers.DataSource = DataUtil.GetDataTableByAND(this._dtSalesInvoices, queryBuilder);
            // Clear selected invoices
            (this.dgvSelectedVouchers.DataSource as DataTable).Clear();
        }
        #endregion
        
        #region Inner Class
        public class InvoiceSelectionEventArgs : System.EventArgs
        {
            private List<Invoice> _invoices;

            public InvoiceSelectionEventArgs(List<Invoice> invoices)
            {
                this._invoices = invoices;
            }

            public List<Invoice> Invoices
            {
                get { return this._invoices; }
            }
        }
        #endregion
                                
    }
}
