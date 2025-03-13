using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Data;

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

        [HttpPut("{userId}")]
        public IActionResult UpdateCartItem(int userId, [FromBody] CartItemDto cartUpdateDto)
        {
            var cartItem = _context.Cart.FirstOrDefault(c => c.uid == userId && c.pid == cartUpdateDto.ProductId);
            if (cartItem == null) return NotFound("Το προϊόν δεν βρέθηκε στο καλάθι.");

            cartItem.quantity = cartUpdateDto.Quantity;
            _context.SaveChanges();

            return Ok(new { message = "Το καλάθι ενημερώθηκε επιτυχώς." });
        }
    }

    public class CartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}