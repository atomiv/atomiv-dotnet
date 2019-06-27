using Moq;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Application.Products.UseCases;
using Optivem.Template.Core.Domain.Products.Entities;
using Optivem.Template.Core.Domain.Products.Repositories;
using Optivem.Template.Core.Domain.Products.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.UnitTest.Products
{
    public class BrowseProductsUseCaseTest
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        private readonly Mock<ICollectionResponseMapper<Product, BrowseProductsResponse>> _responseMapperMock;

        private readonly BrowseProductsUseCase _useCase;

        public BrowseProductsUseCaseTest()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _responseMapperMock = new Mock<ICollectionResponseMapper<Product, BrowseProductsResponse>>();
            _useCase = new BrowseProductsUseCase(_repositoryMock.Object, _responseMapperMock.Object);
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_ReturnsResponse()
        {
            var products = new List<Product>
            {
                new Product(new ProductIdentity(10), "ABC", "My name", 12),
                new Product(new ProductIdentity(11), "BDE", "My name 2", 14),
                new Product(new ProductIdentity(12), "GDE", "My name 3", 16),
                new Product(new ProductIdentity(13), "HDE", "My name 4", 18),
            };

            var page = 2;
            var size = 5;

            _repositoryMock.Setup(e => e.GetAsync(page, size))
                .Returns(Task.FromResult(products.AsEnumerable()));

            var request = new BrowseProductsRequest
            {
                Page = page,
                Size = size,
            };

            await _useCase.HandleAsync(request);

            _repositoryMock.Verify(e => e.GetAsync(page, size), Times.Once);
            _responseMapperMock.Verify(e => e.Map(products), Times.Once);
        }
    }
}
