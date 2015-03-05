/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   SubCategory Entity
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SubCategory
    {
        #region
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public String SubCategoryName { get; set; }
        public String Remark { get; set; }
        #endregion
    }
}
