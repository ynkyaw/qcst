using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.Marketing.DailyMarketing;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmCusComplaint : Form
    {

        private int? _ComplaintID = null;
        String address = String.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ComplaintSaveHandler(object sender, ComplaintSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event ComplaintSaveHandler ComplaintSavedHandler;

        Complaint complaint = new Complaint();
        ComplaintServiceRecord complaintservicerecord = new ComplaintServiceRecord();
        int CusID = 0;

      

        public frmCusComplaint()
        {
            InitializeComponent();
            LoadNBindData();
        }

        public frmCusComplaint(int? complaintID, Customer cus, Township township)
            : this()
        {
            //InitializeComponent();
            LoadNBindData();
            this._ComplaintID = complaintID;
            this.cmbTownship.SelectedValue = township.TownshipID;
            this.cmbCustomerType.SelectedValue = cus.CusType;
            this.cmbCustomerName.SelectedValue = cus.ID;
            int intComplaintActivity = (int)DataTypeParser.Parse(this._ComplaintID, typeof(int), -1);
          //  LoadNBindData();
            // Load APSuport and Marketing Promotion
            LoadNBindComplaint(intComplaintActivity);
        }


        #region Private Method
        private void LoadNBindData()
        {
            DataSet ds = new DataSet();
            DataSet dsCus = new DataSet();
            BindingSource bdBrand = new BindingSource();
            BindingSource bdProduct = new BindingSource();

            BindingSource bdTownship = new BindingSource();                
            BindingSource bdTownshipWithCusType = new BindingSource();
            BindingSource bdCustomer = new BindingSource();
                        
            try
            {                
                DataTable dtEmployee = new EmployeeBL().GetAll();

                DataTable dtBrand = new BrandBL().GetOwnBrands().Copy(); // make copy to be added into a single dataset
                DataTable dtProduct = new ProductBL().GetAll().Copy(); // make copy to be added into a single dataset                

                DataTable dtTownship = new TownshipBL().GetAll();
                DataTable dtTownshipWithCusType = new TownshipBL().GetWithCustomerType();
                DataTable dtCustomer = new CustomerBL().GetAll();

                // add two datatables into a single dataset
                ds.Tables.Add(dtBrand);
                ds.Tables.Add(dtProduct);

                // add three datatables into a single dataset
                dsCus.Tables.Add(dtTownship);
                dsCus.Tables.Add(dtTownshipWithCusType);
                dsCus.Tables.Add(dtCustomer);

                // create data relations among two tables
                DataRelation relBrand_Product = new DataRelation("Brand_Product",
                    dtBrand.Columns["BrandID"], dtProduct.Columns["BrandID"]);
                ds.Relations.Add(relBrand_Product);

                // create data relations among three tables
                DataRelation relTownship_CusType = new DataRelation("Township_CusType",
                       dtTownship.Columns["TownshipID"], dtTownshipWithCusType.Columns["TownshipID"],false);
                DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                       dtTownshipWithCusType.Columns["CusType"], dtCustomer.Columns["CusType"], false);
                dsCus.Relations.Add(relTownship_CusType);                
                dsCus.Relations.Add(relCusType_Customer);


                /** relation between Brand and Category **/
                bdBrand.DataSource = ds;
                bdBrand.DataMember = dtBrand.TableName;

                bdProduct.DataSource = bdBrand;
                bdProduct.DataMember = "Brand_Product";

                /** relation between CusType and Customer **/

                bdTownship.DataSource = dsCus;
                bdTownship.DataMember = dtTownship.TableName;

                bdTownshipWithCusType.DataSource = bdTownship;
                bdTownshipWithCusType.DataMember = "Township_CusType";

                bdCustomer.DataSource = bdTownshipWithCusType;
                bdCustomer.DataMember = "CusType_Customer";

                // bind binding list to each combo datasource
                cmbBrand.DataSource = bdBrand;
                cmbProductName.DataSource = bdProduct;

                // Township
                cmbTownship.DataSource = bdTownship;
                // Customer Type
                cmbCustomerType.DataSource = bdTownshipWithCusType;
                // Customer
                cmbCustomerName.DataSource = bdCustomer;

                cmbSoldBrand.DataSource = dtBrand;
                cmbEmployee.DataSource = dtEmployee;
            }
            catch (SqlException sqle)
            {
                //_logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadNBindComplaint(int? ComplaintID)
        {
            if (!ComplaintID.HasValue) // No need to load maketing detail for a new detail
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtComplaint = new ComplaintBL().GetAll(ComplaintID.Value, conn);
                if (dtComplaint.Rows.Count < 1)
                    return;
                complaintservicerecord.ID = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["ServiceRecordID"], typeof(int), -1);
                cmbTownship.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["TownshipID"], typeof(int), -1);
                cmbCustomerType.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["CusTypeID"], typeof(int), -1);
                cmbCustomerName.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["CustomerID"], typeof(int), -1);
                txtComplaintPerson.Text =(string)DataTypeParser.Parse(dtComplaint.Rows[0]["ComplaintPerson"],typeof(string),null);
                txtPost.Text =(string)DataTypeParser.Parse(dtComplaint.Rows[0]["Post"],typeof(string),null);
                dtpDate.Value = (DateTime)DataTypeParser.Parse(dtComplaint.Rows[0]["TranDate"], typeof(DateTime), null);
                dtpComplaintAcceptDate.Value = (DateTime)DataTypeParser.Parse(dtComplaint.Rows[0]["ComplaintDate"], typeof(DateTime), null);
                cmbSoldBrand.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["BrandID"], typeof(int), -1);
                cmbEmployee.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["EmpID"], typeof(int), -1);
                txtUnConvience.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["Description"],typeof(string),null);
                txtToSolve.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["Request"],typeof(string),null);
                txtOtherRequirement.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["OtherRequirement"], typeof(string), null);
                txtCheckedPlace.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["CheckedPlaces"], typeof(string), null);
                txtComplaintPerson.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["ComplaintPerson"], typeof(string), null);
                txtContactPersonName.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["ConPersonName"], typeof(string), null);
                txtContactPersonPhone.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["MobilePhone"], typeof(string), null);
                txtPhone1.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["Phone1"], typeof(string), null);
                txtPhone2.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["Phone2"], typeof(string), null); 

                //ComplaintServiceRecord
                cmbBrand.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["BrandID"], typeof(int), -1);
                cmbProductName.SelectedValue = (int)DataTypeParser.Parse(dtComplaint.Rows[0]["ProductID"], typeof(int), -1);
                dtpProductionDate.Value = (DateTime)DataTypeParser.Parse(dtComplaint.Rows[0]["ProductionDate"], typeof(DateTime), null);
                txtServiceNo.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["ServiceNo"],typeof(string),null);
                dtpPurchasedDate.Value = (DateTime)DataTypeParser.Parse(dtComplaint.Rows[0]["PurchasedDate"], typeof(DateTime), null);
                txtPurchasedShop.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["PurchasedShop"], typeof(string), null);
                txtPeriod.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["UsedPeriod"], typeof(string), null);
                txtUsedPlace.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["UsedPlace"], typeof(string), null);
                txtChargingTime.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["ChargingAmp"], typeof(string), null);
                txtUsedPeriod.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["OutAmp"], typeof(string), null);
                txtAmp.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["UsingAmp"], typeof(string), null); 
                txtSize.Text = (string)DataTypeParser.Parse(dtComplaint.Rows[0]["UsingSize"], typeof(string), null); 


            }
            catch (SqlException Sqle)
            {
                //To do
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            //  int affectedrow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                //Complaint
                
                complaint.CusID = CusID;
                complaint.EmpID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1);
                complaint.BrandID = (int)DataTypeParser.Parse(cmbSoldBrand.SelectedValue, typeof(int), -1);
                complaint.TranDate = dtpDate.Value;
                complaint.ComplaintDate = dtpComplaintAcceptDate.Value;
                complaint.ComplaintPerson = txtComplaintPerson.Text;
                complaint.Post = txtPost.Text;
                complaint.Description = txtUnConvience.Text;
                complaint.Request = txtToSolve.Text;
                complaint.OtherRequirement = txtOtherRequirement.Text;
                complaint.CheckedPlaces = txtCheckedPlace.Text;

                //ComplaintServiceRecord
               
                complaintservicerecord.ProductID = (int)DataTypeParser.Parse(cmbProductName.SelectedValue, typeof(int), -1);
                complaintservicerecord.ProductionDate = dtpProductionDate.Value;
                complaintservicerecord.ServiceNo = txtServiceNo.Text;
                complaintservicerecord.PurchasedDate = dtpPurchasedDate.Value;
                complaintservicerecord.PurchasedShop = txtPurchasedShop.Text;
                complaintservicerecord.UsedPeriod = (int)DataTypeParser.Parse(txtPeriod.Text, typeof(int), 0);
                complaintservicerecord.UsedPlace = txtUsedPlace.Text;
                complaintservicerecord.Volt = 0;
                complaintservicerecord.ChargingAmp = (float)DataTypeParser.Parse(txtChargingTime.Text, typeof(float), 0);
                complaintservicerecord.OutAmp = (float)DataTypeParser.Parse(txtUsedPeriod.Text, typeof(float), 0);
                complaintservicerecord.UsingAmp = (float)DataTypeParser.Parse(txtAmp.Text, typeof(float), 0);
                complaintservicerecord.UsingSize = (int)DataTypeParser.Parse(txtSize.Text, typeof(int), 0);

                if (_ComplaintID.HasValue)
                {
                    complaint.ComplaintID = _ComplaintID.Value;
                    complaintservicerecord.ComplainID = _ComplaintID.Value;
                    _ComplaintID = new ComplaintBL().Update(complaint, complaintservicerecord, conn);
                }
                else
                {
                    _ComplaintID = new ComplaintBL().Insert(complaint, complaintservicerecord, conn);
                }
                if (_ComplaintID.HasValue)
                {
                    ComplaintSaveEventArgs complaintSaved = new ComplaintSaveEventArgs(_ComplaintID.Value);
                    ComplaintSavedHandler(this, complaintSaved);
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (SqlException Sqle)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CusID = (int)DataTypeParser.Parse(cmbCustomerName.SelectedValue, typeof(int), 0);
                DataTable dtContactPerson = new ContactPersonBL().GetAll(CusID);
                foreach (DataRow row in dtContactPerson.Rows)
                {
                    txtContactPersonName.Text = row["ConPersonName"].ToString();
                    txtContactPersonPhone.Text = row["MobilePhone"].ToString();
                    //txtPost.Text = row["Post"].ToString();
                }

                DataTable dtCustomer = new CustomerBL().GetAllByCusID(CusID);
                foreach (DataRow customer in dtCustomer.Rows)
                {
                    // No            
                    address += string.IsNullOrEmpty(customer["Hno"].ToString()) ? string.Empty : customer["Hno"].ToString() + ", ";
                    // Street
                    address += string.IsNullOrEmpty(customer["Street"].ToString()) ? string.Empty : customer["Street"].ToString() + ", ";
                    // Quarter
                    address += string.IsNullOrEmpty(customer["Quartar"].ToString()) ? string.Empty : customer["Quartar"].ToString() + ", ";
                    // Township
                    address += string.IsNullOrEmpty(customer["Township"].ToString()) ? string.Empty : customer["Township"].ToString() + ", ";
                    // Town
                    address += string.IsNullOrEmpty(customer["Town"].ToString()) ? string.Empty : customer["Town"].ToString() + ", ";
                    // State / Division
                    address += string.IsNullOrEmpty(customer["StateDivisionName"].ToString()) ? string.Empty : customer["StateDivisionName"].ToString() + ", ";
                    txtAddress.Text = address;
                    txtPhone1.Text = customer["Phone1"].ToString();
                    txtPhone2.Text = customer["Phone2"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Inner Class
        public class ComplaintSaveEventArgs : EventArgs
        {
            private int? _ComplaintID = null;
            public ComplaintSaveEventArgs(int? ComplaintID)
            {
                this._ComplaintID = ComplaintID;
            }
            public int? ComplaintID
            {
                get { return this._ComplaintID; }
            }
        }
        #endregion

    }
}
