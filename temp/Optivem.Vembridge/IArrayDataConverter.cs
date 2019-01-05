// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Vembridge
{
    /// <summary>
    /// Converter for converting from string array to a typed object
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    public interface IArrayDataConverter<T>
    {
        /// <summary>
        /// Converts a string array to typed object
        /// </summary>
        /// <param name="data">String array input</param>
        /// <returns>Converted typed object</returns>
        T Convert(string[] data);
    }
}
