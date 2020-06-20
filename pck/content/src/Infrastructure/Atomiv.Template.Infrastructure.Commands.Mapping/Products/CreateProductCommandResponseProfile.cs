using AutoMapper;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Products
{
    public class CreateProductCommandResponseProfile : Profile
    {
        public CreateProductCommandResponseProfile()
        {
            CreateMap<Product, CreateProductCommandResponse>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice));
        }
    }
}
