/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   BankBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using PTIC.Common.BL;

namespace PTIC.Sale.BL
{
    public class BankBL: BaseBusinessLogic
    {        
        #region SELECTALL
        public DataTable GetAll()
        {
            return BankDA.SelectAll();
        }

        public DataTable GetBy(int TownID, string BankName)
        {
            return BankDA.SelectBy(TownID, BankName);
        }
        #endregion

        #region INSERT
        public int Insert(Bank bank)
        {
            if (bank == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Bank Name must not be null!",
                        null, "BankBL", null, null));
                return 0;
            }

            // Field validation
            Validator<Bank> detailValidator = base.ValidationManager.CreateValidator<Bank>();
            ValidationResults vResults = detailValidator.Validate(bank);
            base.ValidationResults = vResults;
            if (!vResults.IsValid)
                return 0;
            // duplicate field validation via db
            DataTable duplicateData = this.GetBy(bank.TownID,bank.BankName);
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Bank_BankName_Duplicate,
                        null, "BankBL", null, null));
                return 0;
            }
            
            // Save it into db
            return BankDA.Insert(bank);
        }
        #endregion

        #region UPDATE
        public int Update(Bank bank)
        {
            if (bank == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Bank Name must not be null!",
                        null, "BankBL", null, null));
                return 0;
            }

            // duplicate field validation
            DataTable duplicateData = this.GetBy(bank.TownID, bank.BankName);
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Bank_BankName_Duplicate,
                        null, "BankBL", null, null));
                return 0;
            }

            return BankDA.UpdateByID(bank);
        }
        #endregion

        #region DELETE
        public int Delete(Bank bank)
        {
            return BankDA.DeleteByID(bank);
        }
        #endregion

    }
}
