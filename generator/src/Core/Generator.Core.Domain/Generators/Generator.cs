using Generator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Core.Domain.Generators
{
    public abstract class Generator : IGenerator
    {
        public Generator(AggregateModel model)
        {
            Model = model;
        }

        public AggregateModel Model { get; }

        public abstract string Generate();
    }
}
