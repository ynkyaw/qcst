/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TownBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.BL
{    
    public class TownBL : BaseBusinessLogic
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return TownDA.SelectAll();
        }
        #endregion

        #region SELECTALLWithCusType
        public DataTable GetAllWithCusType()
        {
            return TownDA.SelectAllWithCustomerType();
        }
        #endregion

        #region INSERT
        public int Insert(Town town)
        {
            if (town == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Town Name must not be null!",
                        null, "TownBL", null, null));
                return 0;
            }

            // duplicate field validation
            DataTable duplicateData = this.GetAll();
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {

                //Code Add By YNK
                //To fix duplicate
                bool isExit = false;
                foreach (DataRow dr in duplicateData.Rows) 
                {
                    if (dr["Town"].ToString() == town.TownName&& ( (int)dr["StateDivisionID"])==town.StateDivisionID) 
                    {
                        isExit = true;
                        break;
                    }
                }

                //End Added

                if (isExit)
                {

                    base.ValidationResults = new ValidationResults();
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.TownInTrip_TownID_Duplicate,
                            null, "TownBL", null, null));
                    return 0;
                }
            }
            return TownDA.Insert(town);
        }
        #endregion

        #region UPDATE
        public int Update(Town town)
        {
            return TownDA.UpdateByID(town);
        }
        #endregion

        #region DELETE
        public int Delete(Town town)
        {
            return TownDA.DeleteByID(town);
        }
        #endregion
    }
}
