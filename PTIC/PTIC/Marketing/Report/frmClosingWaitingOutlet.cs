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
            #region old Code
            //string templateForPreviousStatus = "SELECT IC.CUSSTAT AS PREVIOUS_STATUS,cc.ID,cc.CusName,cc.AddrID,cc.TripID";
            //templateForPreviousStatus+=" FROM CUSTOMER CC LEFT JOIN";
            //templateForPreviousStatus+=" (SELECT (CASE WHEN C.IsAlreadyParment=1 AND MONTH(C.FirstParmanentDate)<'{9}' THEN (";
            //templateForPreviousStatus+="  CASE WHEN( ";
            //templateForPreviousStatus+=" SELECT SUM(MC) ";
            //templateForPreviousStatus+=" FROM( ";
            //templateForPreviousStatus+=" SELECT COUNT(ID) AS MC,MONTH(SalesDate) SD ";
            //templateForPreviousStatus+=" FROM Invoice  ";
            //templateForPreviousStatus+=" WHERE Invoice.CusID=C.ID ";
            //templateForPreviousStatus+=" AND SalesDate BETWEEN '{8}' AND '{10}' ";
            //templateForPreviousStatus+=" GROUP BY MONTH(SALESDATE)) AS MS  ";
            //templateForPreviousStatus+=" )>2 THEN (CASE WHEN MONTH(C.FirstParmanentDate)=MONTH('20150401')  THEN 'NEW PARMENT' ";
            //templateForPreviousStatus += " ELSE 'PERMANT' END) ELSE 'WAITING' END ) ELSE (CASE WHEN C.ID IN (SELECT CusId FROM Invoice WHERE SalesDate < '{9}') ";
            //templateForPreviousStatus += " THEN 'NEW WAITING' ELSE 'POTENTIAL'END) END) AS CUSSTAT,C.ID ";
            //templateForPreviousStatus+=" FROM Customer C ";
            //templateForPreviousStatus+=" ) IC ";
            //templateForPreviousStatus += " ON CC.ID=IC.ID ";

            //string templateSql = "SELECT CUST.ID,CUST.CusName,CUST.PREVIOUS_STATUS PREVIOUS_STATUS,";
            //templateSql+=" ISNULL([{0}],0) [{0}],ISNULL([{1}],0) [{1}],ISNULL([{2}],0) [{2}],ISNULL([{3}],0) [{3}],ISNULL([{4}],0) [{4}],";
            //templateSql+=" ISNULL([{5}],0) [{5}],ISNULL([CURRENT_STATUS],'N')CURRENT_STATUS FROM ("+templateForPreviousStatus+") CUST LEFT JOIN (";
            //templateSql+=" SELECT CusID,[{0}],[{1}],[{2}],[{3}],[{4}],[{5}],";
            //templateSql+=" CASE WHEN ([{0}]+[{1}]+[{2}]+[{3}]+[{4}]+[{5}]) >2 THEN 'P' ELSE 'W' END AS [CURRENT_STATUS]";
            //templateSql+= " FROM (";
            //templateSql+="  SELECT COUNT(ID) AS SALES_COUNT,CusID,MONTH(SalesDate) SALESMONTH";
            //templateSql+="  FROM Invoice WHERE SalesDate BETWEEN '{6}' AND '{7}'";
            //templateSql+="  GROUP BY CusID,MONTH(SalesDate)) AS SALES_COUNTING";
            //templateSql+="  PIVOT(COUNT(SALES_COUNT) FOR SALESMONTH IN ([{0}],[{1}],[{2}],[{3}],[{4}],[{5}])) AS SALES_SUMMARY";
            //templateSql+=" ) AS SALES_CUST";
            //templateSql+=" ON CUST.ID=SALES_CUST.CusID";

            DateTime thisMonth = dtpMonth.Value;
            DateTime currCalDate = dtpMonth.Value.AddMonths(-5);
            DateTime prevCalDate = dtpMonth.Value.AddMonths(-5);
            DateTime currCalstartDate = new DateTime(currCalDate.Year, currCalDate.Month, 1);
            DateTime prevCalstartDate = new DateTime(prevCalDate.Year, prevCalDate.Month, 1);
            DateTime thisMonthendDate = new DateTime(thisMonth.Year, thisMonth.Month, DateTime.DaysInMonth(thisMonth.Year, thisMonth.Month));
            DateTime thisMonthStartDate = new DateTime(thisMonth.Year, thisMonth.Month, 1);
            DateTime prevMonth = dtpMonth.Value.AddMonths(-1);
            DateTime prevMonthendDate = new DateTime(prevMonth.Year, prevMonth.Month, DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month));
            DateTime prevMonthStartDate = new DateTime(prevMonth.Year, prevMonth.Month, 1);
            
            string param0 = currCalstartDate.Month.ToString();
            string param1 = currCalstartDate.AddMonths(1).Month.ToString();
            string param2 = currCalstartDate.AddMonths(2).Month.ToString();
            string param3 = currCalstartDate.AddMonths(3).Month.ToString();
            string param4 = currCalstartDate.AddMonths(4).Month.ToString();
            string param5 = currCalstartDate.AddMonths(5).Month.ToString();
            string param6 = currCalstartDate.ToString("yyyyMMdd");
            string param7 = thisMonthendDate.ToString("yyyyMMdd");
            string param8 = thisMonthStartDate.ToString("yyyyMMdd");
            string param9 = prevMonthStartDate.ToString("yyyyMMdd");
            string param10 = prevCalDate.ToString("yyyyMMdd");
            string param11 = prevMonthendDate.ToString("yyyyMMdd");
            //
            #endregion

            string templateSql = @"SELECT CUSTOMER_STATUS.ID,CUSTOMER_STATUS.CusName,
                                    Convert(bit,ISNULL([{0}],0)) [{0}],
                                    Convert(bit,ISNULL([{1}],0)) [{1}],
                                    Convert(bit,ISNULL([{2}],0)) [{2}],
                                    Convert(bit,ISNULL([{3}],0)) [{3}],
                                    Convert(bit,ISNULL([{4}],0)) [{4}],
                                    Convert(bit,ISNULL([{5}],0)) [{5}],CUSTOMER_STATUS.Prev_Status,CUSTOMER_STATUS.Curr_Status
                                    FROM(
                                         SELECT dbo.[GetCustomerStatus]('{9}','{11}','{10}',ID) Prev_Status,CusName,ID,AddrID,TripID,dbo.[GetCustomerStatus]('{8}','{7}','{6}',ID) Curr_Status
                                           From Customer)  AS CUSTOMER_STATUS LEFT JOIN ( SELECT CusID,[{0}],[{1}],[{2}],[{3}],[{4}],[{5}]
                                                                                                 FROM (  
                                                                                 SELECT COUNT(ID) AS SALES_COUNT,CusID,MONTH(SalesDate) SALESMONTH  
                                                                                 FROM Invoice WHERE SalesDate BETWEEN '{6}' AND '{7}'  
                                                                                 GROUP BY CusID,MONTH(SalesDate)) AS SALES_COUNTING  
                                                                                 PIVOT(COUNT(SALES_COUNT) FOR SALESMONTH IN ([{0}],[{1}],[{2}],[{3}],[{4}],[{5}])) 
                                                                                 AS SALES_SUMMARY ) AS CUSTOMER_TRANSACTION
                                        ON CUSTOMER_STATUS.ID=CUSTOMER_TRANSACTION.CusID";
            string sql = string.Format(templateSql, param0, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

            if (comboBox1.SelectedIndex == 0)
            {
                string ygnCustomer = " INNER JOIN [Address] ADDR ON CUSTOMER_STATUS.AddrID=ADDR.ID WHERE ADDR.TownID ='1' AND CUSTOMER_STATUS.TRIPID IS NULL";
                sql += ygnCustomer;
            }
            else
            {
                string tripCustomer = string.Format(" INNER JOIN Trip T ON T.ID=CUSTOMER_STATUS.TripID WHERE T.ID={0}", comboBox1.SelectedValue);
                sql += tripCustomer;
            }
            sql += " AND CUSTOMER_STATUS.Curr_Status<>'POTENTIAL' ";
            DataTable result = new PTIC.Common.DA.BaseDAO().SelectByQuery(sql);
            for (int i = 0; i < 6; i++)
                result.Columns[2 + i].ColumnName = new DateTime(DateTime.Now.Year, int.Parse(result.Columns[2 + i].ColumnName), 1).ToString("MMM");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result;
        }
    }
}
