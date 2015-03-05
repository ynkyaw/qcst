/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   SupplierDA
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
    class SupplierDA
    { //

        #region SelectAll

        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SupplierSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "SupplierTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["SupplierTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(Supplier supplier)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SupplierInsert";

                cmd.Parameters.AddWithValue("@p_SupTypeID", supplier.SupTypeID);
                cmd.Parameters["@p_SupTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AddrID", supplier.Address);
                cmd.Parameters["@p_AddrID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SupplierName", supplier.SupplierName);
                cmd.Parameters["@p_SupplierName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContactPerson", supplier.ContactPerson);
                cmd.Parameters["@p_ContactPerson"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContatPhone", supplier.ContactPhone);
                cmd.Parameters["@p_ContatPhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", supplier.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", supplier.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Supplier supplier)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SupplierUpdateByID";

                cmd.Parameters.AddWithValue("@p_SupplierID", supplier.SupplierID);
                cmd.Parameters["@p_SupplierID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SupTypeID", supplier.SupTypeID);
                cmd.Parameters["@p_SupTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AddrID", supplier.Address);
                cmd.Parameters["@p_AddrID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SupplierName", supplier.SupplierName);
                cmd.Parameters["@p_SupplierName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContactPerson", supplier.ContactPerson);
                cmd.Parameters["@p_ContactPerson"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContatPhone", supplier.ContactPhone);
                cmd.Parameters["@p_ContatPhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", supplier.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", supplier.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;


                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Supplier supplier)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SupplierDeleteByID";

                cmd.Parameters.AddWithValue("@p_SupplierID", supplier.SupplierID);
                cmd.Parameters["@p_SupplierID"].Direction = ParameterDirection.Input;

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
