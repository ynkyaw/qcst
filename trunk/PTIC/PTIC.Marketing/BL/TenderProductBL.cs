using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class TenderProductBL
    {
        public DataTable GetTenderProductByID(int? tenderInfoID, SqlConnection conn)
        {
            return TenderProductDA.GetTenderProductByID(tenderInfoID, conn);
        }

        public int Add(List<TenderProducts> newTenderProduct, SqlConnection conn)
        {
            return TenderProductDA.Insert(newTenderProduct, conn);
        }

        public int DeleteByTenderProductID(List<TenderProducts> tenderProduct,SqlConnection conn)
        {
            return TenderProductDA.DeleteByTenderProductID(tenderProduct, conn);
        }

        public int UpdateByTenderproductID(List<TenderProducts> tenderProduct, SqlConnection conn)
        {
            return TenderProductDA.UpdateByTenderProductID(tenderProduct, conn);
        }
    }
}
