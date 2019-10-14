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
    public class ListProductsUseCaseTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductRepository> _repositoryMock;

        private readonly ListProductsUseCase _useCase;

        public ListProductsUseCaseTest()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IProductRepository>();
            _useCase = new ListProductsUseCase(_mapperMock.Object, _repositoryMock.Object);
        }

        [Fact(Skip = "In progress")]
        public async Task HandleAsync_ValidRequest_ReturnsResponse()
        {
            var products = new List<Product>
            {
                new Product(new ProductIdentity(1), "ABC", "My name", 12, true),
                new Product(new ProductIdentity(2), "BDE", "My name 2", 14, true),
            };

            throw new NotImplementedException();

            /*
            _repositoryMock.Setup(e => e.FindAsync()).Returns(Task.FromResult(products.AsEnumerable()));
            */

            var request = new ListProductsRequest();

            await _useCase.HandleAsync(request);

            _mapperMock.Verify(e => e.Map<IEnumerable<Product>, ListProductsResponse>(products), Times.Once);
        }
    }
}
