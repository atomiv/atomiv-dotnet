using Optivem.Framework.Core.Application;
using Optivem.Framework.Test.Xunit;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.IntegrationTest.Fixtures;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest
{
    public class CustomerServiceTest : ServiceTest
    {
        private readonly List<CustomerRecord> _customerRecords;

        public CustomerServiceTest(ServiceFixture fixture) : base(fixture)
        {
            _customerRecords = new List<CustomerRecord>
            {
                new CustomerRecord
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CustomerRecord
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CustomerRecord
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },

                new CustomerRecord
                {
                    FirstName = "Markson",
                    LastName = "McDonald",
                },

                new CustomerRecord
                {
                    FirstName = "Jake",
                    LastName = "McDonald",
                },

                new CustomerRecord
                {
                    FirstName = "Mark",
                    LastName = "McPhil",
                },

                new CustomerRecord
                {
                    FirstName = "Susan",
                    LastName = "McDonald",
                },
            };

            Fixture.Db.AddRange(_customerRecords);
        }

        [Fact]
        public async Task BrowseCustomers_ValidRequest_ReturnsResponse()
        {
            var browseRequest = new BrowseCustomersRequest
            {
                Page = 2,
                Size = 3,
            };

            var expectedRecords = new List<CustomerRecord>
            {
                _customerRecords[3],
                _customerRecords[4],
                _customerRecords[5],
            };

            var browseResponse = await Fixture.Customers.BrowseCustomersAsync(browseRequest);

            Assert.Equal(_customerRecords.Count, browseResponse.TotalRecords);
            Assert.Equal(expectedRecords.Count, browseResponse.Records.Count);

            for (int i = 0; i < expectedRecords.Count; i++)
            {
                var expectedRecord = expectedRecords[i];
                var responseRecord = browseResponse.Records[i];

                Assert.Equal(expectedRecord.Id, responseRecord.Id);
                Assert.Equal(expectedRecord.FirstName, responseRecord.FirstName);
                Assert.Equal(expectedRecord.LastName, responseRecord.LastName);
            }
        }

        [Fact]
        public async Task CreateCustomer_ValidRequest_ReturnsResponse()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Customers.CreateCustomerAsync(createRequest);

            AssertUtilities.NotEmpty(createResponse.Id);
            Assert.Equal(createRequest.FirstName, createResponse.FirstName);
            Assert.Equal(createRequest.LastName, createResponse.LastName);

            var findRequest = new FindCustomerRequest { Id = createResponse.Id };

            var findResponse = await Fixture.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(findRequest.Id, findResponse.Id);
            Assert.Equal(createRequest.FirstName, findResponse.FirstName);
            Assert.Equal(createRequest.LastName, findResponse.LastName);
        }

        [Fact]
        public async Task CreateCustomer_InvalidRequest_ThrowsInvalidRequestException()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.Customers.CreateCustomerAsync(createRequest));
        }

        [Fact]
        public async Task DeleteCustomer_ValidRequest_ReturnsResponse()
        {
            var customerRecord = _customerRecords[0];
            var id = customerRecord.Id;

            var deleteRequest = new DeleteCustomerRequest { Id = id };
            var deleteResponse = await Fixture.Customers.DeleteCustomerAsync(deleteRequest);
        }

        [Fact]
        public async Task DeleteCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = Guid.NewGuid();

            var deleteRequest = new DeleteCustomerRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Customers.DeleteCustomerAsync(deleteRequest));
        }

        [Fact]
        public async Task FindCustomer_ValidRequest_ReturnsCustomer()
        {
            var customerRecord = _customerRecords[0];
            var id = customerRecord.Id;

            var findRequest = new FindCustomerRequest { Id = id };
            var findResponse = await Fixture.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(customerRecord.Id, findResponse.Id);
            Assert.Equal(customerRecord.FirstName, findResponse.FirstName);
            Assert.Equal(customerRecord.LastName, findResponse.LastName);
        }

        [Fact]
        public async Task FindCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = Guid.NewGuid();

            var findRequest = new FindCustomerRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Customers.FindCustomerAsync(findRequest));
        }

        [Fact]
        public async Task ListCustomers_ValidRequest_ReturnsResponse()
        {
            var request = new ListCustomersRequest
            {
                NameSearch = "ark",
                Limit = 20,
            };

            var expectedRecords = new List<CustomerRecord>
            {
                _customerRecords[5],
                _customerRecords[3],
            };

            var actualResponse = await Fixture.Customers.ListCustomersAsync(request);

            Assert.Equal(expectedRecords.Count, actualResponse.Records.Count);
            Assert.Equal(_customerRecords.Count, actualResponse.TotalRecords);

            for (int i = 0; i < expectedRecords.Count; i++)
            {
                var expectedRecord = expectedRecords[i];
                var actualRecord = actualResponse.Records[i];

                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.FirstName + " " + expectedRecord.LastName, actualRecord.Name);
            }
        }

        [Fact]
        public async Task UpdateCustomer_ValidRequest_ReturnsResponse()
        {
            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = customerRecord.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Customers.UpdateCustomerAsync(updateRequest);

            Assert.Equal(updateRequest.Id, updateResponse.Id);
            Assert.Equal(updateRequest.FirstName, updateResponse.FirstName);
            Assert.Equal(updateRequest.LastName, updateResponse.LastName);

            var findRequest = new FindCustomerRequest { Id = updateRequest.Id };
            var findResponse = await Fixture.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(updateResponse.Id, findResponse.Id);
            Assert.Equal(updateResponse.FirstName, findResponse.FirstName);
            Assert.Equal(updateResponse.LastName, findResponse.LastName);
        }

        [Fact]
        public async Task UpdateCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var customerRecord = _customerRecords[0];

            var id = Guid.NewGuid();

            var updateRequest = new UpdateCustomerRequest
            {
                Id = id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Customers.UpdateCustomerAsync(updateRequest));
        }

        [Fact]
        public async Task UpdateCustomer_InvalidRequest_ThrowsInvalidRequestException()
        {
            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = customerRecord.Id,
                FirstName = "New first name",
                LastName = null,
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.Customers.UpdateCustomerAsync(updateRequest));
        }
    }
}