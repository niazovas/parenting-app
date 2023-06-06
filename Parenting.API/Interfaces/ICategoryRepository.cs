using Parenting.Server.Models;

namespace Parenting.Server.Services
{
	public interface ICategoryRepository
	{
        Task<ICollection<Category>> GetCategories();
        Task<Category?> GetCategory(int id);
        Task<bool> CreateCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(Category category);
        Task<bool> Save();
       
    }
}

