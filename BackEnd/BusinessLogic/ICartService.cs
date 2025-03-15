using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

public interface ICartService
{
    Task<bool> AddToCartAsync(int userId, int productId, int quantity = 1);
    Task<bool> RemoveFromCartAsync(int userId, int productId, int quantity);
    Task<IEnumerable<Product>> GetCartProductsAsync(int userId);
    Task<bool> UpdateCartItemAsync(int userId, int productId, int quantity);
}