using AutoMapper;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Queries;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.Mapping.Products
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