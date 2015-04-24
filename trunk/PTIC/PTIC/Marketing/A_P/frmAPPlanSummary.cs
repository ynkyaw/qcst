/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/31 (yyyy/MM/dd)
 * Description: 
 */
using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.Common.BL;
using PTIC.Common;
using PTIC.VC.Util;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmAPPlanSummary : Form
    {
        string savefilename = string.Empty;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmAPPlanSummary));

        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetMonthHeaderText();
            SearchNBind(dtpStartMonth.Value, dtpStartMonth.Value.AddMonths(5));
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

        private void dtpStartMonth_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Private Methods
        private void SetMonthHeaderText()
        {
            colMonth_1.HeaderText = dtpStartMonth.Value.ToString("MMM");
            colMonth_2.HeaderText = dtpStartMonth.Value.AddMonths(1).ToString("MMM");
            colMonth_3.HeaderText = dtpStartMonth.Value.AddMonths(2).ToString("MMM");
            colMonth_4.HeaderText = dtpStartMonth.Value.AddMonths(3).ToString("MMM");
            colMonth_5.HeaderText = dtpStartMonth.Value.AddMonths(4).ToString("MMM");
            colMonth_6.HeaderText = dtpStartMonth.Value.AddMonths(5).ToString("MMM");
        }

        private void SearchNBind(DateTime startDate, DateTime endDate)
        {
            dgvAPPlanSummary.DataSource = null;
            DataTable dtSummary = new ReportBL().GetAP_PlanSummaryBy(startDate, endDate);
            if (dtSummary == null || dtSummary.Rows.Count < 1)
            {
                MessageBox.Show("There is no record to display!", "No record",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvAPPlanSummary.DataSource = dtSummary;

            
        }

        /// <summary>
        /// Create summary table structure and set DataPropertyName of GridViewColumns
        /// </summary>
        /// <param name="start">Start point</param>
        /// <returns>Summary DataTable structure</returns>
        private DataTable CreateSummaryTableStructure(int start)
        {
            DataTable dtSummary = new DataTable();
            string fnPlanAmt = "PlanAmt";
            string fnPrevMonthBalAmt = "PrevMonthBalAmt";
            string fnAvailableAmt = "AvailableAmt";
            string fnUsedAmt = "UsedAmt";
            string fnThisMonthBalAmt = "ThisMonthBalAmt";

            dtSummary.Columns.Add(new DataColumn("A_P_MaterialID", typeof(int)));
            for (int i = start; i <= start + 5; i++)
            {
                dtSummary.Columns.AddRange(new DataColumn[] 
                { 
                    //new DataColumn("A_P_PlanDate" + i, typeof(DateTime)),
                    new DataColumn(fnPlanAmt + i, typeof(decimal)),
                    new DataColumn(fnPrevMonthBalAmt + i, typeof(decimal)),
                    new DataColumn(fnAvailableAmt + i, typeof(decimal)),
                    new DataColumn(fnUsedAmt + i, typeof(decimal)),
                    new DataColumn(fnThisMonthBalAmt + i, typeof(decimal))
                });
            }

            colPlanAmt_1.DataPropertyName = fnPlanAmt + start;
            colPrevMonthBalAmt_1.DataPropertyName = fnPrevMonthBalAmt + start;
            colAvailableAmt_1.DataPropertyName = fnAvailableAmt + start;
            colUsedAmt_1.DataPropertyName = fnUsedAmt + start;
            colThisMonthBalAmt_1.DataPropertyName = fnThisMonthBalAmt + start;

            colPlanAmt_2.DataPropertyName = fnPlanAmt + (start + 1);
            colPrevMonthBalAmt_2.DataPropertyName = fnPrevMonthBalAmt + (start + 1);
            colAvailableAmt_2.DataPropertyName = fnAvailableAmt + (start + 1);
            colUsedAmt_2.DataPropertyName = fnUsedAmt + (start + 1);
            colThisMonthBalAmt_2.DataPropertyName = fnThisMonthBalAmt + (start + 1);

            colPlanAmt_3.DataPropertyName = fnPlanAmt + (start + 2);
            colPrevMonthBalAmt_3.DataPropertyName = fnPrevMonthBalAmt + (start + 2);
            colAvailableAmt_3.DataPropertyName = fnAvailableAmt + (start + 2);
            colUsedAmt_3.DataPropertyName = fnUsedAmt + (start + 2);
            colThisMonthBalAmt_3.DataPropertyName = fnThisMonthBalAmt + (start + 2);

            colPlanAmt_4.DataPropertyName = fnPlanAmt + (start + 3);
            colPrevMonthBalAmt_4.DataPropertyName = fnPrevMonthBalAmt + (start + 3);
            colAvailableAmt_4.DataPropertyName = fnAvailableAmt + (start + 3);
            colUsedAmt_4.DataPropertyName = fnUsedAmt + (start + 3);
            colThisMonthBalAmt_4.DataPropertyName = fnThisMonthBalAmt + (start + 3);

            colPlanAmt_5.DataPropertyName = fnPlanAmt + (start + 4);
            colPrevMonthBalAmt_5.DataPropertyName = fnPrevMonthBalAmt + (start + 4);
            colAvailableAmt_5.DataPropertyName = fnAvailableAmt + (start + 4);
            colUsedAmt_5.DataPropertyName = fnUsedAmt + (start + 4);
            colThisMonthBalAmt_5.DataPropertyName = fnThisMonthBalAmt + (start + 4);

            colPlanAmt_6.DataPropertyName = fnPlanAmt + (start + 5);
            colPrevMonthBalAmt_6.DataPropertyName = fnPrevMonthBalAmt + (start + 5);
            colAvailableAmt_6.DataPropertyName = fnAvailableAmt + (start + 5);
            colUsedAmt_6.DataPropertyName = fnUsedAmt + (start + 5);
            colThisMonthBalAmt_6.DataPropertyName = fnThisMonthBalAmt + (start + 5);

            return dtSummary;
        }
        #endregion

        #region Constructor
        public frmAPPlanSummary()
        {
            InitializeComponent();
            dgvAPPlanSummary.AutoGenerateColumns = false;

            dtpStartMonth.Value = new DateTime(dtpStartMonth.Value.Year, dtpStartMonth.Value.Month, 1);
            
            colAPName.ValueMember = "ID";
            colAPName.DisplayMember = "APMaterialName";
            // Create summary table structure
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind A P Materail
            colAPName.DataSource = new APMaterialBUS().GetAll();            
        }
        #endregion

        private void lblSetup_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
        }

        private void dgvAPPlanSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // First row always displays

            if (e.RowIndex == 0)
                return;

            if (IsRepeatedCellValue(1, e.ColumnIndex))
            {
                e.Value = string.Empty;

                e.FormattingApplied = true;
            }

        }

        private bool IsRepeatedCellValue(int rowIndex, int colIndex)
        {
            DataGridViewCell currCell = dgvAPPlanSummary.Rows[rowIndex].Cells[colIndex];
            if (rowIndex == 0)
            {
                rowIndex = 1;
            }
            DataGridViewCell prevCell = dgvAPPlanSummary.Rows[rowIndex - 1].Cells[colIndex];

            //if ((currCell.Value == prevCell.Value) || (currCell.Value != null && prevCell.Value != null && currCell.Value.ToString() == prevCell.Value.ToString()))
            if ((currCell.Value == prevCell.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dgvAPPlanSummary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            // Ignore column and row headers and first row

            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            if (IsRepeatedCellValue(1, e.ColumnIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else if (IsRepeatedCellValue(3, e.ColumnIndex))
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
            else
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Filter = "Excel|*.xlsx;";
            saveFileDialog1.Filter = "Excel 2007 |*.xlsx;";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savefilename = saveFileDialog1.FileName.ToString();
            }
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application

            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook

            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program

            app.Visible = false;

            // get the reference of first sheet. By default its name is Sheet1.

            // store its reference to worksheet

            worksheet = workbook.Sheets["Sheet1"];

            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet

            worksheet.Name = "Exported from gridview";
            // storing header part in Excel

            for (int i = 1; i < dgvAPPlanSummary.Columns.Count + 1; i++)
            {

                worksheet.Cells[1, i] = dgvAPPlanSummary.Columns[i - 1].HeaderText;

            }
            // storing Each row and column value to excel sheet
            for (int i = 0; i < dgvAPPlanSummary.Rows.Count - 1; i++)
            {

                for (int j = 0; j < dgvAPPlanSummary.Columns.Count; j++)
                {
                    string str = (string)DataTypeParser.Parse(dgvAPPlanSummary.Rows[i].Cells[j].Value, typeof(string), String.Empty);
                    worksheet.Cells[i + 2, j + 1] = str;
                }

            }
            worksheet.Application.StandardFont = "Myanmar3";
            worksheet.Application.StandardFontSize = 12;
            worksheet.Rows.WrapText = true;            
            // save the application
            workbook.SaveAs(savefilename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application
            app.Quit();
            MessageBox.Show("Exported to\n" + savefilename, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);        
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            //Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            //Encoding utf8 = Encoding.UTF8;
            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(stOutput);
           // byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
     
            //      byte[] utf8Bytes = Encoding.UTF8.GetBytes(stOutput);
         //   byte[] isoBytes = Encoding.Convert(Encoding.ASCII, Encoding.UTF8, utf8Bytes);

            //byte[] output = ;
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(utfBytes, 0, utfBytes.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }  

    }
}
