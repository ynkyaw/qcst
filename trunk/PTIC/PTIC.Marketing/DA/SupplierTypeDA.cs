/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   SupplierTypeDA
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
    class SupplierTypeDA
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
                command.CommandText = "usp_SupplierTypeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "SupplierTypeTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["SupplierTypeTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(SupplierType supplierType)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SupplierTypeInsert";

                cmd.Parameters.AddWithValue("@p_SupplierType", supplierType.SupplierTypeName);
                cmd.Parameters["@p_SupplierType"].Direction = ParameterDirection.Input;
                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(SupplierType supplierType)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SupplierTypeUpdateByID";

                cmd.Parameters.AddWithValue("@p_SupplierTypeID", supplierType.SupplierTypeID);
                cmd.Parameters["@p_SupplierTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SupplierType", supplierType.SupplierTypeName);
                cmd.Parameters["@p_SupplierType"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(SupplierType supplierType, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SupplierTypeDeleteByID";

                cmd.Parameters.AddWithValue("@p_SupplierTypeID", supplierType.SupplierTypeID);
                cmd.Parameters["@p_SupplierTypeID"].Direction = ParameterDirection.Input;

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
