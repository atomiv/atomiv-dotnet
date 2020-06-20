using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using Generator.Core.Domain.Products;

namespace Generator.Core.Application.Products.UseCases
{
    public class RelistProductUseCase : UpdateAggregateUseCase<IProductRepository, RelistProductRequest, RelistProductResponse, Product, ProductIdentity, int>
    {
        public RelistProductUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Product aggregateRoot, RelistProductRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
