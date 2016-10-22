using System;
using System.IO;
using System.Windows.Forms;

//TODO: Settings form

namespace FuckingClippy
{
    public partial class SettingsForm : Form
    {
        bool AboutInit = false;
        public enum Tab : byte
        {
            Assistant, Options
        }

        public SettingsForm(Tab pTab)
        {
            InitializeComponent();
            switch (pTab)
            {
                default:
                case Tab.Assistant:
                    MainTabControl.SelectedTab = tabAssistant;
                    break;
                case Tab.Options:
                    MainTabControl.SelectedTab = tabOptions;
                    break;
            }
        }

        private void txtAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Console.WriteLine($"CLR: Start {e.LinkText}");
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void tabAbout_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("CLR: About tab entered");

            if (!AboutInit)
            {
                AboutInit = true;

                string t = string.Empty;

                using (StreamReader s = new StreamReader(
                    Utils.ExecutingAssembly.GetManifestResourceStream(
                        "FuckingClippy.Texts.About.txt")))
                {
                    t = s.ReadToEnd();
                }

                txtAbout.Text = t.Replace("<T_VERSION>", Utils.Version);
            }
        }
    }
}
