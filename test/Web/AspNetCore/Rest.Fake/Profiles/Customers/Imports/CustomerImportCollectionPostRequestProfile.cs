using AutoMapper;
using Optivem.Framework.Infrastructure.Application.Mappers.AutoMapper;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Entities;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Models;
using System;
using System.Collections.Generic;

namespace Optivem.Framework.Web.AspNetCore.Rest.Fake.Profiles.Customers.Imports
{
    public class CustomerImportCollectionPostRequestProfile : AutoMapperRequestProfile<CustomerImportCollectionPostRequest, Customer>
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
