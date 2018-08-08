/* 
/ /  Copyright (C) 2003 Nithin Philips
/ /  Description: Provides additional functions to operate on files
/ /  Platform: All platforms supported by .NET framework (1.1)
/ / 
/ /  This program is free software; you can redistribute it and/or modify
/ /  it under the terms of the GNU General Public License version 2 as 
/ /  published by the Free Software Foundation.
/ /
/ /  This program is distributed in the hope that it will be useful,
/ /  but WITHOUT ANY WARRANTY; without even the implied warranty of
/ /  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/ /  GNU General Public License for more details.
/ /
/ /  You should have received a copy of the GNU General Public License
/ /  along with this program; if not, write to the Free Software
/ /  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
/ /
/*/

using System;
using System.IO;
using System.Collections;

namespace csIOLib
{
	
	#region Delegates

	// Delegates
	/// <summary>
	/// Delegate for BeforeFileCopyEvent
	/// </summary>
	public delegate void BeforeFileCopyEventHandler(object sender, FileCopyEventArgs e);
	/// <summary>
	/// Delegate for AfterFileCopy
	/// </summary>
	public delegate void AfterFileCopyEventHandler(object sender, FileCopyEventArgs e);
	/// <summary>
	/// Delegate for UnitCopyEvent
	/// </summary>
	public delegate void UnitCopyEventHandler(object sender, UnitCopyEventArgs e);
	/// <summary>
	/// Delegate for AfterStopEvent
	/// </summary>
	public delegate void AfterStopEventHandler(object sender);

	#endregion

	/// <summary>
	/// Provides methods to operate on files
	/// </summary>
	public class File
	{
		#region Constructors

		/// <summary>
		/// Creates a new instance of File Class
		/// </summary>
		public File()
		{
		}
		#endregion

		#region Constants
		
		private const string pathSeperator = @"\";

		#endregion

		#region Shared Functions

		/// <summary>
		/// Gets files from a directory using a pattern and adds them to referenced arraylist
		/// </summary>
		/// <param name="dirInfo">Directory to query</param>
		/// <param name="list">Arraylist to add results</param>
		/// <param name="pattern">Pattern to use for file lookup</param>
		private static void GetFiles(DirectoryInfo dirInfo, ref ArrayList list, string pattern)
		{
			try{
				FileInfo[] files = dirInfo.GetFiles(pattern); // Get File List
				foreach (FileInfo file in files){
					list.Add(file);                           // Add to arraylist
				}
			}catch(System.UnauthorizedAccessException){
				return;
			}
		}

		/// <summary>
		/// Scans a folder and returns an array of files
		/// </summary>
		/// <param name="path">The folder you want to scan</param>
		/// <param name="recurse">Set to true if you want to scan subfolders else false</param>
		/// <param name="pattern">The patten of files you want to search for</param>
		/// <returns>An array of files</returns>
		public static FileInfo[] EnumerateFiles(string path, bool recurse, string pattern)
		{
			if (pattern == string.Empty)pattern = "*.*";
			if (recurse == true) 
			{
				ArrayList fileList = new ArrayList();
				// get a list of folders
				DirectoryInfo[] list = Directory.EnumerateFolders(path,true);
				for (int i = 0;i <= list.Length -1;i++){
					GetFiles(list[i], ref fileList, pattern);
				}
				return (FileInfo[])fileList.ToArray(typeof(FileInfo));
			}
			else 
			{
				DirectoryInfo directory = new DirectoryInfo(path);
				return directory.GetFiles();
			}
		}

		/// <summary>
		/// Scans a folder and returns an array of files
		/// </summary>
		/// <param name="path">The folder you want to scan</param>
		/// <param name="recurse">Set to true if you want to scan subfolders else false</param>
		/// <returns>An array of files</returns>
		public static FileInfo[] EnumerateFiles(string path, bool recurse)
		{
			return EnumerateFiles(path,recurse,"");
		}

		/// <summary>
		/// Scans a folder and returns an array of files
		/// </summary>
		/// <param name="path">The folder you want to scan</param>
		/// <returns>An array of files</returns>
		public static FileInfo[] EnumerateFiles(string path)
		{
			return EnumerateFiles(path,false,"");
		}

		/// <summary>
		/// Scans specified folders and returns an array of files
		/// </summary>
		/// <param name="directories">An array of folders to scan</param>
		/// <returns>An array of files</returns>
		public static FileInfo[] EnumerateFiles(DirectoryInfo[] directories)
		{
			ArrayList fileList = new ArrayList();
			// get a list of folders

			for (int i = 0;i <= directories.Length -1;i++)
			{
				FileInfo[] files = directories[i].GetFiles();
				foreach (FileInfo file in files)
				{
					fileList.Add(file);
				}
			}
			return (FileInfo[])fileList.ToArray(typeof(FileInfo));
		}

		/// <summary>
		/// Compares two files
		/// </summary>
		/// <param name="file1">The first file</param>
		/// <param name="file2">The second file</param>
		/// <returns>Status of the first file</returns>
		public static FileStatus CompareFiles(string file1,string file2)
		{
			FileInfo obFile1 = new FileInfo(file1);
			FileInfo obFile2 = new FileInfo(file2);
			return CompareFiles(obFile1,obFile2);
		}

		/// <summary>
		/// Compares two files
		/// </summary>
		/// <param name="file1">The first file</param>
		/// <param name="file2">The second file</param>
		/// <returns>Status of the first file</returns>
		public static FileStatus CompareFiles(FileInfo file1, FileInfo file2)
		{
			int lastWrite = int.Parse(DateTime.Compare(file1.LastWriteTime,file2.LastWriteTime).ToString());
			if (lastWrite < 0)
			{
				return FileStatus.Old;
			}
			else if (lastWrite == 0) 
			{
				return FileStatus.Same;
			}
			else if (lastWrite > 0) 
			{
				return FileStatus.New;
			}
			else
			{
				throw new InvalidOperationException("Evaluation returned an invalid value");
			}
		}

		/// <summary>
		/// Parses a file path string and returns the file's name section.
		/// </summary>
		/// <param name="filePath">Full path to the file</param>
		/// <returns>Name of the file</returns>
		public static string GetFileName(string filePath)
		{
			return filePath.Substring(filePath.LastIndexOf(pathSeperator) + 1);
		}

		/// <summary>
		/// Parses a file path string and returns the file's parent directory section.
		/// </summary>
		/// <param name="filePath">Full path to the file</param>
		/// <returns>Parent directory of the file</returns>
		public static string GetFileParent(string filePath)
		{
			return filePath.Substring(0, filePath.LastIndexOf(pathSeperator));
		}

		/// <summary>
		/// Status of files
		/// </summary>
		public enum FileStatus{
			/// <summary>Represents a new file</summary>
			New, 
			/// <summary>Represents an old file</summary>
			Old, 
			/// <summary>Represent similar files</summary>
			Same
		};

		#endregion

		#region Events and EventRaisers

		// Events
		/// <summary>
		/// Event that is raised by CopyFolder method before a file is copied
		/// </summary>
		public event BeforeFileCopyEventHandler BeforeFileCopy;
		/// <summary>
		/// Event that is raised by CopyFolder method after a file is copied
		/// </summary>
		public event AfterFileCopyEventHandler  AfterFileCopy;
		/// <summary>
		/// Event that is raised by Copy method when a unit is copied
		/// </summary>
		public event UnitCopyEventHandler UnitCopy;
		/// <summary>
		/// Event that is raised by Copy method after process is successfully stopped by Stop method
		/// </summary>
		public event AfterStopEventHandler AfterStop;

		/// <summary>
		/// Raises BeforeFileCopy Event
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnBeforeFileCopy(FileCopyEventArgs e)
		{
			if (BeforeFileCopy != null){
				BeforeFileCopy(this, e);
			}
		}

		/// <summary>
		/// Raises AfterFileCopy Event
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnAfterFileCopy(FileCopyEventArgs e)
		{
			if (AfterFileCopy != null){
				AfterFileCopy(this, e);
			}
		}

		/// <summary>
		/// Raises UnitCopy Event
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnUnitCopy(UnitCopyEventArgs e)
		{
			if (UnitCopy != null){
				UnitCopy(this, e);
			}
		}

		/// <summary>
		/// Raises AfterStop Event
		/// </summary>
		protected virtual void OnAfterStop()
		{
			if (AfterStop != null){
				AfterStop(this);
			}
		}

		#endregion

		#region Functions
		
		/* Note: If file this class is used in a different thread, 
		 * and when user wants to cancel the process call stop method
		 * then wait for AfterStop event to raise before killing the thread. 
		 */

		/// <summary>
		/// Specifies whether to stop copying process
		/// </summary>
		bool m_resume = true;
		
		/// <summary>
		/// Stops copying and deletes the partly copied file
		/// </summary>
		public void Stop()
		{
			m_resume = false;
		}

		#endregion

		#region File Copying

		/// <summary>
		/// Copies a file in units
		/// </summary>
		/// <param name="source">Source File</param>
		/// <param name="target">Target File</param>
		/// <param name="unit">Number of bytes that is copied at once. Reverted to 2^20 if 0</param>
		/// <param name="overwriteTarget">Specifies whether the target file is over writen is it already exists otherwise an exception is thrown</param>
		public void Copy(string source, string target, int unit, bool overwriteTarget)
		{
			// Create target folder in case it doesent't exist
			Directory.CreateFolder(GetFileParent(target));

			// set defaults
			if (unit == 0){
				unit = (int)Math.Pow(2, 20); // 1 MB
			}
			
			FileMode targetMode; 
			if (overwriteTarget){
				targetMode = FileMode.Create;				
			}else{
				targetMode = FileMode.CreateNew;
			}

			// Streams
			FileStream sourceStream   = new FileStream(source,FileMode.Open,FileAccess.Read,FileShare.Read);
			FileStream targetStream   = new FileStream(target,targetMode,FileAccess.Write,FileShare.None);
			BinaryReader sourceReader = new BinaryReader(sourceStream);
			BinaryWriter targetWriter = new BinaryWriter(targetStream);
			
			// Counters
			int loopCount = (int)(sourceStream.Length / unit);
			long bytesleft = sourceStream.Length;
			if(bytesleft <= unit) unit = (int)bytesleft;

			// Copier Loop
			for(int i = 0; i <= loopCount; i++)
			{					
				targetWriter.Write(sourceReader.ReadBytes(unit));  // Perform Copying
				
				// Call Event Raiser
				UnitCopyEventArgs e = new UnitCopyEventArgs(source, target, sourceStream.Length, sourceStream.Length - bytesleft, unit);
				this.OnUnitCopy(e);
			
				bytesleft -= unit;
				if(bytesleft <= unit) unit = (int)bytesleft;
				
				// Check for stop
				if (m_resume == false){
					// Close Streams
					sourceReader.Close();
					targetWriter.Close();
					sourceStream.Close();
					targetStream.Close();
					// delete current file
					System.IO.File.Delete(target);
					// Call Event Raiser
					this.OnAfterStop();
					// exit loop
					break;					
				}
			}

			// Close Streams
			sourceReader.Close();
			targetWriter.Close();
			sourceStream.Close();
			targetStream.Close();
		}

		/// <summary>
		/// Copies a folder
		/// </summary>
		/// <param name="sourceFolder">The folder you want to copy</param>
		/// <param name="targetFolder">The folder where the contents of sourcefolder will be copied to</param>
		/// <param name="unit">Number of bytes that is copied at once. Reverted to 2^20 if 0</param>
		/// <param name="overwriteTarget">Specifies whether the target file is over writen is it already exists otherwise an exception is thrown</param>
		/// <param name="recurse">Specify whether to recursively copy all subdirectories of sourcefolder</param>
		public void CopyFolder(string sourceFolder, string targetFolder, int unit, bool overwriteTarget, bool recurse)
		{
			CopyFiles(EnumerateFiles(sourceFolder,recurse),sourceFolder,targetFolder,unit,overwriteTarget);
		}

		/// <summary>
		/// Copies files in an array to target folder
		/// </summary>
		/// <param name="sourceFiles">An array of files to copy</param>
		/// <param name="sourceFolder">Source folder (see documentation)</param>
		/// <param name="targetFolder">Target Folder (see documentation)</param>
		/// <param name="unit">Number of bytes that is copied at once. Reverted to 2^20 if 0</param>
		/// <param name="overwriteTarget">Specifies whether the target file is over writen is it already exists otherwise an exception is thrown</param>
		private void CopyFiles(FileInfo[] sourceFiles, string sourceFolder, string targetFolder, int unit, bool overwriteTarget)
		{
			long totalBytes = 0;
			long remainingBytes = 0;
			// get totals
			foreach (FileInfo file in sourceFiles){
				totalBytes += file.Length;
			}
			remainingBytes = totalBytes;

			string sourceFile;
			string targetFile;

			foreach(FileInfo file in sourceFiles){
				// 
				sourceFile = file.FullName;
				targetFile = file.FullName.Replace(sourceFolder,targetFolder);

				FileCopyEventArgs before = new FileCopyEventArgs(sourceFile,targetFile,file.Length,totalBytes,remainingBytes);
				OnBeforeFileCopy(before);

				Copy(sourceFile,targetFile,unit,overwriteTarget);
				remainingBytes -= file.Length;

				FileCopyEventArgs after = new FileCopyEventArgs(sourceFile,targetFile,file.Length,totalBytes,remainingBytes);
				this.OnAfterFileCopy(after);
			}
		}

		#endregion

	}
}

