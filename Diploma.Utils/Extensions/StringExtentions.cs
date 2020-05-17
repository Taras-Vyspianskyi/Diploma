using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Utils.Extensions
{
    public static class StringExtentions
    {
        public static bool IsNullOrEmpty(this string data)
        {
            if (data == null)
            {
                return true;
            }

            return !(data.Length > 0);
        }
    }
}
