using Order.ApplicationCore.Model.Request;
using Order.ApplicationCore.Model.Response;

namespace Order.ApplicationCore.Interface.Service;

public interface IOrderServiceAsync
{
    Task<IEnumerable<OrderResponseModel>> GetAllOrder();
    Task<int> AddNewOrder(OrderRequestModel r);
    Task<int> GetOrderCountAsync();
    Task<IEnumerable<OrderResponseModel>> GetOrderByCustomerId(int id);
    Task<int> DeleteOrderById(int id);
    Task<OrderResponseModel> GetOrderById(int id);
}