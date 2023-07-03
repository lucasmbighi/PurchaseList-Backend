using Microsoft.EntityFrameworkCore;
using PurchaseListApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PurchaseListContext>(opt =>
    opt.UseInMemoryDatabase("PurchaseListList"));
builder.Services.AddDbContext<StockContext>(opt =>
    opt.UseInMemoryDatabase("StockList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

