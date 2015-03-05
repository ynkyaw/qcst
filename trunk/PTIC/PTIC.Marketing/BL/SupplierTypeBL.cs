/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   SupplierTypeBL
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using AGL.Util;

namespace PTIC.Marketing.BL
{
    public class SupplierTypeBL : BaseBusinessLogic
    { //        
        #region SELECTALL
        public DataTable GetAll()
        {
            return SupplierTypeDA.SelectAll();
        }
        #endregion

        #region Validation Block
        public void Validate(SupplierType supplierType)
        {
            try
            {
                if (supplierType == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Supplier Type ဖြည့်သွင်းပေးပါ။",
                            null, "SupplierType", null, null));
                    return;
                }
                // SupplierType
                Validator<SupplierType> invoiceValidator = base.ValidationManager.CreateValidator<SupplierType>();
                ValidationResults vInvResults = invoiceValidator.Validate(supplierType);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return;

                if ((int)DataTypeParser.Parse(supplierType.SupplierTypeID, typeof(int), -1) == -1)
                {
                    DataTable dtSupplerType = new SupplierTypeBL().GetAll();
                    foreach (DataRow row in dtSupplerType.Rows)
                    {
                        if (supplierType.SupplierTypeName == (string)DataTypeParser.Parse(row["SupplierType"], typeof(string), null))
                        {
                            base.ValidationResults.AddResult(
                            new ValidationResult("Supplier Type Name ထပ်နေသည်။",
                                null, "SupplierType", null, null));
                            return;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                    null, "SupplierType", null, null));
                return;
            }
        }
        #endregion

        #region INSERT
        public int? Insert(SupplierType supplierType)
        {
            try
            {
                Validate(supplierType);

                if (base.ValidationResults.IsValid)
                {
                    return SupplierTypeDA.Insert(supplierType);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                   new ValidationResult(e.Message,
                   null, "SupplierTYpe", null, null));
                return null;
            }

        }
        #endregion

        #region UPDATE
        public int? Update(SupplierType supplierType)
        {
            try
            {
                Validate(supplierType);

                DataTable dtSupplerType = new SupplierTypeBL().GetAll();
                foreach (DataRow row in dtSupplerType.Rows)
                {
                    if (supplierType.SupplierTypeName == (string)DataTypeParser.Parse(row["SupplierType"], typeof(string), null))
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult("Supplier Type Name ထပ်နေသည်။",
                            null, "SupplierType", null, null));
                        return null;
                    }
                }

                if (base.ValidationResults.IsValid)
                {
                    return SupplierTypeDA.UpdateByID(supplierType);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                    null, "SupplierType", null, null));
                return null;
            }
        }
        #endregion

        #region DELETE
        public int Delete(SupplierType supplierType, SqlConnection conn)
        {
            return SupplierTypeDA.DeleteByID(supplierType, conn);
        }
        #endregion
        //
    }
}
