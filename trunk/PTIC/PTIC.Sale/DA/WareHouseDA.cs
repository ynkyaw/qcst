using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class WarehouseDA
    {
        private static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable ShowRoom()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT ID As WarehouseID,Warehouse FROM Warehouse WHERE IsMain != 1 AND IsSub !=1 AND IsDeleted =0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }

        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "WareHouseTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_WareHouseSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public DataTable SelectSubtore()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT Count(IsSub) As SubStoreCount,Warehouse.ID As WarehouseID FROM WareHouse WHERE IsSub = 1 AND IsDeleted =0 GROUP BY WareHouse.ID");
            }
            catch (Exception ex)
            {                
                throw ex;
            }           
            return dt;
        }

        public static DataTable SelectAllSubStore()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM Warehouse WHERE IsDeleted = 0 AND IsMain = 0");
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }

        public DataTable SelectMain()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT Count(IsMain) As SubStoreCount,Warehouse.ID As WarehouseID FROM WareHouse WHERE IsMain = 1 AND IsDeleted =0 GROUP BY WareHouse.ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
    }
}
