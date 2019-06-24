using Moq;
using Optivem.Core.Application;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.Test.Products
{
    public class ListProductsUseCaseTest
    {
        private readonly Mock<IProductRepository> _repositoryMock;
        // private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IResponseMapper> _responseMapperMock;

        private readonly ListProductsUseCase _useCase;

        public ListProductsUseCaseTest()
        {
            _repositoryMock = new Mock<IProductRepository>();
            // _unitOfWorkMock = new Mock<IUnitOfWork>();
            _responseMapperMock = new Mock<IResponseMapper>();
            _useCase = new ListProductsUseCase(_repositoryMock.Object, _responseMapperMock.Object);
        }


        // [Fact(Skip = "Pending write test")]
        [Fact]
        public async Task ShouldReturnsResultsWhenRepositoryHasData()
        {
            var products = new List<Product>
            {
                new Product(new ProductIdentity(1), "ABC", "My name", 12),
                new Product(new ProductIdentity(2), "BDE", "My name 2", 14),
            };

            _repositoryMock.Setup(e => e.GetAsync()).Returns(Task.FromResult(products.AsEnumerable()));
            // _unitOfWorkMock.Setup(e => e.GetRepository<IProductRepository>()).Returns(_repositoryMock.Object);

            var request = new ListProductsRequest();

            await _useCase.HandleAsync(request);

            _responseMapperMock.Verify(e => e.Map<IEnumerable<Product>, ListProductsResponse>(products), Times.Once);
        }
    }
}
