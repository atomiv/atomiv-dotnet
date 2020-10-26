using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Dtos.Orders;
using Atomiv.Template.Lite.Models;
using Atomiv.Template.Lite.Repositories.Interfaces;
using Atomiv.Template.Lite.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

		public OrderService(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}

		public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request)
		{
			var order = _mapper.Map<CreateOrderRequest, Order>(request);
			order = await _orderRepository.CreateOrder(order);
			return _mapper.Map<Order, CreateOrderResponse>(order);
		}

		public async Task<DeleteOrderResponse> DeleteOrder(int id)
		{
			var order = await _orderRepository.DeleteOrder(id);
			return _mapper.Map<Order, DeleteOrderResponse>(order);
		}


		public async Task<GetOrderResponse> GetOrder(int id)
		{
			var order = await _orderRepository.GetOrder(id);
			return _mapper.Map<Order, GetOrderResponse>(order);
		}
		
		
		public async Task<GetOrdersResponse> GetOrders()
		{
			var orders = await _orderRepository.GetOrders();
			return _mapper.Map<IEnumerable<Order>, GetOrdersResponse>(orders);
		}


		public async Task<UpdateOrderResponse> UpdateOrder(UpdateOrderRequest request)
		{
			var order = _mapper.Map<UpdateOrderRequest, Order>(request);
			order = await _orderRepository.UpdateOrder(order);
			return _mapper.Map<Order, UpdateOrderResponse>(order);
		}


	}
}
