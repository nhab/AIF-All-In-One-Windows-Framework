/* 
/ /  Copyright (C) 2003 Nithin Philips
/ /  Description: Arguments that are passed to listener of FileCopy Event
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

namespace csIOLib
{
	/// <summary>
	/// Arguments that are passed to listener of FileCopy Event
	/// </summary>
	public class FileCopyEventArgs : System.EventArgs
	{
		/// <summary>
		/// Creates a new immutable instance of FileCopyEventArgs
		/// </summary>
		/// <param name="sourceFile">Path to source file</param>
		/// <param name="targetFile">Path to target file</param>
		/// <param name="fileSize">Size of source file (in bytes)</param>
		/// <param name="totalBytes">Total number of bytes of all files</param>
		/// <param name="totalRemainingBytes">Number of bytes remaining from totalBytes</param>
		public FileCopyEventArgs(string sourceFile,string targetFile,long fileSize,long totalBytes,long totalRemainingBytes)
		{
			this.sourceFile = sourceFile;
			this.targetFile = targetFile;
			this.fileSize = fileSize;
			this.totalBytes = totalBytes;
			this.totalRemainingBytes = totalRemainingBytes;
		}

		// Information about the file
		private readonly string sourceFile;
		private readonly string targetFile;
		// Information about size of the file
		private readonly long fileSize;                             // Size of the file
		// Information about size of all files
		private readonly long totalBytes;                           // Total number of bytes to copy
		private readonly long totalRemainingBytes;                  // Total number of bytes pending
		
		/// <summary>
		/// Full path to source file
		/// </summary>
		public string SourceFile
		{
			get
			{
				return sourceFile;
			}
		}
		
		/// <summary>
		/// Full path to target file
		/// </summary>
		public string TargetFile
		{
			get
			{
				return targetFile;
			}
		}

		/// <summary>
		/// Total size of current file in bytes
		/// </summary>
		public long FileSize
		{
			get
			{
				return fileSize;
			}
		}

		/// <summary>
		/// Total number of bytes of all files
		/// </summary>
		public long TotalBytes
		{
			get
			{
				return totalBytes;
			}
		}

		/// <summary>
		/// Number of bytes pending to copy
		/// </summary>
		public long TotalRemainingBytes
		{
			get
			{
				return totalRemainingBytes;
			}
		}

		/// <summary>
		/// Calculates percentage done and returns it
		/// </summary>
		public int Percent
		{
			get
			{
				return Utilities.ShortPercent(this.TotalBytes, this.TotalBytes - this.TotalRemainingBytes);
			}
		}
	}
}
