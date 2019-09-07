using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Generator.Core.Domain.Aggregates
{
    public class AggregateModel
    {
        public AggregateModel(string singularName, string pluralName)
        {
            SingularName = singularName;
            PluralName = pluralName;
        }

        public string SingularName { get; }

        public string PluralName { get; }
    }
}
