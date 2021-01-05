using Atomiv.Template.Lite.Dtos.Products;
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
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<CreateProductCommandResponse> CreateProduct(CreateProductCommand request)
		{
			var product = _mapper.Map<CreateProductCommand, Product>(request);
			product = await _productRepository.CreateProduct(product);
			return _mapper.Map<Product, CreateProductCommandResponse>(product);
		}

		public async Task<DeleteProductCommandResponse> DeleteProduct(int id)
		{
			var product = await _productRepository.DeleteProduct(id);
			return _mapper.Map<Product, DeleteProductCommandResponse>(product);
		}

		public async Task<GetProductQueryResponse> GetProduct(int id)
		{
			var product = await _productRepository.GetProduct(id);
			return _mapper.Map<Product, GetProductQueryResponse>(product);
		}

		public async Task<GetProductsQueryResponse> GetProducts()
		{
			var products = await _productRepository.GetProducts();
			return _mapper.Map<IEnumerable<Product>, GetProductsQueryResponse>(products);
		}

		public async Task<UpdateProductCommandResponse> UpdateProduct(UpdateProductCommand request)
		{
			var product = _mapper.Map<UpdateProductCommand, Product>(request);
			product = await _productRepository.UpdateProduct(product);
			return _mapper.Map<Product, UpdateProductCommandResponse>(product);
		}

	}
}
