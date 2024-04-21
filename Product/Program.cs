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

// builder.Services.AddDbContext<eShopDbContext>(option =>
// {
//     option.UseSqlServer(builder.Configuration.GetConnectionString("eShopDbConnection"));
// });

builder.Services.AddDbContext<eShopDbContext>(option =>
{
    // option.UseSqlServer(Environment.GetEnvironmentVariable("eShopDb"));
    option.UseSqlServer(
        "Server=tcp:yfeng.database.windows.net,1433;Initial Catalog=eShopDb;Persist Security Info=False;User ID=yfeng;Password=NewStrongPassword456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
});

builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

var AngularUrl = Environment.GetEnvironmentVariable("angularURL");

app.UseCors(policy =>
{
    policy.WithOrigins(AngularUrl).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
});


app.MapControllers();

app.Run();