using Microsoft.Extensions.Configuration;
using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Test.MicrosoftExtensions.Configuration
{
    public static class ConfigurationRootFactory
    {
        public static IConfigurationRoot Create(IFactory<IConfigurationBuilder> configurationBuilderFactory)
        {
            var configurationBuilder = configurationBuilderFactory.Create();
            var configurationRoot = configurationBuilder.Build();
            return configurationRoot;
        }

        public static IConfigurationRoot Create()
        {
            var configurationBuilderFactory = new JsonConfigurationBuilderFactory(TestFileNames.Configuration);
            return Create(configurationBuilderFactory);
        }
    }
}