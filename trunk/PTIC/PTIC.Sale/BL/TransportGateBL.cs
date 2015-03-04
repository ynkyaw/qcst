/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TransportGateBL ( Insert , Update , Delete , Select}
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
    public class TransportGateBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SELECTALL
        public DataTable GetAll()
        {
            return TransportGateDA.SelectAll();
        }

        public DataTable GetBy(int transportTypeID, string gateName)
        {
            return TransportGateDA.SelectBy(transportTypeID, gateName);
        }
        #endregion

        #region INSERT
        public int Insert(TransportGate transportgate)
        {
            if (transportgate == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Transport Gate must not be null!",
                        null, "TransportGateBL", null, null));
                return 0;
            }

            // duplicate field validation
            DataTable duplicateData = this.GetBy(transportgate.TransportTypeID, transportgate.GateName);
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TransportGate_GateName_Duplicate,
                        null, "TransportGateBL", null, null));
                return 0;
            }
            return TransportGateDA.Insert(transportgate);
        }
        #endregion

        #region UPDATE
        public int Update(TransportGate transportgate)
        {
            if (transportgate == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Transport Gate must not be null!",
                        null, "TransportGateBL", null, null));
                return 0;
            }
            // duplicate field validation
            DataTable duplicateData = this.GetBy(transportgate.TransportTypeID, transportgate.GateName);
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TransportGate_GateName_Duplicate,
                        null, "TransportGateBL", null, null));
                return 0;
            }
            return TransportGateDA.UpdateByID(transportgate);
        }
        #endregion

        #region DELETE
        public int Delete(TransportGate transportgate)
        {
            return TransportGateDA.DeleteByID(transportgate);
        }
        #endregion

    }
}
