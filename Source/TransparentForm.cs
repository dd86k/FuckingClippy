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
                System.Console.WriteLine("TransparentForm called: Mono");
                SetStyle(ControlStyles.SupportsTransparentBackColor |
                    ControlStyles.UserPaint, true);
                BackColor = Color.Transparent;
            }
            else
            {
                System.Console.WriteLine("TransparentForm called: .NET");
                TransparencyKey = Color.Purple;
                BackColor = Color.Purple;
            }
        }
    }
}
