using System;
using Xunit;

namespace Optivem.Framework.Core.Domain.UnitTest
{
    public class IdentityTest
    {
        [Fact]
        public void TestEquals1()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(5);

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void TestEquals2()
        {
            var a = new Identity<int>(5);
            Identity<int> b = null;

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEquals3()
        {
            var a = new Identity<int>(5);
            object b = null;

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEquals4()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(4);

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEquals5()
        {
            var guid = Guid.NewGuid();

            var a = new Identity<Guid>(guid);
            var b = new Identity<Guid>(guid);

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void TestEquals6()
        {
            var a = new Identity<Guid>(Guid.NewGuid());
            var b = new Identity<Guid>(Guid.NewGuid());

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEquals9()
        {
            var a = new Identity<int>(5);
            var b = 5;

            // TODO: VC: Check
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEqualsOperator1()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(5);

            Assert.True(a == b);
        }

        [Fact]
        public void TestEqualsOperator2()
        {
            var a = new CustomerIdentity(5);
            var b = new CustomerIdentity(5);

            Assert.True(a == b);
        }

        [Fact]
        public void TestEqualsOperator3()
        {
            var a = new CustomerIdentity(5);
            var b = new OrderIdentity(5);

            Assert.False(a == b);
        }

        [Fact]
        public void TestInequalityOperator1()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(6);

            Assert.True(a != b);
        }

        [Fact]
        public void TestInequalityOperator2()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(5);

            Assert.False(a != b);
        }

        [Fact]
        public void TestInequalityOperator3()
        {
            var a = new CustomerIdentity(5);
            var b = new OrderIdentity(5);

            Assert.True(a != b);
        }

        [Fact]
        public void TestLessThanOperator1()
        {
            var a = new CustomerIdentity(5);
            var b = new OrderIdentity(10);

            Assert.True(a < b);
        }

        [Fact]
        public void TestLessThanOperator2()
        {
            var a = new CustomerIdentity(15);
            var b = new OrderIdentity(10);

            Assert.False(a < b);
        }

        private class CustomerIdentity : Identity<int>
        {
            public CustomerIdentity(int id) : base(id)
            {
            }
        }

        private class OrderIdentity : Identity<int>
        {
            public OrderIdentity(int id) : base(id)
            {
            }
        }
    }
}