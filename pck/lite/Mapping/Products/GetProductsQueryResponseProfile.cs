using Atomiv.Template.Lite.Dtos.Products;
using Atomiv.Template.Lite.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Products
{
	public class GetProductsResponseMap : Profile
	{
		public GetProductsResponseMap()
		{
			CreateMap<IEnumerable<Product>, GetProductsQueryResponse>()
				.ForMember(dest => dest.Records, opt => opt.MapFrom(e => e));

			CreateMap<Product, GetProductsRecordResponse>();
		}
	}
}
