using System;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeAnimation();

            picCharacter.MouseDown += Clippy_MouseDown;
            picCharacter.MouseUp += Clippy_MouseUp;
            picCharacter.MouseMove += Clippy_MouseMove;
            
            ClientSize = picCharacter.Size;
            
            // Grab the current Screen info and locate the character at the bottom right.
            Screen CurrentScreen = Screen.FromControl(this);
            Location = new Point(CurrentScreen.WorkingArea.Width - (Width + 30),
                CurrentScreen.WorkingArea.Height - (Height + 30));

            // Make the form transparent
            // NOTE: BackColor = Color.Transparent; will not work.
            TransparencyKey = Color.Purple;
            BackColor = Color.Purple;
            
            picCharacter.Image = Animation.GetIdle(); // Ready to go!

            TopMost = true;
        }

        bool FormDown;
        Point LastLocation;

        private void Clippy_MouseMove(object sender, MouseEventArgs e)
        {
            if (FormDown)
            {
                Location =
                    new Point((Location.X - LastLocation.X) + e.X,
                    (Location.Y - LastLocation.Y) + e.Y);

                Update();
            }
        }

        private void Clippy_MouseUp(object sender, MouseEventArgs e)
        {
            FormDown = false;
        }

        private void Clippy_MouseDown(object sender, MouseEventArgs e)
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
