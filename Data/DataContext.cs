using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
        .Property(p => p.Id)
        .UseIdentityColumn();

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }

}
