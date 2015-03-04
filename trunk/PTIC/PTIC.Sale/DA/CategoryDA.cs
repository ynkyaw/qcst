/* Author   :   Aung Ko Ko
    Date      :   11 Feb 2014
    Description :   CategoryDA ( Insert , Update , Delete , SelectAllByBrandID}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class CategoryDA
    {
        #region SelectAllCategory
        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CategorySelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet,"CategoryTable");
           }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["CategoryTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(Category category, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CategoryInsert";

                cmd.Parameters.AddWithValue("@p_category", category.CategoryName);
                cmd.Parameters["@p_category"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_brandid", category.BrandID);
                cmd.Parameters["@p_brandid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", category.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;
                                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Category category, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CategoryUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", category.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_brandid", category.BrandID);
                cmd.Parameters["@p_brandid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_category", category.CategoryName);
                cmd.Parameters["@p_category"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", category.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Category category, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CategoryDelete";

                cmd.Parameters.AddWithValue("@p_id", category.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

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
