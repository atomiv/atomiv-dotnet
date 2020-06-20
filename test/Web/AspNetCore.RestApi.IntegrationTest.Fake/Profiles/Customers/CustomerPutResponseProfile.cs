using AutoMapper;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerPutResponseProfile : Profile
    {
        public CustomerPutResponseProfile()
        {
            CreateMap<Customer, CustomerPutResponse>();
        }
    }
}