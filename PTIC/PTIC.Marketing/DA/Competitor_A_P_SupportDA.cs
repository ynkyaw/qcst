/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: Competitor A_P Support data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class Competitor_A_P_SupportDA
    {
        #region SELECT
        public static DataTable SelectByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "Competitor_A_P_SupportTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_Competitor_A_P_SupportSelectByCActivityID";

                command.Parameters.AddWithValue("@p_CompetitorActivityID", competitorActivityID);
                command.Parameters["@p_CompetitorActivityID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region INSERT
        public static int Insert(Competitor_A_P_Support newCompetitor_A_P_Support, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorA_P_SupportInsert";

                cmd.Parameters.AddWithValue("@p_CActivityID", newCompetitor_A_P_Support.CActivityID);
                cmd.Parameters["@p_CActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", newCompetitor_A_P_Support.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_Type", newCompetitor_A_P_Support.A_P_Type);
                cmd.Parameters["@p_A_P_Type"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_Size", newCompetitor_A_P_Support.A_P_Size);
                cmd.Parameters["@p_A_P_Size"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Period", newCompetitor_A_P_Support.Period);
                cmd.Parameters["@p_Period"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Result", newCompetitor_A_P_Support.Result);
                cmd.Parameters["@p_Result"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Competitor_A_P_Support mdCompetitor_A_P_Support, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Competitor_A_P_SupportUpdateByID";

                cmd.Parameters.AddWithValue("@p_Competitor_A_P_SupportID", mdCompetitor_A_P_Support.ID);
                cmd.Parameters["@p_Competitor_A_P_SupportID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CActivityID", mdCompetitor_A_P_Support.CActivityID);
                cmd.Parameters["@p_CActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", mdCompetitor_A_P_Support.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_Type", mdCompetitor_A_P_Support.A_P_Type);
                cmd.Parameters["@p_A_P_Type"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_Size", mdCompetitor_A_P_Support.A_P_Size);
                cmd.Parameters["@p_A_P_Size"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Period", mdCompetitor_A_P_Support.Period);
                cmd.Parameters["@p_Period"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Result", mdCompetitor_A_P_Support.Result);
                cmd.Parameters["@p_Result"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(int competitor_A_P_SupportID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Competitor_A_P_SupportDeleteByID";

                cmd.Parameters.AddWithValue("@p_Competitor_A_P_SupportID", competitor_A_P_SupportID);
                cmd.Parameters["@p_Competitor_A_P_SupportID"].Direction = ParameterDirection.Input;

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
