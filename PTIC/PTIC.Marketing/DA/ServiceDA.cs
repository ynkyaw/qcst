/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   ServiceDA
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
    class ServiceDA
    {
        #region SelectAll

        public static DataTable SelectAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_APTypeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APTypeTable");
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return dataSet.Tables["APTypeTable"];
        }

        public static DataTable SelectByServiceID(int? serviceID)
        {
            DataTable table = null;
            string tableName = "ServiceTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_ServiceSelectByID";

                command.Parameters.AddWithValue("@p_ServiceID", serviceID);
                command.Parameters["@p_ServiceID"].Direction = ParameterDirection.Input;

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
        public static int? Insert(MobileServiceDetail newMobileServiceDetail, List<MobileServiceRecord> mobileServiceRecords)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedServiceID = null;

            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;
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




                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedServiceID = (int)insertedIDObj;
                // clear parameters of usp_MobileServiceDetailInsert
                cmd.Parameters.Clear();
                // insert new MobileServiceRecord
                cmd.CommandText = "usp_MobileServiceRecordInsert";
                foreach (MobileServiceRecord newMobileServiceRecord in mobileServiceRecords)
                {
                    cmd.Parameters.AddWithValue("@p_MSuvDetailID", insertedServiceID);
                    cmd.Parameters["@p_MSuvDetailID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_BrandID", newMobileServiceRecord.BrandID);
                    //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_ProductID", newMobileServiceRecord.ProductID);
                    //cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Brand", newMobileServiceRecord.Brand);
                    cmd.Parameters["@p_Brand"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Product", newMobileServiceRecord.Product);
                    cmd.Parameters["@p_Product"].Direction = ParameterDirection.Input;

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
                    return insertedServiceID;
                }
            }

            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedServiceID;
        }

        public static int? Insert(Service service,List<ServiceDetail> serviceDetails)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedServiceID = null;

            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ServiceInsert";

                //cmd.Parameters.AddWithValue("@p_ServiceID", service.ServiceID);
                //cmd.Parameters["@p_ServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", service.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", service.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceVia", service.ServiceVia);
                cmd.Parameters["@p_ServiceVia"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InVen", service.InVen);
                cmd.Parameters["@p_InVen"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InShowroom", service.InShowroom);
                cmd.Parameters["@p_InShowroom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InMarketing", service.InMarketing);
                cmd.Parameters["@p_InMarketing"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InFactory", service.InFactory);
                cmd.Parameters["@p_InFactory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToFactory", service.ToFactory);
                cmd.Parameters["@p_ToFactory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromFactory", service.FromFactory);
                cmd.Parameters["@p_FromFactory"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@p_IsMain", service.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", service.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", service.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ShowroomID", service.ShowroomID);
                cmd.Parameters["@p_ShowroomID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", service.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceRecDate", service.ServiceRecDate);
                cmd.Parameters["@p_ServiceRecDate"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedServiceID = (int)insertedIDObj;
                // clear parameters of usp_MobileServiceDetailInsert
                cmd.Parameters.Clear();
                // insert new MobileServiceRecord
                cmd.CommandText = "usp_ServiceDetailInsert";
                foreach (ServiceDetail serviceDetail in serviceDetails)
                {
                    cmd.Parameters.AddWithValue("@p_ServiceID", insertedServiceID);
                    cmd.Parameters["@p_ServiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_productID", serviceDetail.ProductID);
                    cmd.Parameters["@p_productID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_productionDate", serviceDetail.ProductionDate);
                    cmd.Parameters["@p_productionDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_JobCardNo", serviceDetail.JobCardNo);
                    cmd.Parameters["@p_JobCardNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ShopName", serviceDetail.ShopName);
                    cmd.Parameters["@p_ShopName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UsedDuration ", serviceDetail.UserDuration);
                    cmd.Parameters["@p_UsedDuration "].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UsedPlace", serviceDetail.UserPlace);
                    cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ChargingTime", serviceDetail.ChargingTime);
                    cmd.Parameters["@p_ChargingTime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ChargingUsedTime", serviceDetail.ChargingUsedTime);
                    cmd.Parameters["@p_ChargingUsedTime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UsedAmp", serviceDetail.UsedAmp);
                    cmd.Parameters["@p_UsedAmp"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UsedSize", serviceDetail.UsedSize);
                    cmd.Parameters["@p_UsedSize"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Description", serviceDetail.Description);
                    cmd.Parameters["@p_Description"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcCheckDate", serviceDetail.SvcCheckDate);
                    cmd.Parameters["@p_SvcCheckDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PosAcid1", serviceDetail.PosAcid1);
                    cmd.Parameters["@p_PosAcid1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PosAcid2", serviceDetail.PosAcid2);
                    cmd.Parameters["@p_PosAcid2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PosAcid3", serviceDetail.PosAcid3);
                    cmd.Parameters["@p_PosAcid3"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NegAcid1", serviceDetail.NegAcid1);
                    cmd.Parameters["@p_NegAcid1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NegAcid2", serviceDetail.NegAcid2);
                    cmd.Parameters["@p_NegAcid2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NegAcid3", serviceDetail.NegAcid3);
                    cmd.Parameters["@p_NegAcid3"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Volt", serviceDetail.Volt);
                    cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcFault", serviceDetail.SuvFault);
                    cmd.Parameters["@p_SvcFault"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FacRecDate", serviceDetail.FacRecDate);
                    cmd.Parameters["@p_FacRecDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FacFault", serviceDetail.FacFault);
                    cmd.Parameters["@p_FacFault"].Direction = ParameterDirection.Input;

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
                    return insertedServiceID;
                }
            }

            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedServiceID;

        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Service service, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ServiceUpdateByID";

                cmd.Parameters.AddWithValue("@p_ServiceID", service.ServiceID);
                cmd.Parameters["@p_ServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", service.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", service.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceVia", service.ServiceVia);
                cmd.Parameters["@p_ServiceVia"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InVen", service.InVen);
                cmd.Parameters["@p_InVen"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InShowroom", service.InShowroom);
                cmd.Parameters["@p_InShowroom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InMarketing", service.InMarketing);
                cmd.Parameters["@p_InMarketing"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InFactory", service.InFactory);
                cmd.Parameters["@p_InFactory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToFactory", service.ToFactory);
                cmd.Parameters["@p_ToFactory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromFactory", service.FromFactory);
                cmd.Parameters["@p_FromFactory"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", service.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", service.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", service.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ShowroomID", service.ShowroomID);
                cmd.Parameters["@p_ShowroomID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", service.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceRecDate", service.ServiceRecDate);
                cmd.Parameters["@p_ServiceRecDate"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Service service, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankDeleteByBankID";

                cmd.Parameters.AddWithValue("@p_BankID", service.ServiceID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        public static int DeleteByServiceID(int? ServiceID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ServiceDetailDeleteByID";

                cmd.Parameters.AddWithValue("@p_ServiceDetailID", ServiceID);
                cmd.Parameters["@p_ServiceDetailID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #endregion
        //
    }
}
