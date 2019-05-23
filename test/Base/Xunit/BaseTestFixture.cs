using System;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Test.Xunit
{
    public class BaseTestFixture<TFixture> : IClassFixture<TFixture>, IDisposable
        where TFixture : class
    {
        public BaseTestFixture(TFixture client)
        {
            Fixture = client;
            Setup();
        }

        protected TFixture Fixture { get; private set; }

        protected virtual void Setup()
        {
            // NOTE: No actions by default
        }

        protected virtual void Teardown()
        {
            // NOTE: No actions by default
        }

        public void Dispose()
        {
            Teardown();
        }
    }
}