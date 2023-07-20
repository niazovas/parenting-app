using Parenting.Server.Interfaces;
using Parenting.Server.Data;
using Parenting.Server.Models;
using Microsoft.EntityFrameworkCore;
using Parenting.Server.Dto;
using AutoMapper;

namespace Parenting.Server.Repository
{
    public class ProductService : IProductService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //GetAll
        public async Task<List<GetProductDto>> GetProducts()
        {
            var products = await _context.Photos.ToListAsync();
            return products.Select(e => _mapper.Map<GetProductDto>(e)).ToList();
        }

        //GetByID
        public async Task<GetProductDto> GetProduct(int id)
        {
            var product = await _context.Photos
                 .FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<GetProductDto>(product);
        }

        //Add
        public async Task<GetProductDto> CreateProduct(AddProductDto newProduct)
        {
            var addproduct = _mapper.Map<Product>(newProduct);
            _context.Products.Add(addproduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetProductDto>(addproduct);
        }

        //Update
        public async Task<GetProductDto> UpdateProduct(UpdateProductDto productUpdate)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(e => e.Id == productUpdate.Id);
            if (product is null)
                throw new Exception("$\"Product with Id '{updateCategory.Id}' is not found.\"");
            product.Name = productUpdate.Name;
            product.Discription = productUpdate.Discription;
            product.SubCategoryId = productUpdate.SubCategoryId;
            await _context.SaveChangesAsync();
            return _mapper.Map<GetProductDto>(product);
        }

        //Delete
        public async Task<List<GetProductDto>> DeleteProduct(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(e => e.Id == id);
            if (product is null)
                throw new Exception("$\"Product with Id '{updateCategory.Id}' is not found.\"");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            var products = await _context.Photos.ToListAsync();
            return products.Select(e => _mapper.Map<GetProductDto>(e)).ToList();

        }
    }
}

