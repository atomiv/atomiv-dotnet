using Optivem.Framework.Core.Application;

namespace Optivem.Cli.Core.Application.MyFoos.Requests
{
    public class CreateMyFooRequest : IRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}