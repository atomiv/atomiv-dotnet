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

		public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
		{
			var product = _mapper.Map<CreateProductRequest, Product>(request);
			product = await _productRepository.CreateProduct(product);
			return _mapper.Map<Product, CreateProductResponse>(product);
		}

		public async Task<DeleteProductResponse> DeleteProduct(int id)
		{
			var product = await _productRepository.DeleteProduct(id);
			return _mapper.Map<Product, DeleteProductResponse>(product);
		}

		public async Task<GetProductResponse> GetProduct(int id)
		{
			var product = await _productRepository.GetProduct(id);
			return _mapper.Map<Product, GetProductResponse>(product);
		}

		public async Task<GetProductsResponse> GetProducts()
		{
			var products = await _productRepository.GetProducts();
			return _mapper.Map<IEnumerable<Product>, GetProductsResponse>(products);
		}

		public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
		{
			var product = _mapper.Map<UpdateProductRequest, Product>(request);
			product = await _productRepository.UpdateProduct(product);
			return _mapper.Map<Product, UpdateProductResponse>(product);
		}

	}
}
