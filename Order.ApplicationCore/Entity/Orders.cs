using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.ApplicationCore.Entity;

public class Orders
{
    // public int Id { get; set; }
    // public int CustomerId { get; set; }
    // public int ProductId { get; set; }
    // public int ShipperId { get; set; }
    // public DateTime OrderDate { get; set; }
    // public decimal TotalPrice { get; set; }

    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; }
    

    public string CustomerName { get; set; }

    [DataType(DataType.Date)] public DateTime OrderDate { get; set; }

    public int Amount { get; set; }

    [Column(TypeName = "decimal(10, 2)")] public decimal Price { get; set; }

    [Column(TypeName = "decimal(10, 2)")] public decimal TotalPrice { get; set; }
    
}