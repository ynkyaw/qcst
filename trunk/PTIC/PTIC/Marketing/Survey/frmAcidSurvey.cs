using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.VC;
using PTIC.Marketing.Survey;

namespace PTIC.Sale.Survey
{
    public partial class frmAcidSurvey : Form
    {
        /// <summary>
        /// Customer Data
        /// </summary>
        DataTable dtCusotmer = null;

        public frmAcidSurvey()
        {
            InitializeComponent();           
            LoadNBindData();           
        }

        public frmAcidSurvey(int CustomerID,int QuestionFormID,DateTime SurveyDate):this()
        {
            LoadNBindBy(CustomerID, QuestionFormID, SurveyDate);
            btnSave.Enabled = false;
        }

        #region Private Methods
        private void Clear()
        {
            txt1.Text = string.Empty;
            txt10.Text = string.Empty;
            chkAns1Gp.Checked = false;
            chkAns1GR.Checked = false;
            chkAns1KW.Checked = false;
            chkAns1Other.Checked =false;
         //   chkCycle1.Checked = false;
            chkAns1Xcl.Checked = false;
            chkAns2Gp.Checked = false;
            chkAns2Gr.Checked = false;
            chkAns2Kw.Checked = false;
            chkAns2Other.Checked = false;
            chkAns2Toyo.Checked = false;
            chkAns2Xcl.Checked = false;
            txt22_5.Text = string.Empty;
            txt3.Text = string.Empty;
            txt4.Text = string.Empty;
            txt5.Text = string.Empty;
            txt7.Text = string.Empty;
            txt8.Text = string.Empty;
            txt9.Text = string.Empty;
            txtAcidSize1.Text = string.Empty;
            txtAcidSize22_5.Text = string.Empty;
            txtAcidSize4.Text = string.Empty;
            txtAcidSize7.Text = string.Empty;
            txtAcidSize9.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtBottleColor.Text = string.Empty;
            cmbCustomer.SelectedIndex = -1;

        }

        private void LoadNBindBy(int CustomerID, int QuestionFormID, DateTime SurveyDate)
        {
            try
            {
                //  AcidSurvey Search By ........
                DataTable dtAcidSurvey = new AcidAnswerBL().AcidAnswerSearchBy(CustomerID, QuestionFormID, SurveyDate);

                if (dtAcidSurvey.Rows.Count > 0)
                {
                    chkAns1AcidToyo.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans1Toyo"], typeof(bool), false);
                    chkAns1Gp.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans1GP"], typeof(bool), false);
                    chkAns1GR.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans1Gr"], typeof(bool), false);
                    chkAns1KW.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans1Kw"], typeof(bool), false);
                    chkAns1Other.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans1Other"], typeof(bool), false);
                    chkAns1Xcl.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans1Xcl"], typeof(bool), false);

                    chkAns2Gp.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans2Gp"], typeof(bool), false);
                    chkAns2Gr.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans2Gr"], typeof(bool), false);
                    chkAns2Kw.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans2Kw"], typeof(bool), false);
                    chkAns2Other.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans2Other"], typeof(bool), false);
                    chkAns2Toyo.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans2Toyo"], typeof(bool), false);
                    chkAns2Xcl.Checked = (bool)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans2Xcl"], typeof(bool), false);

                    txt3.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans3"], typeof(string), string.Empty);

                    txt1.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans41Lit"], typeof(string), string.Empty);
                    txt4.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans44Lit"], typeof(string), string.Empty);
                    txt7.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans47Lit"], typeof(string), string.Empty);
                    txt9.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans49Lit"], typeof(string), string.Empty);
                    txt22_5.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans422Lit"], typeof(string), string.Empty);

                    txt5.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans5"], typeof(string), string.Empty);

                    txtBottleColor.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans6"], typeof(string), string.Empty);

                    txtAcidSize1.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans7"], typeof(string), string.Empty);
                    txtAcidSize4.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans74Lit"], typeof(string), string.Empty);
                    txtAcidSize7.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans77Lit"], typeof(string), string.Empty);
                    txtAcidSize9.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans79Lit"], typeof(string), string.Empty);
                    txtAcidSize22_5.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans722Lit"], typeof(string), string.Empty);

                    txt8.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans8"], typeof(string), string.Empty);
                    txt10.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Ans9"], typeof(string), string.Empty);

                    cmbCustomer.SelectedValue = (int)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["CustomerID"], typeof(int), -1);
                    dtpSurveyStartDate.Value = (DateTime)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["SurveyDate"], typeof(DateTime), DateTime.Now);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void LoadNBindData()
        {
            try
            {
                dtCusotmer= new CustomerBL().GetAll();
                cmbCustomer.DataSource = dtCusotmer;
                cmbCustomer.DisplayMember = "CusName";
                cmbCustomer.ValueMember = "CustomerID";
                cmbCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            int affectedRows = -1;

            AnswerForm _answerForm = new AnswerForm()
            {
                QuestionFormID = (int)PTIC.Common.Enum.QuestionForm.Acid,
                CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue,typeof(int),-1),
                SurveyDate = (DateTime)DataTypeParser.Parse(dtpSurveyStartDate.Value,typeof(DateTime),DateTime.Now)
            };

            AcidAnswer _acidAnswer = new AcidAnswer()
            {
                Ans1_TOYO  = (bool)DataTypeParser.Parse(chkAns1AcidToyo.Checked,typeof(bool),false),
                Ans1_GP =(bool)DataTypeParser.Parse(chkAns1Gp.Checked,typeof(bool),false),
                Ans1_GR =(bool)DataTypeParser.Parse(chkAns1GR.Checked,typeof(bool),false),
                Ans1_XCL =(bool)DataTypeParser.Parse(chkAns1Xcl.Checked,typeof(bool),false),
                Ans1_KW = (bool)DataTypeParser.Parse(chkAns1KW.Checked,typeof(bool),false),
                Ans1_Other = (bool)DataTypeParser.Parse(chkAns1Other.Checked,typeof(bool),false),
                Ans2_TOYO = (bool)DataTypeParser.Parse(chkAns2Toyo.Checked, typeof(bool), false),
                Ans2_GP = (bool)DataTypeParser.Parse(chkAns2Gp.Checked, typeof(bool), false),
                Ans2_GR = (bool)DataTypeParser.Parse(chkAns2Gr.Checked, typeof(bool), false),
                Ans2_XCL = (bool)DataTypeParser.Parse(chkAns2Xcl.Checked, typeof(bool), false),
                Ans2_KW = (bool)DataTypeParser.Parse(chkAns2Kw.Checked, typeof(bool), false),
                Ans2_Other = (bool)DataTypeParser.Parse(chkAns2Other.Checked, typeof(bool), false),
                Ans3 = (string)DataTypeParser.Parse(txt3.Text,typeof(string),string.Empty),
                Ans4_1Lit = (int)DataTypeParser.Parse(txt1.Text,typeof(int),0),
                Ans4_4Lit = (int)DataTypeParser.Parse(txt4.Text, typeof(int), 0),
                Ans4_7Lit = (int)DataTypeParser.Parse(txt7.Text, typeof(int), 0),
                Ans4_9Lit = (int)DataTypeParser.Parse(txt9.Text, typeof(int), 0),
                Ans4_22_5Lit = (int)DataTypeParser.Parse(txt22_5.Text, typeof(int), 0),
                Ans5 = (string)DataTypeParser.Parse(txt5.Text, typeof(string), string.Empty),
                Ans6 = (string)DataTypeParser.Parse(txtBottleColor.Text, typeof(string),string.Empty),
                Ans7_1Lit = (int)DataTypeParser.Parse(txtAcidSize1.Text, typeof(int), 0),
                Ans7_4Lit = (int)DataTypeParser.Parse(txtAcidSize4.Text, typeof(int), 0),
                Ans7_7Lit = (int)DataTypeParser.Parse(txtAcidSize7.Text, typeof(int), 0),
                Ans7_9Lit =  (int)DataTypeParser.Parse(txtAcidSize9.Text, typeof(int), 0),
                Ans7_22_5Lit = (int)DataTypeParser.Parse(txtAcidSize22_5.Text, typeof(int), 0),
                Ans8 = (string)DataTypeParser.Parse(txt8.Text, typeof(string), string.Empty),
                Ans9 = (string)DataTypeParser.Parse(txt10.Text, typeof(string), string.Empty),
            };

            if (_answerForm.CustomerID != -1)
            {
                affectedRows = new AcidAnswerBL().Add(_answerForm, _acidAnswer);
            }
            else
            {
                MessageBox.Show("Customer ရွေးပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (affectedRows > 0)
            {
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                Clear();
            }
        }
        #endregion

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue,typeof(int),-1);

            DataTable tmp = DataUtil.GetDataTableBy(dtCusotmer, "CustomerID", CustomerID);
            if (tmp == null) return;

            string address = string.Empty;
            // No            
            address += string.IsNullOrEmpty(tmp.Rows[0]["Hno"].ToString()) ? string.Empty : tmp.Rows[0]["Hno"].ToString() + ", ";
            // Street
            address += string.IsNullOrEmpty(tmp.Rows[0]["Street"].ToString()) ? string.Empty : tmp.Rows[0]["Street"].ToString() + ", ";
            // Quarter
            address += string.IsNullOrEmpty(tmp.Rows[0]["Quartar"].ToString()) ? string.Empty : tmp.Rows[0]["Quartar"].ToString() + ", ";
            // Township
            address += string.IsNullOrEmpty(tmp.Rows[0]["Township"].ToString()) ? string.Empty : tmp.Rows[0]["Township"].ToString() + ", ";
            // Town
            address += string.IsNullOrEmpty(tmp.Rows[0]["Town"].ToString()) ? string.Empty : tmp.Rows[0]["Town"].ToString() + ", ";
            // State / Division
            address += string.IsNullOrEmpty(tmp.Rows[0]["StateDivisionName"].ToString()) ? string.Empty : tmp.Rows[0]["StateDivisionName"].ToString() + ", ";

            string s = address;
            int i = s.LastIndexOf(',');
            s = s.Remove(i) +"။";          
            txtAddress.Text = s;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyPage));
            this.Close();
        }
    }
}
