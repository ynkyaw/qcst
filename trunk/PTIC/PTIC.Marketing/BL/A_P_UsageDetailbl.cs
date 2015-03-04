/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/mm/dd)
 * Description: A_P_Usage detail business logic class
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

namespace PTIC.Marketing.BL
{
    public class A_P_UsageDetailBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();


        #region SELECT
        public DataTable GetByA_P_UsageID(int A_P_UsageID, SqlConnection conn)
        {
            return A_P_UsageDetailDA.SelectByA_P_UsageID(A_P_UsageID, conn);
        }
        #endregion

        #region INSERT
        public int? Add(A_P_UsageDetail newA_P_UsageDetail, int vehicleID,
            SqlConnection conn)
        {
            if (newA_P_UsageDetail == null) // Null OrderDetail or no records
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("A_P အသုံးစာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "OrderDetailCount", null, null));
                return null;
            }

            // A_P_UsageDetail validation
            Validator<A_P_UsageDetail> detailValidator = _validatorFactory.CreateValidator<A_P_UsageDetail>();
            ValidationResults vResults = detailValidator.Validate(newA_P_UsageDetail);
            base.ValidationResults = vResults;
            if (!vResults.IsValid)
                return null;
            
            return A_P_UsageDetailDA.Insert(newA_P_UsageDetail, vehicleID, conn);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Update A P Usage Detail and control A P Materail quantity in a specific vehicle
        /// </summary>
        /// <param name="mdA_P_UsageDetail">A P Usage Detail</param>
        /// <param name="vehicleID">Vehicle ID in which A P Material quantiy is to be substracted</param>
        /// <param name="conn">SqlConnection</param>
        /// <returns>Affected row count</returns>
        public int? UpdateByA_P_UsageDetailID(A_P_UsageDetail mdA_P_UsageDetail, int vehicleID,
            SqlConnection conn)
        {
            if (mdA_P_UsageDetail == null) // Null OrderDetail or no records
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("A_P အသုံးစာရင်း ဖြည့်သွင်းပေးပါ။",
                        null, "OrderDetailCount", null, null));
                return null;
            }

            // A_P_UsageDetail validation
            Validator<A_P_UsageDetail> detailValidator = _validatorFactory.CreateValidator<A_P_UsageDetail>();
            ValidationResults vResults = detailValidator.Validate(mdA_P_UsageDetail);
            base.ValidationResults = vResults;
            if (!vResults.IsValid)
                return null;

            return A_P_UsageDetailDA.UpdateByA_P_UsageDetailID(mdA_P_UsageDetail, vehicleID, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByA_P_UsageDetailID(int A_P_UsageDetailID, int vehicleID, SqlConnection conn)
        {
            return A_P_UsageDetailDA.DeleteByA_P_UsageDetailID(A_P_UsageDetailID, vehicleID, conn);
        }
        #endregion

    }
}
