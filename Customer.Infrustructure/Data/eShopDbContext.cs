using Microsoft.EntityFrameworkCore;

namespace Customer.Infrustructure.Data;

public class eShopDbContext: DbContext
{
    public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options)
    {
        
    }
    public DbSet<ApplicationCore.Entity.Customer> Customers { get; set; }
}