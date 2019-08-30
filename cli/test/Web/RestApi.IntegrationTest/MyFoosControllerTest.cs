using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records;
using Optivem.Cli.Web.RestApi.IntegrationTest.Fixtures;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Cli.Web.RestApi.IntegrationTest
{
    public class MyFoosControllerTest : ControllerTest
    {
        private List<MyFooRecord> _myFooRecords;

        public MyFoosControllerTest(ControllerFixture fixture) : base(fixture)
        {
            _myFooRecords = new List<MyFooRecord>
            {
                new MyFooRecord
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new MyFooRecord
                {
                    FirstName = "John",
                    LastName = "McDonald",
                }
            };

            Fixture.Db.AddRange(_myFooRecords);
        }

        [Fact]
        public async Task ListMyFoos_OK()
        {
            var listRequest = new ListMyFoosRequest { };

            var actual = await Fixture.Api.MyFoos.ListMyFoosAsync(listRequest);

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Data;

            Assert.Equal(2, actualContent.Records.Count);

            var expectedFirst = _myFooRecords[0];
            var actualFirst = actualContent.Records[0];

            Assert.True(actualFirst.Id > 0);
            Assert.Equal(expectedFirst.FirstName, actualFirst.FirstName);
            Assert.Equal(expectedFirst.LastName, actualFirst.LastName);

            var expectedSecond = _myFooRecords[1];
            var actualSecond = actualContent.Records[1];

            Assert.True(actualSecond.Id > 0);
            Assert.Equal(expectedSecond.FirstName, actualSecond.FirstName);
            Assert.Equal(expectedSecond.LastName, actualSecond.LastName);
        }

        [Fact]
        public async Task FindMyFoo_Valid_OK()
        {
            var myFooRecord = _myFooRecords[0];
            var id = myFooRecord.Id;

            var findRequest = new FindMyFooRequest { Id = id };

            var findResponse = await Fixture.Api.MyFoos.FindMyFooAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Data;

            Assert.Equal(myFooRecord.Id, findResponseContent.Id);
            Assert.Equal(myFooRecord.FirstName, findResponseContent.FirstName);
            Assert.Equal(myFooRecord.LastName, findResponseContent.LastName);
        }

        [Fact]
        public async Task FindMyFoo_NotExist_NotFound()
        {
            var id = 999;

            var findRequest = new FindMyFooRequest { Id = id };

            var findResponse = await Fixture.Api.MyFoos.FindMyFooAsync(findRequest);

            Assert.Equal(HttpStatusCode.NotFound, findResponse.StatusCode);
        }

        [Fact]
        public async Task CreateMyFoo_Valid_Created()
        {
            var createRequest = new CreateMyFooRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Api.MyFoos.CreateMyFooAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findRequest = new FindMyFooRequest { Id = createResponseContent.Id };

            var findResponse = await Fixture.Api.MyFoos.FindMyFooAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Data;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.FirstName, findResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, findResponseContent.LastName);
        }

        [Fact]
        public async Task CreateMyFoo_Invalid_UnprocessableEntity()
        {
            var createRequest = new CreateMyFooRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Api.MyFoos.CreateMyFooAsync(createRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            var problemDetails = createResponse.ProblemDetails;

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        [Fact]
        public async Task UpdateMyFoo_Valid_OK()
        {
            var myFooRecord = _myFooRecords[0];

            var updateRequest = new UpdateMyFooRequest
            {
                Id = myFooRecord.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Api.MyFoos.UpdateMyFooAsync(updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            var updateResponseContent = updateResponse.Data;

            Assert.Equal(updateRequest.Id, updateResponseContent.Id);
            Assert.Equal(updateRequest.FirstName, updateResponseContent.FirstName);
            Assert.Equal(updateRequest.LastName, updateResponseContent.LastName);
        }

        [Fact]
        public async Task UpdateMyFoo_NotExist_NotFound()
        {
            var myFooRecord = _myFooRecords[0];

            var updateRequest = new UpdateMyFooRequest
            {
                Id = 999,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Api.MyFoos.UpdateMyFooAsync(updateRequest);

            Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
        }

        [Fact]
        public async Task UpdateMyFoo_Invalid_UnprocessableEntity()
        {
            var myFooRecord = _myFooRecords[0];

            var updateRequest = new UpdateMyFooRequest
            {
                Id = myFooRecord.Id,
                FirstName = "New first name",
                LastName = null,
            };

            var updateResponse = await Fixture.Api.MyFoos.UpdateMyFooAsync(updateRequest);
            Assert.Equal(HttpStatusCode.UnprocessableEntity, updateResponse.StatusCode);

            var problemDetails = updateResponse.ProblemDetails;
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        [Fact]
        public async Task DeleteMyFoo_Valid_OK()
        {
            var customerRecord = _myFooRecords[0];
            var id = customerRecord.Id;

            var deleteRequest = new DeleteMyFooRequest { Id = id };

            var deleteResponse = await Fixture.Api.MyFoos.DeleteMyFooAsync(deleteRequest);

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteMyFoo_NotExist_NotFound()
        {
            var id = 999;

            var deleteRequest = new DeleteMyFooRequest { Id = id };

            var deleteResponse = await Fixture.Api.MyFoos.DeleteMyFooAsync(deleteRequest);

            Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
        }
    }
}