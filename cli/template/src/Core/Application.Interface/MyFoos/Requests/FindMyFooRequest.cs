using Optivem.Atomiv.Core.Application;

namespace Optivem.Cli.Core.Application.MyFoos.Requests
{
    public class FindMyFooRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}