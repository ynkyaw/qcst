using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using log4net;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.Common;


namespace PTIC.Marketing.DailyMarketing
{
    public partial class frmTripRequestList : Form
    {
        /// <summary>
        /// Logger for frmTripPlanList
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTripRequestList));

        public bool is_sale { get; set; } 

        public frmTripRequestList()
        {
            InitializeComponent();
            dgvTripRequestList.AutoGenerateColumns = false;
            SetDefaultValue();
            LoadNBindOrders();
            
        }

        private void LoadNBindOrders()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                DateTime fromDate = dtFromDate.Value;
                DateTime toDate = dtToDate.Value;
                //DataTable dtTripPlanList = new A_P_PlanBL().SelectBy(fromDate,toDate, conn);
                //dgvTripPlanList.DataSource = new TripPlanBL().GetAll(conn);
                dgvTripRequestList.DataSource = new TripRequestBL().SelectBy(fromDate, toDate, GlobalCache.is_sale, conn);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }


        private void SetDefaultValue()
        {
            dtFromDate.Value = DateTime.Now;
            dtToDate.Value = DateTime.Now.AddMonths(3);
        }

        private void butAddNew_Click(object sender, EventArgs e)
        {
            //frmTripPlan frm = new frmTripPlan();
            //UIManager.OpenForm(frm);

            frmTripRequest frm = new frmTripRequest();
            //frm.MdiParent = Program.toyo;
            frm.Show();
        }

        private void dgvTripPlanList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTripPlanList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTripRequestList.Rows[e.RowIndex].Cells["ClnNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvTripRequestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvTripRequestList.CurrentRow.IsNewRow || dgvTripRequestList.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
                return;
            }
            // Get an order
            DataGridViewRow selectedRow = dgvTripRequestList.CurrentRow;
            TripRequest mTripRequest = new TripRequest()
            {

                ID = (int)DataTypeParser.Parse(selectedRow.Cells["clnTripRequestID"].Value, typeof(int), -1),
                TripPlanDetailID = (int) DataTypeParser.Parse(selectedRow.Cells["clnTripPlanID"].Value, typeof(int),0),
                //ripPlanName = selectedRow.Cells["clnTripPlanName"].Value.ToString(),                
                FromDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["clnFromDate"].Value, typeof(DateTime), DateTime.Now),
                ToDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["clnToDate"].Value, typeof(DateTime), DateTime.Now)             
            };                        
            frmTripRequest newFrmTripPlan = new frmTripRequest(mTripRequest);
            // TODO: call back handler
            UIManager.OpenForm(newFrmTripPlan);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (dgvTripRequestList.CurrentRow.IsNewRow || dgvTripRequestList.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            DataGridViewRow selectedRow = dgvTripRequestList.CurrentRow;
            int tripRequestID = (int)DataTypeParser.Parse(selectedRow.Cells["clnTripRequestID"].Value, typeof(int), -1);
            if (tripRequestID == -1)
            {
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DeleteTripRequest(tripRequestID);
            }
        }

        private void DeleteTripRequest(int tripRequestID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete an order detail
                int affectedRows = new TripRequestBL().DeleteByTripRequestID(tripRequestID, conn);
                if (affectedRows > 0)
                {
                    dgvTripRequestList.Rows.RemoveAt(dgvTripRequestList.CurrentRow.Index);
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void dgvTripRequestList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }
    }
}
