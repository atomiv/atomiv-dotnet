using Optivem.Framework.Core.Domain;

namespace Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records
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