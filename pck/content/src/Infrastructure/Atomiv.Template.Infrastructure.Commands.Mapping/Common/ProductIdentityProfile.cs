using AutoMapper;
using Atomiv.Template.Core.Domain.Products;
using System;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Common
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