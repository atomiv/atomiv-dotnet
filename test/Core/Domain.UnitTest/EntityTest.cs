using Xunit;

namespace Optivem.Framework.Core.Domain.UnitTest
{
    public class EntityTest
    {
        [Fact]
        public void TestEquals1()
        {
            var a = new Entity<CustomerIdentity>(new CustomerIdentity(4));
            var b = new Entity<CustomerIdentity>(new CustomerIdentity(4));

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void TestEquals2()
        {
            var a = (object) new Entity<CustomerIdentity>(new CustomerIdentity(4));
            var b = new Entity<CustomerIdentity>(new CustomerIdentity(4));

            Assert.True(a.Equals(b));
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