using FluentAssertions;
using System;
using Xunit;

namespace Optivem.Atomiv.Core.Domain.UnitTest
{
    public class EntityTest
    {
        [Fact]
        public void TestEquals1()
        {
            var a = new Entity<CustomerIdentity>(new CustomerIdentity(4));
            var b = new Entity<CustomerIdentity>(new CustomerIdentity(4));

            a.Should().Be(b);
        }

        [Fact]
        public void TestEquals2()
        {
            var a = (object) new Entity<CustomerIdentity>(new CustomerIdentity(4));
            var b = new Entity<CustomerIdentity>(new CustomerIdentity(4));

            a.Should().Be(b);
        }

        [Fact]
        public void EntityCannotHaveNullId()
        {
            Action action = () => new Entity<CustomerIdentity>(null);
            action.Should().Throw<DomainException>();
        }

        // TODO: VC: DELETE implements
        private class CustomerIdentity : Identity<int> //, IEquatable<CustomerIdentity>, IComparable<CustomerIdentity>
        {
            public CustomerIdentity(int id) : base(id)
            {
            }
        }
    }
}