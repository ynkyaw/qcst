using System;
using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
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

namespace PTIC.Sale.Report
{
    public partial class frmMonthlySalesReport : Form
    {

        int currentPage = 0;
        int pageSized = 10;
        int pageCount = 0;
        DataTable productList;
        string savefilename = string.Empty;

        public frmMonthlySalesReport()
        {
            InitializeComponent();
            productList = new PTIC.Sale.BL.ProductBL().GetAll();
        }

        private void frmMonthlySalesReport_Load(object sender, EventArgs e)
        {

            

        }

        void LoadData(DataTable productList) 
        {
            
            string templateStr1 = ",SUM(ISNULL([{0}],0)) as [{0}]";
            string templateStr2 = "[{0}],";
            string templateStr3 = "[{0}]+";
            string templateString = "";

            for (int i = 0; i < pageSized; i++)
            {
                int index = i + (pageSized * currentPage);
                if (index < productList.Rows.Count)
                {
                    DataRow dr = productList.Rows[index];
                    templateString += string.Format(templateStr2, dr["ProductName"]);
                }
            }
            templateString = templateString.Substring(0, templateString.Length - 1);

            string selectQuery = "SELECT row_number() OVER (ORDER BY CusName) AS [No.],CusName," + templateString + ",(";
            for (int i = 0; i < pageSized; i++)
            {
                int index = i + (pageSized * currentPage);
                if (index < productList.Rows.Count)
                {
                    DataRow dr = productList.Rows[index];
                    selectQuery += string.Format(templateStr3, dr["ProductName"]);
                }
            }
            selectQuery = selectQuery.Substring(0, selectQuery.Length - 1);
            selectQuery += ") as [Total Nos],[Cash],[Credit] FROM (SELECT CusName,SUM(SALESAMT) as salesAmt,SalesType";

            for (int i = 0; i < pageSized;i++ )
            {
                int index=i + (pageSized * currentPage);
                if ( index < productList.Rows.Count)
                {
                    DataRow dr = productList.Rows[index];
                    selectQuery += string.Format(templateStr1, dr["ProductName"]);
                }
            }

            selectQuery += @" FROM (
                             SELECT C.CusName,P.ProductName,QTY,(SD.SalePrice*SD.Qty) SALESAMT,
                             CASE WHEN I.SaleType IS NULL THEN 'Cash'
	                         ELSE 'Credit' end as SalesType
                             FROM Invoice I INNER JOIN SalesDetail SD
                             ON I.ID=SD.InvoiceID
                             INNER JOIN Customer C
                             ON I.CusID=C.ID
                             INNER JOIN Product P
                             ON P.ID=SD.ProductID
                             WHERE C.CusType=3
                            ) AS COMPANY_INVOICE
                            PIVOT(SUM(qty) for ProductName IN(";

            
            selectQuery += templateString;
            selectQuery += @")) As C_P
                            group by CusName,SalesType) as t
                            PIVOT(SUM(SALESAMT) FOR SALESTYPE IN([Cash],[Credit]) )As Test";
            dgvCompanySales.DataSource=new PTIC.Common.DA.BaseDAO().SelectByQuery(selectQuery);
            //Set Width
            foreach (DataGridViewColumn col in dgvCompanySales.Columns) 
            {
                col.Width = 50;
            }
            dgvCompanySales.Columns[1].Width = 150;
            dgvCompanySales.Columns[dgvCompanySales.Columns.Count-1].Width = 150;
            dgvCompanySales.Columns[dgvCompanySales.Columns.Count - 2].Width = 150;
            dgvCompanySales.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            pageCount = productList.Rows.Count/pageSized;
            if (productList.Rows.Count % pageSized == 0)
                pageCount--;
            textBox1.Text = string.Format("{0}/{1}", currentPage + 1, pageCount + 1);
            LoadData(productList);
            btnFirst.Enabled = (currentPage>0);
            btnPrevious.Enabled = (currentPage > 0);
            btnNext.Enabled = (currentPage < pageCount);
            btnLast.Enabled = (currentPage < pageCount);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            textBox1.Text = string.Format("{0}/{1}", currentPage + 1, pageCount + 1);
            LoadData(productList);
            btnFirst.Enabled = (currentPage > 0);
            btnPrevious.Enabled = (currentPage > 0);
            btnNext.Enabled = (currentPage < pageCount);
            btnLast.Enabled = (currentPage < pageCount);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentPage++;
            textBox1.Text = string.Format("{0}/{1}", currentPage + 1, pageCount + 1);
            LoadData(productList);
            btnFirst.Enabled = (currentPage > 0);
            btnPrevious.Enabled = (currentPage > 0);
            btnNext.Enabled = (currentPage < pageCount);
            btnLast.Enabled = (currentPage < pageCount);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentPage = pageCount;
            textBox1.Text = string.Format("{0}/{1}", currentPage + 1, pageCount + 1);
            LoadData(productList);
            btnFirst.Enabled = (currentPage > 0);
            btnPrevious.Enabled = (currentPage > 0);
            btnNext.Enabled = (currentPage < pageCount);
            btnLast.Enabled = (currentPage < pageCount);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            textBox1.Text = string.Format("{0}/{1}", currentPage + 1, pageCount + 1);
            LoadData(productList);
            btnFirst.Enabled = (currentPage > 0);
            btnPrevious.Enabled = (currentPage > 0);
            btnNext.Enabled = (currentPage < pageCount);
            btnLast.Enabled = (currentPage < pageCount);
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

            worksheet.Application.StandardFont = "Myanmar3";
            worksheet.Application.StandardFontSize = 10;
            worksheet.Rows.WrapText = true;


            Excel.Range header = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgvCompanySales.Columns.Count + 1]];
            
            Excel.Range allColumns = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgvCompanySales.Columns.Count + 1]];
            allColumns.EntireColumn.ColumnWidth = 5;
            header.Merge();
            worksheet.Cells[1, 1] = "Monthly Company Sales For April' 2014";
            header.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            

            Excel.Range chartRange=worksheet.Range[worksheet.Cells[1,2],worksheet.Cells[10,2]];
            chartRange.EntireColumn.ColumnWidth = 28.89;

            for (int i = 1; i < dgvCompanySales.Columns.Count + 1; i++)
            {

                worksheet.Cells[3, i] = dgvCompanySales.Columns[i - 1].HeaderText;

            }
            // storing Each row and column value to excel sheet
            for (int i = 0; i < dgvCompanySales.Rows.Count - 1; i++)
            {

                for (int j = 0; j < dgvCompanySales.Columns.Count; j++)
                {
                    string str = (string)DataTypeParser.Parse(dgvCompanySales.Rows[i].Cells[j].Value, typeof(string), String.Empty);
                    worksheet.Cells[i + 4, j + 1] = str;
                }
            }

            //worksheet.Columns[2].

          
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
