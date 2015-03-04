
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2013
 * Description: about T R Product
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class T_R_Product_DA
    {

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            string tableName = "T_R_ProductTable";
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_ProductSelectAll";

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
            string tableName = "T_R_ProductTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_ProductSelectByID";

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

        public static DataTable SelectByNo(string No, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "T_R_ProductTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_ProductSelectByNo";

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

        public static DataTable SelectByTripReqID(int tripReqID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "T_R_ProductTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_ProductSelectByTripReqID";

                command.Parameters.AddWithValue("@p_tripReqid", tripReqID);
                command.Parameters["@p_tripReqid"].Direction = ParameterDirection.Input;

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
        public static int Insert(List<T_R_Product> newT_R_Product, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_T_R_ProductInsert";

                foreach (T_R_Product t_r_product in newT_R_Product)
                {
                    cmd.Parameters.AddWithValue("@p_tripReqID", t_r_product.TripReqID);
                    cmd.Parameters["@p_tripReqID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", t_r_product.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", t_r_product.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_weight", t_r_product.Weight);
                    cmd.Parameters["@p_weight"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_remark", t_r_product.Remark);
                    cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;                 

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_T_R_ProductInsert
                    cmd.Parameters.Clear();
                }
         
              //  return cmd.ExecuteNonQuery();
                return affectedRows;
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
        public static int UpdateByT_R_ProductID(List<T_R_Product> mdT_R_Product, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_T_R_ProductUpdateByT_R_ProductID";

                foreach (T_R_Product trProduct in mdT_R_Product)
                {
                    cmd.Parameters.AddWithValue("@p_T_R_ProductID", trProduct.ID);
                    cmd.Parameters["@p_T_R_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_tripReqID", trProduct.TripReqID);
                    cmd.Parameters["@p_tripReqID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", trProduct.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", trProduct.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_weight", trProduct.Weight);
                    cmd.Parameters["@p_weight"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_remark", trProduct.Remark);
                    cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_T_R_ProductUpdateByT_R_ProductID
                    cmd.Parameters.Clear();
                }
              //  return cmd.ExecuteNonQuery();

                return affectedRows;
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
        public static int DeleteByT_R_ProductID(List<T_R_Product> T_R_Products, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_T_R_ProductDeleteByT_R_ProductID";

                foreach (T_R_Product t_r_product in T_R_Products)
                {
                    cmd.Parameters.AddWithValue("@p_T_R_ProductID", t_r_product.ID);
                    cmd.Parameters["@p_T_R_ProductID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_T_R_ProductDeleteByT_R_ProductID
                    cmd.Parameters.Clear();
                }
                return affectedRows;

               // return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

    }
}

