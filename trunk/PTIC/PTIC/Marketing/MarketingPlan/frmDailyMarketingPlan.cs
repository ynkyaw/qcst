using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Marketing.DA;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.Util;
using PTIC.Sale.BL;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmDailyMarketingPlan : Form
    {
        /// <summary>
        /// Record table for different CustomerType
        /// </summary>
        private DataTable _dtCusType = null;

        /// <summary>
        /// Index of Township column from DataGridView
        /// </summary>
        private int _indexTownshipColumn = -1;

        /// <summary>
        /// Index of CustomerType column from DataGridView
        /// </summary>
        private int _indexCusTyepColumn = -1;

        /// <summary>
        /// 
        /// </summary>
        private ComboBox _cmbCusType = null;

      
        private PTIC.Marketing.Entities.MarketingPlan marketingplan = new PTIC.Marketing.Entities.MarketingPlan();
        DataTable marketingplanTbl = new DataTable();

        public frmDailyMarketingPlan()
        {
            InitializeComponent();
            this._indexTownshipColumn = dgvMarketingPlan.Columns.IndexOf(dgvMarketingPlan.Columns["dgvColTownship"]);
            this._indexCusTyepColumn = dgvMarketingPlan.Columns.IndexOf(dgvMarketingPlan.Columns["dgvColCusType"]);
            LoadNBindEmployee();
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvMarketingPlan);
        }

        #region Private Method
        private void LoadNBindData()
        {
            DataSet ds = new DataSet();            
            try
            {                
                //Bind Township
                dgvColTownship.DataSource = new TownshipBL().GetAll();
                //Bind CustomerType
              //  dgvColCusType.DataSource = this._dtCusType = new CusTypeBL().GetAll(conn);
                dgvColCusType.DataSource = this._dtCusType = new CusTypeBL().GetAll();
                dgvColTownship.DisplayMember = "Township";
                dgvColTownship.ValueMember = "TownshipID";

                dgvColCusType.DisplayMember = "CusTypeName";
                dgvColCusType.ValueMember = "CusTypeID";

                //DataTable dttownship = new TownshipBL().GetAll(conn).Copy(); // make copy to be added into a single dataset
                //DataTable dtcustype = new CusTypeBL().GetAll(conn).Copy();
                //// DataTable dtcustomer = new CustomerBL().GetAll(conn); // make copy to be added into a single dataset

                //// add three datatables into a single dataset sdf
                //ds.Tables.Add(dttownship);
                //ds.Tables.Add(dtcustype);
                ////ds.Tables.Add(dtcustomer);

                //// create data relations among three tables
                //try
                //{
                //    DataRelation relTownship_CusType = new DataRelation("Township_CusType",
                //        dttownship.Columns["TownshipID"], dtcustype.Columns["TownshipID"]);
                //    //DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                //    //    dtcustype.Columns["CusTypeID"], dtcustomer.Columns["CusType"]);
                //    ds.Relations.Add(relTownship_CusType);
                //    //ds.Relations.Add(relCusType_Customer);

                //    /** relation between Brand and Category **/
                //    bdtownship.DataSource = ds;
                //    bdtownship.DataMember = dttownship.TableName;

                //    bdcustomertype.DataSource = bdtownship;
                //    bdcustomertype.DataMember = "Township_CusType";

                //    //bdcustomer.DataSource = bdcustomertype;
                //    //bdcustomer.DataMember = "CusType_Customer";
                //}
                //catch (Exception ex) { }

                //// bind binding list to each combo datasource
                //dgvColTownship.DataSource = bdtownship;
                //dgvColTownship.DisplayMember = "Township";
                //dgvColTownship.ValueMember = "TownshipID";

                //dgvColCusType.DataSource = bdcustomertype;
                //dgvColCusType.DisplayMember = "CusTypeName";
                //dgvColCusType.ValueMember = "CusTypeID";

                ////dgvColCusName.DataSource = bdcustomer;
                ////dgvColCusName.DisplayMember = "CusName";
                //////dgvColCusName.ValueMember = "CustomerID";
                //////dgvColCusName.DataPropertyName = "CustomerID";
            }
            catch (SqlException sqle)
            {
                // _logger.Error(sqle);
            }           
        }

        private void LoadNBindEmployee()
        {
            DataSet ds = new DataSet();
            DataTable employeeTbl = null;

            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                employeeTbl = new EmployeeBL().GetAll();
                marketingplanTbl = new MarketingPlanBL().GetMarketingPlan(0,conn);
                DataTable dtEmployeesByDept = null;
                if (GlobalCache.is_sale == false)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                }
                //cboManagerID.DataSource = dtEmployeesByDept;
                //cboManagerID.ValueMember = "EmployeeID";
                //cboManagerID.DisplayMember = "EmpName";

                dgvColEmployee.DataSource = dtEmployeesByDept;
                dgvColEmployee.ValueMember = "EmployeeID";
                dgvColEmployee.DisplayMember = "EmpName";

                dgvMarketingPlan.AutoGenerateColumns = false; // Autogenerate Columns False
                dgvMarketingPlan.DataSource = marketingplanTbl;
                
                dgvColCusType.DisplayMember = "CusTypeName";
              //  dgvColCusType.ValueMember = "CusTypeID";
                //dgvMarketingPlan[0, 0].Selected = true;
             
                dgvColCusName.DataSource = marketingplanTbl;
                dgvColCusName.ValueMember = "CustomerID";
                dgvColCusName.DisplayMember = "CusName";
                dgvColCusName.DataPropertyName = "CustomerID";
            }
            catch (SqlException Sqle)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void Save()
        {
            DataTable dt = dgvMarketingPlan.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    marketingplan.CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                    marketingplan.PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"].ToString(), typeof(DateTime), null);
                    marketingplan.EmpID = (int)DataTypeParser.Parse(row["EmpID"].ToString(), typeof(int), -1);
                    marketingplan.MarketingType = 0;
                    if (marketingplan.CustomerID == -1)
                    {
                        ToastMessageBox.Show(Resource.errCustomer,Color.Red);
                        return;
                    }
                    else if (marketingplan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show(Resource.errPlanDate,Color.Red);
                    }        
                    sup = MarketingPlanDA.InsertMarketingPlan(marketingplan, conn);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    marketingplan.ID = (int)DataTypeParser.Parse(row["MarketingPlanID"].ToString(), typeof(int), -1);
                    sup = MarketingPlanDA.DeleteByID(marketingplan, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    marketingplan.ID = (int)DataTypeParser.Parse(row["MarketingPlanID"].ToString(), typeof(int), -1);
                    marketingplan.CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                    marketingplan.PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"].ToString(), typeof(DateTime), null);
                    marketingplan.EmpID = (int)DataTypeParser.Parse(row["EmpID"].ToString(), typeof(int), -1);
                    marketingplan.MarketingType = (int)DataTypeParser.Parse(row["MarketingType"].ToString(), typeof(int), -1);
                    if (marketingplan.CustomerID == -1)
                    {
                        ToastMessageBox.Show( Resource.errCustomer, Color.Red);
                        return;
                    }
                    else if (marketingplan.PlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    }        
                    sup = MarketingPlanDA.UpdateByID(marketingplan, conn);
                }

                if (sup > 0)
                {
                    LoadNBindEmployee();
                    LoadNBindData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
                else 
                {
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }

            }
            catch (Exception sqle)
            {
                // show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region EventHandler
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dgvMarketingPlan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dgvMarketingPlan.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvMarketingPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dgvMarketingPlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgvMarketingPlan.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    // ((DataGridViewComboBoxColumn)dgvMarketingPlan.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void dgvMarketingPlan_KeyDown(object sender, KeyEventArgs e)        
        {
           
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //    dgvMarketingPlan.BeginEdit(true);
               // e.SuppressKeyPress = true;
                int iColumn = dgvMarketingPlan.CurrentCell.ColumnIndex;
                int iRow = dgvMarketingPlan.CurrentCell.RowIndex;
                if (iColumn == dgvMarketingPlan.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvMarketingPlan.Rows.Count)
                    {
                        DataRow newRow = marketingplanTbl.NewRow();
                        marketingplanTbl.Rows.Add(newRow);
                        this.dgvMarketingPlan.DataSource = marketingplanTbl;
                        dgvMarketingPlan[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvMarketingPlan.CurrentCell = dgvMarketingPlan[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvMarketingPlan.CurrentCell = dgvMarketingPlan[dgvMarketingPlan.CurrentCell.ColumnIndex + 1, dgvMarketingPlan.CurrentCell.RowIndex];
                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvMarketingPlan.SelectedRows)
                    {
                        dgvMarketingPlan.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    if (dgvMarketingPlan.RowCount == 0)
                    {
                        DataRow newRow = marketingplanTbl.NewRow();
                        marketingplanTbl.Rows.Add(newRow);
                        this.dgvMarketingPlan.DataSource = marketingplanTbl;
                        ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvMarketingPlan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           // dgvMarketingPlan.CurrentCell = dgvMarketingPlan[e.ColumnIndex, e.RowIndex];
            //dgvMarketingPlan.BeginEdit(true);
        }

        private void dgvMarketingPlan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {            
            //DataGridViewComboBoxCell currentcmb;
            //if (e.RowIndex == -1)
            //    return;
            //if (sender is DataGridView && (e.ColumnIndex == 4))
            //{
            //    DataGridView dgv = (DataGridView)sender;
            //    if (dgvMarketingPlan.Equals(dgv))
            //    {
            //        CustomerName cusname = new CustomerName();
            //        SqlConnection conn = null;
            //        DataTable dt = null;

            //        try
            //        {
            //            conn = DBManager.GetInstance().GetDbConnection();
            //            cusname.TownshipID = (int)DataTypeParser.Parse(dgvMarketingPlan.CurrentRow.Cells[2].Value.ToString(), typeof(int), -1);
            //            cusname.CusType = (int)DataTypeParser.Parse(dgvMarketingPlan.CurrentRow.Cells[3].Value.ToString(), typeof(int), -1);
            //            dt = new MarketingPlanBL().GetCusName(cusname, conn);
            //            currentcmb = dgvMarketingPlan.CurrentRow.Cells["dgvColCusName"] as DataGridViewComboBoxCell; //or column name inside brackets!
            //            currentcmb.DataSource = dt;
            //            //dgvColCusName.DisplayMember = "CusName";
            //            //dgvColCusName.ValueMember = "CustomerID";
            //        }
            //        catch (SqlException Sqle)
            //        {
            //        }
            //        finally
            //        {
            //            DBManager.GetInstance().CloseDbConnection();
            //        }

            //    }
            //}
        }

        private void dgvMarketingPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell currentcmb;
            if (e.RowIndex == -1 || e.ColumnIndex ==-1)
                return;
            DataGridView dgv = (DataGridView)sender;
            if (dgvMarketingPlan.Equals(dgv))
            {
                CustomerName cusname = new CustomerName();
                SqlConnection conn = null;
                DataTable dt = null;

                try
                {
                    conn = DBManager.GetInstance().GetDbConnection();
                    cusname.TownshipID = (int)DataTypeParser.Parse(dgvMarketingPlan.CurrentRow.Cells["dgvColTownship"].Value.ToString(), typeof(int), -1);
                    cusname.CusType = (int)DataTypeParser.Parse(dgvMarketingPlan.CurrentRow.Cells["dgvColCusType"].Value.ToString(), typeof(int), -1);

                    dt = new MarketingPlanBL().GetCusName(cusname, conn);
                    currentcmb = dgvMarketingPlan.CurrentRow.Cells["dgvColCusName"] as DataGridViewComboBoxCell; //or column name inside brackets!
                    currentcmb.DataSource = dt;
                    //dgvColCusName.DisplayMember = "CusName";
                    //dgvColCusName.ValueMember = "CustomerID";
                }
                catch (SqlException Sqle)
                {
                }
                finally
                {                   
                    DBManager.GetInstance().CloseDbConnection();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvMarketingPlan.SelectedRows)
                {
                    dgvMarketingPlan.Rows.RemoveAt(item.Index);
                }
                Save();
                DataUtil.AddInitialNewRow(dgvMarketingPlan);
                //if (dgvMarketingPlan.RowCount == 0)
                //{
                //    DataTable MarketingPlanTbl = dgvMarketingPlan.DataSource as DataTable;
                //    DataRow newRow = MarketingPlanTbl.NewRow();
                //    MarketingPlanTbl.Rows.Add(newRow);
                //    dgvMarketingPlan.DataSource = MarketingPlanTbl;
                //}
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        { // Search By Plan Date            
            try
            {                
                DateTime startdate = dtpStartDate.Value;
                DateTime enddate = dtpEndDate.Value;
                int marketingtype = 0;
                DataTable dt = MarketingPlanDA.SearchByID(startdate, enddate, marketingtype);
                dgvMarketingPlan.DataSource = dt;
            }
            catch (SqlException Sqle)
            {
                //To do 
            }          
        }
        #endregion

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));            
        }

        //#region DataGridView ComboBox Events
        private void cmbCusType_DropDown(object sender, EventArgs e)
        {
            int TownshipID = (int)DataTypeParser.Parse(dgvMarketingPlan.CurrentRow.Cells[_indexTownshipColumn].Value, typeof(int), 0);
            if (TownshipID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtCusType, "TownshipID", TownshipID);
            _cmbCusType.DataSource = dtResultProducts;
        }
        //#endregion

        private void dgvMarketingPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Register an event to filter displaying value of Customer Type column
            if (dgvMarketingPlan.CurrentRow != null && dgvMarketingPlan.CurrentCell.ColumnIndex == _indexCusTyepColumn)
            {
                _cmbCusType = e.Control as ComboBox;
                if (_cmbCusType != null)
                {
                    _cmbCusType.DropDown += new EventHandler(cmbCusType_DropDown);
                }
            }
        }

        private void dgvMarketingPlan_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbCusType != null)
            {
                _cmbCusType.DropDown -= new EventHandler(cmbCusType_DropDown);
            }
        }

        private void dgvMarketingPlan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadNBindEmployee();
        }

        private void frmDailyMarketingPlan_Load(object sender, EventArgs e)
        {
            dgvMarketingPlan.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvMarketingPlan.DataSource as DataTable);
        }

    }
}

