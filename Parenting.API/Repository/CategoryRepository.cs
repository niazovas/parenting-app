using Parenting.Server.Interfaces;
using Parenting.Server.Data;
using Parenting.Server.Models;


using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Parenting.Server.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

       
        public async Task<bool> CreateCategory(Category category)
        {
            _context.Add(category);
            return await Save();
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            _context.Remove(category);
            return await Save();
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved =await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateCategory(Category category)
        {   
            _context.Update(category);
            return await Save();
        }
    }
}

	