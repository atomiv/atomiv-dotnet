using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;

namespace Cli.Infrastructure.AutoMapper.MyFoos
{
    public class FindMyFooResponseProfile : ResponseProfile<MyFoo, FindMyFooResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, FindMyFooResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}