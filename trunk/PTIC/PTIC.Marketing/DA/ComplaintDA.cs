using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class ComplaintDA
    {
        #region SELECT
        /// <summary>
        /// Retrieve all complaint from database
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all customers</returns>
        public static DataTable SelectAll(int ComplaintID,SqlConnection conn)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("ComplaintTable");
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_ComplaintSelectAllByComplaintID";

                command.Parameters.AddWithValue("@p_ComplaintID", ComplaintID);
                command.Parameters["@p_ComplaintID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }
        #endregion

        #region INSERT
        public static int Insert(Complaint complaint, ComplaintServiceRecord complaintsvrecord, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int insertedComplainID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_ComplaintInsert";

                cmd.Parameters.AddWithValue("@p_CusID", complaint.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", complaint.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", complaint.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", complaint.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ComplaintDate", complaint.ComplaintDate);
                cmd.Parameters["@p_ComplaintDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ComplaintPerson", complaint.ComplaintPerson);
                cmd.Parameters["@p_ComplaintPerson"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Post", complaint.Post);
                cmd.Parameters["@p_Post"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Description", complaint.Description);
                cmd.Parameters["@p_Description"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Request", complaint.Request);
                cmd.Parameters["@p_Request"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherRequirement", complaint.OtherRequirement);
                cmd.Parameters["@p_OtherRequirement"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CheckedPlaces", complaint.CheckedPlaces);
                cmd.Parameters["@p_CheckedPlaces"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedComplainID = (int)insertedIDObj;
                // clear parameters of usp_ComplaintInsert
                cmd.Parameters.Clear();
                // insert new Complaint

                cmd.CommandText = "usp_ComplaintServiceRecordInsert";

                cmd.Parameters.AddWithValue("@p_ComplaintID", insertedComplainID);
                cmd.Parameters["@p_ComplaintID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", complaintsvrecord.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", complaintsvrecord.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedDate", complaintsvrecord.PurchasedDate);
                cmd.Parameters["@p_PurchasedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedShop", complaintsvrecord.PurchasedShop);
                cmd.Parameters["@p_PurchasedShop"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPeriod", complaintsvrecord.UsedPeriod);
                cmd.Parameters["@p_UsedPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", complaintsvrecord.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductionDate", complaintsvrecord.ProductionDate);
                cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Volt", complaintsvrecord.Volt);
                cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChargingAmp", complaintsvrecord.ChargingAmp);
                cmd.Parameters["@p_ChargingAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OutAmp", complaintsvrecord.OutAmp);
                cmd.Parameters["@p_OutAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingAmp", complaintsvrecord.UsingAmp);
                cmd.Parameters["@p_UsingAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingSize", complaintsvrecord.UsingSize);
                cmd.Parameters["@p_UsingSize"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                // clear parameters of each usp_ComplaintServiceRecordInsert
                cmd.Parameters.Clear();

                // commit transaction
                transaction.Commit();

            }
            catch (SqlException Sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return insertedComplainID;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedComplainID;
        }
        #endregion


        #region UPDATE
        public static int Update(Complaint complaint, ComplaintServiceRecord complaintsvrecord, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int affectedRows = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_CustomerComplaintUpdateByCustomerComplaintID";

                cmd.Parameters.AddWithValue("@p_ComplaintID", complaint.ComplaintID);
                cmd.Parameters["@p_ComplaintID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", complaint.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", complaint.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", complaint.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", complaint.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ComplaintDate", complaint.ComplaintDate);
                cmd.Parameters["@p_ComplaintDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ComplaintPerson", complaint.ComplaintPerson);
                cmd.Parameters["@p_ComplaintPerson"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Post", complaint.Post);
                cmd.Parameters["@p_Post"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Description", complaint.Description);
                cmd.Parameters["@p_Description"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Request", complaint.Request);
                cmd.Parameters["@p_Request"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherRequirement", complaint.OtherRequirement);
                cmd.Parameters["@p_OtherRequirement"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CheckedPlaces", complaint.CheckedPlaces);
                cmd.Parameters["@p_CheckedPlaces"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                // clear parameters of usp_ComplaintInsert
                cmd.Parameters.Clear();
                // insert new Complaint

                cmd.CommandText = "usp_ComplaintServiceRecordUpdateByID";

                cmd.Parameters.AddWithValue("@p_CompetitorServiceRecordID", complaintsvrecord.ID);
                cmd.Parameters["@p_CompetitorServiceRecordID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ComplainID", complaintsvrecord.ComplainID);
                cmd.Parameters["@p_ComplainID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", complaintsvrecord.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", complaintsvrecord.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedDate", complaintsvrecord.PurchasedDate);
                cmd.Parameters["@p_PurchasedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedShop", complaintsvrecord.PurchasedShop);
                cmd.Parameters["@p_PurchasedShop"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPeriod", complaintsvrecord.UsedPeriod);
                cmd.Parameters["@p_UsedPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", complaintsvrecord.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductionDate", complaintsvrecord.ProductionDate);
                cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Volt", complaintsvrecord.Volt);
                cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChargingAmp", complaintsvrecord.ChargingAmp);
                cmd.Parameters["@p_ChargingAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OutAmp", complaintsvrecord.OutAmp);
                cmd.Parameters["@p_OutAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingAmp", complaintsvrecord.UsingAmp);
                cmd.Parameters["@p_UsingAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingSize", complaintsvrecord.UsingSize);
                cmd.Parameters["@p_UsingSize"].Direction = ParameterDirection.Input;
               
                affectedRows += cmd.ExecuteNonQuery();
                // clear parameters of each usp_ComplaintServiceRecordInsert
                cmd.Parameters.Clear();

                // commit transaction
                transaction.Commit();

            }
            catch (SqlException Sqle)
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
    }
}
