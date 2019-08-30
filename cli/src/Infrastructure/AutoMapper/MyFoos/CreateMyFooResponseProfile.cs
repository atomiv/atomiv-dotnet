using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;

namespace Optivem.Cli.Infrastructure.AutoMapper.MyFoos
{
    public class CreateMyFooResponseProfile : ResponseProfile<MyFoo, CreateMyFooResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, CreateMyFooResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}