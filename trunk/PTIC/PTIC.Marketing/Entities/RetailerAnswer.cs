﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class RetailerAnswer
    {
        #region Properties
        public int ID { get; set; }
        public int AnswerFormID { get; set; }
        public bool Ans1 { get; set; }
        public bool Ans2 { get; set; }
        public bool Ans3 { get; set; }
        public int QuestionNo { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
