/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   Competitor
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    class Competitor
    {
        #region Entities

        public int CompetitorID { get; set; }
        public int CusID { get; set; }
        public int BrandID { get; set; }
        public DateTime TranDate { get; set; }
        public String CQuality { get; set; }
        public String CLike { get; set; }
        public String Description { get; set; }
        public float SalesPercent { get; set; }
        public String Given_A_P { get; set; }
        public String CusOpinion { get; set; }
        public String Like_Dislike { get; set; }
        public String CurrentActivity { get; set; }
        public String Detail { get; set; }
        //
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}
