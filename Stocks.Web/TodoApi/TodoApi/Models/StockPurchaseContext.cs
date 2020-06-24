using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class StockPurchaseContext : DbContext
    {
        public StockPurchaseContext(DbContextOptions<StockPurchaseContext> options) : base(options)
        {
        }
        public DbSet<StockPurchase> StockPurchases { get; set; }

    }
}