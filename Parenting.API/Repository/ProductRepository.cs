using Parenting.Server.Interfaces;
using Parenting.Server.Data;
using Parenting.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Parenting.Server.Repository
{
	public class ProductRepository: IProductRepository
	{
        private DataContext _context;
        public ProductRepository(DataContext context)
		{
            _context = context;
		}

        public async Task<bool> CreateProduct(Product product)
        {
             await _context.AddAsync(product);
            return  await Save();
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _context.Remove(product);
            return await Save();
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
           return await _context.Products.Where(e => e.Id == id).SingleOrDefaultAsync();
        }

      
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Update(product);
            return await Save();  
        }
    }
}

