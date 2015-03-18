/* Author   :   Aung Ko Ko
    Date      :   13 Feb 2014
    Description :   BrandBL ( Insert , Update , Delete , Select}
*/
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
    public class BrandBL : BaseBusinessLogic
    {

        #region SELECT
        public DataTable GetAll()
        {
            return BrandDA.SelectAll();
        }

        public DataTable GetOwnBrands()
        {
            return BrandDA.SelectAllByIsOwnBrand(true);
        }

      

        public DataTable GetCompetitorBrands()
        {
            //return BrandDA.SelectAllByIsOwnBrand(false, conn);
            return BrandDA.SelectAllCompetitor();
            
            
        }

      

        public DataTable GetAllCompetitorBrand()
        {
            return BrandDA.SelectAllCompetitorBrands();
        }

        public DataTable SelectUsedOwnBrandByCompanyPlanDtlId(int id)
        {
            return BrandDA.SelectUsedOwnBrandByCompanyPlanDtlId(id);
        }

        public DataTable SelectUsedOtherBrandByCompanyPlanDtlId(int id)
        {
            return BrandDA.SelectUsedOtherBrandByCompanyPlanDtlId(id);
        }

        #endregion

        #region SELECT BY BRNADID
        public DataTable GetCompetitorBrandProductBy(string CompetitorBrand , string CompetitorProduct,int BrandID)
        {
            return BrandDA.SelectAllCompetitorBy(CompetitorBrand, CompetitorProduct,BrandID);
        }

        public DataTable GetAllByBrandID(int id,SqlConnection conn)
        {
            return BrandDA.SelectAllByBrandID(id,conn);
        }
        #endregion

        #region INSERT
        public int Insert(Brand newBrand, SqlConnection conn)
        {
            return BrandDA.Insert(newBrand, conn);
        }
        #endregion

        #region InsertCompetitor
        public int InsertCompetitor(Brand newBrand, SqlConnection conn)
        {
            if (newBrand == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("CompetitorBrand Name must not be null!",
                        null, "BrandBL", null, null));
                return 0;
            }

            // Field validation
            Validator<Brand> detailValidator = base.ValidationManager.CreateValidator<Brand>();
            ValidationResults vResults = detailValidator.Validate(newBrand);
            base.ValidationResults = vResults;
            if (!vResults.IsValid)
                return 0;
            // duplicate field validation via db
            DataTable duplicateData = this.GetCompetitorBrandProductBy(newBrand.BrandName,newBrand.CompetitorProduct,0);
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Brand_BrandName_Duplicate,
                        null, "BrandBL", null, null));
                return 0;
            }            

            return BrandDA.InsertCompetitor(newBrand, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByID(Brand brand, SqlConnection conn)
        {
            return BrandDA.UpdateByID(brand, conn);
        }
        #endregion

        #region Update CompetitorProduct
        public int UpdateCompetitorProductByBrandID(Brand brand, SqlConnection conn)
        {
            if (brand == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("CompetitorBrand Name must not be null!",
                        null, "BrandBL", null, null));
                return 0;
            }

            // Field validation
            Validator<Brand> detailValidator = base.ValidationManager.CreateValidator<Brand>();
            ValidationResults vResults = detailValidator.Validate(brand);
            base.ValidationResults = vResults;
            if (!vResults.IsValid)
                return 0;
            // duplicate field validation via db
            DataTable duplicateData = this.GetCompetitorBrandProductBy(brand.BrandName, brand.CompetitorProduct,brand.ID);
            if (duplicateData != null && duplicateData.Rows.Count > 0)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Brand_BrandName_Duplicate,
                        null, "BrandBL", null, null));
                return 0;
            }      
            return BrandDA.UpdateCompetitorProductByBrandID(brand, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByID(Brand brand, SqlConnection conn)
        {
            return BrandDA.DeleteByID(brand, conn);
        }
        #endregion

        #region DELETE
        public int DeleteCompetitorByID(Brand brand, SqlConnection conn)
        {
            return BrandDA.DeleteCompetitorByID(brand, conn);
        }
        #endregion

    }
}
