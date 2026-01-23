using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using Mapster;

namespace Atomiv.Template.Infrastructure.Commands.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            // Customer mappings - map from domain entities to command responses
            TypeAdapterConfig<Customer, CreateCustomerCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName);

            // Product mappings
            TypeAdapterConfig<Product, CreateProductCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Code, src => src.ProductCode)
                .Map(dest => dest.Description, src => src.ProductName)
                .Map(dest => dest.UnitPrice, src => src.ListPrice);

            // EditProduct mappings
            TypeAdapterConfig<Product, EditProductCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Code, src => src.ProductCode)
                .Map(dest => dest.Description, src => src.ProductName)
                .Map(dest => dest.UnitPrice, src => src.ListPrice)
                .Map(dest => dest.IsListed, src => src.IsListed);

            // RelistProduct mappings
            TypeAdapterConfig<Product, RelistProductCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.IsListed, src => src.IsListed);

            // UnlistProduct mappings
            TypeAdapterConfig<Product, UnlistProductCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.IsListed, src => src.IsListed);

            // Order item mappings (must be configured before Order mappings)
            TypeAdapterConfig<OrderItem, CreateOrderItemResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.Status, src => src.Status);

            // UpdateOrderItem mappings
            TypeAdapterConfig<OrderItem, UpdateOrderItemCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.Status, src => src.Status);

            // IReadonlyOrderItem to CreateOrderItemResponse mapping
            TypeAdapterConfig<IReadonlyOrderItem, CreateOrderItemResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.Status, src => src.Status);

            // IReadonlyOrderItem to UpdateOrderItemCommandResponse mapping
            TypeAdapterConfig<IReadonlyOrderItem, UpdateOrderItemCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ProductId, src => src.ProductId.Value)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.Status, src => src.Status);

            // Order mappings
            TypeAdapterConfig<Order, CreateOrderCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.CustomerId, src => src.CustomerId.Value)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.OrderItems, src => src.OrderItems);

            // EditOrder mappings
            TypeAdapterConfig<Order, EditOrderCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.CustomerId, src => src.CustomerId.Value)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.OrderItems, src => src.OrderItems);

            // CancelOrder mappings
            TypeAdapterConfig<Order, CancelOrderCommandResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Status, src => src.Status);
        }
    }
}
