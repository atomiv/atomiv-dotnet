using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.NewtonsoftJson;
using System;
using Xunit;

namespace Optivem.Atomiv.Test.Xunit
{
    public static class AssertUtilities
    {
        private static IJsonSerializer Serializer = new JsonSerializer();

        public static void Equal<T>(T expected, T actual)
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

        public static void NotEmpty(Guid actual)
        {
            Assert.NotEqual(Guid.Empty, actual);
        }
    }
}