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

            bool succcessful = false;

            if (pUserInput.IsLink())
            {
                Start(pUserInput);
                succcessful = true;
            }
            else if (pUserInput.StartsWith("run "))
            {
                try
                {
                    Start(pUserInput.Substring(4));
                    succcessful = true;
                }
                catch
                {
                    Dialog.Say($"Hey, \"{pUserInput}\" returned a Win32 error.");
                }
            }
            else
            {
                //TODO:[H] Fix Google Searches
                Start($"https://google.com/?q={Uri.EscapeDataString(pUserInput)}#");
                succcessful = true;
            }

            if (succcessful)
                Dialog.CurrentForm.Close();
        }
    }

    static class TypeExtensions
    {
        public static bool IsLink(this string pString)
        {
            Uri u;
            return Uri.TryCreate(pString, UriKind.RelativeOrAbsolute, out u);
        }
    }
}
