using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class DateTimeHelper
    {
        public static string get10charStringMMDDYYYY(DateTime dt)
        {
            return dt.Month.ToString().PadLeft(2,'0') + "\\" + dt.Day.ToString().PadLeft(2,'0') +"\\"+ dt.Year.ToString().PadLeft(4,'0');
        }
        public static string get8charStringMMDDYYYY(DateTime dt)
        {
            return dt.Month.ToString().PadLeft(2,'0')  + dt.Day.ToString().PadLeft(2,'0')  + dt.Year.ToString().PadLeft(4,'0');
        }
        public static string get8charStringYYYYMMDD(DateTime dt)
        {
            return dt.Year.ToString().PadLeft(4, '0')+dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0') ;
        }
        public static string changeTo_YYYYMMDD(string sMMDDYYYY)
        {
            string sYear = sMMDDYYYY.Substring( 4, 4);
            string sMon = sMMDDYYYY.Substring(2, 2);
            string sDay = sMMDDYYYY.Substring(0, 2);
            return sYear + sMon + sDay;
        }
        public static long GetLongDate(DateTime dt)
        {
            string s = get8charStringYYYYMMDD(dt);
            long i = long.Parse(s);
            return i;
        }
        public static string get14charStringYYYYMMDD(string  sMMDDYYYY_HHMMSS,char seperator='/')
        {
            if (sMMDDYYYY_HHMMSS == "") return "";
            string sTime = sMMDDYYYY_HHMMSS.Substring(9).Trim().Replace(":", "");
            if (sTime.Substring(sTime.Length - 2) == "AM")
                sTime = sTime.Substring(0, sTime.Length - 2);
            else
                sTime = (int.Parse(sTime.Substring(0, 2)) + 12).ToString() + sTime.Substring(2, sTime.Length - 4);
            int i = sMMDDYYYY_HHMMSS.IndexOf(seperator);
            string sMon= sMMDDYYYY_HHMMSS.Substring(0, i).PadLeft(2,'0');
            string sDay = sMMDDYYYY_HHMMSS.Substring(i+1, sMMDDYYYY_HHMMSS.IndexOf(seperator, 2)-i-1 ).PadLeft(2, '0');
            i = sMMDDYYYY_HHMMSS.IndexOf(seperator, 2);
            string sYear = sMMDDYYYY_HHMMSS.Substring(i+1, 4).PadLeft(4, '0');
            return sMon+sDay+sYear+ sTime;
        }
        public static string ChangeTimeTo24Formant(string sTime)
        {
            if (sTime.Substring(sTime.Length - 2).ToUpper() == "AM")
                sTime = sTime.Substring(0, sTime.Length - 2);
            else
            {
                if (sTime.Substring(sTime.Length - 2).ToUpper() == "PM")
                    sTime = (int.Parse(sTime.Substring(0, sTime.IndexOf(":"))) + 12).ToString() + sTime.Substring(2, sTime.Length - 4);
            }
            return sTime;
        }
        public static string get12charStringYYYYMMDD(string sMMDDYYYYHHMM, char seperator = '/')
        {
            string sTime = sMMDDYYYYHHMM.Substring(9).Trim().Replace(":", "");
            if (sTime.Substring(sTime.Length - 2) == "AM")
                sTime = sTime.Substring(0, sTime.Length - 2);
            else
            {
                if (sTime.Substring(sTime.Length - 2) == "PM")
                    sTime = (int.Parse(sTime.Substring(0, 2)) + 12).ToString() + sTime.Substring(2, sTime.Length - 4);
            }
            int i = sMMDDYYYYHHMM.IndexOf(seperator);
            string sMon = sMMDDYYYYHHMM.Substring(0, i).PadLeft(2, '0');
            string sDay = sMMDDYYYYHHMM.Substring(i + 1, sMMDDYYYYHHMM.IndexOf(seperator, 2) - i - 1).PadLeft(2, '0');
            i = sMMDDYYYYHHMM.IndexOf(seperator, 2);
            string sYear = sMMDDYYYYHHMM.Substring(i + 1, 4).PadLeft(4, '0');
            return sYear + sMon + sDay + sTime.Trim().PadLeft(6,'0').Substring(0,4);
        }
        public static string get12charStringYYYYMMDD2(string sDDMMYYYYHHMM, char seperator = '/')
        {
            string sTime = sDDMMYYYYHHMM.Substring(9).Trim().Replace(":", "");
            if (sTime.Substring(sTime.Length - 2) == "AM")
                sTime = sTime.Substring(0, sTime.Length - 2);
            else
            {
                if (sTime.Substring(sTime.Length - 2) == "PM")
                    sTime = (int.Parse(sTime.Substring(0, 2)) + 12).ToString() + sTime.Substring(2, sTime.Length - 4);
            }
            int i = sDDMMYYYYHHMM.IndexOf(seperator);
            string sDay = sDDMMYYYYHHMM.Substring(0, i).PadLeft(2, '0');
            string sMon = sDDMMYYYYHHMM.Substring(i + 1, sDDMMYYYYHHMM.IndexOf(seperator,i+1) - i - 1).PadLeft(2, '0');
            i = sDDMMYYYYHHMM.IndexOf(seperator , i + 1);
            string sYear = sDDMMYYYYHHMM.Substring(i + 1, 4).PadLeft(4, '0');
            return sYear + sMon + sDay;// + sTime.Trim().PadLeft(6, '0').Substring(0, 4);
        }
    }
}
