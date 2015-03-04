/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/MM/dd)
 * Description: A_P_Usage business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class A_P_UsageBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();


        #region SELECT
        public DataTable GetByA_P_UsageID(int A_P_UsageID, SqlConnection conn)
        {
            return A_P_UsageDA.SelectByA_P_UsageID(A_P_UsageID, conn);
        }

        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newA_P_Usage"></param>
        /// <param name="newA_P_UsageDetails"></param>
        /// <param name="conn"></param>
        /// <returns>Return inserted A_P_UsageID</returns>
        public int? Add(A_P_Usage newA_P_Usage, List<A_P_UsageDetail> newA_P_UsageDetails, SqlConnection conn)
        {
            // Null A_P_Usage
            if (newA_P_Usage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("A_P အသုံးစာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "AP_UsageMaster", null, null));
                return null;
            }
            else if (newA_P_UsageDetails == null || newA_P_UsageDetails.Count < 1) // Null OrderDetail or no records
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("A_P အသုံးစာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "OrderDetailCount", null, null));
                return null;
            }
            
            // A_P_UsageDetail validation
            Validator<A_P_UsageDetail> detailValidator = _validatorFactory.CreateValidator<A_P_UsageDetail>();
            foreach (A_P_UsageDetail detail in newA_P_UsageDetails)
            {
                ValidationResults vResults = detailValidator.Validate(detail);
                base.ValidationResults = vResults;
                if (!vResults.IsValid)
                    return null;
            }

            return A_P_UsageDA.Insert(newA_P_Usage, newA_P_UsageDetails, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByA_P_UsageID(A_P_Usage mdA_P_Usage, SqlConnection conn)
        {
            return A_P_UsageDA.UpdateByA_P_UsageID(mdA_P_Usage, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByA_P_UsageID(int A_P_UsageID, SqlConnection conn)
        {
            return A_P_UsageDA.DeleteByA_P_UsageID(A_P_UsageID, conn);
        }

        #endregion
        
    }
}
