using System.Globalization;
using System.Resources;
using static System.Threading.Thread;

namespace FuckingClippy
{
    partial class MainForm
    {
        /// <summary>
        /// Culture (locale) manager.
        /// </summary>
        ResourceManager RM;

        void InitiateCulture()
        {
            ChangeCulture(CurrentThread.CurrentCulture);
        }

        void ChangeCulture(CultureInfo ci)
        {
            ChangeCulture(ci.Name);
        }

        void ChangeCulture(string language)
        {
            Utils.Log($"ChangeCulture - {language}");

            switch (language)
            {
                case "fr-FR":
                case "fr-CA":
                    RM = new ResourceManager(
                        $"{Utils.ProjectName}.Culture.fr-FR",
                        Utils.Project
                    );
                    break;
                    
                default: // English
                    RM = new ResourceManager(
                        $"{Utils.ProjectName}.Culture.en-US",
                        Utils.Project
                    );
                    break;
            }
        }
    }
}
