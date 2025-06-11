using Microsoft.EntityFrameworkCore;
using MiniStokTakipAPI.Models;

namespace MiniStokTakipAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
    }
}
