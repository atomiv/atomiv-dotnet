using Microsoft.Extensions.Configuration;
using Optivem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Configuration
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
