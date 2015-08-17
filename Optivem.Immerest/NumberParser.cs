using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Immerest
{
    /// <summary>
    /// Parser for converting from string data into numbers, given a number format
    /// </summary>
    public class NumberParser
    {
        public static NumberParser American = new NumberParser(NumberFormatUtilities.DecimalSeparatedNumberFormat);
        public static NumberParser European = new NumberParser(NumberFormatUtilities.CommaSeparatedNumberFormat);

        public NumberParser(NumberFormatInfo numberFormat)
        {
            this.NumberFormat = numberFormat;
        }

        public NumberFormatInfo NumberFormat { get; private set; }

        public int ParseInteger(string data)
        {
            return int.Parse(data, NumberFormat);
        }

        public double ParseDouble(string data)
        {
            return double.Parse(data, NumberFormat);
        }

        public float ParseFloat(string data)
        {
            return float.Parse(data, NumberFormat);
        }

        public long ParseLong(string data)
        {
            return long.Parse(data, NumberFormat);
        }

        public short ParseShort(string data)
        {
            return short.Parse(data, NumberFormat);
        }
    }
}
