using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class InitialMobileServicePlanDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectByDateRange(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtIntialMobileServicePlan;
            try
            {
                string query = String.Format("SELECT * FROM uv_InitialMobileServicePlan WHERE "
                                         + "CONVERT(DATE,InitialPlanDate,103) BETWEEN CONVERT(DATE,CAST('{0}' as DATE),103) "
                                                + "AND CONVERT(DATE,CAST('{1}' as DATE),103)", FromDate, ToDate);
                dtIntialMobileServicePlan = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtIntialMobileServicePlan;
        }      

        public static DataTable SelectInitialMobileServicePlanByInitialMobileServicePlanID(int InititalMobileServicePlanID, int CustomerID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_MobileServicePlanByRoute WHERE InitialMobileServicePlanID = {0} AND CustomerID ={1}";
                dt = b.SelectByQuery(String.Format(query, InititalMobileServicePlanID, CustomerID));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public static DataTable SelectCustomersByRouteID(int RouteID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_Customers WHERE RouteID = {0}";
                dt = b.SelectByQuery(String.Format(query, RouteID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectCustomersByRouteIDAndCustomerID(int RouteID, int CustomerID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_Customers WHERE RouteID = {0} AND CustomerID ={1}";
                dt = b.SelectByQuery(String.Format(query, RouteID, CustomerID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion


        #region INSERT      
        public static int Insert(InitialMobileServicePlan initialMobileServicePlan)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertInto("InitialMobileServicePlan", b.ConvertColName(initialMobileServicePlan), b.ConvertValueList(initialMobileServicePlan));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        #endregion

        #region Update
        public static int Update(InitialMobileServicePlan initialMobileServicePlan)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Update("InitialMobileServicePlan", initialMobileServicePlan.ID.ToString(), b.ConvertColName(initialMobileServicePlan), b.ConvertValueList(initialMobileServicePlan));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        #endregion
    }
}
