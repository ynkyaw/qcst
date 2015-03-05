/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/23 (yyyy/MM/dd)
 * Description: Text format class
 */
using System;
namespace PTIC.Formatting
{
    /// <summary>
    /// Text format
    /// </summary>
    class TextFormat
    {
        /// <summary>
        /// 
        /// </summary>
        public static string WholeNumber = "N0";

        public static string AppDate = "dd-MMM-yyyy";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string PointZeroPlace(decimal number)
        {
            decimal result = Math.Round(number, 0);
            return result.ToString(WholeNumber);
        }

        public static string ToAppDate(DateTime input)
        {
            if (input == null || input == DateTime.MinValue)
                return string.Empty;
            return input.ToString(AppDate);
        }

    }
}
