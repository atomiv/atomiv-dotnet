using Atomiv.Core.Application;

namespace Cli.Core.Application.MyFoos.Requests
{
    public class UpdateMyFooRequest : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}