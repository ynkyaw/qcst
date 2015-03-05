using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Marketing;
using System.Collections;

namespace PTIC.Sale.Setup
{
    public partial class frmCustomerInformations : Form
    {
        DataTable customerTbl = null;
        DataTable townTbl = null;
        Customer customer = new Customer();
        Address address = new Address();
        DataTable townshipTbl = null;
        DataTable statedivisionTbl = null;
        DataTable tripTbl = null;
        DataTable routeTbl = null;
        DataTable cusclassTbl = null;

        DataTable townIntripTbl = null;
        DataTable townshipInRouteTbl = null;

        int CusID;

        /// <summary>
        /// DataSet & Binding Source for Town
        /// </summary>
        DataSet ds = new DataSet();

        BindingSource bdTrip = new BindingSource();
        BindingSource bdTown = new BindingSource();
        BindingSource bdCustomer = new BindingSource();

        /// <summary>
        /// DataSet & Binding Source for Township
        /// </summary>
        DataSet dsTownship = new DataSet();

        BindingSource bdRoute = new BindingSource();
        BindingSource bdTownship = new BindingSource();
        BindingSource bdCustomerTownship = new BindingSource();

        DataTable _dtCustomer = null;

        DataSet dsRoute = new DataSet();
        DataSet dsTrip = new DataSet();

        //BindingSource bdRoute = new BindingSource();
        //BindingSource bdCustomerRoute = new BindingSource();

        //BindingSource bdTrip = new BindingSource();
        //BindingSource bdCustomerTrip = new BindingSource();



        public frmCustomerInformations()
        {
            InitializeComponent();
            LoadData();
            BindData();
            LoadNBindSearch();
            rdoTrip.Checked = true;
            //cmbCustomer.Focus();
        }

        #region Private Method
        public void LoadData()
        {
            try
            {
                customerTbl = new CustomerBL().GetAll();
                this._dtCustomer = customerTbl.Copy();
                townTbl = new TownBL().GetAll();
                townshipTbl = new TownshipBL().GetAll();
                statedivisionTbl = new SDivisionBL().GetAll();
                tripTbl = new TripBL().GetAll();

                routeTbl = new RouteBL().GetAll();

                cusclassTbl = new CustomerClassBL().GetAll();

                townshipInRouteTbl = new TownshipInRouteBL().GetAll();
                townIntripTbl = new TownInTripBL().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void BindData()
        {
            //Set AutoGenerateColumns False
            dgvsetupCustomerInfo.AutoGenerateColumns = false;
            dgvsetupCustomerInfo.DataSource = customerTbl;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerInformation frmCustomerInformation = new frmCustomerInformation();
            frmCustomerInformation.ShowDialog();
            LoadData();
            BindData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvsetupCustomerInfo.SelectedRows.Count == 1)
            {
                // Customer
                customer.ID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[CustomerID.Index].Value, typeof(int), -1);
                customer.AddrID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[AddrID.Index].Value, typeof(int), -1);
                customer.CusCode = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[CusCode.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[CusCode.Index].Value.ToString();
                customer.CusName = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[CusName.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[CusName.Index].Value.ToString();
                customer.Phone1 = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[Phone1.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[Phone1.Index].Value.ToString();
                customer.Phone2 = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[Phone2.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[Phone2.Index].Value.ToString();
                customer.Fax = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[Fax.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[Fax.Index].Value.ToString();
                customer.Email = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[Email.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[Email.Index].Value.ToString();
                customer.Website = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[Website.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[Website.Index].Value.ToString();
                customer.BankID = (int?)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[BankID.Index].Value, typeof(int), 0);
                customer.BankAccNo = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[BankAccNo.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[BankAccNo.Index].Value.ToString();
                customer.RouteID = (int?)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[colRouteID.Index].Value, typeof(int), null);
                customer.TripID = (int?)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[colTripID.Index].Value, typeof(int), null);
                customer.CusType = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[CusTypeID.Index].Value, typeof(int), -1);
                customer.CusClassID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[CusClassID.Index].Value, typeof(int), -1);
                customer.CreditAmount = (decimal)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[CreditAmount.Index].Value, typeof(decimal), 0);
                customer.CreditLimit = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[CreditLimit.Index].Value, typeof(int), 0);
                customer.CusDate = (DateTime)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[CusDate.Index].Value, typeof(DateTime), DateTime.Now);
                customer.Remark = String.IsNullOrEmpty(dgvsetupCustomerInfo.SelectedCells[Remark.Index].Value.ToString()) ? "" : dgvsetupCustomerInfo.SelectedCells[Remark.Index].Value.ToString();

                // Photos
                DataTable dtPhotos = new CustomerBL().GetPhotos(customer.ID);
                if (dtPhotos.Rows.Count > 0)
                {
                    DataRow row = dtPhotos.Rows[0];
                    customer.Photo1 = row["Photo1"] != DBNull.Value ? (byte[])row["Photo1"] : null;
                    customer.Photo2 = row["Photo2"] != DBNull.Value ? (byte[])row["Photo2"] : null;
                    customer.Photo3 = row["Photo3"] != DBNull.Value ? (byte[])row["Photo3"] : null;
                    customer.Photo4 = row["Photo4"] != DBNull.Value ? (byte[])row["Photo4"] : null;
                    customer.Photo5 = row["Photo5"] != DBNull.Value ? (byte[])row["Photo5"] : null;
                }

                // Address
                address.Hno = (string)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[HNo.Index].Value, typeof(string), null);
                address.Street = (string)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[Street.Index].Value, typeof(string), null);
                address.Quartar = (string)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[Quater.Index].Value, typeof(string), null);
                address.TownshipID = (int?)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[colTownshipID.Index].Value, typeof(int), null);
                address.TownID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[colTownID.Index].Value, typeof(int), -1);
                address.StateDivisionID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[StateDivision.Index].Value, typeof(int), -1);
                address.Country = (string)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[dgvColCountry.Index].Value, typeof(string), null);
                frmCustomerInformation cusInfo = new frmCustomerInformation(customer, address);
                UIManager.OpenForm(cusInfo);
                LoadData();
                BindData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            #region Single Delete
            int sup = 0;
            if (dgvsetupCustomerInfo.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show("Please select row(s) that you want to delete!");
                return;
            }
            if (MessageBox.Show("Are you sure want to delete Selected Row?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                customer.ID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.SelectedCells[0].Value.ToString(), typeof(int), null);
                int Index = dgvsetupCustomerInfo.CurrentRow.Index;
                dgvsetupCustomerInfo.Rows.RemoveAt(Index);
                try
                {
                    sup = new CustomerBL().DeleteByID(customer.ID);
                    if (sup > 0)
                    {
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            if (GlobalCache.is_sale)
            {
                UIManager.MdiChildOpenForm(typeof(frmSetupPage));
                this.Close();
            }
            else
            {
                UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
                this.Close();
            }
        }
        
        private void dgvsetupCustomerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvsetupCustomerInfo.SelectedRows.Count > 0)
            {
                int currentrow = e.RowIndex;
                CusID = (int)DataTypeParser.Parse(dgvsetupCustomerInfo.CurrentRow.Cells["CustomerID"].Value, typeof(int), -1);
            }
        }

        private void dgvsetupCustomerInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    gridView.RowHeadersWidth = 50;
                }
            }
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
        
        private void LoadNBindSearch()
        {
            DataTable dtCustomer = customerTbl.Copy();
            DataTable dtCustomerRoute = customerTbl.Copy();
            DataTable dtCustomerTrip = customerTbl.Copy();

            DataTable dtRoute = routeTbl.Copy();
            DataTable dtTrip = tripTbl.Copy();
            DataTable dtTownInTrip = townIntripTbl.Copy();

            // generate the data to insert
            DataRow tripInsert = dtTrip.NewRow();
            tripInsert["TripID"] = -1;
            tripInsert["TripName"] = "All";
            // insert in the Index 0 place
            dtTrip.Rows.InsertAt(tripInsert, 0);

            // generate the data to insert
            DataRow routeInsert = dtRoute.NewRow();
            routeInsert["RouteID"] = -1;
            routeInsert["RouteName"] = "All";
            // insert in the Index 0 place
            dtRoute.Rows.InsertAt(routeInsert, 0);

            // add town and customer tables into a dataset
            dsTownship.Tables.Add(dtRoute);
            dsTownship.Tables.Add(townshipInRouteTbl);
            dsTownship.Tables.Add(dtCustomer);

            // create data relation between township and customer
            DataRelation relRoute_Township = new DataRelation("Route_Township", dtRoute.Columns["RouteID"], townshipInRouteTbl.Columns["RouteID"], false);
            DataRelation relTownship_Customer = new DataRelation("Township_Customer", townshipInRouteTbl.Columns["TownshipID"], dtCustomer.Columns["TownshipID"], false);
            // add relation into a dataset
            dsTownship.Relations.Add(relRoute_Township);
            dsTownship.Relations.Add(relTownship_Customer);

            bdRoute.DataSource = dsTownship;
            bdRoute.DataMember = dtRoute.TableName;

            bdTownship.DataSource = bdRoute;
            bdTownship.DataMember = "Route_Township";

            bdCustomerTownship.DataSource = bdTownship;
            bdCustomerTownship.DataMember = "Township_Customer";

            try
            {
                // add town and customer tables into a dataset
                ds.Tables.Add(dtTrip);
                ds.Tables.Add(dtTownInTrip);
                ds.Tables.Add(customerTbl);

                // create data relation between town and customer
                DataRelation relTrip_Town = new DataRelation("Trip_Town", dtTrip.Columns["TripID"], dtTownInTrip.Columns["TripID"], false);
                DataRelation relTown_Customer = new DataRelation("Town_Customer", dtTownInTrip.Columns["TownID"], customerTbl.Columns["TownID"], false);
                // add relation into a dataset
                ds.Relations.Add(relTrip_Town);
                ds.Relations.Add(relTown_Customer);

                bdTrip.DataSource = ds;
                bdTrip.DataMember = dtTrip.TableName;

                bdTown.DataSource = bdTrip;
                bdTown.DataMember = "Trip_Town";

                bdCustomer.DataSource = bdTown;
                bdCustomer.DataMember = "Town_Customer";
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        private void frmCustomerInformations_Load(object sender, EventArgs e)
        {
            // rdbTown.Checked = true;          
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
            BindData();
            dgvsetupCustomerInfo.DataSource = _dtCustomer;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Search();
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            //Search();
        }

        private void cmbTownTownship_SelectedValueChanged(object sender, EventArgs e)
        {
            //Search();
        }

        private void Search()
        {
            Hashtable hashTbl = new Hashtable();
            int TownOrTownshipID = (int)DataTypeParser.Parse(cmbTownTownship.SelectedValue, typeof(int), 0);
            int CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), 0);

            if (rdoRoute.Checked && chkTownTownship.Checked && chkCustomer.Checked)
            {
                int RouteID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), 0);
                hashTbl.Add("RouteID", RouteID);
                hashTbl.Add("TownshipID", TownOrTownshipID);
                hashTbl.Add("CustomerID", CustomerID);
                // dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableBy(_dtCustomer, "RouteID", RouteID);
                dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableByExactFields(_dtCustomer, hashTbl);
            }
            else if (chkCustomerOnly.Checked)
            {
                String CustomerName = txtCustomer.Text.ToString().Trim();
                dgvsetupCustomerInfo.DataSource = new CustomerBL().SearchByCustomerName(txtCustomer.Text.Trim());
            }
            else if (rdoRoute.Checked && chkTownTownship.Checked)
            {
                int RouteID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), 0);
                hashTbl.Add("RouteID", RouteID);
                hashTbl.Add("TownshipID", TownOrTownshipID);
                //hashTbl.Add("CustomerID", CustomerID);
                // dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableBy(_dtCustomer, "RouteID", RouteID);
                dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableByExactFields(_dtCustomer, hashTbl);
            }
            else if (rdoRoute.Checked)
            {
                int RouteID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), -1);
                hashTbl.Add("RouteID", RouteID);
                //hashTbl.Add("TownshipID", TownOrTownshipID);
                //hashTbl.Add("CustomerID", CustomerID);
                // dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableBy(_dtCustomer, "RouteID", RouteID);
                if (RouteID == -1)
                {
                    dgvsetupCustomerInfo.DataSource = new CustomerBL().SearchAllRoute();
                }
                else
                {
                    dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableByExactFields(_dtCustomer, hashTbl);
                }
            }
            else if (rdoTrip.Checked && chkTownTownship.Checked && chkCustomer.Checked)
            {
                int TripID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), -1);
                hashTbl.Add("TripID", TripID);
                hashTbl.Add("TownID", TownOrTownshipID);
                hashTbl.Add("CustomerID", CustomerID);

                dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableByExactFields(_dtCustomer, hashTbl);

                // dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableBy(_dtCustomer, "TripID", TripID);
            }
            else if (rdoTrip.Checked && chkTownTownship.Checked)
            {
                int TripID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), 0);
                hashTbl.Add("TripID", TripID);
                hashTbl.Add("TownID", TownOrTownshipID);
                //  hashTbl.Add("CustomerID", CustomerID);
                dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableByExactFields(_dtCustomer, hashTbl);
                // dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableBy(_dtCustomer, "TripID", TripID);
            }
            else if (rdoTrip.Checked)
            {
                int TripID = (int)DataTypeParser.Parse(cmbTripOrRoute.SelectedValue, typeof(int), 0);
                hashTbl.Add("TripID", TripID);
                //hashTbl.Add("TownID", TownOrTownshipID);
                //hashTbl.Add("CustomerID", CustomerID);
                if (TripID == -1)
                {
                    dgvsetupCustomerInfo.DataSource = new CustomerBL().SearchAllTrip();
                }
                else
                {
                    dgvsetupCustomerInfo.DataSource = DataUtil.GetDataTableByExactFields(_dtCustomer, hashTbl);
                }
            }
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            //Search();
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
                cmbCustomer.DataSource = bdCustomerTownship;
                cmbTownTownship.ValueMember = "TownshipID";
                cmbTownTownship.DisplayMember = "Township";

                cmbCustomer.ValueMember = "CustomerID";
                cmbCustomer.DisplayMember = "CusName";

                cmbTripOrRoute.Focus();
            }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnTripOrRouteSearch_Click(object sender, EventArgs e)
        {
            LoadData();
            BindData();
            Search();
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
                cmbCustomer.DataSource = bdCustomer;
                cmbTownTownship.ValueMember = "TownID";
                cmbTownTownship.DisplayMember = "Town";
                cmbCustomer.DisplayMember = "CusName";
                cmbCustomer.ValueMember = "CustomerID";
                cmbTripOrRoute.Focus();
            }
        }

        private void cmbTownTownship_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}
