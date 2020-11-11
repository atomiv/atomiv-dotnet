using MongoDB.Driver;

namespace Atomiv.Infrastructure.MongoDB
{
    public static class IFindFluentExtensions
    {
        public static IFindFluent<T, T> GetPage<T>(this IFindFluent<T, T> findFluent, int page, int size)
        {
            var pageIndex = page - 1;

            var skip = pageIndex * size;

            return findFluent
                .Skip(skip)
                .Limit(size);
        }


        /*
         * 
IFindFluent<TDocument, TDocument>
         * 
         */
    }
}
