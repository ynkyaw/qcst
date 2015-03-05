/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */

using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System;
using System.Data;
namespace PTIC.Marketing.BL
{
    public class AP_ReturnDetailBL
    {
        #region SELECT BY DateTime OR Department
        public DataTable GetByDateORDept(DateTime FromDate, DateTime ToDate, int DeptID)
        {
            return AP_ReturnDetailDA.SelectByDeptORDate(FromDate, ToDate, DeptID);
        }

        public DataTable GetByDateORVen(DateTime FromDate, DateTime ToDate, int VenID)
        {
            return AP_ReturnDetailDA.SelectByVenORDate(FromDate, ToDate, VenID);
        }
        #endregion

        #region SELECT
        /// <summary>
        /// Get AP return details by specific date and department.
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="returnedDepartmentID">Department that A P materials are returned.</param>
        /// <returns></returns>
        public DataTable GetBy(DateTime date, int returnedDepartmentID)
        {
            return AP_ReturnDetailDA.SelectBy(date, returnedDepartmentID);
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public int DeleteByID(int AP_ReturnDetailID, AP_Return apReturn, SqlConnection conn)
        {
            return AP_ReturnDetailDA.DeleteByAP_ReturnDetailID(AP_ReturnDetailID, apReturn, conn);
        }
        #endregion
    }
}
