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

        public static Random Random = new Random();

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
                    else
                        Character.Say("I can't run, buddy.");
                    break;

                case "say":
                    if (s.Length > 1)
                        Character.Say(userInput.Substring(4));
                    else
                        Character.Say("Say what?");
                    break;

                case "search":
                    if (s.Length > 1)
                        Start(
                            $"https://www.google.com/search?q={Uri.EscapeDataString(userInput.Substring(7))}"
                        );
                    else
                        Character.Say("You forgot to include what to search.");
                    break;

                    case "fuck":
                        if (s.Length > 1)
                            switch (s[1].ToLower())
                            {
                                case "me":
                                    Character.Say("No thanks, I'll pass.");
                                    break;
                                case "you":
                                    Character.Say("Hey buddy I can always shutdown your computer.");
                                    break;
                                default:
                                    Character.Say("WHO");
                                    break;
                            }
                        else
                            Character.Say("WHO");
                        break;

                    case "help":
                        if (s.Length > 1)
                            switch (s[1].ToLower())
                            {
                                case "me":
                                    Character.Say(@"Try the ""help"" command!");
                                    break;
                                case "you":
                                    Character.Say("How kind! But no, I'm fine");
                                    break;
                                default:
                                    Character.Say("WHO");
                                    break;
                            }
                        else
                            Character.Say(
@"Here are some commands:

run - Run an app from PATH.
say - Make me say something.
search - Search on Google.com."
                            );
                        break;

                    default:
                    Character.Say("Are you okay?");
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
                    $"{ProjectName}.Images.{path}"
                )
            );
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
                RegexOptions.ECMAScript
            );

            int n = 0;

            foreach (var i in s)
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
