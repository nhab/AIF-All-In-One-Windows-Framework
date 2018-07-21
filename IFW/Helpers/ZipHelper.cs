
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class ZipHelper
    {
        public static void Test()
        {

            string start_Path = @"c:\example\start";
            string zip_Path = @"c:\example\result.zip";
            ZipFile.CreateFromDirectory(start_Path, zip_Path);

            string extract_Path = @"c:\example\extract";
            ZipFile.ExtractToDirectory(zip_Path, extract_Path);
        }
        public static void Zip(string filesToZipPath, string zipFile)
        {
            ZipFile.CreateFromDirectory(filesToZipPath, zipFile);

        }
    
        public static byte[] Decompress1File(byte[] gzip)
        {
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
                CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }


        public static void Decompress(string FileNameOnly, string sourcePath, string destinationPath)
        {
            try
            {
                string s7zip = DirectoryHelper.GetSolutionPath();
                s7zip += "7z\\7za.exe";

                string args = " x " + FileNameOnly;// +".tgz";
                if (destinationPath != "")
                    args += " -o" + destinationPath;
                string s1 = s7zip + args;
                CmdHelper.runCmd(s1);

                args = " x " +  FileNameOnly.Substring(0,FileNameOnly.Length-4)+ ".tar";
                if (destinationPath != "")
                    args += " -o" + destinationPath;


                CmdHelper.runCmd(s7zip + args);

                
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
 }

