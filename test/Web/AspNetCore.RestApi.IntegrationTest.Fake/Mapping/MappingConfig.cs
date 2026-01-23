using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using Mapster;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            // Simple mappings - most properties will map by convention
            // No custom mappings needed - IDs are Guids that map directly
        }
    }
}
