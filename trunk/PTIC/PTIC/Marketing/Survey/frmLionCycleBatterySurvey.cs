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
using PTIC.Sale.Entities;
using PTIC.Marketing.BL;
using PTIC.VC;

namespace PTIC.Marketing.Survey
{
    public partial class frmLionCycleBatterySurvey : Form
    {
        /// <summary>
        /// DataTable for Customer
        /// </summary>
        DataTable dtCusotmer = null;

        List<RetailerAnswer> _retailerAnswerList = new List<RetailerAnswer>();

        public frmLionCycleBatterySurvey()
        {
            InitializeComponent();
            LoadNBindData();
        }

        public frmLionCycleBatterySurvey(int CustomerID,int QuestionFormID,DateTime SurveyDate):this()
        {
            LoadNBindBy(CustomerID, QuestionFormID, SurveyDate);
            btnSave.Enabled = false;
        }

        #region Private Methods
        private void Clear()
        {
            rdoCheap.Checked = false;
            rdoComGood.Checked = false;
            rdoComNormal.Checked = false;
            rdoComWrose.Checked = false;
            rdoCycle3.Checked = false;
            rdoCycle6.Checked = false;
            rdoCycleGood.Checked = false;
            rdoDesignGood.Checked = false;
            rdoDesignNormal.Checked = false;
            rdoDesignWrose.Checked = false;
            rdoDieCutGood.Checked = false;
            rdoDieCutNormal.Checked = false;
            rdoDieCutWrose.Checked = false;
            rdoDistributeGood.Checked = false;
            rdoDistributeNormal.Checked = false;
            rdoDistributeWrose.Checked = false;
            rdoEmpGood.Checked = false;
            rdoEmpNormal.Checked = false;
            rdoEmpWrose.Checked = false;
            rdoExpensive.Checked = false;
            //rdoFlagLineGood.Checked = false;
            //rdoFlagLineNormal.Checked = false;
            //rdoFlagLineWrose.Checked = false;
            //rdoNormal.Checked = false;
            //rdoPBBoardGood.Checked = false;
            //rdoPBBoardNormal.Checked = false;
            //rdoPBBoardWrose.Checked = false;
            txtAddress.Text = string.Empty;
            txtSuggestion.Text = string.Empty;
        }

        private void LoadNBindBy(int CustomerID, int QuestionFormID, DateTime SurveyDate)
        {
            try
            {
                //  Lion Cycle  OR TOYO Survey Search By ........
                DataTable dtAcidSurvey = new RetailerAnswerBL().AnswerSearchBy(CustomerID, QuestionFormID, SurveyDate);
                int index = 0;
                if (dtAcidSurvey.Rows.Count > 0)
                {
                    foreach (DataRow row in dtAcidSurvey.Rows)
                    {    

                        switch (index)
                        {
                            case 0:
                                rdoCycleGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoCycle6.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoCycle3.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 1:
                                rdoCheap.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoExpensive.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 2:
                                rdoDesignGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoDesignNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoDesignWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 3:
                                rdoDistributeGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoDistributeNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoDistributeWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 4:
                                rdoEmpGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoEmpNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoEmpWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 5:
                                rdoComGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoComNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoComWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 6:
                                rdoDieCutGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoDieCutNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoDieCutWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            //case 7:
                            //    rdoPBBoardGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                            //    rdoPBBoardNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                            //    rdoPBBoardWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                            //    break;

                            //case 8:
                            //    rdoFlagLineGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                            //    rdoFlagLineNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                            //    rdoFlagLineWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                            //    break;
                        }

                        index++;
                    }

                    txtSuggestion.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Suggestion"], typeof(string), string.Empty);
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
                dtCusotmer = new CustomerBL().GetAll();
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
                QuestionFormID = (int)PTIC.Common.Enum.QuestionForm.Lion,
                CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1),
                SurveyDate = (DateTime)DataTypeParser.Parse(dtpSurveyStartDate.Value, typeof(DateTime), DateTime.Now)
            };

            RetailerSuggestion _retailerSuggestion = new RetailerSuggestion()
            {
                Suggestion = (string)DataTypeParser.Parse(txtSuggestion.Text,typeof(string),string.Empty),
                OtherSuggestion = (string)DataTypeParser.Parse(string.Empty, typeof(string), string.Empty)
            };

            //for(int i=1; i < 10;i++)
            //{
            //    if (i == 1)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //        _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoCycleGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoCycle6.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoCycle3.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = 1;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if(i ==2)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();                    
            //        _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoCheap.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoExpensive.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if(i==3)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();                   
            //        _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoDesignGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoDesignNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoDesignWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if (i == 4)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //        _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoDistributeGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoDistributeNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoDistributeWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if (i == 5)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //      _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoEmpGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoEmpNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoEmpWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if (i == 6)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //       _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoComGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoComNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoComWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if (i == 7)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //       _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoDieCutGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoDieCutNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoDieCutWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if (i == 8)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //        _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoPBBoardGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoPBBoardNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoPBBoardWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }
            //    else if (i == 9)
            //    {
            //        RetailerAnswer _retailerAnswer = new RetailerAnswer();
            //       _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoFlagLineGood.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoFlagLineNormal.Checked, typeof(bool), false);
            //        _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoFlagLineWrose.Checked, typeof(bool), false);
            //        _retailerAnswer.QuestionNo = i;
            //        _retailerAnswerList.Add(_retailerAnswer);
            //    }                
            //}

            //if (_answerForm.CustomerID != -1)
            //{
            //    affectedRows = new RetailerAnswerBL().Add(_answerForm, _retailerSuggestion, _retailerAnswerList);
            //}
            //else
            //{
            //    MessageBox.Show("Customer ရွေးပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (affectedRows > 0)
            //{
            //    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
            //     Clear();
            //}
        }
        #endregion

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1);

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
            s = s.Remove(i) + "။";
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
