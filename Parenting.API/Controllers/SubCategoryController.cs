using AutoMapper;
using Parenting.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Models;
using Parenting.Server.Interfaces;
using Parenting.Server.Services;
using Parenting.Server.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Parenting.Server.Controllers
{

    
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {

        private readonly ISubCategoryService _subcategoryService;

        public SubCategoryController(ISubCategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }


        [HttpGet]
        public Task<List<GetSubCategoryDto>> GetSubCategories()
        {
            return _subcategoryService.GetSubCategories();
        }


        [HttpGet("{subCategoryId}")]
        public Task<GetSubCategoryDto> GetSubCategories(int subCategoryId)
        {
            return _subcategoryService.GetSubCategory(subCategoryId);
        }


        [HttpPost]
        public Task<GetSubCategoryDto> CreateSubCategory([FromBody] AddSubCategoryDto subCategoryCreate)
        {
            return _subcategoryService.CreateSubCategory(subCategoryCreate);
        }


        [HttpPut]
        public Task<GetSubCategoryDto> UpdateSubCategory(UpdateSubCategoryDto subCategoryUpdate)
        {
            return _subcategoryService.UpdateSubCategory(subCategoryUpdate);
        }



        [HttpDelete("{subCategoryId}")]
        public Task<List<GetSubCategoryDto>> DeleteSubCategory(int subCategoryId)
        {
            return _subcategoryService.DeleteSubCategory(subCategoryId);
        }
    }
}

