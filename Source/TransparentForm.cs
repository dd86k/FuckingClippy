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
                SetStyle(ControlStyles.SupportsTransparentBackColor |
                    ControlStyles.UserPaint, true);
                BackColor = Color.Transparent;
            }
            else
            {
                TransparencyKey = Color.Purple;
                BackColor = Color.Purple;
            }
        }
    }
}
