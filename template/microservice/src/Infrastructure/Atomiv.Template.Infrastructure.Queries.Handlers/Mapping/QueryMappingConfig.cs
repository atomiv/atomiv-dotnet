using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using Mapster;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Mapping
{
    public static class QueryMappingConfig
    {
        public static void Configure()
        {
            // Product query mappings
            TypeAdapterConfig<Product, ViewProductQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Code, src => src.ProductCode)
                .Map(dest => dest.Description, src => src.ProductName)
                .Map(dest => dest.UnitPrice, src => src.ListPrice);

            TypeAdapterConfig<Product, BrowseProductsRecordResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Code, src => src.ProductCode)
                .Map(dest => dest.Description, src => src.ProductName)
                .Map(dest => dest.UnitPrice, src => src.ListPrice);

            TypeAdapterConfig<Product, ListProductsRecordQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Name, src => src.ProductName);

            // Customer query mappings
            TypeAdapterConfig<Customer, ViewCustomerQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value);

            TypeAdapterConfig<Customer, BrowseCustomersRecordResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value);

            TypeAdapterConfig<Customer, ListCustomersRecordResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value);

            // Order query mappings
            TypeAdapterConfig<Order, ViewOrderQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.CustomerId, src => src.CustomerId.Value);

            TypeAdapterConfig<Order, BrowseOrdersRecordQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.CustomerId, src => src.CustomerId.Value);

            TypeAdapterConfig<Order, ListOrdersRecordQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value);

            TypeAdapterConfig<OrderItem, FindOrderItemQueryResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value);
        }
    }
}
