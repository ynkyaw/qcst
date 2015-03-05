
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2014
 * Description: About T_R_AP
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// T_R_AP business logic
    /// </summary>
    public class T_R_AP_BL
    {
        #region SELECT
        /// <summary>
        /// Get all T_R_AP from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll(SqlConnection conn)
        {
            return T_R_AP_DA.SelectAll(conn);
        }

        public DataTable GetByTripReqID(int TripReqID, SqlConnection conn)
        {
            return T_R_AP_DA.SelectByTripReqID(TripReqID, conn);
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
    
        #endregion

        #region INSERT

        public int Add(List<T_R_AP> newT_R_AP, SqlConnection conn)
        {
            return T_R_AP_DA.Insert(newT_R_AP, conn);
        }

       
        #endregion

        #region UPDATE
        public int UpdateByTR_AP_ID(List<T_R_AP> newT_R_AP, SqlConnection conn)
        {
            return T_R_AP_DA.UpdateByT_R_APID(newT_R_AP, conn);
        }
        
        #endregion

        #region DELETE
        public int DeleteByTR_AP_ID(List<T_R_AP> newT_R_AP, SqlConnection conn)
        {
            return T_R_AP_DA.DeleteByT_R_APID(newT_R_AP, conn);
        }


        #endregion
    }
}
