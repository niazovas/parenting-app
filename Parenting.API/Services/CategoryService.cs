using Parenting.Server.Interfaces;
using Parenting.Server.Data;
using Parenting.Server.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Parenting.Server.Dto;

namespace Parenting.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private DataContext _context;
        private IMapper _mapper;
        public CategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Add
        public async Task<GetCategoryDto> CreateCategory(AddCategoryDto newcategory)
        {
            var addcategory = _mapper.Map<Category>(newcategory);
            _context.Categories.Add(addcategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetCategoryDto>(addcategory);
        }



        //Delete
        public async Task<List<GetCategoryDto>> DeleteCategory(int id)
        {
            var category = await _context.Categories
                 .FirstOrDefaultAsync(e => e.Id == id);
            if (category is null)
                throw new Exception($"Character with Id '{id}' is not found.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            var categories = await _context.Categories.ToListAsync();
            return categories.Select(e=>_mapper.Map<GetCategoryDto>(e)).ToList();
        }



        //GetAll
        public async Task<List<GetCategoryDto>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(e => _mapper.Map<GetCategoryDto>(e)).ToList();
        }


        //GetByID
        public async Task<GetCategoryDto> GetCategory(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<GetCategoryDto>(category);
        }


        //Update
        public async Task<GetCategoryDto> UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var newCategory = await _context.Categories
                 .FirstOrDefaultAsync(e => e.Id == updateCategory.Id);

            if (newCategory is null)
                throw new Exception($"Category with Id '{updateCategory.Id}' is not found.");

            newCategory.Name = updateCategory.Name;
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCategoryDto>(newCategory);
        }
    }
}

