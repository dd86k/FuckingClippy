using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FuckingClippy
{
    partial class MainForm
    {

    }

    /// <summary>
    /// Dialog system.
    /// </summary>
    static class Dialog
    {
        // A reference to the parent form that summons thee.
        internal static Form ParentForm;
        static Color BubbleColor = Color.FromArgb(255, 255, 204);
        static Font DefaultFont = new Font("Segoe UI", 9);

        #region Prompt
        /// <summary>
        /// Prompt the user and ask him what he wants for christmas.
        /// </summary>
        internal static void Prompt()
        {
            DialogForm form = GetBaseForm(GetPrompt(), new Size(206, 98));

            form.Show();
        }

        static Control[] GetPrompt()
        {
            List<Control> lst = new List<Control>();

            Label l = new Label();
            l.AutoSize = true;
            l.Text = "What would you like to do?";
            l.Location = new Point(4, 8);

            TextBox t = new TextBox();
            t.Multiline = true;
            t.Size = new Size(190, 34);
            t.Location = new Point(4, 32);

            lst.Add(l);
            lst.Add(t);

            return lst.ToArray();
        }
        #endregion

        #region Say
        /// <summary>
        /// Say something to the user.
        /// </summary>
        /// <param name="pText">Text.</param>
        internal static void Say(string pText)
        {
            DialogForm form = GetBaseForm(GetSay(pText), GetSize(pText));

            form.Show();
        }

        static Control[] GetSay(string pText)
        {
            List<Control> lst = new List<Control>();

            Label l = new Label();
            l.Location = new Point(4, 8);
            l.Size = new Size(192, 1000);
            l.Text = pText;

            lst.Add(l);

            return lst.ToArray();
        }
        #endregion

        #region Bases
        static DialogForm GetBaseForm(Control[] pSubControls, Size pClientSize)
        {
            DialogForm form = new DialogForm();
            form.Font = DefaultFont;
            form.TopMost = true;
            form.ShowInTaskbar = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.Manual;
            form.TransparencyKey = Color.Purple;
            form.BackColor = Color.Purple;
            form.ClientSize =
                new Size(pClientSize.Width, pClientSize.Height + 15);
            form.Location =
                new Point(ParentForm.Location.X - (form.Size.Width / 2),
                ParentForm.Location.Y - (form.Size.Height - 4));
            form.Deactivate += (s, e) =>
            {
                //Close();
                Console.WriteLine(" Form closed -- Sadness");
            };

            Panel p = new Panel();
            p.BackColor = BubbleColor;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.AddRange(pSubControls);
            p.Size = pClientSize;

            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 15);
            pb.Location = new Point((int)(form.ClientSize.Width / 1.65),
                form.ClientSize.Height - 15);
            pb.Image =
                Image.FromStream(
                    System.Reflection.Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(
                        "FuckingClippy.Images.Bubble.BubbleTail.png"
                        )
                    );

            form.Controls.Add(p);
            form.Controls.Add(pb);

            return form;
        }
        #endregion

        static Size GetSize(string pData)
        {
            return new Size(200, 20 + (((pData.Length / 25) + 1) * (int)DefaultFont.Size));
        }

        /// <summary>
        /// Process user input.
        /// </summary>
        /// <param name="pUserInput">User input.</param>
        static void Run(string pUserInput)
        {

        }
    }

    class DialogForm : Form
    {
        internal DialogForm()
        {
        }
    }
}
