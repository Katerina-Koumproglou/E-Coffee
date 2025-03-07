using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Cart> Cart { get; set; } = null!;
       

        public DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.email).IsUnique();

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.pid);

            modelBuilder.Entity<Cart>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.uid);
        }
    }
}