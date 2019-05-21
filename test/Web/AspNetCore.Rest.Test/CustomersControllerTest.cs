using Optivem.Common.Http;
using Optivem.Infrastructure.Serialization.CsvHelper;
using Optivem.Test.Xunit;
using Optivem.Test.Xunit.AspNetCore;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers.Exports;
using Optivem.Web.AspNetCore.Fake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Web.AspNetCore.Test
{
    public class CustomersControllerTest : TestClientFixture<TestClient>
    {
        public CustomersControllerTest(TestClient client)
            : base(client)
        {
        }

        [Fact(Skip = "Fails on server, need to re-check")]
        public async Task TestGetAllAsync()
        {
            var expected = new CustomerGetAllResponse
            {
                Results = new List<CustomerGetAllRecordResponse>
                {
                    new CustomerGetAllRecordResponse
                    {
                        Id = 1,
                        UserName = "jsmith",
                        FirstName = "John",
                        LastName = "Smith",
                        CreatedDateTime = new DateTime(2019, 1, 1, 8, 20, 36),
                        ModifiedDateTime = new DateTime(2019, 1, 2, 9, 30, 42),
                    },

                    new CustomerGetAllRecordResponse
                    {
                        Id = 2,
                        UserName = "mcdonald",
                        FirstName = "Mary",
                        LastName = "McDonald",
                        CreatedDateTime = new DateTime(2018, 7, 4, 14, 40, 12),
                        ModifiedDateTime = new DateTime(2018, 9, 8, 18, 50, 18),
                    }
                }
            };

            var actual = await Client.Customers.GetAllAsync();

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

            var actual = await Client.Customers.GetCsvExportsAsync();

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact(Skip = "Sometimes fails locally, need to re-check")]
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

            var result = await Client.Customers.PostImportsAsync(serialized);

            var retrieved = await Client.Customers.GetAllAsync();

            Assert.Equal(4, retrieved.Results.Count());

            // TODO: VC: Handle later

            /*
            var actualDtos = csvSerializationService.Deserialize<List<CustomerDto>>(result);

            AssertUtilities.AssertEqual(expectedDtos, actualDtos);
            */
        }

        [Fact]
        public async Task TestPostAsyncValid()
        {
            var request = new CustomerPostRequest
            {
                UserName = "jsmith3",
                FirstName = "John3",
                LastName = "Smith3",
            };

            var result = await Client.Customers.PostAsync(request);

            Assert.Equal(request.UserName, result.UserName);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task TestPostAsyncInvalid()
        {
            var request = new CustomerPostRequest
            {
                UserName = null,
                FirstName = null,
                LastName = null,
            };

            var exception = await Assert.ThrowsAsync<ProblemDetailsClientException>(async () => await Client.Customers.PostAsync(request));

            var problemDetails = exception.ProblemDetails;

            Assert.NotNull(problemDetails);

            // TODO: VC: Supporting different custom problem details which do not conform to the standard

            Assert.Equal(422, problemDetails.Status);
        }
    }
}