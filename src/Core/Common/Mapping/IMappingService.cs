using System;

namespace Optivem.Framework.Core.Common.Mapping
{
    public interface IMappingService
    {
        TDestination Map<TSource, TDestination>(TSource source);

        object Map(object source, Type sourceType, Type destinationType);
    }
}