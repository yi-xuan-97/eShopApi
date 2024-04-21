using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Interface.Repository;
using Order.ApplicationCore.Interface.Service;
using Order.Infrustructure.Data;
using Order.Infrustructure.Repository;
using Order.Infrustructure.Service;

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
    option.UseSqlServer(Environment.GetEnvironmentVariable("eShopDb"));
});

builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
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

app.MapControllers();

app.Run();