using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AcidAnswer
    {
        #region Properties
        public int ID { get; set; }
        public int AnswerFormID { get; set; }
        public bool Ans1_TOYO { get; set; }
        public bool Ans1_GP { get; set; }
        public bool Ans1_XCL { get; set; }
        public bool Ans1_GR { get; set; }
        public bool Ans1_KW { get; set; }
        public bool Ans1_Other { get; set; }
        public bool Ans2_TOYO { get; set; }
        public bool Ans2_GP { get; set; }
        public bool Ans2_XCL { get; set; }
        public bool Ans2_GR { get; set; }
        public bool Ans2_KW { get; set; }
        public bool Ans2_Other { get; set; }
        public string Ans3 { get; set; }
        public int Ans4_1Lit { get; set; }
        public int Ans4_4Lit { get; set; }
        public int Ans4_7Lit { get; set; }
        public int Ans4_9Lit { get; set; }
        public int Ans4_22_5Lit { get; set; }
        public string Ans5 { get; set; }
        public string Ans6 { get; set; }
        public int Ans7_1Lit { get; set; }
        public int Ans7_4Lit { get; set; }
        public int Ans7_7Lit { get; set; }
        public int Ans7_9Lit { get; set; }
        public int Ans7_22_5Lit { get; set; }
        public string Ans8 { get; set; }
        public string Ans9 { get; set; }
        #endregion
    }
}
