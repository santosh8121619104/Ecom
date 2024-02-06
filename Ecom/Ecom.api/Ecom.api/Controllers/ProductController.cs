using Ecom.BusinessLayer.Interfaces;
using Ecom.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            var product = await _productService.GetProductById(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            bool isProductAdded = await _productService.AddProduct(product);

            if (isProductAdded)
            {
                return Ok("Product added successfully");
            }
            else
            {
                return BadRequest("Failed to add product");
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(string productId, [FromBody] Product product)
        {
            bool isProductUpdated = await _productService.UpdateProduct(product);

            if (isProductUpdated)
            {
                return Ok("Product updated successfully");
            }
            else
            {
                return BadRequest("Failed to update product");
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            bool isProductDeleted = await _productService.DeleteProduct(productId);

            if (isProductDeleted)
            {
                return Ok("Product deleted successfully");
            }
            else
            {
                return BadRequest("Failed to delete product");
            }
        }
    }

}
