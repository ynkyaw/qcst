/* Author   :   Aung Ko Ko
    Date      :   11 Feb 2014
    Description :   BatterySettingBL ( Insert , Update , Delete , GetAll}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;

namespace PTIC.Sale.BL
{
    public class BatterySettingBL
    {
        #region GetAll
        public DataTable GetAll(SqlConnection conn)
        {
            return BatterySettingDA.GetAll(conn);
        }
        #endregion

        #region INSERT
        public int Insert(BatterySetting bsetting, SqlConnection conn)
        {
            return BatterySettingDA.Insert(bsetting, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByID(BatterySetting bsetting, SqlConnection conn)
        {
            return BatterySettingDA.UpdateByID(bsetting, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByID(BatterySetting bsetting, SqlConnection conn)
        {
            return BatterySettingDA.DeleteByID(bsetting, conn);
        }
        #endregion
    }
}
