using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Util;
using Microsoft.Reporting.WinForms;
using PTIC.Common.BL;

namespace PTIC.ReportViewer
{
    public partial class frmRV_CustomerTransition : Form
    {
        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void frmRV_CustomerTransition_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpViewer.LocalReport.ReleaseSandboxAppDomain();
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
        #endregion

        #region Private Methods
        private DataTable GetCustomerTypeEnum()
        {
            DataTable dtCustomerType = new DataTable();
            DataColumn cID = new DataColumn("ID", typeof(int));
            DataColumn cCusTypeName = new DataColumn("CusTypeName", typeof(string));
            dtCustomerType.Columns.AddRange(new DataColumn[] 
            {
                cID, cCusTypeName
            });
            DataRow nRow = dtCustomerType.NewRow();
            nRow[cID] = (int)PTIC.Common.Enum.CustomerType.EndUser;
            nRow[cCusTypeName] = PTIC.Common.Enum.CustomerType.EndUser;
            dtCustomerType.Rows.Add(nRow);

            nRow = dtCustomerType.NewRow();
            nRow[cID] = (int)PTIC.Common.Enum.CustomerType.RetailOutlet;
            nRow[cCusTypeName] = PTIC.Common.Enum.CustomerType.RetailOutlet;
            dtCustomerType.Rows.Add(nRow);

            nRow = dtCustomerType.NewRow();
            nRow[cID] = (int)PTIC.Common.Enum.CustomerType.WholeSaleOutlet;
            nRow[cCusTypeName] = PTIC.Common.Enum.CustomerType.WholeSaleOutlet;
            dtCustomerType.Rows.Add(nRow);

            nRow = dtCustomerType.NewRow();
            nRow[cID] = (int)PTIC.Common.Enum.CustomerType.Company;
            nRow[cCusTypeName] = PTIC.Common.Enum.CustomerType.Company;
            dtCustomerType.Rows.Add(nRow);

            nRow = dtCustomerType.NewRow();
            nRow[cID] = (int)PTIC.Common.Enum.CustomerType.Government;
            nRow[cCusTypeName] = PTIC.Common.Enum.CustomerType.Government;
            dtCustomerType.Rows.Add(nRow);
          
            return dtCustomerType;
        }

        private void Search()
        {
            DataTable dt = null;
            DateTime endDate = (DateTime)DataTypeParser.Parse(dptEndDate.Value, typeof(DateTime), DateTime.Now);
            PTIC.Common.Enum.CustomerType cusType;
            switch ((int)DataTypeParser.Parse(cmbCustomerType.SelectedValue, typeof(int), 0))
            { 
                case (int)PTIC.Common.Enum.CustomerType.EndUser:
                    cusType = PTIC.Common.Enum.CustomerType.EndUser;
                    break;
                case (int)PTIC.Common.Enum.CustomerType.RetailOutlet:
                    cusType = PTIC.Common.Enum.CustomerType.RetailOutlet;
                    break;
                case (int)PTIC.Common.Enum.CustomerType.WholeSaleOutlet:
                    cusType = PTIC.Common.Enum.CustomerType.WholeSaleOutlet;
                    break;
                case (int)PTIC.Common.Enum.CustomerType.Company:
                    cusType = PTIC.Common.Enum.CustomerType.Company;
                    break;
                case (int)PTIC.Common.Enum.CustomerType.Government:
                    cusType = PTIC.Common.Enum.CustomerType.Government;
                    break;
                default:
                    cusType = PTIC.Common.Enum.CustomerType.EndUser;
                    break;
            }

            dt = new ReportBL().GetCustomerTransition(
                cusType, endDate);
                
            rpViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.CustomerTransition.rdlc";
            rpViewer.LocalReport.DataSources.Clear();

            rpViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_CustomerTransition", dt));

            ReportParameter paramEndDate = new ReportParameter("EndDate", endDate.ToShortDateString());

            this.rpViewer.LocalReport.SetParameters(new ReportParameter[] { paramEndDate });

            rpViewer.RefreshReport();
        }

        #endregion

        #region Constructors
        public frmRV_CustomerTransition()
        {
            InitializeComponent();
            this.cmbCustomerType.DataSource = GetCustomerTypeEnum();
        }
        #endregion
                               
    }
}
