using Microsoft.Extensions.Configuration;
using Optivem.Common;

namespace Optivem.Test.Configuration
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
