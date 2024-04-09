using System.Linq.Expressions;
using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.Interface.Repository;
using eShop.ApplicationCore.Interface.Service;

namespace Product.UnitTest;

public class ProductServiceUnitTest
{
    private IProductServiceAsync _productServiceAsync;
    [SetUp]
    public void Setup(IProductServiceAsync serviceAsync)
    {
        _productServiceAsync = serviceAsync;
    }

    [Test]
    public async Task TestListOf()
    {
        var products = await _productServiceAsync.GetAllProduct();
        Assert.NotNull(products);
    }
}

public class MockProductRepository : IProductRepositoryAsync
{
    public Task<int> InsertAsync(eShop.ApplicationCore.Entities.Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(eShop.ApplicationCore.Entities.Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<eShop.ApplicationCore.Entities.Product>> GetAllAsync()
    {
        var result = new List<eShop.ApplicationCore.Entities.Product>
        {

        };
        return result;
    }

    public Task<eShop.ApplicationCore.Entities.Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<eShop.ApplicationCore.Entities.Product>> Filter(Expression<Func<eShop.ApplicationCore.Entities.Product, bool>> filter)
    {
        throw new NotImplementedException();
    }
}