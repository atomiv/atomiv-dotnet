using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using Generator.Core.Domain.Products;

namespace Generator.Core.Application.Products.UseCases
{
    public class UnlistProductUseCase : UpdateAggregateUseCase<IProductRepository, UnlistProductRequest, UnlistProductResponse, Product, ProductIdentity, int>
    {
        public UnlistProductUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Product aggregateRoot, UnlistProductRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
