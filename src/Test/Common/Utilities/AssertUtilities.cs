using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using Xunit;

namespace Optivem.Platform.Test.Common
{
    public static class AssertUtilities
    {
        private static JsonSerializationService jsonSerializationService = new JsonSerializationService();

        public static void AssertEqual<T>(T expected, T actual)
        {
            if(expected == null && actual == null)
            {
                return;
            }

            Assert.NotNull(expected);
            Assert.NotNull(actual);

            var expectedString = jsonSerializationService.Serialize(expected); ;
            var actualString = jsonSerializationService.Serialize(actual);

            Assert.Equal(expectedString, actualString);
        }
    }
}
