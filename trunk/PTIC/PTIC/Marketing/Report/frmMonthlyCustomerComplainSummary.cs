using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PTIC.Marketing.Report
{
    public partial class frmMonthlyCustomerComplainSummary : Form
    {
        public frmMonthlyCustomerComplainSummary()
        {
            InitializeComponent();
            
            
            
        }

        private void frmMonthlyCustomerComplainSummary_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string templateSql = @"SELECT     CC.CaseDespt, ISNULL(CASEINMONTH.RefNo, '') AS COMPLAINNO, ISNULL(CASEINMONTH.ProductName, '') AS PRODUCT, ISNULL(CASEINMONTH.Qty, 0) AS QTY
                         FROM dbo.ComplaintCase AS CC LEFT OUTER JOIN
                         (SELECT     CR.ReceivedDate, CR.RefNo, P.ProductName, PIC.Qty, PIC.ComplaintCaseID
                            FROM          dbo.ComplaintReceive AS CR INNER JOIN
                                                   dbo.ProductInComplaintReceive AS PIC ON CR.ID = PIC.ComplaintReceiveID INNER JOIN
                                                   dbo.Product AS P ON P.ID = PIC.ProductID WHERE MONTH(ReceivedDate)={0} AND YEAR(ReceivedDate)={1}) AS CASEINMONTH ON CASEINMONTH.ComplaintCaseID = CC.ID";

            string sql = string.Format(templateSql, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);
            DataTable dt=new PTIC.Common.DA.BaseDAO().SelectByQuery(sql);
            //dataGridView1.DataSource = dt;
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTIC.Marketing.Report.MonthlyCustomerComplain.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("MonthlyComplain", dt));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("paramMonth", dateTimePicker1.Value.ToString("MMMM")));
            this.reportViewer1.RefreshReport();
        }
    }
}
