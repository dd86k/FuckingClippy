using System;
using System.Windows.Forms;

//TODO: Settings form (medium, long, v0.3)

namespace FuckingClippy
{
    public partial class SettingsForm : Form
    {
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
    }
}
