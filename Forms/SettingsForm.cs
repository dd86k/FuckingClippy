using System.Windows.Forms;

namespace FuckingClippy
{
    public partial class SettingsForm : Form
    {
        public enum Tab : byte
        {
            Assistant,
            Options
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
