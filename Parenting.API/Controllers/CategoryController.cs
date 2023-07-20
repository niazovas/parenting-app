using Parenting.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Interfaces;
using Parenting.Server.Services;
using Parenting.Server.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Parenting.Server.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public Task<List<GetCategoryDto>> GetCategories()
        {
            return _categoryService.GetCategories();
        }


        [HttpGet("{categoryId}")]
        public Task<GetCategoryDto> GetCategory(int categoryId)
        {
            return _categoryService.GetCategory(categoryId);
        }


        [HttpPost]
        public Task<GetCategoryDto> CreateCategory([FromBody] AddCategoryDto categorycreate)
        {
            return _categoryService.CreateCategory(categorycreate);
        }


        [HttpPut]
        public Task<GetCategoryDto> UpdateCategory(UpdateCategoryDto categoryUpdate)
        {
            return _categoryService.UpdateCategory(categoryUpdate);
        }


        [HttpDelete("{categoryId}")]
        public Task<List<GetCategoryDto>> DeleteCategory(int categoryId)
        {
            return _categoryService.DeleteCategory(categoryId);
        }


    }
}

