using System;
using System.Windows.Forms;

namespace FuckingClippy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Utils.Log("Started");
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
