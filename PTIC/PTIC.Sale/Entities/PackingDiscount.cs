/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   PackingDiscount Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class PackingDiscount
    {
        #region Entites
        public int PackingDiscountID { get; set; }
        public int ProductID { get; set; }
        public int AmtPerPack { get; set; }
        public int PackQty { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
