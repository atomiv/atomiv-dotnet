using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using Optivem.Platform.Test.Common;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Dtos.Customers.Exports;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact(Skip = "Fails on server, need to re-check")]
        public async Task TestGetCollectionAsync()
        {
            var expected = new List<CustomerGetCollectionResponse>
            {
                new CustomerGetCollectionResponse
                {
                    Id = 1,
                    UserName = "jsmith",
                    FirstName = "John",
                    LastName = "Smith",
                    CreatedDateTime = new DateTime(2019, 1, 1, 8, 20, 36),
                    ModifiedDateTime = new DateTime(2019, 1, 2, 9, 30, 42),
                },

                new CustomerGetCollectionResponse
                {
                    Id = 2,
                    UserName = "mcdonald",
                    FirstName = "Mary",
                    LastName = "McDonald",
                    CreatedDateTime = new DateTime(2018, 7, 4, 14, 40, 12),
                    ModifiedDateTime = new DateTime(2018, 9, 8, 18, 50, 18),
                }
            };

            var actual = await TestServerFixture.CustomersControllerClient.GetCollectionAsync();

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact(Skip = "Fails on server, need to re-check")]
        public async Task TestGetExportsCsvAsync()
        {
            var csvSerializationService = new CsvSerializationService();

            var expectedDtos = new List<CustomerExportGetCollectionResponse>
            {
                new CustomerExportGetCollectionResponse
                {
                    Id = 1,
                    UserName = "jsmith",
                    FirstName = "John",
                    LastName = "Smith",
                },

                new CustomerExportGetCollectionResponse
                {
                    Id = 2,
                    UserName = "mcdonald",
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };

            var expected = csvSerializationService.Serialize(expectedDtos);

            var actual = await TestServerFixture.CustomersControllerClient.GetAsync("exports", "text/csv");

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public async Task TestImportPostCsvAsync()
        {
            var csvSerializationService = new CsvSerializationService();

            var request = new List<CustomerImportCollectionPostRequest>
            {
                new CustomerImportCollectionPostRequest
                {
                    UserName = "jsmith2",
                    FirstName = "John2",
                    LastName = "Smith2",
                },

                new CustomerImportCollectionPostRequest
                {
                    UserName = "mmcdonald2",
                    FirstName = "Mary2",
                    LastName = "McDonald2",
                }
            };

            var serialized = csvSerializationService.Serialize(request);

            var result = await TestServerFixture.CustomersControllerClient.PostAsync("imports", serialized, "text/csv");

            var retrieved = await TestServerFixture.CustomersControllerClient.GetCollectionAsync();

            Assert.Equal(4, retrieved.Count());

            // TODO: VC: Handle later

            /*
            var actualDtos = csvSerializationService.Deserialize<List<CustomerDto>>(result);

            AssertUtilities.AssertEqual(expectedDtos, actualDtos);
            */
        }
    }
}
