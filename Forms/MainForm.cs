using System;
using System.Drawing;
using System.Windows.Forms;

/* Lazy todo list
- Dialog.Prompt() should return string
- Make MainForm sizeable (scale)
- Dialog.SayStatic(string) + Dialog.Update(string)
- Animation.Play(string[])
  - MaxFrames * Interval
- idle animation 5 -> 2.5 minutes
*/

namespace FuckingClippy
{
    public partial class MainForm : TransparentForm
    {
        System.Timers.Timer tmrIdleSay =
            new System.Timers.Timer(900000); // 15 minutes
        System.Timers.Timer tmrIdleAni =
            new System.Timers.Timer(120000); // 2 minutes

        /// <summary>
        /// Main form where our assistant is.
        /// </summary>
        /// <remarks>
        /// base() ensures that the constructor from <see cref="TransparentForm"/>
        /// gets called (inheritance).
        /// </remarks>
        public MainForm() : base()
        {
            InitializeComponent();

            InitializeAnimation();

            //TODO: Uncomment when translations are ready. (easy, long, v0.5)
            //InitiateCulture();

            Console.WriteLine("CLR: MainForm initiated");

            Character.CharacterForm = this;
            
            picAssistant.Dock = DockStyle.Fill;

            // Grab the current Screen info and locate the character
            // at the bottom right with a margin of 30px.
            Screen CurrentScreen = Screen.FromControl(this);
            Location =
                new Point(CurrentScreen.WorkingArea.Width - (Width + 30),
                    CurrentScreen.WorkingArea.Height - (Height + 30));

            TopMost = true; // Only hell now. :-)
#if DEBUG
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
#endif

            cmsCharacter.ResumeLayout(false);
            ResumeLayout(true);

            Animation.Play("FadeIn");

            picAssistant.MouseDown += Assistant_MouseDown;
            picAssistant.MouseUp += Assistant_MouseUp;
            picAssistant.MouseMove += Assistant_MouseMove;

            tmrIdleAni.Elapsed += TmrIdleAni_Elapsed;
            tmrIdleSay.Elapsed += TmrIdleSay_Elapsed;
            tmrIdleAni.Start();
            tmrIdleSay.Start();
        }

        private void TmrIdleSay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Character.SayRandom();
        }

        private void TmrIdleAni_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Animation.PlayRandom();
        }

        #region Mouse events
        bool FormDown;
        Point LastMouseLocation;
        Point LastFormLocation;
        bool IsPrompting;

        private void Assistant_MouseMove(object sender, MouseEventArgs e)
        {
            if (FormDown)
            {
                Location =
                    new Point((Location.X - LastMouseLocation.X) + e.X,
                    (Location.Y - LastMouseLocation.Y) + e.Y);

                Update();
            }
        }

        private void Assistant_MouseUp(object sender, MouseEventArgs e)
        {
            //TODO: Prompt on single click (medium-hard, short, v0.2)

            Form c = sender as Form;

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

        private void Assistant_MouseDown(object sender, MouseEventArgs e)
        {
            FormDown = true;
            LastMouseLocation = e.Location;
            LastFormLocation = Location;
            IsPrompting = false;
        }
        #endregion

        #region Context menu events
        private void csmiOptions_Click(object sender, EventArgs e)
        { // Settings -> Options tab
            new SettingsForm(SettingsForm.Tab.Options).ShowDialog();
        }

        private void cmsiChooseAssistant_Click(object sender, EventArgs e)
        { // Settings -> Assistant tab
            new SettingsForm(SettingsForm.Tab.Assistant).ShowDialog();
        }

        private void cmsiAnimate_Click(object sender, EventArgs e)
        {
            Animation.PlayRandom();
        }

        private void cmsiHide_Click(object sender, EventArgs e)
        {
            Animation.Play("FadeOut");

            //TODO: Find a way to delay this (medium, short, v0.2)
            Close();
        }
        #endregion
    }
}
