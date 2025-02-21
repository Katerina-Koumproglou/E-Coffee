using BackEnd.Models;

namespace BackEnd.BusinessLogic
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsByCategory(string category);
        Task<Product?> GetProductBySlug(string category, string slug);
    }
}