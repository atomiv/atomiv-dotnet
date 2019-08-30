using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;

namespace Optivem.Cli.Infrastructure.AutoMapper.MyFoos
{
    public class FindMyFooResponseProfile : ResponseProfile<MyFoo, FindMyFooResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, FindMyFooResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}