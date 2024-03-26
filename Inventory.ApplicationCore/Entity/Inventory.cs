namespace Inventory.ApplicationCore.Entity;

public class Inventory
{
    public int InventoryItemId { get; set; } // Primary key

    public string ProductName { get; set; }

    public string SKU { get; set; }

    public string Category { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice => Quantity * UnitPrice; // Calculated property

    public int SupplierId { get; set; }

    public string SupplierName { get; set; }

    public DateTime LastUpdated { get; set; }

    public string Location { get; set; }

    public int MinStockLevel { get; set; }

    public int MaxStockLevel { get; set; }

    public int ReorderPoint { get; set; }

    public string Notes { get; set; }
}