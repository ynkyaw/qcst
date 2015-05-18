using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;
using System.Data;
using PTIC.Sale.Entities;

namespace PTIC.Marketing.DA
{
    public class RetailerAnswerDA
    {
        #region SELECT
        public static DataTable AnswerSearchBy(int CustomerID, int QuestionFormID, DateTime SurveyDate)
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
                command.CommandText = "usp_AnswerFormSelectBy";

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

        #region INSERT
        public static int Insert(AnswerForm newAnswerForm,RetailerSuggestion newRetailerSuggestion,List<RetailerAnswer> newRetailerAnswers)
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

                cmd.CommandText = "usp_RetailerSuggestionInsert";

                cmd.Parameters.AddWithValue("@p_AnswerFormID", insertedAnswerFormID);
                cmd.Parameters["@p_AnswerFormID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Suggestion", newRetailerSuggestion.Suggestion);
                cmd.Parameters["@p_Suggestion"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherSuggestion", newRetailerSuggestion.OtherSuggestion);
                cmd.Parameters["@p_OtherSuggestion"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "usp_RetailerAnswerInsert";
                foreach (RetailerAnswer newRetailerAnswer in newRetailerAnswers)
                {
                    cmd.Parameters.AddWithValue("@p_AnswerFormID", insertedAnswerFormID);
                    cmd.Parameters["@p_AnswerFormID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Ans1", newRetailerAnswer.Ans1);
                    cmd.Parameters["@p_Ans1"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Ans2", newRetailerAnswer.Ans2);
                    cmd.Parameters["@p_Ans2"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Ans3", newRetailerAnswer.Ans3);
                    cmd.Parameters["@p_Ans3"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_QuestionNo", newRetailerAnswer.QuestionNo);
                    cmd.Parameters["@p_QuestionNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SubQuestionNo", newRetailerAnswer.SubQuestionNo);
                    cmd.Parameters["@p_SubQuestionNo"].Direction = ParameterDirection.Input;
                                       
                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_RetailerAnswerInsert
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
                    return insertedAnswerFormID = -1;
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
    }
}
