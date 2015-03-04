using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class TelemarketingDetailBL
    {
        #region SELECT
        public DataTable GetByTeleMarketingDetailID(int teleMarketingDetailID, SqlConnection conn)
        {
            return TelemarketingDetailDA.SelectByMarketingDetailID(teleMarketingDetailID, conn);
        }
        #endregion

        #region SELECT
        public DataTable GetContactPersonAll(int CusID,SqlConnection conn)
        {
            return TelemarketingDetailDA.SelectContactPersonInfo(CusID,conn);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTeleMarketingDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int Add(TeleMarketingDetail newTeleMarketingDetail, SqlConnection conn,bool IsService,bool IsTele)
        {
            return TelemarketingDetailDA.Insert(newTeleMarketingDetail, conn,IsService,IsTele);
        }
        #endregion

        #region UPDATE
        public int UpdateByTeleMarketingDetailID(TeleMarketingDetail mdTeleMarketingDetail, SqlConnection conn,bool IsService)
        {
            return TelemarketingDetailDA.UpdateByTeleMarketingDetailID(mdTeleMarketingDetail, conn,IsService);
        }
        #endregion

        #region DELETE
        public int DeleteByTeleMarketingDetailID(int teleMarketingDetailID, SqlConnection conn)
        {
            return TelemarketingDetailDA.DeleteByTeleMarketingDetailID(teleMarketingDetailID, conn);
        }
        #endregion
    }
}
