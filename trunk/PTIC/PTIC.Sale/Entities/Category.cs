/* Author   :   Aung Ko Ko
    Date      :   13 Feb 2014
    Description :   Category Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Category
    {
        #region
        public int ID { get; set; }
        public int BrandID { get; set; }
        public String CategoryName { get; set; }
        public String Remark { get; set; }
        #endregion
    }
}
