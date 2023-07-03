namespace PurchaseListApi.Models;

public class PurchaseList
{
    public long Id { get; set; }
    public string? StringDate { get; set; }
    public List<Item>? Items { get; set; }
}