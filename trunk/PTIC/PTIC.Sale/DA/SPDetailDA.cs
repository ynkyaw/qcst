using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    class SPDetailDA
    {
        internal static DataTable GetDetailBySalesPlanID(int p)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("SalesPlanDetailTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SalesPlanDetailGetBySalesPlanID";

                command.Parameters.AddWithValue("@p_SalesPlanID", p);
                command.Parameters["@p_SalesPlanID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }

        #region INSERT
        public static int Insert(SalesPlanDetail spdetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SalesPlanDetailInsert";

                cmd.Parameters.AddWithValue("@p_ProductID", spdetail.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPlanID", spdetail.SalesPlanID);
                cmd.Parameters["@p_SalesPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_retailPrice", spdetail.retailPrice);
                cmd.Parameters["@p_retailPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleQty", spdetail.SaleQty);
                cmd.Parameters["@p_SaleQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProduceQty", spdetail.ProduceQty);
                cmd.Parameters["@p_ProduceQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequireQty", spdetail.RequireQty);
                cmd.Parameters["@p_RequireQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_N100Convert", spdetail.Nconvert);
                cmd.Parameters["@p_N100Convert"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_Remark", spdetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion


        internal static int Update(SalesPlanDetail spdetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SalesPlanDetailUpdate";

                cmd.Parameters.AddWithValue("@p_SPDetailID", spdetail.ID);
                cmd.Parameters["@p_SPDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", spdetail.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPlanID", spdetail.SalesPlanID);
                cmd.Parameters["@p_SalesPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_retailPrice", spdetail.retailPrice);
                cmd.Parameters["@p_retailPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleQty", spdetail.SaleQty);
                cmd.Parameters["@p_SaleQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProduceQty", spdetail.ProduceQty);
                cmd.Parameters["@p_ProduceQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequireQty", spdetail.RequireQty);
                cmd.Parameters["@p_RequireQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_N100Convert", spdetail.Nconvert);
                cmd.Parameters["@p_N100Convert"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", spdetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_isdel", 0);
                cmd.Parameters["@p_isdel"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        internal static int Delete(int spDetailID,SalesPlan newSalePlan)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedrow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_SalesPlanDetailDelete";

                cmd.Parameters.AddWithValue("@p_SPDetailID", spDetailID);
                cmd.Parameters["@p_SPDetailID"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.Text;
                string query = "UPDATE SalesPlan SET SalesPlanAmt = @p_SalesPlanAmt WHERE ID = @p_SalesPlanID";
                cmd.CommandText = query;

                cmd.Parameters.AddWithValue("@p_SalesPlanAmt",newSalePlan.SalesPlanAmt);
                cmd.Parameters.AddWithValue("@p_SalesPlanID",newSalePlan.ID);

                affectedrow += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

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
            return affectedrow;
        }
    }
}
