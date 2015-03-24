using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.Sale.OfficeSales
{
    public partial class frmDailySales : Form
    {
        DataTable dailySalesDt = new DataTable();
        DataTable detailsSales = new DataTable();
        public frmDailySales()
        {
            InitializeComponent();
            dailySalesDt = PTIC.Sale.BL.InvoiceBL.GetDailySalesReport();
            detailsSales = PTIC.Sale.BL.InvoiceBL.SelectDetails();
            dgvDailySales.DataSource = dailySalesDt;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            DataTable temp = dailySalesDt.Copy();
            DataRow[] dr ;
            if (dtpOrderStart.Checked) 
            {
                string sql = "SalesDate >= #" + dtpOrderStart.Value.ToShortDateString() + "#";
                dr = temp.Select(sql);
                if(dr.Length>0)
                    temp = dr.CopyToDataTable();
            }

            if (dtpOrderEnd.Checked)
            {
                string sql = "SalesDate <= #" + dtpOrderEnd.Value.ToShortDateString() + "#";
                dr = temp.Select();
                if (dr.Length > 0)
                    temp = dr.CopyToDataTable();
            }


            dgvDailySales.DataSource = temp;
        }

        private void dgvDailySales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDailySales.SelectedRows.Count == 1) 
            {
                int invoiceId =(int)PTIC.VC.Util.DataTypeParser.Parse(dgvDailySales.SelectedRows[0].Cells[colID.Index].Value,typeof(int),0);
                DataRow[] dr = detailsSales.Select("InvoiceID=" + invoiceId);
                if (dr.Length > 0) 
                {
                    dgvSalesDetails.DataSource = dr.CopyToDataTable();
                }
            
            }
        }
    }
}
