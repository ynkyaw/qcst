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
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmSDivisions : Form
    {
        DataTable sdivisionTbl = null;
        SDivisionBL sdivisionBL = new SDivisionBL();
        SDivision sdivision = new SDivision();
        public frmSDivisions()
        {
            InitializeComponent();
            LoadData();
            BindData();
        }

        public void LoadData()  //Load Sate and Division Data for Grid
        {
            try
            {
                sdivisionTbl = sdivisionBL.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void BindData()   // Bind Data in datagridview and combo
        {
            #region Bind DatagridView
            //Set AutoGenerateColumns False
            dgvsetupsdivision.AutoGenerateColumns = false;

            dgvsetupsdivision.DataSource = sdivisionTbl;
            #endregion
        }

        private void Save()
        {
            DataTable dt = dgvsetupsdivision.DataSource as DataTable;
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
                    sdivision.StateDivisionName = String.IsNullOrEmpty(row["StateDivisionName"].ToString()) ? "" : row["StateDivisionName"].ToString();
                    sup = sdivisionBL.Insert(sdivision,conn);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    sdivision.ID = (int)DataTypeParser.Parse(row["SDivisionID"].ToString(), typeof(int), -1);
                    sup = sdivisionBL.Delete(sdivision, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    sdivision.ID = (int)DataTypeParser.Parse(row["SDivisionID"].ToString(), typeof(int), -1);
                    sdivision.StateDivisionName = String.IsNullOrEmpty(row["StateDivisionName"].ToString()) ? "" : row["StateDivisionName"].ToString();
                    sup = sdivisionBL.Update(sdivision, conn);
                }

                if (sup > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
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

        #region Event Handler
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
            BindData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetupsdivision.SelectedRows)
                {
                    dgvsetupsdivision.Rows.RemoveAt(item.Index);
                }
                Save();
            }
        }

        private void dgvsetupsdivision_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetupsdivision.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
        }

        #endregion

        
    }
}
