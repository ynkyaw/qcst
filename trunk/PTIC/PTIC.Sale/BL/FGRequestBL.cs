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
    public class FGRequestBL
    {
        #region SELECT
        /// <summary>
        /// Get all orders from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        /// 
        public DataTable GetAllFGRequestIssue()
        {
            return FGRequestDetailDA.SelectAllFGRequestIssue();
        }

        public DataTable GetAll(SqlConnection conn)
        {
            return FGRequestDetailDA.GetAll(conn);
        }

        public DataTable SelectByRequireDate(DateTime requireDate, SqlConnection conn)
        {
            return FGRequestDetailDA.SelectByRequireDate(requireDate, conn);
        }

        public DataTable SelectByFGRequestID(int FGRequestID,SqlConnection conn)
        {
            return FGRequestDetailDA.SelectByFGRequestID(FGRequestID,conn);
        }


        public DataTable SelectFormByFGRequestID(int FGRequestID)
        {
            return FGRequestDetailDA.SelectByFormFGRequestID(FGRequestID);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new FGRequest into system
        /// </summary>
        /// <param name="newFGRequest">New FGRequest entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Add(FGRequest newfgRequest, List<FGRequestDetail> newfgRequestDetail, SqlConnection conn)
        {
            return FGRequestDA.Insert(newfgRequest, newfgRequestDetail, conn);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Add a new FGRequest into system
        /// </summary>
        /// <param name="newFGRequest">Update FGRequest entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Update(FGRequest newfgRequest, List<FGRequestDetail> newfgRequestDetail, SqlConnection conn)
        {
            return FGRequestDA.Update(newfgRequest, newfgRequestDetail, conn);
        }
        #endregion
    }
}
