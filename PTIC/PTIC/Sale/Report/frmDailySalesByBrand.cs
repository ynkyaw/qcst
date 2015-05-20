using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Sale.Report
{
    public partial class frmDailySalesByBrand : Form
    {
        public frmDailySalesByBrand()
        {
            InitializeComponent();
            DataTable config = new BaseDAO().SelectByQuery("SELECT * FROM PRODUCTCONFIG");
            comboBox1.DataSource = config;
            comboBox1.DisplayMember = "ConfigName";
            comboBox1.ValueMember = "Id";
        }

        private void frmDailySalesByBrand_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadReport(int configId,DateTime salesDate)
        {
            string template1 = @"SELECT STUFF(
			                                            (SELECT '],['+ProductName  
			                                             FROM Product P INNER JOIN ProductConfigDetails PCD
			                                             ON P.ID=PCD.ProductId
			                                             
			                                             WHERE PCD.ProductConfigID= Config.ID and p.IsDeleted=0
			                                             order by PCD.OrderNo
			                                             FOR XML PATH('')),1,1,'') AS TESTING
			                                             FROM ProductConfig Config
			                                             WHERE Config.ID={0}";

            string sql = string.Format(template1, configId);
            string productList = new BaseDAO().SelectScalar(sql)+string.Empty;
            string conditionalSql = string.Format(" WHERE CONVERT(DATE,SalesDate)='{0}'", salesDate.ToShortDateString());
            string conditionalSql2 = string.Format(" WHERE Month(SalesDate)={0} AND YEAR(SalesDate)={1}", salesDate.Month,salesDate.Year);

            string stockSqlTemplate = @"SELECT Warehouse,{0},{1}
                                        FROM(
                                        SELECT W.Warehouse,SUM(QTY) as TOTALQTY,ProductName
                                        FROM [StockInWarehouse] SW
                                        INNER JOIN Warehouse W
                                        ON SW.WarehouseID=W.ID
                                        INNER JOIN Product P
                                        ON SW.ProductID=P.ID
                                        WHERE W.ID IN (1,2)
                                        GROUP BY W.Warehouse,ProductName)as TT
                                        PIVOT (SUM(TOTALQTY) FOR ProductName IN ({0}))AS TESTING";
            
                                            

           productList = productList.Substring(1, productList.Length - 1) + "]";
           string productListTotal = productList.Replace(",", "+")+" AS Total";
           productListTotal = productListTotal.Replace("[", "ISNULL([");
           productListTotal = productListTotal.Replace("]", "],0)");
           string sqlStock = string.Format(stockSqlTemplate, productList, productListTotal);
           DataTable result = LoadDataForGrid(conditionalSql, productList, productListTotal);
           DataTable result2 = LoadDataForGrid(conditionalSql2, productList, productListTotal);
           DataTable result3 = new BaseDAO().SelectByQuery(sqlStock);

           dataGridView1.DataSource = null;
           dataGridView2.DataSource = null;
           dataGridView3.DataSource = null;
           dataGridView1.DataSource = result;
           dataGridView2.DataSource = result2;
           dataGridView3.DataSource = result3;
           AlignGrid(dataGridView1);
           AlignGrid(dataGridView2);
           AlignGrid(dataGridView3);
        }

        private void AlignGrid(DataGridView obj) 
        {
            //obj.Columns[0].Width = 200;
            for (int i = 1; i < obj.Columns.Count; i++)
            {
                obj.Columns[i].Width = 60;
                obj.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private DataTable LoadDataForGrid(string conditionalSql, string productList, string productListTotal)
        {
            #region Calculate Qty Sql
            string consignmentTemplate = @"(SELECT 'Consignment' as Col,{1},{2}
                                            FROM (
                                            SELECT P.ProductName,SUM(SD.Qty ) TOTALQTY
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            {0}
                                            AND SaleType=1
                                            and c.CusType<>3 and c.CusType<>4
                                            GROUP BY SD.ProductID,P.ProductName) AS TT
                                            PIVOT (SUM(TOTALQTY) FOR ProductName IN ({1}))AS TESTING)";

            string warehouseTemplate = @" (SELECT Col,{1},{2}
                                            FROM (
                                            SELECT W.Warehouse AS Col ,P.ProductName,SUM(SD.Qty ) TOTALQTY
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            INNER JOIN Warehouse W
                                            ON I.WAREHOUSEID=W.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            and c.CusType<>3 and c.CusType<>4
                                            {0}
                                            AND (SaleType IS NULL OR SaleType=0)
                                            GROUP BY W.Warehouse,SD.ProductID,P.ProductName) AS TT
                                            PIVOT (SUM(TOTALQTY) FOR ProductName IN ({1}))AS TESTING)";
            string companyGovTemplate = @" (SELECT Col,{1},{3}
                                            FROM (
                                            SELECT 'Company' AS Col ,P.ProductName,SUM(SD.Qty ) TOTALQTY
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            {0}
                                            AND (SaleType IS NULL OR SaleType=0)
                                            and c.CusType={2}
                                            GROUP BY SD.ProductID,P.ProductName) AS TT
                                            PIVOT (SUM(TOTALQTY) FOR ProductName IN ({1}))AS TESTING
                                            )";

            string companyTemplate = @" (SELECT Col,{1},{3}
                                            FROM (
                                            SELECT 'Company'+(case when SaleType IS null then ' Cash' else '' end) as Col ,P.ProductName,SUM(SD.Qty ) TOTALQTY
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            {0}
                                            AND (SaleType IS NULL OR SaleType=0)
                                            and c.CusType={2}
                                            GROUP BY SD.ProductID,P.ProductName,SaleType) AS TT
                                            PIVOT (SUM(TOTALQTY) FOR ProductName IN ({1}))AS TESTING
                                            )";


            
            string ygnRegTemplate = @" (SELECT Col,{1},{2}
                                            FROM (
                                            SELECT '{4}' AS Col ,P.ProductName,SUM(SD.Qty ) TOTALQTY
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            and c.CusType<>3 and c.CusType<>4
                                            INNER JOIN Address CusAddr
                                            ON C.AddrID=CusAddr.ID
                                            and CusAddr.TownID {3} 1
                                            {0}
                                            AND I.WareHouseId=0
                                            AND (SaleType IS NULL OR SaleType=0)
                                            GROUP BY SD.ProductID,P.ProductName) AS TT
                                            PIVOT (SUM(TOTALQTY) FOR ProductName IN ({1}))AS TESTING)";
            #endregion
            #region Calculate Total
            string productListForCalTotal = productList.Replace("[", "'");
            productListForCalTotal = productListForCalTotal.Replace("]", "'");
            string ygnTotalSql = @"SELECT SUM(SD.Qty*sd.SalePrice ) Amt
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            and c.CusType<>3 and c.CusType<>4
                                            INNER JOIN Address CusAddr
                                            ON C.AddrID=CusAddr.ID
                                            and CusAddr.TownID {2} 1
                                            {0}
                                            AND I.WareHouseId=0
                                            AND (SaleType IS NULL OR SaleType=0)
                                            and ProductName IN ({1})";
            string congTotalSql = @"SELECT SUM(SD.Qty*sd.SalePrice ) Amt
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            {0}
                                            AND SaleType=1
                                            and c.CusType<>3 and c.CusType<>4
                                            and ProductName IN ({1})";
            string warehouseTotalSql = @"SELECT SUM(SD.Qty*sd.SalePrice ) Amt
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            INNER JOIN Warehouse W
                                            ON I.WAREHOUSEID=W.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            and c.CusType<>3 and c.CusType<>4
                                            {0}
                                            AND (SaleType IS NULL OR SaleType=0)
                                            and ProductName IN ({1})
                                            GROUP BY I.WAREHOUSEID";
            string companyGoveTotalSql = @"SELECT SUM(SD.Qty*sd.SalePrice ) Amt
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            {0}
                                            AND (SaleType IS NULL OR SaleType=0)
                                            and c.CusType={2}
                                            and ProductName IN ({1})";

            string companyTotalSql = @"SELECT SUM(SD.Qty*sd.SalePrice ) Amt
                                            FROM Invoice I INNER JOIN SalesDetail SD
                                            ON I.ID=SD.InvoiceID
                                            INNER JOIN Product P
                                            ON SD.ProductID=P.ID
                                            Inner Join Customer C
                                            ON C.ID=i.CusID
                                            {0}
                                            AND (SaleType IS NULL OR SaleType=0)
                                            and c.CusType={2}
                                            and ProductName IN ({1})
                                            Group By I.SaleType";

            

            #endregion

            DataTable yangon = new BaseDAO().SelectByQuery(string.Format(ygnRegTemplate, conditionalSql, productList, productListTotal, "=", "Yangon"));
            DataTable consignment = new BaseDAO().SelectByQuery(string.Format(consignmentTemplate, conditionalSql, productList, productListTotal));
            DataTable reg = new BaseDAO().SelectByQuery(string.Format(ygnRegTemplate, conditionalSql, productList, productListTotal, "<>", "Regional"));
            DataTable wareHouse = new BaseDAO().SelectByQuery(string.Format(warehouseTemplate, conditionalSql, productList, productListTotal));
            DataTable company = new BaseDAO().SelectByQuery(string.Format(companyTemplate, conditionalSql, productList, 3, productListTotal));
            DataTable gov = new BaseDAO().SelectByQuery(string.Format(companyGovTemplate, conditionalSql, productList, 4, productListTotal));

            DataTable yangonAmt = new BaseDAO().SelectByQuery(string.Format(ygnTotalSql, conditionalSql, productListForCalTotal, "="));
            DataTable consignmentAmt = new BaseDAO().SelectByQuery(string.Format(congTotalSql, conditionalSql, productListForCalTotal, productListTotal));
            DataTable regAmt = new BaseDAO().SelectByQuery(string.Format(ygnTotalSql, conditionalSql, productListForCalTotal, "<>"));
            DataTable wareHouseAmt = new BaseDAO().SelectByQuery(string.Format(warehouseTotalSql, conditionalSql, productListForCalTotal));
            DataTable companyAmt = new BaseDAO().SelectByQuery(string.Format(companyTotalSql, conditionalSql, productListForCalTotal, 3));
            DataTable govAmt = new BaseDAO().SelectByQuery(string.Format(companyGoveTotalSql, conditionalSql, productListForCalTotal, 4, productListTotal));

            AddingAmount(yangon, yangonAmt);
            AddingAmount(consignment, consignmentAmt);
            AddingAmount(reg, regAmt);
            AddingAmount(wareHouse, wareHouseAmt);
            AddingAmount(company, companyAmt);
            AddingAmount(gov, govAmt);
            if (yangon.Rows.Count < 1)
                yangon = FillBlankData(yangon, "Yangon");
            if (reg.Rows.Count < 1)
                reg = FillBlankData(reg, "Regional");
            if (consignment.Rows.Count < 1)
                consignment = FillBlankData(consignment, "Consignment");


            DataTable warehouseList = new BaseDAO().SelectByQuery("select Warehouse from Warehouse where IsDeleted=0");
            if (wareHouse.Rows.Count < warehouseList.Rows.Count)
            {
                foreach (DataRow dr in warehouseList.Rows)
                {
                    bool isContained = false;
                    foreach (DataRow dataRw in wareHouse.Rows)
                    {
                        if (dr[0] == dataRw[0])
                        {
                            isContained = true;
                            break;
                        }
                    }
                    if (!isContained)
                        wareHouse = FillBlankData(wareHouse, dr[0] + string.Empty);
                }
            }
            if (company.Rows.Count < 1)
                company = FillBlankData(company, "Company");
            if (gov.Rows.Count < 1)
                gov = FillBlankData(gov, "Goverment");
            DataTable result = yangon.Copy();
            result.Merge(consignment);
            result.Merge(reg);
            result.Merge(wareHouse);
            result.Merge(company);
            result.Merge(gov);
            result = AddingTotal(result);
            return result;
        }

        DataTable AddingAmount(DataTable dt, DataTable amttbl) 
        {
            dt.Columns.Add("Amount");
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                dt.Rows[i][dt.Columns.Count - 1] = amttbl.Rows[i][0];
            }

            return dt;
        }

        private DataTable AddingTotal(DataTable dt) 
        {
            DataRow dr = dt.NewRow();
            dr[0] = "Total";
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dr[i] = 0;
               for(int j=0;j<dt.Rows.Count;j++)
               {
                   if (dt.Rows[j][i] != null && dt.Rows[j][i] != DBNull.Value) 
                   {
                       if(i!=dt.Columns.Count-1)
                           dr[i] = ((decimal)dr[i] + (decimal)dt.Rows[j][i]);
                       else
                           dr[i] = (decimal.Parse(dr[i]+string.Empty) + decimal.Parse(dt.Rows[j][i]+string.Empty))+string.Empty;
                   }
               }
            }
            
            dt.Rows.Add(dr);
            dt.Columns[0].ColumnName = "  ";
            return dt;
        }

        private DataTable FillBlankData(DataTable dt, string name) 
        {
            DataRow dr = dt.NewRow();
            dr[0] = name;
            for (int i = 1; i <dt.Columns.Count; i++) 
            {
                dr[i] = DBNull.Value;
            }
            dt.Rows.Add(dr);
            return dt;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReport((int)comboBox1.SelectedValue, dateTimePicker1.Value);
        }
    }
}
