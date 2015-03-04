
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 2 March 2014
 * Description: About Trip Request
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;
using PTIC.Common.Entities;
using PTIC.Common.DA;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class TripRequestDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM TripRequest WHERE [IsDeleted]=0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

       


        public static DataTable SelectByOrderID(int orderID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripRequestTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripRequestSelectByID";

                command.Parameters.AddWithValue("@p_OrderID", orderID);
                command.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }


        public static DataTable SelectBy(DateTime fromDate, DateTime toDate,bool isSale, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripRequestTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripRequestSelectBy";

                command.Parameters.AddWithValue("@p_fromDate", fromDate);
                command.Parameters["@p_fromDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_toDate", toDate);
                command.Parameters["@p_toDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_IsSale", isSale);
                command.Parameters["@p_IsSale"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }


        public static DataTable SelectByNo(string No, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripRequestTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripRequestSelectByNo";

                command.Parameters.AddWithValue("@p_No", No);
                command.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }


        public static DataTable GetByTripRequestID(int tripRequestID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripRequestTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripRequestSelectBytripRequestID";

                command.Parameters.AddWithValue("@p_tripRequestID", tripRequestID);
                command.Parameters["@p_tripRequestID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int Insert(TripRequest newTripRequest, List<Employee> EmployeesList, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            int insertedTripRequestID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_TripRequestInsert";

                cmd.Parameters.AddWithValue("@p_TripPlanDetailID", newTripRequest.TripPlanDetailID);
                cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RoutePlanID", newTripRequest.RoutePlanID);
                cmd.Parameters["@p_RoutePlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", newTripRequest.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", newTripRequest.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductRequestIssueID", newTripRequest.ProductRequestIssueID);
                cmd.Parameters["@p_ProductRequestIssueID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AP_RequestID", newTripRequest.AP_RequestID);
                cmd.Parameters["@p_AP_RequestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ManagerID", newTripRequest.ManagerID);
                cmd.Parameters["@p_ManagerID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_SalesPersonID", newTripRequest.SalesPersonID);
                //cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_SupporterID", newTripRequest.SupporterID);
                //cmd.Parameters["@p_SupporterID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanNo", newTripRequest.TripPlanNo);
                cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReqDate", newTripRequest.ReqDate);
                cmd.Parameters["@p_ReqDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", newTripRequest.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", newTripRequest.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PrevTripName", newTripRequest.PrevTripName);
                cmd.Parameters["@p_PrevTripName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsSaleDevice", newTripRequest.IsSaleDevice);
                cmd.Parameters["@p_IsSaleDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsVoucher", newTripRequest.IsVocher);
                cmd.Parameters["@p_IsVoucher"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PersonCount", newTripRequest.PersonCount);
                cmd.Parameters["@p_PersonCount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesTargetAmt", newTripRequest.SalesTargetAmt);
                cmd.Parameters["@p_SalesTargetAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsVen", newTripRequest.IsVen);
                cmd.Parameters["@p_IsVen"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsAcc", newTripRequest.IsAcc);
                cmd.Parameters["@p_IsAcc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsFac", newTripRequest.IsFac);
                cmd.Parameters["@p_IsFac"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsAdm", newTripRequest.IsAdm);
                cmd.Parameters["@p_IsAdm"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsTab", newTripRequest.IsTab);
                cmd.Parameters["@p_IsTab"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsBoard", newTripRequest.IsBoard);
                cmd.Parameters["@p_IsBoard"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newTripRequest.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark_co", newTripRequest.COO);
                cmd.Parameters["@p_remark_co"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark_mm", newTripRequest.MM);
                cmd.Parameters["@p_remark_mm"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark_sm", newTripRequest.SM);
                cmd.Parameters["@p_remark_sm"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_isSale", newTripRequest.isSale);
                cmd.Parameters["@p_isSale"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedTripRequestID = (int)insertedIDObj;
                // clear parameters of usp_FGRequstInsert
                cmd.Parameters.Clear();
                // insert new order details

                if (EmployeesList != null)
                {
                    if (EmployeesList.Count > 0)
                    {
                        cmd.CommandText = "usp_EmployeesInTripRequest";
                        foreach (Employee EmployeeRow in EmployeesList)
                        {
                            cmd.Parameters.AddWithValue("@p_TripRequestID", insertedTripRequestID);
                            cmd.Parameters["@p_TripRequestID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_EmpID", EmployeeRow.ID);
                            cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                            affectedRows += cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return insertedTripRequestID = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }

            return insertedTripRequestID;
        }
        #endregion

        #region UPDATE APRequestID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int UpdateAPRequestByTripRequestID(TripRequest mdTripRequest, List<Employee> EmployeesList, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_APRequestIDUpdateByTripRequestID";

                cmd.Parameters.AddWithValue("@p_TripRequestID", mdTripRequest.ID);
                cmd.Parameters["@p_TripRequestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@AP_RequestID", mdTripRequest.AP_RequestID);
                cmd.Parameters["@AP_RequestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductRequestIssueID", mdTripRequest.ProductRequestIssueID);
                cmd.Parameters["@p_ProductRequestIssueID"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();                
                
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }

            return affectedrow;
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int UpdateByTripRequestID(TripRequest mdTripRequest, List<Employee> EmployeesList, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_TripRequestUpdateByTripRequestID";


                cmd.Parameters.AddWithValue("@p_TripRequestID", mdTripRequest.ID);
                cmd.Parameters["@p_TripRequestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanID", mdTripRequest.TripPlanDetailID);
                cmd.Parameters["@p_TripPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RoutePlanID", mdTripRequest.RoutePlanID);
                cmd.Parameters["@p_RoutePlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", mdTripRequest.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", mdTripRequest.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ManagerID", mdTripRequest.ManagerID);
                cmd.Parameters["@p_ManagerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", mdTripRequest.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SupporterID", mdTripRequest.SupporterID);
                cmd.Parameters["@p_SupporterID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanNo", mdTripRequest.TripPlanNo);
                cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@p_ReqDate", mdTripRequest.ReqDate);
                cmd.Parameters["@p_ReqDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", mdTripRequest.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", mdTripRequest.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PrevTripName", mdTripRequest.PrevTripName);
                cmd.Parameters["@p_PrevTripName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsSaleDevice", mdTripRequest.IsSaleDevice);
                cmd.Parameters["@p_IsSaleDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsVoucher", mdTripRequest.IsVocher);
                cmd.Parameters["@p_IsVoucher"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PersonCount", mdTripRequest.PersonCount);
                cmd.Parameters["@p_PersonCount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesTargetAmt", mdTripRequest.SalesTargetAmt);
                cmd.Parameters["@p_SalesTargetAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsVen", mdTripRequest.IsVen);
                cmd.Parameters["@p_IsVen"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsAcc", mdTripRequest.IsAcc);
                cmd.Parameters["@p_IsAcc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsFac", mdTripRequest.IsFac);
                cmd.Parameters["@p_IsFac"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsAdm", mdTripRequest.IsAdm);
                cmd.Parameters["@p_IsAdm"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@p_IsTab", mdTripRequest.IsTab);
                cmd.Parameters["@p_IsTab"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", mdTripRequest.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark_co", mdTripRequest.COO);
                cmd.Parameters["@p_remark_co"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark_mm", mdTripRequest.MM);
                cmd.Parameters["@p_remark_mm"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark_sm", mdTripRequest.SM);
                cmd.Parameters["@p_remark_sm"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_isSale", mdTripRequest.isSale);
                cmd.Parameters["@p_isSale"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (EmployeesList != null)
                {
                    if (EmployeesList.Count > 0)
                    {
                        cmd.CommandText = "usp_EmployeesInTripRequest";
                        foreach (Employee EmployeeRow in EmployeesList)
                        {
                            cmd.Parameters.AddWithValue("@p_TripRequestID", mdTripRequest.ID);
                            cmd.Parameters["@p_TripRequestID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_EmpID", EmployeeRow.ID);
                            cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                            affectedrow += cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                    }
                }
                transaction.Commit();

            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedrow=0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }

            return affectedrow;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByTripRequestID(int TripRequestID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripRequestDeleteByTripRequestID";

                cmd.Parameters.AddWithValue("@p_TripRequestID", TripRequestID);
                cmd.Parameters["@p_TripRequestID"].Direction = ParameterDirection.Input;

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

