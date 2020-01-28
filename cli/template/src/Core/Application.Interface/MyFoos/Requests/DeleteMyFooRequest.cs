using Optivem.Atomiv.Core.Application;

namespace Optivem.Cli.Core.Application.MyFoos.Requests
{
    public class DeleteMyFooRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}