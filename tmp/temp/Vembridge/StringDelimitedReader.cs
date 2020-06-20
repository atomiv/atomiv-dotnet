// Copyright (c)   Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vembridge
{
    /// <summary>
    /// String reader for delimiter-separated value formats
    /// </summary>
    public class StringDelimitedReader : DelimitedReader<string[]>
    {
        /// <summary>
        /// Constructs the reader
        /// </summary>
        /// <param name="reader">Text reader for delimiter-separated value source</param>
        /// <param name="delimiter">Delimiter for delimiter-separated value records</param>
        public StringDelimitedReader(TextReader reader, string delimiter)
            : base(reader, delimiter, StringConverter.Instance) { }
    }
}
