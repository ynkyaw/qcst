using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Marketing.DA;
using PTIC.Util;
using PTIC.Sale.BL;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmMobileServiceMonthlyPlan : Form
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

        private BindingSource bdcustomer = new BindingSource();

        DataTable mobileserviceplanTbl = null;
        //MobileServicePlan mobileserviceplan = new MobileServicePlan();

        public frmMobileServiceMonthlyPlan()
        {
            InitializeComponent();
            this._indexTownshipColumn = dgvMobileServicePlan.Columns.IndexOf(dgvMobileServicePlan.Columns["dgvColTownship"]);
            this._indexCusTyepColumn = dgvMobileServicePlan.Columns.IndexOf(dgvMobileServicePlan.Columns["dgvColCusType"]);
            LoadNBindGrid(); // Change By AKKs
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvMobileServicePlan);
        }

        #region Private Method
        private void LoadNBindData()
        {
            BindingSource bdtownship = new BindingSource();
            BindingSource bdcustomertype = new BindingSource();
            DataSet ds = new DataSet();
            try
            {
                //Bind Township
                dgvColTownship.DataSource = new TownshipBL().GetAll();
                //Bind CustomerType
                dgvColCusType.DataSource = this._dtCusType = new CusTypeBL().GetAll();

                dgvColTownship.DisplayMember = "Township";
                dgvColTownship.ValueMember = "TownshipID";

                dgvColCusType.DisplayMember = "CusTypeName";
                dgvColCusType.ValueMember = "CusTypeID";
            }
            catch (SqlException sqle)
            {
                // _logger.Error(sqle);
            }
        }

        private void LoadNBindGrid()
        {
            DataSet ds = new DataSet();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                mobileserviceplanTbl = new MobileServicePlanBL().GetAll();

                dgvMobileServicePlan.AutoGenerateColumns = false; // Autogenerate Columns False
                dgvMobileServicePlan.DataSource = mobileserviceplanTbl;

                dgvColCusName.DataSource = mobileserviceplanTbl;
                dgvColCusName.ValueMember = "CustomerID";
                dgvColCusName.DisplayMember = "CusName";
                dgvColCusName.DataPropertyName = "CustomerID";

            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void Save()
        {
            DataTable dt = dgvMobileServicePlan.DataSource as DataTable;
            int MobileServicePlanID = -1;
            int? sup = null;
            if (dt == null)
                return;

            MobileServicePlanBL mobileServicePlanSaver = null;
            try
            {
                mobileServicePlanSaver = new MobileServicePlanBL();

                List<MobileServicePlan> insertMobileServicePlan = new List<MobileServicePlan>();
                List<MobileServicePlan> updateMobileServicePlan = new List<MobileServicePlan>();
                List<MobileServicePlan> deleteMobileServicePlan = new List<MobileServicePlan>();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    MobileServicePlan mobileserviceplan = new MobileServicePlan()
                    {
                        TownshipID = (int)DataTypeParser.Parse(row["ID"].ToString(), typeof(int), -1),
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1),
                        SvcPlanDate = (DateTime)DataTypeParser.Parse(row["SvcPlanDate"].ToString(), typeof(DateTime), null)

                    };

                    insertMobileServicePlan.Add(mobileserviceplan);
                    //if (mobileserviceplan.CustomerID == -1)
                    //{
                    //    ToastMessageBox.Show( Resource.errCustomer,Color.Red);
                    //    return;
                    //}
                    //else if (mobileserviceplan.TownshipID == -1)
                    //{
                    //    ToastMessageBox.Show("Please Choose Township!",Color.Red);
                    //    return;
                    //}
                    //else if (mobileserviceplan.SvcPlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    //{
                    //    ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    //    return;
                    //}
                    //else
                    //{
                    //    insertMobileServicePlan.Add(mobileserviceplan);
                    //}                    
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    MobileServicePlan mobileserviceplan = new MobileServicePlan()
                    {
                        ID = (int)DataTypeParser.Parse(row["MobileServicePlanID"].ToString(), typeof(int), -1)
                    };

                    if (mobileserviceplan.ID != -1)
                    {
                        deleteMobileServicePlan.Add(mobileserviceplan);
                        MobileServicePlanID = mobileserviceplan.ID;
                        sup = MobileServicePlanDA.DeleteByID(mobileserviceplan);
                    }

                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    MobileServicePlan mobileserviceplan = new MobileServicePlan()
                   {
                       ID = (int)DataTypeParser.Parse(row["MobileServicePlanID"].ToString(), typeof(int), -1),
                       TownshipID = (int)DataTypeParser.Parse(row["ID"].ToString(), typeof(int), -1),
                       CustomerID = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1),
                       // mobileserviceplan.SvcPlanNo = (string)DataTypeParser.Parse(row["SvcPlanNo"].ToString(), typeof(string), null);
                       // marketingplan.EmpID = (int)DataTypeParser.Parse(row["EmpID"].ToString(), typeof(int), -1);
                       SvcPlanDate = (DateTime)DataTypeParser.Parse(row["SvcPlanDate"].ToString(), typeof(DateTime), -1)
                   };

                    updateMobileServicePlan.Add(mobileserviceplan);
                    MobileServicePlanID = mobileserviceplan.ID;
                    //if (mobileserviceplan.CustomerID == -1)
                    //{
                    //    ToastMessageBox.Show( Resource.errCustomer, Color.Red);
                    //    return;
                    //}
                    //else if (mobileserviceplan.SvcPlanDate == (DateTime)DataTypeParser.Parse("{01-Jan-01 12:00:00 AM}", typeof(DateTime), null))
                    //{
                    //    ToastMessageBox.Show(Resource.errPlanDate, Color.Red);
                    //    return;
                    //}
                    //else
                    //{
                    //    updateMobileServicePlan.Add(mobileserviceplan);
                    //    MobileServicePlanID = mobileserviceplan.ID;
                    //}

                }


                if (MobileServicePlanID == -1) // Add new order and details
                {
                    if (insertMobileServicePlan.Count >= 0)
                    {
                        sup = mobileServicePlanSaver.Insert(insertMobileServicePlan);

                        if (!mobileServicePlanSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(mobileServicePlanSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "MobileServicePlan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        ToastMessageBox.Show("Blank A & P Detail Data!");
                        return;
                    }
                }
                else // Update an existing
                {
                    // Insert
                    if (insertMobileServicePlan.Count > 0)
                    {
                        sup = mobileServicePlanSaver.Update(insertMobileServicePlan);

                        if (!mobileServicePlanSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(mobileServicePlanSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "MobileServicePlan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update
                    if (updateMobileServicePlan.Count > 0)
                    {
                        sup = mobileServicePlanSaver.Update(updateMobileServicePlan);

                        if (!mobileServicePlanSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(mobileServicePlanSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "MobileServicePlan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                }


                if (sup.HasValue && sup.Value >= 0)
                {
                    LoadNBindGrid();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    btnSave.Enabled = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int affectedrow = -1;
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                int MobileServicePlanID = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells["colMobileServicePlanID"].Value, typeof(int), -1);
                if (MobileServicePlanID != -1)
                {
                    MobileServicePlan mobileserviceplan = new MobileServicePlan()
                    {
                        ID = MobileServicePlanID
                    };
                    affectedrow = MobileServicePlanDA.DeleteByID(mobileserviceplan);
                    if (affectedrow > 0)
                    {
                        foreach (DataGridViewRow item in this.dgvMobileServicePlan.SelectedRows)
                        {
                            dgvMobileServicePlan.Rows.RemoveAt(item.Index);
                        }
                        ClearButton();
                        ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    }
                    else
                    {
                        ClearButton();
                        MessageBox.Show("အသေးစိတ်အချက် အလက်များဖြည့်သွင်းပြီးဖြစ်၍ ဖျက်ခွင့်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                if (dgvMobileServicePlan.RowCount == 0)
                {
                    DataRow newRow = mobileserviceplanTbl.NewRow();
                    mobileserviceplanTbl.Rows.Add(newRow);
                    this.dgvMobileServicePlan.DataSource = mobileserviceplanTbl;
                }

            }
        }

        private void dgvMobileServicePlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewComboBoxCell currentcmb;
            if (e.RowIndex == -1)
                return;
            DataGridView dgv = (DataGridView)sender;
            if (dgvMobileServicePlan.Equals(dgv))
            {
                CustomerName cusname = new CustomerName();
                SqlConnection conn = null;
                DataTable dt = null;

                try
                {
                    conn = DBManager.GetInstance().GetDbConnection();
                    cusname.TownshipID = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells["dgvColTownship"].Value.ToString(), typeof(int), -1);
                    cusname.CusType = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells["dgvColCusType"].Value.ToString(), typeof(int), -1);
                    dt = new MarketingPlanBL().GetCusName(cusname, conn);
                    currentcmb = dgvMobileServicePlan.CurrentRow.Cells["dgvColCusName"] as DataGridViewComboBoxCell; //or column name inside brackets!
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

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerName cusname = new CustomerName();
            SqlConnection conn = null;
            DataTable dt = null;
            // DataGridViewTextBoxCell txtphone;

            if (dgvMobileServicePlan.CurrentRow.Cells["dgvColCusName"].Selected == true)
            {
                ComboBox cmbbox = (ComboBox)sender;
                if (cmbbox.SelectedIndex > -1)
                {
                    try
                    {
                        // int ID = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells["dgvColCusName"].Value, typeof(int), -1);
                        conn = DBManager.GetInstance().GetDbConnection();
                        int Id = (int)DataTypeParser.Parse(cmbbox.SelectedValue, typeof(int), -1);
                        cusname.TownshipID = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells["dgvColTownship"].Value.ToString(), typeof(int), -1);
                        cusname.CusType = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells["dgvColCusType"].Value.ToString(), typeof(int), -1);
                        dt = new MarketingPlanBL().GetCusName(cusname, conn);
                        foreach (DataRow row in dt.Rows)
                        {
                            int cusid = (int)DataTypeParser.Parse(row["CustomerID"].ToString(), typeof(int), -1);
                            if (cusid == Id)
                            {
                                dgvMobileServicePlan["dgvColPhone", dgvMobileServicePlan.CurrentRow.Index].Value = row["Phone1"].ToString();
                                dgvMobileServicePlan["dgvColContactPerson", dgvMobileServicePlan.CurrentRow.Index].Value = row["ConPersonName"].ToString();
                                dgvMobileServicePlan["dgvColPhone", dgvMobileServicePlan.CurrentRow.Index].Value = row["MobilePhone"].ToString();
                            }
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
            }
            else
            {
                // dgvMobileServicePlan[
            }

        }

        private void dgvMobileServicePlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dgvMobileServicePlan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgvMobileServicePlan.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    // ((DataGridViewComboBoxColumn)dgvMarketingPlan.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startdate = dtpStartDate.Value;
                DateTime enddate = dtpEndDate.Value;
                DataTable dt = MobileServicePlanDA.SearchByID(startdate, enddate);
                dgvMobileServicePlan.DataSource = dt;
            }
            catch (Exception se)
            {
                throw;
            }
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //    dgvMarketingPlan.BeginEdit(true);
                // e.SuppressKeyPress = true;
                // if (marketingplan.CustomerID == -1 || marketingplan.EmpID == -1) return true;
                if (dgvMobileServicePlan.CurrentRow.ErrorText != String.Empty) return true;
                int iColumn = dgvMobileServicePlan.CurrentCell.ColumnIndex;
                int iRow = dgvMobileServicePlan.CurrentCell.RowIndex;
                if (iColumn == dgvMobileServicePlan.Columns.Count - 1)
                {
                    if ((int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells[colMobileServicePlanID.Index].Value, typeof(int), -1) == -1)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    if (iRow + 1 >= dgvMobileServicePlan.Rows.Count)
                    {
                        DataUtil.AddNewRow(dgvMobileServicePlan.DataSource as DataTable);
                        dgvMobileServicePlan[dgvColPlanDate.Index, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvMobileServicePlan.CurrentCell = dgvMobileServicePlan[0, iRow + 1];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    dgvMobileServicePlan.CurrentCell = dgvMobileServicePlan[dgvMobileServicePlan.CurrentCell.ColumnIndex + 1, dgvMobileServicePlan.CurrentCell.RowIndex];
                }
                return true;
            }
            else if (keyData == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvMobileServicePlan.SelectedRows)
                    {
                        dgvMobileServicePlan.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    if (dgvMobileServicePlan.RowCount == 0)
                    {
                        DataRow newRow = mobileserviceplanTbl.NewRow();
                        mobileserviceplanTbl.Rows.Add(newRow);
                        this.dgvMobileServicePlan.DataSource = mobileserviceplanTbl;
                    }
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region DataGridView ComboBox Events
        private void dgvMobileServicePlan_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbCusType != null)
            {
                _cmbCusType.DropDown -= new EventHandler(cmbCusType_DropDown);
            }
        }

        private void dgvMobileServicePlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Register an event to filter displaying value of Customer Type column
            if (dgvMobileServicePlan.CurrentRow != null && dgvMobileServicePlan.CurrentCell.ColumnIndex == _indexCusTyepColumn)
            {
                _cmbCusType = e.Control as ComboBox;
                if (_cmbCusType != null)
                {
                    _cmbCusType.DropDown += new EventHandler(cmbCusType_DropDown);
                }
            }
            ComboBox cmbbox = e.Control as ComboBox;
            if (cmbbox != null)
            {
                // first remove event handler to keep from attaching multiple:
                cmbbox.SelectedIndexChanged -= new
                EventHandler(cb_SelectedIndexChanged);

                // now attach the event handler
                cmbbox.SelectedIndexChanged += new
                EventHandler(cb_SelectedIndexChanged);
            }
        }

        private void cmbCusType_DropDown(object sender, EventArgs e)
        {
            int TownshipID = (int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells[_indexTownshipColumn].Value, typeof(int), 0);
            if (TownshipID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtCusType, "TownshipID", TownshipID);
            _cmbCusType.DataSource = dtResultProducts;
        }
        #endregion

        private void dgvMobileServicePlan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    int MobileServicePlanID = (int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[colMobileServicePlanID.Index].Value, typeof(int), -1);

                    if (MobileServicePlanID != -1)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadNBindGrid();
        }

        private void frmMobileServiceMonthlyPlan_Load(object sender, EventArgs e)
        {
            dgvMobileServicePlan.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;
        }

        private void ClearButton()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvMobileServicePlan == null) return;
            if (dgvMobileServicePlan.CurrentRow == null)
            {
                DataUtil.AddInitialNewRow(dgvMobileServicePlan);
            }
            else if ((int)DataTypeParser.Parse(dgvMobileServicePlan.CurrentRow.Cells[colMobileServicePlanID.Index].Value, typeof(int), -1) != -1)
            {
                DataUtil.AddNewRow(dgvMobileServicePlan.DataSource as DataTable);
                dgvMobileServicePlan[dgvColPlanDate.Index, dgvMobileServicePlan.CurrentRow.Index + 1].Selected = true;
            }

        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
