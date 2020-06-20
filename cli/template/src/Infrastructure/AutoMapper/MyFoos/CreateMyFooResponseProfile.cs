using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;

namespace Cli.Infrastructure.AutoMapper.MyFoos
{
    public class CreateMyFooResponseProfile : ResponseProfile<MyFoo, CreateMyFooResponse>
    {
        protected override void Extend(IMappingExpression<MyFoo, CreateMyFooResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}