using BackEnd.BusinessLogic;
using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("products")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var products = await _productService.GetProductsByCategory(category);

            if (products == null || !products.Any())
            {
                return NotFound($"No products found for category: {category}");
            }

            return Ok(products);
        }

        [HttpGet("{category}/{slug}")]
        public async Task<IActionResult> GetProductBySlug(string category, string slug)
        {
            var product = await _productService.GetProductBySlug(category, slug);

            if (product == null)
            {
                return BadRequest("Invalid product data");
            }

            return Ok(product);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound($"No product found with ID: {id}");
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            if (products == null || !products.Any())
            {
                return NotFound("No products found");
            }

            return Ok(products);
        }
    }
}