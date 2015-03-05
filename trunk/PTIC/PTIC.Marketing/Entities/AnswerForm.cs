using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AnswerForm
    {
        #region Properties
        public int ID { get; set; }
        public int QuestionFormID { get; set; }
        public DateTime SurveyDate { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
