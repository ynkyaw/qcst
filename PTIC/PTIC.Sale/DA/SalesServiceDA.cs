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
    public class SalesServiceDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECTALL
        public static DataTable SelectAllByID(int SalesServiceID)
        {
            DataTable dt;
            dt = b.SelectByQuery("SELECT * FROM SalesService WHERE ID =" + SalesServiceID);
            return dt;
        }

        public static DateTime GetValidLastTime(int SalesSerViceId) 
        {
            DateTime validDate = new DateTime (1,1,1);
            object obj = b.SelectScalar("SELECT (SELECT Max(v) FROM (VALUES (ReceivedDate), (DateToSvc), (SeviceDate),(DateToFactory),(DateFromFactory),(DateFromSvc),(DateToCustomer),(ReturnedDate)) AS value(v)) as [MaxDate] FROM SalesService where ID=" + SalesSerViceId);
            if (obj != null) 
            {
                DateTime.TryParse(obj.ToString(), out validDate);
            }
            return validDate;
            
        }

        #endregion

        #region INSERT MULTIPLE TRANSFER
        public static int Insert(
            List<SalesService> salesServices, 
            List<ServiceBatteryStatus> servicedBatteryStatus, 
            DateTime ReturnDate,int? TransportedWarehouseID, int? TransportedVenID, int SalePersonID, int NowIam)
        {
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
          //  int? insertedServicedCustomerID = null;
            SqlTransaction transaction = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                for (int i = 0; i < salesServices.Count; i++)
                {
                    SalesService salesService = salesServices[i];
                    ServiceBatteryStatus serviceBatteryStatus = servicedBatteryStatus[i];

                    cmd.CommandText = "usp_SalesServiceTransferInsert";

                    cmd.Parameters.AddWithValue("@p_SalesServiceID", salesService.ID);
                    cmd.Parameters["@p_SalesServiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", salesService.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ReturnedDate", ReturnDate);
                    cmd.Parameters["@p_ReturnedDate"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcFactID", salesService.SvcFactID);
                    //cmd.Parameters["@p_SvcFactID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Taker", salesService.Taker);
                    cmd.Parameters["@p_Taker"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IsReturned", salesService.IsReturned);
                    cmd.Parameters["@p_IsReturned"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_Wherami", salesService.Whereami);
                    //cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IsBackward", salesService.IsBackward);
                    cmd.Parameters["@p_IsBackward"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", 1);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    int? currentPlaceID = null;
                    if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom)
                        currentPlaceID = serviceBatteryStatus.CurrentWarehouseID;
                    else if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore)
                        currentPlaceID = serviceBatteryStatus.CurrentMainStoreID;
                    else if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore)
                        currentPlaceID = serviceBatteryStatus.CurrentServiceTeamID;
                    else
                        currentPlaceID = serviceBatteryStatus.CurrentVehicleID;

                    if (serviceBatteryStatus.CurrentVehicleID == null) // Warehouse or Servie Team
                    {
                        if (salesService.IsReturned)
                        {
                            //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID);
                            cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", currentPlaceID);
                            cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                            cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Date", ReturnDate);
                            cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_WarehouseID", null);
                            cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_VenID", null);
                            cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Whereami", (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
                            cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_FromStockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                            //cmd.Parameters["@p_FromStockBy"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_ToStockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                            //cmd.Parameters["@p_ToStockBy"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Customer);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_GiverID", salesService.GiverID);
                            cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@p_Date", ReturnDate);
                            cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID);
                            cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", currentPlaceID);
                            cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                            cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_WarehouseID", TransportedWarehouseID);
                            cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_VenID", TransportedVenID);
                            cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Whereami", NowIam);
                            cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                            //cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                            // Checking Where to Transfer
                            if (TransportedVenID != null)
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Vehicle);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            else if (TransportedWarehouseID == 1)
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.MainStore);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            else if (TransportedWarehouseID == 2)
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }

                            cmd.Parameters.AddWithValue("@p_GiverID", SalePersonID);
                            cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;
                        }
                    }
                    else // vehicle
                    {
                        if (salesService.IsReturned)
                        {
                            cmd.Parameters.AddWithValue("@p_Date", ReturnDate);
                            cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID); // NOT necessary
                            cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", currentPlaceID);
                            cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                            cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_WarehouseID", null);
                            cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_VenID", null);
                            cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Whereami", (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
                            cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Service);
                            //cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Customer);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_GiverID", salesService.GiverID);
                            cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@p_Date", ReturnDate);
                            cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID);
                            cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", DBNull.Value);
                            cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                            cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_WarehouseID", TransportedWarehouseID);
                            cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_VenID", TransportedVenID);
                            cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@p_Whereami", NowIam);
                            cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                            //cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Service);
                            //cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                            // Checking Where to Transfer
                            if (TransportedVenID != null)
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Vehicle);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            else if (TransportedWarehouseID == 1)
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.MainStore);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            else if (TransportedWarehouseID == 2)
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                                cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            }
                            //if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore)
                            //{
                            //    cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                            //    cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            //}
                            //else
                            //{
                            //    cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                            //    cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                            //}

                            cmd.Parameters.AddWithValue("@p_GiverID", SalePersonID);
                            cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;
                        }
                    }

                    affectedrow += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }

        #endregion

        #region INSERT
        public static int Insert(
            SalesService salesService,
            ServicedCustomer servicedCustomer, int? VenID, int? WarehouseID)
        {
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();                
            int affectedrow = 0;
            int? insertedServicedCustomerID = null;
            SqlTransaction transaction = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_ServicedCustomerInsert";

                cmd.Parameters.AddWithValue("@p_CustomerID", servicedCustomer.CustomerID);
                cmd.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", servicedCustomer.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", servicedCustomer.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UserName", servicedCustomer.UserName);
                cmd.Parameters["@p_UserName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContactPerson", servicedCustomer.ContactPerson);
                cmd.Parameters["@p_ContactPerson"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", servicedCustomer.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", servicedCustomer.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedServicedCustomerID = (int?)insertedIDObj;
                // clear parameters of usp_ServicedCustomerInsert
                cmd.Parameters.Clear();
                // insert new ServicedCustomer

                cmd.CommandText = "usp_SalesServiceReceiveInsert";

                cmd.Parameters.AddWithValue("@p_ServicedCustomerID", insertedServicedCustomerID);
                cmd.Parameters["@p_ServicedCustomerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceivedDate", salesService.ReceivedDate);
                cmd.Parameters["@p_ReceivedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductionDate", salesService.ProductionDate);
                cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedDate", salesService.PurchaseDate);
                cmd.Parameters["@p_PurchasedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Giver", salesService.Giver);
                cmd.Parameters["@p_Giver"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TakerID", salesService.TakerID);
                cmd.Parameters["@p_TakerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GiverID", null);
                cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Taker", null);
                cmd.Parameters["@p_Taker"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", salesService.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TownID", salesService.TownID);
                //cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TownshipID", salesService.TownshipID);
                //cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_CusID", salesService.CusID);
                //cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Qty", 1);
                cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_UserName", salesService.UserName);
                //cmd.Parameters["@p_UserName"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ContactPerson", salesService.ContactPersion);
                //cmd.Parameters["@p_ContactPerson"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_PhNo1", salesService.PhNo1);
                //cmd.Parameters["@p_PhNo1"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_PhNo2", salesService.PhNo2);
                //cmd.Parameters["@p_PhNo2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_JobCardNo", salesService.JobCardNo);
                cmd.Parameters["@p_JobCardNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_WarrantyNo", salesService.WarrantyNo);
                cmd.Parameters["@p_WarrantyNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsReturned", false);
                cmd.Parameters["@p_IsReturned"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsBackward", false);
                cmd.Parameters["@p_IsBackward"].Direction = ParameterDirection.Input;

                if (VenID == null)
                {
                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                    if (WarehouseID == 2)
                    {
                        cmd.Parameters.AddWithValue("@p_Date",salesService.ReceivedDate);
                        cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Wherami", (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore);
                        cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                        cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                    }
                    else if (WarehouseID == 1)
                    {
                        cmd.Parameters.AddWithValue("@p_Date", salesService.ReceivedDate);
                        cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.MainStore);
                        cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Wherami", (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore);
                        cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                        cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Wherami", (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom);
                        cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;
                    }
                   
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Date", salesService.ReceivedDate);
                    cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Wherami", (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle);
                    cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Service);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Vehicle);
                    cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                }

                affectedrow += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }

        public static int InsertTransferReturn(
            SalesService salesService, 
            ServiceBatteryStatus serviceBatteryStatus, 
            int? TransportedWarehouseID, int? TransportedVenID, int SalePersonID, int NowIam)
        {
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            SqlTransaction transaction = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_SalesServiceTransferInsert";

                cmd.Parameters.AddWithValue("@p_SalesServiceID", salesService.ID);
                cmd.Parameters["@p_SalesServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", salesService.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReturnedDate", salesService.ReturnedDate);
                cmd.Parameters["@p_ReturnedDate"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_SvcFactID", salesService.SvcFactID);
                //cmd.Parameters["@p_SvcFactID"].Direction = ParameterDirection.Input;
                              
                cmd.Parameters.AddWithValue("@p_Taker", salesService.Taker);
                cmd.Parameters["@p_Taker"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsReturned", salesService.IsReturned);
                cmd.Parameters["@p_IsReturned"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Wherami", salesService.Whereami);
                //cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsBackward", salesService.IsBackward);
                cmd.Parameters["@p_IsBackward"].Direction = ParameterDirection.Input;              

                cmd.Parameters.AddWithValue("@p_Qty", 1);
                cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                int? currentPlaceID = null;
                if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom)
                    currentPlaceID = serviceBatteryStatus.CurrentWarehouseID;
                else if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore)
                    currentPlaceID = serviceBatteryStatus.CurrentMainStoreID;
                else if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore)
                    currentPlaceID = serviceBatteryStatus.CurrentServiceTeamID;
                else
                    currentPlaceID = serviceBatteryStatus.CurrentVehicleID;

                if (serviceBatteryStatus.CurrentVehicleID == null) // Warehouse or Servie Team
                {                    
                    if (salesService.IsReturned)
                    {
                        cmd.Parameters.AddWithValue("@p_Date", salesService.ReturnedDate);
                        cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID);
                        cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", currentPlaceID);
                        cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                        cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_WarehouseID", null);
                        cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_VenID", null);
                        cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Whereami", (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
                        cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_FromStockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                        //cmd.Parameters["@p_FromStockBy"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_ToStockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                        //cmd.Parameters["@p_ToStockBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Customer);
                        cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_GiverID", salesService.GiverID);
                        cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@p_Date", salesService.ReturnedDate);
                        cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID);
                        cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", currentPlaceID);
                        cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                        cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_WarehouseID", TransportedWarehouseID);
                        cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_VenID", TransportedVenID);
                        cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Whereami", NowIam);
                        cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                        //cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                        // Checking Where to Transfer
                        if (TransportedVenID != null)
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Vehicle);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        else if (TransportedWarehouseID == 1)
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.MainStore);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        else if (TransportedWarehouseID == 2)
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }

                        cmd.Parameters.AddWithValue("@p_GiverID", SalePersonID);
                        cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;

                    }                    
                }
                else // vehicle
                {
                    if (salesService.IsReturned)
                    {
                        cmd.Parameters.AddWithValue("@p_Date", salesService.ReturnedDate);
                        cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID); // NOT necessary
                        cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", null);
                        cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                        cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_WarehouseID", null);
                        cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_VenID", null);
                        cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Whereami", (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
                        cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Service);
                        //cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Customer);
                        cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_GiverID", salesService.GiverID);
                        cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@p_Date", salesService.ReturnedDate);
                        cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", serviceBatteryStatus.CurrentWarehouseID);
                        cmd.Parameters.AddWithValue("@p_CurrentWarehouseID", DBNull.Value);
                        cmd.Parameters["@p_CurrentWarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_CurrentVenID", serviceBatteryStatus.CurrentVehicleID);
                        cmd.Parameters["@p_CurrentVenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_WarehouseID", TransportedWarehouseID);
                        cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_VenID", TransportedVenID);
                        cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Whereami", NowIam);
                        cmd.Parameters["@p_Whereami"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Service);
                        //cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                        // Checking Where to Transfer
                        if (TransportedVenID != null)
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Vehicle);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        else if (TransportedWarehouseID == 1)
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.MainStore);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        else if (TransportedWarehouseID == 2)
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                            cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        }
                        //if (salesService.Whereami == (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore)
                        //{
                        //    cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.ServiceTeamOrSubstore);
                        //    cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        //}
                        //else
                        //{
                        //    cmd.Parameters.AddWithValue("@p_Transfer", (int)PTIC.Common.Enum.SvcTransfer.Showroom);
                        //    cmd.Parameters["@p_Transfer"].Direction = ParameterDirection.Input;
                        //}

                        cmd.Parameters.AddWithValue("@p_GiverID", SalePersonID);
                        cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;
                    }
                }

                affectedrow += cmd.ExecuteNonQuery();
                transaction.Commit();
                //if (affectedrow < 1)
                //{
                //    transaction.Rollback();
                //    affectedrow = 0;
                //}

                
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }


        #endregion

        #region UPDATE
        public static int InsertReturn(SalesService salesService, int? VenID, int? WarehouseID, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            SqlTransaction transaction = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_SalesServiceReturnInsert";

                //cmd.Parameters.AddWithValue("@p_SvcFactID", salesService.SvcFactID);
                //cmd.Parameters["@p_SvcFactID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReturnedDate", salesService.ReturnedDate);
                cmd.Parameters["@p_ReturnedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GiverID", salesService.GiverID);
                cmd.Parameters["@p_GiverID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Taker", salesService.Taker);
                cmd.Parameters["@p_Taker"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", salesService.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Qty", -1);
                cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;
                               
                cmd.Parameters.AddWithValue("@p_IsReturned", true);
                cmd.Parameters["@p_IsReturned"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsBackward", true);
                cmd.Parameters["@p_IsBackward"].Direction = ParameterDirection.Input;

                if (VenID == null)
                {
                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Wherami", (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
                    cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Service);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Wherami", (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);
                    cmd.Parameters["@p_Wherami"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Service);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                }

                affectedrow += cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }
        #endregion

        #region SaleService Update
        public static int UpdateByID(SalesService saleService, ServicedCustomer servicedCustomer)
        {
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            SqlTransaction transaction = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_ServicedCustomerUpdate";

                cmd.Parameters.AddWithValue("@p_ServicedCustomerID", servicedCustomer.ID);
                cmd.Parameters["@p_ServicedCustomerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ShopName", servicedCustomer.ShopName);
                cmd.Parameters["@p_ShopName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", servicedCustomer.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                if (servicedCustomer.TownshipID != -1)
                {
                    cmd.Parameters.AddWithValue("@p_TownshipID", servicedCustomer.TownshipID);
                }
                else 
                {
                    cmd.Parameters.AddWithValue("@p_TownshipID", DBNull.Value);
                }
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "usp_SalesServiceUpdate";

                cmd.Parameters.AddWithValue("@p_SalesServiceID", saleService.ID);
                cmd.Parameters["@p_SalesServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContactDateToCustomer", saleService.ContactDateToCustomer);
                cmd.Parameters["@p_ContactDateToCustomer"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductionDate", saleService.ProductionDate);
                cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedDate", saleService.PurchaseDate);
                cmd.Parameters["@p_PurchasedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_JobNo", saleService.JobNo);
                cmd.Parameters["@p_JobNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_WarrantyNo", saleService.WarrantyNo);
                cmd.Parameters["@p_WarrantyNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RecieveVia", saleService.ReceiveVia);
                cmd.Parameters["@p_RecieveVia"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedDuration", saleService.UsedDuration);
                cmd.Parameters["@p_UsedDuration"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", saleService.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedAmp", saleService.UsedAmp);
                cmd.Parameters["@p_UsedAmp"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                transaction.Commit();
            }
            catch (Exception e)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }

        public static int UpdateServiceByID(SalesService saleService, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            int affectedrow = 0;
            SqlTransaction transaction = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_SalesServiceToCusUpdate";

                cmd.Parameters.AddWithValue("@p_SalesServiceID", saleService.ID);
                cmd.Parameters["@p_SalesServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Service", saleService.Service);
                cmd.Parameters["@p_Service"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }

        
       
        #endregion
    }
}
