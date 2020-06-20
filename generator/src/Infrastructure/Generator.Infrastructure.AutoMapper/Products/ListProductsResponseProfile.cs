using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Generator.Core.Application.Products.Responses;
using Generator.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Infrastructure.AutoMapper.Products
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
