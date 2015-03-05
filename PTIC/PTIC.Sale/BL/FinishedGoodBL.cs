using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Sale.BL
{
    public class FinishedGoodBL
    {
        #region INSERT
        /// <summary>
        /// Add a new FinishedGood into system
        /// </summary>
        /// <param name="newFGRequest">New Finished entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Add(List<FinishedGood> newfinishedGoods, SqlConnection conn)
        {
            return FinishedGoodDA.Insert(newfinishedGoods, conn);
        }
        #endregion

        #region SELECTBYProductionDate
        ///<summary>
        ///Select finished Good by ProductionDate
        ///</summary>
        ///<param name="productionDate">ProductionDate</param>
        public DataTable SelectByProductionDate(DateTime productionDate, SqlConnection conn)
        {
            return FinishedGoodDA.SelectByProductionDate(productionDate, conn);
        }

        public DataTable GetAllStockInFactory()
        {
            return FinishedGoodDA.SelectAllStockInFactroy();
        }
        #endregion
    }
}
