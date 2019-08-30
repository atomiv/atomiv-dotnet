using Optivem.Framework.Core.Application;

namespace Optivem.Cli.Core.Application.MyFoos.Requests
{
    public class UpdateMyFooRequest : IRequest<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}