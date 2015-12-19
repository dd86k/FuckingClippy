using System;
using System.Drawing;
using System.Timers;

//TODO: Duplicate frames (images) or variate framerate for variated support

namespace FuckingClippy
{
    public partial class MainForm
    {
        void InitializeAnimation()
        {
            Animation.Timer = new Timer(65);

            Animation.Timer.Elapsed += Animation_OnFrame;
        }

        // Remark: Animation_OnFrame is within MainForm to access the
        // picCharacter PictureBox.
        void Animation_OnFrame(object s, EventArgs e)
        {
            if (Animation.CurrentFrame < Animation.MaxFrame)
            {
                picCharacter.Image =
                    Animation.GetFrame(Animation.Name, Animation.CurrentFrame++);

                GC.Collect();
            }
            else
            {
                picCharacter.Image = Animation.GetIdle();
                Animation.Timer.Stop();
            }
        }
    }

    public class Animation
    {
        const string AnimationFolder = "FuckingClippy.Images.Clippy.Animations";
        internal static Timer Timer;
        internal static string Name
        {
            get;
            private set;
        }
        internal static int CurrentFrame;
        internal static int MaxFrame
        {
            get;
            private set;
        }

        /// <summary>
        /// Play an animation.
        /// </summary>
        /// <param name="pName">Name of the animation.</param>
        public static void PlayAnimation(string pName)
        {
            Name = pName;

            CurrentFrame = 0;

            switch (Name)
            {
                case "Check": MaxFrame = 18; break;
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
                    throw new Exception($"Animation name \"{pName}\" does not exist!");
            }

            Timer.Start();
        }

        internal static Image GetFrame(string pAnimation, int pFrame)
        {
            return
                Image.FromStream(
                    Utils.ExecutingAssembly.GetManifestResourceStream($"{AnimationFolder}.{pAnimation}.{pFrame}.png")
                    );
        }

        internal static Image GetIdle()
        {
            return
                Image.FromStream(
                    Utils.ExecutingAssembly.GetManifestResourceStream("FuckingClippy.Images.Clippy.Idle.png")
                    );
        }
    }
}
