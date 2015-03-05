/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   ProductDA ( Insert , Update , Delete , SelectAll}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class ProductDA
    {
        #region SELECT

        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_ProductSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "ProductTable");
            }
            catch (SqlException sqle)
            {
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return dataSet.Tables["ProductTable"];
        }

        public static DataTable SelectWithPrice()
        {
            DataTable table = null;
            string tableName = "ProductWithPriceTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_ProductWithPriceSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectPriceList()
        {
            string queryString = "SELECT" +
                                            " ProductID, BrandID, ProductName, BrandName," +
                                            " Plate, AcidPrice," +
                                            " WSPrice, RSPrice," +
                                            " WSPriceWithAcid," +
                                            " RSPriceWithAcid" +
                                          " FROM uv_Product";
            return new BaseDAO().SelectByQuery(queryString);
        }
        #endregion

        #region INSERT
        public static int Insert(Product product, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ProductInsert";

                cmd.Parameters.AddWithValue("@p_sub_category_id", product.SubCategoryID);
                cmd.Parameters["@p_sub_category_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FormulaID", product.FormulaID);
                cmd.Parameters["@p_FormulaID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_productname", product.ProductName);
                cmd.Parameters["@p_productname"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_productcode", product.ProductCode);
                //cmd.Parameters["@p_productcode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_usedplace", product.UsedPlace);
                cmd.Parameters["@p_usedplace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_noperpack", product.NoPerPack);
                cmd.Parameters["@p_noperpack"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conlength", product.ConLength);
                cmd.Parameters["@p_conlength"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conbase", product.ConBase);
                cmd.Parameters["@p_conbase"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conheight", product.ConHeight);
                cmd.Parameters["@p_conheight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conthick", product.ConThick);
                cmd.Parameters["@p_conthick"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_minorderqty", product.MinOrderQty);
                cmd.Parameters["@p_minorderqty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_volt", product.Volt);
                cmd.Parameters["@p_volt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_plate", product.Plate);
                cmd.Parameters["@p_plate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_amps", product.Amps);
                cmd.Parameters["@p_amps"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_acid", product.Acid);
                cmd.Parameters["@p_acid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_freeconweight", product.FreeConWeight);
                cmd.Parameters["@p_freeconweight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_leadweight", product.LeadWeight);
                cmd.Parameters["@p_leadweight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", product.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_hasDiscount", product.HasDiscount);
                cmd.Parameters["@p_hasDiscount"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Product product, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ProductUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", product.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_sub_category", product.SubCategoryID);
                cmd.Parameters["@p_sub_category"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FormulaID", product.FormulaID);
                cmd.Parameters["@p_FormulaID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_productname", product.ProductName);
                cmd.Parameters["@p_productname"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_productcode", product.ProductCode);
                //cmd.Parameters["@p_productcode"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_usedplace", product.UsedPlace);
                cmd.Parameters["@p_usedplace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_noperpack", product.NoPerPack);
                cmd.Parameters["@p_noperpack"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conlength", product.ConLength);
                cmd.Parameters["@p_conlength"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conbase", product.ConBase);
                cmd.Parameters["@p_conbase"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conheight", product.ConHeight);
                cmd.Parameters["@p_conheight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_conthick", product.ConThick);
                cmd.Parameters["@p_conthick"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_minorderqty", product.MinOrderQty);
                cmd.Parameters["@p_minorderqty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_volt", product.Volt);
                cmd.Parameters["@p_volt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_plate", product.Plate);
                cmd.Parameters["@p_plate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_amps", product.Amps);
                cmd.Parameters["@p_amps"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_acid", product.Acid);
                cmd.Parameters["@p_acid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_freeconweight", product.FreeConWeight);
                cmd.Parameters["@p_freeconweight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_leadweight", product.LeadWeight);
                cmd.Parameters["@p_leadweight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_remark", product.Remark);
                cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_hasDiscount", product.HasDiscount);
                cmd.Parameters["@p_hasDiscount"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(int productID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ProductDeleteByProductID";

                cmd.Parameters.AddWithValue("@p_ProductID", productID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

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
