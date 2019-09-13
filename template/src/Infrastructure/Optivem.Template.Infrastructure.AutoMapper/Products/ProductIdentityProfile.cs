using AutoMapper;
using Optivem.Template.Core.Domain.Products;

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
