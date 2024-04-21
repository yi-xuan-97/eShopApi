using AutoMapper;
// using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order.API.Helper;
using Order.ApplicationCore.Entity;
using Order.ApplicationCore.Interface.Service;
using Order.ApplicationCore.Model.Request;
using Order.ApplicationCore.Model.Response;

namespace Order.API.Controller;

// [ApiController]
// [Route("[controller]/[action]")]
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private Notification _notification;
    private readonly IOrderServiceAsync _orderServiceAsync;
    private IMapper _mapper;

    public OrderController(IOrderServiceAsync repo, IMapper mapper)
    {
        _orderServiceAsync = repo;
        _notification = new Notification();
        _mapper = mapper;
    }
    
    [HttpPost(template: "bymessage/{message}")]
    public IActionResult CreateOrder(string message)
    {
        _notification.AddMessageToQueue(message);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrder()
    {
        return Ok(await _orderServiceAsync.GetAllOrder());
    }

    [HttpGet(template: "bycustomer/{CustomerName}")]
    public async Task<IActionResult> GetOrderByCustomerId(string CustomerName)
    {
        return Ok(await _orderServiceAsync.GetOrderByCustomer(CustomerName));
    }

    [HttpGet(template: "byid/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        return Ok(await _orderServiceAsync.GetOrderById(id));
    }


    [HttpPost]
    public async Task<IActionResult> AddOrder(Orders obj)
    {
        return Ok(await _orderServiceAsync.AddNewOrder(_mapper.Map<OrderRequestModel>(obj)));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await _orderServiceAsync.DeleteOrderById(id));
    }
    
    
}