using Parenting.Server.Dto;

namespace Parenting.Server.Interfaces
{
	public interface ISubCategoryService
	{
        Task<List<GetSubCategoryDto>> GetSubCategories();
        Task<GetSubCategoryDto> GetSubCategory(int id);
        Task<GetSubCategoryDto> CreateSubCategory(AddSubCategoryDto newSubcategory);
        Task<GetSubCategoryDto> UpdateSubCategory(UpdateSubCategoryDto updateSubcategory);
        Task<List<GetSubCategoryDto>> DeleteSubCategory(int id);
        
    }
}

