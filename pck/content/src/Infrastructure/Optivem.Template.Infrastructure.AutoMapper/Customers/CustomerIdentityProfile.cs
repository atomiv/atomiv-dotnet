using AutoMapper;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class CustomerIdentityProfile : Profile
    {
        public CustomerIdentityProfile()
        {
            CreateMap<int, CustomerIdentity>()
                .ConvertUsing(src => new CustomerIdentity(src));

            CreateMap<CustomerIdentity, int>()
                .ConvertUsing(src => src.Id);
        }
    }
}