using AutoMapper;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetSubsetResponseProfile : Profile
    {
        public CustomerGetSubsetResponseProfile()
        {
            CreateMap<Customer, CustomerGetSubsetResponse>();
        }
    }
}