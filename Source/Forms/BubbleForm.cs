using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    class BubbleForm : TransparentForm
    {
        public BubbleForm() : base()
        {
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;

            AutoSize = true;
            MaximumSize = new Size(200, 0);
            AutoSizeMode = AutoSizeMode.GrowOnly;

            Font = DefaultFont;
            MaximumSize = new Size(9000, 9000);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Deactivate += (s, e) =>
            {
                Close();
            };
        }
    }
}
