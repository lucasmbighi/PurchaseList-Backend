using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using PurchaseListAPI.Models;

public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> options)
        : base(options)
    {
    }

    public DbSet<StockItem> StockItems { get; set; } = null!;
}

