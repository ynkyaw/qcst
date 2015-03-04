/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Order detail business logic class
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
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderDetailBL : BaseBusinessLogic
    {
        #region SELECT
        public DataTable GetAll()
        {
            return OrderDetailDA.SelectAll();
        }

        public DataTable GetByOrderID(int orderID)
        {
            return OrderDetailDA.SelectByOrderID(orderID);
        }

        public DataTable GetByOrderNo(string orderNo)
        {
            return OrderDetailDA.SelectByOrderNo(orderNo);
        }

        public DataTable GetBy(int orderID, int productID)
        {
            return OrderDetailDA.SelectBy(orderID, productID);
        }
        #endregion

        #region INSERT 
        public int Add(List<OrderDetail> newOrderDetails)
        {                        
            try
            {
                // Validate fields values
                if (newOrderDetails == null || newOrderDetails.Count < 1)
                {
                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult("Order မှာယူမှုစာရင်း ဖြည့်သွင်းပေးပါ။",
                            null, "NullOrderDetail", null, null));
                    return 0;
                }
                // OrderDetail
                Validator<OrderDetail> detailValidator = base.ValidationManager.CreateValidator<OrderDetail>();
                foreach (OrderDetail detail in newOrderDetails)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return 0;
                }
                // Do not allow duplicate product
                var duplicatedTripPlanNo = newOrderDetails.GroupBy(x => new { x.ProductID }).Where(x => x.Skip(1).Any()).ToArray();
                if (duplicatedTripPlanNo.Any())
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.OrderDetail_ProductID_Duplicate,
                            null, "OrderDetail_ProductID_Duplicate", null, null));
                    return 0;
                }
                // Do not allow duplicate product via db (this validation is set last in sequence bcoz it interacts with database)
                foreach (OrderDetail detail in newOrderDetails)
                {
                    DataTable dtDuplicatedProduct = this.GetBy(detail.OrderID, detail.ProductID);
                    if (dtDuplicatedProduct != null && dtDuplicatedProduct.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.OrderDetail_ProductID_Duplicate,
                            null, "OrderDetail_ProductID_Duplicate", null, null));
                        return 0;
                    }    
                }
                // Save into db
                return OrderDetailDA.Insert(newOrderDetails);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "OrderDetailBL", null, null));
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public int UpdateByOrderDetailID(List<OrderDetail> mdOrderDetails)
        {
            try
            {
                // Null OrderDetail or no record
                if (mdOrderDetails == null || mdOrderDetails.Count < 1)
                {
                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult("Order မှာယူမှုစာရင်း ဖြည့်သွင်းပေးပါ။",
                            null, "OrderDetailCount", null, null));
                    return 0;
                }
                // OrderDetail validation
                Validator<OrderDetail> detailValidator = base.ValidationManager.CreateValidator<OrderDetail>();
                foreach (OrderDetail detail in mdOrderDetails)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return 0;
                }
                // Do not allow duplicate product
                var duplicatedTripPlanNo = mdOrderDetails.GroupBy(x => new { x.ProductID }).Where(x => x.Skip(1).Any()).ToArray();
                if (duplicatedTripPlanNo.Any())
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.OrderDetail_ProductID_Duplicate,
                            null, "OrderDetail_ProductID_Duplicate", null, null));
                    return 0;
                }
                // Do not allow duplicate product via db (this validation is set last in sequence bcoz it interacts with database)
                foreach (OrderDetail detail in mdOrderDetails)
                {
                    DataTable dtDuplicatedProduct = this.GetBy(detail.OrderID, detail.ProductID);
                    if (dtDuplicatedProduct != null && dtDuplicatedProduct.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.OrderDetail_ProductID_Duplicate,
                            null, "OrderDetail_ProductID_Duplicate", null, null));
                        return 0;
                    }
                }

                // Save into db
                return OrderDetailDA.UpdateByOrderDetailID(mdOrderDetails);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "OrderDetailBL", null, null));
                return 0;
            }
        }
        #endregion

        #region DELETE
        public int DeleteByOrderDetailID(int orderDetailID)
        {
            return OrderDetailDA.DeleteByOrderDetailID(orderDetailID);
        }
        #endregion
    }
}
