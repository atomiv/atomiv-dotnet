using AutoMapper;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.EntityFrameworkCore.Products
{
    public class ProductRecordProfile : Profile
    {
        public ProductRecordProfile()
        {
            CreateMap<Product, ProductRecord>();
            /*
                .ConstructUsing(e => new ProductRecord
                {
                    Id = e.Id.Id,
                    ProductCode = e.ProductCode,
                    ProductName = e.ProductName,
                    ListPrice = e.ListPrice,
                });
            */

            CreateMap<ProductRecord, Product>()
                .ConstructUsing(e => new Product(new ProductIdentity(e.Id), e.ProductCode, e.ProductName, e.ListPrice));

            CreateMap<ProductIdentity, ProductRecord>()
                .ConstructUsing(e => new ProductRecord
                {
                    Id = e.Id,
                });
        }
    }
}
