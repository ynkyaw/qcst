using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class TenderProductDA
    {
        #region SELECT
        internal static DataTable GetTenderProductByID(int? tenderInfoID, SqlConnection conn)
        {
              DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TenderProductSelectByID";

                command.Parameters.AddWithValue("@p_tenderinfoID", tenderInfoID);
                command.Parameters["@p_tenderinfoID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "TenderProductTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["TenderProductTable"];
            
        }            
        #endregion

        #region INSERT
        public static int Insert(List<TenderProducts> newTenderProducts, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderProductInsert";

                foreach (TenderProducts tenderProduct in newTenderProducts)
                {
                    cmd.Parameters.AddWithValue("@p_TenderInfoID", tenderProduct.TenderInfoID);
                    cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TProductName", tenderProduct.TproductName);
                    cmd.Parameters["@p_TProductName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TQty", tenderProduct.Tqty);
                    cmd.Parameters["@p_TQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TPrice", tenderProduct.Tprice);
                    cmd.Parameters["@p_TPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TotalPrice", tenderProduct.TotalPrice);
                    cmd.Parameters["@p_TotalPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_remark", tenderProduct.Remark);
                    cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TenderProductInsert
                    cmd.Parameters.Clear();
                }
                //  return cmd.ExecuteNonQuery();
                return affectedRows;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #endregion

        #region UPDATE

        public static int UpdateByTenderProductID(List<TenderProducts> mdTenderProducts, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderProductUpdateByTenderProductID";

                foreach (TenderProducts tenderProduct in mdTenderProducts)
                {
                    cmd.Parameters.AddWithValue("@p_TenderProductID", tenderProduct.ID);
                    cmd.Parameters["@p_TenderProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TenderInfoID", tenderProduct.TenderInfoID);
                    cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TProductName", tenderProduct.TproductName);
                    cmd.Parameters["@p_TProductName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TQty", tenderProduct.Tqty);
                    cmd.Parameters["@p_TQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TPrice", tenderProduct.Tprice);
                    cmd.Parameters["@p_TPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TotalPrice", tenderProduct.TotalPrice);
                    cmd.Parameters["@p_TotalPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_remark", tenderProduct.Remark);
                    cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TenderProductUpdateByTenderProductID
                    cmd.Parameters.Clear();
                }
                //  return cmd.ExecuteNonQuery();
                return affectedRows;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #endregion

        #region DELETE

        public static int DeleteByTenderProductID(List<TenderProducts> TenderProducts, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderProductDeleteByTenderProductID";

                foreach (TenderProducts tenderProduct in TenderProducts)
                {

                    cmd.Parameters.AddWithValue("@p_TenderProductID", tenderProduct.ID);
                    cmd.Parameters["@p_TenderProductID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear@p_TenderProductID parameters of each usp_TenderProductDeleteByTenderProductID
                    cmd.Parameters.Clear();
                }
                return affectedRows;

                // return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #endregion
    }
}
