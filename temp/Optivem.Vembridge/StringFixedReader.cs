// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Vembridge
{
    /// <summary>
    /// String reader for fixed-width formats
    /// </summary>
    public class StringFixedReader : FixedReader<string[]>
    {
        /// <summary>
        /// Constructs the reader
        /// </summary>
        /// <param name="reader">Underlying reader</param>
        /// <param name="fieldFormats">Formats for fixed-width fields</param>
        public StringFixedReader(TextReader reader, List<FixedFieldFormat> fieldFormats)
            : base(reader, fieldFormats, StringConverter.Instance) { }
    }
}
