using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Secure_file_storage_system__RSA_
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
            Application.Run(new Sign_In());
            //Application.Run(new PrivateKey());
            //Application.Run(new Sign_Up());
            //Application.Run(new Main());
        }
    }
}


