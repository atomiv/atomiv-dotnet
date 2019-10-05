using AutoMapper;
using Optivem.Framework.Core.Domain;
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
            CreateMap<PageAggregateRootsResponse<Product>, BrowseProductsResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e.AggregateRoots))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(e => e.TotalRecords));
        }
    }

    public class BrowseProductsRecordResponseProfile : Profile
    {
        public BrowseProductsRecordResponseProfile()
        {
            CreateMap<Product, BrowseProductsRecordResponse>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(e => e.ProductCode))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(e => e.ProductName))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.ListPrice));
        }

    }
}
