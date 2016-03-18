using System;
using System.Drawing;
using System.Timers;
using System.Linq;
using System.Collections.Generic;

namespace FuckingClippy
{
    public enum AnimationName : byte
    {
        Atomic,
        Bicycle,
        Box,
        Check,
        Chill,
        ExclamationPoint,
        FadeIn,
        FadeOut,
        FeelingDown,
        Headset,
        LookingBottomLeft,
        LookingBottomRight,
        LookingDown,
        LookingUpperLeft,
        LookingUpperRight,
        LookingLeftAndRight,
        Plane,
        PointingDown,
        PointingLeft,
        PointingRight,
        PointingUp,
        Poke,
        Reading,
        RollPaper,
        ScrachingHead,
        Shovel,
        Telescope,
        Tornado,
        Toy,
        Writing
    }

    public partial class MainForm
    {
        void InitializeAnimation()
        {
            Animation.Timer = new Timer(Animation.DefaultInterval);
            Animation.Timer.Elapsed += Animation_OnFrame;
            Animation.Initialize();
        }

        // Remark: Animation_OnFrame is within MainForm to access the
        // picCharacter PictureBox (which is private).
        void Animation_OnFrame(object s, EventArgs e)
        {
            if (Animation.CurrentFrame < Animation.MaxFrame)
            {
                picAssistant.Image =
                    Animation.GetFrame(Animation.Name, Animation.CurrentFrame++);

                // This is important!
                GC.Collect();
            }
            else
            {
                Animation.Timer.Stop();
                picAssistant.Image = Animation.GetIdle();
            }
        }
    }
    
    //TODO: Enums instead (easy, medium, v0.3)

    public class Animation
    {
        public static void Initialize()
        {
            Idle = Image.FromStream(
                Utils.ExecutingAssembly.GetManifestResourceStream
                    ("FuckingClippy.Images.Clippy.Idle.png"));

            AnimationList =
                Enum.GetValues(typeof(AnimationName)).Cast<AnimationName>().ToList();
        }

        /// <summary>
        /// Default <see cref="Timer"/>'s Interval value.
        /// </summary>
        internal const int DefaultInterval = 150;
        /// <summary>
        /// Default animation assembly path.
        /// </summary>
        const string AnimationPath = "FuckingClippy.Images.Clippy.Animations";
        /// <summary>
        /// Animation Timer.
        /// </summary>
        internal static Timer Timer;
        /// <summary>
        /// Animation name.
        /// </summary>
        internal static AnimationName Name
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
        static Image Idle;
        static List<AnimationName> AnimationList;

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
        public static void Play(AnimationName pName)
        {
            if (IsPlaying) return;

            Console.WriteLine($"CLR: Playing animation: {pName}");

            Name = pName;

            CurrentFrame = 0;

            Timer.Interval = DefaultInterval;

            switch (Name)
            {
                case AnimationName.Atomic:
                    MaxFrame = 34;
                    break;
                case AnimationName.Bicycle:
                    MaxFrame = 64;
                    break;
                case AnimationName.Box:
                    MaxFrame = 38;
                    break;
                case AnimationName.Check:
                    MaxFrame = 18;
                    break;
                case AnimationName.Chill:
                    MaxFrame = 84;
                    break;
                case AnimationName.ExclamationPoint:
                    MaxFrame = 9;
                    break;
                case AnimationName.FadeIn:
                    MaxFrame = 2;
                    break;
                case AnimationName.FadeOut:
                    MaxFrame = 2;
                    break;
                case AnimationName.FeelingDown:
                    MaxFrame = 45;
                    break;
                case AnimationName.Headset:
                    MaxFrame = 31;
                    break;
                case AnimationName.LookingBottomLeft:
                    MaxFrame = 4;
                    break;
                case AnimationName.LookingBottomRight:
                    MaxFrame = 11;
                    break;
                case AnimationName.LookingDown:
                    MaxFrame = 4;
                    break;
                case AnimationName.LookingUpperLeft:
                    MaxFrame = 4;
                    break;
                case AnimationName.LookingUpperRight:
                    MaxFrame = 9;
                    break;
                case AnimationName.LookingLeftAndRight:
                    MaxFrame = 17;
                    break;
                case AnimationName.Plane:
                    MaxFrame = 56;
                    break;
                case AnimationName.PointingDown:
                    MaxFrame = 12;
                    break;
                case AnimationName.PointingLeft:
                    MaxFrame = 8;
                    break;
                case AnimationName.PointingRight:
                    MaxFrame = 10;
                    break;
                case AnimationName.PointingUp:
                    MaxFrame = 9;
                    break;
                case AnimationName.Poke:
                    MaxFrame = 14;
                    break;
                case AnimationName.Reading:
                    MaxFrame = 52;
                    break;
                case AnimationName.RollPaper:
                    MaxFrame = 48;
                    break;
                case AnimationName.ScrachingHead:
                    MaxFrame = 16;
                    break;
                case AnimationName.Shovel:
                    MaxFrame = 65;
                    break;
                case AnimationName.Telescope:
                    MaxFrame = 54;
                    break;
                case AnimationName.Tornado:
                    MaxFrame = 30;
                    break;
                case AnimationName.Toy:
                    MaxFrame = 12;
                    break;
                case AnimationName.Writing:
                    MaxFrame = 58;
                    break;
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
            Play(AnimationList[new Random().Next(0, AnimationList.Count)]);
        }

        internal static Image GetFrame(AnimationName pAnimation, int pFrame)
        {
            return
                Image.FromStream(
                    Utils.ExecutingAssembly.GetManifestResourceStream($"{AnimationPath}.{pAnimation}.{pFrame}.png")
                    );
        }

        internal static Image GetIdle()
        {
            return Idle;
        }
    }
}
