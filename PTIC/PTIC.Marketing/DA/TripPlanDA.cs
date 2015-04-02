
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: SampleString
 * Description: Trip Plan
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace  PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class TripPlanDA
    {

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectAll(bool isSale,SqlConnection conn)
        {
            DataSet dataSet = null;
            string tableName = "TripPlanTable";
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanSelectAll";


                command.Parameters.AddWithValue("@p_IsSale", isSale);
                command.Parameters["@p_IsSale"].Direction = ParameterDirection.Input;


                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, tableName);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dataSet.Tables[tableName];
        }

        public static DataTable SelectByOrderID(int orderID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripPlanTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanSelectByID";

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
        
        public static DataTable SelectBy(DateTime fromDate,DateTime toDate, bool isSale)
        {
            DataTable dt = null;
            string tableName = "TripPlanTable";
            SqlConnection conn = null;
            try
            {
                dt = new DataTable(tableName);
                conn = DBManager.GetInstance().GetDbConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanSelectBy";

                command.Parameters.AddWithValue("@p_fromDate", fromDate);
                command.Parameters["@p_fromDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_toDate", toDate);
                command.Parameters["@p_toDate"].Direction = ParameterDirection.Input;

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

        public static DataTable GetPreviousTrip(bool isSale,int tripId,int currentTripDtl) 
        {
            DataTable dt = null;
            string tableName = "TripPlanTable";
            SqlConnection conn = null;
            try
            {
                dt = new DataTable(tableName);
                conn = DBManager.GetInstance().GetDbConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                //command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "select top 1 tr.* from TripRecord tr Inner join TripPlanDetail td on tr.TripPlanDetailID=td.ID Inner Join TripPlan tp on tp.ID =td.TripPlanID where td.TripID=@p_TripId and td.ID<>@p_CurrentId and tp.IsSale=@p_isSale order by td.ID desc";

                command.Parameters.AddWithValue("@p_TripId", tripId);
                

                command.Parameters.AddWithValue("@p_CurrentId", currentTripDtl);
                

                command.Parameters.AddWithValue("@p_isSale", isSale);
                
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
            string tableName = "TripPlanTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlanSelectByNo";

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
        public static int Insert(TripPlan tripPlan, List<TripPlanDetail> tripPlanDetails,out int insertedId)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int idInserted = 0;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new order
                cmd.CommandText = "usp_TripPlanInsert";

                cmd.Parameters.AddWithValue("@p_TripPlanNo", tripPlan.TripPlanNo);
                cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", tripPlan.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanName", tripPlan.TripPlanName);
                cmd.Parameters["@p_TripPlanName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", tripPlan.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", tripPlan.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsSale", tripPlan.IsSale);
                cmd.Parameters["@p_IsSale"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                
                int.TryParse(insertedIDObj+string.Empty,out idInserted);
                
                insertedId = idInserted;

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedOrderID = (int)insertedIDObj;
                // clear parameters of usp_TripPlanInsert
                tripPlan.ID = insertedOrderID;
                cmd.Parameters.Clear();
                 
                // insert new order details
                cmd.CommandText = "usp_TripPlanDetailInsert";
                foreach (TripPlanDetail tripPlanDetail in tripPlanDetails)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlanID", insertedOrderID);
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

                    cmd.Parameters.AddWithValue("@p_PersonCount", tripPlanDetail.PersonCount);
                    cmd.Parameters["@p_PersonCount"].Direction = ParameterDirection.Input;

                   cmd.Parameters.AddWithValue("@p_Remark", tripPlanDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TripPlanDetailInsert
                    cmd.Parameters.Clear();
                }
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            insertedId = idInserted;
            return affectedRows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int Insert(TripPlan newTripPlan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanInsert";

                //cmd.Parameters.AddWithValue("@p_OrderID", newTripPlan.);
                //cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ProductID", newTripPlan.ProductID);
                //cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_WSPrice", newTripPlan.WSPrice);
                //cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_RSPrice", newTripPlan.RSPrice);
                //cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Qty", newTripPlan.Qty);
                //cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Amount", newTripPlan.Amount);
                //cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Remark", newTripPlan.Remark);
                //cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

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
        /// <returns></returns>
        public static int UpdateByTripPlanID(TripPlan mdTripPlan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanUpdateByTripPlanID";
 
                cmd.Parameters.AddWithValue("@p_TripPlanId", mdTripPlan.ID);
                cmd.Parameters["@p_TripPlanId"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanNo", mdTripPlan.TripPlanNo);
                cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", mdTripPlan.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanName", mdTripPlan.TripPlanName);
                cmd.Parameters["@p_TripPlanName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", mdTripPlan.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", mdTripPlan.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsSale", mdTripPlan.IsSale);
                cmd.Parameters["@p_IsSale"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        public static int Update(TripPlan tripPlan, List<TripPlanDetail> mdTripPlanDetails)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // update an existing trip plan
                cmd.CommandText = "usp_TripPlanUpdateByTripPlanID";

                cmd.Parameters.AddWithValue("@p_TripPlanId", tripPlan.ID);
                cmd.Parameters["@p_TripPlanId"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanNo", tripPlan.TripPlanNo);
                cmd.Parameters["@p_TripPlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", tripPlan.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPlanName", tripPlan.TripPlanName);
                cmd.Parameters["@p_TripPlanName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", tripPlan.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", tripPlan.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsSale", tripPlan.IsSale);
                cmd.Parameters["@p_IsSale"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                // clear parameters of usp_OrderUpdateByOrderID
                cmd.Parameters.Clear();
                // update an existing trip plan details
                cmd.CommandText = "usp_TripPlanDetailInsert";
                foreach (TripPlanDetail tripPlanDetail in mdTripPlanDetails)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlanID", tripPlan.ID);
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

                    cmd.Parameters.AddWithValue("@p_PersonCount", tripPlanDetail.PersonCount);
                    cmd.Parameters["@p_PersonCount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", tripPlanDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailUpdateByOrderDetailID
                    cmd.Parameters.Clear();
                }
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }

        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        public static int DeleteByTripPlanID(int TripPlanID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlanDeleteByTripPlanID";

                cmd.Parameters.AddWithValue("@p_TripPlanID", TripPlanID);
                cmd.Parameters["@p_TripPlanID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 547) // constraint violation
                    throw new Exception("ခရီးစဉ် Plan ရှိပြီးဖြစ်၍ ဖျက်၍မရနိုင်ပါ။");
                else
                    throw sqle;
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        public static DataTable GetTripPlanTargetedBrand_Amount_By_TripDtlId(string id)
        {
            DataTable result = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();
                cmd.CommandText = string.Format("SELECT dbo.TripPlanTarget.TripPlanDetailID, dbo.Brand.BrandName, dbo.TripPlanTarget.TargetAmount, dbo.TripPlanTarget.IsDeleted FROM dbo.TripPlanTarget INNER JOIN dbo.Brand ON dbo.TripPlanTarget.BrandID = dbo.Brand.ID WHERE dbo.TripPlanTarget.TripPlanDetailID={0}",id);
                new SqlDataAdapter(cmd).Fill(result);
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 547) // constraint violation
                    throw new Exception(string.Format("Error in retrieving TripPlanTarget for {0}",id));
                else
                    throw sqle;
            }
            return result;
        }
        #endregion

    }
}

