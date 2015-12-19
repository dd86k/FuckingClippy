using System;
using System.Reflection;

namespace FuckingClippy
{
    static class Utils
    {
        internal static Assembly ExecutingAssembly =
            Assembly.GetExecutingAssembly();

        public static bool IsRunningOnMono
        {
            get
            {
                return Type.GetType("Mono.Runtime") != null;
            }
        }
    }
}
