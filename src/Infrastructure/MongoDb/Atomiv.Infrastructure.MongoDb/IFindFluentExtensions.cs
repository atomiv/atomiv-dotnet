using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.MongoDb
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
