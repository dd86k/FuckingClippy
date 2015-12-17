using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FuckingClippy
{
    partial class MainForm
    {
        internal enum DialogType : byte
        {
            /// <summary>
            /// The Character dialogs to the user.
            /// </summary>
            Text,
            /// <summary>
            /// The Character asks a question to the user.
            /// </summary>
            Question,
            /// <summary>
            /// The Character asks a list of choices to the user.
            /// </summary>
            /// <remarks>
            /// The form will consist of radio buttons and the input of choices
            /// must be an array of a custom type.
            /// TODO: Custom struct.
            /// </remarks>
            Choice
        }


    }

    static class Dialog
    {
        internal static Form ParentForm;
        static Color BubbleColor = Color.FromArgb(255, 255, 204);

        internal static void Show()
        {
            DialogForm form = new DialogForm();

            form.TransparencyKey = Color.Purple;
            form.BackColor = Color.Purple;

            //form.Size = GetSize(pText);
            form.Size = new Size(206, 100);

            form.Location =
                new Point(ParentForm.Location.X - (form.Size.Width / 2),
                ParentForm.Location.Y - form.Size.Height);
            
            {
                Panel p = new Panel();
                p.BackColor = BubbleColor;

                Label l = new Label();
                l.AutoSize = true;
                l.Location = new Point(4, 8);
                l.Text = "What would you like to do?";

                TextBox t = new TextBox();
                t.Multiline = true;
                t.Size = new Size(p.Size.Width - 8, 34);
                t.Location = new Point(4, 31);

                p.Controls.Add(l);
                p.Controls.Add(t);

                form.Controls.Add(p);
            }

            form.Show();
        }

        static Size GetSize(string pData)
        {
            //TODO: Check GetSize(string);
            return new Size(200, 40 + ((pData.Length / 25) * 20));
        }

        static void Run(string pUserInput)
        {

        }
    }

    class DialogForm : Form
    {
        internal DialogForm()
        {
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            Deactivate += (s, e) =>
            {
                //Close();
                Console.WriteLine(" Form closed -- Sadness");
            };
        }
    }
}
