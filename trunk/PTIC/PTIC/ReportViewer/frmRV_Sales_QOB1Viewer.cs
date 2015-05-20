﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.Util;

namespace PTIC.ReportViewer
{
    public partial class frmRV_Sales_QOB1Viewer : Form
    {
        #region Events
        private void frmRV_Sales_QOB1Viewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
             DataTable dt = PTIC.Sale.DA.BrandDA.SelectAll();
            dt.Rows.InsertAt(dt.NewRow(),0);
            dt.Rows[0][0]=0;
            dt.Rows[0][1]="All";
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "BrandId";
            comboBox1.DisplayMember = "BrandName";

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

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            //OnDateChangeOccured();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
            Search(
                dtpStartDate.Value,
                dtpEndDate.Value
                );
        }

        private void frmRV_Sales_QOB1Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer.LocalReport.ReleaseSandboxAppDomain();
        }
        #endregion

        #region Private Methods
        private void OnDateChangeOccured()
        {            
            //dtpEndDate.Value = dtpStartDate.Value.AddYears(2);

            // Start date must be 2 years before end date
            dtpStartDate.Value = dtpEndDate.Value.AddYears(-2);                        
        }

        private void Search(DateTime startDate, DateTime endDate)
        {
            string brand = "";
            string brandName = "";
            if (comboBox1.SelectedValue != null) 
            {
                if ((int)comboBox1.SelectedValue > 0) 
                {
                    brand = "WHERE B.ID=" + comboBox1.SelectedValue +"  ";
                    brandName = (comboBox1.SelectedItem as DataRowView)["BrandName"]+string.Empty;
                }
            }
            // Move to first month of start date
            startDate = new DateTime(startDate.Year, 1, 1);

            DateTime now = DateTime.Now;
            // If current reported month is same to month of end date, exclude this month
            if (endDate.Year == now.Year && endDate.Month == now.Month)
            {
                // Exclude current month in end date and move to prior month                
                endDate = endDate.AddMonths(-1);
                // Move to last day of month
                endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
            }
            else
            { 
                // Move to last day of last month (Dec) of end date
                endDate = new DateTime(endDate.Year, 12, DateTime.DaysInMonth(endDate.Year, 12));
            }

            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetSalesQOB1(brand,startDate, endDate);
            if (dt == null) return;
            if (dt.Rows.Count < 1) 
            {
                reportViewer.Clear();
                MessageBox.Show("No Data To Show!");
                return;
            }
            if (!reporter.ValidationResults.IsValid)
            {
                reportViewer.Clear();
                ValidationResult err = DataUtil.GetFirst(reporter.ValidationResults) as ValidationResult;
                MessageBox.Show(
                    err.Message,
                    "Sales QOB1 Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);                
                return;
            }

            
            

            reportViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.Sales_QOB1.rdlc";
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_SalesQOB1", dt));

            ReportParameter paramStartDate = new ReportParameter("StartDate", startDate.ToString());
            ReportParameter paramEndDate = new ReportParameter("EndDate", endDate.ToString());
            ReportParameter paramStd = new ReportParameter("Std", numericUpDown1.Value + "%");
            ReportParameter paramBrand = new ReportParameter("Brand", brandName);

            reportViewer.LocalReport.SetParameters(new ReportParameter[] { paramStartDate, paramEndDate,paramStd,paramBrand });
            
            reportViewer.RefreshReport();
        }
        #endregion

        #region Constructor
        public frmRV_Sales_QOB1Viewer()
        {
            InitializeComponent();
            OnDateChangeOccured();
        }
        #endregion

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            OnDateChangeOccured();
        }
                                        
    }
}
