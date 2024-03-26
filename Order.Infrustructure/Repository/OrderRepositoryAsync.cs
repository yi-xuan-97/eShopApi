using Order.ApplicationCore.Entity;
using Order.ApplicationCore.Interface.Repository;
using Order.Infrustructure.Data;

namespace Order.Infrustructure.Repository;

public class OrderRepositoryAsync: BaseRepositoryAsync<Orders>, IOrderRepositoryAsync
{
    public OrderRepositoryAsync(eShopDbContext dbContext) : base(dbContext)
    {
    }
}