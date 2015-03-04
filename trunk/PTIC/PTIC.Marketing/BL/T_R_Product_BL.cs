
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2014
 * Description: About T_R_Product
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
    /// T_R_Product business logic
    /// </summary>
    public class T_R_Product_BL
    {
        #region SELECT
        /// <summary>
        /// Get all T_R_Product from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll(SqlConnection conn)
        {
            return T_R_Product_DA.SelectAll(conn);
        }

        public DataTable GetByTripReqID(int TripRequestID, SqlConnection conn)
        {
            return T_R_Product_DA.SelectByTripReqID(TripRequestID, conn);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new T_R_Product into system
        /// </summary>
        /// <param name="newOrder">New T_R_Product entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Add(List<T_R_Product> newT_R_Product, SqlConnection conn)
        {
            return T_R_Product_DA.Insert(newT_R_Product, conn);
        }

       
        #endregion

        #region UPDATE

        public int UpdateByT_R_productID(List<T_R_Product> mdT_R_Product, SqlConnection conn)
        {
            return T_R_Product_DA.UpdateByT_R_ProductID(mdT_R_Product, conn);
        }

       
        #endregion

        #region DELETE

        public int DeleteByT_R_ProductID(List<T_R_Product> t_R_Product, SqlConnection conn)
        {
            return T_R_Product_DA.DeleteByT_R_ProductID(t_R_Product, conn);
        }
        #endregion
    }
}
