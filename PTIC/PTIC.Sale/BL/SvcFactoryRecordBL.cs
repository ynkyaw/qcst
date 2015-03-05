using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using System.Data;

namespace PTIC.Sale.BL
{
    public class SvcFactoryRecordBL
    {
        public int Add(SvcFactoryRecord svcFactoryRecord)
        {
            return SvcFactoryRecordDA.InsertSvcFactoryRecord(svcFactoryRecord);
        }

        public DataTable GetAllBySvcID(int salesServiceID)
        {
            return SvcFactoryRecordDA.SelectAllSvcFactoryRecBySvcID(salesServiceID);
        }
    }
}
