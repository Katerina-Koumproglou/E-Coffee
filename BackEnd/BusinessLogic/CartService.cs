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

    public async Task<IEnumerable<Cart>> GetCartWithQuantitiesAsync(int userId)
    {
        return await _context.Cart
            .Where(c => c.uid == userId)
            .Include(c => c.Product) // Include related product details if needed
            .ToListAsync();
    }

    public async Task<bool> AddToCartAsync(int userId, int productId, int quantity = 1)
    {
        var productExists = await _context.Products.AnyAsync(p => p.id == productId);
        if (!productExists)
        {
            return false;
        }

        var cartItemExists = await _context.Cart.FirstOrDefaultAsync(c => c.uid == userId && c.pid == productId);
        if (cartItemExists != null)
        {
            cartItemExists.quantity += quantity;
        }
        else
        {
            var newCartItem = new Cart
            {
                uid = userId,
                pid = productId,
                quantity = quantity
            };
            _context.Cart.Add(newCartItem);
        }

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveFromCartAsync(int userId, int productId, int quantity)
    {
        try
        {
            var cartItem = await _context.Cart.FirstOrDefaultAsync(c => c.uid == userId && c.pid == productId && c.quantity == quantity);
            if (cartItem == null)
            {
                // ���������� false �� �� ������ ��� ������� ��� ������
                return false;
            }

            _context.Cart.Remove(cartItem);
            await _context.SaveChangesAsync(); // ���������� ��� ������� ��� ����

            return true;
        }
        catch (Exception ex)
        {
            // ��������� ������ �� ��������� ���������
            Console.WriteLine($"������ ���� ��� ���������� ���������: {ex.Message}");
            return false;
        }
    }


    public async Task<IEnumerable<Product>> GetCartProductsAsync(int userId)
    {
        return await _context.Cart
            .Where(c => c.uid == userId)
            .Select(c => c.Product)
            .ToListAsync();
    }

    public async Task<bool> UpdateCartItemAsync(int userId, int productId, int quantity)
    {
        var cartItem = await _context.Cart.FirstOrDefaultAsync(c => c.uid == userId && c.pid == productId);

        if (cartItem == null)
        {
            return false;
        }

        cartItem.quantity = quantity;
        await _context.SaveChangesAsync();
        return true;
    }
}