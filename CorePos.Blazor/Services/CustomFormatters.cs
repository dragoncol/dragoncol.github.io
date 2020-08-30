using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePos.Blazor.Services
{
    public static class CustomFormatters
    {
        public static string ToNStr(this double theNumber)
        {
            return theNumber.ToString("c0");
        }

        public static double applyDiscount(this double theNumber, double discountPercent)
        {
            return theNumber - (theNumber * (discountPercent / 100));
        }

        public static double string2Dbl(this string theNumber)
        {
            try
            {
                return Convert.ToDouble(theNumber);
            }
            catch
            {
                return 0;
            }
        }
    }
}
