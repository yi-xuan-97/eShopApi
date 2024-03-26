namespace eShop.ApplicationCore.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<int> ProductIds { get; set; }
}