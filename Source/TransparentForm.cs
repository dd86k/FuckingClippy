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
                //TODO: Fix Mono transparency
                Console.WriteLine("Mono: TransparentForm called");
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
            }
            else
            {
                Console.WriteLine(".NET: TransparentForm called");
                TransparencyKey = Color.Purple;
                BackColor = Color.Purple;
            }
        }
    }
}
