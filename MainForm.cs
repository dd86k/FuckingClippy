using System;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    public partial class MainForm : TransparentForm
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeAnimation();

            picCharacter.MouseDown += Assistant_MouseDown;
            picCharacter.MouseUp += Assistant_MouseUp;
            picCharacter.MouseMove += Assistant_MouseMove;

            Dialog.ParentForm = this;

            ClientSize = picCharacter.Size;
            
            // Grab the current Screen info and locate the character at the bottom right.
            Screen CurrentScreen = Screen.FromControl(this);
            LastLocation =
                Location =
                new Point(CurrentScreen.WorkingArea.Width - (Width + 30),
                CurrentScreen.WorkingArea.Height - (Height + 30));

            picCharacter.Image = Animation.GetIdle();

            TopMost = true; // Only hell now. :-)

            //Dialog.Prompt();
            Dialog.Say("Hello it's me the long text that will haunt you for ever.");
        }

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
            //TODO:[H] Fix Character_MouseUp
            if (e.Location.X == LastLocation.X)
                FormDown = false;
            else
                Dialog.Prompt();
        }

        private void Assistant_MouseDown(object sender, MouseEventArgs e)
        {
            FormDown = true;
            LastLocation = e.Location;
        }

        private void cmsiHide_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
