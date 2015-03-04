using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.Common.BL;
using PTIC.Sale.Entities;
using PTIC.VC.Util;

namespace PTIC.Sale.Delivery
{
    public partial class frmDeliveryNoteList : Form
    {
         //<summary>
         //Record table for different Proudcts
         //</summary>
        private DataTable _dtProduct = null;

        bool VenFilter = false;

        public frmDeliveryNoteList()
        {
            InitializeComponent();
            LoadNBind();
        }

        private void LoadNBind()
        {
            try
            {
                //// Load Brand
                //clnBrandName.DataSource = new BrandBL().GetOwnBrands();
                //// Load Product
                //clnProductName.DataSource = this._dtProduct = new ProductBL().GetAll();
                //// Set binding fields
                //clnBrandName.DisplayMember = "BrandName";
                //clnBrandName.ValueMember = "BrandID";

                //clnProductName.DisplayMember = "ProductName";
                //clnProductName.ValueMember = "ProductID";

                // Load employees
                //cmbSalePerson.DataSource = new EmployeeBL().GetAll(conn);
                cmbSalePerson.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID",
                    (int)PTIC.Common.Enum.PredefinedDepartment.Sales);

                cmbEmpDisplay.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID",
                    (int)PTIC.Common.Enum.PredefinedDepartment.Sales);

                // Load vehicles
                DataTable dtVehicle = new VehicleBL().GetAll();
               
            }
            catch (Exception e)
            {
                // TODO: handle exception
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DeliveryNote deliverynote = new DeliveryNote()
            {
                Date = (DateTime)DataTypeParser.Parse(dtpDeliveryNoteDate.Value, typeof(DateTime), DateTime.Now),
                EmpID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1),
                VenID = (int?)DataTypeParser.Parse(DBNull.Value, typeof(int), null)
            };

            cmbEmpDisplay.SelectedValue = deliverynote.EmpID;
            dtpDeliveryDisplay.Value = deliverynote.Date;
            LoadNGridData(deliverynote);
        }

        private void CalculateTotal()
        {
            int totalAmt = 0;
            DataTable dt = dgvDeliveryNote.DataSource as DataTable;
            if (dt.Rows.Count < 1) return;
            foreach (DataRow row in dt.Rows)
            {
                if (dt.Columns.Contains("TotalQty"))
                    try
                    {
                        totalAmt += (int)DataTypeParser.Parse(row["TotalQty"].ToString(), typeof(int), 0);
                    }
                    catch (Exception)
                    {
                    }
            }
            txtTotalAmt.Text = totalAmt.ToString("N0");
        }

        private void LoadNGridData(DeliveryNote deliverynote)
        {            
            try
            {
               txtTotalAmt.Text = "";
                
                if (VenFilter == false)
                {
                    DataTable dtVanInDeliveryNote = new DeliveryNoteBL().GetFromOriginByDate(deliverynote);
                    if (dtVanInDeliveryNote.Rows.Count > 0)
                    {
                        cmbVenNo.DataSource = dtVanInDeliveryNote.DefaultView.ToTable(true, "VenID", "VenNo");
                    }
                    else
                    {
                        cmbVenNo.DataSource = null;
                    }
                    cmbVenNo.ValueMember = "VenID";
                    cmbVenNo.DisplayMember = "VenNo";
                }

                deliverynote.VenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1);
                DataTable dtDeliveryNote = new DeliveryNoteBL().GetFromOriginByDate(deliverynote);

                if (dtDeliveryNote.Rows.Count > 0)
                {
                    int DeliveryNoteID = (int)DataTypeParser.Parse(dtDeliveryNote.Rows[0]["DeliveryNoteID"], typeof(int), -1);
                    DataTable dtDeliveryNoteDetail = new DeliveryNoteBL().GetDeliveryNoteDetail(DeliveryNoteID);
                    dgvDeliveryNote.AutoGenerateColumns = false;
                    dgvDeliveryNote.DataSource = dtDeliveryNoteDetail;
                    CalculateTotal();
                }
                else
                {
                    int DeliveryNoteID = 0;
                    DataTable dtDeliveryNoteDetail = new DeliveryNoteBL().GetDeliveryNoteDetail(DeliveryNoteID);
                    dgvDeliveryNote.AutoGenerateColumns = false;
                    dgvDeliveryNote.DataSource = dtDeliveryNoteDetail;
                    CalculateTotal();
                }
                
                VenFilter = false;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                
            }
        }

        private void cmbVenNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeliveryNote deliverynote = new DeliveryNote()
            {
                EmpID = (int)DataTypeParser.Parse(cmbEmpDisplay.SelectedValue, typeof(int), -1),
                VenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1),
                Date = (DateTime)DataTypeParser.Parse(dtpDeliveryDisplay.Value, typeof(DateTime), DateTime.Now)
            };
            VenFilter = true;
            LoadNGridData(deliverynote);
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                // pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
                pnlFilter.Visible = false;
                //  pnlGrid.Visible = true;
            }
            else
            {
                // pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
                pnlFilter.Visible = true;
                // pnlGrid.Visible = false;
            }
        }
    }
}
