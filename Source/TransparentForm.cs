using System;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    public class TransparentForm : Form
    {
        public TransparentForm()
        {
            if (Utils.IsRunningOnMono)
            {
                //TODO: Fix Mono transparency (hard, short-long, *)
                Console.WriteLine("CLR: TransparentForm called: Mono");
                SetStyle(ControlStyles.UserPaint |
                    ControlStyles.SupportsTransparentBackColor |
                    ControlStyles.AllPaintingInWmPaint, true);
                BackColor = Color.FromArgb(0, 0, 0, 0);
            }
            else
            {
                Console.WriteLine("CLR: TransparentForm called: .NET");
                TransparencyKey = Color.Purple;
                BackColor = Color.Purple;
            }
        }
    }
}
