/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   PriceChange Entities
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class PriceChange
    {
        #region Entities
        public int PriceChangeID { get; set; }
        public int ProductID { get; set; }
        public DateTime TranDate { get; set; }
        public String WholeSaleNo { get; set; }
        public decimal WSPrice { get; set; }
        public String RetailNo { get; set; }
        public decimal RSPrice { get; set; }
        public decimal AcidPrice { get; set; }

        public decimal WSPriceWithAcid { get; set; }
        public decimal RSPriceWithAcid { get; set; }

        public DateTime ChangeFromDate { get; set; }
        public DateTime ChangeToDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
