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
        public DateTimeParser(string dateTimeFormat)
        {
            this.DateTimeFormat = dateTimeFormat;
        }

        public string DateTimeFormat { get; private set; }

        public DateTime ParseDateTime(string data)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(data, DateTimeFormat, provider);
        }
    }
}
