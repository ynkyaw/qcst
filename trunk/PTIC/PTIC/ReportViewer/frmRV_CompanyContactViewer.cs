using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;
using PTIC.VC.Util;

namespace PTIC.ReportViewer
{
    public partial class frmRV_CompanyContactViewer : Form
    {
        /// <summary>
        /// DataSet & Binding Source for Town
        /// </summary>
        DataSet ds = new DataSet();

        BindingSource bdTrip = new BindingSource();
        BindingSource bdTown = new BindingSource();

        /// <summary>
        /// DataSet & Binding Source for Township
        /// </summary>
        DataSet dsTownship = new DataSet();

        BindingSource bdRoute = new BindingSource();
        BindingSource bdTownship = new BindingSource();



        public frmRV_CompanyContactViewer()
        {
            InitializeComponent();
            LoadNBindSearch();
            rdoTrip.Checked = true;
        }

        #region Private Methods
        private void LoadNBindSearch()
        {
            DataTable townTbl = new TownBL().GetAll();
            DataTable townshipTbl = new TownshipBL().GetAll();
            DataTable tripTbl = new TripBL().GetAll();
            DataTable routeTbl = new RouteBL().GetAll();
            DataTable customerTypTbl = new CusTypeBL().GetAll();
            //cusclassTbl = new CustomerClassBL().GetAll(conn);

            DataTable townshipInRouteTbl = new TownshipInRouteBL().GetAll();
            DataTable townIntripTbl = new TownInTripBL().GetAll();

            DataTable dtRoute = routeTbl.Copy();
            DataTable dtTrip = tripTbl.Copy();
            DataTable dtTownInTrip = townIntripTbl.Copy();
            DataTable dtTownshipInRoute = townshipInRouteTbl.Copy();

            // add town and customer tables into a dataset
            dsTownship.Tables.Add(dtRoute);
            dsTownship.Tables.Add(townshipInRouteTbl);
            //dsTownship.Tables.Add(dtCustomer);

            // create data relation between township and customer
            DataRelation relRoute_Township = new DataRelation("Route_Township", dtRoute.Columns["RouteID"], townshipInRouteTbl.Columns["RouteID"], false);
            // add relation into a dataset
            dsTownship.Relations.Add(relRoute_Township);

            bdRoute.DataSource = dsTownship;
            bdRoute.DataMember = dtRoute.TableName;

            bdTownship.DataSource = bdRoute;
            bdTownship.DataMember = "Route_Township";

            try
            {
                // add town and customer tables into a dataset
                ds.Tables.Add(dtTrip);
                ds.Tables.Add(dtTownInTrip);

                // create data relation between town and customer
                DataRelation relTrip_Town = new DataRelation("Trip_Town", dtTrip.Columns["TripID"], dtTownInTrip.Columns["TripID"], false);
                // add relation into a dataset
                ds.Relations.Add(relTrip_Town);

                bdTrip.DataSource = ds;
                bdTrip.DataMember = dtTrip.TableName;

                bdTown.DataSource = bdTrip;
                bdTown.DataMember = "Trip_Town";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmbCustomerType.DataSource = customerTypTbl;
            cmbCustomerType.ValueMember = "CusTypeID";
            cmbCustomerType.DisplayMember = "CusTypeName";
        }

        private void Search()
        {
            DateTime StartDate,EndDate;
            int? TripID =null;
            int? RouteID =null;
            int? TownID=null;
            int? TownshipID = null;
            int? CustomerType = null;
            if(rdoDaily.Checked)
            {
                StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value,typeof(DateTime),DateTime.Now);
                EndDate =(DateTime)DataTypeParser.Parse(dtpDate.Value,typeof(DateTime),DateTime.Now);
            }
            else if(rdoWeekly.Checked)
            {
               StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value,typeof(DateTime),DateTime.Now);
               DateTime tmp = dtpDate.Value.AddDays(6);
                EndDate =tmp;
            }
            else if(rdoMonthly.Checked)
            {
                StartDate =(DateTime)DataTypeParser.Parse(dtpDate.Value,typeof(DateTime),DateTime.Now);
                EndDate = UIManager.ChangeAnotherdtpOndtpChange(dtpDate);
            }
            else
            {
                StartDate =(DateTime)DataTypeParser.Parse(dtpDate.Value,typeof(DateTime),DateTime.Now);
                int intYear = dtpDate.Value.Year;
                DateTime EndOfThisMonth = new DateTime(intYear, 12, 31);
                EndDate = EndOfThisMonth;
            }

            if(rdoRoute.Checked)
            {
                RouteID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue,typeof(int),null);         
                if(chkTownTownship.Checked)
                {
                    TownshipID = (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue,typeof(int),null);
                }              
            }
            if(rdoTrip.Checked)
            {
                 TripID =(int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue,typeof(int),null);
                if(chkTownTownship.Checked)
                {
                    TownID =(int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue,typeof(int),null);
                }
            }

            DataTable dt = new ReportBL().CompanyContactSelectBy(TripID, RouteID, TownID, TownshipID, CustomerType, StartDate, EndDate);
            rpViewerCompanyContact.Visible = true;
            rpViewerCompanyContact.LocalReport.ReportEmbeddedResource = "PTIC.Report.CompanyContactReport.rdlc";
            rpViewerCompanyContact.LocalReport.DataSources.Clear();
            rpViewerCompanyContact.LocalReport.DataSources.Add(new ReportDataSource("CompanyContactDataSet", dt));
            rpViewerCompanyContact.RefreshReport();
          
        }
        #endregion

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

        private void rdoTrip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTrip.Checked)
            {
                cmbTripOrRoute.DataSource = bdTrip;
                //cmbCustomer.DataSource = bdCustomerTrip;
                cmbTripOrRoute.ValueMember = "TripID";
                cmbTripOrRoute.DisplayMember = "TripName";

                cmbTownTownship.DataSource = bdTown;
                cmbTownTownship.ValueMember = "TownID";
                cmbTownTownship.DisplayMember = "Town";

                cmbTripOrRoute.Focus();
            }
        }

        private void rdoRoute_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRoute.Checked)
            {
                cmbTripOrRoute.DataSource = bdRoute;
                //     cmbCustomer.DataSource = bdCustomerRoute;
                cmbTripOrRoute.ValueMember = "RouteID";
                cmbTripOrRoute.DisplayMember = "RouteName";

                cmbTownTownship.DataSource = bdTownship;
                cmbTownTownship.ValueMember = "TownshipID";
                cmbTownTownship.DisplayMember = "Township";

                cmbTripOrRoute.Focus();
            }
        }

        private void frmRV_CompanyContactViewer_Load(object sender, EventArgs e)
        {
            this.rpViewerCompanyContact.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void frmRV_CompanyContactViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpViewerCompanyContact.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}