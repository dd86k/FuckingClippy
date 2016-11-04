using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    public class TransparentForm : Form
    {
        public TransparentForm()
        {
            Utils.Log("TransparentForm called");

            if (Utils.RunningMono)
            {
                //TODO: #3 Fix Mono transparency
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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
