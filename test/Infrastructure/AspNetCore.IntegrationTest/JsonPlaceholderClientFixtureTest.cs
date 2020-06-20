using Xunit;

namespace Atomiv.Infrastructure.AspNetCore.IntegrationTest
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