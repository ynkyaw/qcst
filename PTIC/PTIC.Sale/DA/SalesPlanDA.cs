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
    public class SalesPlanDA
    {

        internal static DataTable GetbyMonth(DateTime month)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("SalesPlanTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SalesPlanGetByMonth";

                command.Parameters.AddWithValue("@p_PlanDate", month);
                command.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }


        internal static DataTable GetbyMonthAndBrand(DateTime month,int BrandID)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("SalesPlanTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SalesPlanDetailGetByMonthAndBrand";

                command.Parameters.AddWithValue("@p_PlanDate", month);
                command.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_BrandID", BrandID);
                command.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

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
        public static int Insert(SalesPlan saleplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SalesPlanInsert";

                cmd.Parameters.AddWithValue("@p_PlanDate", saleplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPlanAmt", saleplan.SalesPlanAmt);
                cmd.Parameters["@p_SalesPlanAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", saleplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;
                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        internal static int Save(SalesPlan saleplan, List<SalesPlanDetail> spdetails, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int insertedsaleplanid = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                                
                cmd.CommandText = "usp_SalesPlanInsert";

                cmd.Parameters.AddWithValue("@p_PlanDate", saleplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPlanAmt", saleplan.SalesPlanAmt);
                cmd.Parameters["@p_SalesPlanAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", saleplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedsaleplanid = (int)insertedIDObj;

                cmd.Parameters.Clear();

                cmd.CommandText = "usp_SalesPlanDetailInsert";
                foreach (SalesPlanDetail spd in spdetails)
                {
                    cmd.Parameters.AddWithValue("@p_ProductID", spd.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalesPlanID", insertedsaleplanid);
                    cmd.Parameters["@p_SalesPlanID"].Direction = ParameterDirection.Input;


                    cmd.Parameters.AddWithValue("@p_RetailPrice", spd.retailPrice);
                    cmd.Parameters["@p_RetailPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SaleQty", spd.SaleQty);
                    cmd.Parameters["@p_SaleQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProduceQty", spd.ProduceQty);
                    cmd.Parameters["@p_ProduceQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RequireQty", spd.RequireQty);
                    cmd.Parameters["@p_RequireQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_N100Convert", spd.Nconvert);
                    cmd.Parameters["@p_N100Convert"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", spd.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                }
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
            return insertedsaleplanid;
        }

        internal static int Update(SalesPlan saleplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SalesPlanUpdateByID";

                cmd.Parameters.AddWithValue("@p_salesplanID", saleplan.ID);
                cmd.Parameters["@p_salesplanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_isdel", 0);
                cmd.Parameters["@p_isdel"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_spAmt", saleplan.SalesPlanAmt);
                cmd.Parameters["@p_spAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", saleplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            };
        }
    }
}
