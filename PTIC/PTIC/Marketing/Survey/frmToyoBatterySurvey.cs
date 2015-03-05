using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.Marketing.Entities;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Marketing.BL;
using PTIC.Util;

namespace PTIC.Marketing.Survey
{
     public partial class frmToyoBatterySurvey : Form
    {
        /// <summary>
        /// DataTable for Customer
        /// </summary>
        DataTable dtCusotmer = null;

        List<RetailerAnswer> _retailerAnswerList = new List<RetailerAnswer>();

        public frmToyoBatterySurvey()
        {
            InitializeComponent();
            LoadNBindData();
        }

        public frmToyoBatterySurvey(int CustomerID, int QuestionFormID, DateTime SurveyDate)
            : this()
        {
            LoadNBindBy(CustomerID, QuestionFormID, SurveyDate);
            btnSave.Enabled = false;
        }

        #region Private Methods
        private void LoadNBindBy(int CustomerID, int QuestionFormID, DateTime SurveyDate)
        {
            try
            {
                //  Lion Cycle  OR TOYO Survey Search By ........
                DataTable dtAcidSurvey = new RetailerAnswerBL().AnswerSearchBy(CustomerID, QuestionFormID, SurveyDate);
                //int index = 0;
                if (dtAcidSurvey.Rows.Count > 0)
                {
                    foreach (DataRow row in dtAcidSurvey.Rows)
                    {
                        int questionNo = (int)DataTypeParser.Parse(row["QuestionNo"], typeof(int), -1);

                        switch (questionNo)
                        {
                            case 1:
                                rdoCarGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoCarNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoCarWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 2:
                                rdoInverterGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoInverterNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoInverterWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 3:
                                rdoCheap.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoExpensive.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 4:
                                rdoDesignGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoDesignNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoDesignWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 5:
                                 rdoDistributeGood.Checked= (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoDistributeNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoDistributeWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 6:
                                rdoWranGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoWranNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoWranWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 7:
                                rdoResaleGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoResaleNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoResaleWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 8:
                                rdoPresentGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoPresentNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoPresentWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 9:
                                rdoEmpGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoEmpNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoEmpWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 10:
                                rdoTVGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoTVNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoTVWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 11:
                                rdoDieCutGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoDieCutNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoDieCutWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 12:
                                rdoPBBoardGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoPBBoardNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoPBBoardWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 13:
                                rdoFlagLineGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoFlagLineNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoFlagLineWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 14:
                                rdoContactGood.Checked= (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoContactNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoContactWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 15:
                                rdoTranTimeGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoTranTimeNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoTranTimeWorse.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 16:
                                rdoTranQtyGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoTranQtyNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoTranQtyWrose.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            case 17:
                                rdoInfromGood.Checked = (bool)DataTypeParser.Parse(row["Ans1"], typeof(bool), false);
                                rdoInformNormal.Checked = (bool)DataTypeParser.Parse(row["Ans2"], typeof(bool), false);
                                rdoInformLittle.Checked = (bool)DataTypeParser.Parse(row["Ans3"], typeof(bool), false);
                                break;

                            default:
                                break;
                        }
                    }

                    txtSuggestion.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["Suggestion"], typeof(string), string.Empty);
                    txtOtherSuggestion.Text = (string)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["OtherSuggestion"], typeof(string), string.Empty);
                    cmbCustomer.SelectedValue = (int)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["CustomerID"], typeof(int), -1);
                    dtpSurveyStartDate.Value = (DateTime)DataTypeParser.Parse(dtAcidSurvey.Rows[0]["SurveyDate"], typeof(DateTime), DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Clear()
        {
            rdoCarGood.Checked = false;
            rdoCarNormal.Checked = false;
            rdoCarWorse.Checked = false;
            rdoInverterGood.Checked = false;
            rdoInverterNormal.Checked = false;
            rdoInverterWorse.Checked = false;
            rdoCheap.Checked = false;
            rdoNormal.Checked = false;
            rdoExpensive.Checked = false;
            rdoDesignGood.Checked = false;
            rdoDesignNormal.Checked = false;
            rdoDesignWrose.Checked = false;
            rdoDistributeGood.Checked = false;
            rdoDistributeNormal.Checked = false;
            rdoDistributeWorse.Checked = false;
            rdoWranGood.Checked = false;
            rdoWranNormal.Checked = false;
            rdoWranWorse.Checked = false;
            rdoResaleGood.Checked = false;
            rdoResaleNormal.Checked = false;
            rdoResaleWorse.Checked = false;
            rdoPresentGood.Checked = false;
            rdoPresentNormal.Checked = false;
            rdoPresentWorse.Checked = false;
            rdoEmpGood.Checked = false;
            rdoEmpNormal.Checked = false;
            rdoEmpWorse.Checked = false;
            rdoTVGood.Checked = false;
            rdoTVNormal.Checked = false;
            rdoTVWorse.Checked = false;
            rdoDieCutGood.Checked = false;
            rdoDieCutNormal.Checked = false;
            rdoDieCutWrose.Checked = false;
            rdoPBBoardGood.Checked = false;
            rdoPBBoardNormal.Checked = false;
            rdoPBBoardWrose.Checked = false;
            rdoFlagLineGood.Checked = false;
            rdoFlagLineNormal.Checked = false;
            rdoFlagLineWorse.Checked = false;
            rdoContactGood.Checked = false;
            rdoContactNormal.Checked = false;
            rdoContactWorse.Checked = false;
            rdoTranQtyGood.Checked = false;
            rdoTranQtyNormal.Checked = false;
            rdoTranQtyWrose.Checked = false;
            rdoTranTimeGood.Checked = false;
            rdoTranTimeNormal.Checked = false;
            rdoTranTimeWorse.Checked = false;
            txtAddress.Text = string.Empty;
            txtOtherSuggestion.Text = string.Empty;
            txtSuggestion.Text = string.Empty;
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
                QuestionFormID = (int)PTIC.Common.Enum.QuestionForm.Toyo,
                CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1),
                SurveyDate = (DateTime)DataTypeParser.Parse(dtpSurveyStartDate.Value, typeof(DateTime), DateTime.Now)
            };

            RetailerSuggestion _retailerSuggestion = new RetailerSuggestion()
            {
                Suggestion = (string)DataTypeParser.Parse(txtSuggestion.Text, typeof(string), string.Empty),
                OtherSuggestion = (string)DataTypeParser.Parse(txtOtherSuggestion.Text, typeof(string), string.Empty)
            };

            for (int i = 1; i < 18; i++)
            {
                if (i == 1)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoCarGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoCarNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoCarWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 2)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoInverterGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoInverterNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoInverterWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 3)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoCheap.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoExpensive.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 4)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoDesignGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoDesignNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoDesignWrose.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 5)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoDistributeGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoDistributeNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoDistributeWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 6)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoWranGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoWranNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoWranWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 7)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoResaleGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoResaleNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoResaleWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 8)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoPresentGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoPresentNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoPresentWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 9)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoEmpGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoEmpNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoEmpWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 10)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoTVGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoTVNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoTVWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 11)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoDieCutGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoDieCutNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoDieCutWrose.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 12)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoPBBoardGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoPBBoardNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoPBBoardWrose.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 13)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoFlagLineGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoFlagLineNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoFlagLineWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 14)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoContactGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoContactNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoContactWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 15)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoTranTimeGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoTranTimeNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoTranTimeWorse.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 16)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoTranQtyGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoTranQtyNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoTranQtyWrose.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
                else if (i == 17)
                {
                    RetailerAnswer _retailerAnswer = new RetailerAnswer();
                    _retailerAnswer.Ans1 = (bool)DataTypeParser.Parse(rdoInfromGood.Checked, typeof(bool), false);
                    _retailerAnswer.Ans2 = (bool)DataTypeParser.Parse(rdoInformNormal.Checked, typeof(bool), false);
                    _retailerAnswer.Ans3 = (bool)DataTypeParser.Parse(rdoInformLittle.Checked, typeof(bool), false);
                    _retailerAnswer.QuestionNo = i;
                    _retailerAnswerList.Add(_retailerAnswer);
                }
            }

            if (_answerForm.CustomerID != -1)
            {
                affectedRows = new RetailerAnswerBL().Add(_answerForm, _retailerSuggestion, _retailerAnswerList);
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

        private void label11_Click(object sender, EventArgs e)
        {
            ToyoTab.SelectTab("second");
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
    }
}
