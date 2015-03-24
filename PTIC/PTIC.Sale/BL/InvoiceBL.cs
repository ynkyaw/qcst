/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 *              Aung Ko Ko <?>
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Invoice business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PTIC.Sale.BL
{
    public class InvoiceBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SELECT
        /// <summary>
        /// Get all InvoiceVoucher from system
        /// </summary>
        /// <returns>Return datatable containing all customers</returns>
        public DataTable GetAll()
        {
            return InvoiceDA.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeID"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public DataTable GetCreditSaleInvoice(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            return InvoiceDA.SelectCreditSaleInvoice(startDate, endDate, employeeID, customerID);
        }

        /// <summary>
        /// Get invoices that have not been part of any payments
        /// </summary>
        /// <returns></returns>
        public DataTable GetInvoicesWithoutAnyPayment()
        {
            return InvoiceDA.SelectInvoicesWithoutAnyPayment();
        }

        public DataTable GetAllPayment()
        {
            return InvoiceDA.SelectAllPayment();
        }
        
        /// <summary>
        /// Get InvoiceVoucher BY DeliveryNo from system
        /// </summary>        
        /// <returns>Return datatable containing a specific delivery</returns>
        public DataTable GetByDeliveryNo(string deliveryNo)
        {
            return InvoiceDA.SelectByDeliveryNo(deliveryNo);
        }

        public DataTable GetVouchers()
        {
            return InvoiceDA.SelectAll();
        }

        public DataTable GetSaleDetailByInvoiceID(int? InvoiceID)
        {
            return InvoiceDA.SelectByInvoiceID(InvoiceID);
        }

        public DataTable GetSaleDetailByInvoiceNo(string invoiceNo)
        {
            return InvoiceDA.SelectByInvoiceNo(invoiceNo);
        }

        /// <summary>
        /// Get all cash sale invoices from system
        /// </summary>
        /// <returns>Return datatable containing all cash sale invoices</returns>
        public DataTable GetCashSaleInvoice(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            return InvoiceDA.SelectCashSaleInvoice(startDate, endDate, employeeID, customerID);
        }
        #endregion

        #region Validation Only
        public void Validate(Invoice newInvoice, List<SaleDetail> newSaleDetailRecords, int VenID, int WarehouseID)
        {
            try
            {
                if (newSaleDetailRecords == null || newSaleDetailRecords.Count < 1)
                {
                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult("Product ဝယ်ယူမှုစာရင်း ဖြည့်သွင်းပေးပါ။",
                            null, "SalesDetailCount", null, null));
                    return;
                }
                else if (newInvoice == null)
                {
                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult("Invoice စာရင်း ဖြည့်သွင်းပေးပါ။",
                            null, "InvoiceMaster", null, null));
                    return;
                }
                // Invoice
                Validator<Invoice> invoiceValidator = _validatorFactory.CreateValidator<Invoice>();
                ValidationResults vInvResults = invoiceValidator.Validate(newInvoice);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return;

                // SaleDetail            
                Validator<SaleDetail> detailValidator = _validatorFactory.CreateValidator<SaleDetail>();
                foreach (SaleDetail detail in newSaleDetailRecords)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return;
                }
               
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                    null, "InvoiceMaster", null, null));
                return;
            }
        }


        #endregion

        #region Insert Invoice Voucher

        /// <summary>
        /// Save credit invoice
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <param name="newSaleDetailRecords"></param>
        /// <param name="VenID">0 means not via vehicle</param>
        /// <param name="WarehouseID">0 means not via warehouse </param>
        /// <returns></returns>
        public int? Add(Invoice newInvoice, List<SaleDetail> newSaleDetailRecords, int VenID, int WarehouseID)
        {
            try
            {
                Validate(newInvoice,newSaleDetailRecords,VenID,WarehouseID);
                if (!base.ValidationResults.IsValid) // If validation failed
                    return null;
                 
                // Save into database
                return InvoiceDA.Insert(newInvoice, newSaleDetailRecords,VenID,WarehouseID);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                    null, "InvoiceMaster", null, null));
                    return null;
            }
        }

        /// <summary>
        /// Save cash sale invoice from warehouse
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <param name="newSaleDetailRecords"></param>
        /// <param name="newCommDiscount"></param>        
        /// <returns>Return an inserted Invoice</returns>
        public int? CashSaleFromWarehouse(Invoice newInvoice, List<SaleDetail> newSaleDetailRecords, int warehouseID,
            CommDiscount newCommDiscount, Tax newTax)
        {
            if (newInvoice == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Invoice စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "InvoiceMaster", null, null));
                return null;
            }
            else if (newSaleDetailRecords == null || newSaleDetailRecords.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("ဝယ်ယူသည့် Product စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "SalesDetailCount", null, null));
                return null;
            }
            else if(warehouseID < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Warehouse ဖြည့်သွင်းပေးပါရန်။",
                        null, "InvalidWarehouseID", null, null));
                return null;
            }
            try
            {
                // Invoice
                Validator<Invoice> invoiceValidator = _validatorFactory.CreateValidator<Invoice>();
                ValidationResults vInvResults = invoiceValidator.Validate(newInvoice);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return null;
                // SaleDetail            
                Validator<SaleDetail> detailValidator = _validatorFactory.CreateValidator<SaleDetail>();
                foreach (SaleDetail detail in newSaleDetailRecords)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return null;
                }
                // Save cash sale into database
                return InvoiceDA.InsertCashInvoice(newInvoice, newSaleDetailRecords,
                false, warehouseID,
                true, // Enable stock control
                newCommDiscount, newTax);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "InvoiceBL", null, null));
                return null;
            }
        }

        /// <summary>
        /// Open cash sale invoice from vehicle
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <param name="newSaleDetailRecords"></param>
        /// <param name="vehicleID"></param>
        /// <param name="newCommDiscount"></param>
        /// <param name="newTax"></param>        
        /// <returns>Return an inserted Invoice</returns>
        public int? CashSaleFromVehicle(
            Invoice newInvoice, 
            List<SaleDetail> newSaleDetailRecords, 
            int vehicleID,
            CommDiscount newCommDiscount, 
            Tax newTax)
        {
            if (newInvoice == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Invoice စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "InvoiceMaster", null, null));
                return null;
            }
            else if (newSaleDetailRecords == null || newSaleDetailRecords.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("ဝယ်ယူသည့် Product စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "SalesDetailCount", null, null));
                return null;
            }
            else if(vehicleID < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("အရောင်းကားနံပါတ် ဖြည့်သွင်းပေးပါရန်။",
                        null, "InvalidVehicle", null, null));
                return null;
            }
            
            try
            {
                // Invoice
                Validator<Invoice> invoiceValidator = _validatorFactory.CreateValidator<Invoice>();
                ValidationResults vInvResults = invoiceValidator.Validate(newInvoice);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return null;
                // SaleDetail            
                Validator<SaleDetail> detailValidator = _validatorFactory.CreateValidator<SaleDetail>();
                foreach (SaleDetail detail in newSaleDetailRecords)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return null;
                }
                // Save cash sale into database
                return InvoiceDA.InsertCashInvoice(newInvoice, newSaleDetailRecords,
                    true, vehicleID,
                    true, // Enable stock control
                    newCommDiscount, newTax);
            }
            catch(Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "InvoiceBL", null, null));
                return null;
            }            
        }


        public static DataTable GetDailySalesReport() 
        {
            return InvoiceDA.SelectDailyReports();
        
        }
        #endregion

        public void ValidateVehicle(Invoice newInvoice, List<SaleDetail> newSaleDetailRecords, int vehicleID,
            CommDiscount newCommDiscount, Tax newTax)
        {
            if (newInvoice == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Invoice စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "InvoiceMaster", null, null));
                return;
            }
            else if (newSaleDetailRecords == null || newSaleDetailRecords.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("ဝယ်ယူသည့် Product စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "SalesDetailCount", null, null));
                return;
            }

            try
            {
                // Invoice
                Validator<Invoice> invoiceValidator = _validatorFactory.CreateValidator<Invoice>();
                ValidationResults vInvResults = invoiceValidator.Validate(newInvoice);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return;
                // SaleDetail            
                Validator<SaleDetail> detailValidator = _validatorFactory.CreateValidator<SaleDetail>();
                foreach (SaleDetail detail in newSaleDetailRecords)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return;
                }
                
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "InvoiceBL", null, null));
                return;
            }
        }


        public void ValidateWarehouse(Invoice newInvoice, List<SaleDetail> newSaleDetailRecords, int warehouseID,
            CommDiscount newCommDiscount, Tax newTax)
        {
            if (newInvoice == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Invoice စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "InvoiceMaster", null, null));
                return;
            }
            else if (newSaleDetailRecords == null || newSaleDetailRecords.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("ဝယ်ယူသည့် Product စာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "SalesDetailCount", null, null));
                return;
            }

            try
            {
                // Invoice
                Validator<Invoice> invoiceValidator = _validatorFactory.CreateValidator<Invoice>();
                ValidationResults vInvResults = invoiceValidator.Validate(newInvoice);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return;
                // SaleDetail            
                Validator<SaleDetail> detailValidator = _validatorFactory.CreateValidator<SaleDetail>();
                foreach (SaleDetail detail in newSaleDetailRecords)
                {
                    ValidationResults vResults = detailValidator.Validate(detail);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return;
                }
                
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "InvoiceBL", null, null));
                return;
            }
        }
    }
}
