using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PTIC.Sale.Report
{
    public partial class frmDeliveryNoteDetailViewer : Form
    {
        private int DeliveryNoteID;

        public frmDeliveryNoteDetailViewer()
        {
            InitializeComponent();
        }

        public frmDeliveryNoteDetailViewer(int DeliveryNoteID):this()
        {
            // TODO: Complete member initialization
            this.DeliveryNoteID = DeliveryNoteID;
            LoadData(this.DeliveryNoteID);
        }

        private void LoadData(int DeliveryNoteID)
        {
            DeliveryNoteReport cryRpt = new DeliveryNoteReport();
            cryRpt.SetDatabaseLogon("sa", "sa", @"AUNGKOKO-PC\AUNGKOKO", "PTIC_Ver_1_0_6");
                      
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            // Parameter Passing
            crParameterDiscreteValue.Value = Convert.ToInt32(DeliveryNoteID);
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@p_DeliveryNoteID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            try
            {
                crystalReportViewer1.ReportSource = cryRpt;
            }
            catch (Exception ex)
            {

            }
            crystalReportViewer1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData(1);
        }
    }
}
