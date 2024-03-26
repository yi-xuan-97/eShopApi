using Customer.ApplicationCore.RepositoryInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controller;

[Route("api/[controller]")]
[ApiController]
// [Authorize(Roles = "Admin")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;

    public CustomerController(ICustomerRepositoryAsync customerRepository)
    {
        _customerRepositoryAsync = customerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
        return Ok(await _customerRepositoryAsync.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(ApplicationCore.Entity.Customer obj)
    {
        try
        {
            var result = await _customerRepositoryAsync.InsertAsync(obj);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
}