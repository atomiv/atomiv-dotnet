﻿using System;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Test.Xunit
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