using AutoMapper;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Models;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetResponseProfile : Profile
    {
        public CustomerGetResponseProfile()
        {
            CreateMap<Customer, CustomerGetResponse>();
        }
    }
}