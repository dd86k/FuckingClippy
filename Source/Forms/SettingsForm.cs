using System.Windows.Forms;

//TODO: Settings form

namespace FuckingClippy
{
    public partial class SettingsForm : Form
    {
        public enum Tab : byte
        {
            Assistant, Options
        }

        public SettingsForm(Tab tab)
        {
            InitializeComponent();
            switch (tab)
            {
                default:
                case Tab.Assistant:
                    MainTabControl.SelectedTab = tabAssistant;
                    break;
                case Tab.Options:
                    MainTabControl.SelectedTab = tabOptions;
                    break;
            }
            lblAbout.Text = $"{Utils.ProjectName} v{Utils.Version}";
        }
    }
}
