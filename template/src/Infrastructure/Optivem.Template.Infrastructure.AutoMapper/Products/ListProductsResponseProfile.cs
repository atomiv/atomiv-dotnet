using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Products
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
