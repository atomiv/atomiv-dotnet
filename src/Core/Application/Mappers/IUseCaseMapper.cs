namespace Optivem.Framework.Core.Application.Mappers
{
    public interface IUseCaseMapper
    {
        T Map<S, T>(S source);

        T Map<S, T>(S source, T target); 
    }
}
