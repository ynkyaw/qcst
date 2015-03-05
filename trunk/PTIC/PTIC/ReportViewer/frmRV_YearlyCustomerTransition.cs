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
    public partial class frmRV_YearlyCustomerTransition : Form
    {                
        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
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
            nRow[cID] = -1;
            nRow[cCusTypeName] = "-- Unselect --";
            dtCustomerType.Rows.Add(nRow);

            nRow = dtCustomerType.NewRow();
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

        private void LoadNBindTownTrip()
        {            
            DataSet dsTownInTrip = new DataSet();

            BindingSource bdTrip = new BindingSource();
            BindingSource bdTownInTrip = new BindingSource();
            
            DataTable dtTrip = new TripBL().GetAll();            
            DataTable dtTownInTrip = new TownInTripBL().GetAll();

            DataRow unselectedRow = dtTrip.NewRow();
            unselectedRow["TripID"] = -1;
            unselectedRow["TripName"] = "-- Unselect --";
            dtTrip.Rows.Add(unselectedRow);
            
            unselectedRow = dtTownInTrip.NewRow();
            unselectedRow["TownID"] = -1;
            unselectedRow["Town"] = "-- Unselect --";
            dtTownInTrip.Rows.Add(unselectedRow);

            dsTownInTrip.Tables.AddRange(new DataTable[] 
            {
                dtTrip, dtTownInTrip
            });
            
            DataRelation relTownTrip = new DataRelation(
                "RelTownTrip",
                dtTrip.Columns["TripID"], dtTownInTrip.Columns["TripID"], false);

            dsTownInTrip.Relations.Add(relTownTrip);

            bdTrip.DataSource = dsTownInTrip;
            bdTrip.DataMember = dtTrip.TableName;

            bdTownInTrip.DataSource = bdTrip;
            bdTownInTrip.DataMember = relTownTrip.RelationName;

            this.cmbTrip.DataSource = bdTrip;
            this.cmbTrip.ValueMember = "TripID";
            this.cmbTrip.DisplayMember = "TripName";

            this.cmbTown.DataSource = bdTownInTrip;
            this.cmbTown.ValueMember = "TownID";
            this.cmbTown.DisplayMember = "Town";

        }

        private void Search()
        {
            DataTable dt = null;
            DateTime startDate = (DateTime)DataTypeParser.Parse(dptStartDate.Value, typeof(DateTime), DateTime.Now);
            PTIC.Common.Enum.CustomerType? cusType;
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
                    cusType = null;
                    break;
            }

            int? tripID = (int?)DataTypeParser.Parse(cmbTrip.SelectedValue, typeof(int), null);            
            int? townID = (int?)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), null);

            dt = new ReportBL().GetYearlyCustomerTransition(tripID, townID, startDate, cusType);                 

            rpViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.YearlyCustomerTransition.rdlc";
            rpViewer.LocalReport.DataSources.Clear();

            rpViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_YearlyCustomerTransition", dt));

            ReportParameter paramStartDate = new ReportParameter("StartDate", startDate.ToShortDateString());

            this.rpViewer.LocalReport.SetParameters(new ReportParameter[] { paramStartDate });

            rpViewer.RefreshReport();
        }
        #endregion

        #region Constructors
        public frmRV_YearlyCustomerTransition()
        {
            InitializeComponent();
            this.cmbCustomerType.DataSource = GetCustomerTypeEnum();
            LoadNBindTownTrip();
        }
        #endregion
                

    }
}
