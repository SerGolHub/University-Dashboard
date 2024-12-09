using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard.Reports.Extension
{
	public static class ExtensionString
	{
		public static bool IsEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}
	}
}
