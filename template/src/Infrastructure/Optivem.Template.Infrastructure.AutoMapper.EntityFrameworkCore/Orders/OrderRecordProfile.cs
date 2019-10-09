using AutoMapper;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Optivem.Template.Infrastructure.AutoMapper.EntityFrameworkCore.Orders
{
    public class OrderRecordProfile : Profile
    {
        public OrderRecordProfile()
        {
            CreateMap<Order, OrderRecord>()
                .ForMember(dest => dest.OrderStatusRecordId, opt => opt.MapFrom(e => (int)e.Status))
                .ForMember(dest => dest.OrderStatusRecord, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerRecordId, opt => opt.MapFrom(e => e.CustomerId.Id))
                ;

            CreateMap<OrderDetail, OrderDetailRecord>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id))
                .ForMember(dest => dest.StatusRecordId, opt => opt.MapFrom(e => (int)e.Status))
                .ForMember(dest => dest.OrderDetailStatusRecord, opt => opt.Ignore())
                ;

            CreateMap<OrderRecord, IEnumerable<Expression<Func<OrderRecord, object>>>>()
                .ConvertUsing(e => new List<Expression<Func<OrderRecord, object>>> { f => f.OrderDetailRecords });
        }


    }
}
