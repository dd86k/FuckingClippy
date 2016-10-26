using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using static System.Diagnostics.Process;
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

        public static Random R = new Random();

        public static readonly bool RunningMono =
            Type.GetType("Mono.Runtime") != null;
        static string RuntimeName = RunningMono ? "Mono" : ".NET";

        /// <summary>
        /// Process user input.
        /// </summary>
        /// <param name="userInput">User input.</param>
        public static void ProcessInput(string userInput)
        {
            string[] s = userInput.Split(' ');

            if (s.Length > 0)
            switch (s[0].ToLower())
            {
                case "run":
                    if (s.Length > 1)
                    try
                    {
                        Start(userInput.Substring(4));
                    }
                    catch (Exception e)
                    {
                        Character.Say($"{e.GetType()}!");
                    }
                    break;

                case "say":
                    if (s.Length > 1)
                        Character.Say(userInput.Substring(4));
                    break;

                case "search":
                    Start($"https://www.google.com/search?q={Uri.EscapeDataString(userInput.Substring(7))}");
                    break;

                default:
                    Character.Say("What was that?");
                    break;
            }
            else
                Character.Say("Hello?");
        }

        #region Assembly related
        public static Image LoadEmbeddedImage(string path)
        {
            return Image.FromStream(
            GetExecutingAssembly().GetManifestResourceStream(
                $"{ProjectName}.Images.Bubble.BubbleTail.png"));
        }

        public static bool EmbeddedItemExist(string path)
        {
            try
            {
                Project.GetManifestResourceInfo(
                    ProjectName + "." + path
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int GetNumberOfEmbeddedItems(string path)
        {
            string[] s = Project.GetManifestResourceNames();

            Regex r = new Regex(
                $"{ProjectName}\\.{path.Replace(".", "\\.")}\\.*",
                 RegexOptions.ECMAScript | RegexOptions.IgnoreCase);

            int n = 0;

            foreach (var i in s)
                if (r.IsMatch(i))
                    ++n;

            return n;
        }
        #endregion

        public static void Log(string text)
        {
            Console.WriteLine($"{RuntimeName}: {text}");
        }
    }
}
