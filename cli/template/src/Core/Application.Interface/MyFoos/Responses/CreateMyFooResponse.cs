using Atomiv.Core.Application;

namespace Cli.Core.Application.MyFoos.Responses
{
    public class CreateMyFooResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}