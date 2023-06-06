using Parenting.Server.Models;
namespace Parenting.Server.Interfaces
{
	public interface ISubCategoryRepository
	{
        Task<ICollection<SubCategory>> GetSubCategories();
        Task<SubCategory?> GetSubCategory(int id);
        Task<bool> CreateSubCategory(SubCategory subcategory);
        Task<bool> UpdateSubCategory(SubCategory subcategory);
        Task<bool> DeleteSubCategory(SubCategory subcategory);
        Task<bool> Save();
    }
}

