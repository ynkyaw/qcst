/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   Cash Discount Entity
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class CashDiscount
    {
        #region Entities
        public int CashDiscountID { get; set; }
        public DateTime Date { get; set; }
        public float CashCommPercent { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
