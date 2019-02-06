using Xunit;

namespace Optivem.Platform.Test.Infrastructure.Common.RestClient.Default
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
