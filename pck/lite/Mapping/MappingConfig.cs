using Atomiv.Template.Dtos.Customers;
using Atomiv.Template.Dtos.Orders;
using Atomiv.Template.Dtos.Products;
using Atomiv.Template.Entities;
using Mapster;
using System;

namespace Atomiv.Template.Lite.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            // Customer mappings
            TypeAdapterConfig<Customer, CustomerDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id);

            TypeAdapterConfig<CustomerDto, Customer>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id);

            // Product mappings
            TypeAdapterConfig<Product, ProductDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id);

            TypeAdapterConfig<ProductDto, Product>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id);

            // Order mappings
            TypeAdapterConfig<Order, OrderDto>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId);

            TypeAdapterConfig<OrderDto, Order>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomerId, src => src.CustomerId);

            TypeAdapterConfig<OrderItem, OrderItemDto>
                .NewConfig()
                .Map(dest => dest.ProductId, src => src.ProductId);

            TypeAdapterConfig<OrderItemDto, OrderItem>
                .NewConfig()
                .Map(dest => dest.ProductId, src => src.ProductId);
        }
    }
}
