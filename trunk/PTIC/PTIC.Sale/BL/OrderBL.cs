/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
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
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// Order business logic
    /// </summary>
    public class OrderBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SELECT
        /// <summary>
        /// Get all orders from system
        /// </summary>        
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll()
        {
            return OrderDA.SelectAll();
        }

        /// <summary>
        /// Get only the n records by filtering CurrentPage and PageSize
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="currentPage">Current page number</param>
        /// <param name="pageSize">Result record count</param>
        /// <returns>Return result DataTable</returns>
        public DataTable Get(DateTime? startDate, DateTime? endDate, int CustomerID,int DeptID,int currentPage, int pageSize)
        {
            int skip = currentPage * pageSize;
            return OrderDA.SelectTop(startDate, endDate,CustomerID,DeptID, pageSize, skip);
        }

        /// <summary>
        /// Get all order row count.
        ///     If startDate or endDate is null, get row count over all rows. Otherwise, over selected rows.
        /// </summary>
        /// <param name="startDate">Start date filter</param>
        /// <param name="endDate">End date filter</param>
        /// <returns>Return row count</returns>
        public int GetOrderCount(DateTime? startDate, DateTime? endDate)
        {
            return OrderDA.SelectOrderRowCount(startDate, endDate);
        }

        /// <summary>
        /// Get all lost orders row count with filters
        ///     If startDate or endDate is null, get row count over all rows. Otherwise, over selected rows.
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="townID">Town ID</param>
        /// <param name="productID">Product ID/param>
        /// <returns>Return row count</returns>
        public int GetLostCount(DateTime? startDate, DateTime? endDate, int? customerID, int? townID, int? productID)
        {
            return OrderDA.SelectLostOrderRowCount(startDate, endDate, customerID, townID, productID);
        }

        /// <summary>
        /// Get all lost orders row count without filters
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Return lost order row count</returns>
        public int GetLostCount(DateTime? startDate, DateTime? endDate)
        {
            return OrderDA.SelectLostOrderRowCount(startDate, endDate);
        }

        // TODO: Remove this method. No need any more!
        /// <summary>
        /// Get lost orders
        /// </summary>
        /// <returns>Return DataTable containing results data</returns>
        public DataTable GetLost()
        {
            return OrderDA.SelectLost();
        }

        /// <summary>
        /// Get lost orders between start and end row with specific filters
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="townID">Town ID</param>
        /// <param name="productID">Product ID</param>        
        /// <param name="pageSize">Result row count</param>
        /// <param name="skip">Start row to be skipped along with remaining rows</param>
        /// <returns>Return result DataTable</returns>      
        public DataTable GetLostTop(
            DateTime? startDate, DateTime? endDate,
            int? customerID, int? townID, int? productID,
            int currentPage, int pageSize)
        {
            int skip = currentPage * pageSize;
            return OrderDA.SelectLostTop(startDate, endDate, customerID, townID, productID, pageSize, skip);
        }

        /// <summary>
        /// Get all lost orders between start and end row without any filters
        /// </summary>
        /// <param name="pageSize">Result row count</param>
        /// <param name="skip">Start row to be skipped along with remaining rows</param>
        /// <returns>Return result DataTable</returns>
        public DataTable GetLostTop(int currentPage, int pageSize)
        {
            int skip = currentPage * pageSize;
            return OrderDA.SelectLostTop(pageSize, skip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDelivered"></param>        
        /// <returns></returns>
        public DataTable GetDelivered()
        {
            return OrderDA.SelectByIsDelivered(true);
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <returns></returns>
        public DataTable GetUndelivered()
        {
            return OrderDA.SelectByIsDelivered(false);
        }

        public DataTable GetByOrderNo(string orderNo)
        {
            return OrderDA.SelectByOrderNo(orderNo);
        }

        public DataTable GetByID(int orderID)
        {
            return OrderDA.SelectByID(orderID);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new order into system
        /// </summary>
        /// <param name="newOrder">New order entity</param>        
        /// <returns>Return affected row count</returns>
        public int Add(Order newOrder)
        {
            return OrderDA.Insert(newOrder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrder"></param>
        /// <param name="newOrderDetails"></param>
        /// <param name="conn"></param>
        /// <returns>Return inserted order id</returns>
        public int? Add(Order newOrder, List<OrderDetail> newOrderDetails)
        {                        
            try
            {
                // Null Order
                if (newOrder == null)
                {
                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult("Order စာရင်း ဖြည့်သွင်းပေးပါ။",
                            null, "InvoiceMaster", null, null));
                    return null;
                }
                else if (newOrderDetails == null || newOrderDetails.Count < 1) // Null OrderDetail or no records
                {
                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult("Order မှာယူမှုစာရင်း ဖြည့်သွင်းပေးပါ။",
                            null, "OrderDetailCount", null, null));
                    return null;
                }
                // Order validation
                Validator<Order> invoiceValidator = _validatorFactory.CreateValidator<Order>();
                ValidationResults vInvResults = invoiceValidator.Validate(newOrder);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return null;
                // OrderDetail validation
                Validator<OrderDetail> detailValidator = _validatorFactory.CreateValidator<OrderDetail>();
                foreach (OrderDetail detail in newOrderDetails)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return null;
                }
                // Do not allow duplicate product in OrderDetail
                var duplicatedTripPlanNo = newOrderDetails.GroupBy(x => new { x.ProductID }).Where(x => x.Skip(1).Any()).ToArray();
                if (duplicatedTripPlanNo.Any())
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.OrderDetail_ProductID_Duplicate,
                            null, "OrderDetail_ProductID_Duplicate", null, null));
                    return null;
                }
                // Do not allow duplicate product via db (this validation is set last in sequence bcoz it interacts with database)
                OrderDetailBL detailBL = new OrderDetailBL();
                foreach (OrderDetail detail in newOrderDetails)
                {
                    DataTable dtDuplicatedProduct = detailBL.GetBy(detail.OrderID, detail.ProductID);
                    if (dtDuplicatedProduct != null && dtDuplicatedProduct.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.OrderDetail_ProductID_Duplicate,
                            null, "OrderDetail_ProductID_Duplicate", null, null));
                        return null;
                    }
                }

                // Save into db
                return OrderDA.Insert(newOrder, newOrderDetails);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "OrderBL", null, null));
                return null;
            }            
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Update an existing order in system by order ID
        /// </summary>
        /// <param name="mdOrder">Order to be updated</param>
        /// <returns>Return affected row count</returns>
        public int UpdateByOrderID(Order mdOrder)
        {
            // Validate fields values
            if (mdOrder == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Order စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "NullOrder", null, null));
                return 0;
            }
            // Order validation
            Validator<Order> invoiceValidator = _validatorFactory.CreateValidator<Order>();
            ValidationResults vInvResults = invoiceValidator.Validate(mdOrder);
            base.ValidationResults = vInvResults;
            if (!vInvResults.IsValid)
                return 0;

            try
            {
                return OrderDA.UpdateByOrderID(mdOrder);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "OrderBL", null, null));
                return 0;
            }
        }

        public int Update(Order mdOrder, List<OrderDetail> mdOrderDetails, SqlConnection conn)
        {
            return OrderDA.Update(mdOrder, mdOrderDetails, conn);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete order from system by order ID
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByOrderID(int orderID, SqlConnection conn)
        {
            return OrderDA.DeleteByOrderID(orderID, conn);
        }
        #endregion
    }
}
