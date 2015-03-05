using System;
using System.Data;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Sale.Survey;

namespace PTIC.Marketing.Survey
{
    public partial class frmAcidAnswerList : Form
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

        //  DataTable
        DataTable townTbl = null;
        DataTable townshipTbl = null;
        DataTable statedivisionTbl = null;
        DataTable tripTbl = null;
        DataTable routeTbl = null;
        DataTable cusclassTbl = null;

        DataTable townIntripTbl = null;
        DataTable townshipInRouteTbl = null;


        public frmAcidAnswerList()
        {
            InitializeComponent();
            dtpSurveyStartDate.Value = new DateTime(dtpSurveyStartDate.Value.Year, dtpSurveyStartDate.Value.Month, 1);
            LoadNBindSearch();
            cmbSurveyType.SelectedIndex = 0;
            rdoRoute.Checked = true;
            LoadSearchByDateRange_SurveyType(dtpSurveyStartDate.Value, dtpSurveyEndDate.Value, cmbSurveyType.SelectedIndex + 1);
        }

        #region Private Methods
        private void LoadSearchByDateRange_SurveyType(DateTime startDate , DateTime endDate,int QuestionFormID)
        {
            try
            {
                dgvAnswer.AutoGenerateColumns = false;
                dgvAnswer.DataSource = new AcidAnswerBL().SearchByDateRage_SurveyType(startDate,endDate,QuestionFormID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void LoadSearch()
        {
            int? RouteID = null;
            int? TownshipID = null;

            int? TripID = null;
            int? TownID = null;

            DateTime startdate = (DateTime)DataTypeParser.Parse(dtpSurveyStartDate.Value,typeof(DateTime), DateTime.Now);
            DateTime enddate = (DateTime)DataTypeParser.Parse(dtpSurveyEndDate.Value, typeof(DateTime), DateTime.Now);

            int QuestionFormID = (int)DataTypeParser.Parse(cmbSurveyType.SelectedIndex + 1, typeof(int), -1);

            if (rdoRoute.Checked)
            {
                 RouteID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), null);
                 if (chkTownTownship.Checked)
                 {
                     TownshipID = (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), null);
                 }
                 else
                 {
                     TownshipID = null;
                 }
            }
            else
            {
                TripID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), null);
                if (chkTownTownship.Checked)
                {
                    TownID = (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), null);
                }
                else
                {
                    TownID = null;
                }
            }

            dgvAnswer.AutoGenerateColumns = false;
            dgvAnswer.DataSource = new AcidAnswerBL().Search(startdate, enddate, QuestionFormID, RouteID, TownshipID, TripID, TownID);

        }

        private void LoadNBindSearch()
        {
            townTbl = new TownBL().GetAll();
            townshipTbl = new TownshipBL().GetAll();
            statedivisionTbl = new SDivisionBL().GetAll();
            tripTbl = new TripBL().GetAll();
            routeTbl = new RouteBL().GetAll();
            cusclassTbl = new CustomerClassBL().GetAll();

            townshipInRouteTbl = new TownshipInRouteBL().GetAll();
            townIntripTbl = new TownInTripBL().GetAll();
          
            DataTable dtRoute = routeTbl.Copy();
            DataTable dtTrip = tripTbl.Copy();
            DataTable dtTownInTrip = townIntripTbl.Copy();

            // add town and customer tables into a dataset
            dsTownship.Tables.Add(dtRoute);
            dsTownship.Tables.Add(townshipInRouteTbl);
        
            // create data relation between township and customer
            DataRelation relRoute_Township = new DataRelation("Route_Township", dtRoute.Columns["RouteID"], townshipInRouteTbl.Columns["RouteID"], false);
           // DataRelation relTownship_Customer = new DataRelation("Township_Customer", townshipInRouteTbl.Columns["TownshipID"], dtCustomer.Columns["TownshipID"], false);
            // add relation into a dataset
            dsTownship.Relations.Add(relRoute_Township);
           // dsTownship.Relations.Add(relTownship_Customer);

            bdRoute.DataSource = dsTownship;
            bdRoute.DataMember = dtRoute.TableName;

            bdTownship.DataSource = bdRoute;
            bdTownship.DataMember = "Route_Township";
        
            try
            {
                // add town and customer tables into a dataset
                ds.Tables.Add(dtTrip);
                ds.Tables.Add(dtTownInTrip);
                //ds.Tables.Add(customerTbl);

                // create data relation between town and customer
                DataRelation relTrip_Town = new DataRelation("Trip_Town", dtTrip.Columns["TripID"], dtTownInTrip.Columns["TripID"], false);
                //DataRelation relTown_Customer = new DataRelation("Town_Customer", dtTownInTrip.Columns["TownID"], customerTbl.Columns["TownID"], false);
                // add relation into a dataset
                ds.Relations.Add(relTrip_Town);
                //ds.Relations.Add(relTown_Customer);

                bdTrip.DataSource = ds;
                bdTrip.DataMember = dtTrip.TableName;

                bdTown.DataSource = bdTrip;
                bdTown.DataMember = "Trip_Town";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            cmbCustomerType.DataSource = new CusTypeBL().GetAll();
            cmbCustomerType.DisplayMember = "CusTypeName";
            cmbCustomerType.ValueMember = "CusTypeID";
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
                //cmbCustomer.ValueMember = "CustomerID";
                //cmbCustomer.DisplayMember = "CusName";

                cmbTownTownship.DataSource = bdTown;
               // cmbCustomer.DataSource = bdCustomer;
                cmbTownTownship.ValueMember = "TownID";
                cmbTownTownship.DisplayMember = "Town";
                //cmbCustomer.DisplayMember = "CusName";
                //cmbCustomer.ValueMember = "CustomerID";
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
               // cmbCustomer.DataSource = bdCustomerTownship;
                cmbTownTownship.ValueMember = "TownshipID";
                cmbTownTownship.DisplayMember = "Township";

                //cmbCustomer.ValueMember = "CustomerID";
                //cmbCustomer.DisplayMember = "CusName";

                cmbTripOrRoute.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSearch();
        }

        private void dgvAnswer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colDetail.Index && dgv.Rows.Count > 0)
            {
                int CustomerID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colCustomerID.Index].Value, typeof(int), -1);
                int QuestionFormID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colQuestionFormID.Index].Value, typeof(int), -1);
                DateTime SurveyDate = (DateTime)DataTypeParser.Parse(dgv.CurrentRow.Cells[colSurveyDate.Index].Value, typeof(DateTime), DateTime.Now);

                if (QuestionFormID == (int)PTIC.Common.Enum.QuestionForm.Toyo)
                {
                    frmToyoBatterySurvey _frmToyBatterySurvey = new frmToyoBatterySurvey(CustomerID, QuestionFormID, SurveyDate);
                    UIManager.MdiChildOpenForm(_frmToyBatterySurvey);
                }
                else if (QuestionFormID == (int)PTIC.Common.Enum.QuestionForm.Lion)
                {
                    frmLionCycleBatterySurvey _frmLionCycleBatterySurvey = new frmLionCycleBatterySurvey(CustomerID, QuestionFormID, SurveyDate);
                    UIManager.MdiChildOpenForm(_frmLionCycleBatterySurvey);
                }
                else
                {
                    frmAcidSurvey _frmAcidSurvey = new frmAcidSurvey(CustomerID, QuestionFormID, SurveyDate);
                    UIManager.MdiChildOpenForm(_frmAcidSurvey);
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyPage));
            this.Close();
        }

        private void dgvAnswer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void dtpSurveyStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSurveyEndDate.Value = UIManager.ChangeOneMonthRange(dtpSurveyStartDate);
        }

        private void btnByFormType_Click(object sender, EventArgs e)
        {
            dgvAnswer.AutoGenerateColumns = false;
            LoadSearchByDateRange_SurveyType(dtpSurveyStartDate.Value, dtpSurveyEndDate.Value, cmbSurveyType.SelectedIndex + 1);
        }
    }
}
