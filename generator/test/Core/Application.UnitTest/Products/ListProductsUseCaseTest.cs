using Moq;
using Optivem.Framework.Core.Application;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Application.Products.UseCases;
using Optivem.Generator.Core.Domain.Products.Entities;
using Optivem.Generator.Core.Domain.Products.Repositories;
using Optivem.Generator.Core.Domain.Products.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Generator.Core.Application.UnitTest.Products
{
    public class ListProductsUseCaseTest
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        private readonly Mock<ICollectionResponseMapper<Product, ListProductsResponse>> _responseMapperMock;

        private readonly ListProductsUseCase _useCase;

        public ListProductsUseCaseTest()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _responseMapperMock = new Mock<ICollectionResponseMapper<Product, ListProductsResponse>>();
            _useCase = new ListProductsUseCase(_repositoryMock.Object, _responseMapperMock.Object);
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

            _responseMapperMock.Verify(e => e.Map(products), Times.Once);
        }
    }
}
