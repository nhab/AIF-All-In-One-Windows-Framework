/* 
/ /  Copyright (C) 2003 Nithin Philips
/ /  Description: Arguments that are passed to listener of UnitCopy Event
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
	/// Arguments that are passed to listener of UnitCopy Event
	/// </summary>
	public class UnitCopyEventArgs : System.EventArgs
	{
		/// <summary>
		/// Creates a new immutable instance of UnitCopyEventArgs
		/// </summary>
		/// <param name="sourceFile">Path to source file</param>
		/// <param name="targetFile">Path to target file</param>
		/// <param name="fileSize">Size of source file (in bytes)</param>
		/// <param name="totalBytesCopied">Total number of bytes copied from beginning</param>
		/// <param name="bytesCopied">Number of bytes copied during this session (usually = unit)</param>
		public UnitCopyEventArgs(string sourceFile,string targetFile,long fileSize,long totalBytesCopied,long bytesCopied)
		{
			this.sourceFile = sourceFile;
			this.targetFile = targetFile;
			this.fileSize = fileSize;
			this.totalBytesCopied = totalBytesCopied;
			this.bytesCopied = bytesCopied;
		}

		// Information about the file
		private readonly string sourceFile;
		private readonly string targetFile;
		// Size Information
		private readonly long fileSize;               // Size of the file
		private readonly long totalBytesCopied;       // Accumulated number of bytes copied
		private readonly long bytesCopied;            // Bytes copied during current pass

		/// <summary>
		/// Full path to source file
		/// </summary>
		public string SourceFile{
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
		/// Total size of file in bytes
		/// </summary>
		public long FileSize
		{
			get
			{
				return fileSize;
			}
		}

		/// <summary>
		/// Total number of bytes copied (Accumulated)
		/// </summary>
		public long TotalBytesCopied
		{
			get
			{
				return totalBytesCopied;
			}
		}

		/// <summary>
		/// The number of bytes copied during current session
		/// </summary>
		public long BytesCopied
		{
			get
			{
				return bytesCopied;
			}
		}

		/// <summary>
		/// Calculates percentage done and returns it
		/// </summary>
		public int Percent
		{
			get
			{
				return Utilities.ShortPercent(this.FileSize, this.TotalBytesCopied);
			}
		}
	}
}
