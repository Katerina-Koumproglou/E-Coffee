using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

public interface ICartService
{
    Task<bool> AddToCartAsync(int userId, int productId);
    Task<bool> RemoveFromCartAsync(int userId, int productId);
    Task<IEnumerable<Product>> GetCartProductsAsync(int userId);
}