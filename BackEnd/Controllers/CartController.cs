using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Data;
using Azure.Core;
using System.Runtime.InteropServices;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ApplicationDbContext _context;

        public CartController(ICartService cartService, ApplicationDbContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        [HttpGet("quantities/{userId}")]
        public async Task<IActionResult> GetCartWithQuantities(int userId)
        {
            var cartItems = await _cartService.GetCartWithQuantitiesAsync(userId);
            if (!cartItems.Any())
            {
                return NotFound(new { message = "No items found in the cart." });
            }

            return Ok(cartItems);
        }

        [HttpPost("quantities/modification")]
        public async Task<IActionResult> ModifyCartQuantities([FromBody] CartRequest request)
        {
            Console.WriteLine("request.UserId: " + request.UserId + " request.ProductId: " + request.ProductId + " request.Quantity: " + request.Quantity);
            var result = await _cartService.UpdateCartItemAsync(request.UserId, request.ProductId, request.Quantity);
            if (!result)
            {
                return NotFound(new { message = "Product not found in cart." });
            }

            return Ok(new { message = "Cart updated successfully." });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            var result = await _cartService.AddToCartAsync(request.UserId, request.ProductId, request.Quantity);
            if (result)
            {
                return Ok(new { message = "Product added to cart successfully." });
            }
            return BadRequest(new { message = "Product was not added to cart." });
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] CartRequest request)
        {
            var result = await _cartService.RemoveFromCartAsync(request.UserId, request.ProductId, request.Quantity);
            if (result)
            {
                return Ok(new { message = "Product removed from cart successfully." });
            }
            return NotFound(new { message = "Product was not removed from cart." });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartProducts(int userId)
        {
            var products = await _cartService.GetCartProductsAsync(userId);
            return Ok(products);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateCartItem(int userId, [FromBody] CartRequest request)
        {
            var result = await _cartService.UpdateCartItemAsync(userId, request.ProductId, request.Quantity);
            if (!result)
            {
                return NotFound(new { message = "Product not found in cart." });
            }

            return Ok(new { message = "Cart updated successfully." });
        }
    }

    public class CartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}