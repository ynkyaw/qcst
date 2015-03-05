
using System.Data;
using System;
using PTIC.Sale.Entities;
using PTIC.Marketing.DA;
namespace PTIC.Marketing.BL
{
    public class SurveyAnswerBL
    {
        #region SELECT
        public DataTable GetSurveyResultBy(
            DateTime startDate, DateTime endDate, PTIC.Common.Enum.QuestionForm questionForm,
            Customer customer, Address address)
        {
            return SurveyAnswerDA.SelectSurveyResultBy(startDate, endDate, questionForm, customer, address);
        }
        #endregion
    }
}
