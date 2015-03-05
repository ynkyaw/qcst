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

namespace PTIC.ReportViewer
{
    public partial class frmRV_WaitingOrPermanentCustomer : Form
    {
        #region Events
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void frmRV_WaitingOrPermanentCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpViewer.LocalReport.ReleaseSandboxAppDomain();
        }
        #endregion

        #region Private Methods
        private void Search()
        {
            DataTable dt = new DataTable();
            DateTime endDate = (DateTime)DataTypeParser.Parse(dptEndDate.Value, typeof(DateTime), DateTime.Now);
            if (rdoPermanent.Checked)
                dt = new ReportBL().GetPermanentCustomers(endDate);
            else
                dt = new ReportBL().GetWaitingCustomers(endDate);
                        
            rpViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.WaitingOrPermanentCustomer.rdlc";
            rpViewer.LocalReport.DataSources.Clear();

            rpViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_WaitingOrPermanentCustomer", dt));

            ReportParameter paramWaitingOrPermanent = new ReportParameter("WaitingOrPermanent",
                rdoPermanent.Checked ? PTIC.Common.Enum.CustomerTransition.Permanent.ToString() :
                Common.Enum.CustomerTransition.Waiting.ToString());

            this.rpViewer.LocalReport.SetParameters(new ReportParameter[] { paramWaitingOrPermanent });

            rpViewer.RefreshReport();
        }
        #endregion

        #region Constructors
        public frmRV_WaitingOrPermanentCustomer()
        {
            InitializeComponent();
        }
        #endregion
                        
    }
}
