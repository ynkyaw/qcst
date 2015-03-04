/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   PackingDiscountDA ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;

namespace PTIC.Sale.DA
{
    public class PackingDiscountDA
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
                command.CommandText = "usp_PackingDiscountSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "PackingDiscountTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["PackingDiscountTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(PackingDiscount packingdiscount, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PackingDiscountInsert";

                cmd.Parameters.AddWithValue("@p_ProductID", packingdiscount.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AmtPerPack", packingdiscount.AmtPerPack);
                cmd.Parameters["@p_AmtPerPack"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PackQty", packingdiscount.PackQty);
                cmd.Parameters["@p_PackQty"].Direction = ParameterDirection.Input;
                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(PackingDiscount packingdiscount, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PackingDiscountUpdate";

                cmd.Parameters.AddWithValue("@p_PackingDiscountID", packingdiscount.PackingDiscountID);
                cmd.Parameters["@p_PackingDiscountID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", packingdiscount.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AmtPerPack", packingdiscount.AmtPerPack);
                cmd.Parameters["@p_AmtPerPack"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PackQty", packingdiscount.PackQty);
                cmd.Parameters["@p_PackQty"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(PackingDiscount packingdiscount, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PackingDiscountDelete";

                cmd.Parameters.AddWithValue("@p_PackingDiscountID", packingdiscount.PackingDiscountID);
                cmd.Parameters["@p_PackingDiscountID"].Direction = ParameterDirection.Input;

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
