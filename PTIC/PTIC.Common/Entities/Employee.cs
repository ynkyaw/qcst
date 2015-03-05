/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Employee entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Common.Entities
{
    /// <summary>
    /// Employee entity bean
    /// </summary>
    public class Employee
    {
        #region Properties
        public int ID { get; set; }
        public int EmployeeInTripPlanDetailID { get; set; }
        public int ApplicantID { get; set; }
        public string EmpName { get; set; }
        public int PostID { get; set; }
        public int DeptID { get; set; }
        public int FingerID { get; set; }
        public int DeviceID { get; set; }
        public int ConAddrID { get; set; }
        public int PerAddrID { get; set; }
        public int EmployDate { get; set; }
        public int SalaryLvlID { get; set; }
        public int WitnessID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
