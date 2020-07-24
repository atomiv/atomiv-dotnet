using AutoMapper;
using Atomiv.Template.Core.Domain.Products;
using System;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Common
{
    public class ProductIdentityProfile : Profile
    {
        public ProductIdentityProfile()
        {
            CreateMap<ProductIdentity, Guid>()
                .ConvertUsing(src => GetGuid(src.Value));
        }

        // TODO: VC: DELETE

        // TODO: VC: Move up
        private Guid GetGuid(Guid value)
        {
            return value;

            /*
            var success = Guid.TryParse(value, out Guid result);

            return result;
            */
        }
    }
}