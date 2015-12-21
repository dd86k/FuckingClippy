using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Diagnostics.Process;

//TODO: Add support for:
// - Images
// - Choices (radio buttons?)

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
        // The current active bubble text.
        internal static Form CurrentForm;
        static Color BubbleColor = Color.FromArgb(255, 255, 204);
        static Font DefaultFont = new Font("Segoe UI", 9);
        static Image BubbleTail = Image.FromStream(
            System.Reflection.Assembly.GetExecutingAssembly()
            .GetManifestResourceStream(
                "FuckingClippy.Images.Bubble.BubbleTail.png"));

        #region Prompt
        /// <summary>
        /// Prompt the user and ask him what he wants for christmas.
        /// </summary>
        internal static void Prompt()
        {
            CurrentForm = GetBaseForm(GetPrompt(), new Size(206, 98));

            CurrentForm.Show();
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
            t.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
                {
                    ProcessInput(t.Text);
                }
            };

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
            CurrentForm = GetBaseForm(GetSay(pText), GetSizeWithText(pText));

            CurrentForm.Show();
        }

        static Control[] GetSay(string pText)
        {
            List<Control> lst = new List<Control>();

            Label l = new Label();
            l.Location = new Point(4, 6);
            l.Size = new Size(192, 1000);
            l.Text = pText;

            lst.Add(l);

            return lst.ToArray();
        }

        static Size GetSizeWithText(string pData)
        {
            // TODO: Find the perfect Height sizing algorithm
            return new Size(200,
                12 + (((pData.Length / 25) + 1) * ((int)DefaultFont.Size * 2)));
        }
        #endregion

        #region Bases
        static DialogForm GetBaseForm(Control[] pSubControls, Size pClientSize)
        {
            DialogForm form = new DialogForm();
            form.Font = DefaultFont;
            form.ClientSize =
                new Size(pClientSize.Width, pClientSize.Height + 15);
            form.Location =
                new Point(ParentForm.Location.X - (form.Size.Width / 2),
                ParentForm.Location.Y - (form.Size.Height - 4));
            form.Deactivate += (s, e) =>
            {
                form.Close();
            };

            /* Bubble body */
            Panel p = new Panel();
            p.BackColor = BubbleColor;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.AddRange(pSubControls);
            p.Size = pClientSize;

            /* Bubble tail */
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 15);
            pb.Location = new Point((int)(form.ClientSize.Width / 1.62),
                form.ClientSize.Height - 15);
            pb.Image = BubbleTail;

            form.Controls.Add(p);
            form.Controls.Add(pb);

            return form;
        }
        #endregion

        /// <summary>
        /// Process user input.
        /// </summary>
        /// <param name="pUserInput">User input.</param>
        static void ProcessInput(string pUserInput)
        {
            Console.WriteLine($"User input: {pUserInput}");

            if (pUserInput.StartsWith("run "))
            {
                string run = pUserInput.Substring(4);
                
                Console.WriteLine($"User action: RUN - Parameter: {run}");

                Start(run);
            }

            if (pUserInput.StartsWith("search "))
            {
                string run = pUserInput.Substring(7);

                Console.WriteLine($"User action: SEARCH - Parameter: {run}");

                Start($"https://www.google.ca/?q={run}");
            }

            CurrentForm.Close();
        }
    }

    class DialogForm : TransparentForm
    {
        public DialogForm() : base()
        {
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
        }
    }
}
