using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;
using PTIC.VC.Util;
using PTIC.Sale.BL;

namespace PTIC.ReportViewer
{
    public partial class frmRV_MonthlySalesByCustomerViewer : Form
    {
        DataTable dtCusType = null;

        public frmRV_MonthlySalesByCustomerViewer()
        {
            InitializeComponent();
            DataRow rowUnselect = null;

            dtCusType = new CusTypeBL().GetData();
            rowUnselect = dtCusType.NewRow();
            rowUnselect["CusTypeID"] =DBNull.Value;
            rowUnselect["CusTypeName"] = "-- Unselect --";
            dtCusType.Rows.InsertAt(rowUnselect, 0);
            cmbCustType.DataSource = dtCusType;
        }

        private void frmRV_MonthlySalesByCustomerViewer_Load(object sender, EventArgs e)
        {
           // this.rpMonthlySalesByCusViewer.RefreshReport();
            //this.rpMonthlySalesByCusViewer.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime SalesDate = (DateTime)DataTypeParser.Parse(dtpStartDate.Value, typeof(DateTime), DateTime.Now);
            int? CusType = (int?)DataTypeParser.Parse(cmbCustType.SelectedValue, typeof(int),null);
            Search(SalesDate,CusType);
        }

        #region Private Methods
        private void Search(DateTime SalesDate,int? CusType)
        {
            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetMonthlySalesByCustomer(SalesDate,CusType);
            ReportParameter salesDate = new ReportParameter("SalesDate", SalesDate.ToString("MMM,yyyy"));

            rpMonthlySalesByCusViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.MonthlySalesByCustomer.rdlc";
            rpMonthlySalesByCusViewer.LocalReport.DataSources.Clear();

            this.rpMonthlySalesByCusViewer.LocalReport.SetParameters(new ReportParameter[] {salesDate});
            
            rpMonthlySalesByCusViewer.LocalReport.DataSources.Add(new ReportDataSource("MonthlySalesByCustomerDataSet", dt));

            rpMonthlySalesByCusViewer.RefreshReport();
        }
        #endregion

        private void frmRV_MonthlySalesByCustomerViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpMonthlySalesByCusViewer.LocalReport.ReleaseSandboxAppDomain();
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
