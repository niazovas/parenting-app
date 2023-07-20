using Parenting.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Models;
using Parenting.Server.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Parenting.Server.Controllers
{


    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IWebHostEnvironment _environment;


        public ProductController(IProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }


        [HttpGet]
        public Task<List<GetProductDto>> GetProducts()
        {
            return _productService.GetProducts();
        }


        [HttpGet("{productId}")]
        public Task<GetProductDto> GetProduct(int productId)
        {
            return _productService.GetProduct(productId);
        }


        [HttpPost]
        public Task<GetProductDto> CreateProduct([FromForm] AddProductDto productAdd)
        {
            return _productService.CreateProduct(productAdd);
        }

        [HttpPut]
        public Task<GetProductDto> UpdateProduct(UpdateProductDto updateProduct)
        {
            return _productService.UpdateProduct(updateProduct);
        }


        [HttpDelete("{productId}")]
        public Task<List<GetProductDto>> DeleteProduct(int productId)
        {
            return _productService.DeleteProduct(productId);
        }


        private async Task SaveFile(Stream stream, string fileName)
        {
            var fullName = Path.Combine(_environment.WebRootPath, "images", fileName);

            await using FileStream fileStream = new(fullName, FileMode.OpenOrCreate);
            var buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = await stream.ReadAsync(buffer)) > 0)
            {
                await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));
            }
        }
    }
}