using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class RetailerSuggestion
    {
        #region Properties
        public int ID { get; set; }
        public int AnswerFormID { get; set; }
        public string Suggestion { get; set; }
        public string OtherSuggestion { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
