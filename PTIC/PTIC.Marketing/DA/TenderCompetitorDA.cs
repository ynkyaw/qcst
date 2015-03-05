using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class TenderCompetitorDA
    {
        #region SELECT
        internal static DataTable GetTenderCompetitorByID(int? tenderInfoID, SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TenderCompetitortSelectByID";

                command.Parameters.AddWithValue("@p_tenderinfoID", tenderInfoID);
                command.Parameters["@p_tenderinfoID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "TenderCompetitorTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["TenderCompetitorTable"];

        }            
        #endregion

        #region INSERT

        public static int Insert(List<TenderCompetitors> newTenderCompetitors, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderCompetitorInsert";

                foreach (TenderCompetitors tenderCompetitor in newTenderCompetitors)
                {
                    cmd.Parameters.AddWithValue("@p_TenderInfoID", tenderCompetitor.TenderInfoID);
                    cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TCompetitor", tenderCompetitor.TCompetitor);
                    cmd.Parameters["@p_TCompetitor"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TProductName", tenderCompetitor.TProductName);
                    cmd.Parameters["@p_TProductName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TQty", tenderCompetitor.Tqty);
                    cmd.Parameters["@p_TQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TPrice", tenderCompetitor.Tprice);
                    cmd.Parameters["@p_TPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TotalPrice", tenderCompetitor.TotalPrice);
                    cmd.Parameters["@p_TotalPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_remark", tenderCompetitor.Remark);
                    cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TenderCompetitorInsert
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

        public static int UpdateByTenderCompetitorID(List<TenderCompetitors> mdTenderCompetitors, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderCompetitorUpdateByTenderCompetitorID";

                foreach (TenderCompetitors tenderCompetitor in mdTenderCompetitors)
                {
                    cmd.Parameters.AddWithValue("@p_TenderProductID", tenderCompetitor.ID);
                    cmd.Parameters["@p_TenderProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TenderInfoID", tenderCompetitor.TenderInfoID);
                    cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TCompetitor", tenderCompetitor.TCompetitor);
                    cmd.Parameters["@p_TCompetitor"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TProductName", tenderCompetitor.TProductName);
                    cmd.Parameters["@p_TProductName"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TQty", tenderCompetitor.Tqty);
                    cmd.Parameters["@p_TQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TPrice", tenderCompetitor.Tprice);
                    cmd.Parameters["@p_TPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TotalPrice", tenderCompetitor.TotalPrice);
                    cmd.Parameters["@p_TotalPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_remark", tenderCompetitor.Remark);
                    cmd.Parameters["@p_remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TenderCompetitorUpdateByTenderCompetitorID
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

        public static int DeleteByTenderCompetitorID(List<TenderCompetitors> tenderCompetitors, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderCompetitorDeleteByTenderCompetitorID";

                foreach (TenderCompetitors tenderCompetitor in tenderCompetitors)
                {
                    cmd.Parameters.AddWithValue("@p_TenderCompetitorID", tenderCompetitor.ID);
                    cmd.Parameters["@p_TenderCompetitorID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear@p_TenderProductID parameters of each usp_TenderCompetitorDeleteByTenderCompetitorID
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
