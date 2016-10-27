using System;
using System.Drawing;
using System.Windows.Forms;

/* Lazy todo list
- Dialog.Prompt() should return string
- Make MainForm sizeable (fixed scale)
- Dialog.SayStatic(string) + Dialog.Update(string)
- Animation.Play(string[])
  - MaxFrames * Interval
*/

namespace FuckingClippy
{
    public partial class MainForm : TransparentForm
    {
        Timer tmrIdleSay = new Timer();
        Timer tmrIdleAni = new Timer();

        /// <summary>
        /// Main form where our assistant is.
        /// </summary>
        /// <remarks>
        /// base() ensures that the constructor from
        /// <see cref="TransparentForm"/> gets called.
        /// </remarks>
        public MainForm() : base()
        {
            InitializeComponent();

            InitializeAnimation();

            //TODO: Uncomment when translations are ready.
            //InitiateCulture();

            Utils.Log("MainForm initiated");

            Character.Initialize(this);
            
            picAssistant.Dock = DockStyle.Fill;

            tmrIdleAni.Interval = 120000;
#if DEBUG
            tmrIdleSay.Interval = 5000;
#else
            tmrIdleSay.Interval = 150000;
#endif

            // Grab the current Screen info and locate the character
            // at the bottom right with a margin of 30px.
            Screen sc = Screen.FromControl(this);
            Location =
                new Point(sc.WorkingArea.Width - (Width + 30),
                    sc.WorkingArea.Height - (Height + 30));

            /*Character.DelegateRandomSay = new
                Character.RandomSay(Character.CallSayRandom);*/

            picAssistant.MouseDown += Assistant_MouseDown;
            picAssistant.MouseUp += Assistant_MouseUp;
            picAssistant.MouseMove += Assistant_MouseMove;

            tmrIdleAni.Tick += TmrIdleAni_Tick;
            tmrIdleSay.Tick += TmrIdleSay_Tick;

            TopMost = true; // Only hell now. :-)
#if DEBUG
            {
                ToolStripItem[] DebugItems = new ToolStripItem[2];

                DebugItems[0] = new ToolStripMenuItem();
                DebugItems[0].Text = "[Debug] Prompt";
                DebugItems[0].Click += (s, e) =>
                {
                    Character.Prompt();
                };

                DebugItems[1] = new ToolStripMenuItem();
                DebugItems[1].Text = "[Debug] Say (Random)";
                DebugItems[1].Click += (s, e) =>
                {
                    Character.SayRandom();
                };

                cmsCharacter.Items.AddRange(DebugItems);
            }
#endif

            cmsCharacter.ResumeLayout(false);
            ResumeLayout(true);
            
            Character.AnimationSystem.Play(Animation.FadeIn);
            tmrIdleAni.Start();
            tmrIdleSay.Start();
        }

        #region Idle timers
        void TmrIdleSay_Tick(object sender, EventArgs e)
        {
            //Character.CallSayRandom();
            //Character.DelegateRandomSay.Invoke();
            //Character.SayRandom();
        }

        void TmrIdleAni_Tick(object sender, EventArgs e)
        {
            Character.AnimationSystem.PlayRandom();
        }
        #endregion

        #region Mouse events
        bool FormDown, IsPrompting;
        Point LastMouseLocation, LastFormLocation;

        void Assistant_MouseMove(object sender, MouseEventArgs e)
        {
            if (FormDown)
            {
                Location =
                    new Point((Location.X - LastMouseLocation.X) + e.X,
                    (Location.Y - LastMouseLocation.Y) + e.Y);

                Update();
            }
        }

        void Assistant_MouseUp(object sender, MouseEventArgs e)
        {
            FormDown = false;

            if (e.Button == MouseButtons.Left)
                if (LastFormLocation.X == Location.X &&
                    LastFormLocation.Y == Location.Y &&
                    !IsPrompting)
                {
                    IsPrompting = true;
                    Character.Prompt();
                }
        }

        void Assistant_MouseDown(object sender, MouseEventArgs e)
        {
            FormDown = true;
            IsPrompting = false;
            LastMouseLocation = e.Location;
            LastFormLocation = Location;
        }
#endregion

#region Context menu events
        void csmiOptions_Click(object sender, EventArgs e)
        { // Settings -> Options tab
            new SettingsForm(SettingsForm.Tab.Options).ShowDialog();
        }

        void cmsiChooseAssistant_Click(object sender, EventArgs e)
        { // Settings -> Assistant tab
            new SettingsForm(SettingsForm.Tab.Assistant).ShowDialog();
        }

        void cmsiAnimate_Click(object sender, EventArgs e)
        {
            Character.AnimationSystem.PlayRandom();
        }

        void cmsiHide_Click(object sender, EventArgs e)
        {
            Character.AnimationSystem.Play(Animation.FadeOut);

            // Dirty solution
            Timer a = new Timer();
            a.Interval = 3 * Character.AnimationSystem.DefaultInterval;
            a.Tick += (s, g) => { Close(); };
            a.Start();
        }
#endregion
    }
}
