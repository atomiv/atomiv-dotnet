using AutoMapper;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class UpdateProductRequestProfile : Profile
    {
        public UpdateProductRequestProfile()
        {
            CreateMap<UpdateProductRequest, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(e => e.Description))
                .ForMember(dest => dest.ListPrice, opt => opt.MapFrom(e => e.UnitPrice))
                ;
        }
    }
}
