
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2014
 * Description: Abou TripPlan_AP
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// TripPlan_AP detail entity
    /// </summary>
    public class TripPlan_AP
    {
        #region Properties
        public int ID { get; set; }
        public int TripPlanDetailID { get; set; }
        public int A_PID { get; set; }
        public int Qty { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
