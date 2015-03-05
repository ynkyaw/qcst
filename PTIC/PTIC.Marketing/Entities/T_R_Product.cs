
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2014
 * Description: About T_R_Product
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// T_R_Product detail entity
    /// </summary>
    public class T_R_Product
    {
        #region Properties
        public int ID { get; set; }
        public int TripReqID { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public float Weight { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
