using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PurchaseListApi.Models;

public class PurchaseListContext : DbContext
{
    public PurchaseListContext(DbContextOptions<PurchaseListContext> options)
    : base(options)
    {
    }

    public DbSet<PurchaseList> PurchaseLists { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
}