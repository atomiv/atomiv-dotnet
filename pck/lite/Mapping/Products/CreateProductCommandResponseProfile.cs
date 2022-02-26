using Atomiv.Template.Lite.Dtos.Products;
using Atomiv.Template.Lite.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Products
{
	public class CreateProductCommandResponseProfile : Profile
	{
		public CreateProductCommandResponseProfile()
		{
			CreateMap<Product, CreateProductCommandResponse>();
		}
	}
}
