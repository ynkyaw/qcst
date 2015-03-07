/* Author   :   Aung Ko Ko
    Date      :   11 Feb 2014
    Description :   BrandDA ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class BrandDA
    {
        public static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_BrandSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "BrandTable");
            }
            catch (SqlException sqle)
            {
                // show error message
            }
            return dataSet.Tables["BrandTable"];
        }
        #endregion

        #region SELECT IsOwnBrand
        public static DataTable SelectAllCompetitor()
        {
            DataTable dt;

            try
            {
                dt = b.SelectByQuery("SELECT CompetitorBrand As BrandName,ID As BrandID FROM CompetitorBrand WHERE IsDeleted =0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public static DataTable SelectAllByIsOwnBrand(bool check)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_BrandSelectAllByIsOwnBrand";

                command.Parameters.AddWithValue("@p_isownbrand", check);
                command.Parameters["@p_isownbrand"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "BrandTable");
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return dataSet.Tables["BrandTable"];
        }
        #endregion

        #region SELECTBYBRANDID
        #endregion

        public static DataTable SelectAllByBrandID(int id, SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BrandSelectAllByBrandID";

                cmd.Parameters.AddWithValue("@p_id", id);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet, "BrandTable");
            }
            catch (SqlException sqle)
            {
                // show error message
            }

            return dataSet.Tables["BrandTable"];
        }

        #region INSERT
        public static int Insert(Brand brand, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BrandInsert";

                cmd.Parameters.AddWithValue("@p_brandname", brand.BrandName);
                cmd.Parameters["@p_brandname"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_isownbrand", brand.IsOwnBrand);
                cmd.Parameters["@p_isownbrand"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_confirmdate", DateTime.Now);
                cmd.Parameters["@p_confirmdate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_startdate", DateTime.Now);
                cmd.Parameters["@p_startdate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", brand.Remark);
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
        public static int UpdateByID(Brand brand, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BrandUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", brand.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_brandname", brand.BrandName);
                cmd.Parameters["@p_brandname"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_confirmdate", brand.ConfirmDate);
                cmd.Parameters["@p_confirmdate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_startdate", brand.StartDate);
                cmd.Parameters["@p_startdate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_isownbrand", brand.IsOwnBrand);
                cmd.Parameters["@p_isownbrand"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", brand.Remark);
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
        public static int DeleteByID(Brand brand, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BrandDelete";

                cmd.Parameters.AddWithValue("@p_id", brand.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region Insert Competitor
        public static int InsertCompetitor(Brand brand, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            int? insertedCompetitorBrandID = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_CompetitorBrandInsert";

                cmd.Parameters.AddWithValue("@p_CompetitorBrand", brand.BrandName);
                cmd.Parameters["@p_CompetitorBrand"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", brand.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedCompetitorBrandID = (int)insertedIDObj;
                // clear parameters of usp_CompetitorBrandInsert
                cmd.Parameters.Clear();

                cmd.CommandText = "usp_CompetitorProductInsert";

                cmd.Parameters.AddWithValue("@p_BrandID", insertedCompetitorBrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductName", brand.CompetitorProduct);
                cmd.Parameters["@p_ProductName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Company", brand.Company);
                cmd.Parameters["@p_Company"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", brand.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", brand.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", brand.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                // clear parameters of each usp_OrderDetailInsert
                cmd.Parameters.Clear();

                // commit transaction
                transaction.Commit();

            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return 0;
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

        #region Update CompetitorBrand
        public static int UpdateCompetitorProductByBrandID(Brand brand, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorBrandUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", brand.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductName", brand.CompetitorProduct);
                cmd.Parameters["@p_ProductName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Company", brand.Company);
                cmd.Parameters["@p_Company"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", brand.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", brand.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", brand.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region Select CompetitorBrand
        public static DataTable SelectAllCompetitorBrands()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM CompetitorBrand WHERE IsDeleted =0");
            }
            catch (Exception ex)
            {                
                throw;
            }
            return dt;
        }

        public static DataTable SelectAllCompetitorBy(string CompetitorBrand , string CompetitorProduct,int BrandID)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("CompetitorBrandProduct");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CompetitorBrand,CompetitorProduct.CProductName As CompetitorProduct,CompetitorProduct.Remark, "
                                        +"CompetitorBrand.ID,CompetitorProduct.CompanyName "
                                        +"FROM CompetitorBrand "
                                         +"INNER JOIN CompetitorProduct ON CompetitorProduct.BrandID = CompetitorBrand.ID "
                                        + "WHERE CompetitorProduct.IsDeleted =0 AND CompetitorBrand.IsDeleted=0 AND CompetitorBrand = @p_CompetitorBrand AND CompetitorProduct.CProductName = @p_CompetitorProduct AND CompetitorBrand.ID != @p_CompetitorBrandID";

                command.Parameters.AddWithValue("@p_CompetitorBrand", CompetitorBrand);
                command.Parameters["@p_CompetitorBrand"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CompetitorProduct", CompetitorProduct);
                command.Parameters["@p_CompetitorProduct"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CompetitorBrandID", BrandID);
                command.Parameters["@p_CompetitorProduct"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }


        public static DataTable SelectAllCompetitorBrand()
        {
            DataTable dt;
            try
            {
                string query = "SELECT CompetitorBrand,CompetitorProduct.CProductName As CompetitorProduct,CompetitorProduct.Remark,CompetitorBrand.ID,CompetitorProduct.CompanyName,CompetitorProduct.Phone1,CompetitorProduct.Phone2"
                                        + " FROM CompetitorBrand LEFT JOIN CompetitorProduct ON CompetitorProduct.BrandID = CompetitorBrand.ID"
                                            + " WHERE CompetitorProduct.IsDeleted =0 AND CompetitorBrand.IsDeleted=0";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region Competitor DELETE 
        public static int DeleteCompetitorByID(Brand brand, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.CommandText = "DELETE CompetitorProduct WHERE BrandID = @p_BrandID";

                cmd.Parameters.AddWithValue("@p_BrandID", brand.ID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE CompetitorBrand WHERE ID = @p_BrandID";

                cmd.Parameters.AddWithValue("@p_BrandID", brand.ID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                               
                // commit transaction
                transaction.Commit();

            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return 0;
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

    }
}
