/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/23 (yyyy/MM/dd)
 * Description: Pattern rule for field validation
 */
namespace PTIC.VC.Validation
{
    /// <summary>
    /// Pattern-based rule for validation
    /// </summary>
    public class PatternRule
    {
        /// <summary>
        /// Uniform Resource Locator pattern
        /// </summary>
        public const string Url = @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

        /// <summary>
        /// E-Mail pattern
        /// </summary>
        public const string EMail = @"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";

        /// <summary>
        /// Natural number without zero pattern
        /// </summary>
        //public static string NaturalNumberNonZero = "^[0-9]+$";
        public const string NaturalNumberNonZero = "^[1-9]+[0-9]*$";

        public const string NaturalNumberIncludingBlank = "^[1-9]*[0-9]*$";

        /// <summary>
        /// Irrational number pattern
        /// </summary>
        public const string IrrationalNumber = @"^[0-9]+[\.]?[0-9]*$";
    }
}
