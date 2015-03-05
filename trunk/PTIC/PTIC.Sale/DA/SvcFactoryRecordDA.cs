using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Sale.DA
{
    public class SvcFactoryRecordDA
    {
        static BaseDAO _dataAccess = new BaseDAO();

        /*------------------------------ Update Code Insert , Update , Delete --------------------------------------------*/
        public static int InsertSvcFactoryRecord(SvcFactoryRecord svcFactoryRecord)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = _dataAccess.InsertInto("SvcFactoryRecord", _dataAccess.ConvertColName(svcFactoryRecord), _dataAccess.ConvertValueList(svcFactoryRecord));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public static DataTable SelectAllSvcFactoryRecBySvcID(int SalesServiceID)
        {
            DataTable dt;
            dt = _dataAccess.SelectByQuery("SELECT * FROM SvcFactoryRecord WHERE SalesServiceID=" + SalesServiceID);
            return dt;
        }
    }
}
