using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;

namespace PTIC.Sale.BL
{
    public class SvcFunctionBL
    {
        #region SELECT
        public DataTable GetByID(int svcTestID)
        {
            return SvcFunctionDA.SelectByID(svcTestID);
        }
        #endregion

        /* -------------------- Update Code Insert , Update , Delete ------------------------------*/
        #region INSERT
        public int AddSvcFunction(SvcFunction svcFunction)
        {
            return SvcFunctionDA.InsertSvcFunction(svcFunction);
        }
        #endregion

        #region SELECTBYID
        public DataTable GetAllByID(int SalesServiceID)
        {
            return SvcFunctionDA.SelectAllBySalesSvcID(SalesServiceID);
        }
        #endregion
    }
}
