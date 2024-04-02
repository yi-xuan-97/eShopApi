using System.Linq.Expressions;
using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.Interface.Repository;
using eShop.ApplicationCore.Interface.Service;

namespace Prodduct.UnitTest;

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
    public Task<int> InsertAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var result = new List<Product>
        {

        };
        return result;
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> Filter(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }
}