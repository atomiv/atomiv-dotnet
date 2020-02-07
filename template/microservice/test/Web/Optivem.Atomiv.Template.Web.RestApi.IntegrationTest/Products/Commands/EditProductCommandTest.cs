namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Products.Commands
{
    public class EditProductCommandTest : BaseTest
    {
        public EditProductCommandTest(Fixture fixture) : base(fixture)
        {
        }

        /*
         * 
        [Fact(Skip = "Pending implement")]
        public async Task UpdateProduct_Valid_OK()
        {
            var productRecord = _productRecords[0];

            var updateRequest = new EditProductCommand
            {
                Id = productRecord.Id,
                Description = "New desc",
                UnitPrice = 130,
            };

            var updateResponse = await Fixture.Api.Products.EditProductAsync(updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            var updateResponseContent = updateResponse.Data;

            Assert.Equal(updateRequest.Id, updateResponseContent.Id);
            Assert.Equal(updateRequest.Description, updateResponseContent.Description);
            Assert.Equal(updateRequest.UnitPrice, updateResponseContent.UnitPrice);
        }

        [Fact]
        public async Task UpdateProduct_NotExist_NotFound()
        {
            var id = Guid.NewGuid();

            var updateRequest = new EditProductCommand
            {
                Id = id,
                Description = "New desc 2",
                UnitPrice = 140,
            };

            var updateResponse = await Fixture.Api.Products.EditProductAsync(updateRequest);

            Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
        }

        [Fact(Skip = "Pending implement")]
        public async Task UpdateProduct_Invalid_UnprocessableEntity()
        {
            var productRecord = _productRecords[0];

            var updateRequest = new EditProductCommand
            {
                Id = productRecord.Id,
                Description = "New desc 3",
                UnitPrice = 150,
            };

            var updateResponse = await Fixture.Api.Products.EditProductAsync(updateRequest);
            Assert.Equal(HttpStatusCode.UnprocessableEntity, updateResponse.StatusCode);

            var problemDetails = updateResponse.ProblemDetails;
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }
         * 
         */
    }
}
