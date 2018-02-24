using System;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    public partial class MainForm : TransparentForm
    {
        Timer IdleTalkTimer = new Timer();
        Timer IdleAnimationTimer = new Timer();

        public MainForm() : base()
        {
            Utils.Log("Initializing MainForm...");

            InitializeComponent();

            Utils.Log("MainForm initiated");

            SuspendLayout();

            //TODO: Uncomment when translations are ready.
            //InitiateCulture();
            
            ShowIcon = false; // Use main icon. (Windows)

            Character.Initialize(this);

            // Grab the current Screen info and locate the character
            // at the bottom right with a margin of 30 pixels.
            {
                Screen sc = Screen.PrimaryScreen; // Screen.FromControl(this)
                Location = new Point(
                        sc.WorkingArea.Width - (Width + 30),
                        sc.WorkingArea.Height - (Height + 30)
                    );
            }

            picAssistant.Dock = DockStyle.Fill;
            picAssistant.MouseDown += Assistant_MouseDown;
            picAssistant.MouseUp += Assistant_MouseUp;
            picAssistant.MouseMove += Assistant_MouseMove;

            IdleAnimationTimer.Tick += TmrIdleAni_Tick;
            IdleTalkTimer.Tick += TmrIdleSay_Tick;
            IdleAnimationTimer.Interval = 30000; // 30 seconds
            IdleTalkTimer.Interval = 270000; // 4.5 minutes

            TopMost = true; // Only hell now. :-)
#if DEBUG
            ToolStripItem[] DebugItems = new ToolStripItem[2];

            DebugItems[0] = new ToolStripMenuItem()
            {
                Text = "[Debug] Prompt"
            };
            DebugItems[0].Click += (s, e) => Character.Prompt();

            DebugItems[1] = new ToolStripMenuItem()
            {
                Text = "[Debug] Say (Random)"
            };
            DebugItems[1].Click += (s, e) => Character.SayRandom();

            cmsCharacter.Items.AddRange(DebugItems);
#endif
            cmsCharacter.ResumeLayout(false);
            ResumeLayout(true);

            Character.PlayAnimation(Animation.FadeIn);
            IdleAnimationTimer.Start();
            IdleTalkTimer.Start();

            GC.Collect();

#if OFFICE
            ExcelHelper.Initialize();
#elif OFFICE && DEBUG
            // Also should be a dynamic setting with CLI switch.
            // And started manually by the user probably? Or scan for process?
            ExcelHelper.Test();
#endif
        }

        /// <summary>
        /// Exit main application while playing the FadeOut animation.
        /// </summary>
        public void Exit()
        {
            Character.PlayAnimation(Animation.FadeOut);

            // Dirty/temporary solution
            Timer a = new Timer()
            {
                Interval = 3 * 125 // Temporary
            };
            a.Tick += (s, e) => { Close(); };
            a.Start();
        }

#region Idle timers
        void TmrIdleSay_Tick(object sender, EventArgs e)
        {
            Character.SayRandom();
        }

        void TmrIdleAni_Tick(object sender, EventArgs e)
        {
            Character.PlayRandomAnimation();
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
        void CmsiHide_Click(object sender, EventArgs e)
        {
            Exit();
        }

        void CsmiOptions_Click(object sender, EventArgs e)
        { // Settings -> Options tab
            new SettingsForm(Tab.Options).ShowDialog();
        }

        void CmsiChooseAssistant_Click(object sender, EventArgs e)
        { // Settings -> Assistant tab
            new SettingsForm(Tab.Assistant).ShowDialog();
        }

        void CmsiAnimate_Click(object sender, EventArgs e)
        {
            Character.PlayRandomAnimation();
        }
#endregion
    }
}
