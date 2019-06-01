using Xunit;

namespace Optivem.Test.Xunit
{
    public abstract class BaseTestFixture<TFixture> : IClassFixture<TFixture>
        where TFixture : class
    {
        public BaseTestFixture(TFixture fixture)
        {
            Fixture = fixture;
        }

        public TFixture Fixture { get; private set; }
    }
}
