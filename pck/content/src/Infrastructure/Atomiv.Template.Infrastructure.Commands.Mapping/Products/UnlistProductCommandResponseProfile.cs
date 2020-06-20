using AutoMapper;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Products
{
    public class UnlistProductCommandResponseProfile : Profile
    {
        public UnlistProductCommandResponseProfile()
        {
            CreateMap<Product, UnlistProductCommandResponse>();
        }
    }
}
