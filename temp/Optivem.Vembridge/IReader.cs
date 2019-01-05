// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Vembridge
{
    /// <summary>
    /// Interface for reader
    /// </summary>
    /// <typeparam name="T">Type of the object being read</typeparam>
    public interface IReader<T> : IDisposable
    {
        T Read();
        List<T> ReadToEnd();
    }
}