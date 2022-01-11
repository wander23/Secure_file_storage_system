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
            //Application.Run(new Sign_Up());
            //Application.Run(new Main());
            //GFG g = new GFG();
            //g.decryptImage(33667, 3, @"C:\Users\Admin\Desktop\MHMM\pic\TestImage\4.png", "1.bmp");

        }
    }
}


