using BackEnd.Models;

namespace BackEnd.BusinessLogic
{
    public interface IProductService
    {
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetProductsByCategory(string category);
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductBySlug(string category, string slug);
    }
}