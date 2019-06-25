using Xunit;

namespace Optivem.Framework.Infrastructure.AspNetCore.IntegrationTest
{
    public class JsonPlaceholderClientFixtureTest : IClassFixture<JsonPlaceholderClientFixture>
    {
        public JsonPlaceholderClientFixtureTest(JsonPlaceholderClientFixture fixture)
        {
            JsonPlaceholderClient = fixture.JsonPlaceholderClient;
        }

        public JsonPlaceholderClient JsonPlaceholderClient { get; }
    }
}