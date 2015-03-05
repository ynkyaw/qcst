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
using PTIC.Common.BL;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_AP_BalanceViewer : Form
    {
        public frmRV_AP_BalanceViewer()
        {
            InitializeComponent();
            LoadNBindCombo();
            rdoDept.Checked = true;
        }

        #region Private Methods
        private void LoadNBindCombo()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                DataSet ds = new DataSet();

                BindingSource bdAPSubCat = new BindingSource(); // APSubCategroy
                BindingSource bdPosm = new BindingSource(); // POSM

                DataTable  dtPosm= new APMaterialDAO().SelectAllWithAPSubCat();
                DataTable dtAPSubCat = new APSubCategoryDAO().SelectAll();

                // add two datatables into a single dataset
                ds.Tables.Add(dtAPSubCat);
                ds.Tables.Add(dtPosm);

                // create data relations among two tables
                DataRelation relAPSubCat_Posm = new DataRelation("APSubCat_Posm",
                    dtAPSubCat.Columns["ID"], dtPosm.Columns["AP_SubCategoryID"], false);
                ds.Relations.Add(relAPSubCat_Posm);

                bdAPSubCat.DataSource = ds;
                bdAPSubCat.DataMember = dtAPSubCat.TableName;

                bdPosm.DataSource = bdAPSubCat;
                bdPosm.DataMember = "APSubCat_Posm";
                
                // Bind APSubCategory
                cmbAPSubCat.DataSource = bdAPSubCat;
                cmbAPSubCat.DisplayMember = "APSubCategoryName";
                cmbAPSubCat.ValueMember = "ID";
                // Bind POSM
                cmbPOSM.DataSource = bdPosm;
                cmbPOSM.DisplayMember = "APMaterialName";
                cmbPOSM.ValueMember = "AP_MaterialID";
            }
            catch (SqlException Sqle)
            {
                //ToastMessageBox.Show(Resource.errFailedToSave);  // To do
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }

            ////   cboMaterialName.DataSource = new APMaterialDAO().SelectAll();
            //cmbPOSM.DataSource = 
            //cmbPOSM.DisplayMember = "APMaterialName";
            //cmbPOSM.ValueMember = "AP_MaterialID";

            //cmbAPSubCat.DataSource = 
            //cmbAPSubCat.DisplayMember = "APSubCategoryName";
            //cmbAPSubCat.ValueMember = "ID";
        }

        private void Search()
        {
            int? DeptID,VenID,APMaterialID =null;
            int? SubCategoryID = null;

            if(rdoDept.Checked)
            {
                 DeptID =(int?)DataTypeParser.Parse(cmbDeptVen.SelectedValue,typeof(int),null);
                 VenID = null;
            }
            else
            {
                DeptID = null;
                VenID = (int?)DataTypeParser.Parse(cmbDeptVen.SelectedValue,typeof(int),null);
            }

             if (chkPosm.Checked)
            {
                APMaterialID = (int?)DataTypeParser.Parse(cmbPOSM.SelectedValue, typeof(int), null);
                SubCategoryID = null;
            }
            else if (chkAPSubCat.Checked)
            {
                SubCategoryID = (int?)DataTypeParser.Parse(cmbAPSubCat.SelectedValue, typeof(int), null);
                APMaterialID = null;
            }           
            else if (chkAPSubCat.Checked == false && chkPosm.Checked == false)
            {
                APMaterialID =null;
                SubCategoryID = null;
            }

            DataTable dt = new RP_AP_BalanceBL().GetAPBalanceBy(DeptID,VenID,null,SubCategoryID,APMaterialID);
           //  DataTable dt = new RP_AP_BalanceBL().GetAPBalanceBy(8, null, null, null, null);
            rpViewerAPBalance.Visible = true;
            rpViewerAPBalance.LocalReport.ReportEmbeddedResource = "PTIC.Report.AP_Balance.rdlc";
            rpViewerAPBalance.LocalReport.DataSources.Clear();
            rpViewerAPBalance.LocalReport.DataSources.Add(new ReportDataSource("AP_BalancesDataSet", dt));
            rpViewerAPBalance.RefreshReport();
        }
        #endregion

        private void AP_BalanceViewer_Load(object sender, EventArgs e)
        {

            this.rpViewerAPBalance.RefreshReport();
            this.rpViewerAPBalance.RefreshReport();
        }

        private void rdoDept_CheckedChanged(object sender, EventArgs e)
        {            
            try
            {                
                if (rdoDept.Checked)
                {
                    // Department, Ven & Employee
                    cmbDeptVen.DataSource = new DepartmentBL().GetAll();
                    cmbDeptVen.ValueMember = "ID";
                    cmbDeptVen.DisplayMember = "DeptName";
                    cmbDeptVen.SelectedValue = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
                }
                else
                {
                    try
                    {
                        //  Vehicle Binding
                        cmbDeptVen.DataSource = new VehicleBL().GetAll();
                        cmbDeptVen.DisplayMember = "VenNo";
                        cmbDeptVen.ValueMember = "VehicleID";                      
                    }
                    catch (Exception ee)
                    {
                        throw ee;
                    }
                }
            }
            catch (Exception exe)
            {
                throw exe;
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
                //   pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void cmbAPSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAPSubCat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPosm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void AP_BalanceViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpViewerAPBalance.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
