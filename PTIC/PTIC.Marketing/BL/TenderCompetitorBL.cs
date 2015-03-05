using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class TenderCompetitorBL
    {
        public DataTable GetTenderCompetitorByID(int? tenderInfoID, SqlConnection conn)
        {
            return TenderCompetitorDA.GetTenderCompetitorByID(tenderInfoID, conn);
        }

        public int Add(List<TenderCompetitors> newTenderCompetitor, SqlConnection conn)
        {
            return TenderCompetitorDA.Insert(newTenderCompetitor, conn);
        }

        public int DeleteByTenderCompetitorID(List<TenderCompetitors> tenderCompetitor, SqlConnection conn)
        {
            return TenderCompetitorDA.DeleteByTenderCompetitorID(tenderCompetitor, conn);
        }

        public int UpdateByTenderCompetitorID(List<TenderCompetitors> tenderCompetitor, SqlConnection conn)
        {
            return TenderCompetitorDA.UpdateByTenderCompetitorID(tenderCompetitor, conn);
        }
    }
}
