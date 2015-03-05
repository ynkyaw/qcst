using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class FinishedGoodDA
    {
        public static int Insert(List<FinishedGood> finishedGoods, SqlConnection conn)
        {
            
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {              
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
               
         
                cmd.CommandText = "usp_FinishedGoodInsert";
                foreach (FinishedGood newfinishedGood in finishedGoods)
                {
                    cmd.Parameters.AddWithValue("@p_ProductID", newfinishedGood.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductionCode", newfinishedGood.ProductionCode);
                    cmd.Parameters["@p_ProductionCode"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductionDate", newfinishedGood.ProductionDate);
                    cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_Qty", newfinishedGood.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newfinishedGood.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;      

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_FGRequstDetailInsert
                    cmd.Parameters.Clear();
                }
              
            }
            catch (SqlException sqle)
            {
                
            }
            finally
            {                
                cmd.Dispose();
            }
            return affectedRows;
        }

        #region Select By Production Date
        public static DataTable SelectByProductionDate(DateTime productionDate, SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FinishedGoodSelectByProductionDate";

                command.Parameters.AddWithValue("@p_ProductionDate", productionDate);
                command.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FinishedGoods");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FinishedGoods"];
        }

        public static DataTable SelectAllStockInFactroy()
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductID,ProductName,Qty FROM StockInWarehouse "
                                        +"INNER JOIN Product ON Product.ID = ProductID "
                                            +"WHERE StockInWarehouse.IsDeleted = 0 AND WarehouseID =1";
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FinishedGoods");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FinishedGoods"];
        }

        #endregion

    }
}
