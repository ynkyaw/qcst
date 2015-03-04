using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class AcidAnswerBL
    {
        /// <summary>
        /// AcidAnswer Form Insert
        /// </summary>
        /// <param name="newAnswerForm"></param>
        /// <param name="newAcidAnswer"></param>
        /// <returns></returns>
        #region INSERT
        public int Add(AnswerForm newAnswerForm, AcidAnswer newAcidAnswer)
        {
            return AcidAnswerDA.Insert(newAnswerForm, newAcidAnswer);
        }
        #endregion

        #region SELECT
        public DataTable SearchByDateRage_SurveyType(DateTime startdate, DateTime enddate, int questionFormID)
        {
            return AcidAnswerDA.SearchByDateRange_SurveyType(startdate, enddate, questionFormID);
        }

        public DataTable Search(DateTime startdate, DateTime enddate, int questionFormID, int? RouteID, int? TownshipID, int? TripID, int? TownID)
        {
            return AcidAnswerDA.SearchBy(startdate, enddate, questionFormID, RouteID, TownshipID, TripID, TownID);
        }

        public DataTable AcidAnswerSearchBy(int CustomerID, int QuestionFormID, DateTime SurveyDate)
        {
            return AcidAnswerDA.AcidAnswerSearchBy(CustomerID, QuestionFormID, SurveyDate);
        }
        #endregion
    }
}
