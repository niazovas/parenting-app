using AutoMapper;
using Parenting.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Parenting.Server.Models;
using Parenting.Server.Interfaces;
using Parenting.Server.Services;
using Parenting.Server.Repository;
using Microsoft.EntityFrameworkCore;

namespace Parenting.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _environment = environment;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var entities = await _productRepository.GetProducts();
            var products = _mapper.Map<List<ProductResponceDto>>(entities);
            return Ok(products);
        }


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var entities = await _productRepository.GetProduct(productId);
            var product = _mapper.Map<ProductResponceDto>(entities);
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDto productcreate)
        {
            var productMap = _mapper.Map<Product>(productcreate);
            var path = Path.Combine(_environment.WebRootPath, "Images/", productcreate.ImagePath.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await productcreate.ImagePath.CopyToAsync(stream);
                stream.Close();

                productMap.ImagePath = path;
                await _productRepository.CreateProduct(productMap);
                return Ok("Successfully created");
            }
        }

            [HttpPut]
            public async Task<IActionResult> UpdateProduct(ProductDto updateProduct)
            {
                var producToUpdate = await _productRepository.GetProduct(updateProduct.Id);

                if (producToUpdate == null)
                    return NotFound();

                producToUpdate.Name = updateProduct.Name;
                producToUpdate.Discription = updateProduct.Discription;

                if (updateProduct.ImagePath == null)
                    return NotFound();

                var path = Path.Combine(_environment.WebRootPath, "Images/", updateProduct.ImagePath.FileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await updateProduct.ImagePath.CopyToAsync(stream);
                    stream.Close();
                }
                producToUpdate.ImagePath = path;

                await _productRepository.UpdateProduct(producToUpdate);
                return Ok("Successifully updated");
            }


            [HttpDelete("{productId}")]
            public async Task<IActionResult> DeleteProduct(int productId)
            {
                var productDelete = await _productRepository.GetProduct(productId);

                if (productDelete == null)
                    return NotFound();

                await _productRepository.DeleteProduct(productDelete);
                return (NoContent());
            }


        
    }
}