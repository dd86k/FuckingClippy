using System;
using System.Drawing;
using System.Reflection;
using System.Timers;

namespace FuckingClippy
{
    public partial class MainForm
    {
        void InitializeAnimation()
        {
            Animation.Timer = new Timer();

            Animation.Timer.Interval = 120; //TODO: Check Interval

            Animation.Timer.Elapsed += Animation_OnFrame;
        }

        /// <summary>
        /// Play an animation on screen.
        /// </summary>
        /// <param name="pName">Name of the animation.</param>
        void PlayAnimation(string pName)
        {
            Animation.Name = pName;

            switch (Animation.Name)
            {
                case "Check": Animation.MaxFrame = 18; break;
                /*case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;
                case "": Animation.MaxFrame = 1; break;*/
                default:
                    throw new Exception($"Animation name \"{pName}\" does not exist.");
            }

            Animation.Timer.Start();
        }

        void Animation_OnFrame(object s, EventArgs e)
        {
            if (Animation.CurrentFrame < Animation.MaxFrame)
            {
                picCharacter.Image =
                    Animation.GetFrame(Animation.Name, Animation.CurrentFrame++);
            }
            else
            {
                Animation.Timer.Stop();
            }
        }
    }

    public class Animation
    {
        const string AnimationFolder = "FuckingClippy.Images.Clippy.Animations";
        static Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();
        internal static Timer Timer;
        internal static string Name;
        internal static int CurrentFrame;
        internal static int MaxFrame;

        internal static Image GetFrame(string pAnimation, int pFrame)
        {
            return
                Image.FromStream(
                    ExecutingAssembly.GetManifestResourceStream($"{AnimationFolder}.{pAnimation}.{pFrame}.png")
                    );
        }

        internal static Image GetIdle()
        {
            return
                Image.FromStream(
                    ExecutingAssembly.GetManifestResourceStream("FuckingClippy.Images.Clippy.Idle.png")
                    );
        }
    }
}
