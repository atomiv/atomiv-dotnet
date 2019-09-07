using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Core.Application.Products.UseCases
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
