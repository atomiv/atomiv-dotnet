using AutoMapper;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class CreateProductResponseProfile : Profile
    {
        public CreateProductResponseProfile()
        {
            CreateMap<Product, CreateProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice))
                ;
        }
    }
}
