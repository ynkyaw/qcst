/* Author   :   Aung Ko Ko
    Date      :   15 Feb 2014
    Description :   
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class BatterySetting
    {
        #region BatterySetting Entities
        public int BatterySettingID { get; set; }
        public int ProductID { get; set; }
        public DateTime TranDate { get; set; }
        public float Weight { get; set; }
        public int Qty { get; set; }
        #endregion
    }
}
