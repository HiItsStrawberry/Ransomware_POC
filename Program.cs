using System;
using System.Windows.Forms;

namespace Launcher_Ransomware
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Launcher());
            Application.Run(new Encryption());
            //Application.Run(new Decryption());
        }
    }
}
