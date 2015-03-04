
/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service test data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Sale.DA
{
    public class SvcTestDA
    {
        private static string _tableName = "SvcTest";
        public static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectByID(int svcTestID)
        {
            DataTable dt = new DataTable(_tableName);
            string queryString = "SELECT * FROM {0} WHERE ID = {1}";
            try
            {
                dt = _dataAccess.SelectByQuery(string.Format(queryString, _tableName, svcTestID));
            }
            catch (Exception ex)
            {
                return null;
            }
            return dt;
        }
        #endregion

        #region INSERT
        public static List<SvcFunction> Insert(SvcTest newSvcTest, int svcFactID, List<SvcFunction> svc3Functions, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedSvcTestID = null;
            List<SvcFunction> insertedSvcFunction = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new service test
                cmd.CommandText = "usp_SvcTestInsert";

                cmd.Parameters.AddWithValue("@p_TestVolt", newSvcTest.TestVolt);
                cmd.Parameters["@p_TestVolt"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TestFaultFact", newSvcTest.TestFaultFact);
                //cmd.Parameters["@p_TestFaultFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestService", newSvcTest.TestService);
                cmd.Parameters["@p_TestService"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestFault", newSvcTest.TestFault);
                cmd.Parameters["@p_TestFault"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TestAfterSvc", newSvcTest.TestAfterSvc);
                //cmd.Parameters["@p_TestAfterSvc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus1", newSvcTest.TestRecPlus1);
                cmd.Parameters["@p_TestRecPlus1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus2", newSvcTest.TestRecPlus2);
                cmd.Parameters["@p_TestRecPlus2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus3", newSvcTest.TestRecPlus3);
                cmd.Parameters["@p_TestRecPlus3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus4", newSvcTest.TestRecPlus4);
                cmd.Parameters["@p_TestRecPlus4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus5", newSvcTest.TestRecPlus5);
                cmd.Parameters["@p_TestRecPlus5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus6", newSvcTest.TestRecPlus6);
                cmd.Parameters["@p_TestRecPlus6"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus1", newSvcTest.TestRecMinus1);
                cmd.Parameters["@p_TestRecMinus1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus2", newSvcTest.TestRecMinus2);
                cmd.Parameters["@p_TestRecMinus2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus3", newSvcTest.TestRecMinus3);
                cmd.Parameters["@p_TestRecMinus3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus4", newSvcTest.TestRecMinus4);
                cmd.Parameters["@p_TestRecMinus4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus5", newSvcTest.TestRecMinus5);
                cmd.Parameters["@p_TestRecMinus5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus6", newSvcTest.TestRecMinus6);
                cmd.Parameters["@p_TestRecMinus6"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SvcFactID", svcFactID);
                cmd.Parameters["@p_SvcFactID"].Direction = ParameterDirection.Input;
             
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                insertedSvcTestID = (int)insertedIDObj;

                cmd.Parameters.Clear();
                // insert service function
                insertedSvcFunction = new List<SvcFunction>();
                cmd.CommandText = "usp_SvcFunctionInsert";
                foreach(SvcFunction func in svc3Functions)
                {
                    cmd.Parameters.AddWithValue("@p_SvcTestID", insertedSvcTestID);
                    cmd.Parameters["@p_SvcTestID"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_SvcDate", func.SvcDate);
                    cmd.Parameters["@p_SvcDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromTime", func.FromTime);
                    cmd.Parameters["@p_FromTime"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_ToTime", func.ToTime);
                    cmd.Parameters["@p_ToTime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Function", func.SvcFunctions);
                    cmd.Parameters["@p_Function"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_Volt", func.Volt);
                    cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus1", func.RecPlus1);
                    cmd.Parameters["@p_RecPlus1"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_RecPlus2", func.RecPlus2);
                    cmd.Parameters["@p_RecPlus2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus3", func.RecPlus3);
                    cmd.Parameters["@p_RecPlus3"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_RecPlus4", func.RecPlus4);
                    cmd.Parameters["@p_RecPlus4"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus5", func.RecPlus5);
                    cmd.Parameters["@p_RecPlus5"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_RecPlus6", func.RecPlus6);
                    cmd.Parameters["@p_RecPlus6"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus1", func.RecMinus1);
                    cmd.Parameters["@p_RecMinus1"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_RecMinus2", func.RecMinus2);
                    cmd.Parameters["@p_RecMinus2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus3", func.RecMinus3);
                    cmd.Parameters["@p_RecMinus3"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_RecMinus4", func.RecMinus4);
                    cmd.Parameters["@p_RecMinus4"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus5", func.RecMinus5);
                    cmd.Parameters["@p_RecMinus5"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_RecMinus6", func.RecMinus6);
                    cmd.Parameters["@p_RecMinus6"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", func.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    //SvcFunction outSvcFunc = new SvcFunction();
                    //outSvcFunc.ID = (int)cmd.ExecuteScalar();
                    //outSvcFunc.SvcTestID = insertedSvcTestID.Value;

                   // insertedSvcFunction.Add(outSvcFunc);
                    cmd.Parameters.Clear();
                }                
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return null;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedSvcFunction;
        }
        #endregion

        #region UPDATE
        public static int? Update(SvcTest updateSvcTest, int svcFactID, List<SvcFunction> svc3Functions, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedCount = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // Update service test
                cmd.CommandText = "usp_SvcTestUpdate";

                cmd.Parameters.AddWithValue("@p_SvcTestID", updateSvcTest.ID);
                cmd.Parameters["@p_SvcTestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestVolt", updateSvcTest.TestVolt);
                cmd.Parameters["@p_TestVolt"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TestFaultFact", updateSvcTest.TestFaultFact);
                //cmd.Parameters["@p_TestFaultFact"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestService", updateSvcTest.TestService);
                cmd.Parameters["@p_TestService"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestFault", updateSvcTest.TestFault);
                cmd.Parameters["@p_TestFault"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TestAfterSvc", updateSvcTest.TestAfterSvc);
                //cmd.Parameters["@p_TestAfterSvc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus1", updateSvcTest.TestRecPlus1);
                cmd.Parameters["@p_TestRecPlus1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus2", updateSvcTest.TestRecPlus2);
                cmd.Parameters["@p_TestRecPlus2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus3", updateSvcTest.TestRecPlus3);
                cmd.Parameters["@p_TestRecPlus3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus4", updateSvcTest.TestRecPlus4);
                cmd.Parameters["@p_TestRecPlus4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus5", updateSvcTest.TestRecPlus5);
                cmd.Parameters["@p_TestRecPlus5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecPlus6", updateSvcTest.TestRecPlus6);
                cmd.Parameters["@p_TestRecPlus6"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus1", updateSvcTest.TestRecMinus1);
                cmd.Parameters["@p_TestRecMinus1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus2", updateSvcTest.TestRecMinus2);
                cmd.Parameters["@p_TestRecMinus2"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus3", updateSvcTest.TestRecMinus3);
                cmd.Parameters["@p_TestRecMinus3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus4", updateSvcTest.TestRecMinus4);
                cmd.Parameters["@p_TestRecMinus4"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus5", updateSvcTest.TestRecMinus5);
                cmd.Parameters["@p_TestRecMinus5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TestRecMinus6", updateSvcTest.TestRecMinus6);
                cmd.Parameters["@p_TestRecMinus6"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SvcFactID", svcFactID);
                cmd.Parameters["@p_SvcFactID"].Direction = ParameterDirection.Input;
                
                affectedCount = cmd.ExecuteNonQuery();

                if (affectedCount < 1)
                {
                    transaction.Rollback();
                    return null;
                }
                cmd.Parameters.Clear();
                affectedCount = 0;
                // Update service function
                cmd.CommandText = "usp_SvcFunctionUpdate";
                foreach (SvcFunction func in svc3Functions)
                {
                    cmd.Parameters.AddWithValue("@p_SvcFunctionID", func.ID);
                    cmd.Parameters["@p_SvcFunctionID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcTestID", func.SvcTestID);
                    //cmd.Parameters["@p_SvcTestID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcDate", func.SvcDate);
                    cmd.Parameters["@p_SvcDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromTime", func.FromTime);
                    cmd.Parameters["@p_FromTime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToTime", func.ToTime);
                    cmd.Parameters["@p_ToTime"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Function", func.SvcFunctions);
                    cmd.Parameters["@p_Function"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Volt", func.Volt);
                    cmd.Parameters["@p_Volt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus1", func.RecPlus1);
                    cmd.Parameters["@p_RecPlus1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus2", func.RecPlus2);
                    cmd.Parameters["@p_RecPlus2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus3", func.RecPlus3);
                    cmd.Parameters["@p_RecPlus3"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus4", func.RecPlus4);
                    cmd.Parameters["@p_RecPlus4"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus5", func.RecPlus5);
                    cmd.Parameters["@p_RecPlus5"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecPlus6", func.RecPlus6);
                    cmd.Parameters["@p_RecPlus6"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus1", func.RecMinus1);
                    cmd.Parameters["@p_RecMinus1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus2", func.RecMinus2);
                    cmd.Parameters["@p_RecMinus2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus3", func.RecMinus3);
                    cmd.Parameters["@p_RecMinus3"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus4", func.RecMinus4);
                    cmd.Parameters["@p_RecMinus4"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus5", func.RecMinus5);
                    cmd.Parameters["@p_RecMinus5"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RecMinus6", func.RecMinus6);
                    cmd.Parameters["@p_RecMinus6"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", func.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedCount += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                //if (affectedCount < 3) // Fixed service functions
                //    transaction.Rollback();

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return null;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedCount;
        }
        #endregion



        /*------------------------------ Update Code Insert , Update , Delete --------------------------------------------*/
        public static int InsertSvcTest(SvcTest svcTest)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = _dataAccess.InsertInto("SvcTest", _dataAccess.ConvertColName(svcTest), _dataAccess.ConvertValueList(svcTest));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public static DataTable SelectAllBySalesSvcID(int SalesServiceID)
        {
            DataTable dt;
            dt = _dataAccess.SelectByQuery("SELECT * FROM SvcTest WHERE SalesServiceID=" + SalesServiceID);
            return dt;
        }

    }
}
