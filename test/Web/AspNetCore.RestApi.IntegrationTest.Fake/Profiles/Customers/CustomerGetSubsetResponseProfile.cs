using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;

namespace Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetSubsetResponseProfile : Profile
    {
        public CustomerGetSubsetResponseProfile()
        {
            CreateMap<Customer, CustomerGetSubsetResponse>();
        }
    }
}