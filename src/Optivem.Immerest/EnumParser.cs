// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Immerest
{
    /// <summary>
    /// Parser for Enum types
    /// </summary>
    public class EnumParser
    {
        /// <summary>
        /// Creates an instance of the parser for Enum types
        /// </summary>
        /// <param name="ignoreCase">Indicates whether case should be ignored during parsing</param>
        public EnumParser(bool ignoreCase = false)
        {
            this.IgnoreCase = ignoreCase;
        }

        /// <summary>
        /// Indicates whether case should be ignored during parsing
        /// </summary>
        public bool IgnoreCase { get; private set; }

        /// <summary>
        /// Parses string data and converts it to an object
        /// </summary>
        /// <param name="data">String data to be parsed</param>
        /// <param name="type">Enum data type</param>
        /// <returns>Parsed Enum object</returns>
        public object ParseEnum(string data, Type type)
        {
            return Enum.Parse(type, data, IgnoreCase);
        }

        /// <summary>
        /// Parses string data and converts it to an object
        /// </summary>
        /// <typeparam name="T">Enum data type</typeparam>
        /// <param name="data">String data to be parsed</param>
        /// <returns>Parsed Enum object</returns>
        public T ParseEnum<T>(string data)
        {
            return (T)ParseEnum(data, typeof(T));
        }
    }
}
