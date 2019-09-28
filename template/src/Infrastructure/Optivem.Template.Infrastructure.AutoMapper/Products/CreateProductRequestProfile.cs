using AutoMapper;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class CreateProductRequestProfile : Profile
    {
        public CreateProductRequestProfile()
        {
            CreateMap<CreateProductRequest, Product>()
                .ConstructUsing(request => new Product(ProductIdentity.Null,
                    request.Code,
                    request.Description,
                    request.UnitPrice));
        }
    }
}
