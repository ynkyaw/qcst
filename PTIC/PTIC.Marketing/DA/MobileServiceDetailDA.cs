/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/mm/dd)
 * Description: Mobile Service Detail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class MobileServiceDetailDA
    {
        #region SELECT
        public static DataTable SelectByMobileServiceDetailID(int mobileServiceDetailID)
        {
            DataTable table = null;
            string tableName = "MobileServiceDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceDetailSelectByID";

                command.Parameters.AddWithValue("@p_MobileServiceDetailID", mobileServiceDetailID);
                command.Parameters["@p_MobileServiceDetailID"].Direction = ParameterDirection.Input;

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
        public static int Insert(MobileServiceDetail newMobileServiceDetail)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServiceDetailInsert";

                cmd.Parameters.AddWithValue("@p_ServicePlanID", newMobileServiceDetail.ServicePlanID);
                cmd.Parameters["@p_ServicePlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", newMobileServiceDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", newMobileServiceDetail.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", newMobileServiceDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newMobileServiceDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServicedDate", newMobileServiceDetail.ServicePlanID);
                cmd.Parameters["@p_ServicedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsCustomer", newMobileServiceDetail.IsCustomer);
                cmd.Parameters["@p_IsCustomer"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SugForUsage", newMobileServiceDetail.SugForUsage);
                cmd.Parameters["@p_SugForUsage"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ResonNotService", newMobileServiceDetail.ResonNotService);
                cmd.Parameters["@p_ResonNotService"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AppointedDate", newMobileServiceDetail.AppointedDate);
                cmd.Parameters["@p_AppointedDate"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMobileServiceDetail"></param>
        /// <param name="newMobileServiceRecords"></param>
        /// <returns>Return an inserted MobileServiceDetail</returns>
        public static int? Insert(MobileServiceDetail newMobileServiceDetail, List<MobileServiceRecord> newMobileServiceRecords)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedMobileServiceDetailID = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new MobileServiceDetail
                cmd.CommandText = "usp_MobileServiceDetailInsert";

                cmd.Parameters.AddWithValue("@p_ServicePlanID", newMobileServiceDetail.ServicePlanID);
                cmd.Parameters["@p_ServicePlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", newMobileServiceDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", newMobileServiceDetail.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", newMobileServiceDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newMobileServiceDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServicedDate", newMobileServiceDetail.ServicedDate);
                cmd.Parameters["@p_ServicedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsCustomer", newMobileServiceDetail.IsCustomer);
                cmd.Parameters["@p_IsCustomer"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SugForUsage", newMobileServiceDetail.SugForUsage);
                cmd.Parameters["@p_SugForUsage"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ResonNotService", newMobileServiceDetail.ResonNotService);
                cmd.Parameters["@p_ResonNotService"].Direction = ParameterDirection.Input;

                if (newMobileServiceDetail.AppointedDate != DateTime.MinValue)
                {
                    //cmd.Parameters.AddWithValue("@p_Flag", true);
                    //cmd.Parameters["@p_Flag"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AppointedDate", newMobileServiceDetail.AppointedDate);
                    cmd.Parameters["@p_AppointedDate"].Direction = ParameterDirection.Input;
                }
                else
                {
                    //cmd.Parameters.AddWithValue("@p_Flag", false);
                    //cmd.Parameters["@p_Flag"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AppointedDate", null);
                    cmd.Parameters["@p_AppointedDate"].Direction = ParameterDirection.Input;
                }

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedMobileServiceDetailID = (int)insertedIDObj;
                // clear parameters of usp_MobileServiceDetailInsert
                cmd.Parameters.Clear();
                // insert new MobileServiceRecord
                cmd.CommandText = "usp_MobileServiceRecordInsert";
                foreach (MobileServiceRecord newMobileServiceRecord in newMobileServiceRecords)
                {
                    cmd.Parameters.AddWithValue("@p_MSuvDetailID", insertedMobileServiceDetailID);
                    cmd.Parameters["@p_MSuvDetailID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_BrandID", newMobileServiceRecord.BrandID);
                    //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_ProductID", newMobileServiceRecord.ProductID);
                    //cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UsedPlace", newMobileServiceRecord.UsedPlace);
                    cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MachineNo", newMobileServiceRecord.MachineNo);
                    cmd.Parameters["@p_MachineNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductionDate", newMobileServiceRecord.ProductionDate);
                    cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Volt", newMobileServiceRecord.Volt);
                    cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ChargingAmp", newMobileServiceRecord.ChargingAmp);
                    cmd.Parameters["@p_ChargingAmp"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OutAmp", newMobileServiceRecord.OutAmp);
                    cmd.Parameters["@p_OutAmp"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Acid1", newMobileServiceRecord.Acid1);
                    cmd.Parameters["@p_Acid1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Acid2", newMobileServiceRecord.Acid2);
                    cmd.Parameters["@p_Acid2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Acid3", newMobileServiceRecord.Acid3);
                    cmd.Parameters["@p_Acid3"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Acid4", newMobileServiceRecord.Acid4);
                    cmd.Parameters["@p_Acid4"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Acid5", newMobileServiceRecord.Acid5);
                    cmd.Parameters["@p_Acid5"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Acid6", newMobileServiceRecord.Acid6);
                    cmd.Parameters["@p_Acid6"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Serving", newMobileServiceRecord.Serving);
                    cmd.Parameters["@p_Serving"].Direction = ParameterDirection.Input;
                    
                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_MobileServiceRecordInsert
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
                    return insertedMobileServiceDetailID;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedMobileServiceDetailID;
        }
        #endregion

        #region UPDATE
        public static int UpdateByMobileServiceDetailID(MobileServiceDetail mdMobileServiceDetail)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServiceDetailUpdateByID";

                cmd.Parameters.AddWithValue("@p_MobileServiceDetailID", mdMobileServiceDetail.ID);
                cmd.Parameters["@p_MobileServiceDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", mdMobileServiceDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", mdMobileServiceDetail.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServicePlanID", mdMobileServiceDetail.ServicePlanID);
                cmd.Parameters["@p_ServicePlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", mdMobileServiceDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", mdMobileServiceDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServicedDate", mdMobileServiceDetail.ServicedDate);
                cmd.Parameters["@p_ServicedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsCustomer", mdMobileServiceDetail.IsCustomer);
                cmd.Parameters["@p_IsCustomer"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SugForUsage", mdMobileServiceDetail.SugForUsage);
                cmd.Parameters["@p_SugForUsage"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ResonNotService", mdMobileServiceDetail.ResonNotService);
                cmd.Parameters["@p_ResonNotService"].Direction = ParameterDirection.Input;

                if (mdMobileServiceDetail.AppointedDate != DateTime.MinValue)
                {
                    cmd.Parameters.AddWithValue("@p_AppointedDate", mdMobileServiceDetail.AppointedDate);
                    cmd.Parameters["@p_AppointedDate"].Direction = ParameterDirection.Input;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_AppointedDate", null);
                    cmd.Parameters["@p_AppointedDate"].Direction = ParameterDirection.Input;
                }

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByMobileServiceDetailID(int mobileServiceDetailID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServiceDetailDeleteByID";

                cmd.Parameters.AddWithValue("@p_MobileServiceDetailID", mobileServiceDetailID);
                cmd.Parameters["@p_MobileServiceDetailID"].Direction = ParameterDirection.Input;

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
