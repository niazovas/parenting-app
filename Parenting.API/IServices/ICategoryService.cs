
using Parenting.Server.Dto;

namespace Parenting.Server.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetCategories();
        Task<GetCategoryDto> GetCategory(int id);
        Task<GetCategoryDto> CreateCategory(AddCategoryDto newcategory);
        Task<GetCategoryDto> UpdateCategory(UpdateCategoryDto updateCategory);
        Task<List<GetCategoryDto>> DeleteCategory(int id);


    }
}

