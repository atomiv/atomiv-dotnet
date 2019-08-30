using Optivem.Framework.Core.Application;
using System.Collections.Generic;

namespace Optivem.Cli.Core.Application.MyFoos.Responses
{
    public class ListMyFoosResponse : ICollectionResponse<ListMyFoosRecordResponse, int>
    {
        public List<ListMyFoosRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public class ListMyFoosRecordResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}