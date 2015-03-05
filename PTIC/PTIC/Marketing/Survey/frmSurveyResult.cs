using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Common;
using PTIC.Sale.BL;
using PTIC.Marketing.BL;
using PTIC.Sale.Entities;
using PTIC.VC.Util;

namespace PTIC.Marketing.Survey
{
    public partial class frmSurveyResult : Form
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

        #region Events
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

        private void lblSetup_Click_1(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyPage));
            this.Close();
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
                
                cmbTripOrRoute.Focus();
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyPage));
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(false);
        }

        private void btnSearchBySurvery_Click(object sender, EventArgs e)
        {
            Search(true);
        }
        #endregion

        #region Private Methods
        private void LoadNBindSearch()
        {
            try
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
                DataRelation relRoute_Township =
                    new DataRelation("Route_Township", dtRoute.Columns["RouteID"], townshipInRouteTbl.Columns["RouteID"], false);
                // add relation into a dataset
                dsTownship.Relations.Add(relRoute_Township);

                bdRoute.DataSource = dsTownship;
                bdRoute.DataMember = dtRoute.TableName;

                bdTownship.DataSource = bdRoute;
                bdTownship.DataMember = "Route_Township";

                // add town and customer tables into a dataset
                ds.Tables.Add(dtTrip);
                ds.Tables.Add(dtTownInTrip);
                //ds.Tables.Add(customerTbl);

                // create data relation between town and customer
                DataRelation relTrip_Town =
                    new DataRelation("Trip_Town", dtTrip.Columns["TripID"], dtTownInTrip.Columns["TripID"], false);
                // add relation into a dataset
                ds.Relations.Add(relTrip_Town);
                //ds.Relations.Add(relTown_Customer);

                bdTrip.DataSource = ds;
                bdTrip.DataMember = dtTrip.TableName;

                bdTown.DataSource = bdTrip;
                bdTown.DataMember = "Trip_Town";

                cmbCustomerType.DataSource = new CusTypeBL().GetAll();
                cmbCustomerType.DisplayMember = "CusTypeName";
                cmbCustomerType.ValueMember = "CusTypeID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Search(bool bySurveyTypeOnly)
        {
            Common.Enum.QuestionForm qstForm;
            int intQstForm = (int)DataTypeParser.Parse(cmbSurveyType.SelectedIndex + 1, typeof(int), 1);
            if (intQstForm == (int)Common.Enum.QuestionForm.Toyo)
                qstForm = Common.Enum.QuestionForm.Toyo;
            else if (intQstForm == (int)Common.Enum.QuestionForm.Lion)
                qstForm = Common.Enum.QuestionForm.Lion;
            else
                qstForm = Common.Enum.QuestionForm.Acid;
            Customer customer = new Customer();            
            Address address = new Address();
            if (!bySurveyTypeOnly)
            {
                if (rdoRoute.Checked)
                {
                    customer.RouteID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), null);
                    address.TownshipID = chkTownTownship.Checked ? (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), null) : null;
                }
                else // trip
                {
                    customer.TripID = (int?)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), null);
                    address.TownID = chkTownTownship.Checked ? (int?)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), null) : null;
                }
            }            
            DataTable suveryResult = new SurveyAnswerBL().GetSurveyResultBy(
                dtpSurveyStartDate.Value, dtpSurveyEndDate.Value, qstForm, customer, address);

            if (qstForm == Common.Enum.QuestionForm.Lion)
                BindLionSuveryResult(suveryResult);
            else if (qstForm == Common.Enum.QuestionForm.Toyo)
                BindToyoSuveryResult(suveryResult);
            else
                MessageBox.Show("This survery does not support search!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void BindLionSuveryResult(DataTable suveryResult)
        {
            if (suveryResult == null || suveryResult.Rows.Count < 9)
            {
                MessageBox.Show("There is no record found!", "Search", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSurveyResult.DataSource = null;
                return;
            }
            DataColumn colQst = new DataColumn("Question", typeof(string));
            suveryResult.Columns.Add(colQst);                        
            foreach(DataRow row in suveryResult.Rows)
            {
                int qstNo = (int)DataTypeParser.Parse(row["QuestionNo"], typeof(int), 0);
                if (qstNo == 1)
                    row[colQst] = "(1) Lion Cycle Battery ၏သက်တမ်းရှည်ကြာသုံးစွဲနိုင်မှု";
                else if (qstNo == 2)
                    row[colQst] = "(2) Lion Cycle Battery ၏ဈေးနှုန်း";
                else if (qstNo == 3)
                    row[colQst] = "(3) ကုန်ပစ္စည်းဒီဇိုင်းအသွင်အပြင်ပေါ်တွင်ကျေနပ်မှု";
                else if (qstNo == 4)
                    row[colQst] = "(4) ကျွန်တော်များ၏ကုမ္ပဏီမှ ကုန်ပစ္စည်းဖြန့်ဖြူးမှုပေါ်တွင် လူကြီးမင်းတို့၏ထင်မြင်မှု";
                else if (qstNo == 5)
                    row[colQst] = "(5) ကုမ္ပဏီဝန်ထမ်းများ၏ ဆက်ဆံရေးပြေပြစ်မှု";
                else if (qstNo == 6)
                    row[colQst] = "(6) ရောင်းချမှုပေါ်တွင်ရရှိသောခံစားခွင့်အတွက် လူကြီးမင်း၏အမြင်";
                else if (qstNo == 7)                
                    row[colQst] = "     (က) Die Cut";                
                else if (qstNo == 8)
                    row[colQst] = "     (ခ) PB Board";
                else if (qstNo == 9)
                    row[colQst] = "     (ဂ) Flag Line";                                
            }

            DataRow groupRow = suveryResult.NewRow();
            groupRow[colQst] = "(7) ကြော်ငြာအပေါ်လူကြီးမင်းမှထင်မြင်မှု";
            suveryResult.Rows.InsertAt(groupRow, 6);

            this.dgvSurveyResult.DataSource = suveryResult;            
        }

        private void BindToyoSuveryResult(DataTable suveryResult)
        {
            if (suveryResult == null || suveryResult.Rows.Count < 17)
            {
                MessageBox.Show("There is no record found!", "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSurveyResult.DataSource = null;
                return;
            }
            DataColumn colQst = new DataColumn("Question", typeof(string));
            suveryResult.Columns.Add(colQst);
            foreach (DataRow row in suveryResult.Rows)
            {
                int qstNo = (int)DataTypeParser.Parse(row["QuestionNo"], typeof(int), 0);
                if (qstNo == 1)
                    row[colQst] = "     ကား";
                else if (qstNo == 2)
                    row[colQst] = "     Inverter";
                else if (qstNo == 3)
                    row[colQst] = "(2) Toyo Battery ၏ဈေးနှုန်း";
                else if (qstNo == 4)
                    row[colQst] = "(3) ကုန်ပစ္စည်းလှပမှု ဒီဇိုင်းအသွင်အပြင်ပေါ်တွင်ကျေနပ်မှု";
                else if (qstNo == 5)
                    row[colQst] = "(4) ကျွန်တော်များ၏ ကုမ္ပဏီမှတိုက်ရိုက်ကုန်ပစ္စည်းဖြန့်ဖြူးမှုနှင့် ပေးပို့နိုင်မှုအပေါ်တွင် လူကြီးမင်းတို့၏ ထင်မြင်မှု";
                else if (qstNo == 6)
                    row[colQst] = "(5) အာမခံပေးမှုကြောင့်သုံးစွဲသူဖောက်သည်များ၏ ကျေနပ်မှု";
                else if (qstNo == 7)
                    row[colQst] = "(6) အာမခံပေးမှုကြေင့် တဆင့်ပြန်လည်ရောင်းချသူများအတွက် အဆင်ပြေချောမွေ့မှု";
                else if (qstNo == 8)
                    row[colQst] = "(7) အရောင်းမြှင့်တင်ရေး နှင့် လက်ဆောင်ပေးနိုင်မှု";                
                else if (qstNo == 9)
                    row[colQst] = "(8) ကုမ္ပဏီဝန်ထမ်းများ၏ဆက်ဆံရေး";
                else if (qstNo == 10) // blank
                    row[colQst] = "     (က) TV";
                else if (qstNo == 11)
                    row[colQst] = "     (ခ) Die Cut";
                else if (qstNo == 12)
                    row[colQst] = "     (ဂ) PB Board";
                else if (qstNo == 13)
                    row[colQst] = "     (ဃ) Flag Line";
                else if (qstNo == 14)
                    row[colQst] = "(10) ကုမ္ပဏီသို့အလွယ်တကူဆက်သွယ်နိုင်မှု";
                else if (qstNo == 15) // blank
                    row[colQst] = "     (က) အချိန်";
                else if (qstNo == 16)
                    row[colQst] = "     (ခ) အရည်အတွက်";
                else if (qstNo == 17)
                    row[colQst] = "(12) ကုမ္ပဏီမှ Customer များသို့သတင်းပေးထိတွေ့မှု";
            }

            DataRow groupRow = suveryResult.NewRow();
            groupRow[colQst] = "(1) Toyo Battery ၏ သက်တမ်းရှည်ကြာသုံးစွဲနိုင်မှု";
            suveryResult.Rows.InsertAt(groupRow, 0);

            groupRow = suveryResult.NewRow();
            groupRow[colQst] = "(9) ကြော်ငြာအပေါ်လူကြီးမင်းမှထင်မြင်မှု";
            suveryResult.Rows.InsertAt(groupRow, 10);

            groupRow = suveryResult.NewRow();
            groupRow[colQst] = "(11) Order မှာယူပြီးကုမ္ပဏီမှပစ္စည်းပေးပို့မှု";
            suveryResult.Rows.InsertAt(groupRow, 16);

            this.dgvSurveyResult.DataSource = suveryResult;
        }
        #endregion

        #region Constructors
        public frmSurveyResult()
        {
            InitializeComponent();
            dgvSurveyResult.AutoGenerateColumns = false;
            dtpSurveyStartDate.Value = new DateTime(dtpSurveyStartDate.Value.Year, dtpSurveyStartDate.Value.Month, 1);
            LoadNBindSearch();
            cmbSurveyType.SelectedIndex = 0;
            rdoRoute.Checked = true;
        }
        #endregion

        private void dtpSurveyStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpSurveyEndDate.Value = UIManager.ChangeOneMonthRange(dtpSurveyStartDate);
        }

        

                                                               
    }
}
