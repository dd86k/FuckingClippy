#if OFFICE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;

using WordApp = Microsoft.Office.Interop.Word.Application;

namespace FuckingClippy
{
    static class WordHelper
    {
        static WordApp WordInstance;

        /// <summary>
        /// Initiates the excel and word apps.
        /// </summary>
        public static void Initialize()
        {
            WordInstance = new WordApp();
        }

        public static void Test()
        {
            WordInstance.Activate(); // Fails
        }
    }
}
#endif