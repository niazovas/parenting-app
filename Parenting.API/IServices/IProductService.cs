using Parenting.Server.Dto;
using Parenting.Server.Models;

namespace Parenting.Server.Interfaces
{
	public interface IProductService
	{
        Task<List<GetProductDto>> GetProducts(); 
        Task<GetProductDto> GetProduct(int id);
        Task<GetProductDto> CreateProduct(AddProductDto newProduct);
        Task<GetProductDto> UpdateProduct(UpdateProductDto updateProduct);
        Task<List<GetProductDto>> DeleteProduct(int id);
        
    }
}

