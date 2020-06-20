// Copyright (c)   Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vembridge
{
    /// <summary>
    /// Base implementation of a typed-object reader
    /// </summary>
    /// <typeparam name="T">Type of the object being read</typeparam>
    /// <typeparam name="U">Type of the inner reader used</typeparam>
    public abstract class BaseReader<T, U> : IReader<T> where U : IDisposable
    {
        /// <summary>
        /// Constructs the reader
        /// </summary>
        /// <param name="reader">Represents the underlying reader</param>
        /// <param name="disposeReader"></param>
        protected BaseReader(U reader, bool disposeReader = false)
        {
            this.Reader = reader;
            this.DisposeReader = disposeReader;
        }

        /// <summary>
        /// Represents the underlying reader
        /// </summary>
        public U Reader { get; private set; }

        /// <summary>
        /// Indicates whether the underlying reader should be disposed
        /// </summary>
        protected bool DisposeReader { get; private set; }

        /// <summary>
        /// Reads the next object
        /// </summary>
        /// <returns>The object which has been read</returns>
        public abstract T Read();

        /// <summary>
        /// Reads all the objects
        /// </summary>
        /// <returns>List of all objects read</returns>
        public abstract List<T> ReadToEnd();

        /// <summary>
        /// Disposes the reader
        /// </summary>
        public void Dispose()
        {
            PreDispose();

            if (DisposeReader)
            {
                Reader.Dispose();
            }
        }

        /// <summary>
        /// Executes pre-disposal actions
        /// </summary>
        protected virtual void PreDispose()
        {
            // Implemented only by subclasses, if need to execute custom disposal actions
        }
    }
}
