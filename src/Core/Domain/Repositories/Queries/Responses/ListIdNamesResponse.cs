using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class ListIdNamesResponse<TId> : IResponse
    {
        public ListIdNamesResponse(IEnumerable<IdNameResponse<TId>> records, int totalRecords)
        {
            Records = records;
            TotalRecords = totalRecords;
        }

        public IEnumerable<IdNameResponse<TId>> Records { get; }

        public int TotalRecords { get; }
    }

    public class IdNameResponse<TId> : IResponse
    {
        public IdNameResponse(TId id, string name)
        {
            Id = id;
            Name = name;
        }

        public TId Id { get; }

        public string Name { get; }
    }
}
