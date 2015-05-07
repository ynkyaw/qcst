using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.Marketing.Report
{
    public partial class frmClosingWaitingOutlet : Form
    {
        public frmClosingWaitingOutlet()
        {
            InitializeComponent();
            string sqlCombo = "(SELECT 0 ID,TOWN DISPLAY FROM Town WHERE ID =1) UNION (SELECT ID,TripName DISPLAY FROM Trip)";
            DataTable result = new PTIC.Common.DA.BaseDAO().SelectByQuery(sqlCombo);
            comboBox1.DataSource = result;
            comboBox1.DisplayMember = "DISPLAY";
            comboBox1.ValueMember = "ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string templateSql = "SELECT CUST.ID,CUST.CusName,ISNULL(SALES_CUST.PREVIOUS_STATUS,' ') PREVIOUS_STATUS,";
            templateSql+=" ISNULL([{0}],0) [{0}],ISNULL([{1}],0) [{1}],ISNULL([{2}],0) [{2}],ISNULL([{3}],0) [{3}],ISNULL([{4}],0) [{4}],";
            templateSql+=" ISNULL([{5}],0) [{5}],ISNULL([CURRENT_STATUS],'N')CURRENT_STATUS FROM Customer CUST LEFT JOIN (";
            templateSql+=" SELECT CusID,'' AS PREVIOUS_STATUS,[{0}],[{1}],[{2}],[{3}],[{4}],[{5}],";
            templateSql+=" CASE WHEN ([{0}]+[{1}]+[{2}]+[{3}]+[{4}]+[{5}]) >2 THEN 'P' ELSE 'W' END AS [CURRENT_STATUS]";
            templateSql+= " FROM (";00
	        templateSql+="  SELECT COUNT(ID) AS SALES_COUNT,CusID,MONTH(SalesDate) SALESMONTH";
	        templateSql+="  FROM Invoice WHERE SalesDate BETWEEN '{6}' AND '{7}'";
	        templateSql+="  GROUP BY CusID,MONTH(SalesDate)) AS SALES_COUNTING";
            templateSql+="  PIVOT(COUNT(SALES_COUNT) FOR SALESMONTH IN ([{0}],[{1}],[{2}],[{3}],[{4}],[{5}])) AS SALES_SUMMARY";
            templateSql+=" ) AS SALES_CUST";
            templateSql+=" ON CUST.ID=SALES_CUST.CusID";
            

            DateTime calDate = dtpMonth.Value.AddMonths(-5);
            DateTime startDate = new DateTime(calDate.Year, calDate.Month, 1);
            DateTime endDate =new DateTime(dtpMonth.Value.Year, dtpMonth.Value.Month, DateTime.DaysInMonth(dtpMonth.Value.Year, dtpMonth.Value.Month));
            string param6 = startDate.ToString("yyyyMMdd");
            string param7 = endDate.ToString("yyyyMMdd");
            string param0 = startDate.Month.ToString();
            string param1 = startDate.AddMonths(1).Month.ToString();
            string param2 = startDate.AddMonths(2).Month.ToString();
            string param3 = startDate.AddMonths(3).Month.ToString();
            string param4 = startDate.AddMonths(4).Month.ToString();
            string param5 = startDate.AddMonths(5).Month.ToString();

            string sql = string.Format(templateSql, param0, param1, param2, param3, param4, param5, param6, param7);

            if (comboBox1.SelectedIndex == 0)
            {
                string ygnCustomer = " INNER JOIN [Address] ADDR ON CUST.AddrID=ADDR.ID WHERE ADDR.TownID ='1' AND TRIPID IS NULL";
                sql += ygnCustomer;
            }
            else
            {
                string tripCustomer = string.Format(" INNER JOIN Trip T ON T.ID=CUST.TripID WHERE T.ID={0}", comboBox1.SelectedValue);
                sql += tripCustomer;
            }
            DataTable result = new PTIC.Common.DA.BaseDAO().SelectByQuery(sql);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result;
        }
    }
}
