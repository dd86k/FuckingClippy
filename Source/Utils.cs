using System;
using System.Reflection;
using static System.Diagnostics.Process;

namespace FuckingClippy
{
    static class Utils
    {
        internal static readonly Assembly ExecutingAssembly =
            Assembly.GetExecutingAssembly();

        public static string Version
        {
            get
            {
                return ExecutingAssembly.GetName().Version.ToString();
            }
        }

        public static readonly bool IsRunningOnMono =
            Type.GetType("Mono.Runtime") != null;

        /// <summary>
        /// Process user input.
        /// </summary>
        /// <param name="pUserInput">User input.</param>
        static internal void ProcessInput(string pUserInput)
        {
            Console.WriteLine($"CLR: User input: {pUserInput}");

            if (pUserInput.ToLower().StartsWith("run "))
            {
                try
                {
                    Start(pUserInput.Substring(4));
                }
                catch (Exception e)
                {
                    Character.Say($"Hey, \"{pUserInput}\" returned a {e.GetType()} error.");
                }
            }
            else if (pUserInput.ToLower().StartsWith("say "))
            {
                Character.Say(pUserInput.Substring(4));
            }
            else if (pUserInput.ToLower().StartsWith("search "))
            {
                Start($"https://www.google.com/search?q={Uri.EscapeDataString(pUserInput)}");
            }
            else
            {
                Character.Say("I can't figure out what you're saying.");
            }
        }
    }
}
