using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Optivem.Platform.Test.Infrastructure.Common.RestClient.Default
{
    public class RestControllerClientFixtureTest : IClassFixture<RestControllerClientFixture>
    {
        public RestControllerClientFixtureTest(RestControllerClientFixture fixture)
        {
            Fixture = fixture;
        }

        public RestControllerClientFixture Fixture { get; }
    }
}
