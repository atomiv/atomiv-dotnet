// Copyright (c)   Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vembridge
{
    /// <summary>
    /// Format specifications for a fixed-width field
    /// </summary>
    public class FixedFieldFormat
    {
        /// <summary>
        /// Constructs a fixed-width field format
        /// </summary>
        /// <param name="startIndex">Start index</param>
        /// <param name="length">Length of the field</param>
        public FixedFieldFormat(int startIndex, int length)
        {
            this.StartIndex = startIndex;
            this.Length = length;
        }

        /// <summary>
        /// Represents the start index of the fixed-width field
        /// </summary>
        public int StartIndex { get; private set; }

        /// <summary>
        /// Represents the length of the fixed-width field
        /// </summary>
        public int Length { get; private set; }
    }
}
