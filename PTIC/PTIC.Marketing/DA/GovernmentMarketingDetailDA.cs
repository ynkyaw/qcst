/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: Government Marketing Detail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class GovernmentMarketingDetailDA
    {
        #region SELECT
        public static DataTable SelectGovMarketingLogs(SqlConnection conn)
        {

            DataTable table = null;
            string tableName = "GovernmentMarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_GovernmentMarketingLogSelectAll";

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
        public static int? Insert(GovernmentMarketingDetail newGovernmentMarketingDetail, SqlConnection conn)
        {
            int? insertedGovMarketingDetailID = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GovernmentMarketingDetailInsert";

                cmd.Parameters.AddWithValue("@p_MarketingPlanID", newGovernmentMarketingDetail.MarketingPlanID);
                cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_MinistryName", newGovernmentMarketingDetail.MinistryName);
                //cmd.Parameters["@p_MinistryName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Department", newGovernmentMarketingDetail.Department);
                cmd.Parameters["@p_Department"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ContactPerson", newGovernmentMarketingDetail.ContactPerson);
                //cmd.Parameters["@p_ContactPerson"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Position", newGovernmentMarketingDetail.Position);
                //cmd.Parameters["@p_Position"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ContactPhone", newGovernmentMarketingDetail.ContactPhone);
                //cmd.Parameters["@p_ContactPhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Matter", newGovernmentMarketingDetail.Matter);
                cmd.Parameters["@p_Matter"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Date", newGovernmentMarketingDetail.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Address", newGovernmentMarketingDetail.Address);
                cmd.Parameters["@p_Address"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", newGovernmentMarketingDetail.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", newGovernmentMarketingDetail.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newGovernmentMarketingDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", newGovernmentMarketingDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", newGovernmentMarketingDetail.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newGovernmentMarketingDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceID", newGovernmentMarketingDetail.ServiceID);
                cmd.Parameters["@p_ServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", newGovernmentMarketingDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TenderInfoID", newGovernmentMarketingDetail.TenderInfoID);
                cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedGovMarketingDetailID = (int)insertedIDObj;
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return insertedGovMarketingDetailID;
        }
        #endregion

        #region UPDATE
        public static int UpdateByGovDetailID(GovernmentMarketingDetail mdGovernmentMarketingDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GovernmentMarketingDetailUpdateByGovMarketingDetailID";

                cmd.Parameters.AddWithValue("@p_GovMarketingDetailID", mdGovernmentMarketingDetail.ID);
                cmd.Parameters["@p_GovMarketingDetailID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_MinistryName", mdGovernmentMarketingDetail.MinistryName);
                //cmd.Parameters["@p_MinistryName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Department", mdGovernmentMarketingDetail.Department);
                cmd.Parameters["@p_Department"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ContactPerson", mdGovernmentMarketingDetail.ContactPerson);
                //cmd.Parameters["@p_ContactPerson"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Position", mdGovernmentMarketingDetail.Position);
                //cmd.Parameters["@p_Position"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_ContactPhone", mdGovernmentMarketingDetail.ContactPhone);
                //cmd.Parameters["@p_ContactPhone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Matter", mdGovernmentMarketingDetail.Matter);
                cmd.Parameters["@p_Matter"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Date", mdGovernmentMarketingDetail.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Address", mdGovernmentMarketingDetail.Address);
                cmd.Parameters["@p_Address"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone1", mdGovernmentMarketingDetail.Phone1);
                cmd.Parameters["@p_Phone1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone2", mdGovernmentMarketingDetail.Phone2);
                cmd.Parameters["@p_Phone2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", mdGovernmentMarketingDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", mdGovernmentMarketingDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", mdGovernmentMarketingDetail.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", mdGovernmentMarketingDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceID", mdGovernmentMarketingDetail.ServiceID);
                cmd.Parameters["@p_ServiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", mdGovernmentMarketingDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TenderInfoID", mdGovernmentMarketingDetail.TenderInfoID);
                cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        #endregion
    }
}
