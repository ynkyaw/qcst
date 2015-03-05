/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/03/03 (yyyy/mm/dd)
 * Description: 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class Complaint
    {
        #region Properties
        public int ComplaintID { get; set; }
        public int CusID { get; set; }
        public int BrandID { get; set; }
        public int EmpID { get; set; }
        public DateTime TranDate { get; set; }
        public DateTime ComplaintDate { get; set; }
        public string ComplaintPerson { get; set; }
        public string Post { get; set; }
        public string Description { get; set; }
        public string Request { get; set; }
        public string OtherRequirement { get; set; }
        public string CheckedPlaces { get; set; }
        public bool IsService { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
