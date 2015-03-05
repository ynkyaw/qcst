using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Common;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmSalePlan4ProductionCompare : Form
    {
        DataTable spDetailTbl = null;
        DataTable productTbl = null;
        DataTable salesplanTbl = null;
        DateTime SalePlanDate;

        DataTable salesplanTblTarget = null;
        DataTable saleplanDetailTblTarget = null;

        public frmSalePlan4ProductionCompare()
        {
            InitializeComponent();
        }

        public frmSalePlan4ProductionCompare(DateTime PlanDate)
            : this()
        {
            this.SalePlanDate = (DateTime)DataTypeParser.Parse(PlanDate, typeof(DateTime), DateTime.Now);
            dtpSource.Value = this.SalePlanDate;
            LoadData();
            BindData();
        }

        private void LoadData()
        {            
            try
            {                               
                //productTbl = new ProductBL().GetAll(conn);
                productTbl = new ProductBL().GetWithPrice();
                salesplanTbl = new SalesPlanBL().GetbyMonth(dtpSource.Value);
                salesplanTblTarget = new SalesPlanBL().GetbyMonth(dtpTarget.Value);
                if (salesplanTbl.Rows.Count == 1 && salesplanTblTarget.Rows.Count == 1)
                {
                    spDetailTbl = new SalesPlanBL().GetDetailBySalesPlanID((int)DataTypeParser.Parse(salesplanTbl.Rows[0][0], typeof(int), 0));
                    saleplanDetailTblTarget = new SalesPlanBL().GetDetailBySalesPlanID((int)DataTypeParser.Parse(salesplanTblTarget.Rows[0][0], typeof(int), 0));
                }
                else if (salesplanTbl.Rows.Count < 1 && salesplanTblTarget.Rows.Count == 1)
                {
                    spDetailTbl = new SalesPlanBL().GetDetailBySalesPlanID(0);
                    saleplanDetailTblTarget = new SalesPlanBL().GetDetailBySalesPlanID((int)DataTypeParser.Parse(salesplanTblTarget.Rows[0][0], typeof(int), 0));
                }
                else if (salesplanTblTarget.Rows.Count < 1 && salesplanTbl.Rows.Count == 1)
                {
                    spDetailTbl = new SalesPlanBL().GetDetailBySalesPlanID((int)DataTypeParser.Parse(salesplanTbl.Rows[0][0], typeof(int), 0));
                    saleplanDetailTblTarget = new SalesPlanBL().GetDetailBySalesPlanID(0);
                }
                else
                {
                    spDetailTbl = new SalesPlanBL().GetDetailBySalesPlanID(0);
                    saleplanDetailTblTarget = new SalesPlanBL().GetDetailBySalesPlanID(0);
                }
            }
            catch(Exception e)
            {
                throw e;
            }            
        }

        private void BindData()
        {
            dgvSalesPlan4P.AutoGenerateColumns = false;
            dgvSalesPlan4PTarget.AutoGenerateColumns = false;

            //clnProductName.DataSource = productTbl;
            //clnProductName.DisplayMember = "ProductName";
            //clnProductName.ValueMember = "ProductID";

            //  txtTotalSalesAmount.Text = "0";

            if (salesplanTbl.Rows.Count == 1)
            {
                decimal tempValue = (decimal)DataTypeParser.Parse(salesplanTbl.Rows[0]["SalesPlanAmt"].ToString(), typeof(decimal), 0);
                // txtTotalSalesAmount.Text = (tempValue).ToString("N0");
            }
            dgvSalesPlan4P.DataSource = spDetailTbl;
            dgvSalesPlan4PTarget.DataSource = saleplanDetailTblTarget;


        }

        private void dtpTarget_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
            BindData();
        }

        private void dtpSource_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
            BindData();
        }

        private void dgvSalesPlan4P_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    dgvSalesPlan4P.Rows[r.Index].Cells["colRequireN100Convert"].Value =
                               (float)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnCalculatedValue"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnNeed2ProduceQty"].Value, typeof(int), 0);

                    dgvSalesPlan4P.Rows[r.Index].Cells["clnN100Convert"].Value =
                               (float)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnCalculatedValue"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(dgvSalesPlan4P.Rows[r.Index].Cells["clnProducedQty"].Value, typeof(int), 0);

                    //dgvSalesPlan4P.CurrentRow.Cells["clnN100Convert"].Value =
                    //  (float)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells["clnCalculatedValue"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells["clnProducedQty"].Value, typeof(int), 0);

                }
            }
        }

        private void dgvSalesPlan4PTarget_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    gridView.Rows[r.Index].Cells[dataGridViewTextBoxColumn5.Index].Value =
                               (float)DataTypeParser.Parse(gridView.Rows[r.Index].Cells["dataGridViewTextBoxColumn11"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells["dataGridViewTextBoxColumn3"].Value, typeof(int), 0);

                    gridView.Rows[r.Index].Cells["dataGridViewTextBoxColumn6"].Value =
                               (float)DataTypeParser.Parse(gridView.Rows[r.Index].Cells["dataGridViewTextBoxColumn11"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells["dataGridViewTextBoxColumn4"].Value, typeof(int), 0);

                    //dgvSalesPlan4P.CurrentRow.Cells["clnN100Convert"].Value =
                    //  (float)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells["clnCalculatedValue"].Value, typeof(float), 0) * (int)DataTypeParser.Parse(dgvSalesPlan4P.CurrentRow.Cells["clnProducedQty"].Value, typeof(int), 0);

                }
            }
        }

    }
}