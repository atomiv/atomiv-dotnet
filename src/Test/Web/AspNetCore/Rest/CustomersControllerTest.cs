using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using Optivem.Platform.Test.Common;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest
{
    public class CustomersControllerTest : RestTestServerFixtureTest
    {
        public CustomersControllerTest(RestTestServerFixture testServerFixture) 
            : base(testServerFixture)
        {
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var expected = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                },

                new CustomerDto
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };

            var actual = await TestServerFixture.CustomersControllerClient.GetCollectionAsync();

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public async Task TestGetCsvAsync()
        {
            var csvSerializationService = new CsvSerializationService();

            var expectedDtos = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                },

                new CustomerDto
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };

            var expected = csvSerializationService.Serialize(expectedDtos);

            var actual = await TestServerFixture.CustomersControllerClient.GetAsync(null, "text/csv");

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public async Task TestPostCsvAsync()
        {
            var csvSerializationService = new CsvSerializationService();

            var expectedDtos = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                },

                new CustomerDto
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };

            var serialized = csvSerializationService.Serialize(expectedDtos);

            var result = await TestServerFixture.CustomersControllerClient.PostAsync("imports", serialized, "text/csv");

            // TODO: VC: Handle later

            /*
            var actualDtos = csvSerializationService.Deserialize<List<CustomerDto>>(result);

            AssertUtilities.AssertEqual(expectedDtos, actualDtos);
            */
        }
    }
}
