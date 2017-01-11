#if OFFICE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

using WordApp = Microsoft.Office.Interop.Word.Application;
using ExcelApp = Microsoft.Office.Interop.Excel.Application;

namespace FuckingClippy
{
    static class OfficeHelper
    {
        static WordApp WordInstance;
        static ExcelApp ExcelInstance;

        /// <summary>
        /// Initiates the excel and word apps.
        /// </summary>
        /// <remarks>
        /// Takes around a second for both to start.
        /// </remarks>
        public static void Initialize()
        {
            WordInstance = new WordApp();
            ExcelInstance = new ExcelApp();

            ExcelInstance.ActivateMicrosoftApp(XlMSApplication.xlMicrosoftWord);

            Thread.Sleep(3000);

            WordInstance.Windows[0].ActivePane
                .Application.ActiveDocument.Paragraphs.Add("penis");
#if DEBUG
            //Character.Say("Column: " +                 ExcelInstance.ActiveCell.Column);
#endif
        }
    }
}
#endif