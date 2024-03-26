using AutoMapper;
using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.Interface.Repository;
using eShop.ApplicationCore.Interface.Service;
using eShop.ApplicationCore.Model.Request;
using eShop.ApplicationCore.Model.Response;

namespace eShop.Infrastructure.Service;

public class ProductServiceAsync: IProductServiceAsync
{
    private readonly IProductRepositoryAsync _productRepositoryAsync;
    private readonly IMapper _mapper;
    public ProductServiceAsync(IProductRepositoryAsync repo, IMapper mapper)
    {
        _productRepositoryAsync = repo;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductResponseModel>> GetAllProduct()
    {
        var result = await _productRepositoryAsync.GetAllAsync();
        List<ProductResponseModel> lst = new List<ProductResponseModel>();
        foreach (Product r in result)
        {
            ProductResponseModel m = _mapper.Map<ProductResponseModel>(r);
            lst.Add(m);
        }

        return lst;
    }

    public async Task<int> AddNewProduct(ProductRequestModel r)
    {
        Product product = new Product()
        {
            Name = r.Name,
            Description = r.Description,
            Price = r.Price,
            Category = r.Category,
            Stock = r.Stock
        };
        return await _productRepositoryAsync.InsertAsync(product);
    }

    public async Task<int> GetProductCountAsync()
    {
        var allproduct = await _productRepositoryAsync.GetAllAsync();
        return allproduct.Count();
    }

    public async Task<IEnumerable<ProductResponseModel>> GetProductByName(string name)
    {
        var result = await _productRepositoryAsync.Filter(x => x.Name == name);
        List<ProductResponseModel> lst = new List<ProductResponseModel>();
        foreach (Product r in result)
        {
            ProductResponseModel m = _mapper.Map<ProductResponseModel>(r);
            lst.Add(m);
        }

        return lst;
    }

    public async Task<int> DeleteProductById(int id)
    {
        return await _productRepositoryAsync.DeleteAsync(id);
    }

    public async Task<ProductResponseModel> GetProductById(int id)
    {
        var result = await _productRepositoryAsync.GetByIdAsync(id);
        ProductResponseModel m = _mapper.Map<ProductResponseModel>(result);
        return m;
    }
}