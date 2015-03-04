/* Author   :   Aung Ko Ko
    Date      :   11 Feb 2014
    Description :   BatterySettingDA ( Insert , Update , Delete , GetAll}
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
    public class BatterySettingDA
    {
        #region SELECT
        public static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_BSettingSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "BSettingTable");
            }
            catch (SqlException sqle)
            {
                // show error message
            }
            return dataSet.Tables["BSettingTable"];
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(BatterySetting bsetting, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BSettingUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", bsetting.BatterySettingID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_productid", bsetting.ProductID);
                cmd.Parameters["@p_productid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_trandate", bsetting.TranDate);
                cmd.Parameters["@p_trandate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_weight", bsetting.Weight);
                cmd.Parameters["@p_weight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_qty", bsetting.Qty);
                cmd.Parameters["@p_qty"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region INSERT
        public static int Insert(BatterySetting bsetting, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BSettingInsert";

                cmd.Parameters.AddWithValue("@p_productid", bsetting.ProductID);
                cmd.Parameters["@p_productid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_trandate", bsetting.TranDate);
                cmd.Parameters["@p_trandate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_weight", bsetting.Weight);
                cmd.Parameters["@p_weight"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_qty", bsetting.Qty);
                cmd.Parameters["@p_qty"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(BatterySetting bsetting, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BSettingDelete";

                cmd.Parameters.AddWithValue("@p_id", bsetting.BatterySettingID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

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
