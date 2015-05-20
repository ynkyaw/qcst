using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.Survey;

namespace PTIC.Marketing.Survey
{
    public partial class frmSurveyPage : Form
    {
        public frmSurveyPage()
        {
            InitializeComponent();
        }

        private void btnAcid_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmAcidSurvey));
            this.Close();
        }

        private void btnSurveyQuestionList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmAcidAnswerList));
            this.Close();
        }

        private void btnLion_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmLionCycleBatterySurvey));
            this.Close();
        }

        private void btnSurveyQuestion_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmToyoBatterySurvey));
            this.Close();
        }

        private void btnSurveyResult_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyResult));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             UIManager.MdiChildOpenForm(typeof(PTIC.Marketing.Report.frmToyoSurvey));
            this.Close();
            
        }
    }
}
