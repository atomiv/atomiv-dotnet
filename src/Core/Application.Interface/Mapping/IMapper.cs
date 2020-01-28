namespace Optivem.Atomiv.Core.Application.Mapping
{
    public interface IMapper
    {
        T Map<S, T>(S source);

        T Map<S, T>(S source, T target);
    }
}