/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   SaleCommission Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SaleCommission
    {
        #region Entitites
        public int SaleCommissionID { get; set; }
        public float SaleCommPercent { get; set; }
        public decimal CommAmt1 { get; set; }
        public decimal CommAmt2 { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
