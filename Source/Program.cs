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
            Console.WriteLine(Utils.IsRunningOnMono ?
                "CLR: Started on: Mono" : "CLR: Started on: .NET");
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
