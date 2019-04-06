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
    /// Reader for fixed-width file formats
    /// </summary>
    public class FixedReader<T> : BaseReader<T, TextReader> where T : class
    {
        /// <summary>
        /// Creates a reader for fixed-width file formats
        /// </summary>
        /// <param name="reader">Underlying text reader</param>
        /// <param name="fieldFormats">Start indexes of the fixed-width fields</param>
        /// <param name="converter">Converter for converting from fixed-width string record to typed object</param>
        public FixedReader(TextReader reader, List<FixedFieldFormat> fieldFormats, IArrayDataConverter<T> converter)
            : base(reader)
        {
            this.FieldFormats = fieldFormats;
            this.Converter = converter;
        }

        /// <summary>
        /// Represents the start indexes of the fixed-width fields
        /// </summary>
        public List<FixedFieldFormat> FieldFormats { get; private set; }

        /// <summary>
        /// Represents converter for converting from fixed-width string record to typed object
        /// </summary>
        public IArrayDataConverter<T> Converter { get; private set; }

        /// <summary>
        /// Reads a single typed object from a fixed-width format source
        /// </summary>
        /// <returns>Typed object</returns>
        public override T Read()
        {
            string line = Reader.ReadLine();

            if (line == null)
            {
                return null;
            }

            int count = FieldFormats.Count;
            string[] parts = new string[count];

            for (int i = 0; i < count; i++)
            {
                FixedFieldFormat format = FieldFormats[i];
                int startIndex = format.StartIndex;
                int length = format.Length;
                string field = line.Substring(startIndex, length);
                parts[i] = field;
            }

            return Converter.Convert(parts);
        }

        /// <summary>
        /// Reads all the typed objects from a fixed-width format source
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
