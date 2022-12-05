using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLib;

namespace Hazi_Gyumolcs_Multi
{
    internal static class Program
    {
        public static readonly SQL database = new SQL("localhost", "root", "", "gyumolcsok");
        public static FormNyito formNyito = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formNyito = new FormNyito();
            Application.Run(formNyito);
        }
    }
}
