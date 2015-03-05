/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   CompetitorActivity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class CompetitorActivity
    {
        #region Entities

        public int CompetitorActivityID { get; set; }
        public String A_P_Remark { get; set; }
        public String MarketPromoRemark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}
