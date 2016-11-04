using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;

using WordApp = Microsoft.Office.Interop.Word.Application;
using ExcelApp = Microsoft.Office.Interop.Excel.Application;

namespace FuckingClippy
{
    static class OfficeHelper
    {
        static WordApp WordApp;
        static ExcelApp ExcelApp;

        /// <summary>
        /// Initiates the excel and word apps.
        /// </summary>
        /// <remarks>
        /// Takes around a second for both to start.
        /// </remarks>
        public static void Initialize()
        {
            WordApp = new WordApp();
            ExcelApp = new ExcelApp();
        }
    }
}
