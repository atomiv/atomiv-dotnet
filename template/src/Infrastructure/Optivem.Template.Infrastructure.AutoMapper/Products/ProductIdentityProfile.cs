using AutoMapper;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class ProductIdentityProfile : Profile
    {
        public ProductIdentityProfile()
        {
            CreateMap<int, ProductIdentity>()
                .ConvertUsing(src => new ProductIdentity(src));

            CreateMap<ProductIdentity, int>()
                .ConvertUsing(src => src.Id);
        }
    }
}
