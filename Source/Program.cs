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
            Console.WriteLine(Utils.IsRunningOnMono ? "Running on: Mono" : "Running on: .NET/CLR");
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
