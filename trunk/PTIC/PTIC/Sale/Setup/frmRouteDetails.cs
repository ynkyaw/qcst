using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.VC.Marketing;

namespace PTIC.Sale.Setup
{
    public partial class frmRouteDetails : Form
    {

        #region
        private int _routeId = 0;
        DataTable townInRoute;
        private BindingSource townshipinrouteBindingSource = new BindingSource();
        #endregion

        public frmRouteDetails()
        {
            InitializeComponent();
            LoadTownCombo();
        }

        public frmRouteDetails(int id)
        {
            InitializeComponent();
            _routeId = id;
            LoadTownCombo();
            LoadRouteDetails();

        }

        private void dgvsetuptownshipinrout_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetuptownshipinrout.Rows[e.RowIndex].Cells["colTownshipInRouteNo"].Value = (e.RowIndex + 1).ToString();
            dgvsetuptownshipinrout.Rows[e.RowIndex].Cells[dgvColDelete.Index].Value = "Remove";
        }

        private void dgvsetuptownshipinrout_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == dgv.CurrentRow.Cells[dgvColTownshipID.Index].ColumnIndex)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells[dgvColTownshipID.Index].EditedFormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate value not allowed";
                            MessageBox.Show("Duplicate Not Allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
        }


        #region Init Form
        private void LoadTownCombo() 
        {
            try
            {
                DataTable townshipTbl = new TownshipBL().GetAll();
                dgvColTownshipID.DataSource = townshipTbl;
                dgvColTownshipID.DisplayMember = "Township";
                dgvColTownshipID.ValueMember = "TownshipID";
            }
            catch (SqlException sqle)
            {

            }


            
        }

        private void LoadRouteDetails()
        {
            Route route = new RouteBL().GetDataByRouteId(_routeId);

            txtRemark.Text = route.Remark;
            qcstEntryCtl1.TextBoxText = route.RouteName;

            townInRoute = new TownshipInRouteBL().GetDataByRouteId(_routeId);
            dgvsetuptownshipinrout.Rows.Add(townInRoute.Rows.Count);
            for (int i = 0; i < townInRoute.Rows.Count;i++ )
            {
                dgvsetuptownshipinrout.Rows[i].Cells[0].Value = townInRoute.Rows[i]["ID"];
                dgvsetuptownshipinrout.Rows[i].Cells[2].Value = townInRoute.Rows[i]["TownshipID"];
                dgvsetuptownshipinrout.Rows[i].Cells[3].Value = townInRoute.Rows[i]["RouteID"];

            }
            
        }



        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region Check Validation
            int dbRouteIdWithSameName = new RouteBL().SelectRouteIdByRouteName(qcstEntryCtl1.TextBoxText);
            if (_routeId != dbRouteIdWithSameName && dbRouteIdWithSameName!=0)
            {
                MessageBox.Show("Route Name already Exist!");
                return;
            }

            for(int indexOne=0;indexOne<dgvsetuptownshipinrout.Rows.Count-1;indexOne++)
            {
                object firstTown=dgvsetuptownshipinrout.Rows[indexOne].Cells[dgvColTownshipID.Index].Value;
                for (int indexTwo = indexOne+1; indexTwo < dgvsetuptownshipinrout.Rows.Count - 1; indexTwo++)
                {
                    object secTown = dgvsetuptownshipinrout.Rows[indexTwo].Cells[dgvColTownshipID.Index].Value;
                    if (firstTown != null && firstTown.Equals(secTown)) 
                    {
                        MessageBox.Show("");
                        return;
                    }
                }
            }

            #endregion


            if (_routeId == 0)
            {
                Route route = new Route();
                route.RouteName = qcstEntryCtl1.TextBoxText;
                route.Remark = txtRemark.Text;
                route.LastModified = DateTime.Now;
                route.IsDeleted = false;
                try
                {
                    route.RouteID = new RouteBL().Insert(route, DBManager.GetInstance().GetDbConnection());
                    for(int indexOne=0;indexOne<dgvsetuptownshipinrout.Rows.Count-1;indexOne++)
                    {
                        object firstTown=dgvsetuptownshipinrout.Rows[indexOne].Cells[dgvColTownshipID.Index].Value;
                        if (firstTown != null&& (int)firstTown!=0)
                        {
                            TownshipInRoute townshipinroute = new TownshipInRoute();
                            townshipinroute.RouteID = route.RouteID;
                            townshipinroute.TownshipID = (int)firstTown;
                            new TownshipInRouteBL().Insert(townshipinroute);
                        }
                     }
                }
                catch (Exception err) 
                {
                
                
                }

                

            }
            else 
            {
                Route route = new Route();
                route.RouteName = qcstEntryCtl1.TextBoxText;
                route.Remark = txtRemark.Text;
                route.LastModified = DateTime.Now;
                route.IsDeleted = false;
                route.RouteID = _routeId;

                int updatedCnt = new RouteBL().Update(route, DBManager.GetInstance().GetDbConnection());


                SaveTownshipInRoute(_routeId);
            }
            MessageBox.Show("Success");
            this.Close();


        }

        private bool isExist(string TownId) 
        {
            bool isFound = false;
            foreach (DataGridViewRow dgvRw in dgvsetuptownshipinrout.Rows) 
            {
                if (dgvRw.Cells[0].Value!=null && TownId == dgvRw.Cells[0].Value.ToString())
                {
                    isFound = true;
                    break;
                }
            
            }

            return isFound;
        }



        private void SaveTownshipInRoute(int routeId)     // *** Insert / Update / Delete Township Datagridview by DataRow State ** //
        {
            DataTable oldTonwnInRoute = townInRoute;

            //Deleted Town
            foreach (DataRow dr in oldTonwnInRoute.Rows) 
            {
                if (!isExist(dr["ID"].ToString()))
                {
                    //Delete
                    TownshipInRoute tspInRoute = new TownshipInRoute();
                    tspInRoute.TownshipInRouteID = (int)dr["ID"];
                    new TownshipInRouteBL().Delete(tspInRoute);


                }
            
            }

            foreach (DataGridViewRow dgvRw in dgvsetuptownshipinrout.Rows) 
            {
                if (dgvRw.Index != dgvsetuptownshipinrout.Rows.Count-1)
                {
                    TownshipInRoute tspInRoute = new TownshipInRoute();
                    tspInRoute.TownshipInRouteID = (dgvRw.Cells[colTrownshipInRoute.Index].Value == null ? 0 : (int)dgvRw.Cells[colTrownshipInRoute.Index].Value);
                    tspInRoute.TownshipID = (int)dgvRw.Cells[dgvColTownshipID.Index].Value;
                    tspInRoute.RouteID = _routeId;
                    tspInRoute.LastModified = DateTime.Now;
                    tspInRoute.IsDeleted = false;
                    if (tspInRoute.TownshipInRouteID==0)
                    {
                        //Insert
                        new TownshipInRouteBL().Insert(tspInRoute);

                    }
                    else
                    {

                        //Update
                        new TownshipInRouteBL().Update(tspInRoute);
                    }

                }
            }




        }




        private void dgvsetuptownshipinrout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvColDelete.Index) 
            {
                int currentrow = e.RowIndex;
                if(currentrow!=dgvsetuptownshipinrout.Rows.Count-1)
                    dgvsetuptownshipinrout.Rows.RemoveAt(currentrow);
            
            }
        }

        private void dgvsetuptownshipinrout_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == dgvColTownshipID.Index)
            {
                dgvsetuptownshipinrout.Rows.RemoveAt(dgv.CurrentRow.Index);
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        

       
    }
}
