using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controller;

[ApiController]
[Route("[controller]/[action]")]
public class ReviewController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("This is working");
    }
}