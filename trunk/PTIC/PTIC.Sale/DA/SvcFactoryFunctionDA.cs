using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Sale.DA
{
    public class SvcFactoryFunctionDA
    {
        static BaseDAO _dataAccess = new BaseDAO();
        /*------------------------------ Update Code Insert , Update , Delete --------------------------------------------*/
        public static int InsertSvcFactoryFunction(SvcFactoryFunction svcFactoryFunction)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = _dataAccess.InsertInto("SvcFactoryFunction", _dataAccess.ConvertColName(svcFactoryFunction), _dataAccess.ConvertValueList(svcFactoryFunction));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public static DataTable SelectAllSvcFactoryFunctionBySvcID(int SalesServiceID)
        {
            DataTable dt;
            dt = _dataAccess.SelectByQuery("SELECT * FROM SvcFactoryFunction WHERE SalesServiceID=" + SalesServiceID);
            return dt;
        }
    }
}
