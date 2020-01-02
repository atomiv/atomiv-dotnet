using AutoMapper;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Products
{
    public class UpdateProductCommandResponseProfile : Profile
    {
        public UpdateProductCommandResponseProfile()
        {
            CreateMap<Product, UpdateProductCommandResponse>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice));
        }
    }
}
