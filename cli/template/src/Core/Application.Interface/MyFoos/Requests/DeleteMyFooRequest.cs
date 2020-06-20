using Atomiv.Core.Application;

namespace Cli.Core.Application.MyFoos.Requests
{
    public class DeleteMyFooRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}