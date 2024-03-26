using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entity;

namespace Order.Infrustructure.Data;

public class eShopDbContext: DbContext
{
    public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options)
    {

    }

    public DbSet<Orders> Orders { get; set; }
}