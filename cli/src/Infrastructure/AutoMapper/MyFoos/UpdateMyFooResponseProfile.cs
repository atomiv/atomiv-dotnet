using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;

namespace Optivem.Cli.Infrastructure.AutoMapper.MyFoos
{
    public class UpdateMyFooResponseProfile : ResponseProfile<MyFoo, UpdateMyFooResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, UpdateMyFooResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}
