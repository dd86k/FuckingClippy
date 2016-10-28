using System;
using System.Drawing;
using System.Windows.Forms;

//TODO: Add support for...
// - Images
// - Choices (radio buttons?)

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

    /// <summary>
    /// The assistant.
    /// </summary>
    static class Character
    {
        public static void Initialize(Form form)
        {
            DialogSystem.CharacterForm = form;

            AnimationSystem.Initialize();
        }

        public static void Prompt()
        {
            DialogSystem.Prompt();
        }

        public static void Say(string text)
        {
            DialogSystem.Say(text);
        }

        public static void SayRandom()
        {
            DialogSystem.SayRandom();
        }

        private static class DialogSystem
        {
            // A reference to the parent form that summons thee.
            internal static Form CharacterForm;
            // The current active bubble text.
            internal static Form CurrentBubbleForm;
            // Defaults
            static Color BubbleColor = Color.FromArgb(255, 255, 204);
            static Font DefaultFont = new Font("Segoe UI", 9);
            static Image BubbleTail =
                Utils.LoadEmbeddedImage("Bubble.Tail.png");

            #region Prompt
            /// <summary>
            /// Prompt the user for information.
            /// </summary>
            internal static void Prompt()
            {
                Utils.Log($"Prompt");

                if (CurrentBubbleForm != null)
                    CurrentBubbleForm.SuspendLayout();

                CurrentBubbleForm = GetBaseForm(GetPrompt());
                CurrentBubbleForm.ResumeLayout();

                CurrentBubbleForm.Show();
            }

            static Control[] GetPrompt()
            {
                Control[] ca = new Control[2];

                ca[0] = new Label();
                ca[0].AutoSize = true;
                ca[0].Text = "What would you like to do?";
                ca[0].Location = new Point(4, 8);
                ca[0].Font = DefaultFont;

                ca[1] = new TextBox();
                (ca[1] as TextBox).Multiline = true;
                ca[1].Size = new Size(190, 36);
                ca[1].Font = DefaultFont;
                ca[1].Location = new Point(4, 30);
                ca[1].KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter) // Includes Return
                    {
                        e.SuppressKeyPress = true;
                        Utils.ProcessInput((s as TextBox).Text);
                    }
                };

                return ca;
            }
            #endregion

            #region Say
            /// <summary>
            /// Say something to the user.
            /// </summary>
            /// <param name="text">Text.</param>
            internal static void Say(string text)
            {
                Utils.Log($"Say - {text}");

                if (CurrentBubbleForm != null)
                {
                    CurrentBubbleForm.Close();
                    CurrentBubbleForm = null;
                }

                CurrentBubbleForm = GetBaseForm(GetSay(text));

                CurrentBubbleForm.Show();
                CurrentBubbleForm.Update();
            }

            internal static void SayRandom()
            {
                string[] s =
                {
                "So, you come here often?",
                "Would you like help with hugging yourself?",
                "(this isFor ThE fAnS and G GaMerGirls)",
                "Welcome. Welcome to City 17.",
                "I can see you, but can you see me?",
                "Do you need help looking at that screen?",
                "I know, I'm not as fun as GonzoBuddy, but at least I'm not spyware, right?",
                "It would be a shame if something happened to these fil-- OOOPSS!",
                "［ ＭＡＸＩＭＵＭ ＡＲＭＯＲ ］",
                "Are you sure you want to click that?",
                "0x4E4F4246\nDid I spook you?",
                "Did you know that Intel's first microprocessor, the Intel 4004, was released in 1971, had 2,300 transistors measuring 10 microns?",
                "I am not an AI, just a bunch of CIL instructions.",
                "Seems like you need help living your life there buddy.",
                "The program '[3440] FuckingClippy.exe' has exited with code 0 (0x0).",
                "<3?",
                "Did you know that I'm a vegan?",
                "SUFFER();",
                "rawrrr x33",
                "I still have transparency and form autosizing issues on Mono!",
                "Deleting your files...",
                "S-sorry, senpai..",
                "Hey do you mind if I use more memory?",
                };

                Say(s[Utils.Random.Next(0, s.Length)]);
            }

            static Control[] GetSay(string text)
            {
                Control[] ca = new Control[1];

                ca[0] = new Label();
                ca[0].Location = new Point(4, 6);
                //ca[0].Size = new Size(192, 1000);
                ca[0].AutoSize = true;
                ca[0].MaximumSize = new Size(192, 0);
                ca[0].Font = DefaultFont;
                ca[0].Text = text;

                return ca;
            }
            #endregion

            #region Base
            static BubbleForm GetBaseForm(Control[] subControls)
            {
                if (CurrentBubbleForm != null)
                    CurrentBubbleForm.Close();

                BubbleForm f = new BubbleForm();

                /* Bubble body */
                Panel p = new Panel();
                p.Controls.AddRange(subControls);
                p.AutoSize = true;
                p.MaximumSize = new Size(200, 0);
                p.BackColor = BubbleColor;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Location = new Point(0, 0);

                /* Bubble tail */
                PictureBox pb = new PictureBox();
                pb.Size = new Size(BubbleTail.Width, BubbleTail.Height);
                pb.Image = BubbleTail;

                p.ClientSizeChanged += (s, e) =>
                {
                    pb.Location =
                        new Point((int)(f.ClientSize.Width / 1.62), p.Height);
                };

                f.Controls.Add(p);
                f.Controls.Add(pb);

                f.Location =
                    new Point(CharacterForm.Location.X - (f.Size.Width / 2),
                    CharacterForm.Location.Y - (f.Size.Height));

                return f;
            }
            #endregion
        }
        
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
            public const int DefaultInterval = 125;
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
                Play((Animation)Utils.Random.Next(0, NumberOfAnimations));
            }
        }
    }
}
