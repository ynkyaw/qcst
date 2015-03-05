
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: March 2 2014
 * Description: About Trip Request BL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Common.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// TripRequest business logic
    /// </summary>
    public class TripRequestBL
    {
        #region SELECT
        /// <summary>
        /// Get all TripRequest from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll()
        {
            return TripRequestDA.SelectAll();
        }

        public DataTable SelectBy(DateTime fromDate, DateTime toDate,bool isSale, SqlConnection conn)
        {
            return TripRequestDA.SelectBy(fromDate, toDate,isSale, conn);
        }

        public DataTable SelectByTripRequestID(int tripRequestID, SqlConnection conn)
        {
            return TripRequestDA.GetByTripRequestID(tripRequestID, conn);
        }


        //public DataTable GetLost(SqlConnection conn)
        //{
        //    return TripRequestDA.SelectLost(conn);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDelivered"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        //public DataTable GetDelivered(SqlConnection conn)
        //{
        //    return TripRequestDA.SelectByIsDelivered(true, conn);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        //public DataTable GetUndelivered(SqlConnection conn)
        //{
        //    return OrderDA.SelectByIsDelivered(false, conn);
        //}

        //public DataTable GetByNo(string No, SqlConnection conn)
        //{
        //    return TripRequestDA.SelectByTripRequestNo(No, conn);
        //}
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new TripRequest into system
        /// </summary>
        /// <param name="newOrder">New TripRequest entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Add(TripRequest newTripRequest, List<Employee> EmployeesList, SqlConnection conn)
        {
            return TripRequestDA.Insert(newTripRequest, EmployeesList, conn);
        }

        //public int Add(TripRequest newTripRequest, List<TripRequestDetail> newTripRequestDetails, SqlConnection conn)
        //{
        //    return TripRequestDA.Insert(newTripRequest, newTripRequestDetails, conn);
        //}
        #endregion

        #region UPDATE
        /// <summary>
        /// Update an existing TripRequest in system by order ID
        /// </summary>
        /// <param name="mdTripRequest">TripRequest to be updated</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int UpdateByTripRequestID(TripRequest mdTripRequest, List<Employee> EmployeesList, SqlConnection conn)
        {
            return TripRequestDA.UpdateByTripRequestID(mdTripRequest,EmployeesList, conn);
        }


        /// <summary>
        /// Update an existing AP_RequestID in system by order ID
        /// </summary>
        /// <param name="mdTripRequest">AP_RequestID to be updated</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int UpdateAPRequestIDByTripRequestID(TripRequest mdTripRequest, List<Employee> EmployeesList, SqlConnection conn)
        {
            return TripRequestDA.UpdateAPRequestByTripRequestID(mdTripRequest, EmployeesList, conn);
        }

        //public int Update(TripRequest mdTripRequest, List<TripRequestDetail> mdTripRequestDetails, SqlConnection conn)
        //{
        //    return TripRequestDA.Update(mdTripRequest, mdTripRequestDetails, conn);
        //}
        #endregion

        #region DELETE
        /// <summary>
        /// Delete TripRequest from system by order ID
        /// </summary>
        /// <param name="TripRequestID">TripRequest ID</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByTripRequestID(int TripRequestID, SqlConnection conn)
        {
            return TripRequestDA.DeleteByTripRequestID(TripRequestID, conn);
        }
        #endregion
    }
}
