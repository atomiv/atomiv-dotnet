using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Mappers;
using Optivem.Atomiv.Core.Domain;
using Optivem.Generator.Core.Application.Products.Requests;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Domain.Products;

namespace Optivem.Generator.Core.Application.Products.UseCases
{
    public class UpdateProductUseCase : UpdateAggregateUseCase<IProductRepository, UpdateProductRequest, UpdateProductResponse, Product, ProductIdentity, int>
    {
        public UpdateProductUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Product aggregateRoot, UpdateProductRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
