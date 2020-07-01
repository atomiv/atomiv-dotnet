using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Atomiv.Core.Domain.UnitTest
{
    public class PrimitiveIdentityTest
    {

        [Fact]
        public void GuidIdentityCannotBeEmptyGuidValue()
        {
            Action action = () => new GuidIdentity(Guid.Empty);
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void GuidIdentityIdentical()
        {
            var guid = Guid.NewGuid();

            var a = new GuidIdentity(guid);
            var b = new GuidIdentity(guid);

            (a == b).Should().BeTrue();
        }

        [Fact]
        public void GuidIdentityImplicitConversion()
        {
            GuidIdentity a = null;
            Guid b;

            Action action = () => b = a;
            action.Should().Throw<DomainException>();
        }

        [Fact]
        public void GuidIdentityImplicitConversionNullable()
        {
            GuidIdentity a = null;
            Guid? b = a;

            b.Should().Be(null);
        }


        private class GuidIdentity : PrimitiveIdentity<Guid>
        {
            public GuidIdentity(Guid value) : base(value)
            {
            }
        }
    }
}
