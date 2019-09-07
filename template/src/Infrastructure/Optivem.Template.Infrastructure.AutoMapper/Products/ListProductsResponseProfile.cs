using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
{
    public class ListProductsResponseProfile : Profile
    {
        public ListProductsResponseProfile()
        {
            CreateMap<IEnumerable<Product>, ListProductsResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));

        }
    }

    public class ListProductsRecordResponseProfile : Profile
    {
        public ListProductsRecordResponseProfile()
        {
            CreateMap<Product, ListProductsRecordResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(e => $"{e.ProductCode} - {e.ProductName}"));
        }
    }
}
