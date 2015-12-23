using System;
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

        void ChangeCulture(CultureInfo pLanguage)
        {
            ChangeCulture(pLanguage.Name);
        }

        void ChangeCulture(string pLanguage)
        {
            Console.WriteLine($"CLR: ChangeCulture({pLanguage})");

            switch (pLanguage)
            {
                case "en-EdgyMemer":

                    break;

                case "fr-FR":
                case "fr-CA":
                    RM = new ResourceManager("FuckingClippy.Culture.fr-FR",
                             Utils.ExecutingAssembly);
                    break;
                    
                // English
                default:
                    RM = new ResourceManager("FuckingClippy.Culture.en-US",
                             Utils.ExecutingAssembly);
                    break;
            }
        }
    }
}
