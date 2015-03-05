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
using Microsoft.Reporting.WinForms;
using PTIC.Common.BL;

namespace PTIC.ReportViewer
{
    public partial class frmRV_Sales_QOB6Viewer : Form
    {
        #region Events
        private void frmRV_Sales_QOB6Viewer_Load(object sender, EventArgs e)
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

        private void frmRV_Sales_QOB6Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer.LocalReport.ReleaseSandboxAppDomain();
        }
        #endregion

        #region Private Methods
        private void PreloadData()
        {
            cmbBrand.DataSource = new BrandBL().GetAll();
        }

        private void OnDateChangeOccured()
        {
            dtpEndDate.Value = dtpStartDate.Value.AddYears(2);
        }

        private void Search(DateTime startDate, DateTime endDate, int brandID, string brandName)
        {
            DataTable dt = new ReportBL().GetSalesQOB6(startDate, endDate, brandID);
            reportViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.Sales_QOB6.rdlc";
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_SalesQOB6", dt));

            ReportParameter paramEndDate = new ReportParameter("Brand", brandName);
            reportViewer.LocalReport.SetParameters(new ReportParameter[] { paramEndDate });

            reportViewer.RefreshReport();
        }
        #endregion

        #region Constructor
        public frmRV_Sales_QOB6Viewer()
        {            
            InitializeComponent();
            //
            OnDateChangeOccured();
            // 
            PreloadData();
        }
        #endregion
                                
    }
}
