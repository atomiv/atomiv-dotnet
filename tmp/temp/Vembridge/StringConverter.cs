// Copyright (c)   Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vembridge
{
    /// <summary>
    /// Direct string converter
    /// </summary>
    public class StringConverter : IArrayDataConverter<string[]>
    {
        public static readonly StringConverter Instance = new StringConverter();

        /// <summary>
        /// Converts string array to string array
        /// </summary>
        /// <param name="data">Input data array</param>
        /// <returns>Mirrored output data array</returns>
        public string[] Convert(string[] data)
        {
            // No conversion, simply relay the received data
            return data;
        }
    }
}
