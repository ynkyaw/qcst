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
    public partial class frmRV_YearlySalesQty : Form
    {
        public frmRV_YearlySalesQty()
        {
            InitializeComponent();
            rdoTrip.Checked = true;
        }

        private void frmRV_YearlySalesQty_Load(object sender, EventArgs e)
        {

        }

        #region Private Method
        private void Search(int? CusType,int? VoucherType,int? TownID,int? TownshipID,int? RouteID, int? TripID,DateTime Date)
        {
            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetYearlySalesSelectBy(CusType,VoucherType,TownID,TownshipID,RouteID,TripID,Date);
            //ReportParameter salesDate = new ReportParameter("SalesDate", SalesDate.ToString("MMM,yyyy"));

            YearlySalesViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.YearlySales.rdlc";
            YearlySalesViewer.LocalReport.DataSources.Clear();

           // this.rpMonthlySalesByRegionViewer.LocalReport.SetParameters(new ReportParameter[] { salesDate });

            YearlySalesViewer.LocalReport.DataSources.Add(new ReportDataSource("YearlySalesQtyDataSet", dt));

            YearlySalesViewer.RefreshReport();
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? TownID = null;
            int? TownshipID=null;

            int? RouteID = null;
            int? TripID =null;

            if(rdoRoute.Checked)
            {
                RouteID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue,typeof(int),null);
                TownshipID =(int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue,typeof(int),null);
            }
            else
            {
                TripID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue,typeof(int),null);
                TownID =(int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue,typeof(int),null);
            }
            //Search(null, null, null, null, null, null, (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now));
            
            Search(null, null, TownID, TownshipID, RouteID, TripID, (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now));
        }

        private void frmRV_YearlySalesQty_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmRV_YearlySalesQty_FormClosing(object sender, FormClosingEventArgs e)
        {
            YearlySalesViewer.LocalReport.ReleaseSandboxAppDomain();
        }

        private void rdoTrip_CheckedChanged(object sender, EventArgs e)
        {
            cmbTownTownship.Enabled = true;
            DataTable dtTrip = new TripBL().GetAll();
            DataTable dtTown = new TownBL().GetAll();

            // generate the data to insert
            DataRow tripUnselectInsert = dtTrip.NewRow();
            tripUnselectInsert["TripID"] = -2;
            tripUnselectInsert["TripName"] = "---------- UnSelect ----------";
            // insert in the Index 0 place
            dtTrip.Rows.InsertAt(tripUnselectInsert, 0);

            // generate the data to insert
            DataRow tripAllInsert = dtTrip.NewRow();
            tripAllInsert["TripID"] = -1;
            tripAllInsert["TripName"] = "------------ All ------------";
            // insert in the Index 1 place
            dtTrip.Rows.InsertAt(tripAllInsert, 1);

            // generate the data to insert
            DataRow townUnselectInsert = dtTown.NewRow();
            townUnselectInsert["TownID"] = -1;
            townUnselectInsert["Town"] = "---------- UnSelect ----------";
            // insert in the Index 0 place
            dtTown.Rows.InsertAt(townUnselectInsert, 0);

            cmbTripOrRoute.DataSource = dtTrip;
            cmbTripOrRoute.DisplayMember = "TripName";
            cmbTripOrRoute.ValueMember = "TripID";

            cmbTownTownship.DataSource = dtTown;
            cmbTownTownship.DisplayMember = "Town";
            cmbTownTownship.ValueMember = "TownID";
        }

        private void rdoRoute_CheckedChanged(object sender, EventArgs e)
        {
            cmbTownTownship.Enabled = true;
            DataTable dtRoute = new RouteBL().GetAll();
            DataTable dtTownship = new TownshipBL().GetAll();

            // generate the data to insert
            DataRow routeUnselectInsert = dtRoute.NewRow();
            routeUnselectInsert["RouteID"] = -2;
            routeUnselectInsert["RouteName"] = "---------- UnSelect ----------";
            // insert in the Index 0 place
            dtRoute.Rows.InsertAt(routeUnselectInsert, 0);

            // generate the data to insert
            DataRow routeAllInsert = dtRoute.NewRow();
            routeAllInsert["RouteID"] = -1;
            routeAllInsert["RouteName"] = "------------ All ------------";
            // insert in the Index 1 place
            dtRoute.Rows.InsertAt(routeAllInsert, 1);

            // generate the data to insert
            DataRow townshipUnselectInsert = dtTownship.NewRow();
            townshipUnselectInsert["TownshipID"] = -1;
            townshipUnselectInsert["Township"] = "---------- UnSelect ----------";
            // insert in the Index 0 place
            dtTownship.Rows.InsertAt(townshipUnselectInsert, 0);
                      
            cmbTripOrRoute.DataSource = dtRoute;
            cmbTripOrRoute.DisplayMember = "RouteName";
            cmbTripOrRoute.ValueMember = "RouteID";
            
            cmbTownTownship.DataSource = dtTownship;
            cmbTownTownship.DisplayMember = "Township";
            cmbTownTownship.ValueMember = "TownshipID";
        }

        private void cmbTripOrRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RouteID = -1; // RouteID Variable
            int TripID = -1; // TripID Variable

            //  Check Route Or Trip Selecting
            if (rdoRoute.Checked)
            {
                RouteID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), -1);
            }
            else
            {
                TripID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), -1);
            }


            if (rdoRoute.Checked && cmbTripOrRoute.SelectedIndex == 1)
            {
                cmbTownTownship.Enabled = false;
            }
            else if (rdoRoute.Checked && cmbTripOrRoute.SelectedIndex == 0)
            {
                cmbTownTownship.Enabled = true;
            }
            else if (rdoRoute.Checked && RouteID != -1)
            {
                //DataTable dtTownshipInRoute = new TripBL().GetAll();
            }
            else if (rdoTrip.Checked && cmbTripOrRoute.SelectedIndex == 1)
            {
                cmbTownTownship.Enabled = false;
            }
            else if (rdoTrip.Checked && cmbTripOrRoute.SelectedIndex == 0)
            {
                cmbTownTownship.Enabled = true;
            }
            else if (rdoTrip.Checked && TripID != -1)
            {
                DataTable dtTownInTrip = new TripBL().GetAllTownByTripID(TripID);

                cmbTownTownship.DataSource = dtTownInTrip;
                cmbTownTownship.DisplayMember = "Town";
                cmbTownTownship.ValueMember = "TownID";
            }
        }

    }
}
