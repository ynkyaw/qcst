using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class TenderInfoBL
    {
        public DataTable GetTenderInfoByID(int tenderID,SqlConnection conn)
        {
            return TenderInfoDA.GetTenderInfoByID(tenderID,conn);
        }

        public int? SaveInfo(Entities.TenderInfo tenderinfo, SqlConnection conn)
        {
            return TenderInfoDA.InsertInfo(tenderinfo,conn);
        }

        public int? UpdateInfo(Entities.TenderInfo tenderinfo, SqlConnection conn)
        {
            return TenderInfoDA.UpdateInfo(tenderinfo, conn);
        }
    }
}
