using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Cli.Infrastructure.AutoMapper.MyFoos
{
    public class ListMyFoosResponseProfile : ResponseProfile<IEnumerable<MyFoo>, ListMyFoosResponse>
    {
        protected override void Extend(IMappingExpression<IEnumerable<MyFoo>, ListMyFoosResponse> map)
        {
            map.ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));
        }
    }

    public class ListMyFoosRecordResponseProfile : ResponseProfile<MyFoo, ListMyFoosRecordResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, ListMyFoosRecordResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}
