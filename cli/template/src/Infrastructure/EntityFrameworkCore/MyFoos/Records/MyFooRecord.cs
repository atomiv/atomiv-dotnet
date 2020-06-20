using Atomiv.Core.Domain;

namespace Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records
{
    public class MyFooRecord : IIdentity<int>
    {
        public MyFooRecord()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}