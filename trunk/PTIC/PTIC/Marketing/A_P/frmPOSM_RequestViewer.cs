using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PTIC.Marketing.A_P
{
    public partial class frmPOSM_RequestViewer : Form
    {
        string Date,POSM,UnitCost,Qty,Total,Requester,Accepter = string.Empty;       
        

        public frmPOSM_RequestViewer()
        {
            InitializeComponent();
        }

        public frmPOSM_RequestViewer(string Date, string POSM, string UnitCost, string Qty, string Total, string Requester, string Accepter)
            : this()
        {
            this.Date = Date;
            this.POSM = POSM;
            this.UnitCost = UnitCost;
            this.Qty = Qty;
            this.Total = Total;
            this.Requester = Requester;
            this.Accepter = Accepter;
        }   
   

        private void frmPOSM_RequestViewer_Load(object sender, EventArgs e)
        {
            ReportParameter fromDate = new ReportParameter("fromDate", this.Date);
            ReportParameter posm = new ReportParameter("POSM", this.POSM);
            ReportParameter unitcost = new ReportParameter("UnitCost", this.UnitCost);
            ReportParameter qty = new ReportParameter("Qty", this.Qty);
            ReportParameter total = new ReportParameter("Total", this.Total);
            ReportParameter requester = new ReportParameter("Requester", this.Requester);
            ReportParameter accepter = new ReportParameter("Accepter",this.Accepter);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { fromDate,posm,unitcost,qty,total,requester,accepter});
            this.reportViewer1.RefreshReport();        
        }
    }
}
