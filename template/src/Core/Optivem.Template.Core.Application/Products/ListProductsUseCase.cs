using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products
{
    public class ListProductsUseCase : ListAggregatesUseCase<IProductRepository, ListProductsRequest, ListProductsResponse, ListProductsRecordResponse, Product, ProductIdentity, int>
    {
        public ListProductsUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork, responseMapper)
        {
        }
    }
}
