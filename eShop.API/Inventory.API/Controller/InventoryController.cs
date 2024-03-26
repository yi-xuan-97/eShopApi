using Inventory.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controller;

[ApiController]
[Route("[controller]/[action]")]
public class InventoryController : ControllerBase
{
    private RabbitMqQueueReader reader;

    public InventoryController()
    {
        reader = new RabbitMqQueueReader();
    }
    [HttpGet]
    public IActionResult GetMessage()
    {
        reader.ReadMessage();
        return Ok();
    }
    
}