/* Author   :   Aung Ko Ko, Wai Phyoe Thu<wpt.osp@gmail.com>
    Date      :   19 Feb 2014
    Description :   TownInTripBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.BL
{
    public class TownInTripBL : BaseBusinessLogic
    {
        #region SELECTALL
        public DataTable GetTownInTripByTownID(int TownID)
        {
            return TownInTripDA.SelectTownInTripByTownID(TownID);
        }

        public DataTable GetAll()
        {
            return TownInTripDA.SelectAll();
        }

        public DataTable GetBy(int tripID, int townID)
        {
            return TownInTripDA.SelectBy(tripID, townID);
        }
        #endregion

        #region INSERT
        public int Insert(List<TownInTrip> townInTripList)
        {
            try
            {
                // Validate fields values
                if (townInTripList == null || townInTripList.Count < 1)
                {
                    //base.ValidationResults.AddResult(
                    //    new ValidationResult("ပါဝင်သောမြို့များ ဖြည့်သွင်းပေးပါရန်။",
                    //        null, "NullTownInTrip", null, null));
                    //return 0;
                }
                // Field validation
                Validator<TownInTrip> itemValidator = base.ValidationManager.CreateValidator<TownInTrip>();
                foreach (TownInTrip item in townInTripList)
                {
                    ValidationResults vResults = itemValidator.Validate(item);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return 0;
                }
                // Do not allow duplicate town
                var duplicatedTown = townInTripList.GroupBy(x => new { x.TownID }).Where(x => x.Skip(1).Any()).ToArray();
                if (duplicatedTown.Any())
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.TownInTrip_TownID_Duplicate,
                            null, "TownInTrip_TownID_Duplicate", null, null));
                    return 0;
                }
                // Do not allow duplicate town via db (this validation is set last in sequence bcoz it interacts with database)
                foreach (TownInTrip item in townInTripList)
                {
                    DataTable dtDuplicatedTown = this.GetBy(item.TripID, item.TownID);
                    if (dtDuplicatedTown != null && dtDuplicatedTown.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.TownInTrip_TownID_Duplicate,
                            null, "TownInTrip_TownID_Duplicate", null, null));
                        return 0;
                    }
                }
                // Insert into db
                return TownInTripDA.Insert(townInTripList);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                        new ValidationResult(e.Message,
                            null, "TownInTripBL", null, null));
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public int Update(List<TownInTrip> townInTripList)
        {
            try
            {
                // Validate fields values
                if (townInTripList == null || townInTripList.Count < 1)
                {
                    //base.ValidationResults.AddResult(
                    //    new ValidationResult("ပါဝင်သောမြို့များ ဖြည့်သွင်းပေးပါရန်။",
                    //        null, "NullTownInTrip", null, null));
                    return 0;
                }
                // Field validation
                Validator<TownInTrip> itemValidator = base.ValidationManager.CreateValidator<TownInTrip>();
                foreach (TownInTrip item in townInTripList)
                {
                    ValidationResults vResults = itemValidator.Validate(item);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return 0;
                }
                // Do not allow duplicate town
                var duplicatedTown = townInTripList.GroupBy(x => new { x.TownID }).Where(x => x.Skip(1).Any()).ToArray();
                if (duplicatedTown.Any())
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.TownInTrip_TownID_Duplicate,
                            null, "TownInTrip_TownID_Duplicate", null, null));
                    return 0;
                }
                // Do not allow duplicate town via db (this validation is set last in sequence bcoz it interacts with database)
                foreach (TownInTrip item in townInTripList)
                {
                    DataTable dtDuplicatedTown = this.GetBy(item.TripID, item.TownID);
                    if (dtDuplicatedTown != null && dtDuplicatedTown.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.TownInTrip_TownID_Duplicate,
                            null, "TownInTrip_TownID_Duplicate", null, null));
                        return 0;
                    }
                }
                // Update
                return TownInTripDA.UpdateByID(townInTripList);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                        new ValidationResult(e.Message,
                            null, "TownInTripBL", null, null));
                return 0;
            }
        }
        #endregion

        #region DELETE
        public int Delete(TownInTrip townintrip)
        {
            return TownInTripDA.DeleteByID(townintrip);
        }
        #endregion
    }
}
