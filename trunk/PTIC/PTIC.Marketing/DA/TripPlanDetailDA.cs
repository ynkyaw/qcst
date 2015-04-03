
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, Aung Ko Ko <>
 * Create date: 1 March 2014
 * Description: Trip Plan Detail
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;
using PTIC.Common.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class TripPlanDetailDA
    {

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            string tableName = "TripPlanDetailTable";
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanDetailSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, tableName);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dataSet.Tables[tableName];
        }

        public static DataTable SelectBy(string tripPlanNo, int tripPlanID)
        {
            DataTable dt = null;
            string tableName = "TripPlanDetail";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT ID FROM TripPlanDetail WHERE IsDeleted = 0 AND TripPlanNo = @p_TripPlanNo AND TripPlanID = @p_TripPlanID";
                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("@p_TripPlanNo", tripPlanNo);
                command.Parameters.AddWithValue("@p_TripPlanID", tripPlanID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        public static DataTable SelectByDateRange(DateTime start,DateTime end,bool isSale)
        {
            DataTable dt = null;
            string tableName = "TripPlanDetailTable";
            SqlConnection conn = null;
            try
            {
                dt = new DataTable(tableName);
                conn = DBManager.GetInstance().GetDbConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanDetailSelectBytDateRange";

                command.Parameters.AddWithValue("@p_StartDate", start);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_End", end);
                command.Parameters["@p_End"].Direction = ParameterDirection.Input;

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

        public static DataTable SelectBy(DateTime startDate, DateTime endDate, int vehicleID,int dtlId)
        {
            DataTable table = null;
            string tableName = "MarketingDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT ID FROM TripPlanDetail WHERE IsDeleted = 0 AND VenID = @p_VenID AND ID<>@p_Id"
                                                        + " AND ((@p_FromDate BETWEEN FromDate AND ToDate)"
                                                        + " OR (@p_ToDate BETWEEN FromDate AND ToDate))";

                command.Parameters.AddWithValue("@p_VenID", vehicleID);
                command.Parameters.AddWithValue("@p_FromDate", startDate);
                command.Parameters.AddWithValue("@p_ToDate", endDate);
                command.Parameters.AddWithValue("@p_Id",dtlId);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectBy(DateTime startDate, DateTime endDate, Employee manager)
        {
            DataTable table = null;
            string tableName = "MarketingDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT ID FROM TripPlanDetail WHERE IsDeleted = 0 AND ManagerID = @p_ManagerID"
                                                        + " AND ((@p_FromDate BETWEEN FromDate AND ToDate)"
                                                        + " OR (@p_ToDate BETWEEN FromDate AND ToDate))";

                command.Parameters.AddWithValue("@p_ManagerID", manager.ID);
                command.Parameters.AddWithValue("@p_FromDate", startDate);
                command.Parameters.AddWithValue("@p_ToDate", endDate);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectByTripPlanID(int tripPlanID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripPlanDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanDetailSelectBytripPlanID";

                command.Parameters.AddWithValue("@p_tripPlanID", tripPlanID);
                command.Parameters["@p_tripPlanID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        public static DataTable GetPrevTripPlan(int tripPlanDetailID, bool isSale, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripPlanDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SelectPrevTripPlan";


                command.Parameters.AddWithValue("@p_tripPlanDetailID", tripPlanDetailID);
                command.Parameters["@p_tripPlanDetailID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_isSale", isSale);
                command.Parameters["@p_isSale"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        public static DataTable GetPrevTripPlanByTripPlanDetailID(int tripPlanDetailID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripPlanDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SelectPrevTripPlanByTripPlanDetailID";

                command.Parameters.AddWithValue("@p_tripPlanDetailID", tripPlanDetailID);
                command.Parameters["@p_tripPlanDetailID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }


        public static DataTable GetByTripPlanDetailID(int tripPlanDetailID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripPlanDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanDetailSelectBytripPlanDetailID";

                command.Parameters.AddWithValue("@p_tripPlanDetailID", tripPlanDetailID);
                command.Parameters["@p_tripPlanDetailID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        public static DataTable GetAllTripPlanDetails()
        {

            DataTable dt = null;
            string tableName = "TripPlanDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = "SELECT * FROM TripPlanDetail";
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
            string tableName = "TripPlanDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanDetailSelectByNo";

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
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int Insert(TripPlanDetail newTripPlanDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanDetailInsert";

                //cmd.Parameters.AddWithValue("@p_OrderID", newTripPlanDetail.OrderID);
                //cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ProductID", newTripPlanDetail.ProductID);
                //cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_WSPrice", newTripPlanDetail.WSPrice);
                //cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_RSPrice", newTripPlanDetail.RSPrice);
                //cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Qty", newTripPlanDetail.Qty);
                //cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Amount", newTripPlanDetail.Amount);
                //cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newTripPlanDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int UpdateByTripPlanDetailID(TripPlanDetail mdTripPlanDetail, List<Employee> EmployeesList, SqlConnection conn)
        {            
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            //bool flag = false;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_TripPlanDetailUpdateByTripPlanDetailID";

                cmd.Parameters.AddWithValue("@p_TripPlanDetailID", mdTripPlanDetail.ID);
                cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanID", mdTripPlanDetail.TripPlanID);
                cmd.Parameters["@p_TripPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ManagerID", mdTripPlanDetail.ManagerID);
                cmd.Parameters["@p_ManagerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", mdTripPlanDetail.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", mdTripPlanDetail.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", mdTripPlanDetail.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanNo", mdTripPlanDetail.TripPlanNo);
                cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TripName", tripPlanDetail.TripName);
                //cmd.Parameters["@p_TripName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripID", mdTripPlanDetail.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", mdTripPlanDetail.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", mdTripPlanDetail.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", mdTripPlanDetail.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PrevTripName", mdTripPlanDetail.PrevTripName);
                cmd.Parameters["@p_PrevTripName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Accessories", mdTripPlanDetail.Accessories);
                cmd.Parameters["@p_Accessories"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Rent", mdTripPlanDetail.Rent);
                cmd.Parameters["@p_Rent"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Food", mdTripPlanDetail.Food);
                cmd.Parameters["@p_Food"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Transport", mdTripPlanDetail.Transport);
                cmd.Parameters["@p_Transport"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Communication", mdTripPlanDetail.Communication);
                cmd.Parameters["@p_Communication"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherExp", mdTripPlanDetail.OtherExp);
                cmd.Parameters["@p_OtherExp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remittance", mdTripPlanDetail.Remittance);
                cmd.Parameters["@p_Remittance"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleType", mdTripPlanDetail.SaleType);
                cmd.Parameters["@p_SaleType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleType1", mdTripPlanDetail.SaleType1);
                cmd.Parameters["@p_SaleType1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleType2", mdTripPlanDetail.SaleType2);
                cmd.Parameters["@p_SaleType2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PersonCount", mdTripPlanDetail.PersonCount);
                cmd.Parameters["@p_PersonCount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", mdTripPlanDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@p_coo", mdTripPlanDetail.COO_remark);
                cmd.Parameters["@p_coo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_mm", mdTripPlanDetail.MM_remark);
                cmd.Parameters["@p_mm"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_sm", mdTripPlanDetail.SM_remark);
                cmd.Parameters["@p_sm"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@p_TripPlanPurpose", mdTripPlanDetail.TripPlanPurpose);
                cmd.Parameters["@p_TripPlanPurpose"].Direction = ParameterDirection.Input;


                affectedrow = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //if (EmployeesList == null)
                //{
                //    flag = true;
                //}
                if (EmployeesList !=null)
                {
                    if (EmployeesList.Count > 0)
                    {
                        cmd.CommandText = "usp_EmployeesInTripPlanDetail";
                        foreach (Employee EmployeeRow in EmployeesList)
                        {
                            cmd.Parameters.AddWithValue("@p_TripPlanDetailID", mdTripPlanDetail.ID);
                            cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

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
                    return affectedrow;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }

            return affectedrow;
        }

        public static int Update(List<TripPlanDetail> tripPlanDetails)
        {
            try
            {
                int affectedrow = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanDetailUpdateByTripPlanDetailID";

                foreach (TripPlanDetail tripPlanDetail in tripPlanDetails)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlanDetailID", tripPlanDetail.ID);
                    cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TripPlanID", tripPlanDetail.TripPlanID);
                    cmd.Parameters["@p_TripPlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ManagerID", tripPlanDetail.ManagerID);
                    cmd.Parameters["@p_ManagerID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalesPersonID", tripPlanDetail.SalesPersonID);
                    cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TransportTypeID", tripPlanDetail.TransportTypeID);
                    cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_VenID", tripPlanDetail.VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TripPlanNo", tripPlanDetail.TripPlanNo);
                    cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_TripName", tripPlanDetail.TripName);
                    //cmd.Parameters["@p_TripName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TripID", tripPlanDetail.TripID);
                    cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TranDate", tripPlanDetail.TranDate);
                    cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromDate", tripPlanDetail.FromDate);
                    cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToDate", tripPlanDetail.ToDate);
                    cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PrevTripName", tripPlanDetail.PrevTripName);
                    cmd.Parameters["@p_PrevTripName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Accessories", tripPlanDetail.Accessories);
                    cmd.Parameters["@p_Accessories"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Rent", tripPlanDetail.Rent);
                    cmd.Parameters["@p_Rent"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Food", tripPlanDetail.Food);
                    cmd.Parameters["@p_Food"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Transport", tripPlanDetail.Transport);
                    cmd.Parameters["@p_Transport"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Communication", tripPlanDetail.Communication);
                    cmd.Parameters["@p_Communication"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OtherExp", tripPlanDetail.OtherExp);
                    cmd.Parameters["@p_OtherExp"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remittance", tripPlanDetail.Remittance);
                    cmd.Parameters["@p_Remittance"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SaleType", tripPlanDetail.SaleType);
                    cmd.Parameters["@p_SaleType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SaleType1", false);
                    cmd.Parameters["@p_SaleType1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SaleType2", false);
                    cmd.Parameters["@p_SaleType2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PersonCount", tripPlanDetail.PersonCount);
                    cmd.Parameters["@p_PersonCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", tripPlanDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailUpdateByOrderDetailID
                    cmd.Parameters.Clear();
                }

                return affectedrow;
            }

            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #endregion

        #region DELETE


        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByTripPlanDetailID(int TripPlanDetailID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanDetailDeleteByTripPlanDetailID";

                cmd.Parameters.AddWithValue("@p_TripPlanDetailID", TripPlanDetailID);
                cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 547) // Constraint violation
                    throw new Exception("Trip Target / အသေးစိတ်အစီအစဉ် ဖြည့်သွင်းပြီး ဖြစ်ပါ၍ ဖျက်၍မရနိုင်ပါ။");
                else
                    throw sqle;
            }
        }

        public static int DeleteByTripPlanDetailID(List<TripPlanDetail> tripPlanDetail)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_tripPlanDetailDeleteByTripPlanDetailID";

                foreach (TripPlanDetail newTripPlanDetails in tripPlanDetail)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlanDetailID", newTripPlanDetails.ID);
                    cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                }
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            return affectedRows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByTripPlanID(int TripPlanID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanDetailDeleteByTripPlanID";

                cmd.Parameters.AddWithValue("@p_TripPlanID", TripPlanID);
                cmd.Parameters["@p_TripPlanID"].Direction = ParameterDirection.Input;

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

