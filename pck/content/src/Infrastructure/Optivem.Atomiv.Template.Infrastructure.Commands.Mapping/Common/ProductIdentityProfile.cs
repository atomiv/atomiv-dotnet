using AutoMapper;
using Optivem.Atomiv.Template.Core.Domain.Products;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Common
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