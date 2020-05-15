using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Domain.Products;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Products
{
    public class RelistProductCommandResponseProfile : Profile
    {
        public RelistProductCommandResponseProfile()
        {
            CreateMap<Product, RelistProductCommandResponse>();
        }
    }
}
