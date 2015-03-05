/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   SupplierBL
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
    public class SupplierBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SELECTALL
        public DataTable GetAll()
        {
            return SupplierDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int? Insert(Supplier newSupplier)
        {
            if (newSupplier == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Supplier အချက်အလက် ဖြည့်သွင်းပေးပါရန်။",
                        null, "SupplierBL", null, null));
                return null;
            }
            try
            {
                // clear leading and trailing while spaces
                newSupplier.SupplierName = newSupplier.SupplierName.Trim();

                // Supplier validation
                Validator<Supplier> supValidator = _validatorFactory.CreateValidator<Supplier>();
                ValidationResults vCusResults = supValidator.Validate(newSupplier);
                base.ValidationResults = vCusResults;
                if (!vCusResults.IsValid)
                    return null;

                DataTable dtSupplier = new SupplierBL().GetAll();
                foreach (DataRow row in dtSupplier.Rows)
                {
                    if (newSupplier.SupTypeID == (int)DataTypeParser.Parse(row["SupTypeID"], typeof(int), -1) && newSupplier.SupplierName == (string)DataTypeParser.Parse(row["SupplierName"], typeof(string), null))
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult("Duplicate Data Not Allowed!",
                            null, "Supplier", null, null));
                        return null;
                    }
                }


                // Save into db
                return SupplierDA.Insert(newSupplier);
            }

            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "SupplierBL", null, null));
                return null;
            }
        }
        #endregion

        #region UPDATE
        public int? Update(Supplier supplier)
        {
            if (supplier == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Supplier အချက်အလက် ဖြည့်သွင်းပေးပါရန်။",
                        null, "SupplierBL", null, null));
                return null;
            }
            try
            {
                // clear leading and trailing while spaces
                supplier.SupplierName = supplier.SupplierName.Trim();

                // Supplier validation
                Validator<Supplier> supValidator = _validatorFactory.CreateValidator<Supplier>();
                ValidationResults vCusResults = supValidator.Validate(supplier);
                base.ValidationResults = vCusResults;
                if (!vCusResults.IsValid)
                    return null;


                DataTable dtSupplier = new SupplierBL().GetAll();
                foreach (DataRow row in dtSupplier.Rows)
                {
                    if (supplier.SupTypeID == (int)DataTypeParser.Parse(row["SupTypeID"], typeof(int), -1) && supplier.SupplierName == (string)DataTypeParser.Parse(row["SupplierName"], typeof(string), null))
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult("Duplicate Data Not Allowed!",
                            null, "Supplier", null, null));
                        return null;
                    }
                }

                // Update data from db
                return SupplierDA.UpdateByID(supplier);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "SupplierBL", null, null));
                return null;
            }
        }
        #endregion

        #region DELETE
        public int? Delete(Supplier supplier)
        {
            if (supplier == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Supplier အချက်အလက် ဖြည့်သွင်းပေးပါရန်။",
                        null, "SupplierBL", null, null));
                return null;
            }
            try
            {
                // Delete from db
                return SupplierDA.DeleteByID(supplier);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "SupplierBL", null, null));
                return null;
            }
        }
        #endregion

    }
}
