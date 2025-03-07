using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Models;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;

    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddToCartAsync(int userId, int productId)
    {
        var cartItemExists = await _context.Cart.AnyAsync(c => c.uid == userId && c.pid == productId);
        if (cartItemExists)
        {
            return false; // Product is already in the cart
        }

        var newCartItem = new Cart
        {
            uid = userId,
            pid = productId
        };

        _context.Cart.Add(newCartItem);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveFromCartAsync(int userId, int productId)
    {
        var cartItem = await _context.Cart.FirstOrDefaultAsync(c => c.uid == userId && c.pid == productId);
        if (cartItem == null)
        {
            return false;
        }

        _context.Cart.Remove(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Product>> GetCartProductsAsync(int userId)
    {
        return await _context.Cart
            .Where(c => c.uid == userId)
            .Select(c => c.Product)
            .ToListAsync();
    }
}