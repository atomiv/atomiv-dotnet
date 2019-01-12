using System;

namespace Optivem.Infrastructure.Parsing.Default
{
    /// <summary>
    /// Parser for converting from string data into numbers, given a number format
    /// </summary>
    public class NumberParser
    {
        public static NumberParser American = new NumberParser(NumberFormatUtilities.DecimalSeparatedNumberFormat);
        public static NumberParser European = new NumberParser(NumberFormatUtilities.CommaSeparatedNumberFormat);

        public NumberParser(IFormatProvider formatProvider = null)
        {
            this.FormatProvider = formatProvider;
        }

        public IFormatProvider FormatProvider { get; private set; }

        public int ParseInteger(string data)
        {
            return int.Parse(data, FormatProvider);
        }

        public double ParseDouble(string data)
        {
            return double.Parse(data, FormatProvider);
        }

        public float ParseFloat(string data)
        {
            return float.Parse(data, FormatProvider);
        }

        public long ParseLong(string data)
        {
            return long.Parse(data, FormatProvider);
        }

        public short ParseShort(string data)
        {
            return short.Parse(data, FormatProvider);
        }
    }
}
