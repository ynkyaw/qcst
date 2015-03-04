/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service test business logic class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using System.Data;

namespace PTIC.Sale.BL
{
    public class SvcTestBL
    {
        #region SELECT
        public DataTable GetByID(int svcTestID)
        {
            return SvcTestDA.SelectByID(svcTestID);
        }
        #endregion

        #region INSERT

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSvcTest"></param>
        /// <param name="svcFactID"></param>
        /// <param name="svc3Functions"></param>
        /// <param name="conn"></param>
        /// <returns>Return inserted service functions</returns>
        public List<SvcFunction> Add(SvcTest newSvcTest, int svcFactID, List<SvcFunction> svc3Functions, SqlConnection conn)
        {
            return SvcTestDA.Insert(newSvcTest, svcFactID, svc3Functions, conn);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateSvcTest"></param>
        /// <param name="svcFactID"></param>
        /// <param name="svc3Functions"></param>
        /// <param name="conn"></param>
        /// <returns>Return affected rows</returns>
        public int? Update(SvcTest updateSvcTest, int svcFactID, List<SvcFunction> svc3Functions, SqlConnection conn)
        {
            return SvcTestDA.Update(updateSvcTest, svcFactID, svc3Functions, conn);
        }
        #endregion

        /* -------------------- Update Code Insert , Update , Delete ------------------------------*/
        #region INSERT
        public int AddSvcTest(SvcTest svcTest)
        {
            return SvcTestDA.InsertSvcTest(svcTest);
        }
        #endregion

        #region SELECTBYID
        public DataTable GetAllByID(int SalesServiceID)
        {
            return SvcTestDA.SelectAllBySalesSvcID(SalesServiceID);
        }
        #endregion
    }
}
