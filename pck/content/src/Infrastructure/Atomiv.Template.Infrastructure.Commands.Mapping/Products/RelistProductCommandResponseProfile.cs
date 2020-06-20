using AutoMapper;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Products
{
    public class RelistProductCommandResponseProfile : Profile
    {
        public RelistProductCommandResponseProfile()
        {
            CreateMap<Product, RelistProductCommandResponse>();
        }
    }
}
