using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;

namespace PTIC.Marketing.BL
{
    public class AP_PurchasedDetailBL
    {
        public DataTable GetAllAP_PurchasedDetailByAP_EnquiryDetailID(int AP_EnquiryDetailID)
        {
            return AP_PurchasedDetailDA.SelectAP_PurchasedInDetailByAP_EnquiryID(AP_EnquiryDetailID);
        }

        #region INSERT
        public int Insert(AP_PurchasedDetail _apPurchasedDetail, int APMaterialID,SqlConnection conn)
        {
            return AP_PurchasedDetailDA.Insert(_apPurchasedDetail,APMaterialID, conn);
        }
        #endregion

        #region SELECT
        public DataTable GetAll()
        {
            return AP_PurchasedDetailDA.SelectAllPurchasedInDetail();
        }

        public DataTable SelectAllPurchasedInDetailByDate(DateTime PurchasedDate)
        {
            return AP_PurchasedDetailDA.SelectAllPurchasedInDetailByDate(PurchasedDate);
        }
        #endregion

    }
}
