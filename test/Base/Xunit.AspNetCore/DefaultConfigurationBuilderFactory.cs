using Microsoft.Extensions.Configuration;
using Optivem.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.AspNetCore
{
    public class DefaultConfigurationBuilderFactory : IFactory<IConfigurationBuilder>
    {
        public DefaultConfigurationBuilderFactory(string configurationFile = TestFileNames.Configuration)
        {
            ConfigurationFile = configurationFile;
        }

        public string ConfigurationFile { get; private set; }

        public IConfigurationBuilder Create()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(ConfigurationFile);

            return configurationBuilder;
        }
    }
}
