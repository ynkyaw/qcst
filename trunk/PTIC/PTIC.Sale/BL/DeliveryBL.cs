/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Delivery business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using PTIC.Common.BL;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// Delivery business logic
    /// </summary>
    public class DeliveryBL : BaseBusinessLogic
    {
        
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SELECT

        public DataTable GetStockInSubStore(int ProductID,int WarehouseID)
        {
            return DeliveryDA.SelectStockInSubStoreByProdutID(ProductID,WarehouseID);
        }

        public DataTable GetStockInVehicle(int VanID,int ProductID)
        {
            return DeliveryDA.SelectStockInVehicle(VanID,ProductID);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataTable GetPlanned()
        {
            return DeliveryDA.SelectByStatus(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataTable GetPlannedBy(int? salesPersonID, int? customerID, DateTime? startDate, DateTime? endDate)
        {
            return DeliveryDA.SelectBy(false, salesPersonID, customerID, startDate, endDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataTable GetDelivered()
        {
            return DeliveryDA.SelectByStatus(true);
        }


        /// <summary>
        /// Get only the n records by filtering CurrentPage and PageSize
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="employeeID">Employee ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="currentPage">Current page number</param>
        /// <param name="pageSize">Result record count</param>
        /// <returns>Return result DataTable</returns>
        public DataTable GetDeliveredTop(
            DateTime? startDate, DateTime? endDate, 
            int? employeeID, int? customerID, 
            int currentPage, int pageSize)
        {
            int skip = currentPage * pageSize;
            return DeliveryDA.SelectTop(startDate, endDate, employeeID, customerID, pageSize, skip);
        }
       
        /// <summary>
        /// Get row count.
        ///     If startDate or endDate is null, get row count over all rows. Otherwise, over selected rows.
        /// </summary>
        /// <param name="startDate">Start date filter</param>
        /// <param name="endDate">End date filter</param>
        /// <param name="employeeID">Employee ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <returns>Return row count</returns>
        public int GetCount(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            return DeliveryDA.SelectRowCount(startDate, endDate, employeeID, customerID);
        }

        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDelivery"></param>        
        /// <returns></returns>
        public int Add(Delivery newDelivery)
        {
            return DeliveryDA.Insert(newDelivery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDelivery"></param>
        /// <param name="newDeliveryDetails"></param>
        /// <returns></returns>
        public int Add(Delivery newDelivery, List<DeliveryDetail> newDeliveryDetails)
        {
            // Validate fields
            Validator<DeliveryDetail> detailValidator = _validatorFactory.CreateValidator<DeliveryDetail>();
            foreach(DeliveryDetail detail in newDeliveryDetails)
            {
                ValidationResults vResults = detailValidator.Validate(detail);
                base.ValidationResults = vResults;
                if (!vResults.IsValid)                
                    return 0;
            }
            return DeliveryDA.Insert(newDelivery, newDeliveryDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrderLost"></param>
        /// <param name="newLostDeliveryDetails"></param>
        /// <returns></returns>
        public int ToOrderLost(Delivery newOrderLost, List<DeliveryDetail> newLostDeliveryDetails)
        {
            // Set status as "Delivered"
            newOrderLost.Status = true;
            // Set Delivery Qty = zero for order lost
            foreach(DeliveryDetail newDetail in newLostDeliveryDetails)
            {
                newDetail.DeliverQty = 0;
            }            
            return DeliveryDA.Insert(newOrderLost, newLostDeliveryDetails);
        }

        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdDelivery"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int UpdateByDeliveryID(Delivery mdDelivery, SqlConnection conn)
        {
            return DeliveryDA.UpdateByDeliveryID(mdDelivery, conn);
        }

        public int UpdateAsDeliveredByID(int deliveryID)
        {
            return DeliveryDA.UpdateStatusByDeliveryID(deliveryID, true);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int DeleteByDeliveryID(string deliveryID, SqlConnection conn)
        {
            return DeliveryDA.DeleteByDeliveryID(deliveryID, conn);
        }
        #endregion
    }
}
