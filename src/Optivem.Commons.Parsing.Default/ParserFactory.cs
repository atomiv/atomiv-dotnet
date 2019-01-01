using System;
using System.Collections.Generic;

namespace Optivem.Parsing.Default
{
    // TODO: VC: Non-generic EnumParser, i.e. parsing any enum, like a service, i.e. parser.Parse<SomeEnum>

    public static class ParserFactory<T>
    {
        public static Parser CreateParser(NumberParser numberParser, DateTimeParser dateTimeParser, IEnumerable<Type> enumTypes = null, 
            BooleanParser booleanParser = null, /* TODO: VC: EnumParser<T> enumParser = null, */ Dictionary<Type, Converter> otherConverters = null)
        {
            if(booleanParser == null)
            {
                booleanParser = new BooleanParser();
            }

            // TODO: VC

            /*
            if(enumParser == null)
            {
                enumParser = new EnumParser();
            }
            */

            Dictionary<Type, Converter> converters = new Dictionary<Type, Converter>
            {
                { CommonTypes.String, data => data },
                { CommonTypes.Bool, data => booleanParser.Parse(data) },
                { CommonTypes.Short, data => numberParser.ParseShort(data) },
                { CommonTypes.Int, data => numberParser.ParseInteger(data) },
                { CommonTypes.Long, data => numberParser.ParseLong(data) },
                { CommonTypes.Float, data => numberParser.ParseFloat(data) },
                { CommonTypes.Double, data => numberParser.ParseDouble(data) },
                { CommonTypes.DateTime, data => dateTimeParser.Parse(data) }
            };

            // TODO: VC

            /*

            if(enumTypes != null)
            {
                foreach (Type enumType in enumTypes)
                {
                    converters.Add(enumType, data => enumParser.ParseEnum(data, enumType));
                }
            }

            */

            if(otherConverters != null)
            {
                foreach(KeyValuePair<Type, Converter> entry in otherConverters)
                {
                    converters.Add(entry.Key, entry.Value);
                }
            }

            return new Parser(converters);
        }
    }
}
