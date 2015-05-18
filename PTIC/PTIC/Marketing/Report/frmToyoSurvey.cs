using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PTIC.Marketing.Report
{
    public partial class frmToyoSurvey : Form
    {
        public frmToyoSurvey()
        {
            InitializeComponent();
        }

        private void frmToyoSurvey_Load(object sender, EventArgs e)
        {
            string templateSql = @"SELECT CR.CusName,CR.Region,AF.QuestionFormID,Q.Question,SQ.SubQuestion,Convert(int,Ans1)*3 as Ans1,Convert(int,Ans2)*2 as Ans2,Convert(int,Ans3) as Ans3,sq.Answer1,SQ.Answer2,SQ.Answer3,RS.Suggestion,RS.OtherSuggestion
                                    FROM AnswerForm AF INNER JOIN RetailerSuggestion RS
                                    ON AF.ID=RS.AnswerFormID
                                    INNER JOIN RetailerAnswer RA
                                    ON AF.ID=RA.AnswerFormID
                                    INNER JOIN tblQuestionNo Q
                                    ON RA.QuestionNo = Q.QuestionNo
                                    AND AF.QuestionFormID=Q.QuestionFormId
                                    INNER JOIN tblSubQuestion SQ
                                    ON SQ.QuestionId=Q.Id
                                    AND RA.SubQuestionNo=SQ.SubQuestionNo
                                    INNER JOIN (SELECT C.ID,C.CusName,ISNULL(T.TripName,'Yangon') as Region
                                    FROM Customer C
                                    LEFT JOIN Trip T
                                    ON C.TripID=T.ID) as CR
                                    ON CR.ID=AF.CustomerID
                                    Order by RA.QuestionNo";

            //string sql = string.Format(templateSql, dtpMonth.Value.Month, dtpMonth.Value.Year);
            DataTable dt = new PTIC.Common.DA.BaseDAO().SelectByQuery(templateSql);
            //dataGridView1.DataSource = dt;
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTIC.Marketing.Report.ToyoSurvey.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ToyoSurvey", dt));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("rptParamMonthYear", dtpMonth.Value.ToString("MMM,yyyy")));
            this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }
    }
}
