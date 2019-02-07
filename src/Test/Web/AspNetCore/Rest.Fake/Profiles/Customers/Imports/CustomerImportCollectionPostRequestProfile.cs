using Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Entities;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Profiles.Customers.Imports
{
    public class CustomerImportCollectionPostRequestProfile : AutoMapperRequestProfile<CustomerImportCollectionPostRequest, Customer>
    {
        public CustomerImportCollectionPostRequestProfile()
        {
            // TODO: VC: Check custom mappings

            map.ForMember(e => e.Id, e => e.MapFrom(s => 0))
                .ForMember(e => e.CreatedDateTime, e => e.MapFrom(s => DateTime.Now))
                .ForMember(e => e.ModifiedDateTime, e => e.MapFrom(s => DateTime.Now))
                .ForMember(e => e.Cards, e => e.MapFrom(s => new List<Card>()));
        }
    }
}
