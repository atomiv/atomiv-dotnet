using Microsoft.Extensions.Configuration;
using Optivem.Core.Common;

namespace Optivem.Test.Common.Configuration
{
    // TODO: VC: Consider moving this into Startup / Composition Root section

    public class JsonConfigurationBuilderFactory : IFactory<IConfigurationBuilder>
    {
        public JsonConfigurationBuilderFactory(string configurationFile)
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
