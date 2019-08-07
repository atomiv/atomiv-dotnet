using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Framework.Test.Xunit
{
    public class AsyncFixtureTest : IAsyncLifetime
    {
        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
