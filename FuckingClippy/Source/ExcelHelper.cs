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

using ExcelApp = Microsoft.Office.Interop.Excel.Application;

namespace FuckingClippy
{
    static class ExcelHelper
    {
        static ExcelApp ExcelInstance;

        public static void Initialize()
        {
            ExcelInstance = new ExcelApp();
        }

        public static void Test()
        {
            //ExcelInstance.ActivateMicrosoftApp(XlMSApplication.xlMicrosoftWord);

            ExcelInstance.Application.SheetChange += ExcelInstance_SheetChange;

            //Character.Say("Column: "+ExcelInstance.Assistant.);
        }

        private static void ExcelInstance_SheetChange(object Sh, Range Target)
        {
            Character.Say("Change!");
        }
    }
}
#endif