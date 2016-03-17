using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Reflection.Assembly;

//TODO: Add support for:
// - Images
// - Choices (radio buttons?)

namespace FuckingClippy
{
    /// <summary>
    /// Dialog system.
    /// </summary>
    static class Character
    {
        // A reference to the parent form that summons thee.
        internal static Form CharacterForm;
        // The current active bubble text.
        internal static Form CurrentBubbleForm;
        static Color BubbleColor = Color.FromArgb(255, 255, 204);
        static Font DefaultFont = new Font("Segoe UI", 9);
        static Image BubbleTail = Image.FromStream(
            GetExecutingAssembly().GetManifestResourceStream(
                "FuckingClippy.Images.Bubble.BubbleTail.png"));

        #region Prompt
        /// <summary>
        /// Prompt the user and ask him what he wants for christmas.
        /// </summary>
        internal static void Prompt()
        {
            Console.WriteLine($"CLR: Prompt() called -- {DefaultFont.Name}");

            CurrentBubbleForm = GetBaseForm(GetPrompt());
            
            CurrentBubbleForm.Show();
        }

        static Control[] GetPrompt()
        {
            List<Control> lst = new List<Control>();

            Label l = new Label();
            l.AutoSize = true;
            l.Text = "What would you like to do?";
            l.Location = new Point(4, 8);
            l.Font = DefaultFont;

            TextBox t = new TextBox();
            t.Multiline = true;
            t.Size = new Size(190, 36);
            t.Font = DefaultFont;
            t.Location = new Point(4, 30);
            t.KeyDown += t_UserInput;

            lst.Add(l);
            lst.Add(t);

            return lst.ToArray();
        }

        private static void t_UserInput(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                TextBox t = s as TextBox;
                Utils.ProcessInput(t.Text);
            }
        }
        #endregion

        #region Say
        /// <summary>
        /// Say something to the user.
        /// </summary>
        /// <param name="pText">Text.</param>
        internal static void Say(string pText)
        {
            Console.WriteLine($"CLR: Say({pText}) called -- {DefaultFont.Name}");

            CurrentBubbleForm = GetBaseForm(GetSay(pText));

            CurrentBubbleForm.Show();
        }

        internal static void SayRandom()
        {
            string[] str =
            {
                "I heard you like pies.",
                "Would you like help with hugging yourself?",
                "I got you a gift for christmas. It's called a kernel panic! Let me show you!",
                "test123 guys can you hear me",
                "foo dick",
                "Looks like you're trying to focus, need some help?",
                "I hope you're enjoying staring at my body.",
                "WHY DOESN'T EMOJIS WORK HUH",
                "I'm bored.",
                "DUDE WHERE'S MY GAC? >:-(",
                "Meow."
            };

            Say(str[new Random().Next(0, str.Length)]);
        }

        static Control[] GetSay(string pText)
        {
            List<Control> lst = new List<Control>();

            Label l = new Label();
            l.Location = new Point(4, 6);
            //l.Size = new Size(192, 1000);
            l.AutoSize = true;
            l.MaximumSize = new Size(192, 0);
            l.Font = DefaultFont;
            l.Text = pText;

            lst.Add(l);

            return lst.ToArray();
        }
        #endregion

        #region Bases
        static BubbleForm GetBaseForm(Control[] pSubControls)
        {
            if (CurrentBubbleForm != null)
                CurrentBubbleForm.Close();

            BubbleForm f = new BubbleForm();
            f.Font = DefaultFont;
            f.Deactivate += (s, e) =>
            {
                f.Close();
            };
            f.MaximumSize = new Size(9000, 9000);
            f.AutoSize = true;
            f.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            /* Bubble body */
            Panel p = new Panel();
            p.Controls.AddRange(pSubControls);
            p.AutoSize = true;
            p.MaximumSize = new Size(200, 0);
            p.BackColor = BubbleColor;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Location = new Point(0, 0);
            //p.Size = pClientSize;

            /* Bubble tail */
            PictureBox pb = new PictureBox();
            pb.Size = new Size(BubbleTail.Width, BubbleTail.Height);
            pb.Image = BubbleTail;

            p.ClientSizeChanged += (s, e) =>
            {
                pb.Location = new Point((int)(f.ClientSize.Width / 1.62),
                    p.Height);
            };

            f.Controls.Add(p);
            f.Controls.Add(pb);
            
            f.Location =
                new Point(CharacterForm.Location.X - (f.Size.Width / 2),
                CharacterForm.Location.Y - (f.Size.Height));

            return f;
        }
        #endregion
    }

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
        }
    }
}
