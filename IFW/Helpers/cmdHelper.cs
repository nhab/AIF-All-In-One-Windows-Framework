using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class CmdHelper
    {
     
        public static void runCmd(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C "+command;
            process.StartInfo = startInfo;
            process.Start();
        }

        public static void Run_Default_Program(string filename)
        {
            System.Diagnostics.Process.Start(filename);
        }
    }
}
