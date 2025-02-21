using BackEnd.Data;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            return await _context.Products.Where(p => p.category == category).ToListAsync();
        }

        public async Task<Product?> GetProductBySlug(string category, string slug)
        {
            return await _context.Products.Where(p => p.category == category && p.slug == slug).FirstOrDefaultAsync();
        }
    }
}