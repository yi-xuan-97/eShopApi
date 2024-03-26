using AutoMapper;
using eShop.ApplicationCore.Entities;
using eShop.ApplicationCore.Interface.Service;
using eShop.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controller;

// [ApiController]
// [Route("[controller]/[action]")]
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductServiceAsync _productServiceAsync;
    private readonly IMapper _mapper;
    public ProductController(IProductServiceAsync productServiceAsync, IMapper mapper)
    {
        _productServiceAsync = productServiceAsync;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        return Ok(await _productServiceAsync.GetAllProduct());
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetProductByName(string name)
    {
        return Ok(await _productServiceAsync.GetProductByName(name));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        return Ok(await _productServiceAsync.GetProductById(id));
    }
    //
    // [HttpGet]
    // public async Task<IActionResult> GetProductCount()
    // {
    //     return Ok(await _productServiceAsync.GetProductCountAsync());
    // }
    

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product obj)
    {
        return Ok(await _productServiceAsync.AddNewProduct(_mapper.Map<ProductRequestModel>(obj)));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return Ok(await _productServiceAsync.DeleteProductById(id));
    }
}