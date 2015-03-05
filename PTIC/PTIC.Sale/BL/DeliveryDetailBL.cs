/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Order business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class DeliveryDetailBL
    {
        public DataTable GetStockQtyByProductID(int ProductID)
        {
            return DeliveryDetailDA.SelectStockQtyByProductID(ProductID);
        }

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataTable GetAll(SqlConnection conn)
        {
            return DeliveryDetailDA.SelectAll(conn);
        }

        public DataTable GetByDeliveryID(int deliveryID)
        {
            return DeliveryDetailDA.SelectByDeliveryID(deliveryID);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDeliveryDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int Add(DeliveryDetail newDeliveryDetail, SqlConnection conn)
        {
            return DeliveryDetailDA.Insert(newDeliveryDetail, conn);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdDeliveryDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int UpdateByDeliveryDetailID(DeliveryDetail mdDeliveryDetail, SqlConnection conn)
        {
            return DeliveryDetailDA.UpdateByDeliveryDetailID(mdDeliveryDetail, conn);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int DeleteByDeliveryDetailID(string deliveryDetailID, SqlConnection conn)
        {
            return DeliveryDetailDA.DeleteByDeliveryDetailID(deliveryDetailID, conn);
        }
        #endregion
    }
}
