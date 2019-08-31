using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Generator.Core.Application.Products.Responses;
using Optivem.Generator.Core.Domain.Products.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Generator.Infrastructure.AutoMapper.Products
{
    public class ListProductsResponseProfile : ResponseProfile<IEnumerable<Product>, ListProductsResponse>
    {
        protected override void Extend(IMappingExpression<IEnumerable<Product>, ListProductsResponse> map)
        {
            map.ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));
        }
    }

    public class ListProductsRecordResponseProfile : ResponseProfile<Product, ListProductsRecordResponse>
    {
        protected override void Extend(IMappingExpression<Product, ListProductsRecordResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
            map.ForMember(dest => dest.Name, opt => opt.MapFrom(e => $"{e.ProductCode} - {e.ProductName}"));
        }
    }
}
