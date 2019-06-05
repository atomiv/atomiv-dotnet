using Xunit;

namespace Optivem.Test.Xunit
{
    public class TestFixture<TFixture> : IClassFixture<TFixture>
        where TFixture : class
    {
        public TestFixture(TFixture fixture)
        {
            Fixture = fixture;
        }

        public TFixture Fixture { get; private set; }
    }
}
