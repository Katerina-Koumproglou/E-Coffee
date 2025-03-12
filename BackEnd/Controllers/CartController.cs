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
                return Ok(new { message = "Το προϊόν προστέθηκε στο καλάθι!" });
            }
            return BadRequest(new { message = "Το προϊόν υπάρχει ήδη στο καλάθι." });
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromBody] CartRequest request)
        {
            var result = await _cartService.RemoveFromCartAsync(request.UserId, request.ProductId);
            if (result)
            {
                return Ok(new { message = "Το προϊόν αφαιρέθηκε από το καλάθι!" });
            }
            return NotFound(new { message = "Το προϊόν δεν βρέθηκε στο καλάθι." });
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
[HttpPost("add")]
public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
{
    Console.WriteLine($"Received request: UserId={request.UserId}, ProductId={request.ProductId}");

    if (request.UserId == 0 || request.ProductId == 0)
    {
        return BadRequest(new { message = "Μη έγκυρα δεδομένα." });
    }

    var result = await _cartService.AddToCartAsync(request.UserId, request.ProductId);
    if (result)
    {
        return Ok(new { message = "Το προϊόν προστέθηκε στο καλάθι!" });
    }
    return BadRequest(new { message = "Το προϊόν υπάρχει ήδη στο καλάθι." });
}

[HttpGet("{userId}")]
public async Task<IActionResult> GetCartProducts(int userId)
{
    var products = await _cartService.GetCartProductsAsync(userId);
    return Ok(products);
}


