using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using PTIC.Sale.Entities;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class RetailerAnswerBL
    {
        #region SELECT
        public DataTable AnswerSearchBy(int CustomerID, int QuestionFormID, DateTime SurveyDate)
        {
            return RetailerAnswerDA.AnswerSearchBy(CustomerID, QuestionFormID, SurveyDate);
        }
        #endregion

        #region INSERT
        public int Add(AnswerForm newAnswerForm, RetailerSuggestion newRetailerSuggestion, List<RetailerAnswer> newRetailerAnswers)
        {

            return RetailerAnswerDA.Insert(newAnswerForm, newRetailerSuggestion, newRetailerAnswers);
        }
        #endregion
    }
}
