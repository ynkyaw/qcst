/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/16 (yyyy/MM/dd)
 * Description:
 */
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;
using System;
using PTIC.Common.DA;
namespace PTIC.Marketing.DA
{
    public class AP_ReturnDetailDA
    {
        #region SELECT
        public static DataTable SelectByDeptORDate(DateTime FromDate, DateTime ToDate, int fromDepartmentID)
        {
            string queryString = string.Empty;
            // string date = kwDate.ToString("yyyy-MM-dd");
            if (fromDepartmentID != 0 && FromDate != DateTime.MinValue && ToDate != DateTime.MinValue)
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList "
                                             + "WHERE FromDeptID = '{2}' AND CONVERT(VARCHAR(10),ReturnDate,103) between CONVERT(VARCHAR(10),CAST('{0}' As Date),103) AND CONVERT(VARCHAR(10),CAST('{1}' As Date),103)",
                    FromDate, ToDate, fromDepartmentID);
            }
            else if (fromDepartmentID != 0)
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList WHERE FromDeptID = '{0}' ", fromDepartmentID);
            }
            else if (FromDate == DateTime.MinValue && ToDate == DateTime.MinValue && fromDepartmentID == 0)
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList");
            }
            else
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList "
                                            + "WHERE CONVERT(VARCHAR(10),ReturnDate,103) between CONVERT(VARCHAR(10),CAST('{0}' As Date),103) AND CONVERT(VARCHAR(10),CAST('{1}' As Date),103)",
                   FromDate, ToDate);
            }
            return new BaseDAO().SelectByQuery(queryString);
        }

        public static DataTable SelectByVenORDate(DateTime FromDate, DateTime ToDate, int fromVenID)
        {
            string queryString = string.Empty;
            // string date = kwDate.ToString("yyyy-MM-dd");
            if (fromVenID != 0 && FromDate != DateTime.MinValue && ToDate != DateTime.MinValue)
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList "
                                             + "WHERE FromVenID = '{2}' AND CONVERT(VARCHAR(10),ReturnDate,103) between CONVERT(VARCHAR(10),CAST('{0}' As Date),103) AND CONVERT(VARCHAR(10),CAST('{1}' As Date),103)",
                    FromDate, ToDate, fromVenID);
            }
            else if (fromVenID != 0)
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList WHERE FromVenID = '{0}' ", fromVenID);
            }
            else if (FromDate == DateTime.MinValue && ToDate == DateTime.MinValue && fromVenID == 0)
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList");
            }
            else
            {
                queryString = string.Format("SELECT * FROM uv_AP_ReturnList "
                                            + "WHERE CONVERT(VARCHAR(10),ReturnDate,103) between CONVERT(VARCHAR(10),CAST('{0}' As Date),103) AND CONVERT(VARCHAR(10),CAST('{1}' As Date),103)",
                   FromDate, ToDate);
            }
            return new BaseDAO().SelectByQuery(queryString);
        }
        #endregion


        #region SELECT
        public static DataTable SelectBy(DateTime kwDate, int fromDepartmentID)
        {
            string queryString = string.Empty;
            string date = kwDate.ToString("yyyy-MM-dd");
            //if (fromDepartmentID.HasValue)
            //{
            //    queryString = string.Format("SELECT * FROM uv_AP_ReturnDetail WHERE CAST(ReturnDate AS DATE) = '{0}' AND FromDeptID = {1}",
            //        date, fromDepartmentID);
            //}
            //else
            //{
            //    queryString = string.Format("SELECT * FROM uv_AP_ReturnDetail WHERE CAST(ReturnDate AS DATE) = '{0}'", date);
            //}
            queryString = string.Format("SELECT * FROM uv_AP_ReturnDetail WHERE CAST(ReturnDate AS DATE) = '{0}' AND FromDeptID = {1}",
                    date, fromDepartmentID);
            return new BaseDAO().SelectByQuery(queryString);
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public static int DeleteByAP_ReturnDetailID(int AP_ReturnDetailID, AP_Return apReturn, SqlConnection conn)
        {
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_AP_ReturnDetailDeleteByID";

                cmd.Parameters.AddWithValue("@p_AP_ReturnDetailID", AP_ReturnDetailID);
                cmd.Parameters.AddWithValue("@p_FromDeptID", apReturn.FromDeptID.HasValue ? apReturn.FromDeptID : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_FromVenID", apReturn.FromVenID.HasValue ? apReturn.FromVenID : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_ToDeptID", apReturn.ToDeptID.HasValue ? apReturn.ToDeptID : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@p_ToVenID", apReturn.ToVenID.HasValue ? apReturn.ToVenID : (object)DBNull.Value);
                                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion
    }
}
