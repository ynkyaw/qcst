/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 *              Aung Ko Ko
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Employee data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Common.DA
{
    public class EmployeeDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectAllByRank()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_EmployeeSelectWithoutPhoto WHERE [Rank] Between '1' AND '7'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public static DataTable SelectEmpFromSalesMktRank1To7()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_EmployeeSelectWithoutPhoto "
                                        +"WHERE ([Rank] Between 1 AND 7) AND (DeptID = 7 OR DeptID =8)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public static DataTable SelectEmpFromMarketingAndSale()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_EmployeeSelectAll WHERE DeptID =7 OR DeptID =8");
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectAll()
        {
            DataTable table = null;
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable("EmployeeTable");
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_EmployeeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }

        public static DataTable SelectAllExpectParam(int DeptID)
        {
            DataTable dt;
            try
            {
                string query ="SELECT * FROM [dbo].[MessageUsers] "
							+"INNER JOIN Employee ON Employee.ID = MessageUsers.EmployeeID "
							+"INNER JOIN Department ON Department.ID = Employee.DeptID "
                             +"INNER JOIN Job_Position ON Job_Position.ID = Employee.PostID WHERE [IsActive] = 1 "
                             +"AND DeptID !='{0}'";

                dt = b.SelectByQuery(string.Format(query, DeptID));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllByTripRequestID(int TripRequestID)
        {
            DataTable dt;
            try
            {
                //dt = b.SelectAll("EmployeeInTripPlanDetail");
                dt = b.SelectByQuery("SELECT	EmployeeInTripRequest.ID,Job_Position.PostName,Department.DeptName,EmpName,EmpID As EmployeeID,TripRequestID,Employee.PostID,Employee.DeptID"
                    + " FROM EmployeeInTripRequest"
                    + " LEFT JOIN Employee ON Employee.ID = EmployeeInTripRequest.EmpID"
                    + " INNER JOIN Job_Position ON Job_Position.ID = Employee.PostID INNER JOIN Department ON Department.ID = Employee.DeptID WHERE TripRequestID=" + TripRequestID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAllByTripPlanDetailID(int TripPlanDetailID)
        {
            DataTable dt;
            try
            {
                //dt = b.SelectAll("EmployeeInTripPlanDetail");
                dt = b.SelectByQuery("SELECT	EmployeeInTripPlanDetail.ID,EmpName,Job_Position.PostName,Department.DeptName,EmpID As EmployeeID,TripPlanDetailID,Employee.PostID,Employee.DeptID FROM EmployeeInTripPlanDetail LEFT JOIN Employee ON Employee.ID = EmployeeInTripPlanDetail.EmpID"
                    + " INNER JOIN Job_Position ON Job_Position.ID = Employee.PostID INNER JOIN Department ON Department.ID = Employee.DeptID"
                    + " WHERE TripPlanDetailID =" + TripPlanDetailID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectByID(int employeeID)
        {
            string queryString = string.Format("SELECT * FROM Employee WHERE ID = {0}", employeeID);
            return b.SelectByQuery(queryString);
        }

        #endregion

        #region DELETE
        public int DeleteByID(int EmployeeInTripPlanDetailID)
        {
            int flag;
            try
            {
                flag = b.Delete("EmployeeInTripPlanDetail", EmployeeInTripPlanDetailID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return flag;
        }
        #endregion
    }
}
