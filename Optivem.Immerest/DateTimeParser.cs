using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Immerest
{
    /// <summary>
    /// Parser for converting from string into DateTime, using a given DateTime format
    /// </summary>
    public class DateTimeParser
    {
        /// <summary>
        /// Constructs an instance of the parser
        /// </summary>
        /// <param name="dateTimeFormat">Datetime format used for parsing dates</param>
        public DateTimeParser(string dateTimeFormat)
        {
            this.DateTimeFormat = dateTimeFormat;
        }

        /// <summary>
        /// Datetime format used for parsing dates
        /// </summary>
        public string DateTimeFormat { get; private set; }

        /// <summary>
        /// Converts string representation of DateTime to the actual DateTime object
        /// </summary>
        /// <param name="data">String data to be converted</param>
        /// <returns>Converted DateTime</returns>
        public DateTime ParseDateTime(string data)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(data, DateTimeFormat, provider);
        }
    }
}
