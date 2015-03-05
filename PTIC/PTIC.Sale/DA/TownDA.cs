/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TownDA ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class TownDA
    {
        #region SelectAll
        public static DataTable SelectAll()
        {
            DataTable table = null;
            try
            {
                table = new DataTable("TownTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TownSelectAll";

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

        public static DataTable SelectByDivisionID(int StateDivisionID)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("TownTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                //command.CommandText = "SELECT Town.[ID] AS TownID,Town.[StateDivisionID],Town.[Town],Town.[DateAdded] "
                //                        +",Town.[LastModified],Town.[IsDeleted] FROM [dbo].[Town],[dbo].[StateDivision]	"
                //                            +"WHERE Town.StateDivisionID = StateDivision.ID AND Town.IsDeleted = 0 ORDER BY StateDivisionID "
                //                                +";

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
        #endregion

        #region SelectAll

        public static DataTable SelectAllWithCustomerType()
        {
            DataTable table = null;
            try
            {
                table = new DataTable("CustomerTypeTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TownWithCusTypeSelectAll";

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
        public static int Insert(Town town)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownInsert";

                cmd.Parameters.AddWithValue("@p_StateDivisionID", town.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Town", town.TownName);
                cmd.Parameters["@p_Town"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Town town)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownUpdateByTownID";

                cmd.Parameters.AddWithValue("@p_TownID", town.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StateDivisionID", town.StateDivisionID);
                cmd.Parameters["@p_StateDivisionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Town", town.TownName);
                cmd.Parameters["@p_Town"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Town town)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownDeleteByTownID";

                cmd.Parameters.AddWithValue("@p_TownID", town.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion
    }
}
