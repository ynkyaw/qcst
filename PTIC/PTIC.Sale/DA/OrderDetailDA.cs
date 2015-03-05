/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Order detail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderDetailDA
    {

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            string tableName = "OrderDetailTable";
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderDetailSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, tableName);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dataSet.Tables[tableName];
        }

        public static DataTable SelectByOrderID(int orderID)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            string tableName = "OrderDetailTable";
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderDetailSelectByOrderID";

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

        public static DataTable SelectByOrderNo(string orderNo)
        {
            DataTable dt = null;
            string tableName = "OrderDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderDetailSelectByOrderNo";

                command.Parameters.AddWithValue("@p_OrderNo", orderNo);
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

        public static DataTable SelectBy(int orderID, int productID)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            string tableName = "OrderDetailTable";
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT ID FROM OrderDetail "
                    + " WHERE IsDeleted = 0 AND OrderID = @p_OrderID AND ProductID = @p_ProductID ";

                command.Parameters.AddWithValue("@p_OrderID", orderID);
                command.Parameters.AddWithValue("@p_ProductID", productID);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return dt;
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrderDetail"></param>        
        /// <returns></returns>
        public static int Insert(List<OrderDetail> newOrderDetails)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_OrderDetailInsert";

                foreach (OrderDetail newOrderDetail in newOrderDetails)
                {
                    cmd.Parameters.AddWithValue("@p_OrderID", newOrderDetail.OrderID);
                    cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newOrderDetail.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WSPrice", newOrderDetail.WSPrice);
                    cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RSPrice", newOrderDetail.RSPrice);
                    cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newOrderDetail.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Amount", newOrderDetail.Amount);
                    cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newOrderDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailInsert
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
                    throw sqle;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRow;
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrderDetail"></param>        
        /// <returns></returns>
        public static int UpdateByOrderDetailID(List<OrderDetail> mdOrderDetails)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_OrderDetailUpdateByOrderDetailID";

                foreach (OrderDetail detail in mdOrderDetails)
                {
                    cmd.Parameters.AddWithValue("@p_OrderDetailID", detail.ID);
                    cmd.Parameters["@p_OrderDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OrderID", detail.OrderID);
                    cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", detail.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WSPrice", detail.WSPrice);
                    cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RSPrice", detail.RSPrice);
                    cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", detail.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Amount", detail.Amount);
                    cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", detail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailInsert
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
                    throw sqle;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRow;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>        
        /// <returns></returns>
        public static int DeleteByOrderDetailID(int orderDetailID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_OrderDetailDeleteByOrderDetailID";

                cmd.Parameters.AddWithValue("@p_OrderDetailID", orderDetailID);
                cmd.Parameters["@p_OrderDetailID"].Direction = ParameterDirection.Input;

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
