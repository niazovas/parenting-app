using AutoMapper;
using Parenting.Server.Dto;
using Parenting.Server.Models;

namespace Parenting.Server.Helper
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<Product, ProductResponceDto>().ReverseMap();
		}
	}
}

