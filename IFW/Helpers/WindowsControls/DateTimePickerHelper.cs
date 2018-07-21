using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Helpers.WindowsControls
{
    public class DateTimePickerHelper
    {
        public static string curFormat= "yyyy-MM-dd";
        public static void Init(ref DateTimePicker dtp)
        {
            ShowEmpty(ref dtp);
            dtp.CloseUp += Dtp_CloseUp;
        }

        private static void Dtp_CloseUp(object sender, EventArgs e)
        {
            (sender as DateTimePicker).CustomFormat = DateTimePickerHelper.curFormat;

        }

        public static void ShowEmpty(ref DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";
        }

        public static void ShowNormalDate(ref DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = curFormat;
        }

    }
}
