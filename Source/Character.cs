﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Reflection.Assembly;

//TODO: Add support for... (medium, medium, v0.3)
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

            if (CurrentBubbleForm != null)
                CurrentBubbleForm.SuspendLayout();
            CurrentBubbleForm = GetBaseForm(GetPrompt());
            CurrentBubbleForm.ResumeLayout();
            
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

            if (CurrentBubbleForm != null)
                CurrentBubbleForm.SuspendLayout();
            CurrentBubbleForm = GetBaseForm(GetSay(pText));
            CurrentBubbleForm.ResumeLayout();

            CurrentBubbleForm.Show();
        }

        internal static void SayRandom()
        {
            string[] s =
            {
                "So, you come here often?",
                "Would you like help with hugging yourself?",
                "(this isFor ThE fAnS and G GaMerGirls)",
                "Welcome. Welcome to City 17.",
                "I can see you, but can you see me?",
                "Do you need help looking at that screen?",
                "I know, I'm not as fun as GonzoBuddy, but at least I'm not spyware, right?",
                "It would be a shame if something happened to these fil-- OOOPSS!",
                "[MAXIMUM ARMOR]",
                "Are you sure you want to click that?",
                "0x4E4F4246\nDid I spook you?",
                "Did you know that Intel's first microprocessor, the Intel 4004, was released in 1971, had 2,300 transistors measuring 10 microns?",
                "I am not an AI, just a bunch of IL instructions.",
                "Seems like you need help living your life there buddy.",
                "The program '[3440] FuckingClippy.vshost.exe' has exited with code 0 (0x0).",
                "<3?",
                "Did you know that I'm a vegan?",
                "SUFFER();",
                "rawrrr x33",
                "I still have transparency and form autosizing issues on Mono!",
                "Deleting your files...",
                "S-sorry, senpai..",
                "Hey do you mind if I use more memory?",
            };

            Say(s[new Random().Next(0, s.Length)]);
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

        #region Base
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