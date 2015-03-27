using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using System.Data;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.BL
{
    public class SalesServiceBL : BaseBusinessLogic
    {
        #region SELECT
        public DataTable GetAllByID(int SalesServiceID)
        {
            return SalesServiceDA.SelectAllByID(SalesServiceID);
        }
        #endregion

        #region INSERT
        public int SalesServiceReceivedInsert(
            SalesService salesService, 
            ServicedCustomer servicedCustomer, 
            int? VenID, int? WarehouseID)
        {
            /*** Validation ***/
            if (salesService == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("အကြောင်းအရာများကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullSaleService", null, null));
                return 0;
            }
            else if (servicedCustomer == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("End User Info (သို့မဟုတ်) Outlet User Info ကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullServicedCustomer", null, null));
                return 0;
            }
            else if(!VenID.HasValue && !WarehouseID.HasValue)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("အရောင်းကားနံပါတ် (သို့မဟုတ်) Showroom အမည် ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullVenhicleIDOrWarehouseID", null, null));
                return 0;
            }

            try
            {
                Validator<SalesService> salesServiceValidator = base.ValidationManager.CreateValidator<SalesService>();
                ValidationResults vSalesServiceResults = salesServiceValidator.Validate(salesService);
                base.ValidationResults = vSalesServiceResults;
                if (!vSalesServiceResults.IsValid)
                    return 0;

                // ServicedCustomer validation
                Validator<ServicedCustomer> servicedCusValidator = base.ValidationManager.CreateValidator<ServicedCustomer>();
                ValidationResults vServicedCusResults = servicedCusValidator.Validate(servicedCustomer);
                base.ValidationResults = vServicedCusResults;
                if (!vServicedCusResults.IsValid)
                    return 0;

                return SalesServiceDA.Insert(salesService, servicedCustomer, VenID, WarehouseID);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "SalesServiceBL", null, null));
                return 0;
            }
        }

        public int SalesServiceTransferReturnInsert(
            SalesService salesService, 
            ServiceBatteryStatus serviceBatteryStatus, 
            int? TransportedWarehouseID, int? TransportedVenID, int SalePersonID, int NowIam)
        {
            return SalesServiceDA.InsertTransferReturn(salesService, serviceBatteryStatus,TransportedWarehouseID, TransportedVenID,SalePersonID, NowIam);
        }

        public int SalesServiceTransferReturnInsert(
            List<SalesService> salesServices, 
            List<ServiceBatteryStatus> serviceBatteryStatus, 
            DateTime ReturnDate,int? TransportedWarehouseID, int? TransportedVenID, int SalePersonID, int NowIam)
        {
            return SalesServiceDA.Insert(salesServices, serviceBatteryStatus, ReturnDate,TransportedWarehouseID, TransportedVenID, SalePersonID, NowIam);
        }
        #endregion

        #region UPDATE BY ID
        public int SalesServiceUpdateByID(
            SalesService saleService, 
            ServicedCustomer servicedCustomer)
        {
            /*** Validation ***/
            if (saleService == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Service Battery Detail မှ အကြောင်းအရာများကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullSaleService", null, null));
                return 0;
            }
            else if (servicedCustomer == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Service Battery Detail မှ အကြောင်းအရာများကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullServicedCustomer", null, null));
                return 0;
            }

            try
            {
                // SalesService validation
                saleService.ReceivedDate = DateTime.Now; // Bypass validation
                saleService.ProductID = 1; // Bypass validation
                saleService.Giver = "Giver"; // Bypass validation
                saleService.Taker = "Taker"; // Bypass validation
                saleService.Whereami = 0; // Bypass validation

                saleService.JobNo = saleService.JobNo.Trim();
                Validator<SalesService> salesServiceValidator = base.ValidationManager.CreateValidator<SalesService>();
                ValidationResults vSalesServiceResults = salesServiceValidator.Validate(saleService);
                base.ValidationResults = vSalesServiceResults;
                if (!vSalesServiceResults.IsValid)
                    return 0;

                // ServicedCustomer validation
                servicedCustomer.CustomerID = 1; // Bypass validation

                Validator<ServicedCustomer> servicedCusValidator = base.ValidationManager.CreateValidator<ServicedCustomer>();
                ValidationResults vServicedCusResults = servicedCusValidator.Validate(servicedCustomer);
                base.ValidationResults = vServicedCusResults;
                if (!vServicedCusResults.IsValid)
                    return 0;

                return SalesServiceDA.UpdateByID(saleService, servicedCustomer);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "SalesServiceBL", null, null));
                return 0;
            }
        }

        public int SalesServiceUpdateServiceByID(SalesService saleService, SqlConnection conn)
        {
            return SalesServiceDA.UpdateServiceByID(saleService, conn);
        }


        public DateTime GetValidLastTime(int SalesSerViceId) 
        {
            return SalesServiceDA.GetValidLastTime(SalesSerViceId);
            
        }
        #endregion
    }
}
