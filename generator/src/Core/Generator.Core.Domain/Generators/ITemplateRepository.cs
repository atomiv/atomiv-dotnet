using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Core.Domain.Generators
{
    public interface ITemplateRepository
    {
        SourceCode GetAggregateSourceCode();
    }
}
