using eShop.ApplicationCore.Model.Request;
using eShop.ApplicationCore.Model.Response;

namespace eShop.ApplicationCore.Interface.Service;

public interface IProductServiceAsync
{
    Task<IEnumerable<ProductResponseModel>> GetAllProduct();
    Task<int> AddNewProduct(ProductRequestModel r);
    Task<int> GetProductCountAsync();
    Task<IEnumerable<ProductResponseModel>> GetProductByName(string name);
    Task<int> DeleteProductById(int id);
    Task<ProductResponseModel> GetProductById(int id);
}