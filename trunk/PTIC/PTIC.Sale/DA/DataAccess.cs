/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Order detail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// Base class for data access
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="resTableName"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable ExecQuerySP(string storedProcedureName, string resTableName, SqlConnection conn)
        {
            DataTable table = new DataTable();
            if(string.IsNullOrEmpty(resTableName))
                table = new DataTable();
            else
                table = new DataTable(resTableName);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqle)
            {
                throw;
            }
        }

    }
}
