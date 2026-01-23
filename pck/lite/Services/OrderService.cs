using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Dtos.Orders;
using Atomiv.Template.Lite.Entities;
using Atomiv.Template.Lite.Repositories.Interfaces;
using Atomiv.Template.Lite.Services.Interfaces;
using MapsterMapper;
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

		public async Task<CreateOrderCommandResponse> CreateOrder(CreateOrderCommand request)
		{
			var order = _mapper.Map<CreateOrderCommand, Order>(request);
			order = await _orderRepository.CreateOrder(order);
			return _mapper.Map<Order, CreateOrderCommandResponse>(order);
		}

		public async Task<DeleteOrderCommandResponse> DeleteOrder(int id)
		{
			var order = await _orderRepository.DeleteOrder(id);
			return _mapper.Map<Order, DeleteOrderCommandResponse>(order);
		}


		public async Task<GetOrderQueryResponse> GetOrder(int id)
		{
			var order = await _orderRepository.GetOrder(id);
			return _mapper.Map<Order, GetOrderQueryResponse>(order);
		}
		
		
		public async Task<GetOrdersQueryResponse> GetOrders()
		{
			var orders = await _orderRepository.GetOrders();
			return _mapper.Map<IEnumerable<Order>, GetOrdersQueryResponse>(orders);
		}


		public async Task<UpdateOrderCommandResponse> UpdateOrder(UpdateOrderCommand request)
		{
			var order = _mapper.Map<UpdateOrderCommand, Order>(request);
			order = await _orderRepository.UpdateOrder(order);
			return _mapper.Map<Order, UpdateOrderCommandResponse>(order);
		}


	}
}
