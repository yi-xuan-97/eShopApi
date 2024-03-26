using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrustructure.Data;

public class eShopDbContext:DbContext
{
    public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options)
    {
    }
    public DbSet<ApplicationCore.Entity.Inventory> Inventories { get; set; }
}