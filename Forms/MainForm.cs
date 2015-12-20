using System;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    public partial class MainForm : TransparentForm
    {
        public MainForm() : base()
        {
            InitializeComponent();

            InitializeAnimation();

            Console.WriteLine(Utils.IsRunningOnMono ? "Running on: Mono" : "Running on: .NET/CLR");

            //TODO: Uncomment when translations are ready.
            //InitiateCulture();

            picCharacter.MouseDown += Assistant_MouseDown;
            picCharacter.MouseUp += Assistant_MouseUp;
            picCharacter.MouseMove += Assistant_MouseMove;

            Dialog.ParentForm = this;

            ClientSize = picCharacter.Size;

            // Grab the current Screen info and locate the character
            // at the bottom right with a margin of 30px.
            Screen CurrentScreen = Screen.FromControl(this);
            Location =
                new Point(CurrentScreen.WorkingArea.Width - (Width + 30),
                    CurrentScreen.WorkingArea.Height - (Height + 30));
            
            picCharacter.Image = Animation.GetIdle();

            TopMost = true; // Only hell now. :-)

#if DEBUG
            ToolStripItem[] DebugItems = new ToolStripItem[3];
            
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
                string[] str =
                {
                    "I heard you like cock.",
                    "Would you like help with hugging yourself?",
                    "test123 guys can you hear me"
                };

                Dialog.Say(str[new Random().Next(0, str.Length)]);
            };

            DebugItems[2] = new ToolStripMenuItem();
            DebugItems[2].Text = "[Debug] Animate (Check)";
            DebugItems[2].Click += (s, e) =>
            {
                Animation.PlayAnimation("Check");
            };

            cmsCharacter.Items.AddRange(DebugItems);
#endif

            GC.Collect();
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
            //TODO:[High] Find a way to figure out when the cursor
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
        private void cmsiChooseAssistant_Click(object sender, EventArgs e)
        { // Settings -> Assistant tab

        }

        private void csmiOptions_Click(object sender, EventArgs e)
        { // Settings -> Options tab

        }

        private void cmsiHide_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
