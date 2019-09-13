namespace Optivem.Framework.Core.Common.Mapping
{
    public interface IMapper
    {
        T Map<S, T>(S source);

        T Map<S, T>(S source, T target); 
    }
}
