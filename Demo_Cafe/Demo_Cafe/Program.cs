using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace Demo_Cafe
{
    static class Program
    {
        public static string tennv { set; get; }
        public static bool IstruePass = false;
        public static int mabanHD { set; get; }
        public static bool select;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
