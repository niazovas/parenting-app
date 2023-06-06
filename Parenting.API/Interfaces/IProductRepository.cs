using System.Collections.ObjectModel;
using Parenting.Server.Models;
namespace Parenting.Server.Interfaces
{
	public interface IProductRepository
	{
        Task<ICollection<Product>> GetProducts();
        Task<Product?> GetProduct(int id);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task <bool> Save();
    }
}

