/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/27 (yyyy/MM/dd)
 * Description: TripRecord data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class TripRecordDA
    {
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectByTripPlanDetailID(int tripPlanDetailID)
        {
            string queryString = string.Format("SELECT * FROM TripRecord WHERE TripPlanDetailID = {0} ", tripPlanDetailID);
            return _dataAccess.SelectByQuery(queryString);
        }

        public static DataTable SelectPreviousRecordByTripPlanDetailID(int tripPlanDetailID)
        {
            string queryString = string.Format("SELECT TOP 1 * FROM"
                                                            + " (SELECT"
		                                                            + " detail.ID AS DetailID, rec.ArrivedDate, rec.RentAmt, rec.FoodAmt,"
		                                                            + " rec.TransportAmt, rec.CommunicationAmt, rec.OtherExpense, rec.RemittanceAmt"
	                                                            + " FROM TripRecord AS rec"
		                                                            + " INNER JOIN TripPlanDetail AS detail ON detail.ID = rec.TripPlanDetailID"
		                                                            + " INNER JOIN TripPlan AS pln ON pln.ID = detail.TripPlanID"
	                                                            + " WHERE pln.ID = (SELECT TripPlanID FROM TripPlanDetail WHERE ID = {0})"
		                                                            + " AND detail.TripID = (SELECT TripID FROM TripPlanDetail WHERE ID = {0})"
                                                            + " ) Result WHERE DetailID != {0} ORDER BY ArrivedDate", tripPlanDetailID);
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion

        #region INSERT
        public static int? Insert(TripRecord newTripRecord)
        {
            try
            {
                string cmdInsert = "INSERT INTO [TripRecord] ( "
                                               + "[TripPlanDetailID], [ArrivedDate], [PrevDebitAmt], [RentAmt], [FoodAmt]"
		                                       + ",[TransportAmt], [CommunicationAmt], [OtherExpense], [RemittanceAmt], [DebitConflictShop]"
                                               + ",[ShopWithoutOwnerSign], [CompetitorStatus], [Complaint], [PossibleNextTripDate]"
                                               + ", [MainProductID4NextTrip], [SpecialCase], [Suggestion], [Remark] )"
                                               + "OUTPUT inserted.ID"
                                         + " VALUES ("
                                               + "@p_TripPlanDetailID, @p_ArrivedDate, @p_PrevDebitAmt, @p_RentAmt, @p_FoodAmt"
                                               + ",@p_TransportAmt, @p_CommunicationAmt, @p_OtherExpense, @p_RemittanceAmt, @p_DebitConflictShop"
                                               + ",@p_ShopWithoutOwnerSign, @p_CompetitorStatus, @p_Complaint, @p_PossibleNextTripDate"
                                               + ",@p_MainProductID4NextTrip, @p_SpecialCase, @p_Suggestion, @p_Remark )";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdInsert;

                //cmd.Parameters.AddWithValue("@p_TripPlanDetailID", newTripRecord.TripPlanDetailID);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_TripPlanDetailID",
                  Value = newTripRecord.TripPlanDetailID
                });

                //cmd.Parameters.AddWithValue("@p_ArrivedDate", newTripRecord.ArrivedDate);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_ArrivedDate",
                  Value = newTripRecord.ArrivedDate
                });

                //cmd.Parameters.AddWithValue("@p_PrevDebitAmt", newTripRecord.PrevDebitAmt);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_PrevDebitAmt",
                  Value = (object)newTripRecord.PrevDebitAmt ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_RentAmt", newTripRecord.RentAmt);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_RentAmt",
                  Value = (object)newTripRecord.RentAmt ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_FoodAmt", newTripRecord.FoodAmt);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_FoodAmt",
                  Value = (object)newTripRecord.FoodAmt ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_TransportAmt", newTripRecord.TransportAmt);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_TransportAmt",
                  Value = (object)newTripRecord.TransportAmt ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_CommunicationAmt", newTripRecord.CommunicationAmt);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_CommunicationAmt",
                  Value = (object)newTripRecord.CommunicationAmt ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_OtherExpense", newTripRecord.OtherExpense);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_OtherExpense",
                  Value = (object)newTripRecord.OtherExpense ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_RemittanceAmt", newTripRecord.RemittanceAmt);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_RemittanceAmt",
                  Value = (object)newTripRecord.RemittanceAmt ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_DebitConflictShop", newTripRecord.DebitConflictShop);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_DebitConflictShop",
                  Value = (object)newTripRecord.DebitConflictShop ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_ShopWithoutOwnerSign", newTripRecord.ShopWithoutOwnerSign);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_ShopWithoutOwnerSign",
                  Value = (object)newTripRecord.ShopWithoutOwnerSign ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_CompetitorStatus", newTripRecord.CompetitorStatus);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_CompetitorStatus",
                  Value = (object)newTripRecord.CompetitorStatus ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_Complaint", newTripRecord.Complaint);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_Complaint",
                  Value = (object)newTripRecord.Complaint ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_PossibleNextTripDate", newTripRecord.PossibleNextTripDate);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_PossibleNextTripDate",
                  Value = (object)newTripRecord.PossibleNextTripDate ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_MainProductID4NextTrip", newTripRecord.MainProductID4NextTrip);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_MainProductID4NextTrip",
                  Value = (object)newTripRecord.MainProductID4NextTrip ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_SpecialCase", newTripRecord.SpecialCase);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_SpecialCase",
                  Value = (object)newTripRecord.SpecialCase ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_Suggestion", newTripRecord.Suggestion);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_Suggestion",
                  Value = (object)newTripRecord.Suggestion ?? DBNull.Value
                });
                
                //cmd.Parameters.AddWithValue("@p_Remark", newTripRecord.Remark);
                cmd.Parameters.Add(new SqlParameter() 
                { 
                  ParameterName = "@p_Remark",
                  Value = (object)newTripRecord.Remark ?? DBNull.Value
                });
                
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                return (int)insertedIDObj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(TripRecord uTripRecord)
        {
            try
            {
                string cmdUpdate = "UPDATE [TripRecord] SET "
		                                        + "[TripPlanDetailID] = @p_TripPlanDetailID"
                                              + " ,[ArrivedDate] = @p_ArrivedDate"
                                              + " ,[PrevDebitAmt] = @p_PrevDebitAmt"
                                              + " ,[RentAmt] = @p_RentAmt"
                                              + " ,[FoodAmt] = @p_FoodAmt"
                                              + " ,[TransportAmt] = @p_TransportAmt"
                                              + " ,[CommunicationAmt] = @p_CommunicationAmt"
                                              + " ,[OtherExpense] = @p_OtherExpense"
                                              + " ,[RemittanceAmt] = @p_RemittanceAmt"
                                              + " ,[DebitConflictShop] = @p_DebitConflictShop"
                                              + " ,[ShopWithoutOwnerSign] = @p_ShopWithoutOwnerSign"
                                              + " ,[CompetitorStatus] = @p_CompetitorStatus"
                                              + " ,[Complaint] = @p_Complaint"
                                              + " ,[PossibleNextTripDate] = @p_PossibleNextTripDate"
                                              + " ,[MainProductID4NextTrip] = @p_MainProductID4NextTrip"
                                              + " ,[SpecialCase] = @p_SpecialCase"
                                              + " ,[Suggestion] = @p_Suggestion"
                                              + " ,[Remark] = @p_Remark"
                                              + " ,[LastModified] = GETDATE()"
                                         +" WHERE [ID] = @p_ID";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdUpdate;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_TripPlanDetailID",
                    Value = uTripRecord.TripPlanDetailID
                });
                
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_ArrivedDate",
                    Value = uTripRecord.ArrivedDate
                });
                
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_PrevDebitAmt",
                    Value = (object)uTripRecord.PrevDebitAmt ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_RentAmt",
                    Value = (object)uTripRecord.RentAmt ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_FoodAmt",
                    Value = (object)uTripRecord.FoodAmt ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_TransportAmt",
                    Value = (object)uTripRecord.TransportAmt ?? DBNull.Value
                });
                
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_CommunicationAmt",
                    Value = (object)uTripRecord.CommunicationAmt ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_OtherExpense",
                    Value = (object)uTripRecord.OtherExpense ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_RemittanceAmt",
                    Value = (object)uTripRecord.RemittanceAmt ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_DebitConflictShop",
                    Value = (object)uTripRecord.DebitConflictShop ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_ShopWithoutOwnerSign",
                    Value = (object)uTripRecord.ShopWithoutOwnerSign ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_CompetitorStatus",
                    Value = (object)uTripRecord.CompetitorStatus ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_Complaint",
                    Value = (object)uTripRecord.Complaint ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_PossibleNextTripDate",
                    Value = (object)uTripRecord.PossibleNextTripDate ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_MainProductID4NextTrip",
                    Value = (object)uTripRecord.MainProductID4NextTrip ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_SpecialCase",
                    Value = (object)uTripRecord.SpecialCase ?? DBNull.Value
                });
               
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_Suggestion",
                    Value = (object)uTripRecord.Suggestion ?? DBNull.Value
                });
                
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_Remark",
                    Value = (object)uTripRecord.Remark ?? DBNull.Value
                });

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_ID",
                    Value = (object)uTripRecord.ID ?? DBNull.Value
                });
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        #endregion
    }
}
