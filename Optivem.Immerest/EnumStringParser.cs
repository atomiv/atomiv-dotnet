// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0.

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
    /// <typeparam name="T">Enum type</typeparam>
    public class EnumStringParser<T>
    {
        private Dictionary<string, T> map;

        public EnumStringParser(Dictionary<string, T> map)
        {
            this.map = map;
        }

        /// <summary>
        /// Parses string data and converts it to an object
        /// </summary>
        /// <typeparam name="T">Enum data type</typeparam>
        /// <param name="data">String data to be parsed</param>
        /// <returns>Parsed Enum object</returns>
        public T ParseEnum(string data)
        {
            return map[data];
        }
    }
}
