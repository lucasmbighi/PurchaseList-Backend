namespace PurchaseListAPI.Models;

public class StockItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public double Quantity { get; set; }
    public string? Unity { get; set; }
}