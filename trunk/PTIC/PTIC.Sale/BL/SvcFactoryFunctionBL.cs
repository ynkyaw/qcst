using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;

namespace PTIC.Sale.BL
{
    public class SvcFactoryFunctionBL
    {
        public int Add(SvcFactoryFunction svcFactoryFunction)
        {
            return SvcFactoryFunctionDA.InsertSvcFactoryFunction(svcFactoryFunction);
        }

        public DataTable GetAllBySvcID(int salesServiceID)
        {
            return SvcFactoryFunctionDA.SelectAllSvcFactoryFunctionBySvcID(salesServiceID);
        }
    }
}
