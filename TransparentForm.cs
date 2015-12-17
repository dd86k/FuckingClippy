using System;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
	public class TransparentForm : Form
	{
		public TransparentForm ()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor = Color.Transparent;
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// Empty on purpose
		}
	}
}

