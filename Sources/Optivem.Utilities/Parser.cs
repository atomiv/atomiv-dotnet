using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Utilities
{
    /// <summary>
    /// Parses string data into objects, using specified data types
    /// </summary>
    public class Parser
    {
        private static Dictionary<DataType, Convert> delegates = new Dictionary<DataType, Convert>()
        {
            { DataType.String, new Convert((parser, data) => data) },
            { DataType.Short, new Convert((parser, data) => parser.NumberParser.ParseShort(data)) },
            { DataType.Integer, new Convert((parser, data) => parser.NumberParser.ParseInteger(data)) },
            { DataType.Long, new Convert((parser, data) => parser.NumberParser.ParseLong(data)) },
            { DataType.Float, new Convert((parser, data) => parser.NumberParser.ParseFloat(data)) },
            { DataType.Double, new Convert((parser, data) => parser.NumberParser.ParseDouble(data)) },
            { DataType.DateTime, new Convert((parser, data) => parser.DateTimeParser.ParseDateTime(data)) },
        };

        private delegate object Convert(Parser parser, string data);

        public Parser(NumberParser numberParser, DateTimeParser dateTimeParser)
        {
            this.NumberParser = numberParser;
            this.DateTimeParser = dateTimeParser;
        }

        public NumberParser NumberParser { get; private set; }

        public DateTimeParser DateTimeParser { get; private set; }

        public object Parse(string data, DataType dataType)
        {
            if (!delegates.ContainsKey(dataType))
            {
                throw new NotSupportedException();
            }

            if (data == null)
            {
                return null;
            }

            return delegates[dataType](this, data);
        }
    }
}
