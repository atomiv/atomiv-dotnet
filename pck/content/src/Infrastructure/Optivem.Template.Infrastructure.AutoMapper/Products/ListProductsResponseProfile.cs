using AutoMapper;
using Optivem.Framework.Core.Domain;
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
            CreateMap<ListReadModel<ProductIdNameReadModel>, ListProductsResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e.Records))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(e => e.TotalRecords));

            CreateMap<ProductIdNameReadModel, ListProductsRecordResponse>();
        }
    }
}