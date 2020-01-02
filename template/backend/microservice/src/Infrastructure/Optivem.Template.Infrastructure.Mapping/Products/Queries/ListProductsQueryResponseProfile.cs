using AutoMapper;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Queries;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.Mapping.Products
{
    public class ListProductsQueryResponseProfile : Profile
    {
        public ListProductsQueryResponseProfile()
        {
            CreateMap<ListReadModel<ProductIdNameReadModel>, ListProductsQueryResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e.Records))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(e => e.TotalRecords));

            CreateMap<ProductIdNameReadModel, ListProductsRecordQueryResponse>();
        }
    }
}