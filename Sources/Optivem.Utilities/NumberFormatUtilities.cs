using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Utilities
{
    /// <summary>
    /// Utilities for working with the NumberFormat class
    /// </summary>
    public static class NumberFormatUtilities
    {
        public static NumberFormatInfo DecimalSeparatedNumberFormat { get; private set; }

        public static NumberFormatInfo CommaSeparatedNumberFormat { get; private set; }

        static NumberFormatUtilities()
        {
            DecimalSeparatedNumberFormat = CreateNumberFormat(",", ".");
            CommaSeparatedNumberFormat = CreateNumberFormat(".", ",");
        }

        public static NumberFormatInfo CreateNumberFormat(string numberGroupSeparator, string numberDecimalSeparator)
        {
            return new NumberFormatInfo()
            {
                NumberGroupSeparator = numberGroupSeparator,
                NumberDecimalSeparator = numberDecimalSeparator
            };
        }

    }
}
