using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Domain.Products;

namespace Optivem.Generator.Core.Application.Products.UseCases
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
