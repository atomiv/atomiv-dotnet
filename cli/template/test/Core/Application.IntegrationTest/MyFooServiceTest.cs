using Optivem.Atomiv.Core.Application;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.IntegrationTest.Fixtures;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Cli.Core.Application.IntegrationTest
{
    public class MyFooServiceTest : ServiceTest
    {
        private readonly List<MyFooRecord> _myFooRecords;

        public MyFooServiceTest(ServiceFixture fixture) : base(fixture)
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
        public async Task CreateMyFoo_ValidRequest_ReturnsResponse()
        {
            var createRequest = new CreateMyFooRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.MyFoos.CreateMyFooAsync(createRequest);

            Assert.True(createResponse.Id > 0);
            Assert.Equal(createRequest.FirstName, createResponse.FirstName);
            Assert.Equal(createRequest.LastName, createResponse.LastName);

            var findRequest = new FindMyFooRequest { Id = createResponse.Id };

            var findResponse = await Fixture.MyFoos.FindMyFooAsync(findRequest);

            Assert.Equal(findRequest.Id, findResponse.Id);
            Assert.Equal(createRequest.FirstName, findResponse.FirstName);
            Assert.Equal(createRequest.LastName, findResponse.LastName);
        }

        [Fact]
        public async Task CreateMyFoo_InvalidRequest_ThrowsInvalidRequestException()
        {
            var createRequest = new CreateMyFooRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.MyFoos.CreateMyFooAsync(createRequest));
        }

        [Fact]
        public async Task DeleteMyFoo_ValidRequest_ReturnsResponse()
        {
            var myFooRecord = _myFooRecords[0];
            var id = myFooRecord.Id;

            var deleteRequest = new DeleteMyFooRequest { Id = id };
            var deleteResponse = await Fixture.MyFoos.DeleteMyFooAsync(deleteRequest);
        }

        [Fact]
        public async Task DeleteMyFoo_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

            var deleteRequest = new DeleteMyFooRequest { Id = id };
            
            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.MyFoos.DeleteMyFooAsync(deleteRequest));
        }

        [Fact]
        public async Task FindMyFoo_ValidRequest_ReturnsMyFoo()
        {
            var myFooRecord = _myFooRecords[0];
            var id = myFooRecord.Id;

            var findRequest = new FindMyFooRequest { Id = id };
            var findResponse = await Fixture.MyFoos.FindMyFooAsync(findRequest);

            Assert.Equal(myFooRecord.Id, findResponse.Id);
            Assert.Equal(myFooRecord.FirstName, findResponse.FirstName);
            Assert.Equal(myFooRecord.LastName, findResponse.LastName);
        }

        [Fact]
        public async Task FindMyFoo_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var id = 999;

            var findRequest = new FindMyFooRequest { Id = id };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.MyFoos.FindMyFooAsync(findRequest));
        }

        [Fact]
        public async Task ListMyFoos_ValidRequest_ReturnsResponse()
        {
            var request = new ListMyFoosRequest();

            var actualResponse = await Fixture.MyFoos.ListMyFoosAsync(request);

            Assert.Equal(_myFooRecords.Count, actualResponse.Count);

            for(int i = 0; i < _myFooRecords.Count; i++)
            {
                var expectedRecord = _myFooRecords[i];
                var actualRecord = actualResponse.Records[i];

                Assert.Equal(expectedRecord.Id, actualRecord.Id);
                Assert.Equal(expectedRecord.FirstName, actualRecord.FirstName);
                Assert.Equal(expectedRecord.LastName, actualRecord.LastName);
            }
        }

        [Fact]
        public async Task UpdateMyFoo_ValidRequest_ReturnsResponse()
        {
            var myFooRecord = _myFooRecords[0];

            var updateRequest = new UpdateMyFooRequest
            {
                Id = myFooRecord.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.MyFoos.UpdateMyFooAsync(updateRequest);

            Assert.Equal(updateRequest.Id, updateResponse.Id);
            Assert.Equal(updateRequest.FirstName, updateResponse.FirstName);
            Assert.Equal(updateRequest.LastName, updateResponse.LastName);
        }

        [Fact]
        public async Task UpdateMyFoo_NotExistRequest_ThrowsNotFoundRequestException()
        {
            var myFooRecord = _myFooRecords[0];

            var updateRequest = new UpdateMyFooRequest
            {
                Id = 999,
                FirstName = "New first name",
                LastName = "New last name",
            };

            await Assert.ThrowsAsync<NotFoundRequestException>(() => Fixture.MyFoos.UpdateMyFooAsync(updateRequest));
        }

        [Fact]
        public async Task UpdateMyFoo_InvalidRequest_ThrowsInvalidRequestException()
        {
            var myFooRecord = _myFooRecords[0];

            var updateRequest = new UpdateMyFooRequest
            {
                Id = myFooRecord.Id,
                FirstName = "New first name",
                LastName = null,
            };

            await Assert.ThrowsAsync<InvalidRequestException>(() => Fixture.MyFoos.UpdateMyFooAsync(updateRequest));
        }
    }
}
