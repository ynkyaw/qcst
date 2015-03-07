/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/mm/dd)
 * Description: Mobile Service Record data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using System.Data;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class MobileServiceRecordDA
    {
        #region SELECT
        public static DataTable SelectByMobileServiceDetailID(int? mobileServiceDetailID)
        {
            DataTable table = null;
            string tableName = "MobileServiceRecordTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceRecordSelectByMobileServiceDetailID";

                command.Parameters.AddWithValue("@p_MobileServiceDetailID", mobileServiceDetailID);
                command.Parameters["@p_MobileServiceDetailID"].Direction = ParameterDirection.Input;

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
        public static int Insert(MobileServiceRecord newMobileServiceRecord)
        {
            try
            {   
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServiceRecordInsert";

                cmd.Parameters.AddWithValue("@p_MSuvDetailID", newMobileServiceRecord.MSuvDetailID);
                cmd.Parameters["@p_MSuvDetailID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BrandID", newMobileServiceRecord.BrandID);
                //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ProductID", newMobileServiceRecord.ProductID);
                //cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Brand", newMobileServiceRecord.Brand);
                cmd.Parameters["@p_Brand"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Product", newMobileServiceRecord.Product);
                cmd.Parameters["@p_Product"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", newMobileServiceRecord.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MachineNo", newMobileServiceRecord.MachineNo);
                cmd.Parameters["@p_MachineNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductionDate", newMobileServiceRecord.ProductionDate);
                cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Volt", newMobileServiceRecord.Volt);
                cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChargingAmp", newMobileServiceRecord.ChargingAmp);
                cmd.Parameters["@p_ChargingAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OutAmp", newMobileServiceRecord.OutAmp);
                cmd.Parameters["@p_OutAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid1", newMobileServiceRecord.Acid1);
                cmd.Parameters["@p_Acid1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid2", newMobileServiceRecord.Acid2);
                cmd.Parameters["@p_Acid2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid3", newMobileServiceRecord.Acid3);
                cmd.Parameters["@p_Acid3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid4", newMobileServiceRecord.Acid4);
                cmd.Parameters["@p_Acid4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid5", newMobileServiceRecord.Acid5);
                cmd.Parameters["@p_Acid5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid6", newMobileServiceRecord.Acid6);
                cmd.Parameters["@p_Acid6"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Serving", newMobileServiceRecord.Serving);
                cmd.Parameters["@p_Serving"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByMobileServiceRecordID(MobileServiceRecord mdMobileServiceRecord)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServiceRecordUpdateByID";

                cmd.Parameters.AddWithValue("@p_MobileServiceRecordID", mdMobileServiceRecord.ID);
                cmd.Parameters["@p_MobileServiceRecordID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MSuvDetailID", mdMobileServiceRecord.MSuvDetailID);
                cmd.Parameters["@p_MSuvDetailID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BrandID", mdMobileServiceRecord.BrandID);
                //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ProductID", mdMobileServiceRecord.ProductID);
                //cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Brand", mdMobileServiceRecord.Brand);
                cmd.Parameters["@p_Brand"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Product", mdMobileServiceRecord.Product);
                cmd.Parameters["@p_Product"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", mdMobileServiceRecord.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MachineNo", mdMobileServiceRecord.MachineNo);
                cmd.Parameters["@p_MachineNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductionDate", mdMobileServiceRecord.ProductionDate);
                cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Volt", mdMobileServiceRecord.Volt);
                cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChargingAmp", mdMobileServiceRecord.ChargingAmp);
                cmd.Parameters["@p_ChargingAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OutAmp", mdMobileServiceRecord.OutAmp);
                cmd.Parameters["@p_OutAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid1", mdMobileServiceRecord.Acid1);
                cmd.Parameters["@p_Acid1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid2", mdMobileServiceRecord.Acid2);
                cmd.Parameters["@p_Acid2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid3", mdMobileServiceRecord.Acid3);
                cmd.Parameters["@p_Acid3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid4", mdMobileServiceRecord.Acid4);
                cmd.Parameters["@p_Acid4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid5", mdMobileServiceRecord.Acid5);
                cmd.Parameters["@p_Acid5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Acid6", mdMobileServiceRecord.Acid6);
                cmd.Parameters["@p_Acid6"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Serving", mdMobileServiceRecord.Serving);
                cmd.Parameters["@p_Serving"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(int mobileServiceRecordID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServiceRecordDeleteByID";

                cmd.Parameters.AddWithValue("@p_MobileServiceRecord", mobileServiceRecordID);
                cmd.Parameters["@p_MobileServiceRecord"].Direction = ParameterDirection.Input;

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
