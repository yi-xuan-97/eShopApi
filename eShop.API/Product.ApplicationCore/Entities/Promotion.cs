namespace eShop.ApplicationCore.Entities;

public class Promotion
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}