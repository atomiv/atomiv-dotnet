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
    /// Reader for delimiter-separated values (DSV) files
    /// </summary>
    /// <typeparam name="T">Typed object which can be deserialized from DSV record</typeparam>
    public class DelimitedReader<T> : BaseReader<T, TextReader> where T : class
    {
        /// <summary>
        /// Constructs DSV reader
        /// </summary>
        /// <param name="reader">Underlying text reader</param>
        /// <param name="delimiter">Delimiter text</param>
        /// <param name="converter">Converter from delimited record to typed object</param>
        public DelimitedReader(TextReader reader, string delimiter, IArrayDataConverter<T> converter)
            : base(reader)
        {
            this.Delimiter = delimiter;
            this.Converter = converter;
        }

        /// <summary>
        /// Represents the delimiter text for separating fields on a single line
        /// </summary>
        public string Delimiter { get; private set; }

        /// <summary>
        /// Represents converter for converting from delimited string record to typed object
        /// </summary>
        public IArrayDataConverter<T> Converter { get; private set; }

        /// <summary>
        /// Reads a single typed object from a delimiter-separated value source
        /// </summary>
        /// <returns>Typed object</returns>
        public override T Read()
        {
            string line = Reader.ReadLine();

            if (line == null)
            {
                return null;
            }

            string[] parts = line.Split(new[] { Delimiter }, StringSplitOptions.None);

            return Converter.Convert(parts);
        }

        /// <summary>
        /// Reads all the typed objects from a delimiter-separated value source
        /// </summary>
        /// <returns>List of typed objects</returns>
        public override List<T> ReadToEnd()
        {
            List<T> records = new List<T>();

            T record = null;

            while ((record = Read()) != null)
            {
                records.Add(record);
            }

            return records;
        }
    }
}
