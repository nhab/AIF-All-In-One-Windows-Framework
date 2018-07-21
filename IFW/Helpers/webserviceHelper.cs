using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class webServiceHelper
    {
        public void read_webservice()
        {
            WebRequest request = WebRequest.Create("http://services.groupkt.com/country/get/all");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            string s1;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                s1 = sr.ReadToEnd();
            }

            Console.WriteLine(s1);
            Console.ReadLine();
        }
    }
}
