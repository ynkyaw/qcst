using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_Sales_QOB3Viewer : Form
    {
        #region Events
        private void frmRV_Sales_QOB5Viewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            OnDateChangeOccured();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(
                dtpStartDate.Value,
                dtpEndDate.Value,
                (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), 0),
                cmbBrand.Text
                );
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

        private void frmRV_Sales_QOB5Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer.LocalReport.ReleaseSandboxAppDomain();
        }
        #endregion

        #region Private Methods
        private void PreloadData()
        {
            DataTable dt = new BrandBL().GetAll();
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows[0][0] = 0;
            dt.Rows[0][1] = "All";
            cmbBrand.DataSource = dt;

        }

        private void OnDateChangeOccured()
        {
            dtpEndDate.Value = dtpStartDate.Value.AddYears(2);
        }

        private void Search(DateTime startDate, DateTime endDate, int brandID, string brandName)
        {
            string brand = "";
            
            if (brandID > 0) 
            {
                brand = " WHERE B.ID=" + brandID + "  ";
            }
            DataTable dt = new ReportBL().GetSalesQOB3(brand, startDate, endDate);
            reportViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.Sales_QOB3.rdlc";
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_SalesQOB5", dt));

            if (brandID == 0)
                brandName = string.Empty;

            ReportParameter paramEndDate = new ReportParameter("Brand", brandName);
            ReportParameter paramStd = new ReportParameter("Std", numericUpDown1.Value + "%");
            reportViewer.LocalReport.SetParameters(new ReportParameter[] { paramEndDate ,paramStd});

            reportViewer.RefreshReport();
        }
        #endregion

        #region Constructor
        public frmRV_Sales_QOB3Viewer()
        {
            InitializeComponent();
            //
            OnDateChangeOccured();
            // 
            PreloadData();
        }
        #endregion

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }
                                
    }
}
