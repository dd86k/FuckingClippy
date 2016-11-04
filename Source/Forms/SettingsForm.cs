using System.Windows.Forms;

namespace FuckingClippy
{
    public enum Tab : byte
    {
        Assistant, Options
    }

    public partial class SettingsForm : Form
    {
        public SettingsForm(Tab tab)
        {
            InitializeComponent();

            switch (tab)
            {
                default:
                    MainTabControl.SelectedTab = tabAssistant;
                    break;
                case Tab.Options:
                    MainTabControl.SelectedTab = tabOptions;
                    break;
            }

            lblAbout.Text = $"{Utils.ProjectName} v{Utils.Version}";
        }

        void btnOk_Click(object sender, System.EventArgs e)
        {
            //SettingsHandler...
            Close();
        }

        void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
