using Atomiv.Core.Domain;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Domain.MyFoos.Entities
{
    public class MyFoo : AggregateRoot<MyFooIdentity>
    {
        public MyFoo(MyFooIdentity id, string firstName, string lastName) 
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}