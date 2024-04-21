namespace Order.ApplicationCore.Model.Request;

public class OrderRequestModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
}