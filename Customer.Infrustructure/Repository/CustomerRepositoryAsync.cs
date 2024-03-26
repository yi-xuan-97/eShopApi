using Customer.ApplicationCore.RepositoryInterface;
using Customer.Infrustructure.Data;

namespace Customer.Infrustructure.Repository;

public class CustomerRepositoryAsync: BaseRepositoryAsync<ApplicationCore.Entity.Customer>, ICustomerRepositoryAsync
{
    public CustomerRepositoryAsync(eShopDbContext dbContext) : base(dbContext)
    {
    }
}