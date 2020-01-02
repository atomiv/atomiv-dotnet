using FluentAssertions;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Application.IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest
{
    public class CustomerServiceTest : ServiceTest
    {
        public CustomerServiceTest(ServiceFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task BrowseCustomers_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Markson",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Jake",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Mark",
                    LastName = "McPhil",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Susan",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var browseRequest = new BrowseCustomersQuery
            {
                Page = 2,
                Size = 3,
            };

            var browseResponse = await Fixture.CustomerService.BrowseCustomersAsync(browseRequest);

            // Assert

            var expectedRecordResponses = new List<CreateCustomerCommandResponse>
            {
                createResponses[3],
                createResponses[4],
                createResponses[5],
            };

            browseResponse.TotalRecords.Should().Be(createRequests.Count);

            browseResponse.Records.Should().BeEquivalentTo(expectedRecordResponses);
        }

        [Fact]
        public async Task CreateCustomer_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var createRequest = new CreateCustomerCommand
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            // Act

            var createResponse = await Fixture.CustomerService.CreateCustomerAsync(createRequest);

            // Assert

            createResponse.Id.Should().NotBeEmpty();
            createResponse.Should().BeEquivalentTo(createRequest);

            var id = createResponse.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findResponse = await Fixture.CustomerService.FindCustomerAsync(findRequest);
            findResponse.Should().BeEquivalentTo(createResponse);
        }

        [Fact]
        public async Task CreateCustomer_InvalidRequest_ThrowsInvalidRequestException()
        {
            // Arrange

            var createRequest = new CreateCustomerCommand
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            // Act

            Func<Task> createFunc = () => Fixture.CustomerService.CreateCustomerAsync(createRequest);

            // Assert

            await createFunc.Should().ThrowAsync<InvalidRequestException>();
        }

        [Fact]
        public async Task DeleteCustomer_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var id = createResponses[1].Id;
            var deleteRequest = new DeleteCustomerCommand { Id = id };
            await Fixture.CustomerService.DeleteCustomerAsync(deleteRequest);

            // Assert

            var findRequest = new FindCustomerQuery { Id = id };
            Func<Task> findFunc = () => Fixture.CustomerService.FindCustomerAsync(findRequest);
            await findFunc.Should().ThrowAsync<NotFoundRequestException>();
        }

        [Fact]
        public async Task DeleteCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            await CreateCustomersAsync(createRequests);

            // Act

            var id = Guid.NewGuid();
            var deleteRequest = new DeleteCustomerCommand { Id = id };
            Func<Task> deleteFunc = () => Fixture.CustomerService.DeleteCustomerAsync(deleteRequest);

            // Assert

            await deleteFunc.Should().ThrowAsync<NotFoundRequestException>();
        }

        [Fact]
        public async Task FindCustomer_ValidRequest_ReturnsCustomer()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var someCreateResponse = createResponses[1];
            var id = someCreateResponse.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findResponse = await Fixture.CustomerService.FindCustomerAsync(findRequest);

            // Assert
            
            findResponse.Should().BeEquivalentTo(someCreateResponse);
        }


        [Fact]
        public async Task FindCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var id = Guid.NewGuid();
            var findRequest = new FindCustomerQuery { Id = id };
            Func<Task> findFunc = () => Fixture.CustomerService.FindCustomerAsync(findRequest);

            // Assert

            await findFunc.Should().ThrowAsync<NotFoundRequestException>();
        }


        [Fact]
        public async Task ListCustomers_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Markson",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Jake",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Mark",
                    LastName = "McPhil",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Susan",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var listRequest = new ListCustomersQuery
            {
                NameSearch = "ark",
                Limit = 10,
            };

            var listResponse = await Fixture.CustomerService.ListCustomersAsync(listRequest);

            // Assert

            var expectedRecords = new List<CreateCustomerCommandResponse>
            {
                createResponses[3],
                createResponses[5],
            }
            .Select(e => new ListCustomersRecordResponse
            {
                Id = e.Id,
                Name = $"{e.FirstName} {e.LastName}",
            });

            listResponse.TotalRecords.Should().Be(createRequests.Count);

            listResponse.Records.Should().BeEquivalentTo(expectedRecords);
        }




        [Fact]
        public async Task UpdateCustomer_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var someCreateResponse = createResponses[1];

            var updateRequest = new UpdateCustomerCommand
            {
                Id = someCreateResponse.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.CustomerService.UpdateCustomerAsync(updateRequest);

            // Assert

            updateResponse.Should().BeEquivalentTo(updateRequest);

            var id = updateRequest.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findResponse = await Fixture.CustomerService.FindCustomerAsync(findRequest);
            findResponse.Should().BeEquivalentTo(updateResponse);
        }

        [Fact]
        public async Task UpdateCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var id = Guid.NewGuid();

            var updateRequest = new UpdateCustomerCommand
            {
                Id = id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            Func<Task> updateFunc = () => Fixture.CustomerService.UpdateCustomerAsync(updateRequest);

            // Assert

            await updateFunc.Should().ThrowAsync<NotFoundRequestException>();
        }

        [Fact]
        public async Task UpdateCustomer_InvalidRequest_ThrowsInvalidRequestException()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var someCreateResponse = createResponses[2];

            var updateRequest = new UpdateCustomerCommand
            {
                Id = someCreateResponse.Id,
                FirstName = "New first name",
                LastName = null,
            };

            Func<Task> updateFunc = () => Fixture.CustomerService.UpdateCustomerAsync(updateRequest);

            // Assert

            await updateFunc.Should().ThrowAsync<InvalidRequestException>();
        }
    }
}