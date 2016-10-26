using System;
using System.Drawing;
using System.Timers;

namespace FuckingClippy
{
    public enum Animation : byte
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
            AnimationSystem.AnimationTimer =
                new Timer(AnimationSystem.DefaultInterval);
            AnimationSystem.AnimationTimer.Elapsed += Animation_OnFrame;
            AnimationSystem.Initialize();
        }
        
        /// <remarks>
        /// Animation_OnFrame is within MainForm to access
        /// picCharacter (PictureBox, private).
        /// </remarks>
        void Animation_OnFrame(object s, EventArgs e)
        {
            if (AnimationSystem.CurrentFrame < AnimationSystem.MaxFrame)
            {
                picAssistant.Image = AnimationSystem.GetNextFrame();
                
                // Every 2 frames.
                if (AnimationSystem.CurrentFrame % 2 != 0)
                    GC.Collect();
            }
            else
            {
                AnimationSystem.Stop();
                picAssistant.Image = AnimationSystem.Idle;
            }
        }
    }

    //TODO: Move AnimationSystem to Character?
    public static class AnimationSystem
    {
        public static void Initialize()
        {
            Idle = Utils.LoadEmbeddedImage("Clippy.Idle.png");

            AnimationTimer.Interval = DefaultInterval;

            NumberOfAnimations = Enum.GetNames(typeof(Animation)).Length;
        }

        public static void Stop()
        {
            AnimationTimer.Stop();
        }

        /// <summary>
        /// Default <see cref="AnimationTimer"/>'s interval.
        /// </summary>
        internal const int DefaultInterval = 150;
        /// <summary>
        /// Animation Timer.
        /// </summary>
        internal static Timer AnimationTimer;
        /// <summary>
        /// Current animation.
        /// </summary>
        internal static Animation CurrentAnimation
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
        internal static Image Idle;

        private static int NumberOfAnimations;

        /// <summary>
        /// Get if there is an animation playing.
        /// </summary>
        static internal bool IsPlaying => AnimationTimer.Enabled;

        /// <summary>
        /// Play an animation. If there is already an animation rolling, simply
        /// ignore the request.
        /// </summary>
        /// <param name="name">Name of the animation.</param>
        public static void Play(Animation name)
        {
            if (IsPlaying) return;

            Utils.Log($"Playing animation: {name}");

            CurrentAnimation = name;

            CurrentFrame = 0;

            string path = $"Images.Clippy.Animations.{name}";

            if (!Utils.EmbeddedItemExist(path))
                throw new ArgumentException("Animation not found.");

            MaxFrame = Utils.GetNumberOfEmbeddedItems(path);

            AnimationTimer.Start();
        }

        public static Image GetFrame(int frame)
        {
            return Utils.LoadEmbeddedImage(
                $"Clippy.Animations.{CurrentAnimation}.{frame}.png"
            );
        }

        public static Image GetNextFrame()
        {
            return GetFrame(CurrentFrame++);
        }

        /// <summary>
        /// Play a random animation.
        /// </summary>
        public static void PlayRandom()
        {
            Play((Animation)Utils.R.Next(0, NumberOfAnimations));
        }
    }
}
