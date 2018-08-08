/* 
/ /  Copyright (C) 2003 Nithin Philips
/ /  Description: Provides additional functions to operate on directories
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

	/// <summary>
	/// Provides methods to operate on directories.
	/// </summary>
	public class Directory
	{
		/// <summary>
		/// An instance of this class is not available. Use the static methods instead.
		/// </summary>
		private Directory()
		{
		}

		/// <summary>
		/// Returns an array of all directories in the given path
		/// </summary>
		/// <param name="path">A path you want to parse</param>
		/// <returns>An array of all directories in the given path</returns>
		public static string[] ParseDirectories(string path)
		{
			string delim = @"\";  // Path Seperator

			if (path != null)
			{
				if (path.EndsWith(delim) == true)
				{
					// Trauncate delim from end
					path = path.Remove(path.Length-1,1);
				}

				string[] m_directories = path.Split(delim.ToCharArray());
				string[] directories = new string[m_directories.Length];
				
				for(int i = 0;i <= m_directories.Length -1;i++)
				{
					if (i > 0 )
					{
						// Append last item + insert current path + insert delim
						directories[i] = directories[i - 1] +  m_directories[i] + delim;
					}
					else
					{
						// The first item in the array
						directories[i] = m_directories[i] + delim;
					}
				}
				m_directories = null;
				return directories;
			}
			else
			{
				throw new ArgumentException("The argument 'path' cannot be null","path");
			}
		} // getDirectories

		/// <summary>
		/// Recursively scans the given path and returns an array of all sub directories.Do not call this function directly, call the wrapper function instead.
		/// </summary>
		/// <param name="folder">The folder you want to scan</param>
		/// <param name="list">The list which will be populated. It must be pre-Initialized</param>
		/// <param name="resumeOnError">Indicates whether to throw exceptions on error or to continue scanning when an error is encountered</param>
		private static void EnumerateFolders(ref System.IO.DirectoryInfo folder, ref ArrayList list,ref bool resumeOnError)
		{
			list.Add(folder); // add folder to the list
			try
			{
				// scan sub folders
				DirectoryInfo[] subDirectories = folder.GetDirectories(); 
				for (int i = 0;i <= (subDirectories.Length - 1); i++)
				{
					EnumerateFolders(ref subDirectories[i], ref list,ref resumeOnError );
				}
			}
			catch (UnauthorizedAccessException AcsEx)
			{
				if (resumeOnError == true)
				{
					return;
				}
				else
				{
					Console.WriteLine("Error Was Rethrown");
					// re throw the exception
					throw AcsEx;
				}
			}
		}
		
		/// <summary>
		/// Recursively scans the given path and returns an array of all sub directories
		/// </summary>
		/// <param name="folder">The folder you want to scan</param>
		/// <param name="resumeOnError">Indicates whether to throw exceptions on error or to continue scanning when an error is encountered</param>
		/// <returns>An array of all sub directories</returns>
		public static DirectoryInfo[] EnumerateFolders(string folder, bool resumeOnError)
		{
			DirectoryInfo directory = new DirectoryInfo(folder);
			ArrayList list = new ArrayList();
			// call recursive function
			EnumerateFolders(ref directory,ref list, ref resumeOnError);
			// convert to array and return it
			return (DirectoryInfo[])list.ToArray(typeof(DirectoryInfo));
		}

		/// <summary>
		/// Creates a Folder
		/// </summary>
		/// <param name="path">The path to the folder you want to create</param>
		public static void CreateFolder(string path)
		{
			DirectoryInfo folder = new DirectoryInfo(path);
			folder.Create();
		}

		/// <summary>
		/// Copies source directory structure to target directory structure
		/// </summary>
		/// <param name="source">Folder you want to copy from</param>
		/// <param name="target">Folder you want to copy to</param>
		public static void CopyFolders(string source, string target){
			// get a list of source folders
			DirectoryInfo[] list = EnumerateFolders(source,true);
			foreach (DirectoryInfo folder in list){
				CreateFolder(folder.FullName.Replace(source,target));
			}
		}
		
		/// <summary>
		/// Copies source directory structure to target directory structure
		/// </summary>
		/// <param name="source">Folder you want to copy from</param>
		/// <param name="target">Folder you want to copy to</param>
		/// <param name="list">An array of DirectoryInfo objects</param>
		public static void CopyFolders(string source, string target,DirectoryInfo[] list)
		{
			foreach (DirectoryInfo folder in list)
			{
				CreateFolder(folder.FullName.Replace(source,target));
			}
		}
	}
}
