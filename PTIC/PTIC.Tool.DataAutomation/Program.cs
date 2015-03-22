using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PTIC.Tool.DataAutomation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            DataManager dataManager = new DataManager();
            dataManager.Copy(
                "Data Source=WPT-PC;Initial Catalog=PTIC_Ver_1_0_7_MieMie;User ID=sa;Password=sa",
                "Data Source=WPT-PC;Initial Catalog=PTIC_Ver_1_0_7;User ID=sa;Password=sa",
                2626);

        }
    }
}
