using AutoMapper;
using eShop.ApplicationCore.Interface.Repository;
using eShop.ApplicationCore.Interface.Service;
using eShop.Infrastructure.Data;
using eShop.Infrastructure.Repository;
using eShop.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<eShopDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("eShopDbConnection"));
});

// builder.Services.AddDbContext<eShopDbContext>(option =>
// {
//     option.UseSqlServer(Environment.GetEnvironmentVariable("eShopDb"));
// });

builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddAutoMapper(typeof(Program));



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