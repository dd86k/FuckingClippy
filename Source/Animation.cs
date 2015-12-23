using System;
using System.Drawing;
using System.Timers;

namespace FuckingClippy
{
    public partial class MainForm
    {
        void InitializeAnimation()
        {
            Animation.Timer = new Timer(Animation.DefaultInterval);

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

                // This is important!
                GC.Collect();
            }
            else
            {
                picCharacter.Image = Animation.GetIdle();
                Animation.Timer.Stop();
            }
        }
    }

    //TODO: Make Animation a proper object instead.
    //TODO: Make an enumeration for animation names instead of using a string

    public class Animation
    {
        /// <summary>
        /// Default <see cref="Timer"/>'s Interval value.
        /// </summary>
        internal const int DefaultInterval = 150;
        /// <summary>
        /// Default animation folder path.
        /// </summary>
        const string AnimationFolder = "FuckingClippy.Images.Clippy.Animations";
        /// <summary>
        /// Animation Timer.
        /// </summary>
        internal static Timer Timer;
        /// <summary>
        /// Animation name.
        /// </summary>
        internal static string Name
        {
            get;
            private set;
        }
        /// <summary>
        /// Current animation name.
        /// </summary>
        internal static int CurrentFrame;
        /// <summary>
        /// Number of frames of the current animation.
        /// </summary>
        internal static int MaxFrame
        {
            get;
            private set;
        }
        /// <summary>
        /// Default idle image.
        /// </summary>
        static readonly Image Idle = 
                Image.FromStream(
                    Utils.ExecutingAssembly.GetManifestResourceStream("FuckingClippy.Images.Clippy.Idle.png")
                );
        /// <summary>
        /// Get if there is an animation playing.
        /// </summary>
        static internal bool IsPlaying
        {
            get
            {
                return Timer.Enabled;
            }
        }

        /// <summary>
        /// Play an animation. If there is already an animation rolling, simply
        /// ignore the request.
        /// </summary>
        /// <param name="pName">Name of the animation.</param>
        public static void Play(string pName)
        {
            if (IsPlaying)
                return;

            Console.WriteLine($"CLR: Playing animation: {pName}");

            Name = pName;

            CurrentFrame = 0;

            Timer.Interval = DefaultInterval;

            //TODO:[S] Change Interval depending on animation (in switch(string))

            switch (Name)
            {
                case "Atomic": MaxFrame = 34; break;
                case "Bicycle": MaxFrame = 64; break;
                case "Box": MaxFrame = 38; break;
                case "Check": MaxFrame = 18; break;
                case "Chill": MaxFrame = 84; break;
                case "ExclamationPoint": MaxFrame = 9; break;
                case "FadeIn": MaxFrame = 2; break;
                case "FadeOut": MaxFrame = 2; break;
                case "FeelingDown": MaxFrame = 45; break;
                case "Headset": MaxFrame = 31; break;
                case "LookingBottomLeft": MaxFrame = 4; break;
                case "LookingBottomRight": MaxFrame = 11; break;
                case "LookingDown": MaxFrame = 4; break;
                case "LookingUpperLeft": MaxFrame = 4; break;
                case "LookingUpperRight": MaxFrame = 9; break;
                case "LookingLeftAndRight": MaxFrame = 17; break;
                case "Plane": MaxFrame = 56; break;
                case "PointingDown": MaxFrame = 12; break;
                case "PointingLeft": MaxFrame = 8; break;
                case "PointingRight": MaxFrame = 10; break;
                case "PointingUp": MaxFrame = 9; break;
                case "Poke": MaxFrame = 14; break;
                case "Reading": MaxFrame = 52; break;
                case "RollPaper": MaxFrame = 48; break;
                case "ScrachingHead": MaxFrame = 16; break;
                case "Shovel": MaxFrame = 65; break;
                case "Telescope": MaxFrame = 54; break;
                case "Tornado": MaxFrame = 30; break;
                case "Toy": MaxFrame = 12; break;
                case "Writing": MaxFrame = 58; break;
                default:
                    throw new Exception($"Animation name \"{pName}\" does not exist!");
            }

            Timer.Start();
        }

        /// <summary>
        /// Play a random animation.
        /// </summary>
        public static void PlayRandom()
        {
            Random r = new Random(DateTime.Now.Millisecond * DateTime.Now.Second);

            string[] a =
            {
                "Atomic",
                "Bicycle",
                "Box",
                "Check",
                "Chill",
                "ExclamationPoint",
                "FadeIn",
                "FadeOut",
                "FeelingDown",
                "Headset",
                "LookingBottomLeft",
                "LookingBottomRight",
                "LookingDown",
                "LookingUpperLeft",
                "LookingUpperRight",
                "LookingLeftAndRight",
                "Plane",
                "PointingDown",
                "PointingLeft",
                "PointingRight",
                "PointingUp",
                "Poke",
                "Reading",
                "RollPaper",
                "ScrachingHead",
                "Shovel",
                "Telescope",
                "Tornado",
                "Toy",
                "Writing"
            };

            Play(a[r.Next(0, a.Length)]);
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
            return Idle;
        }
    }
}
