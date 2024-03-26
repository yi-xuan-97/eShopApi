using AutoMapper;
using Order.ApplicationCore.Entity;
using Order.ApplicationCore.Interface.Repository;
using Order.ApplicationCore.Interface.Service;
using Order.ApplicationCore.Model.Request;
using Order.ApplicationCore.Model.Response;

namespace Order.Infrustructure.Service;

public class OrderServiceAsync : IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync repo, IMapper mapper)
    {
        _orderRepositoryAsync = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderResponseModel>> GetAllOrder()
    {
        var result = await _orderRepositoryAsync.GetAllAsync();
        List<OrderResponseModel> lst = new List<OrderResponseModel>();
        foreach (Orders r in result)
        {
            OrderResponseModel m = _mapper.Map<OrderResponseModel>(r);
            lst.Add(m);
        }

        return lst;
    }

    public async Task<int> AddNewOrder(OrderRequestModel r)
    {
        Orders o = new Orders()
        {
            CustomerId = r.CustomerId,
            ProductId = r.ProductId,
            ShipperId = r.ShipperId,
            OrderDate = r.OrderDate,
            TotalPrice = r.TotalPrice
        };
        return await _orderRepositoryAsync.InsertAsync(o);
    }

    public async Task<int> GetOrderCountAsync()
    {
        var allproduct = await _orderRepositoryAsync.GetAllAsync();
        return allproduct.Count();
    }

    public async Task<IEnumerable<OrderResponseModel>> GetOrderByCustomerId(int id)
    {
        var result = await _orderRepositoryAsync.Filter(x => x.CustomerId == id);
        List<OrderResponseModel> lst = new List<OrderResponseModel>();
        foreach (Orders o in result)
        {
            OrderResponseModel m = _mapper.Map<OrderResponseModel>(o);
            lst.Add(m);
        }

        return lst;
    }

    public async Task<int> DeleteOrderById(int id)
    {
        return await _orderRepositoryAsync.DeleteAsync(id);
    }

    public async Task<OrderResponseModel> GetOrderById(int id)
    {
        var result = await _orderRepositoryAsync.GetByIdAsync(id);
        OrderResponseModel m = _mapper.Map<OrderResponseModel>(result);
        return m;
    }
}