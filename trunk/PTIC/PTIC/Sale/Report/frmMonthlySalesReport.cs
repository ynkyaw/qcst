using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.Sale.Report
{
    public partial class frmMonthlySalesReport : Form
    {
        public frmMonthlySalesReport()
        {
            InitializeComponent();
        }

        private void frmMonthlySalesReport_Load(object sender, EventArgs e)
        {

            

        }

        void LoadData() 
        {
            DataTable productList = new PTIC.Sale.BL.ProductBL().GetAll();
            string templateStr1 = ",SUM(ISNULL([{0}],0)) as [{0}]";
            string templateStr2 = "[{0}],";
            string selectQuery = @"SELECT *
                                   FROM 
                                   (SELECT CusName,SUM(SALESAMT) as salesAmt,SalesType";
            foreach (DataRow dr in productList.Rows)
            {
                selectQuery += string.Format(templateStr1, dr["ProductName"]);
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

            foreach (DataRow dr in productList.Rows)
            {
                selectQuery += string.Format(templateStr2, dr["ProductName"]);
            }
            selectQuery = selectQuery.Substring(0,selectQuery.Length - 1);
            selectQuery += @")) As C_P
                            group by CusName,SalesType) as t
                            PIVOT(SUM(SALESAMT) FOR SALESTYPE IN([Cash],[Credit]) )As Test";
            dataGridView1.DataSource=new PTIC.Common.DA.BaseDAO().SelectByQuery(selectQuery);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
