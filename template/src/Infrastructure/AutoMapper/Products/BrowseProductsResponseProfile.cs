using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class BrowseProductsResponseProfile : Profile
    {
        public BrowseProductsResponseProfile()
        {
            CreateMap<IEnumerable<Product>, BrowseProductsResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));
        }
    }

    public class BrowseProductsRecordResponseProfile : Profile
    {
        public BrowseProductsRecordResponseProfile()
        {
            CreateMap<Product, BrowseProductsRecordResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice));
        }

    }
}
