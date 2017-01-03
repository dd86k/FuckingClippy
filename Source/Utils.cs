using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Reflection.Assembly;

namespace FuckingClippy
{
    static class Utils
    {
        public static readonly Assembly Project = GetEntryAssembly();
        public static readonly string Version =
            Project.GetName().Version.ToString();
        public static readonly string ProjectName =
            Project.GetName().Name;

        public static PlatformID OSType = Environment.OSVersion.Platform;

        public static Random R = new Random();

        public static readonly bool RunningMono =
            Type.GetType("Mono.Runtime") != null;
        static string RuntimeName = RunningMono ? "Mono" : ".NET";

        #region Assembly related
        public static Stream LoadEmbedded(string path)
        {
            return
                Project.GetManifestResourceStream($"{ProjectName}.{path}");
        }

        public static Image LoadEmbeddedImage(string path)
        {
            return Image.FromStream(
                Project.GetManifestResourceStream(
                    $"{ProjectName}.Images.{path}"
                )
            );
        }

        public static int GetNumberOfEmbeddedItems(string path)
        {
            Regex r = new Regex(
                $@"{ProjectName}\.{path.Replace(".", @"\.")}\.*",
                RegexOptions.ECMAScript | RegexOptions.Compiled
            );

            int n = 0;

            foreach (var i in Project.GetManifestResourceNames())
                if (r.IsMatch(i))
                    ++n;

            return n;
        }
        #endregion

        public static void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
