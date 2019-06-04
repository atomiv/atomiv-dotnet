using Xunit;

namespace Optivem.Core.Domain.Test
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
            IIdentity<int> b = null;

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
            var a = new Identity<string>("hello");
            var b = new Identity<string>("hello");

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void TestEquals6()
        {
            var a = new Identity<string>("hello");
            var b = new Identity<string>("hello2");

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEquals7()
        {
            var a = new Identity<string>("hello");
            var b = new Identity<string>(null);

            Assert.False(a.Equals(b));
        }

        [Fact]
        public void TestEquals8()
        {
            var a = new Identity<string>(null);
            var b = new Identity<string>(null);

            // TODO: VC: Check
            Assert.True(a.Equals(b));
        }
    }
}
