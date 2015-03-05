using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.VC.Marketing;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.Util;


namespace PTIC.Sale.Setup
{
    public partial class frmTrip : Form
    {
        private BindingSource tripBindingSource = new BindingSource();
        private BindingSource townintripBindingSource = new BindingSource();
        DataTable townTbl = null;
        Trip trip = new Trip();
        TownInTrip townintrip = new TownInTrip();
        bool IsMarketing = false;
        bool IsRowEdit = false;

        public frmTrip()
        {
            InitializeComponent();
            LoadData();
            BindData();
        }

        public frmTrip(bool IsTrue)
            : this()
        {
            IsMarketing = IsTrue;
        }

        #region Private Methiod
        private void GetData()
        {
            DataSet ds = new DataSet();
            
            try
            {
                DataTable trip = new TripBL().GetAll().Copy(); // make copy to be added into a single dataset
                DataTable townintrip = new TownInTripBL().GetAll().Copy(); // make copy to be added into a single dataset

                // add two data table into single dataset
                ds.Tables.Add(trip);
                ds.Tables.Add(townintrip);

                // create data relations between two tables
                DataRelation relation = new DataRelation("TownInTrip",
                    trip.Columns["TripID"], townintrip.Columns["TripID"],false);
                ds.Relations.Add(relation);

                /** relation between Trip and TownInTrip **/
                tripBindingSource.DataSource = ds;
                tripBindingSource.DataMember = trip.TableName;

                townintripBindingSource.DataSource = tripBindingSource;
                townintripBindingSource.DataMember = "TownInTrip";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()  //Load Town Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                townTbl = new TownBL().GetAll();
            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void BindData()  // Bind Data into TownInTrip Combo
        {
            TownID.DataSource = townTbl;
            TownID.DisplayMember = "Town";
            TownID.ValueMember = "TownID";
        }

        private void SaveTrip()
        {
            DataSet ds = tripBindingSource.DataSource as DataSet;
            DataTable dt = new DataTable();
            dt = ds.Tables["TripTable"];
            int sup = 0;
            if (dt == null)
                return;

            try
            {                
                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    trip.TripName = String.IsNullOrEmpty(row["TripName"].ToString()) ? "" : row["TripName"].ToString();
                    trip.TripPeriod = (int)DataTypeParser.Parse(row["TripPeriod"].ToString(), typeof(int), 0);
                    trip.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    sup = new TripBL().Insert(trip);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    trip.TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1);
                    sup = new TripBL().Delete(trip);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    trip.TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1);
                    trip.TripName = String.IsNullOrEmpty(row["TripName"].ToString()) ? "" : row["TripName"].ToString();
                    trip.TripPeriod = (int)DataTypeParser.Parse(row["TripPeriod"].ToString(), typeof(int), 0);
                    trip.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    sup = new TripBL().Update(trip);
                }

                if (sup > 0)
                {
                    GetData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveTownInTrip()
        {
            DataSet ds = tripBindingSource.DataSource as DataSet;
            DataTable dt = dt = ds.Tables["TownInTripTable"];
                        
            if (dt == null)
                return;
            int sup = 0;
            TownInTripBL townInTripSaver = null;
            List<TownInTrip> townInTripList = null;
            try
            {
                townInTripSaver = new TownInTripBL();
                townInTripList = new List<TownInTrip>();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    TownInTrip townInTrip = new TownInTrip()
                    {
                        TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1),
                        TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1)
                    };

                    if (townInTrip.TripID == -1)
                    {
                        ToastMessageBox.Show(Resource.errNeedToSaveTrip, Color.Red);
                        return;
                    }
                    //sup = townInTripSaver.Insert(townintrip);
                    // Add it into list
                    townInTripList.Add(townInTrip);
                }
                // Insert 
                sup += townInTripSaver.Insert(townInTripList);
                // Check field validation failed or not
                if (!townInTripSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(townInTripSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                
                // Clear list
                townInTripList.Clear();
                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    TownInTrip townInTrip = new TownInTrip() 
                    {
                        TownInTripID = (int)DataTypeParser.Parse(row["TownInTripID"].ToString(), typeof(int), -1)
                    };
                    sup += townInTripSaver.Delete(townInTrip);
                }

                // Clear list
                townInTripList.Clear();
                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    TownInTrip townInTrip = new TownInTrip()
                    {
                        TownInTripID = (int)DataTypeParser.Parse(row["TownInTripID"].ToString(), typeof(int), -1),
                        TripID = (int)DataTypeParser.Parse(row["TripID"].ToString(), typeof(int), -1),
                        TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1)
                    };
                    if (townInTrip.TripID == -1)
                    {
                        ToastMessageBox.Show(Resource.errNeedToSaveTrip, Color.Red); return;
                    }

                    //sup = townInTripSaver.Update(townintrip);
                    // Add it into list
                    townInTripList.Add(townInTrip);
                }
                // Update
                sup += townInTripSaver.Update(townInTripList);

                // Check validation
                if (!townInTripSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(townInTripSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (sup > 0)
                {
                    GetData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handler
        private void dgvsetuptrip_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetuptrip.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvsetuptripintown_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetuptownintrip.Rows[e.RowIndex].Cells[2].Value = (e.RowIndex + 1).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTrip();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetuptrip.SelectedRows.Count <1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete,Color.Red);
                return;
            }
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetuptrip.SelectedRows)
                {
                    if (!item.IsNewRow)
                    dgvsetuptrip.Rows.RemoveAt(item.Index);
                }
                SaveTrip();
                LoadData();
                BindData();
                GetData();
                //ToastMessageBox.Show(Resource.msgSuccessfullySaved);
            }
        }

        private void btnTownInTripSave_Click(object sender, EventArgs e)
        {
            SaveTownInTrip();
        }

        private void btnTownInTripDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetuptrip == null || dgvsetuptrip.CurrentRow == null) return;
            if (dgvsetuptownintrip.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete,Color.Red);
                return;
            }
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetuptownintrip.SelectedRows)
                {
                    if(!item.IsNewRow)
                        dgvsetuptownintrip.Rows.RemoveAt(item.Index);
                }
                SaveTownInTrip();
                //ToastMessageBox.Show(Resource.msgSuccessfullySaved);
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            if (IsMarketing == true)
            {
                UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
                this.Close();
            }
            else
            {
                UIManager.MdiChildOpenForm(typeof(frmSetupPage));
                this.Close();
            }
        }
        #endregion

        private void frmTrip_Load(object sender, EventArgs e)
        {
            dgvsetuptrip.AutoGenerateColumns = false;
            dgvsetuptownintrip.AutoGenerateColumns = false;
            dgvsetuptrip.DataSource = tripBindingSource;
            dgvsetuptownintrip.DataSource = townintripBindingSource;
            GetData();
        }

        private void dgvsetuptrip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //if (dgv == null)
            //    return;
            //if (dgv.CurrentRow.Selected)
            //{

            //    if (tripTbl.Rows.Count > 0 && tripTbl.Rows.Count != e.RowIndex)
            //    {
            //        int tripID = (int)DataTypeParser.Parse(tripTbl.Rows[e.RowIndex]["TripID"], typeof(int), -1);
            //        DataRow[] rows = townintripCopy.Select("TripID = " + tripID + " AND IsDeleted =" + false);
            //        townintripTbl.Rows.Clear();

            //        foreach (DataRow row in rows)
            //        {
            //            DataRow newRow = townintripTbl.NewRow();
            //            newRow["TownInTripID"] = row["TownInTripID",DataRowVersion.Original];
            //            newRow["TripID"] = row["TripID",DataRowVersion.Original];
            //            newRow["TownID"] = row["TownID",DataRowVersion.Original];
            //            newRow["DateAdded"] = row["DateAdded",DataRowVersion.Original];
            //            newRow["LastModified"] = row["LastModified",DataRowVersion.Original];
            //            newRow["IsDeleted"] = row["IsDeleted",DataRowVersion.Original];
            //            townintripTbl.Rows.Add(newRow);
            //        }
            //        dgvsetuptownintrip.AutoGenerateColumns = false;
            //        dgvsetuptownintrip.DataSource = townintripTbl;
            //        dgvsetuptownintrip.Visible = true;
            //    }
            //}

        }

        private void dgvsetuptrip_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetuptrip.Columns["TripName"].Index)
            {
                if (dgvsetuptrip.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    dgvsetuptrip.Rows[e.RowIndex].ErrorText = "TripName must be fill";
                }
                else
                {
                    dgvsetuptrip.CurrentCell.ErrorText = string.Empty;
                }
            }
            if (e.ColumnIndex == dgvsetuptrip.Columns["TripPeriod"].Index)
            {
                int newInteger;
                if (dgvsetuptrip.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    dgvsetuptrip.Rows[e.RowIndex].ErrorText = "TripPeriod must be fill";
                }else
                    if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                    {
                        e.Cancel = true;
                        dgvsetuptrip.Rows[e.RowIndex].ErrorText = "TripPeriod must be integer";
                    }
                    else
                    {
                        dgvsetuptrip.CurrentCell.ErrorText = string.Empty;
                    }
            }
        }

        private void dgvsetuptrip_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //TODO handle
            e.Cancel = true;
            dgvsetuptrip.Rows[e.RowIndex].ErrorText = "TripPeriod must be integer";
        }

        private void dgvsetuptownintrip_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvsetuptownintrip_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }  
        }

        private void dgvsetuptrip_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                int? TripID = (int?)DataTypeParser.Parse(row.Cells["TripID"].Value, typeof(int), null);

                if (TripID != null)
                {
                    dgv.Rows[row.Index].ReadOnly = true;
                }
            }
            
        }

        private void dgvsetuptownintrip_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                int? TownInTripID = (int?)DataTypeParser.Parse(row.Cells["TownInTripID"].Value, typeof(int), null);

                if (TownInTripID != null)
                {
                    dgv.Rows[row.Index].ReadOnly = true;
                }
            }
        }

        private void dgvsetuptrip_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = dgvsetuptrip as DataGridView;

            if (IsRowEdit == false)
            {
                dgv.CurrentRow.ReadOnly = false;
                IsRowEdit = true;
            }
            else
            {
                MessageBox.Show("သိမ်းမည် ကိုနှိပ်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        

        private void dgvsetuptownintrip_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == dgv.CurrentRow.Cells[TownInTripID.Index].ColumnIndex)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells[TownInTripID.Index].EditedFormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate value not allowed";
                            MessageBox.Show("Duplicate Not Allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }

    }
}
