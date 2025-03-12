using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BackEnd.Models;

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

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            var result = await _cartService.AddToCartAsync(request.UserId, request.ProductId);
            if (result)
            {
                return Ok(new { message = "Product added to cart successfully." });
            }
            return BadRequest(new { message = "Product was not added to cart." });
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] CartRequest request)
        {
            var result = await _cartService.RemoveFromCartAsync(request.UserId, request.ProductId);
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
    }

    public class CartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
//[HttpPost("add")]
//public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
//{
//    Console.WriteLine($"Received request: UserId={request.UserId}, ProductId={request.ProductId}");

//    if (request.UserId == 0 || request.ProductId == 0)
//    {
//        return BadRequest(new { message = "�� ������ ��������." });
//    }

//    var result = await _cartService.AddToCartAsync(request.UserId, request.ProductId);
//    if (result)
//    {
//        return Ok(new { message = "�� ������ ���������� ��� ������!" });
//    }
//    return BadRequest(new { message = "�� ������ ������� ��� ��� ������." });
//}

//[HttpGet("{userId}")]
//public async Task<IActionResult> GetCartProducts(int userId)
//{
//    var products = await _cartService.GetCartProductsAsync(userId);
//    return Ok(products);
//}


