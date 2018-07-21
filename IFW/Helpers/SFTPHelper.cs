
using System.Collections;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class SFTPHelper
    {
        /// <summary>
        /// List a remote directory in the console.
        /// </summary>
        public static IEnumerable<SftpFile> ListFiles(string host,string username,string password,string remotedir)
        {           
            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    
                    sftp.Connect();
                    var files = sftp.ListDirectory(remotedir);
                    
                    sftp.Disconnect();
                    return files;
                }
                catch (Exception e)
                {
                    return null;
                   // Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }
        public static ArrayList FileUploadUsingSftp(string SFTPAddress, string SFTPUserName,
            string SFTPPassword,  string SFTPFilePath, string FileName)
        {
            var client = new SftpClient(SFTPAddress, 22, SFTPUserName, SFTPPassword);
            client.Connect();
            if (client.IsConnected)
            {
                FileInfo f = new FileInfo(FileName);
                string uploadfile = f.FullName;
                var fileStream = new FileStream(uploadfile, FileMode.Open);
                if (fileStream != null)
                {
                    //If you have a folder located at sftp://ftp.example.com/share
                    //then you can add this like:
                    client.UploadFile(fileStream, SFTPFilePath + f.Name, null);
                    client.Disconnect();
                    client.Dispose();
                }
            }
            return null;
        }

        public static void UploadSFTPFile(string host, string username,
         string password, string sourcefile, string destinationpath, int port)
        {
            using (SftpClient client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                client.ChangeDirectory(destinationpath);
                using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                {
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fs, Path.GetFileName(sourcefile));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="remotedir"></param>
        /// <param name="fileName">Includes path</param>
        public static void DownloadRemoteFile(string host, string username, string password, string remotedir, SftpFile file)
        {
           

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();
                    sftp.ChangeDirectory(remotedir);
                    DownloadFile(sftp, file,DirectoryHelper.GetSolutionPath()+ "EFiles\\");
                    sftp.Disconnect();
                    
                }
                catch (Exception e)
                {                  
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }

        public static void DownloadFile(SftpClient client, SftpFile file, string directory)
        {
           //Console.WriteLine("Downloading {0}", file.FullName);
            using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
            {
                client.DownloadFile(file.FullName, fileStream);
            }
        }


    }

}
