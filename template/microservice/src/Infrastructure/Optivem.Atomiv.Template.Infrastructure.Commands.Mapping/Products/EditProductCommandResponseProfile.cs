using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Domain.Products;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Products
{
    public class EditProductCommandResponseProfile : Profile
    {
        public EditProductCommandResponseProfile()
        {
            CreateMap<Product, EditProductCommandResponse>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice));
        }
    }
}
