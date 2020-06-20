using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Common.Serialization;
using Atomiv.Infrastructure.NewtonsoftJson;
using Atomiv.Test.EntityFrameworkCore;
using Atomiv.Template.DependencyInjection;
using Atomiv.Template.Web.RestClient;
using Atomiv.Template.Web.RestClient.Interface;
using System.Net.Http;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Atomiv.Template.Web.RestApi.IntegrationTest
{
    public class Fixture
    {
        public Fixture()
        {
            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e), ConfigurationKeys.SqlServerOptionsAction);

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json");

            var configurationRoot = configurationBuilder.Build();

            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configurationRoot);

            var services = new ServiceCollection();

            services.AddSingleton(typeof(TestServer), serviceProvider => new TestServer(webHostBuilder));
            services.AddSingleton<IJsonSerializer, JsonSerializer>();

            services.AddTransient<IHttpClientFactory, TestServerHttpClientFactory>();
            services.AddHttpClient<ICustomerControllerClient, CustomerControllerClient>();
            services.AddHttpClient<IOrderControllerClient, OrderControllerClient>();
            services.AddHttpClient<IProductControllerClient, ProductControllerClient>();
            services.AddTransient<IApiClient, ApiClient>();

            var serviceProvider = services.BuildServiceProvider();

            Api = serviceProvider.GetRequiredService<IApiClient>();
        }

        public DbTestClient<DatabaseContext> Db { get; }

        public IApiClient Api { get; }
    }
}