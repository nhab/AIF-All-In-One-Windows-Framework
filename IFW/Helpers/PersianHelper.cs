using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Helpers
{
    public class PersianHelper
    {
        public static string Convert_to_english_Format(string farsiDate)
        {
            string s = farsiDate.Replace("ب.ظ", "PM");
            s = s.Replace("ق.ظ", "AM");
            if (s.Length > 8)
                s = s.Substring(3, 2) + s.Substring(2, 1) + s.Substring(0, 2)  + s.Substring(5);
            return s;
        }
        public static DateTime ConvertToGeorgianDate(string jalaiDate)
        {
            PersianCalendar pc = new PersianCalendar();
            
            string jalali_Year = jalaiDate.Substring(0, 4);int y = int.Parse(jalali_Year);
            string jalali_mon = jalaiDate.Substring(5, 2); int m = int.Parse(jalali_mon);
            string jalali_day = jalaiDate.Substring(8, 2); int d = int.Parse(jalali_day);

            DateTime dt = new DateTime(y,m,d, pc);
            
            return dt;
        }
        public static  string ConvertToJalaliDate(DateTime thisDate)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(thisDate)+ "/" +pc.GetMonth(thisDate).ToString("D2") + "/" +
                          pc.GetDayOfMonth(thisDate).ToString("D2")    ;
        }
        public static string ConvertToJalaliDateTime(DateTime thisDate)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(thisDate) + "/" + pc.GetMonth(thisDate).ToString("D2") + "/" +
                          pc.GetDayOfMonth(thisDate).ToString("D2")+" "
                          +pc.GetHour(thisDate)+":"
                          +pc.GetMinute(thisDate)+":"
                          +pc.GetSecond(thisDate);
        }
        public static void Change_ListView_ToJalaliDate(ref ListView Listview1,string[] cols)
        {
            int len = Listview1.Items.Count;
            int dateColsCount = cols.Count();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < dateColsCount; j++)
                {
                    int colIndex = ListViewHelper.GetColIndex(Listview1, cols[j]);
                    string sGeorgianDate = Listview1.Items[i].SubItems[colIndex].Text;
                    DateTime dt = DateTime.Parse(sGeorgianDate);
                    Listview1.Items[i].SubItems[colIndex].Text = ConvertToJalaliDate(dt);
                }
            }
        }
        public static void Change_ListView_ToGeorgianDate(ref ListView Listview1, string[] cols, string georgianDateFormat = "yyyy-MM-dd HH:mm:ss,fff")
        {
            int len = Listview1.Items.Count;
            int dateColsCount = cols.Count();
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < dateColsCount; j++)
                {
                    int colIndex = ListViewHelper.GetColIndex(Listview1, cols[j]);
                    string sDate = Listview1.Items[i].SubItems[colIndex].Text;
                    Listview1.Items[i].SubItems[colIndex].Text = ConvertToGeorgianDate(sDate).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
    }
}
