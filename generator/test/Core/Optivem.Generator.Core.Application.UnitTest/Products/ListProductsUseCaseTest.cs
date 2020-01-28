using Moq;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Mappers;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Application.Products.UseCases;
using Optivem.Generator.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Generator.Core.Application.UnitTest.Products
{
    public class ListProductsUseCaseTest
    {
        private readonly Mock<IUseCaseMapper> _mapperMock;
        private readonly Mock<IProductRepository> _repositoryMock;

        private readonly ListProductsUseCase _useCase;

        public ListProductsUseCaseTest()
        {
            _mapperMock = new Mock<IUseCaseMapper>();
            _repositoryMock = new Mock<IProductRepository>();
            _useCase = new ListProductsUseCase(_mapperMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_ReturnsResponse()
        {
            var products = new List<Product>
            {
                new Product(new ProductIdentity(1), "ABC", "My name", 12),
                new Product(new ProductIdentity(2), "BDE", "My name 2", 14),
            };

            _repositoryMock.Setup(e => e.GetAsync()).Returns(Task.FromResult(products.AsEnumerable()));

            var request = new ListProductsRequest();

            await _useCase.HandleAsync(request);

            _mapperMock.Verify(e => e.Map<IEnumerable<Product>, ListProductsResponse>(products), Times.Once);
        }
    }
}
