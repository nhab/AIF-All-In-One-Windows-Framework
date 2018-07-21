using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public static class StringHelper
    {
        public static string RemoveSpaces(string s)
        {
            return s.Replace(" ", "");
        }

        public static string Repeat(int n, char c)
        {
            return new String(c, n);
        }
        public static string Right(string s, int n)
        {
            return s.Substring(s.Length - n, n);
        }
        public static string Format_To_A_Fixed_Length(string s,int n,char c=' ')
        {
            int len = s.Length;
            if (n <= len) return s;
            for (int i = len; i < n; i++)
                s += c;
            return s;
        }
    }
}
