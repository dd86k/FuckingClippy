using System;
using System.Reflection;

namespace FuckingClippy
{
    static class Utils
    {
        internal static Assembly ExecutingAssembly =
            Assembly.GetExecutingAssembly();

        public static readonly bool IsRunningOnMono =
            Type.GetType("Mono.Runtime") != null;
    }
}
