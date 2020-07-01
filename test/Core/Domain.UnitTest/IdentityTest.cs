using FluentAssertions;
using System;
using Xunit;

namespace Atomiv.Core.Domain.UnitTest
{
    public class IdentityTest
    {
        [Fact]
        public void TestEquals1()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(5);

            a.Should().Be(b);
        }

        [Fact]
        public void TestEquals2()
        {
            var a = new Identity<int>(5);
            Identity<int> b = null;

            a.Should().NotBe(b);
        }

        // TODO: VC: DELETE
/*
        [Fact]
        public void TestEquals3()
        {
            var a = new Identity<int>(5);
            object b = null;

            a.Should().NotBe(b);
        }
        */

        [Fact]
        public void TestEquals4()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(4);

            a.Should().NotBe(b);
        }

        [Fact]
        public void TestEquals5()
        {
            var guid = Guid.NewGuid();

            var a = new Identity<Guid>(guid);
            var b = new Identity<Guid>(guid);

            a.Should().Be(b);
        }

        [Fact]
        public void TestEquals6()
        {
            var a = new Identity<Guid>(Guid.NewGuid());
            var b = new Identity<Guid>(Guid.NewGuid());

            a.Should().NotBe(b);
        }

        /*
        [Fact]
        public void TestEquals9()
        {
            var a = new Identity<int>(5);
            var b = 5;

            // TODO: VC: Check
            a.Should().NotBe(b);
            (a.Equals(b)).Should().BeFalse();
        }
        */

        [Fact]
        public void TestEqualsOperator1()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(5);

            (a == b).Should().BeTrue();
        }

        [Fact]
        public void TestEqualsOperator2()
        {
            var a = new CustomerIdentity(5);
            var b = new CustomerIdentity(5);

            (a == b).Should().BeTrue();
        }

        [Fact]
        public void TestEqualsOperator3()
        {
            var a = new CustomerIdentity(5);
            var b = new OrderIdentity(5);

            (a == b).Should().BeFalse();
        }

        [Fact]
        public void TestInequalityOperator1()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(6);

            (a != b).Should().BeTrue();
        }

        [Fact]
        public void TestInequalityOperator2()
        {
            var a = new Identity<int>(5);
            var b = new Identity<int>(5);

            (a != b).Should().BeFalse();
        }

        [Fact]
        public void TestInequalityOperator3()
        {
            var a = new CustomerIdentity(5);
            var b = new OrderIdentity(5);

            (a != b).Should().BeTrue();
        }

        [Fact]
        public void TestLessThanOperator1()
        {
            var a = new CustomerIdentity(5);
            var b = new OrderIdentity(10);

            (a < b).Should().BeTrue();
        }

        [Fact]
        public void TestLessThanOperator2()
        {
            var a = new CustomerIdentity(15);
            var b = new OrderIdentity(10);

            (a < b).Should().BeFalse();
        }

        [Fact]
        public void GuidIdentityCannotBeEmptyGuidValue()
        {
            Action action = () => new GuidIdentity(Guid.Empty);
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void IntIdentityCannotBeZeroValue()
        {
            Action action = () => new CustomerIdentity(0);
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void StringIdentityCannotBeNullValue()
        {
            Action action = () => new StringIdentity(null);
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void NullIdentityConvertsToDefaultIdValue()
        {
            CustomerIdentity customerId = null;
            int value = customerId;

            value.Should().Be(0);
        }

        [Fact]
        public void NullIdentityConvertsToDefaultValue()
        {
            CustomerIdentity customerId = null;
            int? value = customerId;

            value.Should().Be(0);
        }

        private class CustomerIdentity : Identity<int>
        {
            public CustomerIdentity(int value) : base(value)
            {
            }
        }

        private class OrderIdentity : Identity<int>
        {
            public OrderIdentity(int value) : base(value)
            {
            }
        }

        private class GuidIdentity : Identity<Guid>
        {
            public GuidIdentity(Guid value) : base(value)
            {
            }
        }

        private class StringIdentity : Identity<string>
        {
            public StringIdentity(string value) : base(value)
            {
            }
        }
    }
}