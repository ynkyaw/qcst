using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Common;
using PTIC.Sale.BL;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_DeliveryNoteViewer : Form
    {
        internal int DeliveryNoteID;

        public frmRV_DeliveryNoteViewer()
        {
            InitializeComponent();
        }

        public frmRV_DeliveryNoteViewer(int DeliveryNoteID)
            : this()
        {
            this.DeliveryNoteID = DeliveryNoteID;
        }


        private void frmRV_DeliveryNoteViewer_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            DataTable dtDeliveryNoteDetail = new DeliveryNoteBL().GetDeliveryNoteDetail(this.DeliveryNoteID);
                    
            rpDeliveryNoteViewer.Visible = true;
            rpDeliveryNoteViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.DeliveryNote.rdlc";
            rpDeliveryNoteViewer.LocalReport.DataSources.Clear();
            rpDeliveryNoteViewer.LocalReport.DataSources.Add(new ReportDataSource("DeliveryNoteDataSet", dtDeliveryNoteDetail));

            this.rpDeliveryNoteViewer.RefreshReport();
        }
    }
}
