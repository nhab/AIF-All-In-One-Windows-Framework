using System;
using System.DirectoryServices;


namespace IFramework.Controller
{
    public class ActiveDirectoryUserManagement
    {

         private static String _path;
        //private static String _filterAttribute;
        public static bool IsAuthenticated(String domain, String username, String pwd)
        {
            String domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);

            try
            {//Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }


                // _path = result.Path;
                //  _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                return false;
                // throw new Exception("Error authenticating user. " + ex.Message);
            }

            return true;
        }
        public static string  getCurrentUser()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name; 
        }
        public static string getCurUserWithoutDomainName()
        {
            string s = getCurrentUser();
            s=s.Substring(s.IndexOf("\\")+1);
            return s;
        }
    }
}
