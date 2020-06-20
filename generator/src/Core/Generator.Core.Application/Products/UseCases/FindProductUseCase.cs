using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using Generator.Core.Domain.Products;

namespace Generator.Core.Application.Products.UseCases
{
    public class FindProductUseCase : FindAggregateUseCase<IProductRepository, FindProductRequest, FindProductResponse, Product, ProductIdentity, int>
    {
        public FindProductUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
