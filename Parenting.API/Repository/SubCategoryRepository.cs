using Parenting.Server.Models;
using Parenting.Server.Data;
using Parenting.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Parenting.Server.Repository
{
	public class SubCategoryRepository:ISubCategoryRepository
	{
        private DataContext _context;
        public SubCategoryRepository(DataContext context)
		{
			_context = context;
		}

        public async Task<bool> CreateSubCategory(SubCategory subcategory)
        {
            _context.Add(subcategory);
            return await Save();

        }

        public async Task<bool> DeleteSubCategory(SubCategory subcategory)
        {
            _context.Remove(subcategory);
            return await Save();
        }

        public async Task<SubCategory?> GetSubCategory(int id)
        {
            return await _context.SubCategories.Where(e => e.Id == id).SingleOrDefaultAsync();
        }

        public async Task<ICollection<SubCategory>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved =await _context.SaveChangesAsync();
            return saved > 0 ? true : false;

        }

     
        public async Task<bool> UpdateSubCategory(SubCategory subcategory)
        {
            _context.Update(subcategory);
            return await Save();
        }
    }
}

