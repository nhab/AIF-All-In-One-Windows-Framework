using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class CredentialFileHelper
    {
        private static string getFilePath()
        {
            string p = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = Path.GetDirectoryName(p) + "\\u.dll";
            return path;
        }
        public static void  LoadFromFile(out string user, out string pass)
        {

            string path = getFilePath();
            IEnumerable<string> s = File.ReadLines(path);
           user = s.ToArray<string>()[0];
           pass= s.ToArray<string>()[1];
           
        }
        public static void SaveCredentials(string user,string pass)
        {
            string path = getFilePath();
            string s = user + "\r\n" + pass;

            File.WriteAllText(path, s);
        }
        public static void GetCredentialsFromFile(out string uname,out string pass ,out string domain)
        {
            string path = getFilePath();
            string[] lines = File.ReadAllLines (path);
            
            uname = lines[0];
            pass = lines[1];
            domain = "IKAP";
        }
    }
}
