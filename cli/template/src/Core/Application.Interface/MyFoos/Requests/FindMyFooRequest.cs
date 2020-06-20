using Atomiv.Core.Application;

namespace Cli.Core.Application.MyFoos.Requests
{
    public class FindMyFooRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}