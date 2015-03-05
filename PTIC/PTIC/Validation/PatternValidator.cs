/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/23 (yyyy/MM/dd)
 * Description: Pattern rule for field validation
 */
using System.Text.RegularExpressions;
namespace PTIC.VC.Validation
{
    /// <summary>
    /// Pattern rule based validator
    /// </summary>
    public class PatternValidator
        : PatternRule
    {
        /// <summary>
        /// Validate input text is an irrational number or not
        /// </summary>
        /// <param name="input">input text</param>
        /// <returns>true if matched</returns>
        public static bool IsIrrationalNumber(string input)
        {
            return new Regex(IrrationalNumber).IsMatch(input);
        }
    }
}
