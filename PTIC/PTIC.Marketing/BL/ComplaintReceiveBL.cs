using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using PTIC.Marketing.DA;
using PTIC.Common;
using PTIC.Common.BL;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class ComplaintReceiveBL : BaseBusinessLogic
    {        
        #region SELECT
        public DataTable GetProductInComplaintReceiveBYComplaintReceiveID(int ComplaintReceiveID)
        {
            return ComplaintReceiveDA.SelectProductInComplaintReceiveByComplaintReceiveID(ComplaintReceiveID);
        }

        public DataTable GetComplaintReceiveByComplaintReceiveID(int ComplaintReceiveID)
        {
            return ComplaintReceiveDA.SelectComplaintReceiveByComplaintReceiveID(ComplaintReceiveID);
        }

        public DataTable GetComplaintReceiveByReceiveDate(int ReceiveMonth,int ReceiveYear)
        {
            return ComplaintReceiveDA.SelectComplaintReceiveByReceiveDate(ReceiveMonth,ReceiveYear);
        }
        #endregion

        #region INSERT
        public int? AddComplaintReceived(
            ComplaintReceive newComplaintReceive, 
            List<ProductInComplaintReceive> newProductInComplaintReceives)
        {
            // Validate ComplaintReceive
            Validator<ComplaintReceive> comReceiveValidator = ValidationManager.CreateValidator<ComplaintReceive>();
            ValidationResults vResults = comReceiveValidator.Validate(newComplaintReceive);
            base.ValidationResults = vResults;
            if (!vResults.IsValid)
                return null;

            // Validate ProductInComplaintReceive
            if (newProductInComplaintReceives != null)
            {
                Validator<ProductInComplaintReceive> productValidator = ValidationManager.CreateValidator<ProductInComplaintReceive>();
                foreach (ProductInComplaintReceive product in newProductInComplaintReceives)
                {
                    ValidationResults pResults = productValidator.Validate(product);
                    base.ValidationResults = pResults;
                    if (!pResults.IsValid)
                        return null;
                }
            }
            // Save to database
            return ComplaintReceiveDA.InsertComplaintReceive(newComplaintReceive, newProductInComplaintReceives);
        }
        #endregion
    }
}
