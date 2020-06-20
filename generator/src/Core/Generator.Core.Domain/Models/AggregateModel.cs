using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Core.Domain.Models
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
