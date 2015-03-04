using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using PTIC.Sale.Entities;

namespace PTIC.Sale.DA
{
    public class SvcFunctionDA
    {
        private static string _tableName = "SvcFunction";
        public static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectByID(int svcTestID)
        {
            DataTable dt = new DataTable(_tableName);
            string queryString = "SELECT * FROM {0} WHERE SvcTestID = {1}";
            try
            {
                dt = _dataAccess.SelectByQuery(string.Format(queryString, _tableName, svcTestID));
            }
            catch (Exception ex)
            {
                return null;
            }
            return dt;
        }
        #endregion

        /*------------------------------ Update Code Insert , Update , Delete --------------------------------------------*/
        public static int InsertSvcFunction(SvcFunction svcFunction)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = _dataAccess.InsertInto("SvcFunction", _dataAccess.ConvertColName(svcFunction), _dataAccess.ConvertValueList(svcFunction));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public static DataTable SelectAllBySalesSvcID(int SalesServiceID)
        {
            DataTable dt;
            dt = _dataAccess.SelectByQuery("SELECT * FROM SvcFunction WHERE SalesServiceID=" + SalesServiceID);
            return dt;
        }
    }
}
