using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.BL
{
    public class AP_EnquiryBL : BaseBusinessLogic
    {
        #region SELECT        

        public DataTable GetAcceptEnquiryAP_SubCategoryListByDate(int StartMonth, int EndMonth, int Year)
        {
            return AP_EnquiryDA.SelectAcceptEnquiryAP_SubCategoryListByDate(StartMonth, EndMonth,Year);
        }

        public DataTable GetAcceptEnquiryAP_MaterialListByDate(int StartMonth, int EndMonth,int Year)
        {
            return AP_EnquiryDA.SelectAcceptEnquiryAP_MaterialListByDate(StartMonth, EndMonth,Year);
        }

        public DataTable GetAllEnquiry()
        {
            return AP_EnquiryDA.SelectAllEnquiry();
        }

        public DataTable GetBalanceByAPMaterialID(int APMaterialID)
        {
            return AP_EnquiryDA.SelectBalanceByAPMaterialID(APMaterialID);
        }

        public DataTable GetBalanceByAPMaterialIDDeptID(int APMaterialID,int DeptID)
        {
            return AP_EnquiryDA.SelectBalanceByAPMaterialIDDeptID(APMaterialID,DeptID);
        }

        public DataTable GetBalanceByAPMaterialIDVenID(int APMaterialID, int VenID)
        {
            return AP_EnquiryDA.SelectBalanceByAPMaterialIDVenID(APMaterialID, VenID);
        }

        public DataTable GetAllDetail(DateTime? EnquiryDate)
        {
            return AP_EnquiryDA.SelectAllAP_EnquiryDetail(EnquiryDate);
        }

        public DataTable GetAPEnquiryByIsAccepted()
        {
            return AP_EnquiryDA.SelectAP_EnquiryDetailByIsAccepted();
        }

        public DataTable GetAllAPEnquiryByIsAccepted()
        {
            return AP_EnquiryDA.SelectAllAP_EnquiryDetailByIsAccepted();
        }

        public DataTable GetByStartDateEndDate(DateTime StartDate, DateTime EndDate)
        {
            return AP_EnquiryDA.SelectAllEnquiryByDate(StartDate, EndDate);
        }
        #endregion

        #region INSERT
        public int Add(AP_Enquiry _AP_Enquiry, List<AP_EnquiryDetail> _AP_EnquiryDetail)
        {
            base.ValidationResults = new ValidationResults();

            try
            {
                return AP_EnquiryDA.Insert(_AP_Enquiry, _AP_EnquiryDetail);
            }
            catch (Exception ex)
            {
                // Validate  တစ်လကျော်ထိ ပေးဝယ်ခွင့်ပြု
                base.ValidationResults.AddResult(
                        new ValidationResult(ex.Message,
                            null, "AP_EnquiryBL", null, null));

            }
            return 0;
        }
        #endregion

        #region Update
        public int UpdateAPEnquiry(AP_Enquiry _AP_Enquiry)
        {
            return AP_EnquiryDA.UpdateAPEnquiry(_AP_Enquiry);
        }

        public int EditByID(AP_Enquiry _AP_Enquiry, List<AP_EnquiryDetail> _UpdateAP_EnquiryDetail,List<AP_EnquiryDetail> _InsertAPEnquiryList)
        {
            base.ValidationResults = new ValidationResults();

            try
            {
                return AP_EnquiryDA.Update(_AP_Enquiry, _UpdateAP_EnquiryDetail, _InsertAPEnquiryList);
            }
            catch (Exception ex)
            {
                // Validate  တစ်လကျော်ထိ ပေးဝယ်ခွင့်ပြု
                base.ValidationResults.AddResult(
                        new ValidationResult(ex.Message,
                            null, "AP_EnquiryBL", null, null));

            }
            return 0;
        }

        public int UpdateByID(AP_EnquiryDetail _newAPEnquiryDetail, SqlConnection conn)
        {
            return AP_EnquiryDA.UpdateByID(_newAPEnquiryDetail, conn);
        }
        #endregion


        public DataTable Get_AviliablePlanAmountByAP_MaterialID(int ap_materialId, DateTime planDate) 
        {
            return AP_EnquiryDA.Get_AviliablePlanAmountByAP_MaterialID(ap_materialId, planDate);
        }
    }
}
