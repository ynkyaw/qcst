using System;
using System.Windows.Forms;
using PTIC.VC.Sale;
using PTIC.VC.Auth;
using PTIC.Marketing;
using PTIC.VC.Marketing;
using System.Diagnostics;
using System.Threading;

namespace PTIC.VC
{
    public static class Program
    {
        public enum Module
        { 
            AdminHR,
            Marketing,
            Sale,
            Finance,
            FMOffice,
            Production,
            Planning,
            QC,
            Maintenance,
            ISO
        }

        public static string _selectedDepartment = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public static Module module;

        public static frmSaleMain toyo = null;
        public static frmMarketingMain marketintoyo = null;
        public static frmLogin login = null;
        public static frmMainGUI frmMainGUI = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
  
            using (Mutex mutex = new Mutex(false, "PTIC"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Application already running!", "PTIC System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Application.Run(new frmMainGUI());                
            }
           
        }
    }
}
