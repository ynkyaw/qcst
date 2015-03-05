/* Author   :   Aung Ko Ko, Wai Phyoe Thu <wpt.osp@gmail.com>
    Date      :   19 Feb 2014
    Description :   PriceChangeBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using AGL.Util;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class PriceChangeBL
    {        
        #region SELECT
        public DataTable GetAll()
        {
            return PriceChangeDA.SelectAll();
        }
        
        /// <summary>
        /// Get prices of specific product in desired date
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public PriceChange GetPrice(int productID, DateTime date)
        {
            DataTable dtPC = PriceChangeDA.SelectBy(productID, date);
            if (dtPC == null || dtPC.Rows.Count < 1)
                return null;
            return new PriceChange() 
            {
                WholeSaleNo = (string)DataTypeParser.Parse(dtPC.Rows[0]["WholeSaleNo"], typeof(string), string.Empty),
                WSPrice = (decimal)DataTypeParser.Parse(dtPC.Rows[0]["WSPrice"], typeof(decimal), 0),
                RetailNo = (string)DataTypeParser.Parse(dtPC.Rows[0]["RetailNo"], typeof(string), string.Empty),
                RSPrice = (decimal)DataTypeParser.Parse(dtPC.Rows[0]["RSPrice"], typeof(decimal), 0),
                AcidPrice = (decimal)DataTypeParser.Parse(dtPC.Rows[0]["AcidPrice"], typeof(decimal), 0),
                WSPriceWithAcid = (decimal)DataTypeParser.Parse(dtPC.Rows[0]["WSPriceWithAcid"], typeof(decimal), 0),
                RSPriceWithAcid = (decimal)DataTypeParser.Parse(dtPC.Rows[0]["RSPriceWithAcid"], typeof(decimal), 0)
            };
        }
        #endregion

        #region INSERT
        public int Insert(PriceChange pricechange, SqlConnection conn)
        {
            return PriceChangeDA.Insert(pricechange, conn);
        }
        #endregion

        #region UPDATE
        public int Update(PriceChange pricechange, SqlConnection conn)
        {
            return PriceChangeDA.UpdateByID(pricechange, conn);
        }
        #endregion

        #region DELETE
        public int Delete(PriceChange pricechange, SqlConnection conn)
        {
            return PriceChangeDA.DeleteByID(pricechange, conn);
        }
        #endregion
    }
}
