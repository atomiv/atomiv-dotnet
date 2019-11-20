using AutoMapper;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class ProductIdentityProfile : Profile
    {
        public ProductIdentityProfile()
        {
            CreateMap<ProductIdentity, int>()
                .ConvertUsing(src => src.Id);
        }
    }
}