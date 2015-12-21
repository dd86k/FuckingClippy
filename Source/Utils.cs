using System;
using System.Reflection;
using static System.Diagnostics.Process;

namespace FuckingClippy
{
    static class Utils
    {
        internal static readonly Assembly ExecutingAssembly =
            Assembly.GetExecutingAssembly();

        public static readonly bool IsRunningOnMono =
            Type.GetType("Mono.Runtime") != null;

        /// <summary>
        /// Process user input.
        /// </summary>
        /// <param name="pUserInput">User input.</param>
        static internal void ProcessInput(string pUserInput)
        {
            Console.WriteLine($"User input: {pUserInput}");

            if (pUserInput.StartsWith("run "))
            {
                string run = pUserInput.Substring(4);
                
                Console.WriteLine($"User action: RUN - Parameter: {run}");

                Start(run);
            }

            if (pUserInput.StartsWith("search "))
            {
                string run = pUserInput.Substring(7);

                Console.WriteLine($"User action: SEARCH - Parameter: {run}");

                Start($"https://www.google.ca/?q={run}");
            }

            Dialog.CurrentForm.Close();
        }
    }
}
