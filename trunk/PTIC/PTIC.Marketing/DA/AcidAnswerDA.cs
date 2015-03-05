using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class AcidAnswerDA
    {
        #region INSERT
        public static int Insert(AnswerForm newAnswerForm, AcidAnswer newAcidAnswer)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int insertedAnswerFormID = -1;

            try
            {
                //  SqlConnection
                conn = DBManager.GetInstance().GetDbConnection();
                //  Begin Transaction
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.CommandText = "usp_AnswerFormInsert";

                cmd.Parameters.AddWithValue("@p_QuestionFormID", newAnswerForm.QuestionFormID);
                cmd.Parameters["@p_QuestionFormID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SurveyDate", newAnswerForm.SurveyDate);
                cmd.Parameters["@p_SurveyDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CustomerID", newAnswerForm.CustomerID);
                cmd.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return -1;
                insertedAnswerFormID = (int)insertedIDObj;
                // clear parameters of usp_AnswerFormInsert
                cmd.Parameters.Clear();

                // insert new usp_AcidAnswerInsert
                cmd.CommandText = "usp_AcidAnswerInsert";

                cmd.Parameters.AddWithValue("@p_AnswerFormID", insertedAnswerFormID);
                cmd.Parameters["@p_AnswerFormID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans1_TOYO", newAcidAnswer.Ans1_TOYO);
                cmd.Parameters["@p_Ans1_TOYO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans1_GP", newAcidAnswer.Ans1_GP);
                cmd.Parameters["@p_Ans1_GP"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans1_XCL", newAcidAnswer.Ans1_XCL);
                cmd.Parameters["@p_Ans1_XCL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans1_GR", newAcidAnswer.Ans1_GR);
                cmd.Parameters["@p_Ans1_GR"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans1_KW", newAcidAnswer.Ans1_KW);
                cmd.Parameters["@p_Ans1_KW"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans1_Other", newAcidAnswer.Ans1_Other);
                cmd.Parameters["@p_Ans1_Other"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans2_TOYO", newAcidAnswer.Ans2_TOYO);
                cmd.Parameters["@p_Ans2_TOYO"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans2_GP", newAcidAnswer.Ans2_GP);
                cmd.Parameters["@p_Ans2_GP"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans2_XCL", newAcidAnswer.Ans2_XCL);
                cmd.Parameters["@p_Ans2_XCL"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans2_GR", newAcidAnswer.Ans2_GR);
                cmd.Parameters["@p_Ans2_GR"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans2_KW", newAcidAnswer.Ans2_KW);
                cmd.Parameters["@p_Ans2_KW"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans2_Other", newAcidAnswer.Ans2_Other);
                cmd.Parameters["@p_Ans2_Other"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans3", newAcidAnswer.Ans3);
                cmd.Parameters["@p_Ans3"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans4_1Lit", newAcidAnswer.Ans4_1Lit);
                cmd.Parameters["@p_Ans4_1Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans4_4Lit", newAcidAnswer.Ans4_4Lit);
                cmd.Parameters["@p_Ans4_4Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans4_7Lit", newAcidAnswer.Ans4_7Lit);
                cmd.Parameters["@p_Ans4_7Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans4_9Lit", newAcidAnswer.Ans4_9Lit);
                cmd.Parameters["@p_Ans4_9Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans4_22_5Lit", newAcidAnswer.Ans4_22_5Lit);
                cmd.Parameters["@p_Ans4_22_5Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans5", newAcidAnswer.Ans5);
                cmd.Parameters["@p_Ans5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans6", newAcidAnswer.Ans6);
                cmd.Parameters["@p_Ans5"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans7_1Lit", newAcidAnswer.Ans7_1Lit);
                cmd.Parameters["@p_Ans7_1Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans7_4Lit", newAcidAnswer.Ans7_4Lit);
                cmd.Parameters["@p_Ans7_4Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans7_7Lit", newAcidAnswer.Ans7_7Lit);
                cmd.Parameters["@p_Ans7_7Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans7_9Lit", newAcidAnswer.Ans7_9Lit);
                cmd.Parameters["@p_Ans7_9Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans7_22_5Lit", newAcidAnswer.Ans7_22_5Lit);
                cmd.Parameters["@p_Ans7_22_5Lit"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans8", newAcidAnswer.Ans8);
                cmd.Parameters["@p_Ans8"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Ans9", newAcidAnswer.Ans9);
                cmd.Parameters["@p_Ans9"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                // clear parameters of each 
                cmd.Parameters.Clear();

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {

                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return insertedAnswerFormID;
                }
            }

            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedAnswerFormID;
        }
        #endregion

        #region SELECT
        public static DataTable SearchByDateRange_SurveyType(DateTime startdate, DateTime enddate, int questionFormID)
        {
            DataTable table = null;
            string tableName = "AnswerFormTbl";
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_AnswerSelectByDateRangeSurveyType";

                command.Parameters.AddWithValue("@p_QuestionFormID", questionFormID);
                command.Parameters["@p_QuestionFormID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_startDate", startdate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", enddate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }



        public static DataTable SearchBy(DateTime startdate, DateTime enddate, int questionFormID, int? RouteID, int? TownshipID, int? TripID, int? TownID)
        {
            DataTable table = null;
            string tableName = "AnswerFormTbl";
            SqlConnection conn =null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_AcidAnswerSelectBy";

                command.Parameters.AddWithValue("@p_QuestionFormID", questionFormID);
                command.Parameters["@p_QuestionFormID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_startDate",startdate );
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", enddate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_routeID", RouteID);
                command.Parameters["@p_routeID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_townshipID", TownshipID);
                command.Parameters["@p_townshipID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_tripID", TripID);
                command.Parameters["@p_tripID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_townID", TownID);
                command.Parameters["@p_townID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable AcidAnswerSearchBy(int CustomerID,int QuestionFormID,DateTime SurveyDate)
        {
            DataTable table = null;
            string tableName = "AcidAnswerFormTbl";
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_AcidAnswerFormSelectBy";

                command.Parameters.AddWithValue("@p_CustomerID", CustomerID);
                command.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_QuestionFormID", QuestionFormID);
                command.Parameters["@p_QuestionFormID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_SurveyDate", SurveyDate);
                command.Parameters["@p_SurveyDate"].Direction = ParameterDirection.Input;

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
    }
}
