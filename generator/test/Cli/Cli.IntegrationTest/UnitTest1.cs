using System;
using Xunit;

namespace Optivem.Generator.Cli.IntegrationTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var code = @"
            using Optivem.Framework.Core.Domain;

            namespace Optivem.Generator.Core.Domain.Customers
                {
                    public class Customer : AggregateRoot<CustomerIdentity>
                    {
                        public Customer(CustomerIdentity id, string firstName, string lastName)
                            : base(id)
                        {
                            FirstName = firstName;
                            LastName = lastName;
                        }

                        public string FirstName { get; set; }

                        public string LastName { get; set; }
                    }
                }";


        }
    }
}
