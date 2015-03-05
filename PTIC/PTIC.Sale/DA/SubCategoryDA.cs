/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   SubCategoryDA ( Insert , Update , Delete , SelectAll}
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
    public class SubCategoryDA
    {
        #region SelectAllProduct

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
                command.CommandText = "usp_SubCatSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "SubCatTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["SubCatTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(SubCategory subcategory, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SubCatInsert";

                cmd.Parameters.AddWithValue("@p_categoryid", subcategory.CategoryID );
                cmd.Parameters["@p_categoryid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_subcategory", subcategory.SubCategoryName);
                cmd.Parameters["@p_subcategory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", subcategory.Remark);
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
        public static int UpdateByID(SubCategory subcategory, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SubCatUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", subcategory.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_categoryid", subcategory.CategoryID);
                cmd.Parameters["@p_categoryid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_subcategory", subcategory.SubCategoryName);
                cmd.Parameters["@p_subcategory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", subcategory.Remark);
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
        public static int DeleteByID(SubCategory subcategory, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SubCatDelete";

                cmd.Parameters.AddWithValue("@p_id", subcategory.ID);
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
