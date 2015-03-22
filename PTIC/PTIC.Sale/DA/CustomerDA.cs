/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Customer data access class
 */
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
    /// <summary>
    /// Customer data access
    /// </summary>
    public class CustomerDA
    {
        static BaseDAO b = new BaseDAO();

        #region Searching
        public static DataTable SearchBy3Fields(int TripOrRouteID, int TownORTownshipID, String CustomerName)
        {
            DataTable dt;
            dt = b.SelectByQuery("SELECT * FROM uv_Customers"
                                                + "WHERE RouteID =" + TripOrRouteID + "AND TownID =" + TownORTownshipID + "AND CusName LIKE N" + "'%" + CustomerName + "%'");
            return dt;
        }
        /// <summary>
        /// All Route that Contain Township in Yangon
        /// </summary>
        /// <returns></returns>
        public static DataTable SearchAllRoute()
        {
            try
            {
                DataTable dt;
                dt = b.SelectByQuery("SELECT * FROM uv_Customers WHERE RouteID IS NOT NULL");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// All Trip Select
        /// </summary>
        /// <returns></returns>
        public static DataTable SearchAllTrip()
        {
            try
            {
                DataTable dt;
                dt = b.SelectByQuery("SELECT * FROM uv_Customers WHERE TripID IS NOT NULL");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchByCustomer(String CustomerName)
        {
            try
            {
                DataTable dt;
                dt = b.SelectByQuery("SELECT * FROM uv_Customers WHERE CusName LIKE N" + "'%" + CustomerName + "%'");
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region SELECT
        /// <summary>
        /// Select all customer Type
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectAllCusType()
        {
            DataTable dtCustomerType;
            try
            {
                dtCustomerType = b.SelectAll("CustomerType");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtCustomerType;
        }

        /// <summary>
        /// Retrieve all customers from database
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all customers</returns>
        public static DataTable SelectAll()
        {
            DataTable table = null;
            try
            {
                table = new DataTable("CustomerTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CustomerSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return table;
        }

        /// <summary>
        /// Retrieve all customers from database
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all customers</returns>
        public static DataTable SelectAllByCusID(int CusID)
        {
            DataTable table = null;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable("CustomerTable");
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CustomerSelectAllByCusID";

                command.Parameters.AddWithValue("@p_CusID", CusID);
                command.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }

        public static DataTable SelectCusTypeInTownship()
        {
            DataTable table = null;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable("CustomerTypeInTownshipTable");
                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                command.CommandText = "SELECT cus.CusType, cus_type.CusTypeName, addr.TownshipID FROM Customer cus"
                                                        + " INNER JOIN Address addr ON addr.ID = cus.AddrID"
                                                        + " INNER JOIN CustomerType cus_type ON cus_type.ID = cus.CusType"
                                                        + " GROUP BY CusType, cus_type.CusTypeName, addr.TownshipID";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectCusTypeInTown()
        {
            DataTable table = null;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable("CustomerTypeInTownTable");
                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                command.CommandText = "SELECT cus.CusType, cus_type.CusTypeName, addr.TownID FROM Customer cus"
                                                        + " INNER JOIN Address addr ON addr.ID = cus.AddrID"
                                                        + " INNER JOIN CustomerType cus_type ON cus_type.ID = cus.CusType"
                                                        + " GROUP BY CusType, cus_type.CusTypeName, addr.TownID";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        /// <summary>
        /// Retrieve photos of a specific customer
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <returns>DataTable containing photos</returns>
        public static DataTable SelectPhotos(int customerID)
        {
            string queryString = string.Format("SELECT Photo1, Photo2, Photo3, Photo4, Photo5 FROM Customer WHERE ID = {0}", customerID);
            return new BaseDAO().SelectByQuery(queryString);
        }

        public static DataTable SelectByRoutID(int routeID)
        {
            string queryString = string.Format("SELECT * FROM uv_Customers WHERE RouteID = {0}", routeID);
            return new BaseDAO().SelectByQuery(queryString);
        }

        public static DataTable SelectByTripID(int tripID)
        {
            string queryString = string.Format("SELECT * FROM uv_Customers WHERE TripID = {0}", tripID);
            return new BaseDAO().SelectByQuery(queryString);
        }

        public static DataTable SelectAllCustomer()
        {
            DataTable dtCusomter;
            try
            {
                string query = "SELECT * FROM uv_Customers";
                dtCusomter = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dtCusomter;
        }

        public static DataTable GetAllCustomerByCustomerType(string custType)
        {
            DataTable dtCusomter;
            try
            {
                string query = @"SELECT c.[ID],[AddrID],[RouteID],[BankID],[TripID],[CusType],[CusClassID],[CusCode],[CusName],[Phone1],[Phone2],[Fax]
                                ,[Email],[Website],[BankAccNo],[CreditAmount],[CreditLimit],[CusDate],[Photo1],[Photo2],[Photo3],[Photo4],[Photo5],[IsPotential]
                                ,[IsMain],[IsDevice],[Remark],c.[DateAdded],c.[LastModified],c.[IsDeleted],townshipId FROM [Customer] c,[Address] a
                                WHERE c.AddrID = a.ID AND  a.TownshipID is not null AND c.CusType="+custType;
                dtCusomter = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dtCusomter;
        }


        

        #endregion

        #region INSERT
        /// <summary>
        /// Insert a new customer into database
        /// </summary>
        /// <param name="newCustomer">New customer entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return inserted customer ID</returns>
        public static int Insert(Customer newCustomer,
            Address newaddress,
            ContactPerson contactperson,
            Address contactaddress,
            Owner owner,
            Address owneraddress)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int insertedCusID = 0;
            int affectedrow = 0;

            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_CustomerInsert";

                cmd.Parameters.AddWithValue("@p_RouteID", newCustomer.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankID", newCustomer.BankID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripID", newCustomer.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusType", newCustomer.CusType);
                cmd.Parameters["@p_CusType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusClassID", newCustomer.CusClassID);
                cmd.Parameters["@p_CusClassID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_CusCode", newCustomer.CusCode);
                //cmd.Parameters["@p_CusCode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusName", newCustomer.CusName);
                cmd.Parameters["@p_CusName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", newCustomer.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", newCustomer.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Fax", newCustomer.Fax);
                cmd.Parameters["@p_Fax"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Email", newCustomer.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Website", newCustomer.Website);
                cmd.Parameters["@p_Website"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankAccNo", newCustomer.BankAccNo);
                cmd.Parameters["@p_BankAccNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CreditAmount", newCustomer.CreditAmount);
                cmd.Parameters["@p_CreditAmount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CreditLimit", newCustomer.CreditLimit);
                cmd.Parameters["@p_CreditLimit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusDate", newCustomer.CusDate);
                cmd.Parameters["@p_CusDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo1", newCustomer.Photo1);
                cmd.Parameters["@p_Photo1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo2", newCustomer.Photo2);
                cmd.Parameters["@p_Photo2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo3", newCustomer.Photo3);
                cmd.Parameters["@p_Photo3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo4", newCustomer.Photo4);
                cmd.Parameters["@p_Photo4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo5", newCustomer.Photo5);
                cmd.Parameters["@p_Photo5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsPotential", newCustomer.IsPotential);
                cmd.Parameters["@p_IsPotential"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", newCustomer.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", newCustomer.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newCustomer.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", newaddress.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", newaddress.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StateDivisionID", newaddress.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Hno", newaddress.Hno);
                cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Street", newaddress.Street);
                cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Quartar", newaddress.Quartar);
                cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Country", newaddress.Country);
                cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedCusID = (int)insertedIDObj;
                // clear parameters of usp_CustomerInsert
                cmd.Parameters.Clear();
                // insert new Customer

                cmd.CommandText = "usp_ContactPersonInsert";

                cmd.Parameters.AddWithValue("@p_CusID", insertedCusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ConPersonName", contactperson.ContactPersonName);
                cmd.Parameters["@p_ConPersonName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DOB", contactperson.DOB);
                cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_NRC", contactperson.NRC);
                cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Post", contactperson.Post);
                cmd.Parameters["@p_Post"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Email", contactperson.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MobilePhone", contactperson.MobilePhone);
                cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_HomePhone", contactperson.HomePhone);
                cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Membership", contactperson.Membership);
                cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Education", contactperson.Education);
                cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SpouseName", contactperson.SpouseName);
                cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Race", contactperson.Race);
                cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Religion", contactperson.Religion);
                cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", contactperson.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", contactaddress.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", contactaddress.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StateDivisionID", contactaddress.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Hno", contactaddress.Hno);
                cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Street", contactaddress.Street);
                cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Quartar", contactaddress.Quartar);
                cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Country", contactaddress.Country);
                cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                // clear parameters of each usp_ContactPersonInsert
                cmd.Parameters.Clear();

                // Owner Information
                cmd.CommandText = "usp_OwnerInsert";

                cmd.Parameters.AddWithValue("@p_CusID", insertedCusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OwnerName", owner.OwnerName);
                cmd.Parameters["@p_OwnerName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DOB", owner.DOB);
                cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_NRC", owner.NRC);
                cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Fax", owner.Fax);
                cmd.Parameters["@p_Fax"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MobilePhone", owner.MobilePhone);
                cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_HomePhone", owner.HomePhone);
                cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Membership", owner.Membership);
                cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Education", owner.Education);
                cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherBussiness", owner.OtherBussiness);
                cmd.Parameters["@p_OtherBussiness"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SpouseName", owner.SpouseName);
                cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Race", owner.Race);
                cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Religion", owner.Religion);
                cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", owner.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", owneraddress.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", owneraddress.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StateDivisionID", owneraddress.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Hno", owneraddress.Hno);
                cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Street", owneraddress.Street);
                cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Quartar", owneraddress.Quartar);
                cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Country", owneraddress.Country);
                cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                // clear parameters of each usp_ContactPersonInsert
                cmd.Parameters.Clear();

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    //return affectedrow;
                    return insertedCusID;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                DBManager.GetInstance().CloseDbConnection();
            }
            //return affectedrow;
            return insertedCusID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <param name="newaddress"></param>
        /// <param name="contactperson"></param>
        /// <param name="conn"></param>
        /// <returns>A new inserted customer ID</returns>
        public static int Insert(Customer newCustomer, Address newaddress, ContactPerson contactperson)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int insertedCusID = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_CustomerInsert";

                cmd.Parameters.AddWithValue("@p_RouteID", newCustomer.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankID", newCustomer.BankID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripID", newCustomer.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusType", newCustomer.CusType);
                cmd.Parameters["@p_CusType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusClassID", newCustomer.CusClassID);
                cmd.Parameters["@p_CusClassID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusName", newCustomer.CusName);
                cmd.Parameters["@p_CusName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", newCustomer.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", newCustomer.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Fax", newCustomer.Fax);
                cmd.Parameters["@p_Fax"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Email", newCustomer.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Website", newCustomer.Website);
                cmd.Parameters["@p_Website"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankAccNo", newCustomer.BankAccNo);
                cmd.Parameters["@p_BankAccNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CreditAmount", newCustomer.CreditAmount);
                cmd.Parameters["@p_CreditAmount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CreditLimit", newCustomer.CreditLimit);
                cmd.Parameters["@p_CreditLimit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusDate", newCustomer.CusDate);
                cmd.Parameters["@p_CusDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo1", newCustomer.Photo1);
                cmd.Parameters["@p_Photo1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo2", newCustomer.Photo2);
                cmd.Parameters["@p_Photo2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo3", newCustomer.Photo3);
                cmd.Parameters["@p_Photo3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo4", newCustomer.Photo4);
                cmd.Parameters["@p_Photo4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo5", newCustomer.Photo5);
                cmd.Parameters["@p_Photo5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsPotential", newCustomer.IsPotential);
                cmd.Parameters["@p_IsPotential"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", newCustomer.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", newCustomer.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newCustomer.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", newaddress.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", newaddress.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StateDivisionID", newaddress.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Hno", newaddress.Hno);
                cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Street", newaddress.Street);
                cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Quartar", newaddress.Quartar);
                cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Country", newaddress.Country);
                cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedCusID = (int)insertedIDObj;
                // clear parameters of usp_CustomerInsert
                cmd.Parameters.Clear();
                // insert a new contact person
                cmd.CommandText = "usp_ContactPersonInsert";

                cmd.Parameters.AddWithValue("@p_CusID", insertedCusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ConPersonName", contactperson.ContactPersonName);
                cmd.Parameters["@p_ConPersonName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DOB", contactperson.DOB);
                cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_NRC", contactperson.NRC);
                cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Post", contactperson.Post);
                cmd.Parameters["@p_Post"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Email", contactperson.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MobilePhone", contactperson.MobilePhone);
                cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_HomePhone", contactperson.HomePhone);
                cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Membership", contactperson.Membership);
                cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Education", contactperson.Education);
                cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SpouseName", contactperson.SpouseName);
                cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Race", contactperson.Race);
                cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Religion", contactperson.Religion);
                cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", contactperson.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

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
                DBManager.GetInstance().CloseDbConnection();
            }
            return insertedCusID;
        }

        #endregion

        #region UPDATE
        /// <summary>
        /// Update an existing customer by customer ID
        /// </summary>
        /// <param name="mdCustomer">Customer to be updated</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public static int UpdateByCustomerID(Customer mdCustomer,
            Address newaddress, Owner owner, Address owneraddress, ContactPerson contactperson, Address contactaddress)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_CustomerUpdateByCustomerID";

                cmd.Parameters.AddWithValue("@p_CustomerID", mdCustomer.ID);
                cmd.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AddrID", mdCustomer.AddrID);
                cmd.Parameters["@p_AddrID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteID", mdCustomer.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankID", mdCustomer.BankID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripID", mdCustomer.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusTypeID", mdCustomer.CusType);
                cmd.Parameters["@p_CusTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusClassID", mdCustomer.CusClassID);
                cmd.Parameters["@p_CusClassID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_CusCode", mdCustomer.CusCode);
                //cmd.Parameters["@p_CusCode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusName", mdCustomer.CusName);
                cmd.Parameters["@p_CusName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", mdCustomer.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", mdCustomer.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Fax", mdCustomer.Fax);
                cmd.Parameters["@p_Fax"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Email", mdCustomer.Email);
                cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Website", mdCustomer.Website);
                cmd.Parameters["@p_Website"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankAccNo", mdCustomer.BankAccNo);
                cmd.Parameters["@p_BankAccNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CreditAmount", mdCustomer.CreditAmount);
                cmd.Parameters["@p_CreditAmount"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CreditLimit", mdCustomer.CreditLimit);
                cmd.Parameters["@p_CreditLimit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusDate", mdCustomer.CusDate);
                cmd.Parameters["@p_CusDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo1", mdCustomer.Photo1);
                cmd.Parameters["@p_Photo1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo2", mdCustomer.Photo2);
                cmd.Parameters["@p_Photo2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo3", mdCustomer.Photo3);
                cmd.Parameters["@p_Photo3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo4", mdCustomer.Photo4);
                cmd.Parameters["@p_Photo4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Photo5", mdCustomer.Photo5);
                cmd.Parameters["@p_Photo5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsPotential", mdCustomer.IsPotential);
                cmd.Parameters["@p_IsPotential"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", mdCustomer.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", mdCustomer.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", mdCustomer.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", newaddress.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", newaddress.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StateDivisionID", newaddress.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Hno", newaddress.Hno);
                cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Street", newaddress.Street);
                cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Quartar", newaddress.Quartar);
                cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Country", newaddress.Country);
                cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                // Owner Information
                if (owner.OwnerID > 0)
                {
                    cmd.CommandText = "usp_OwnerUpdateByOwnerID";

                    cmd.Parameters.AddWithValue("@p_OwnerID", owner.OwnerID);
                    cmd.Parameters["@p_OwnerID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CusID", owner.CusID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AddrID", owner.AddrID);
                    cmd.Parameters["@p_AddrID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OwnerName", owner.OwnerName);
                    cmd.Parameters["@p_OwnerName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DOB", owner.DOB);
                    cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NRC", owner.NRC);
                    cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Fax", owner.Fax);
                    cmd.Parameters["@p_Fax"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MobilePhone", owner.MobilePhone);
                    cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_HomePhone", owner.HomePhone);
                    cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Membership", owner.Membership);
                    cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Education", owner.Education);
                    cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OtherBussiness", owner.OtherBussiness);
                    cmd.Parameters["@p_OtherBussiness"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SpouseName", owner.SpouseName);
                    cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Race", owner.Race);
                    cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Religion", owner.Religion);
                    cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", owner.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownID", owneraddress.TownID);
                    cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", owneraddress.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StateDivisionID", owneraddress.StateDivisionID);
                    cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Hno", owneraddress.Hno);
                    cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Street", owneraddress.Street);
                    cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Quartar", owneraddress.Quartar);
                    cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_ContactPersonInsert
                    cmd.Parameters.Clear();
                }
                else       
                {
                    // Owner Information
                    cmd.CommandText = "usp_OwnerInsert";

                    cmd.Parameters.AddWithValue("@p_CusID", mdCustomer.ID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OwnerName", owner.OwnerName);
                    cmd.Parameters["@p_OwnerName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DOB", owner.DOB);
                    cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NRC", owner.NRC);
                    cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Fax", owner.Fax);
                    cmd.Parameters["@p_Fax"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MobilePhone", owner.MobilePhone);
                    cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_HomePhone", owner.HomePhone);
                    cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Membership", owner.Membership);
                    cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Education", owner.Education);
                    cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OtherBussiness", owner.OtherBussiness);
                    cmd.Parameters["@p_OtherBussiness"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SpouseName", owner.SpouseName);
                    cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Race", owner.Race);
                    cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Religion", owner.Religion);
                    cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", owner.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownID", owneraddress.TownID);
                    cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", owneraddress.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StateDivisionID", owneraddress.StateDivisionID);
                    cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Hno", owneraddress.Hno);
                    cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Street", owneraddress.Street);
                    cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Quartar", owneraddress.Quartar);
                    cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Country", owneraddress.Country);
                    cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_ContactPersonInsert
                    cmd.Parameters.Clear();
                }

                // Customer Update OR Insert
                if (contactperson.ID > 0)
                {
                    cmd.CommandText = "usp_ContactPersonUpdateByContactPeronsID";

                    cmd.Parameters.AddWithValue("@p_ContactPersonID", contactperson.ID);
                    cmd.Parameters["@p_ContactPersonID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CusID", contactperson.CusID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AddrID", contactperson.AddrID);
                    cmd.Parameters["@p_AddrID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ConPersonName", contactperson.ContactPersonName);
                    cmd.Parameters["@p_ConPersonName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DOB", contactperson.DOB);
                    cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NRC", contactperson.NRC);
                    cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Post", contactperson.Post);
                    cmd.Parameters["@p_Post"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Email", contactperson.Email);
                    cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MobilePhone", contactperson.MobilePhone);
                    cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_HomePhone", contactperson.HomePhone);
                    cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Membership", contactperson.Membership);
                    cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Education", contactperson.Education);
                    cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SpouseName", contactperson.SpouseName);
                    cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Race", contactperson.Race);
                    cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Religion", contactperson.Religion);
                    cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", contactperson.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownID", contactaddress.TownID);
                    cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", contactaddress.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StateDivisionID", contactaddress.StateDivisionID);
                    cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Hno", contactaddress.Hno);
                    cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Street", contactaddress.Street);
                    cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Quartar", contactaddress.Quartar);
                    cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Country", contactaddress.Country);
                    cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_ContactPersonInsert
                    cmd.Parameters.Clear();

                }
                else
                {
                    cmd.CommandText = "usp_ContactPersonInsert";

                    cmd.Parameters.AddWithValue("@p_CusID", mdCustomer.ID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ConPersonName", contactperson.ContactPersonName);
                    cmd.Parameters["@p_ConPersonName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DOB", contactperson.DOB);
                    cmd.Parameters["@p_DOB"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NRC", contactperson.NRC);
                    cmd.Parameters["@p_NRC"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Post", contactperson.Post);
                    cmd.Parameters["@p_Post"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Email", contactperson.Email);
                    cmd.Parameters["@p_Email"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MobilePhone", contactperson.MobilePhone);
                    cmd.Parameters["@p_MobilePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_HomePhone", contactperson.HomePhone);
                    cmd.Parameters["@p_HomePhone"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Membership", contactperson.Membership);
                    cmd.Parameters["@p_Membership"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Education", contactperson.Education);
                    cmd.Parameters["@p_Education"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SpouseName", contactperson.SpouseName);
                    cmd.Parameters["@p_SpouseName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Race", contactperson.Race);
                    cmd.Parameters["@p_Race"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Religion", contactperson.Religion);
                    cmd.Parameters["@p_Religion"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", contactperson.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownID", contactaddress.TownID);
                    cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", contactaddress.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StateDivisionID", contactaddress.StateDivisionID);
                    cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Hno", contactaddress.Hno);
                    cmd.Parameters["@p_Hno"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Street", contactaddress.Street);
                    cmd.Parameters["@p_Street"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Quartar", contactaddress.Quartar);
                    cmd.Parameters["@p_Quartar"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Country", contactaddress.Country);
                    cmd.Parameters["@p_Country"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_ContactPersonInsert
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
                    return affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRows;
        }

        /// <summary>
        /// Set NULL to value of a specific field by customer ID
        /// </summary>
        /// <param name="columnName">To column</param>
        /// <param name="customerID">By Customer ID</param>
        /// <returns>Return number of rows affected</returns>
        public static int DeletePhotoBy(string columnName, int customerID)
        {
            return new BaseDAO().ExecuteNonQuery(string.Format("UPDATE Customer SET {0} = NULL WHERE ID = {1}", columnName, customerID));
        }

        #endregion

        #region DELETE
        /// <summary>
        /// Delete customer from database by customer ID
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <returns>Return affected row count</returns>
        public static int DeleteByCustomerID(int customerID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CustomerDeleteByCustomerID";

                cmd.Parameters.AddWithValue("@p_CustomerID", customerID);
                cmd.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;

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
