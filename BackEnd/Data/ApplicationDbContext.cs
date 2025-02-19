using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BackEnd.Models.Capsule> Capsules { get; set; }
        public DbSet<BackEnd.Models.Machine> Machines { get; set; }
        public DbSet<BackEnd.Models.Accessory> Accessories { get; set; }
        public DbSet<BackEnd.Models.Beverage> Beverages { get; set; }
    }
}