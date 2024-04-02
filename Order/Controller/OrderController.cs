using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public OrderController(IOrderServiceAsync repo)
    {
        _orderServiceAsync = repo;
        _notification = new Notification();
    }
    
    [HttpPost("{message}")]
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

    [HttpGet("{CustomerId}")]
    public async Task<IActionResult> GetOrderByCustomerId(int id)
    {
        return Ok(await _orderServiceAsync.GetOrderByCustomerId(id));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        return Ok(await _orderServiceAsync.GetOrderById(id));
    }


    [HttpPost]
    public async Task<IActionResult> AddProduct(Orders obj)
    {
        return Ok(await _orderServiceAsync.AddNewOrder(_mapper.Map<OrderRequestModel>(obj)));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await _orderServiceAsync.DeleteOrderById(id));
    }
    
    
}