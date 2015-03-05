using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Sale.Entities;

namespace PTIC.Marketing.DA
{
    public class TelemarketingDetailDA
    {
        #region SELECT
        public static DataTable SelectByMarketingDetailID(int marketingDetailID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "TeleMarketingDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TeleMarketingDetailSelectByTeleMarketingDetailID";

                command.Parameters.AddWithValue("@p_TeleMarketingDetailID", marketingDetailID);
                command.Parameters["@p_TeleMarketingDetailID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region SELECT Contact Person Info
        public static DataTable SelectContactPersonInfo(int CusID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "ContactPersonInfoTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_ContactPesronInfoSelectByCustomerID";

                command.Parameters.AddWithValue("@p_CusID", CusID);
                command.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region INSERT
        public static int Insert(TeleMarketingDetail newTeleMarketingDetail, SqlConnection conn,bool IsService,bool IsTele)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedCusID = null;
            int affectedRows = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_TeleMarketingDetailInsert";

                cmd.Parameters.AddWithValue("@p_CusID", newTeleMarketingDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newTeleMarketingDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingPlanID", newTeleMarketingDetail.MarketingPlanID);
                cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", newTeleMarketingDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingBrandID", newTeleMarketingDetail.UsingBrand);
                cmd.Parameters["@p_UsingBrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingProductID", newTeleMarketingDetail.UsingProductID);
                cmd.Parameters["@p_UsingProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingQty", newTeleMarketingDetail.UsingQty);
                cmd.Parameters["@p_UsingQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingPeriod", newTeleMarketingDetail.UsingPeriod);
                cmd.Parameters["@p_UsingPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SellingPeriod", newTeleMarketingDetail.SellingPeriod);
                cmd.Parameters["@p_SellingPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SellingBrandID", newTeleMarketingDetail.SellingBrandID);
                cmd.Parameters["@p_SellingBrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SatisfactionFact", newTeleMarketingDetail.SatisfactionFact);
                cmd.Parameters["@p_SatisfactionFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DissatisfactionFact", newTeleMarketingDetail.DisatisfactionFact);
                cmd.Parameters["@p_DissatisfactionFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherFact", newTeleMarketingDetail.OtherFact);
                cmd.Parameters["@p_OtherFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceDate", 
                    newTeleMarketingDetail.ServiceDate == DateTime.MinValue ? (object)DBNull.Value : newTeleMarketingDetail.ServiceDate);
                cmd.Parameters["@p_ServiceDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RecallDate",
                    newTeleMarketingDetail.RecallDate == DateTime.MinValue ? (object)DBNull.Value : newTeleMarketingDetail.RecallDate);              
                cmd.Parameters["@p_RecallDate"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_MarketedDate", newTeleMarketingDetail.MarketedDate);
                cmd.Parameters["@p_MarketedDate"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;
                insertedCusID = (int)insertedIDObj;
                cmd.Parameters.Clear();

                if (IsService == true)
                {
                    cmd.CommandText = "usp_MobileServicePlanInsert";

                    cmd.Parameters.AddWithValue("@p_CusID", newTeleMarketingDetail.CusID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TeleMarketingDetailID", insertedCusID);
                    cmd.Parameters["@p_TeleMarketingDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", DBNull.Value);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_InitialMobileServicePlanID", null);
                    cmd.Parameters["@p_InitialMobileServicePlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcPlanDate", newTeleMarketingDetail.ServiceDate);
                    cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", (int)PTIC.Common.Enum.FormStatus.Reported);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    affectedRows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    
                }

                if (IsTele)
                {
                    cmd.CommandText = "usp_TeleMarketingPlanInsert";

                    cmd.Parameters.AddWithValue("@p_CusID", newTeleMarketingDetail.CusID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PlanDate", newTeleMarketingDetail.RecallDate);
                    cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MarketingType", (int)PTIC.Common.Enum.MarketingType.Telemarketing);
                    cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", (int)PTIC.Common.Enum.FormStatus.Reported);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    affectedRows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                transaction.Commit();           
                
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedRows = 0;
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

        #region UPDATE
        public static int UpdateByTeleMarketingDetailID(TeleMarketingDetail newTeleMarketingDetail, SqlConnection conn,bool IsService)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_TeleMarketingDetailUpdateByTeleMarketingDetailID";

                cmd.Parameters.AddWithValue("@p_TeleMarketingDetailID", newTeleMarketingDetail.ID);
                cmd.Parameters["@p_TeleMarketingDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", newTeleMarketingDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newTeleMarketingDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingPlanID", newTeleMarketingDetail.MarketingPlanID);
                cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", newTeleMarketingDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingBrandID", newTeleMarketingDetail.UsingBrand);
                cmd.Parameters["@p_UsingBrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingProductID", newTeleMarketingDetail.UsingProductID);
                cmd.Parameters["@p_UsingProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingQty", newTeleMarketingDetail.UsingQty);
                cmd.Parameters["@p_UsingQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingPeriod", newTeleMarketingDetail.UsingPeriod);
                cmd.Parameters["@p_UsingPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SellingPeriod", newTeleMarketingDetail.SellingPeriod);
                cmd.Parameters["@p_SellingPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SellingBrandID", newTeleMarketingDetail.SellingBrandID);
                cmd.Parameters["@p_SellingBrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SatisfactionFact", newTeleMarketingDetail.SatisfactionFact);
                cmd.Parameters["@p_SatisfactionFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DissatisfactionFact", newTeleMarketingDetail.DisatisfactionFact);
                cmd.Parameters["@p_DissatisfactionFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherFact", newTeleMarketingDetail.OtherFact);
                cmd.Parameters["@p_OtherFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceDate", 
                    newTeleMarketingDetail.ServiceDate == DateTime.MinValue ? (object)DBNull.Value : newTeleMarketingDetail.ServiceDate);
                cmd.Parameters["@p_ServiceDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RecallDate", newTeleMarketingDetail.RecallDate == DateTime.MinValue ? (object)DBNull.Value:newTeleMarketingDetail.RecallDate);
                cmd.Parameters["@p_RecallDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketedDate", newTeleMarketingDetail.MarketedDate);
                cmd.Parameters["@p_MarketedDate"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


                if (IsService == true)
                {
                    cmd.CommandText = "usp_MobileServicePlanUpdateByTeleMarketingID";

                    cmd.Parameters.AddWithValue("@p_TeleMarketingDetailID", newTeleMarketingDetail.ID);
                    cmd.Parameters["@p_TeleMarketingDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CusID", newTeleMarketingDetail.CusID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", DBNull.Value);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcPlanNo", Guid.NewGuid().ToString());
                    cmd.Parameters["@p_SvcPlanNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcPlanDate", newTeleMarketingDetail.ServiceDate);
                    cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;
                    affectedRows = cmd.ExecuteNonQuery();
                }              
                transaction.Commit();

            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedRows;
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
        public static int DeleteByTeleMarketingDetailID(int teleMarketingDetailID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TeleMarketingDetailDeleteByTeleMarketingDetailID";

                cmd.Parameters.AddWithValue("@p_TeleMarketingDetailID", teleMarketingDetailID);
                cmd.Parameters["@p_TeleMarketingDetailID"].Direction = ParameterDirection.Input;

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
