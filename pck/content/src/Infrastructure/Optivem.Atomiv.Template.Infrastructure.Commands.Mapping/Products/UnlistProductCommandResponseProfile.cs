using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Commands.Products;
using Optivem.Atomiv.Template.Core.Domain.Products;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Products
{
    public class UnlistProductCommandResponseProfile : Profile
    {
        public UnlistProductCommandResponseProfile()
        {
            CreateMap<Product, UnlistProductCommandResponse>();
        }
    }
}
