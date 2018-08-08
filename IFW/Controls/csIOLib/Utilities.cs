/* 
/ /  Copyright (C) 2003 Nithin Philips
/ /  Description: Miscellaneous functions to support csIOLib
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
	/// Miscellaneous functions to support csIOLib
	/// </summary>
	public class Utilities
	{
		/// <summary>
		/// An instance is not available. Use static methods instead.
		/// </summary>
		private Utilities()
		{
		}

		/// <summary>
		/// Calculates percentage
		/// </summary>
		/// <param name="total">Total value</param>
		/// <param name="value">Current value</param>
		/// <returns>Percentage</returns>
		public static int ShortPercent(long total, long value)
		{
			return (int)((100D / total) * value);
		}
		
		/// <summary>
		/// Calculates percentage
		/// </summary>
		/// <param name="total">Total value</param>
		/// <param name="value">Current value</param>
		/// <returns>Percentage</returns>
		public static int ShortPercent(int total, int value)
		{
			return (int)((100D / total) * value);
		}

		/// <summary>
		/// Calculates percentage
		/// </summary>
		/// <param name="total">Total value</param>
		/// <param name="value">Current value</param>
		/// <returns>Percentage</returns>
		public static double LongPercent(long total, long value)
		{
			return (100D / total) * value;
		}

		/// <summary>
		/// Calculates percentage
		/// </summary>
		/// <param name="total">Total value</param>
		/// <param name="value">Current value</param>
		/// <returns>Percentage</returns>
		public static double LongPercent(int total, int value)
		{
			return (100D / total) * value;
		}
	}
}
