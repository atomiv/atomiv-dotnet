// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Vembridge.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunStringDelimitedReader();
            RunStringFixedReader();
        }

        private static void RunStringDelimitedReader()
        {
            string path = @"C:\path\to\some_file.csv";
            string delimiter = ",";
            
            List<string[]> records;
            using (TextReader textReader = new StreamReader(path))
            {
                StringDelimitedReader reader = new StringDelimitedReader(textReader, delimiter);
                records = reader.ReadToEnd();
            }
        }

        private static void RunStringFixedReader()
        {
            string path = @"C:\path\to\some_file.csv";
            List<FixedFieldFormat> formats = new List<FixedFieldFormat>
            {
                new FixedFieldFormat(0, 5),
                new FixedFieldFormat(5, 3),
                new FixedFieldFormat(8, 4),
                new FixedFieldFormat(12, 2)
            };

            List<string[]> records;
            using (TextReader textReader = new StreamReader(path))
            {
                StringFixedReader reader = new StringFixedReader(textReader, formats);
                records = reader.ReadToEnd();
            }
        }
    }
}
