using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class DeliveryNoteDA
    {
        public static BaseDAO b = new BaseDAO();
        #region SELECT        
        public static DataTable SelectByDeliveryID(DeliveryNote deliverynote, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "DeliveryNoteTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliveryNoteSelect";

                command.Parameters.AddWithValue("@p_Date", deliverynote.Date);
                command.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_SalePersonID", deliverynote.EmpID);
                command.Parameters["@p_SalePersonID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_VenID", deliverynote.VenID);
                command.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectDeliveryNoteByDate(DeliveryNote deliverynote)
        {
            DataTable dt;
            string tableName = "DeliveryNote";
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            SqlCommand cmd = null;
            try
            {
                dt = new DataTable(tableName);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryNoteSelectByDate";

                cmd.Parameters.AddWithValue("@p_VenID",deliverynote.VenID);
                cmd.Parameters.AddWithValue("@p_SalesPersonID", deliverynote.EmpID);
                cmd.Parameters.AddWithValue("@p_Date", deliverynote.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                //string SqlQuery = ;

                //dt = b.SelectByQuery(string.Format(SqlQuery,deliverynote.EmpID,deliverynote.Date.ToString("yyyy-MM-dd"),deliverynote.VenID));
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;

        }
        #endregion

        #region SELECT
        public static DataTable SelectByDate(DeliveryNote deliverynote)
        {
            DataTable table = null;
            string tableName = "DeliveryNoteTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliveryNoteSelectFromOrigin";

                command.Parameters.AddWithValue("@p_Date", deliverynote.Date);
                command.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_SalePersonID", deliverynote.EmpID);
                command.Parameters["@p_SalePersonID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_VenID", deliverynote.VenID);
                command.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

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

        #region SELECT
        public static DataTable SelectByDeliveryID(int DeliveryNoteID)
        {
            DataTable table = null;
            string tableName = "DeliveryNoteTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliveryNoteSelectDetailFromOrigin";

                command.Parameters.AddWithValue("@p_DeliveryNoteID", DeliveryNoteID);
                command.Parameters["@p_DeliveryNoteID"].Direction = ParameterDirection.Input;
                
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <param name="newSaleDetailRecords"></param>
        /// <param name="conn"></param>
        /// <returns>Return an inserted Invoice</returns>
        public static int? Insert(DeliveryNote newDeliveryNote, List<DeliveryNoteDetail> newDeliveryNoteDetailRecords,int WarehouseID)
        {
            SqlTransaction transaction = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            int? insertedDeliveryNoteID = null;
            int affectedrow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new MobileServiceDetail
                cmd.CommandText = "usp_DeliveryNoteInsert";

                cmd.Parameters.AddWithValue("@p_VenID", newDeliveryNote.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newDeliveryNote.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;
                                
                cmd.Parameters.AddWithValue("@p_Date", newDeliveryNote.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;


                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedDeliveryNoteID = (int)insertedIDObj;
                // clear parameters of usp_MobileServiceDetailInsert
                cmd.Parameters.Clear();
                // insert new MobileServiceRecord
                cmd.CommandText = "usp_DeliveryNoteDetailInsert";

                foreach (DeliveryNoteDetail newDeliveryNoteDetailRecord in newDeliveryNoteDetailRecords)
                {
                    //cmd.Parameters.AddWithValue("@p_PreVenID", PreVenID);
                    //cmd.Parameters["@p_PreVenID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_PreEmpID", PreEmpID);
                    //cmd.Parameters["@p_PreEmpID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DeliveryNoteID", insertedDeliveryNoteID);
                    cmd.Parameters["@p_DeliveryNoteID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newDeliveryNoteDetailRecord.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DeliveryQty", newDeliveryNoteDetailRecord.DeliveryQty);
                    cmd.Parameters["@p_DeliveryQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WareHouseQty", newDeliveryNoteDetailRecord.WareHouseQty);
                    cmd.Parameters["@p_WareHouseQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ExtraQty", newDeliveryNoteDetailRecord.ExtraQty);
                    cmd.Parameters["@p_ExtraQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_VenID", newDeliveryNote.VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_EmpID", newDeliveryNote.EmpID);
                    cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Date", newDeliveryNote.Date);
                    cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Warehouse);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockByVehicle", (int)PTIC.Common.Enum.WarehouseStockBy.Vehicle);
                    cmd.Parameters["@p_StockByVehicle"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", string.Empty);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_MobileServiceRecordInsert
                    cmd.Parameters.Clear();
                }

                //if (deliveryList !=null)
                //{
                //    //  Update VenID in Delivery
                //    cmd.CommandText = "usp_DeliveryVenIDUpdateByID";
                //    foreach (Delivery list in deliveryList)
                //    {
                //        cmd.Parameters.AddWithValue("@p_DeliveryID", list.ID);
                //        cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                //        cmd.Parameters.AddWithValue("@p_VenID", newDeliveryNote.VenID);
                //        cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                //        affectedrow += cmd.ExecuteNonQuery();
                //        // clear parameters of each usp_MobileServiceRecordInsert
                //        cmd.Parameters.Clear();
                //    }
                //}


                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedrow=0;
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

        #region DELETE
        public static int DeleteByDeliveryDetailID(int DeliveryDetailID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryNoteDetailDeleteByDeliveryNoteDetailID";

                cmd.Parameters.AddWithValue("@p_DeliveryNoteDetialID", DeliveryDetailID);
                cmd.Parameters["@p_DeliveryNoteDetialID"].Direction = ParameterDirection.Input;

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
