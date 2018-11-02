using System;
using System.Collections.Generic;
using System.Text;

namespace Wcoder.Blog.Protocol.Extensions
{
    public class GlobalExtensions
    {
        //系统默认初始时间
        private static readonly DateTime DATETIME_DEFAULT = DateTime.Parse("1900-01-01 00:00:00");

        public static long NewLongId()
        {
            string strKeyNo = string.Concat(DateTime.Now.ToString("yyMMddHHmmssfff", System.Globalization.CultureInfo.InvariantCulture), GetUniqueCode(4));
            return Convert.ToInt64(strKeyNo);
        }

        private static string GetUniqueCode(int intDigit = 7)
        {
            if (intDigit <= 0)
            {
                intDigit = 7;
            }
            string strReturn = Math.Abs(Guid.NewGuid().ToString().GetHashCode()).ToString();
            if (strReturn.Length < intDigit)
            {
                return strReturn.PadRight(intDigit, '0');
            }
            else
            {
                return strReturn.Substring(0, intDigit);
            }
        }
    }
}