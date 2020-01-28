using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Test.Xunit
{
    public class FixtureTest<TFixture> : IClassFixture<TFixture>, IAsyncLifetime
        where TFixture : class
    {
        public FixtureTest(TFixture fixture)
        {
            Fixture = fixture;
        }

        public TFixture Fixture { get; private set; }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}