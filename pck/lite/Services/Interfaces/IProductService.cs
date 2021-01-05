using Atomiv.Template.Lite.Dtos.Products;
using Atomiv.Template.Lite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Services.Interfaces
{
	public interface IProductService
	{
		public Task<GetProductsQueryResponse> GetProducts();

		public Task<GetProductQueryResponse> GetProduct(int id);

		public Task<UpdateProductCommandResponse> UpdateProduct(UpdateProductCommand request);

		public Task<CreateProductCommandResponse> CreateProduct(CreateProductCommand request);

		public Task<DeleteProductCommandResponse> DeleteProduct(int id);

	}
}
