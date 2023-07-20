using Parenting.Server.Data;
using Parenting.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Parenting.Server.Dto;
using Parenting.Server.Models;

namespace Parenting.Server.Repository
{
    public class SubCategoryService : ISubCategoryService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public SubCategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetSubCategoryDto>> GetSubCategories()
        {
            var products = await _context.SubCategories.ToListAsync();
            return products.Select(e => _mapper.Map<GetSubCategoryDto>(e)).ToList();

        }

        public async Task<GetSubCategoryDto> GetSubCategory(int id)
        {
            var subcategory = await _context.SubCategories
                 .FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<GetSubCategoryDto>(subcategory);
        }

        public async Task<GetSubCategoryDto> CreateSubCategory(AddSubCategoryDto newSubcategory)
        {
            var subcategory = _mapper.Map<SubCategory>(newSubcategory);
            _context.SubCategories.Add(subcategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetSubCategoryDto>(subcategory);
        }

        public async Task<GetSubCategoryDto> UpdateSubCategory(UpdateSubCategoryDto updateSubcategory)
        {
            var subcategry = await _context.SubCategories
                .FirstOrDefaultAsync(e => e.Id == updateSubcategory.Id);
            if (subcategry is null)
                throw new Exception("Not found!");

            subcategry.Name = updateSubcategory.Name;
            subcategry.CategoryId = updateSubcategory.Id;
            await _context.SaveChangesAsync();
            return _mapper.Map<GetSubCategoryDto>(subcategry);


        }

        public async Task<List<GetSubCategoryDto>> DeleteSubCategory(int id)
        {
            var subcategory = await _context.SubCategories
                  .FirstOrDefaultAsync(e => e.Id == id);
            if (subcategory is null)
                throw new Exception("Not Found");
            _context.SubCategories.Remove(subcategory);
            await _context.SaveChangesAsync();

            var products = await _context.SubCategories.ToListAsync();
            return products.Select(e => _mapper.Map<GetSubCategoryDto>(e)).ToList();


        }
    }
}

