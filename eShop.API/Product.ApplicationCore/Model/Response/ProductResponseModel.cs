using eShop.ApplicationCore.Entities;

namespace eShop.ApplicationCore.Model.Response;

public class ProductResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public int Stock { get; set; }
    public List<Review> Reviews { get; set; }
}