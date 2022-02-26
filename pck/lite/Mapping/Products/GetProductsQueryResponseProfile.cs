using Atomiv.Template.Lite.Dtos.Products;
using Atomiv.Template.Lite.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Products
{
	public class GetProductsQueryResponseProfile : Profile
	{
		public GetProductsQueryResponseProfile()
		{
			CreateMap<IEnumerable<Product>, GetProductsQueryResponse>()
				.ForMember(dest => dest.Records, opt => opt.MapFrom(e => e));

			CreateMap<Product, GetProductsRecordResponse>();
		}
	}
}
