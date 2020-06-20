using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;

namespace Cli.Infrastructure.AutoMapper.MyFoos
{
    public class UpdateMyFooResponseProfile : ResponseProfile<MyFoo, UpdateMyFooResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, UpdateMyFooResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}
