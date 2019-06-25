using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Application.IntegrationTest.Fixture;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
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
                }
            };

            Fixture.Db.AddRange(_customerRecords);
        }

        // TODO: VC: Separate tests when there is no data and when data exists?

        [Fact(Skip = "TODO")]
        public async Task BrowseCustomers_ValidRequest_ReturnsResponse()
        {
            var browseRequest = new BrowseCustomersRequest { };

            var browseResponse = await Fixture.Customers.BrowseCustomersAsync(browseRequest);
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

            Assert.True(createResponse.Id > 0);
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
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities
            // TODO: VC: That detailed validation should be in unit tests

            var createRequest = new CreateCustomerRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.Customers.CreateCustomerAsync(createRequest));

            // TODO: Verify that the element was not added by comparing count before and after
        }

        [Fact]
        public async Task DeleteCustomer_ValidRequest_ReturnsResponse()
        {
            var customerRecord = _customerRecords[0];
            var id = customerRecord.Id;

            var deleteRequest = new DeleteCustomerRequest { Id = id };
            var deleteResponse = await Fixture.Customers.DeleteCustomerAsync(deleteRequest);

            // TODO: VC: Assert that when try find it does not exist
        }

        [Fact]
        public async Task DeleteCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

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
            var id = 999;

            var findRequest = new FindCustomerRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Customers.FindCustomerAsync(findRequest));
        }

        [Fact]
        public async Task ListCustomers_ValidRequest_ReturnsResponse()
        {
            var request = new ListCustomersRequest();

            var actualResponse = await Fixture.Customers.ListCustomersAsync(request);

            Assert.Equal(_customerRecords.Count, actualResponse.Count);

            for(int i = 0; i < _customerRecords.Count; i++)
            {
                var expectedRecord = _customerRecords[i];
                var actualRecord = actualResponse.Records[i];

                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.FirstName, actualRecord.FirstName);
                Assert.Equal(expectedRecord.LastName, actualRecord.LastName);
            }
        }

        [Fact]
        public async Task UpdateCustomer_ValidRequest_ReturnsResponse()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

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
        }

        [Fact]
        public async Task UpdateCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = 999,
                FirstName = "New first name",
                LastName = "New last name",
            };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.Customers.UpdateCustomerAsync(updateRequest));
        }

        [Fact]
        public async Task UpdateCustomer_InvalidRequest_ThrowsInvalidRequestException()
        {
            // TODO: Request invalid - null, exceeded length, special characters, words, date (date in the past), negative integers for quantities

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
