using Moq;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Application.Products.UseCases;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.UnitTest.Products
{
    public class BrowseProductsUseCaseTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductRepository> _repositoryMock;

        private readonly BrowseProductsUseCase _useCase;

        public BrowseProductsUseCaseTest()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IProductRepository>();
            _useCase = new BrowseProductsUseCase(_mapperMock.Object, _repositoryMock.Object);
        }

        [Fact(Skip = "In progress")]
        public async Task HandleAsync_ValidRequest_ReturnsResponse()
        {
            var products = new List<Product>
            {
                new Product(new ProductIdentity(10), "ABC", "My name", 12, true),
                new Product(new ProductIdentity(11), "BDE", "My name 2", 14, true),
                new Product(new ProductIdentity(12), "GDE", "My name 3", 16, true),
                new Product(new ProductIdentity(13), "HDE", "My name 4", 18, true),
            };

            var page = 2;
            var size = 5;

            throw new NotImplementedException();

            /*
            _repositoryMock.Setup(e => e.PageAsync(page, size))
                .Returns(Task.FromResult(products.AsEnumerable()));
            */
            var request = new BrowseProductsRequest
            {
                Page = page,
                Size = size,
            };

            await _useCase.HandleAsync(request);

            _mapperMock.Verify(e => e.Map<IEnumerable<Product>, BrowseProductsResponse>(products), Times.Once);
            _repositoryMock.Verify(e => e.PageAsync(page, size), Times.Once);
        }
    }
}
