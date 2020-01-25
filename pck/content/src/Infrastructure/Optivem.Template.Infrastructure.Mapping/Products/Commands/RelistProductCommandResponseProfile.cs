using AutoMapper;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.Mapping.Products
{
    public class RelistProductCommandResponseProfile : Profile
    {
        public RelistProductCommandResponseProfile()
        {
            CreateMap<Product, RelistProductCommandResponse>();
        }
    }
}
