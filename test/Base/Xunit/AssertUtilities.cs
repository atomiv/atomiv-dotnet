using Optivem.Framework.Core.Common.Serialization;
using Optivem.Framework.Infrastructure.NewtonsoftJson;
using Xunit;

namespace Optivem.Framework.Test.Xunit
{
    public static class AssertUtilities
    {
        private static IJsonSerializer Serializer = new JsonSerializer();

        public static void AssertEqual<T>(T expected, T actual)
        {
            if (expected == null && actual == null)
            {
                return;
            }

            Assert.NotNull(expected);
            Assert.NotNull(actual);

            var expectedString = Serializer.Serialize(expected); ;
            var actualString = Serializer.Serialize(actual);

            Assert.Equal(expectedString, actualString);
        }
    }
}