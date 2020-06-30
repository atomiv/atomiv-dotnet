using FluentAssertions;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Queries.Customers;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Customers.Commands
{
    public class CreateCustomerCommandTest : BaseTest
    {
        public CreateCustomerCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task CreateCustomer_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createRequest = new CreateCustomerCommand
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            // Act

            var createHttpResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest, header);

            // Assert

            createHttpResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createResponse = createHttpResponse.Data;

            createResponse.Id.Should().NotBeEmpty();
            createResponse.Should().BeEquivalentTo(createRequest);

            var id = createResponse.Id;
            var findRequest = new ViewCustomerQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Customers.ViewCustomerAsync(findRequest, header);
            var findResponse = findHttpResponse.Data;
            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            findResponse.Should().BeEquivalentTo(createResponse);
        }

        [Fact]
        public async Task CreateCustomer_InvalidRequest_UnprocessableEntity()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createRequest = new CreateCustomerCommand
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            // Act

            var createHttpResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest, header);

            // Assert

            createHttpResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);

            // TODO: VC: Move to common so that this is validated in all error cases
            createHttpResponse.ProblemDetails.Should().NotBeNull();
            createHttpResponse.ProblemDetails.Type.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Title.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Status.Should().NotBeNull();
            createHttpResponse.ProblemDetails.Detail.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Instance.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Extensions.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateCustomer_InvalidRequest2_UnprocessableEntity()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

            var createRequest = new CreateCustomerCommand
            {
                FirstName = string.Empty,
                LastName = "Last name 1",
            };

            // Act

            var createHttpResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest, header);

            // Assert

            createHttpResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);

            // TODO: VC: Move to common so that this is validated in all error cases
            createHttpResponse.ProblemDetails.Should().NotBeNull();
            createHttpResponse.ProblemDetails.Type.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Title.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Status.Should().NotBeNull();
            createHttpResponse.ProblemDetails.Detail.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Instance.Should().NotBeNullOrEmpty();
            createHttpResponse.ProblemDetails.Extensions.Should().NotBeNull();
        }


    }
}
