using AutoMapper;
using Parenting.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Models;
using Parenting.Server.Interfaces;
using Parenting.Server.Services;
using Parenting.Server.Repository;


namespace Parenting.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var entities = await _categoryRepository.GetCategories();
            var categories =_mapper.Map<List<CategoryDto>>(entities);
            return Ok(categories);
        }


        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategories(int categoryId)
        {
            var entities = await _categoryRepository.GetCategory(categoryId);
            var category = _mapper.Map<CategoryDto>(entities);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categorycreate)
        {
            var categoryMap = _mapper.Map<Category>(categorycreate);
            await _categoryRepository.CreateCategory(categoryMap);
            return Ok("Successfully created");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory( CategoryDto categoryUpdate)
        {
            var categoryToUpdate = await _categoryRepository.GetCategory(categoryUpdate.Id);

            if (categoryToUpdate == null)
                return NotFound();

            categoryToUpdate.Name = categoryUpdate.Name;
            await _categoryRepository.UpdateCategory(categoryToUpdate);
            return Ok("Successfully updated");

        }


        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var categorytodelete=await _categoryRepository.GetCategory(categoryId);

            if (categorytodelete == null)
                return NotFound();

            await _categoryRepository.DeleteCategory(categorytodelete);
            return NoContent();
        }


     }
}

