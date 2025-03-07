using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BackEnd.Models;
using System.IO.Pipes;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int uid,int pid)//[FromBody] CartItemDto cartItem
        {
            var result = await _cartService.AddToCartAsync(uid,pid); //cartItem.UserId, cartItem.ProductId
            if (result)
            {
                return Ok();
            }
            return BadRequest("Failed to add item to cart");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(int uid,int pid) //[FromBody] CartItemDto cartItem
        {
            var result = await _cartService.RemoveFromCartAsync(uid,pid); //cartItem.UserId, cartItem.ProductId
            if (result)
            {
                return Ok();
            }
            return BadRequest("Failed to remove item from cart");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartProducts(int userId)
        {
            var products = await _cartService.GetCartProductsAsync(userId);
            return Ok(products);
        }
    }
}