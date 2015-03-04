/*
 * Author:  AUNG KO KO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/02/22 (yyyy/mm/dd)
 * Description: Address entity bean class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class CusType
    {
        public int CusTypeID { get; set; }
        public String CusTypeName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }  
    }
}
