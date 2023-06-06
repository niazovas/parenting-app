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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;
        public SubCategoryController(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            var entities = await _subCategoryRepository.GetSubCategories();
            var subCategories=_mapper.Map<List<SubCategoryDto>>(entities);
            return Ok(subCategories);
        }


        [HttpGet("{subCategoryId}")]
        public async Task<IActionResult> GetSubCategories(int subCategoryId)
        {
            var entities = await _subCategoryRepository.GetSubCategory(subCategoryId);
            var subCategories = _mapper.Map<List<SubCategoryDto>>(entities);
            return Ok(subCategories);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryDto subCategoryCreate)
        {
            var subCategoryMap = _mapper.Map<SubCategory>(subCategoryCreate);
            await _subCategoryRepository.CreateSubCategory(subCategoryMap);
            return Ok("Successfully created");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSubCategory(SubCategoryDto subCategoryUpdate)
        {
            var subCategoryToUpdate = await _subCategoryRepository.GetSubCategory(subCategoryUpdate.Id);

            if (subCategoryToUpdate == null)
                return NotFound();

            subCategoryToUpdate.Name = subCategoryUpdate.Name;
            subCategoryToUpdate.CategoryId = subCategoryUpdate.CategoryId;
            await _subCategoryRepository.UpdateSubCategory(subCategoryToUpdate);
            return Ok("Successfully Updated");
        }



        [HttpDelete("{subCategoryId}")]
        public async Task<IActionResult> DeleteSubCategory(int subCategoryId)
        {
            var subCategoryToDelete = await _subCategoryRepository.GetSubCategory(subCategoryId);

            if (subCategoryToDelete == null)
                return NotFound();

            await _subCategoryRepository.DeleteSubCategory(subCategoryToDelete);
            return Ok("Successfully Deleted");
        }
    }
}

