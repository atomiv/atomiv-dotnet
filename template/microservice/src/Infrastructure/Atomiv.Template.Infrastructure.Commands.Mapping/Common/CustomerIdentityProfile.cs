using AutoMapper;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Common
{
    public class CustomerIdentityProfile : Profile
    {
        public CustomerIdentityProfile()
        {
            CreateMap<CustomerIdentity, string>()
                .ConvertUsing(src => src.Value);
        }
    }
}