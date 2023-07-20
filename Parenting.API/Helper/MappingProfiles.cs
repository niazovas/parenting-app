using AutoMapper;
using Parenting.Server.Dto;
using Parenting.Server.Models;

namespace Parenting.Server.Helper
{
	public class MappingProfiles:Profile
	{
		public MappingProfiles()
		{
			CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<SubCategory, UpdateSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, AddSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, GetSubCategoryDto>().ReverseMap();

            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();

            CreateMap<Photo, AddPhotoDto>().ReverseMap();
            CreateMap<Photo, GetPhotoDto>().ReverseMap();
            CreateMap<Photo, UpdatePhotoDto>().ReverseMap();

        }
	}
}

