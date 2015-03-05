/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/09/20 (yyyy/MM/dd)
 * Description: Order entity bean class
 */
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PTIC.Common.BL
{
    /// <summary>
    /// Base class for business logic / rule
    /// </summary>
    public class BaseBusinessLogic
    {
        /// <summary>
        /// Field / Attribute validation manager
        /// </summary>        
        protected ValidatorFactory ValidationManager = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        /// <summary>
        /// Field / Attribute validation results
        /// </summary>
        public ValidationResults ValidationResults = new ValidationResults();

    }
}
