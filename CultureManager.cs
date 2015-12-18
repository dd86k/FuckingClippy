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

        void ChangeCulture()
        {
            CultureInfo ci = CurrentThread.CurrentCulture;
            ChangeCulture(ci);
        }

        void ChangeCulture(CultureInfo pLanguage)
        {
            ChangeCulture(pLanguage.Name);
        }

        void ChangeCulture(string pLanguage)
        {
            switch (pLanguage)
            {
                case "en-EdgyMemer":

                    break;

                case "fr-FR":
                case "fr-CA":
                    RM = new ResourceManager("FuckingClippy.Culture.fr-FR",
                             ExecutingAssembly);
                    break;

                case "en":
                case "en-US":
                case "en-UK":
                default:
                    RM = new ResourceManager("FuckingClippy.Culture.en-US",
                             ExecutingAssembly);
                    break;
            }

            /* This is where our translations goes into controls */
            // ===== Context Menu =====
            
        }
    }
}
