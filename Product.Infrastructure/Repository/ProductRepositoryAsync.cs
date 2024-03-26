using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.Interface.Repository;
using eShop.ApplicationCore.Model.Response;
using eShop.Infrastructure.Data;

namespace eShop.Infrastructure.Repository;

public class ProductRepositoryAsync: BaseRepositoryAsync<Product>, IProductRepositoryAsync
{
    public ProductRepositoryAsync(eShopDbContext dbContext) : base(dbContext)
    {
    }
}