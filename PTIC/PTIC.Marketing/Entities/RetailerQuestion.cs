using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class RetailerQuestion
    {
        #region Properties
        public int ID { get; set; }
        public int QuestionFormID { get; set; }
        public int QuestionNo { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
