using System;
using System.Drawing;
using System.Windows.Forms;

/* Lazy todo list
- Every 30 minutes: text
- Every 10 minutes: animation (lazy-type)
*- Dialog.Prompt() should return string
*- Make MainForm sizeable (scale)
*- Dialog.SayStatic(string) + Dialog.Update(string)
*- Animation.Play(string[])
  - MaxFrames * Interval

* Not at the Dec 25th release (or extra if possible)
*/

namespace FuckingClippy
{
    public partial class MainForm : TransparentForm
    {
        public MainForm() : base()
        {
            InitializeComponent();

            InitializeAnimation();

            Console.WriteLine("CLR: MainForm initiated");

            //TODO*: Uncomment when translations are ready.
            //InitiateCulture();

            picCharacter.MouseDown += Assistant_MouseDown;
            picCharacter.MouseUp += Assistant_MouseUp;
            picCharacter.MouseMove += Assistant_MouseMove;

            Dialog.ParentForm = this;

            ClientSize = picCharacter.Size;
            picCharacter.Dock = DockStyle.Fill;

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
                Dialog.Prompt();
            };

            DebugItems[1] = new ToolStripMenuItem();
            DebugItems[1].Text = "[Debug] Say (Random)";
            DebugItems[1].Click += (s, e) =>
            {
                Dialog.SayRandom();
            };

            cmsCharacter.Items.AddRange(DebugItems);
#endif

            Animation.Play("FadeIn");
        }

        #region Mouse events
        bool FormDown;
        Point LastLocation;

        private void Assistant_MouseMove(object sender, MouseEventArgs e)
        {
            if (FormDown)
            {
                Location =
                    new Point((Location.X - LastLocation.X) + e.X,
                    (Location.Y - LastLocation.Y) + e.Y);

                Update();
            }
        }

        private void Assistant_MouseUp(object sender, MouseEventArgs e)
        {
            //TODO**: Find a way to figure out when the cursor
            // hasn't changed position, if so, prompt.
            FormDown = false;
        }

        private void Assistant_MouseDown(object sender, MouseEventArgs e)
        {
            FormDown = true;
            LastLocation = e.Location;
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
            Close();
        }
        #endregion
    }
}
