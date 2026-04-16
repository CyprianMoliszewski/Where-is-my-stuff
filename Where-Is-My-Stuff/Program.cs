using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Where_Is_My_Stuff.Database;
using System.Data.Common;
using Where_Is_My_Stuff.Services;

namespace Where_Is_My_Stuff
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DATABASE INIT
            DatabaseHandler dbHandler = DatabaseHandler.Instance;
            dbHandler.SetConnection(new DatabaseInit().GetConn());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            
        }
    }
}
