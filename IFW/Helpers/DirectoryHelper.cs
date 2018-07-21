
using System.IO;

namespace IFramework.Helpers
{
    public class DirectoryHelper
    {
        public static string[] GetFileNames(string path)
        {
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.GetLength(0); i++)
            {
                var sections = files[i].Split('\\');
                files[i] = sections[sections.Length - 1];
            }
            return files;
        }


        public static string GetSolutionPath()
        {
            //string startupPath = Environment.CurrentDirectory;
            return System.IO.Directory.GetCurrentDirectory()+"\\";           
        }
        public static void DeleteFiles(string directoryname)
        {
            CmdHelper.runCmd("del /q " + directoryname);
        }
    }

}
