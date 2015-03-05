using WeifenLuo.WinFormsUI.Docking;
using PTIC.Sale.Entities;
using PTIC.Common.Entities;

namespace PTIC.VC
{
    public static class GlobalCache
    {  
        /// <summary>
        /// Currently loginned user
        /// </summary>
        public static User LoginUser = null;

        /// <summary>
        /// Currently loginned employee
        /// </summary>
        public static Employee LoginEmployee = null;
        
        /* ------- Components ------*/
        public static DockPanel MenuContainer = new DockPanel();
        public static bool is_sale = false;
    }
}
