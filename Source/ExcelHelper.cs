#if OFFICE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            ExcelInstance.ActivateMicrosoftApp(XlMSApplication.xlMicrosoftWord);

            //Character.Say("Column: " +                 ExcelInstance.ActiveCell.Column);
        }
    }
}
#endif