using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Generator.Core.Domain.Aggregates
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
