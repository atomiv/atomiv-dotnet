namespace Atomiv.Core.Application
{
    public interface IMapper
    {
        T Map<S, T>(S source);

        T Map<S, T>(S source, T target);
    }
}