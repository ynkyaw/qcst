using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Util;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;
using PTIC.Sale.BL;

namespace PTIC.ReportViewer
{
    public partial class frmRV_MonthlySalesByRegion : Form
    {
        DataTable dtTrip = null;

        public frmRV_MonthlySalesByRegion()
        {
            InitializeComponent();
            DataRow rowUnselect = null;
            DataRow rowYangon = null;
            dtTrip = new TripBL().GetAll();
            rowUnselect = dtTrip.NewRow();
            rowUnselect["TripID"] = -1;
            rowUnselect["TripName"] = "-- UnSelect --";
            dtTrip.Rows.InsertAt(rowUnselect, 0);

            rowYangon = dtTrip.NewRow();
            rowYangon["TripID"] = DBNull.Value;
            rowYangon["TripName"] = "Yangon";
            dtTrip.Rows.InsertAt(rowYangon, 1);

            cmbTrip.DataSource = dtTrip;
         }

        private void frmRV_MonthlySalesByRegion_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpMonthlySalesByRegionViewer.LocalReport.ReleaseSandboxAppDomain();
        }

        private void frmRV_MonthlySalesByRegion_Load(object sender, EventArgs e)
        {

         //   this.rpMonthlySalesByRegionViewer.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime SalesDate = (DateTime)DataTypeParser.Parse(dtpStartDate.Value, typeof(DateTime), DateTime.Now);
            int? TripID = (int?)DataTypeParser.Parse(cmbTrip.SelectedValue, typeof(int), null);
            Search(SalesDate,TripID);
        }

        #region Private Methods
        private void Search(DateTime SalesDate,int? TripID)
        {
            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetMonthlySalesByRegion(SalesDate,TripID);
            ReportParameter salesDate = new ReportParameter("SalesDate", SalesDate.ToString("MMM,yyyy"));

            rpMonthlySalesByRegionViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.MonthlySalesByRegion.rdlc";
            rpMonthlySalesByRegionViewer.LocalReport.DataSources.Clear();

            this.rpMonthlySalesByRegionViewer.LocalReport.SetParameters(new ReportParameter[] { salesDate });

            rpMonthlySalesByRegionViewer.LocalReport.DataSources.Add(new ReportDataSource("MonthlySalesByRegionDataSet", dt));

            rpMonthlySalesByRegionViewer.RefreshReport();
        }
        #endregion

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
