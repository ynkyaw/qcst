using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.Common.BL;
using PTIC.VC.Util;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_QOB_Marketing_2Viewer : Form
    {
        public frmRV_QOB_Marketing_2Viewer()
        {
            InitializeComponent();
            LoadNBind();
        }

        #region Private Methods
        private void LoadNBind()
        {
            cmbBrand.DataSource = new BrandBL().GetOwnBrands();
            cmbBrand.DisplayMember = "BrandName";
            cmbBrand.ValueMember = "BrandID";
        }

        private void Search()
        {
            int Year = dtpStartDate.Value.Year;
            DateTime StartDate = new DateTime(Year,1,1);
            int BrandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue,typeof(int),-1);
            
            DataTable dt = new ReportBL().GetNewOutletQOBBy(StartDate, BrandID);
            rpViewerMarketingQOB2.Visible = true;
            rpViewerMarketingQOB2.LocalReport.ReportEmbeddedResource = "PTIC.Report.Marketing_QOB2.rdlc";
            rpViewerMarketingQOB2.LocalReport.DataSources.Clear();
            rpViewerMarketingQOB2.LocalReport.DataSources.Add(new ReportDataSource("MarketingQOB2DataSet", dt));
            rpViewerMarketingQOB2.RefreshReport();
        }
        #endregion

        private void frmRV_QOB_Marketing_2Viewer_Load(object sender, EventArgs e)
        {
            this.rpViewerMarketingQOB2.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void frmRV_QOB_Marketing_2Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpViewerMarketingQOB2.LocalReport.ReleaseSandboxAppDomain();
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
    }
}
