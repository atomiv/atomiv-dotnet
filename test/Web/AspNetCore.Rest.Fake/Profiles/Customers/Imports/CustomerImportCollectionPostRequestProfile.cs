using AutoMapper;
using Optivem.Web.AspNetCore.Fake.Entities;
using Optivem.Web.AspNetCore.Fake.Models;
using Optivem.Infrastructure.Mapping.AutoMapper;
using System;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.Fake.Profiles.Customers.Imports
{
    public class CustomerImportCollectionPostRequestProfile : RequestProfile<CustomerImportCollectionPostRequest, Customer>
    {
        protected override void Extend(IMappingExpression<CustomerImportCollectionPostRequest, Customer> map)
        {
            map.ForMember(e => e.Id, e => e.MapFrom(s => 0))
                .ForMember(e => e.CreatedDateTime, e => e.MapFrom(s => DateTime.Now))
                .ForMember(e => e.ModifiedDateTime, e => e.MapFrom(s => DateTime.Now))
                .ForMember(e => e.Cards, e => e.MapFrom(s => new List<Card>()));
        }
    }
}
