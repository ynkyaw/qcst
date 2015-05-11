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
    public partial class frmYearlyCustomerComplainSummaryReport : Form
    {
        DataTable uiTable;
        int pageSize = 10;
        int currentPage = 0;
        int totalPageCount = 0;
        DataTable complainCases;
        int []totalCaseCount = new int[12];
        
        public frmYearlyCustomerComplainSummaryReport()
        {
            InitializeComponent();
            complainCases = PTIC.Marketing.DA.ComplaintCaseDA.SelectComplaintCase();
            if (complainCases.Rows.Count > 0)
            {
                totalPageCount = complainCases.Rows.Count / pageSize;
                if (complainCases.Rows.Count % pageSize > 0) 
                {
                    totalPageCount++;
                }
            }
        }

        private void InitUITable() 
        {
            uiTable = new DataTable();
            uiTable.Columns.Add("No.", typeof(string));
            uiTable.Columns.Add("ComplainCase", typeof(string));
            uiTable.Columns.Add("Jan", typeof(string));
            uiTable.Columns.Add("Feb", typeof(string));
            uiTable.Columns.Add("Mar", typeof(string));
            uiTable.Columns.Add("Apr", typeof(string));
            uiTable.Columns.Add("May", typeof(string));
            uiTable.Columns.Add("Jun", typeof(string));
            uiTable.Columns.Add("Jul", typeof(string));
            uiTable.Columns.Add("Aug", typeof(string));
            uiTable.Columns.Add("Sep", typeof(string));
            uiTable.Columns.Add("Oct", typeof(string));
            uiTable.Columns.Add("Nov", typeof(string));
            uiTable.Columns.Add("Dec", typeof(string));
            uiTable.Columns.Add("Total", typeof(string));
            string templateHeader="Case|Battery|Qty|"+"\r"+" No |  Size |   |"+"\r"+"-----------------"+"\r"+"   1|N-20 |2"+"\r"+"  20|N-70 |2";


            uiTable.Rows.Add("92", "Acid (M)  Parking ထဲတွင် အက်ဆစ်များယိုစိမ့်၍ စုတ်ပြဲနေခြင်း၊"+"\r"+"အက်ဆစ်ဗူးနှုတ်ခမ်းများပျော့၍ weight မခံနိုင်တော့၍", templateHeader, templateHeader, templateHeader,
                templateHeader, templateHeader, templateHeader, templateHeader, templateHeader, templateHeader, templateHeader, templateHeader, templateHeader, "200");
            dataGridView1.DataSource = uiTable;
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[1].Width = 250;
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].Width = 75;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrepareData(numericUpDown1.Value);
            
        }

        private void PrepareData(decimal year) 
        {
            InitUITable();
            int currentIndex = pageSize*currentPage;
            for (int i = 0; i < pageSize; i++) 
            {
                if (complainCases.Rows.Count >= currentIndex)
                {
                    int complainCaseId =(int)complainCases.Rows[currentIndex][0];
                    string complainCase = complainCases.Rows[currentIndex][1] + string.Empty;
                    string[] monthCase = new string[12];
                    string[] batteries = new string[12];
                    int[] monthlyCaseCount = new int[12];
                    int totalCount = 0;




                    //uiTable.Rows.Add((currentIndex + 1).ToString(), complainCases, monthCase[0], monthCase[1], monthCase[2], monthCase[3],
                    //    monthCase[4], monthCase[5], monthCase[6], monthCase[7],monthCase[8], monthCase[9], monthCase[10], monthCase[11],totalCount.ToString());

                    //uiTable.Rows.Add(string.Empty,"Battery Size", monthCase);

                    currentIndex++;
                }
                else break;
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
