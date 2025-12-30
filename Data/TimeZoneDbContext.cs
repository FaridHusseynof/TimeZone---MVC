using Microsoft.EntityFrameworkCore;
using TimeZone.Models;

namespace TimeZone.Data
{
    public class TimeZoneDbContext : DbContext
    {
        public TimeZoneDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Summary> summary { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
    }
}
