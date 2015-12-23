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
                //TODO*: Fix Mono transparency
                System.Console.WriteLine("CLR: TransparentForm called: Mono");
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
            }
            else
            {
                System.Console.WriteLine("CLR: TransparentForm called: .NET");
                TransparencyKey = Color.Purple;
                BackColor = Color.Purple;
            }
        }
    }
}
