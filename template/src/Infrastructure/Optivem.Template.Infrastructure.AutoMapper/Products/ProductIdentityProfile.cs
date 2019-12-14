using AutoMapper;
using Optivem.Template.Core.Domain.Products;
using System;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class ProductIdentityProfile : Profile
    {
        public ProductIdentityProfile()
        {
            CreateMap<ProductIdentity, Guid>()
                .ConvertUsing(src => src.Value);
        }
    }
}