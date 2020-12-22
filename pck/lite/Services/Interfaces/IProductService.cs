using Atomiv.Template.Lite.Dtos.Products;
using Atomiv.Template.Lite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface IProductService
	{
		public Task<GetProductsResponse> GetProducts();

		public Task<GetProductResponse> GetProduct(int id);

		public Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request);

		public Task<CreateProductResponse> CreateProduct(CreateProductRequest request);

		public Task<DeleteProductResponse> DeleteProduct(int id);

	}
}
